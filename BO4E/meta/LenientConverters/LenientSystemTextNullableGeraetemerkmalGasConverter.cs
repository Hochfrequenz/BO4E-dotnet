#nullable enable
using System;
using System.Text.Json;
using System.Text.RegularExpressions;
using BO4E.ENUM;

namespace BO4E.meta.LenientConverters;

/// <summary>
/// The lenient ZaehlergroesseGasConverter allows for transforming strings that do not contain the prefix "GAS_" into valid nullable <see cref="BO4E.ENUM.Geraetemerkmal"/>
/// </summary>
/// <remarks>The main symptom for its usage is "Error converting value "G4" to type Geraetemerkmal"</remarks>
public class LenientSystemTextNullableGeraetemerkmalGasConverter
    : System.Text.Json.Serialization.JsonConverter<Geraetemerkmal?>
{
    /// <summary>
    /// <inheritdoc cref="System.Text.Json.Serialization.JsonConverter{T}.Read"/>
    /// </summary>
    public override Geraetemerkmal? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        if (reader.TokenType == JsonTokenType.Number)
        {
            return null;
        }
        var rawString = reader.GetString();
        if (rawString is null)
        {
            return null;
        }
        try
        {
            return (BO4E.ENUM.Geraetemerkmal)
                Enum.Parse(typeof(BO4E.ENUM.Geraetemerkmal), rawString, ignoreCase: true);
        }
        catch (ArgumentException) when (rawString.StartsWith("G"))
        {
            if (rawString == "G2Period5")
            {
                return Geraetemerkmal.GAS_G2P5;
            }
            return (BO4E.ENUM.Geraetemerkmal)
                Enum.Parse(typeof(BO4E.ENUM.Geraetemerkmal), "GAS_" + rawString, ignoreCase: true);
        }
    }

    /// <summary>
    /// https://regex101.com/r/dAUAHL/1
    /// </summary>
    private static readonly Regex GasPrefixRegex = new(
        @"^(?<praefix>(?:GAS_)?)(?<rest>.+)$",
        RegexOptions.Compiled
    );

    /// <summary>
    /// <inheritdoc cref="System.Text.Json.Serialization.JsonConverter{T}.Write"/>
    /// </summary>
    public override void Write(
        Utf8JsonWriter writer,
        Geraetemerkmal? value,
        JsonSerializerOptions options
    )
    {
        if (value.HasValue)
        {
            var stringValue = value.ToString();
            writer.WriteStringValue(stringValue);
        }
        else
        {
            writer.WriteNullValue();
        }
    }
}
