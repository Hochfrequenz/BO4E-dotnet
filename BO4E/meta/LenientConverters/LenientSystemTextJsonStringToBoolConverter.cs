using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BO4E.meta.LenientConverters
{
    /// <summary>
    ///     The lenient StringToBoolConverter allows for bool or bool? objects to be serialized as strings
    /// </summary>
    public class LenientSystemTextJsonStringToBoolConverter : JsonConverter<bool>
    {
        /// <summary>
        /// </summary>
        public override bool HandleNull => true;

        /// <summary>
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="typeToConvert"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            switch (reader.TokenType)
            {
                case JsonTokenType.Null:
                    return false;
                case JsonTokenType.True:
                    return true;
                case JsonTokenType.False:
                    return false;
                case JsonTokenType.String when bool.TryParse(reader.GetString(), out var boolValue):
                    return boolValue;
                default:
                    return false;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="options"></param>
        public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value);
        }
    }
}