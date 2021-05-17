using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BO4E.meta.LenientConverters
{
    /// <summary>
    ///     A custom enum converter that uses an array for containing bit flags.
    /// </summary>
    public class LenientSystemTextJsonEnumListConverter : JsonConverterFactory
    {
        /// <summary>
        /// </summary>
        /// <param name="typeToConvert"></param>
        /// <returns></returns>
        public override bool CanConvert(Type typeToConvert)
        {
            if (!typeToConvert.IsGenericType) return false;

            if (typeToConvert.GetGenericTypeDefinition() != typeof(List<>)) return false;

            var expectedListElementType = typeToConvert.GetGenericArguments()[0];
            return expectedListElementType.ToString().StartsWith("BO4E.ENUM");
        }

        /// <summary>
        /// </summary>
        /// <param name="typeToConvert"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            var converter = (JsonConverter)Activator.CreateInstance(
                typeof(LenientSystemTextJsonEnumListConverter<,>).MakeGenericType(typeToConvert,
                    typeToConvert.GetGenericArguments().First()),
                BindingFlags.Instance | BindingFlags.Public,
                null,
                null,
                null);

            return converter;
        }
    }

    /// <summary>
    ///     allows to deserialize a list of enums (see tests)
    /// </summary>
    public class LenientSystemTextJsonEnumListConverter<T, TE> : JsonConverter<T>
        where T : List<TE> where TE : struct, Enum
    {
        /// <inheritdoc cref=" JsonConverter.CanConvert(Type)" />
        public override bool CanConvert(Type objectType)
        {
            if (!objectType.IsGenericType) return false;

            if (objectType.GetGenericTypeDefinition() != typeof(List<>)) return false;

            var expectedListElementType = objectType.GetGenericArguments()[0];
            return expectedListElementType.ToString().StartsWith("BO4E.ENUM");
        }

        /// <summary>
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="typeToConvert"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var rawList = JsonSerializer.Deserialize<List<object>>(ref reader);
            var expectedListElementType = typeToConvert.GetGenericArguments()[0];
            var expectedListType = typeof(List<>).MakeGenericType(expectedListElementType);
            var result = Activator.CreateInstance(expectedListType);
            if (rawList == null || rawList.Count == 0) return result as T;

            // First try to parse the List normally, in case it's formatted as expected
            foreach (var rawItem in rawList)
                switch (rawItem)
                {
                    case object _ when Enum.TryParse(rawItem.ToString(), true, out TE enumResult):
                        {
                            // default. everything is as it should be :-)

                            ((IList)result).Add(enumResult);
                            break;
                        }
                    case JsonElement element:
                        try
                        {
                            var rawDict = JsonSerializer.Deserialize<Dictionary<string, object>>(element.GetRawText());
                            var rawObject = rawDict.Values.FirstOrDefault();
                            var enumValue = Enum.Parse(expectedListElementType, rawObject.ToString(), true);
                            ((IList)result).Add(enumValue);
                        }
                        catch (Exception)
                        {
                            var enumValue = Enum.Parse(expectedListElementType, element.GetString(), true);
                            ((IList)result).Add(enumValue);
                        }

                        break;
                    default:
                        ((IList)result).Add(rawItem);
                        break;
                }

            return result as T;
        }

        /// <summary>
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="options"></param>
        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            if (value.Any())
            {
                writer.WriteStartArray();
                foreach (var val in value) JsonSerializer.Serialize(writer, val, typeof(TE), options);

                writer.WriteEndArray();
            }
            else
            {
                writer.WriteNullValue();
            }
        }
    }
}