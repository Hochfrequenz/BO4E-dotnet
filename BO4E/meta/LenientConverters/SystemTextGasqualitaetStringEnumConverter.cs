using System;
using BO4E.ENUM;

namespace BO4E.meta.LenientConverters;

/// <summary>
/// converts 'HGAS' to Enum Member Gasqualitaet.H_GAS (and 'LGAS' to Gasqualitaet.L_GAS) for non-nullable Gasqualitaet.
/// <seealso cref="SystemTextNullableGasqualitaetStringEnumConverter"/>
/// </summary>
public class SystemTextGasqualitaetStringEnumConverter
    : System.Text.Json.Serialization.JsonConverter<Gasqualitaet>
{
    /// <inheritdoc />
    public override Gasqualitaet Read(
        ref System.Text.Json.Utf8JsonReader reader,
        Type typeToConvert,
        System.Text.Json.JsonSerializerOptions options
    )
    {
        if (reader.TokenType == System.Text.Json.JsonTokenType.Number)
        {
            var integerValue = reader.GetInt64();
            return (Gasqualitaet)Enum.ToObject(typeof(Gasqualitaet), integerValue);
        }
        string enumString = reader.GetString();

        return enumString?.ToUpper() switch
        {
            "HGAS" => Gasqualitaet.H_GAS,
            "LGAS" => Gasqualitaet.L_GAS,
            _ => Enum.TryParse(enumString?.ToUpper(), out Gasqualitaet result)
                ? result
                : throw new System.Text.Json.JsonException(
                    $"Invalid value for {typeToConvert}: {enumString}"
                ),
        };
    }

    /// <inheritdoc />
    public override void Write(
        System.Text.Json.Utf8JsonWriter writer,
        Gasqualitaet value,
        System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(value.ToString());
    }
}
