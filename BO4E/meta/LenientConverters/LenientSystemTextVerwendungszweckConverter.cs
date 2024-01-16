using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using BO4E.ENUM;
using Verwendungszweck = BO4E.COM.Verwendungszweck; // not the enum!!


namespace BO4E.meta.LenientConverters
{
    /// <summary>
    /// A converter for Verwendungszweck (COM)
    /// </summary>
    public class VerwendungszweckJsonConverter : JsonConverter<Verwendungszweck>
    {
        private JsonSerializerOptions defaultOptions = LenientParsing.MOST_LENIENT.GetJsonSerializerOptions();

        /// <inheritdoc />
        public VerwendungszweckJsonConverter()
        {
            defaultOptions.Converters.Remove(defaultOptions.Converters.First(c => c.GetType() == typeof(JsonStringEnumConverter)));
            defaultOptions.Converters.Add(new JsonStringEnumConverter());
        }

        /// <inheritdoc />
        public override Verwendungszweck? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.StartArray)
            {
                var retList = new List<BO4E.ENUM.Verwendungszweck>();
                reader.Read();
                while (reader.TokenType != JsonTokenType.EndArray)
                {
                    retList.Add(System.Text.Json.JsonSerializer.Deserialize<BO4E.ENUM.Verwendungszweck>(ref reader, defaultOptions));
                    //read end object
                    reader.Read();
                }

                return new BO4E.COM.Verwendungszweck { Marktrolle = Marktrolle.LF, Zweck = retList };
            }

            if (reader.TokenType == JsonTokenType.String)
            {
                var retList = new List<BO4E.ENUM.Verwendungszweck>
                {
                    Enum.Parse<BO4E.ENUM.Verwendungszweck>(reader.GetString().ToUpper())
                };
                return new BO4E.COM.Verwendungszweck { Marktrolle = Marktrolle.LF, Zweck = retList };
            }

            return reader.TokenType switch
            {
                JsonTokenType.Null => null,
                JsonTokenType.StartObject => System.Text.Json.JsonSerializer.Deserialize<BO4E.COM.Verwendungszweck>(ref reader, defaultOptions),
                _ => null
            };
        }

        /// <inheritdoc />
        public override void Write(Utf8JsonWriter writer, BO4E.COM.Verwendungszweck value, JsonSerializerOptions options)
        {
            System.Text.Json.JsonSerializer.Serialize(writer, value, defaultOptions);
        }
    }
}
