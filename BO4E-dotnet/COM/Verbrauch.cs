using System;
using System.IO;
using System.Runtime.Serialization;

using BO4E.ENUM;
using BO4E.meta;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>
    /// Abbildung eines zeitlich abgegrenzten Verbrauchs.
    /// </summary>
    [ProtoContract]
    public class Verbrauch : COM
    {
        /// <summary>
        /// Central Europe Standard Time as hard coded default time. Public to be used elsewhere ;)
        /// </summary>
        [ProtoIgnore]
        public static TimeZoneInfo CENTRAL_EUROPE_STANDARD_TIME { get; private set; }
        static Verbrauch()
        {
            var assembly = typeof(Verbrauch).Assembly; // ??? zumindest eher als executing assembly.
            // load serialized time zone from json resource file:
            using (Stream stream = assembly.GetManifestResourceStream("BO4E.CentralEuropeStandardTime.json"))
            {
                using (var jsonReader = new StreamReader(stream))
                {
                    string jsonString = jsonReader.ReadToEnd();
                    //Console.WriteLine(jsonString);
                    CENTRAL_EUROPE_STANDARD_TIME = JsonConvert.DeserializeObject<TimeZoneInfo>(jsonString);
                }
            }
        }

        /// <summary>
        /// Beginn des Zeitraumes, für den der Verbrauch angegeben wird.
        /// </summary>
        [JsonProperty(PropertyName = "startdatum", Required = Required.Default, Order = 7)]
        [ProtoMember(3, DataFormat = DataFormat.WellKnown)]
        public DateTime Startdatum { get; set; } // ToDo: use datetimeoffset as well

        /// <summary>
        /// Ende des Zeitraumes, für den der Verbrauch angegeben wird.
        /// </summary>
        [JsonProperty(PropertyName = "enddatum", Required = Required.Default, Order = 8)]
        [ProtoMember(4, DataFormat = DataFormat.WellKnown)]
        public DateTime Enddatum { get; set; } // ToDo: use datetimeoffset as well

        /// <summary>
        /// Gibt an, ob es sich um eine PROGNOSE oder eine MESSUNG handelt.
        /// </summary>
        /// <see cref="ENUM.Wertermittlungsverfahren" />
        [JsonProperty(PropertyName = "wertermittlungsverfahren", Required = Required.Always, Order = 5)]
        [ProtoMember(5)]
        public Wertermittlungsverfahren Wertermittlungsverfahren { get; set; }

        /// <summary>
        /// Die OBIS-Kennzahl für den Wert, die festlegt, welche Größe mit dem Stand gemeldet wird.
        /// </summary>
        /// <example>
        /// 1-0:1.8.1
        /// </example>
        [JsonProperty(PropertyName = "obiskennzahl", Required = Required.Always, Order = 6)]
        [ProtoMember(6)]
        public string Obiskennzahl { get; set; }

        /// <summary>
        /// Gibt den absoluten Wert der Menge an.
        /// </summary>
        [JsonProperty(PropertyName = "wert", Required = Required.Always, Order = 7)]
        [ProtoMember(7)]
        public decimal Wert { get; set; }

        /// <summary>
        /// Gibt die Einheit zum jeweiligen Wert an.
        /// </summary>
        /// <see cref="Mengeneinheit" />
        [JsonProperty(PropertyName = "einheit", Required = Required.Always, Order = 8)]
        [ProtoMember(8)]
        public Mengeneinheit Einheit { get; set; }

        /// <summary>type</summary>
        /// <example>arbeitleistungtagesparameterabhmalo | veranschlagtejahresmenge | TUMKundenwert</example>
        [NonOfficial(NonOfficialCategory.UNSPECIFIED)]
        [JsonProperty(PropertyName = "type", Required = Required.Default)]
        [ProtoMember(9)]
        public Verbrauchsmengetyp? Type { get; set; }

        /// <param name="context"></param>
        [OnDeserialized]
        protected void FixSapBugs(StreamingContext context)
        {
            this.FixSapCdsBug();
        }

        /// <summary>
        /// static version of <see cref="Verbrauch.FixSapCdsBug()"/> 
        /// </summary>
        /// <param name="v">verbrauch to be fixed</param>
        /// <returns>new Verbrauch instance with fixed bugs</returns>
        public static Verbrauch FixSapCdsBug(Verbrauch v)
        {
            Verbrauch result;
            result = JsonConvert.DeserializeObject<Verbrauch>(JsonConvert.SerializeObject(v));
            result.FixSapCdsBug();
            return result;
        }

        [ProtoIgnore]
        internal const string _SAP_PROFDECIMALS_KEY = "sap_profdecimals";

        /// <summary>
        /// Our SAP Core Data Service view definition reading the profile values has a bug: 
        /// The time stamp of both start- and enddatum is simply a concatenated string using the
        /// date (defining the table row) and the time (determining the column). The design of
        /// the table eprofval is pure PITA but we've got to deal with it anyway. Since it's
        /// impossible to artificially increment the date directly in the definition of the
        /// ABAP/SQL view (as of SAP 7.51), we're attempting to fix it here. On 363 days a year
        /// the symptom is easy to detect: The last time slice of the day ranges from 23:45 of
        /// the current day and has the enddatum t 00:00 still on the same day instead of the
        /// following. What makes it difficult are the edge cases. What happens on the day we
        /// switch from daylight saving time to non-daylight saving time? The time difference
        /// could be in the order of magnitude of 22 to 25 hours. Please add new unit tests for
        /// every edge case.
        /// </summary>
        public void FixSapCdsBug()
        {
            //using (MiniProfiler.Current.Step("FixSapCdsBug (Verbrauch)")) // don't do this. it slows down everything !
            // {
            if (Startdatum != null && Enddatum != null && Startdatum > Enddatum)
            {
                TimeSpan diff = Startdatum - Enddatum;
                if (diff.Hours <= 25 && diff.Hours >= 23 && diff.Minutes == 45 && Startdatum.Hour >= 22 && Enddatum.Hour == 0)
                {
                    Enddatum += new TimeSpan(diff.Hours + 1, 0, 0);
                }
                else
                {
                    // something seems wrong but not sure how to fix it. 
                }
            }
            Startdatum = DateTime.SpecifyKind(Startdatum, DateTimeKind.Utc);
            Enddatum = DateTime.SpecifyKind(Enddatum, DateTimeKind.Utc);
            if ((int)(Enddatum - Startdatum).TotalHours == 2)
            {
                // check DST of start and enddatum
                var startdatumLocal = TimeZoneInfo.ConvertTimeFromUtc(Startdatum, Verbrauch.CENTRAL_EUROPE_STANDARD_TIME);
                var enddatumLocal = TimeZoneInfo.ConvertTimeFromUtc(Enddatum, Verbrauch.CENTRAL_EUROPE_STANDARD_TIME);
                if (!Verbrauch.CENTRAL_EUROPE_STANDARD_TIME.IsDaylightSavingTime(startdatumLocal - new TimeSpan(0, 0, 1)) && Verbrauch.CENTRAL_EUROPE_STANDARD_TIME.IsDaylightSavingTime(enddatumLocal))
                {
                    // change winter-->summer time (e.g. UTC+1-->UTC+2)
                    // this is an artefact of the sap enddatum computation
                    Enddatum -= new TimeSpan(1, 0, 0); // toDo: get offset from timezoneinfo->rules->dstOffset
                }
            }
            else if ((int)(Enddatum - Startdatum).TotalMinutes == -45)
            {
                // check DST of start and enddatum
                //var startdatumLocal = TimeZoneInfo.ConvertTimeFromUtc(startdatum, Verbrauch.CENTRAL_EUROPE_STANDARD_TIME);
                var enddatumLocal = TimeZoneInfo.ConvertTimeFromUtc(Enddatum, Verbrauch.CENTRAL_EUROPE_STANDARD_TIME);
                if (!Verbrauch.CENTRAL_EUROPE_STANDARD_TIME.IsDaylightSavingTime(enddatumLocal - new TimeSpan(1, 0, 0)) && Verbrauch.CENTRAL_EUROPE_STANDARD_TIME.IsDaylightSavingTime(enddatumLocal - new TimeSpan(1, 0, 1)))
                {
                    // change winter-->summer time (e.g. UTC+1-->UTC+2)
                    // this is an artefact of the sap enddatum computation
                    Enddatum += new TimeSpan(1, 0, 0); // toDo: get offset from timezoneinfo->rules->dstOffset
                }
            }
            if (UserProperties != null && UserProperties.TryGetValue(_SAP_PROFDECIMALS_KEY, out JToken profDecimalsRaw))
            {
                var profDecimals = profDecimalsRaw.Value<int>();
                if (profDecimals > 0)
                {
                    // or should I import math.pow() for this purpose?
                    for (int i = 0; i < profDecimals; i++)
                    {
                        Wert /= 10.0M;
                    }
                }
                UserProperties.Remove(_SAP_PROFDECIMALS_KEY);
            }
        }

        /// <summary>
        /// SAP systems are bad in date time and time zone handling. That's why we do it here, properly.
        /// Time zones in SAP are customizing. We can only hope that our enum contains the actual customer values.
        /// </summary>
        protected enum SapTimezone
        {
            /// <summary>
            /// universal time coordinated
            /// </summary>
            UTC,
            /// <summary>
            /// Greenwich Mean Time
            /// </summary>
            GMT,
            /// <summary>
            ///  Central European Time
            /// </summary>
            CET,
            /// <summary>
            /// Central European Time ("MittelEuropäische Zeit")
            /// </summary>
            MEZ,
            /// <summary>
            /// Central European Summer Time
            /// </summary>
            CEST,
            /// <summary>
            /// Central European Summer Time ("MittelEuropäische SommerZeit")
            /// </summary>
            MESZ
        }
    }
}