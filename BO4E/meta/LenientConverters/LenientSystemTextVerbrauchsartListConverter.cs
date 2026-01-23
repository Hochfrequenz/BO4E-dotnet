#nullable enable
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using BO4E.ENUM;

namespace BO4E.meta.LenientConverters;

/// <summary>
/// A lenient JSON converter for <see cref="List{T}"/> of <see cref="Verbrauchsart"/> that handles
/// malformed historic data where values may be nested in arrays.
/// </summary>
/// <remarks>
/// This converter was created to handle historic data stored in databases when the Verbrauchsarten
/// property did not exist (prior to v0.31.0). The data was stored in UserProperties with formats like:
/// <list type="bullet">
/// <item><description>{"Verbrauchsarten": [[]]} - empty nested list</description></item>
/// <item><description>{"Verbrauchsarten": [[0]]} - nested list with integer value</description></item>
/// <item><description>{"Verbrauchsarten": [[], 0]} - mixed nested list and value</description></item>
/// <item><description>{"Verbrauchsarten": [["KL"]]} - nested list with string value</description></item>
/// </list>
/// The converter extracts valid Verbrauchsart values from any nesting level and ignores invalid entries.
/// Note: Enum.TryParse is used which matches by member name (e.g., "KL"), which happens to match
/// the [EnumMember] attribute values in this case.
/// </remarks>
public class LenientSystemTextVerbrauchsartListConverter : JsonConverter<List<Verbrauchsart>?>
{
    /// <summary>
    /// Maximum recursion depth to prevent stack overflow from malicious/malformed deeply nested JSON.
    /// </summary>
    private const int MaxRecursionDepth = 64;

    /// <inheritdoc />
    public override List<Verbrauchsart>? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        if (reader.TokenType == JsonTokenType.Null)
        {
            return null;
        }

        if (reader.TokenType != JsonTokenType.StartArray)
        {
            // If it's not an array, try to read a single value
            var singleValue = TryReadSingleValue(ref reader);
            if (singleValue.HasValue)
            {
                return new List<Verbrauchsart> { singleValue.Value };
            }
            return new List<Verbrauchsart>();
        }

        var result = new List<Verbrauchsart>();
        ExtractVerbrauchsartValues(ref reader, result, 0);
        return result;
    }

    private void ExtractVerbrauchsartValues(
        ref Utf8JsonReader reader,
        List<Verbrauchsart> result,
        int depth
    )
    {
        // Prevent stack overflow from deeply nested arrays
        if (depth > MaxRecursionDepth)
        {
            SkipCurrentArray(ref reader);
            return;
        }

        // reader is positioned at StartArray
        while (reader.Read())
        {
            switch (reader.TokenType)
            {
                case JsonTokenType.EndArray:
                    return;

                case JsonTokenType.StartArray:
                    // Recursively process nested arrays with increased depth
                    ExtractVerbrauchsartValues(ref reader, result, depth + 1);
                    break;

                case JsonTokenType.Number:
                    if (reader.TryGetInt32(out var intValue))
                    {
                        if (Enum.IsDefined(typeof(Verbrauchsart), intValue))
                        {
                            result.Add((Verbrauchsart)intValue);
                        }
                        // Skip invalid integer values silently
                    }
                    break;

                case JsonTokenType.String:
                    var stringValue = reader.GetString();
                    if (!string.IsNullOrEmpty(stringValue))
                    {
                        if (
                            Enum.TryParse<Verbrauchsart>(
                                stringValue,
                                ignoreCase: true,
                                out var enumValue
                            )
                        )
                        {
                            result.Add(enumValue);
                        }
                        // Skip invalid string values silently
                    }
                    break;

                case JsonTokenType.Null:
                    // Skip null values
                    break;

                case JsonTokenType.StartObject:
                    // Skip objects - read until end of object
                    SkipObject(ref reader);
                    break;

                default:
                    // Skip other token types (true, false, etc.)
                    break;
            }
        }
    }

    private Verbrauchsart? TryReadSingleValue(ref Utf8JsonReader reader)
    {
        switch (reader.TokenType)
        {
            case JsonTokenType.Number:
                if (
                    reader.TryGetInt32(out var intValue)
                    && Enum.IsDefined(typeof(Verbrauchsart), intValue)
                )
                {
                    return (Verbrauchsart)intValue;
                }
                break;

            case JsonTokenType.String:
                var stringValue = reader.GetString();
                if (
                    !string.IsNullOrEmpty(stringValue)
                    && Enum.TryParse<Verbrauchsart>(
                        stringValue,
                        ignoreCase: true,
                        out var enumValue
                    )
                )
                {
                    return enumValue;
                }
                break;
        }

        return null;
    }

    private void SkipCurrentArray(ref Utf8JsonReader reader)
    {
        var depth = 1;
        while (depth > 0 && reader.Read())
        {
            if (reader.TokenType == JsonTokenType.StartArray)
                depth++;
            else if (reader.TokenType == JsonTokenType.EndArray)
                depth--;
        }
    }

    private void SkipObject(ref Utf8JsonReader reader)
    {
        var depth = 1;
        while (depth > 0 && reader.Read())
        {
            if (reader.TokenType == JsonTokenType.StartObject)
                depth++;
            else if (reader.TokenType == JsonTokenType.EndObject)
                depth--;
        }
    }

    /// <inheritdoc />
    /// <remarks>
    /// Writes a flat array of enum values using the serializer's configured enum converter.
    /// This maintains compatibility with the default serialization behavior.
    /// </remarks>
    public override void Write(
        Utf8JsonWriter writer,
        List<Verbrauchsart>? value,
        JsonSerializerOptions options
    )
    {
        if (value == null)
        {
            writer.WriteNullValue();
            return;
        }

        writer.WriteStartArray();
        foreach (var item in value)
        {
            // Serialize each enum value individually, respecting enum converter settings
            JsonSerializer.Serialize(writer, item, options);
        }
        writer.WriteEndArray();
    }
}
