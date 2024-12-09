using System;
using System.Text.Json;
using System.Text.RegularExpressions;
using BO4E.ENUM;
using EnumsNET;

namespace BO4E.meta.LenientConverters;

/// <summary>
/// The lenient ZaehlergroesseGasConverter allows for transforming strings that do not contain the prefix "GAS_" into valid <see cref="BO4E.ENUM.Geraetemerkmal"/>
/// </summary>
/// <remarks>The main symptom for its usage is "Error converting value "G4" to type Geraetemerkmal"</remarks>
public class LenientSystemTextGeraetemerkmalGasConverter
    : System.Text.Json.Serialization.JsonConverter<Geraetemerkmal>
{
    /// <summary>
    /// <inheritdoc cref="System.Text.Json.Serialization.JsonConverter{T}.Read"/>
    /// </summary>
    public override Geraetemerkmal Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        if (reader.TokenType == JsonTokenType.Number)
        {
            return Geraetemerkmal.EINTARIF;
        }
        var rawString = reader.GetString();
        try
        {
            return Enums.Parse<Geraetemerkmal>(rawString);
        }
        catch (ArgumentException) when (rawString.StartsWith("G"))
        {
            switch (rawString)
            {
                case "G2Period5":
                case "G2.5":
                    return Geraetemerkmal.GAS_G2P5;
                default:
                    return Enums.Parse<Geraetemerkmal>("GAS_" + rawString);
            }
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
        Geraetemerkmal value,
        JsonSerializerOptions options
    )
    {
        var stringValue = value.ToString();
        writer.WriteStringValue(stringValue);
    }
}
