using System;
using System.Collections.Generic;
using BO4E.ENUM;
using Newtonsoft.Json;

namespace BO4E.meta.LenientConverters;

/// <summary>
/// converter for a list of verwendungszwecke
/// </summary>
public class NewtonsoftVerwendungszweckListConverter : JsonConverter<List<Verwendungszweck>?>
{
    /// <inheritdoc />
    public override List<Verwendungszweck>? ReadJson(
        JsonReader reader,
        Type objectType,
        List<Verwendungszweck>? existingValue,
        bool hasExistingValue,
        JsonSerializer serializer
    )
    {
        if (reader.TokenType == JsonToken.Null)
        {
            return null;
        }

        var items = new List<Verwendungszweck>();
        if (reader.TokenType == JsonToken.StartArray)
        {
            reader.Read();
            serializer.Converters.Add(new NewtonsoftVerwendungszweckStringEnumConverter());
            while (reader.TokenType != JsonToken.EndArray)
            {
                var item = serializer.Deserialize<Verwendungszweck>(reader);
                items.Add(item);
                reader.Read();
            }
        }

        return items;
    }

    /// <inheritdoc />
    public override void WriteJson(
        JsonWriter writer,
        List<Verwendungszweck>? value,
        JsonSerializer serializer
    )
    {
        if (value is null)
        {
            writer.WriteNull();
        }
        else
        {
            writer.WriteStartArray();
            foreach (var item in (List<Verwendungszweck>)value)
            {
                serializer.Serialize(writer, item); // Use existing converter for TEnum
            }

            writer.WriteEndArray();
        }
    }
}
