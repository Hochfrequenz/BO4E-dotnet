using System;
using BO4E.ENUM;

namespace BO4E.meta.LenientConverters;

/// <summary>
/// Converts 'MEHRMINDERMBENGENABRECHNUNG' (with typo!) to Enum Member <see cref="Verwendungszweck.MEHRMINDERMENGENABRECHNUNG"/>.
/// </summary>
public class SystemTextVerwendungszweckStringEnumConverter : System.Text.Json.Serialization.JsonConverter<Verwendungszweck?>
{
    /// <inheritdoc />
    public override Verwendungszweck? Read(ref System.Text.Json.Utf8JsonReader reader, Type typeToConvert,
        System.Text.Json.JsonSerializerOptions options)
    {
        if (reader.TokenType == System.Text.Json.JsonTokenType.Null)
        {
            return null;
        }

        if (reader.TokenType == System.Text.Json.JsonTokenType.Number)
        {
            var integerValue = reader.GetInt64();
            return (Verwendungszweck)Enum.ToObject(typeof(Verwendungszweck), integerValue);
        }

        if (reader.TokenType == System.Text.Json.JsonTokenType.String)
        {
            string enumString = reader.GetString();

            return enumString switch
            {
                "MEHRMINDERMBENGENABRECHNUNG" => Verwendungszweck.MEHRMINDERMENGENABRECHNUNG,
                _ => Enum.TryParse<Verwendungszweck>(enumString, true, out var result)
                    ? result
                    : throw new System.Text.Json.JsonException($"Invalid value for {typeToConvert.Name}: {enumString}")
            };
        }

        throw new System.Text.Json.JsonException($"Unexpected token parsing {typeToConvert.Name}. Expected String or Number, got {reader.TokenType}.");
    }

    /// <inheritdoc />
    public override void Write(System.Text.Json.Utf8JsonWriter writer, Verwendungszweck? value,
        System.Text.Json.JsonSerializerOptions options)
    {
        if (value is null)
        {
            writer.WriteNullValue();
        }
        else
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}

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
/// <remarks><seealso cref="SystemTextVerwendungszweckStringEnumConverter"/></remarks>
public class NewtonsoftVerwendungszweckStringEnumConverter : Newtonsoft.Json.JsonConverter<Verwendungszweck?>
{
    /// <inheritdoc />>
    public override Verwendungszweck? ReadJson(Newtonsoft.Json.JsonReader reader, Type objectType,
        Verwendungszweck? existingValue, bool hasExistingValue, Newtonsoft.Json.JsonSerializer serializer)
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
            string enumString = reader.Value.ToString();

            return enumString switch
            {
                "MEHRMINDERMBENGENABRECHNUNG" => Verwendungszweck.MEHRMINDERMENGENABRECHNUNG,
                _ => Enum.TryParse(enumString, out Verwendungszweck result)
                    ? result
                    : throw new Newtonsoft.Json.JsonSerializationException(
                        $"Invalid value for {objectType}: {enumString}")
            };
        }

        throw new Newtonsoft.Json.JsonSerializationException("Expected string value.");
    }

    /// <inheritdoc />
    public override void WriteJson(Newtonsoft.Json.JsonWriter writer, Verwendungszweck? value,
        Newtonsoft.Json.JsonSerializer serializer)
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