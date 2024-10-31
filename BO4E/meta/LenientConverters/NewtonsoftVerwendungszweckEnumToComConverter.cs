using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BO4E.meta.LenientConverters;

/// <summary>
/// Converts a stringified single <see cref="BO4E.ENUM.Verwendungszweck"/>
/// to a <see cref="BO4E.COM.Verwendungszweck"/> which has the single enum value as member in <see cref="COM.Verwendungszweck.Zweck"/>
/// </summary>
/// /// <remarks><seealso cref="SystemTextVerwendungszweckEnumToComConverter"/></remarks>
public class NewtonsoftVerwendungszweckEnumToComConverter
    : Newtonsoft.Json.JsonConverter<BO4E.COM.Verwendungszweck?>
{
    /// <inheritdoc />
    public override bool CanWrite => false;

    /// <inheritdoc />
    public override void WriteJson(
        JsonWriter writer,
        BO4E.COM.Verwendungszweck? value,
        JsonSerializer serializer
    )
    {
        throw new NotImplementedException(
            "This converter is only intended to work with deserialization; Tests show that this alone is sufficient."
        );
    }

    /// <inheritdoc />
    public override BO4E.COM.Verwendungszweck? ReadJson(
        JsonReader reader,
        Type objectType,
        BO4E.COM.Verwendungszweck? existingValue,
        bool hasExistingValue,
        JsonSerializer serializer
    )
    {
        if (reader.TokenType == JsonToken.Null)
        {
            return null;
        }

        var result = new BO4E.COM.Verwendungszweck
        {
            Marktrolle = ENUM.Marktrolle.LF,
            Zweck = new List<ENUM.Verwendungszweck>(),
        };
        if (reader.TokenType == JsonToken.String)
        {
            var stringValue = (string)reader.Value!;
            // we don't want to interfere or re-add the famous and beloved NewtonsoftVerwendungszweckStringEnumConverter
            stringValue = stringValue.Replace(
                "MEHRMINDERMBENGENABRECHNUNG",
                "MEHRMINDERMENGENABRECHNUNG"
            );
            result.Zweck.Add(
                (BO4E.ENUM.Verwendungszweck)
                    Enum.Parse(typeof(BO4E.ENUM.Verwendungszweck), stringValue)
            );
            return result;
        }

        int? stringEnumConverterIndex = null;
        foreach (var converter in serializer.Converters)
        {
            if (converter is NewtonsoftVerwendungszweckStringEnumConverter)
            {
                stringEnumConverterIndex = serializer.Converters.IndexOf(converter);
                break;
            }
        }
        int? thisConverterIndex =
            serializer.Converters.IndexOf(this) == -1 ? null : serializer.Converters.IndexOf(this);

        if (stringEnumConverterIndex == null)
        {
            serializer.Converters.Add(new NewtonsoftVerwendungszweckStringEnumConverter());
            ;
        }
        if (thisConverterIndex != null)
        {
            serializer.Converters.RemoveAt(thisConverterIndex.Value);
        }
        // Delegate to the default behavior for complex objects or other token types
        var objectResult = JToken.ReadFrom(reader).ToObject<BO4E.COM.Verwendungszweck>(serializer);
        if (thisConverterIndex != null)
        {
            serializer.Converters.Insert(thisConverterIndex.Value, this);
        }
        if (stringEnumConverterIndex == null)
        {
            serializer.Converters.RemoveAt(serializer.Converters.Count - 1);
        }

        return objectResult;
    }
}
