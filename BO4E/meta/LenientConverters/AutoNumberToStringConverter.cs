using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BO4E.meta.LenientConverters;

/// <summary>
/// Helps reading a number that should be converted to a string (e.g. VersionsStruktur)
/// </summary>
public class AutoNumberToStringConverter : JsonConverter<string>
{
    /// <summary>
    /// <inheritdoc cref="JsonConverter{T}.CanConvert(Type)"/>
    /// </summary>
    public override bool CanConvert(Type typeToConvert)
    {
        return typeof(string) == typeToConvert;
    }

    /// <summary>
    /// <inheritdoc cref="JsonConverter{T}.Read(ref Utf8JsonReader, Type, JsonSerializerOptions)"/>
    /// </summary>
    public override string? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        if (reader.TokenType == JsonTokenType.Number)
        {
            if (reader.TryGetInt64(out long number))
            {
                return number.ToString(CultureInfo.InvariantCulture);
            }

            if (reader.TryGetDouble(out var doubleNumber))
            {
                return doubleNumber.ToString(CultureInfo.InvariantCulture);
            }
        }

        if (reader.TokenType == JsonTokenType.String)
        {
            return reader.GetString();
        }

        using var document = JsonDocument.ParseValue(ref reader);
        return document.RootElement.Clone().ToString();
    }

    /// <summary>
    /// <inheritdoc cref="JsonConverter{T}.Write(Utf8JsonWriter, T, JsonSerializerOptions)"/>
    /// </summary>
    public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value);
    }
}
