#nullable enable
using System;
using BO4E.ENUM;

namespace BO4E.meta.LenientConverters;

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
/// <remarks><seealso cref="SystemTextNullableGasqualitaetStringEnumConverter"/></remarks>
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
            string? enumString = reader.Value?.ToString();

            return enumString?.ToUpper() switch
            {
                "HGAS" => Gasqualitaet.H_GAS,
                "LGAS" => Gasqualitaet.L_GAS,
                _ => Enum.TryParse(enumString?.ToUpper(), out Gasqualitaet result)
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
