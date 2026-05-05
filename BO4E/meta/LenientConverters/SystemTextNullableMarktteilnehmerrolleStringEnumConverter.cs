using System;
using System.Text.Json;
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
    private static readonly string[] LegacyObjectPropertyNames = ["code", "name", "value", "wert"];

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
        if (reader.TokenType == System.Text.Json.JsonTokenType.StartObject)
        {
            using var document = JsonDocument.ParseValue(ref reader);
            return ParseLegacyObject(document.RootElement);
        }
        string? enumString = reader.GetString();

        return ParseString(enumString, typeToConvert);
    }

    private static Marktteilnehmerrolle? ParseLegacyObject(JsonElement rolleObject)
    {
        foreach (var propertyName in LegacyObjectPropertyNames)
        {
            if (
                rolleObject.TryGetProperty(propertyName, out var property)
                && TryParseProperty(property, out var parsed)
            )
            {
                return parsed;
            }
        }

        return null;
    }

    private static bool TryParseProperty(JsonElement property, out Marktteilnehmerrolle? parsed)
    {
        parsed = property.ValueKind switch
        {
            JsonValueKind.String => TryParseString(property.GetString(), out var result)
                ? result
                : null,
            JsonValueKind.Number when property.TryGetInt32(out var integerValue) => Enum.IsDefined(
                typeof(Marktteilnehmerrolle),
                integerValue
            )
                ? (Marktteilnehmerrolle)Enum.ToObject(typeof(Marktteilnehmerrolle), integerValue)
                : null,
            JsonValueKind.Null => null,
            _ => null,
        };

        return parsed is not null;
    }

    private static Marktteilnehmerrolle ParseString(string? enumString, Type typeToConvert)
    {
        return TryParseString(enumString, out var result)
            ? result
            : throw new System.Text.Json.JsonException(
                $"Invalid value for {typeToConvert}: {enumString}"
            );
    }

    private static bool TryParseString(string? enumString, out Marktteilnehmerrolle result)
    {
        var normalized = enumString?.ToUpper();
        if (normalized == "ANDEREPARTEI")
        {
            result = Marktteilnehmerrolle.ANDERE_PARTEI;
            return true;
        }

        if (
            Enum.TryParse(normalized, out result)
            && Enum.IsDefined(typeof(Marktteilnehmerrolle), result)
        )
        {
            return true;
        }

        result = default;
        return false;
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
