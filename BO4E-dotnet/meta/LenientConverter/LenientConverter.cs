using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace BO4E.meta.LenientConverter
{
    public class LenientConverter
    {

        public class LenientEnumListConverter : JsonConverter
        {

            public override bool CanConvert(Type objectType)
            {
                if (!objectType.IsGenericType)
                {
                    return false;
                }
                if (objectType.GetGenericTypeDefinition() != typeof(List<>))
                {
                    return false;
                }
                Type expectedListElementType = objectType.GetGenericArguments()[0];
                return expectedListElementType.ToString().StartsWith("BO4E.ENUM");
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                JToken token = JToken.Load(reader); // https://stackoverflow.com/a/47864946/10009545
                List<object> rawList = token.ToObject<List<object>>();
                Type expectedListElementType = objectType.GetGenericArguments()[0];
                Type expectedListType = typeof(List<>).MakeGenericType(expectedListElementType);
                object result = Activator.CreateInstance(expectedListType);
                if (rawList == null || rawList.Count == 0)
                {
                    return result;
                }
                // First try to parse the List normally, in case it's formatted as expected
                foreach (var rawItem in rawList)
                {
                    if (rawItem.GetType() == typeof(string) && Enum.IsDefined(expectedListElementType, rawItem.ToString()))
                    {
                        // default. everything is as it should be :-)
                        object enumValue = Enum.Parse(expectedListElementType, rawItem.ToString());
                        ((IList)result).Add(enumValue);
                    }
                    else if (rawItem.GetType() == typeof(JObject))
                    {
                        Dictionary<string, object> rawDict = ((JObject)rawItem).ToObject<Dictionary<string, object>>();
                        object rawObject = rawDict.Values.FirstOrDefault<object>();
                        object enumValue = Enum.Parse(expectedListElementType, rawObject.ToString());
                        ((IList)result).Add(enumValue);
                    }
                    else
                    {
                        ((IList)result).Add(rawItem);
                    }
                }
                return result;
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

        /// <summary>
        /// The lenient DateTimeConverter allows for transforming strings into (nullable) DateTime(?) objects,
        /// even if their formatting is somehow weird.
        /// </summary>
        public class LenientDateTimeConverter : JsonConverter
        {
            // basic structure copied from https://stackoverflow.com/a/33172735/10009545

            private readonly DateTime? _defaultDateTime;

            public LenientDateTimeConverter(DateTime? defaultDateTime = null)
            {
                this._defaultDateTime = defaultDateTime;
            }

            public LenientDateTimeConverter() : this(null)
            {

            }

            private readonly List<string> ALLOWED_DATETIME_FORMATS = new List<string>()
            {
                "yyyyMMddHHmm",
                "yyyyMMddHHmmss",
                @"yyyyMMddHHmmss'--T::zzzz'", // ToDo: remove again. this is just a buggy, nasty workaround
            };

            public override bool CanConvert(Type objectType)
            {
                return (objectType == typeof(DateTime) || objectType == typeof(DateTime?));
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                string rawDate;
                if (reader.Value == null)
                {
                    return null;
                }
                else if (reader.Value as string != null)
                {
                    rawDate = (string)reader.Value;
                }
                else if (reader.Value.GetType() == typeof(DateTime))
                {
                    return (DateTime)reader.Value;
                }
                else
                {
                    rawDate = reader.Value.ToString();
                }
                // First try to parse the date string as is (in case it is correctly formatted)
                if (DateTime.TryParse(rawDate, out DateTime date))
                {
                    return date;
                }

                foreach (string dtf in ALLOWED_DATETIME_FORMATS)
                {
                    if (DateTime.TryParseExact(rawDate, dtf, CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                    {
                        return date;
                    }
                }

                // It's not a date after all, so just return the default value
                if (objectType == typeof(DateTime?))
                {
                    return null;
                }
                if (this._defaultDateTime.HasValue)
                {
                    return _defaultDateTime;
                }
                else
                {
                    throw new JsonReaderException($"Couldn't convert {rawDate} to any of the allowed date time formats: {String.Join(";", ALLOWED_DATETIME_FORMATS)})");
                }
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

        /// <summary>
        /// The lenient StringToIntConverter allows for int or int? objects have alphabetic characters.
        /// </summary>
        /// <example>"anzahlAbschlaege": "Item12",</example>
        public class LenientStringToIntConverter : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return (objectType == typeof(int) || objectType == typeof(int?));
            }

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
                        return null;
                    else
                        return 0;
                }
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
}
