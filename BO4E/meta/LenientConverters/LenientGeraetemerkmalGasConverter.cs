using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using BO4E.ENUM;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BO4E.meta.LenientConverters
{
    /// <summary>
    /// The lenient ZaehlergroesseGasConverter allows for transforming strings that do not contain the prefix "GAS_" into valid <see cref="BO4E.ENUM.Geraetemerkmal"/>
    /// </summary>
    /// <remarks>The main symptom for its usage is "Error converting value "G4" to type Geraetemerkmal"</remarks>
    public class LenientGeraetemerkmalGasConverter : JsonConverter
    {
        /// <inheritdoc cref="JsonConverter.CanWrite" />
        public override bool CanWrite => false;

        /// <inheritdoc cref="JsonConverter.CanConvert(Type)" />
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(BO4E.ENUM.Geraetemerkmal) || objectType == typeof(BO4E.ENUM.Geraetemerkmal?);
        }

        /// <inheritdoc cref="JsonConverter.ReadJson(JsonReader, Type, object, JsonSerializer)" />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            string rawValue;
            switch (reader.Value)
            {
                case string value:
                    rawValue = value;
                    break;
                case null:
                    return null; // this should cover the case of a null value for nullable enum
                default:
                    rawValue = reader.Value?.ToString();
                    break;
            }

            try
            {
                return Enum.Parse<Geraetemerkmal>(rawValue);
            }
            catch (ArgumentException) when (rawValue.StartsWith("G"))
            {
                return Enum.Parse<Geraetemerkmal>("GAS_" + rawValue);
            }
        }

        /// <inheritdoc cref="JsonConverter.WriteJson(JsonWriter, object, JsonSerializer)" />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
