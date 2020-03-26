using System;

using Newtonsoft.Json;

namespace BO4E.meta.LenientParsing
{
    public class LenientBo4eUriConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Bo4eUri));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null)
            {
                return null;
            }
            string rawString = (string)reader.Value;
            if (rawString.Trim() == String.Empty)
            {
                return null;
            }
            return new Bo4eUri(rawString);
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
