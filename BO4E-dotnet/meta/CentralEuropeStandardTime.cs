using Newtonsoft.Json;

using System;
using System.IO;

namespace BO4E.meta
{
    /// <summary>
    /// Holds a <see cref="TimeZoneInfo"/> object with the german time zone <see cref="CENTRAL_EUROPE_STANDARD_TIME"/>
    /// </summary>
    public abstract class CentralEuropeStandardTime
    {
        /// <summary>
        /// Central Europe Standard Time as hard coded default time. Public to be used elsewhere ;)
        /// </summary>
        public static readonly TimeZoneInfo CENTRAL_EUROPE_STANDARD_TIME;
        static CentralEuropeStandardTime()
        {
            var assembly = typeof(CentralEuropeStandardTime).Assembly;
            // load serialized time zone from json resource file:
            using (Stream stream = assembly.GetManifestResourceStream("BO4E.meta.CentralEuropeStandardTime.json"))
            {
                using (var jsonReader = new StreamReader(stream))
                {
                    string jsonString = jsonReader.ReadToEnd();
                    //Console.WriteLine(jsonString);
                    CENTRAL_EUROPE_STANDARD_TIME = JsonConvert.DeserializeObject<TimeZoneInfo>(jsonString);
                }
            }
        }
    }
}
