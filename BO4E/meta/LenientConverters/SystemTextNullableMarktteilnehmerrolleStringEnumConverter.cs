using System;
using BO4E.ENUM;

namespace BO4E.meta.LenientConverters;

/// <summary>
/// Converts legacy value 'anderepartei' to Enum Member Marktteilnehmerrolle.ANDERE_PARTEI.
/// For non-nullable see <seealso cref="SystemTextMarktteilnehmerrolleStringEnumConverter"/>.
/// </summary>
/// <remarks>
/// Note: <see cref="Write"/> uses <c>value.ToString()</c> which returns the C# member name (e.g. "ANDERE_PARTEI").
/// This only produces correct output because the member name matches the <c>[EnumMember]</c> value.
/// </remarks>
public class SystemTextNullableMarktteilnehmerrolleStringEnumConverter
    : System.Text.Json.Serialization.JsonConverter<Marktteilnehmerrolle?>
{
    /// <inheritdoc />
    public override Marktteilnehmerrolle? Read(
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
        Marktteilnehmerrolle? value,
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
