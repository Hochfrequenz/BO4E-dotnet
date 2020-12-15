using Newtonsoft.Json;

using System;
using System.Linq;

namespace BO4E.meta.LenientConverters
{
    /// <summary>
    /// The lenient StringToIntConverter allows for int or int? objects have alphabetic characters.
    /// If the string is not parsable as integer 0 is used in case of (int) and <c>null</c> in case of (int?).
    /// </summary>
    /// <example>(string)"12" will be parsed as (int)12 where an integer value is expected.</example>
    public class LenientStringToIntConverter : JsonConverter
    {
        /// <inheritdoc cref="JsonConverter.CanConvert(Type)"/>
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(int) || objectType == typeof(int?));
        }

        /// <inheritdoc cref="JsonConverter.ReadJson(JsonReader, Type, object, JsonSerializer)"/>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null)
            {
                return null;
            }
            string numeric = new String(reader.Value.ToString().Where(Char.IsDigit).ToArray());
            if (int.TryParse(numeric, out int intValue))
            {
                return intValue;
            }
            else
            {
                if (objectType == typeof(int?))
                {
                    return null;
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <inheritdoc cref="JsonConverter.CanWrite"/>
        public override bool CanWrite => false;

        /// <inheritdoc cref="JsonConverter.WriteJson(JsonWriter, object, JsonSerializer)"/>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}