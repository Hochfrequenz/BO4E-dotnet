using BO4E.ENUM;

using System;
using System.Text.Json;

namespace BO4E.meta.LenientConverters
{
    /// <summary>
    /// The lenient ZaehlergroesseGasConverter allows for transforming strings that do not contain the prefix "GAS_" into valid <see cref="BO4E.ENUM.Geraetemerkmal"/>
    /// </summary>
    /// <remarks>The main symptom for its usage is "Error converting value "G4" to type Geraetemerkmal"</remarks>
    public class LenientSystemTextGeraetemerkmalGasConverter : System.Text.Json.Serialization.JsonConverter<Geraetemerkmal>
    {
        /// <summary>
        /// <inheritdoc cref="System.Text.Json.Serialization.JsonConverter{T}.Read"/>
        /// </summary>
        public override Geraetemerkmal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var rawString = reader.GetString();
            try
            {
                return Enum.Parse<Geraetemerkmal>(rawString);
            }
            catch (ArgumentException) when (rawString.StartsWith("G"))
            {
                if (rawString == "G2Period5")
                {
                    return Geraetemerkmal.GAS_G2P5;
                }
                return Enum.Parse<Geraetemerkmal>("GAS_" + rawString);
            }
        }

        /// <summary>
        /// <inheritdoc cref="System.Text.Json.Serialization.JsonConverter{T}.Write"/>
        /// </summary>
        public override void Write(Utf8JsonWriter writer, Geraetemerkmal value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// The lenient ZaehlergroesseGasConverter allows for transforming strings that do not contain the prefix "GAS_" into valid nullable <see cref="BO4E.ENUM.Geraetemerkmal"/>
    /// </summary>
    /// <remarks>The main symptom for its usage is "Error converting value "G4" to type Geraetemerkmal"</remarks>
    public class LenientSystemTextNullableGeraetemerkmalGasConverter : System.Text.Json.Serialization.JsonConverter<Geraetemerkmal?>
    {
        /// <summary>
        /// <inheritdoc cref="System.Text.Json.Serialization.JsonConverter{T}.Read"/>
        /// </summary>
        public override Geraetemerkmal? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var rawString = reader.GetString();
            if (rawString is null)
            {
                return null;
            }
            try
            {
                return Enum.Parse<Geraetemerkmal>(rawString);
            }
            catch (ArgumentException) when (rawString.StartsWith("G"))
            {
                if (rawString == "G2Period5")
                {
                    return Geraetemerkmal.GAS_G2P5;
                }
                return Enum.Parse<Geraetemerkmal>("GAS_" + rawString);
            }
        }

        /// <summary>
        /// <inheritdoc cref="System.Text.Json.Serialization.JsonConverter{T}.Write"/>
        /// </summary>
        public override void Write(Utf8JsonWriter writer, Geraetemerkmal? value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
