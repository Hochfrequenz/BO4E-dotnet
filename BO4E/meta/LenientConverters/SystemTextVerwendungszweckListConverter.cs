namespace BO4E.meta.LenientConverters;

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using BO4E.ENUM;

/// <summary>
/// Converter for a list of Verwendungszweck, using System.Text.Json
/// </summary>
public class VerwendungszweckListConverter : JsonConverter<List<Verwendungszweck>?>
{
    /// <inheritdoc />
    public override List<Verwendungszweck>? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        if (reader.TokenType == JsonTokenType.Null)
        {
            return null;
        }

        var items = new List<Verwendungszweck>();
        if (reader.TokenType == JsonTokenType.StartArray)
        {
            var adaptedOptions = new JsonSerializerOptions()
            {
                Converters = { new SystemTextVerwendungszweckStringEnumConverter() },
            };
            reader.Read();
            while (reader.TokenType != JsonTokenType.EndArray)
            {
                // Attempt to read each item in the array as Verwendungszweck
                var item = JsonSerializer.Deserialize<Verwendungszweck>(ref reader, adaptedOptions);
                items.Add(item);
                reader.Read();
            }
        }

        return items;
    }

    /// <inheritdoc />
    public override void Write(
        Utf8JsonWriter writer,
        List<Verwendungszweck>? value,
        JsonSerializerOptions options
    )
    {
        if (value is null)
        {
            writer.WriteNullValue();
        }
        else
        {
            writer.WriteStartArray();
            foreach (var item in value)
            {
                JsonSerializer.Serialize(writer, item, options);
            }

            writer.WriteEndArray();
        }
    }
}
