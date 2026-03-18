using System;
using BO4E.ENUM;

namespace BO4E.meta.LenientConverters;

/// <summary>
/// Converts legacy value 'anderepartei' to Enum Member Marktteilnehmerrolle.ANDERE_PARTEI for non-nullable Marktteilnehmerrolle.
/// <seealso cref="SystemTextNullableMarktteilnehmerrolleStringEnumConverter"/>
/// </summary>
public class SystemTextMarktteilnehmerrolleStringEnumConverter
    : System.Text.Json.Serialization.JsonConverter<Marktteilnehmerrolle>
{
    /// <inheritdoc />
    public override Marktteilnehmerrolle Read(
        ref System.Text.Json.Utf8JsonReader reader,
        Type typeToConvert,
        System.Text.Json.JsonSerializerOptions options
    )
    {
        if (reader.TokenType == System.Text.Json.JsonTokenType.Number)
        {
            var integerValue = reader.GetInt64();
            return (Marktteilnehmerrolle)Enum.ToObject(typeof(Marktteilnehmerrolle), integerValue);
        }
        string? enumString = reader.GetString();

        return enumString?.ToUpper() switch
        {
            "ANDEREPARTEI" => Marktteilnehmerrolle.ANDERE_PARTEI,
            _ => Enum.TryParse(enumString?.ToUpper(), out Marktteilnehmerrolle result)
                ? result
                : throw new System.Text.Json.JsonException(
                    $"Invalid value for {typeToConvert}: {enumString}"
                ),
        };
    }

    /// <inheritdoc />
    public override void Write(
        System.Text.Json.Utf8JsonWriter writer,
        Marktteilnehmerrolle value,
        System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(value.ToString());
    }
}
