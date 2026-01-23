#nullable enable
using System;
using BO4E.ENUM;

namespace BO4E.meta.LenientConverters;

/// <summary>
/// converts 'MEHRMINDERMBENGENABRECHNUNG' (with typo!) to Enum Member <see cref="Verwendungszweck.MEHRMINDERMENGENABRECHNUNG"/>
/// </summary>
/// <remarks>
/// It is intended, that you use this converter TOGETHER with the <see cref="Newtonsoft.Json.Converters.StringEnumConverter"/>.
/// In this case you need to add this converter BEFORE the <see cref="Newtonsoft.Json.Converters.StringEnumConverter"/> in the list of converters.
/// <code>
/// var settings = new Newtonsoft.Json.JsonSerializerSettings()
/// {
///     Converters = { new NewtonsoftVerwendungszweckStringEnumConverter(), new StringEnumConverter() }
/// };
/// </code>
/// </remarks>
/// <remarks><seealso cref="SystemTextNullableVerwendungszweckStringEnumConverter"/></remarks>
public class NewtonsoftVerwendungszweckStringEnumConverter
    : Newtonsoft.Json.JsonConverter<Verwendungszweck?>
{
    /// <inheritdoc />>
    public override Verwendungszweck? ReadJson(
        Newtonsoft.Json.JsonReader reader,
        Type objectType,
        Verwendungszweck? existingValue,
        bool hasExistingValue,
        Newtonsoft.Json.JsonSerializer serializer
    )
    {
        if (reader.TokenType == Newtonsoft.Json.JsonToken.Null)
        {
            return null;
        }

        if (reader.TokenType == Newtonsoft.Json.JsonToken.Integer)
        {
            var integerValue = Convert.ToInt64(reader.Value);
            return (Verwendungszweck)Enum.ToObject(typeof(Verwendungszweck), integerValue);
        }

        if (reader.TokenType == Newtonsoft.Json.JsonToken.String)
        {
            string? enumString = reader.Value?.ToString();

            return enumString switch
            {
                "MEHRMINDERMBENGENABRECHNUNG" => Verwendungszweck.MEHRMINDERMENGENABRECHNUNG,
                _ => Enum.TryParse(enumString, out Verwendungszweck result)
                    ? result
                    : throw new Newtonsoft.Json.JsonSerializationException(
                        $"Invalid value for {objectType}: {enumString}"
                    ),
            };
        }

        throw new Newtonsoft.Json.JsonSerializationException("Expected string value.");
    }

    /// <inheritdoc />
    public override void WriteJson(
        Newtonsoft.Json.JsonWriter writer,
        Verwendungszweck? value,
        Newtonsoft.Json.JsonSerializer serializer
    )
    {
        if (value is null)
        {
            writer.WriteNull();
        }
        else
        {
            writer.WriteValue(value.ToString());
        }
    }

    /// <inheritdoc />
    public override bool CanWrite => true;
}
