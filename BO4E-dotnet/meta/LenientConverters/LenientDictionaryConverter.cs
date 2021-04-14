using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BO4E.meta.LenientConverters
{
    /// <summary>
    /// A custom converter following the code on joseftw/JOS.SystemTextJsonDictionaryStringObjectJsonConverter
    /// </summary>
    public class LenientDictionaryConverter : JsonConverter<Dictionary<string, object>>
    {
        /// <summary>
        /// Can only convert dictionaries
        /// </summary>
        /// <param name="typeToConvert"></param>
        /// <returns></returns>
        public override bool CanConvert(Type typeToConvert)
        {
            bool willConvert = typeToConvert == typeof(Dictionary<string, object>);
            return willConvert;
        }
        /// <summary>
        /// Read the Dicitionary from a JSON reader
        /// </summary>
        /// <param name="reader">the json reader passed by the converter</param>
        /// <param name="typeToConvert">The type we want to construct</param>
        /// <param name="options">any json serializer options</param>
        /// <returns></returns>
        public override Dictionary<string, object> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException($"JsonTokenType was of type {reader.TokenType}, only objects are supported");
            }

            var dictionary = new Dictionary<string, object>();
            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                {
                    return dictionary;
                }

                if (reader.TokenType != JsonTokenType.PropertyName)
                {
                    throw new JsonException("JsonTokenType was not PropertyName");
                }

                var propertyName = reader.GetString();

                if (string.IsNullOrWhiteSpace(propertyName))
                {
                    throw new JsonException("Failed to get property name");
                }

                reader.Read();

                dictionary.Add(propertyName, ExtractValue(ref reader, options));
            }

            return dictionary;
        }
        /// <summary>
        /// Write the dictionary to json
        /// </summary>
        /// <param name="writer">a json writer to write to</param>
        /// <param name="value">the value of the dictionary we want to write to</param>
        /// <param name="options">a jsonserializeroptions object to give custom options</param>
        public override void Write(Utf8JsonWriter writer, Dictionary<string, object> value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            foreach (var key in value.Keys)
            {
                HandleValue(writer, key, value[key]);
            }

            writer.WriteEndObject();
        }

        private static void HandleValue(Utf8JsonWriter writer, string key, object objectValue)
        {
            if (key != null)
            {
                writer.WritePropertyName(key);
            }

            switch (objectValue)
            {
                case string stringValue:
                    writer.WriteStringValue(stringValue);
                    break;
                case DateTime dateTime:
                    writer.WriteStringValue(dateTime);
                    break;
                case long longValue:
                    writer.WriteNumberValue(longValue);
                    break;
                case int intValue:
                    writer.WriteNumberValue(intValue);
                    break;
                case float floatValue:
                    writer.WriteNumberValue(floatValue);
                    break;
                case double doubleValue:
                    writer.WriteNumberValue(doubleValue);
                    break;
                case decimal decimalValue:
                    writer.WriteNumberValue(decimalValue);
                    break;
                case bool boolValue:
                    writer.WriteBooleanValue(boolValue);
                    break;
                case Dictionary<string, object> dict:
                    writer.WriteStartObject();
                    foreach (var item in dict)
                    {
                        HandleValue(writer, item.Key, item.Value);
                    }
                    writer.WriteEndObject();
                    break;
                case object[] array:
                    writer.WriteStartArray();
                    foreach (var item in array)
                    {
                        HandleValue(writer, item);
                    }
                    writer.WriteEndArray();
                    break;
                default:
                    writer.WriteNullValue();
                    break;
            }
        }

        private static void HandleValue(Utf8JsonWriter writer, object value)
        {
            HandleValue(writer, null, value);
        }

        private object ExtractValue(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            switch (reader.TokenType)
            {
                case JsonTokenType.String:
                    if (reader.TryGetDateTime(out var date))
                    {
                        return date;
                    }
                    return reader.GetString();
                case JsonTokenType.False:
                    return false;
                case JsonTokenType.True:
                    return true;
                case JsonTokenType.Null:
                    return null;
                case JsonTokenType.Number:
                    if (reader.TryGetInt64(out var result))
                    {
                        return result;
                    }
                    return reader.GetDecimal();
                case JsonTokenType.StartObject:
                    return Read(ref reader, null, options);
                case JsonTokenType.StartArray:
                    var list = new List<object>();
                    while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
                    {
                        list.Add(ExtractValue(ref reader, options));
                    }

                    return list;
                default:
                    throw new JsonException($"'{reader.TokenType}' is not supported");
            }
        }
    }
}
