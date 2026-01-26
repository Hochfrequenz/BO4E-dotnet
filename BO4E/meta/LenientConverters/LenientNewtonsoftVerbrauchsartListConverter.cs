using System;
using System.Collections.Generic;
using BO4E.ENUM;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BO4E.meta.LenientConverters;

/// <summary>
/// A lenient JSON converter for <see cref="List{T}"/> of <see cref="Verbrauchsart"/> that handles
/// malformed historic data where values may be nested in arrays or have unexpected types.
/// </summary>
/// <remarks>
/// This converter was created to handle historic data stored in databases when the Verbrauchsarten
/// property did not exist (prior to v0.31.0). The data was stored in UserProperties with formats like:
/// <list type="bullet">
/// <item><description>{"Verbrauchsarten": [[]]} - empty nested list</description></item>
/// <item><description>{"Verbrauchsarten": [[0]]} - nested list with integer value</description></item>
/// <item><description>{"Verbrauchsarten": [[], 0]} - mixed nested list and value</description></item>
/// <item><description>{"Verbrauchsarten": [["KL"]]} - nested list with string value</description></item>
/// <item><description>{"Verbrauchsarten": {"invalid": "object"}} - object instead of array</description></item>
/// </list>
/// The converter extracts valid Verbrauchsart values from any nesting level and ignores invalid entries.
/// When the input is an unexpected type (e.g., an object), the converter returns an empty list
/// and properly consumes the value to avoid deserialization errors.
/// Note: Enum.TryParse is used which matches by member name (e.g., "KL"), which happens to match
/// the [EnumMember] attribute values in this case.
/// </remarks>
public class LenientNewtonsoftVerbrauchsartListConverter : JsonConverter<List<Verbrauchsart>?>
{
    /// <summary>
    /// Maximum recursion depth to prevent stack overflow from malicious/malformed deeply nested JSON.
    /// </summary>
    private const int MaxRecursionDepth = 64;

    /// <inheritdoc />
    /// <remarks>
    /// Disabled to use default serialization and avoid introducing changes to the write behavior.
    /// This converter is intended only to fix deserialization of malformed historic data.
    /// </remarks>
    public override bool CanWrite => false;

    /// <inheritdoc />
    public override List<Verbrauchsart>? ReadJson(
        JsonReader reader,
        Type objectType,
        List<Verbrauchsart>? existingValue,
        bool hasExistingValue,
        JsonSerializer serializer
    )
    {
        if (reader.TokenType == JsonToken.Null)
        {
            return null;
        }

        var result = new List<Verbrauchsart>();

        if (reader.TokenType == JsonToken.StartArray)
        {
            var jArray = JArray.Load(reader);
            ExtractVerbrauchsartValues(jArray, result, 0);
        }
        else
        {
            // Try to read a single value
            var singleValue = TryParseSingleValue(reader);
            if (singleValue.HasValue)
            {
                result.Add(singleValue.Value);
            }
            else if (reader.TokenType == JsonToken.StartObject)
            {
                // For objects or other unexpected types, we must skip the entire value
                // to leave the reader in the correct position (past the value).
                reader.Skip();
            }
        }

        return result;
    }

    private void ExtractVerbrauchsartValues(JToken token, List<Verbrauchsart> result, int depth)
    {
        // Prevent stack overflow from deeply nested arrays
        if (depth > MaxRecursionDepth)
        {
            return;
        }

        switch (token.Type)
        {
            case JTokenType.Array:
                foreach (var item in (JArray)token)
                {
                    ExtractVerbrauchsartValues(item, result, depth + 1);
                }
                break;

            case JTokenType.Integer:
                var intValue = token.Value<int>();
                if (Enum.IsDefined(typeof(Verbrauchsart), intValue))
                {
                    result.Add((Verbrauchsart)intValue);
                }
                // Skip invalid integer values silently
                break;

            case JTokenType.String:
                var stringValue = token.Value<string>();
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

            case JTokenType.Null:
            case JTokenType.Object:
                // Skip null values and objects
                break;

            default:
                // Skip other token types
                break;
        }
    }

    private Verbrauchsart? TryParseSingleValue(JsonReader reader)
    {
        switch (reader.TokenType)
        {
            case JsonToken.Integer:
                var intValue = Convert.ToInt32(reader.Value);
                if (Enum.IsDefined(typeof(Verbrauchsart), intValue))
                {
                    return (Verbrauchsart)intValue;
                }
                break;

            case JsonToken.String:
                var stringValue = reader.Value?.ToString();
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

    /// <inheritdoc />
    /// <remarks>
    /// This method is not called because <see cref="CanWrite"/> returns false.
    /// The default Newtonsoft.Json serialization is used for writing.
    /// </remarks>
    public override void WriteJson(
        JsonWriter writer,
        List<Verbrauchsart>? value,
        JsonSerializer serializer
    )
    {
        // CanWrite returns false, so this method should never be called.
        // If it is called, delegate to the default serializer behavior.
        throw new NotImplementedException(
            "WriteJson should not be called because CanWrite returns false."
        );
    }
}
