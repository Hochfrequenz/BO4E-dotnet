using System;
using Newtonsoft.Json;

namespace BO4E.meta.LenientConverters
{
    /// <summary>
    ///     allows deserializing <see cref="Bo4eUri" />s
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public class LenientBo4eUriConverter : JsonConverter
    {
        /// <inheritdoc cref="JsonConverter.CanConvert(Type)" />
        public override bool CanWrite => false;

        /// <inheritdoc cref="JsonConverter.CanConvert(Type)" />
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Bo4eUri);
        }

        /// <inheritdoc cref="JsonConverter.ReadJson(JsonReader, Type, object, JsonSerializer)" />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            if (reader.Value == null) return null;
            var rawString = (string) reader.Value;
            if (rawString.Trim() == string.Empty) return null;
            return new Bo4eUri(rawString);
        }

        /// <inheritdoc cref="JsonConverter.WriteJson(JsonWriter, object, JsonSerializer)" />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}