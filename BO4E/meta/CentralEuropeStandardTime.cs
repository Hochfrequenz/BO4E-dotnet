using System;
using System.IO;
using Newtonsoft.Json;

namespace BO4E.meta
{
    /// <summary>
    ///     Holds a <see cref="TimeZoneInfo" /> object with the german time zone
    ///     <see cref="CentralEuropeStandardTimezoneInfo" />
    /// </summary>
    public abstract class CentralEuropeStandardTime
    {
        private static readonly TimeZoneInfo? _CentralEuropeStandardTimezoneInfo;

        /// <summary>
        ///     Central Europe Standard Time as hard coded default time. Public to be used elsewhere ;)
        /// </summary>
        public static TimeZoneInfo CentralEuropeStandardTimezoneInfo
        {
            get => _CentralEuropeStandardTimezoneInfo!;
        }

        static CentralEuropeStandardTime()
        {
            var assembly = typeof(CentralEuropeStandardTime).Assembly;
            // load serialized time zone from json resource file:
            const string resourceFileName = "BO4E.meta.CentralEuropeStandardTime.json";
            using var stream = assembly.GetManifestResourceStream(resourceFileName);
            if (stream == null)
            // this should never ever happen
            {
                throw new FileNotFoundException($"The file resource {resourceFileName} was not found.");
            }
            using var jsonReader = new StreamReader(stream);
            var jsonString = jsonReader.ReadToEnd();
            //Console.WriteLine(jsonString);
            _CentralEuropeStandardTimezoneInfo = JsonConvert.DeserializeObject<TimeZoneInfo>(jsonString);
        }

        /// <summary>
        ///     legacy time zone info object.
        /// </summary>
        [Obsolete("Use " + nameof(CentralEuropeStandardTimezoneInfo) + " instead.")]
        // ReSharper disable once InconsistentNaming
        public static TimeZoneInfo CENTRAL_EUROPE_STANDARD_TIME => CentralEuropeStandardTimezoneInfo;
    }
}
