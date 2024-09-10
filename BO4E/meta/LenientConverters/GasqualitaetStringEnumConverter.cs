using System;
using BO4E.ENUM;

namespace BO4E.meta.LenientConverters;

/// <summary>
/// converts 'HGAS' to Enum Member Gasqualitaet.H_GAS (and 'LGAS' to Gasqualitaet.L_GAS)
/// </summary>
public class SystemTextGasqualitaetStringEnumConverter
    : System.Text.Json.Serialization.JsonConverter<Gasqualitaet?>
{
    /// <inheritdoc />
    public override Gasqualitaet? Read(
        ref System.Text.Json.Utf8JsonReader reader,
        Type typeToConvert,
        System.Text.Json.JsonSerializerOptions options
    )
    {
        if (reader.TokenType == System.Text.Json.JsonTokenType.Null)
        {
            return null;
        }
        if (reader.TokenType == System.Text.Json.JsonTokenType.Number)
        {
            var integerValue = reader.GetInt64();
            return (Gasqualitaet)Enum.ToObject(typeof(Gasqualitaet), integerValue);
        }
        string enumString = reader.GetString();

        return enumString switch
        {
            "HGAS" => Gasqualitaet.H_GAS,
            "LGAS" => Gasqualitaet.L_GAS,
            _ => Enum.TryParse(enumString, out Gasqualitaet result)
                ? result
                : throw new System.Text.Json.JsonException(
                    $"Invalid value for {typeToConvert}: {enumString}"
                ),
        };
    }

    /// <inheritdoc />
    public override void Write(
        System.Text.Json.Utf8JsonWriter writer,
        Gasqualitaet? value,
        System.Text.Json.JsonSerializerOptions options
    )
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
/// Converts 'HGAS' to Enum Member Gasqualitaet.H_GAS (and 'LGAS' to Gasqualitaet.L_GAS)
/// </summary>
/// <remarks>
/// It is intended, that you use this converter TOGETHER with the <see cref="Newtonsoft.Json.Converters.StringEnumConverter"/>.
/// In this case you need to add this converter BEFORE the <see cref="Newtonsoft.Json.Converters.StringEnumConverter"/> in the list of converters.
/// <code>
/// var settings = new Newtonsoft.Json.JsonSerializerSettings()
/// {
///     Converters = { new NewtonsoftGasqualitaetStringEnumConverter(), new StringEnumConverter() }
/// };
/// </code>
/// </remarks>
/// <remarks><seealso cref="SystemTextGasqualitaetStringEnumConverter"/></remarks>
public class NewtonsoftGasqualitaetStringEnumConverter
    : Newtonsoft.Json.JsonConverter<Gasqualitaet?>
{
    /// <inheritdoc />>
    public override Gasqualitaet? ReadJson(
        Newtonsoft.Json.JsonReader reader,
        Type objectType,
        Gasqualitaet? existingValue,
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
            return (Gasqualitaet)Enum.ToObject(typeof(Gasqualitaet), integerValue);
        }
        if (reader.TokenType == Newtonsoft.Json.JsonToken.String)
        {
            string enumString = reader.Value.ToString();

            return enumString switch
            {
                "HGAS" => Gasqualitaet.H_GAS,
                "LGAS" => Gasqualitaet.L_GAS,
                _ => Enum.TryParse(enumString, out Gasqualitaet result)
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
        Gasqualitaet? value,
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
