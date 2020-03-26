using System;
using System.Collections.Generic;
using System.Globalization;

using Newtonsoft.Json;

namespace BO4E.meta.LenientParsing
{
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
}