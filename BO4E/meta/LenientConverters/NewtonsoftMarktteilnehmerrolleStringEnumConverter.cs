using System;
using BO4E.ENUM;

namespace BO4E.meta.LenientConverters;

/// <summary>
/// Converts legacy value 'anderepartei' to Enum Member Marktteilnehmerrolle.ANDERE_PARTEI
/// </summary>
/// <remarks>
/// It is intended, that you use this converter TOGETHER with the <see cref="Newtonsoft.Json.Converters.StringEnumConverter"/>.
/// In this case you need to add this converter BEFORE the <see cref="Newtonsoft.Json.Converters.StringEnumConverter"/> in the list of converters.
/// <code>
/// var settings = new Newtonsoft.Json.JsonSerializerSettings()
/// {
///     Converters = { new NewtonsoftMarktteilnehmerrolleStringEnumConverter(), new StringEnumConverter() }
/// };
/// </code>
/// </remarks>
public class NewtonsoftMarktteilnehmerrolleStringEnumConverter
    : Newtonsoft.Json.JsonConverter<Marktteilnehmerrolle?>
{
    /// <inheritdoc />
    public override Marktteilnehmerrolle? ReadJson(
        Newtonsoft.Json.JsonReader reader,
        Type objectType,
        Marktteilnehmerrolle? existingValue,
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
            return (Marktteilnehmerrolle)Enum.ToObject(typeof(Marktteilnehmerrolle), integerValue);
        }
        if (reader.TokenType == Newtonsoft.Json.JsonToken.String)
        {
            string? enumString = reader.Value?.ToString();

            return enumString?.ToUpper() switch
            {
                "ANDEREPARTEI" => Marktteilnehmerrolle.ANDERE_PARTEI,
                _ => Enum.TryParse(enumString?.ToUpper(), out Marktteilnehmerrolle result)
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
        Marktteilnehmerrolle? value,
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
