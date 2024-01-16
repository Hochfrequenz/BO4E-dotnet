using System;
using System.Collections.Generic;
using BO4E.COM;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Marktrolle = BO4E.ENUM.Marktrolle;

namespace BO4E.meta.LenientConverters
{
    /// <summary>
    /// A converter for Verwendungszweck (ENUM)
    /// </summary>
    public class VerwendungszweckJsonNetConverter : JsonConverter
    {
        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Verwendungszweck);
        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            if (reader.TokenType == JsonToken.Integer)
            {
                var retList = new List<ENUM.Verwendungszweck>
                {
                    Enum.Parse<ENUM.Verwendungszweck>(Enum.GetName(typeof(ENUM.Verwendungszweck), reader.Value))
                };
                return new Verwendungszweck { Marktrolle = Marktrolle.LF, Zweck = retList };
            }

            if (reader.TokenType == JsonToken.String)
            {
                var retList = new List<ENUM.Verwendungszweck>
                {
                    Enum.Parse<ENUM.Verwendungszweck>((string)reader.Value)
                };
                return new Verwendungszweck { Marktrolle = Marktrolle.LF, Zweck = retList };
            }

            return JToken.ReadFrom(reader).ToObject<Verwendungszweck>();
        }

        /// <inheritdoc />
        public override bool CanWrite => true;

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(value);
        }
    }
}
