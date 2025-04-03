using System;
using BO4E.ENUM;

namespace BO4E.meta.LenientConverters;

/// <summary>
/// Converts 'MEHRMINDERMBENGENABRECHNUNG' (with typo!) to Enum Member <see cref="Verwendungszweck.MEHRMINDERMENGENABRECHNUNG"/> for nullable Verwendungszweck.
/// <seealso cref="SystemTextVerwendungszweckStringEnumConverter"/> for non-nullable Verwendungszweck.
/// </summary>
public class SystemTextNullableVerwendungszweckStringEnumConverter
    : System.Text.Json.Serialization.JsonConverter<Verwendungszweck?>
{
    /// <inheritdoc />
    public override Verwendungszweck? Read(
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
                    : throw new System.Text.Json.JsonException(
                        $"Invalid value for {typeToConvert.Name}: {enumString}"
                    ),
            };
        }

        throw new System.Text.Json.JsonException(
            $"Unexpected token parsing {typeToConvert.Name}. Expected String or Number, got {reader.TokenType}."
        );
    }

    /// <inheritdoc />
    public override void Write(
        System.Text.Json.Utf8JsonWriter writer,
        Verwendungszweck? value,
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
