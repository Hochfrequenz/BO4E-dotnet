using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;
using BO4E.ENUM;
using BO4E.meta;
using BO4E.meta.LenientConverters;
using Newtonsoft.Json;
using ProtoBuf;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace BO4E.COM
{
    /// <summary>
    ///     Abbildung eines zeitlich abgegrenzten Verbrauchs.
    /// </summary>
    [ProtoContract]
    public class Verbrauch : COM
    {
        [ProtoIgnore] internal const string SapProfdecimalsKey = "sap_profdecimals";

        /// <summary>
        ///     static serializer options for Verbracuhconverter
        /// </summary>
        public static JsonSerializerOptions VerbrauchSerializerOptions;

        static Verbrauch()
        {
            VerbrauchSerializerOptions = LenientParsing.MOST_LENIENT.GetJsonSerializerOptions();
            VerbrauchSerializerOptions.Converters.Remove(
                VerbrauchSerializerOptions.Converters.First(s => s.GetType() == typeof(VerbrauchConverter)));
        }

        /// <summary>
        ///     <inheritdoc cref="CentralEuropeStandardTime.CentralEuropeStandardTimezoneInfo" />
        /// </summary>
        [ProtoIgnore]
        [Obsolete(
            "This property moved. Use the property BO4E.meta." + nameof(CentralEuropeStandardTime) + "." +
            nameof(CentralEuropeStandardTime.CentralEuropeStandardTimezoneInfo) + " instead.", true)]
        // ReSharper disable once InconsistentNaming
        public static TimeZoneInfo CENTRAL_EUROPE_STANDARD_TIME
            => CentralEuropeStandardTime.CentralEuropeStandardTimezoneInfo;

        /// <summary>
        ///     Beginn des Zeitraumes, für den der Verbrauch angegeben wird.
        /// </summary>
        /// <remarks>
        /// <c>Required = Required.Default</c>, DateTime aber nicht nullable, laut bo4e doku wäre es optional
        ///</remarks>
        [CompatibilityLevel(CompatibilityLevel.Level240)]
        [JsonProperty(PropertyName = "startdatum", Required = Required.Default, Order = 7)]
        [JsonPropertyName("startdatum")]
        [ProtoMember(3)]
        public DateTime Startdatum { get; set; } // ToDo: use datetimeoffset as well

        /// <summary>
        ///     Ende des Zeitraumes, für den der Verbrauch angegeben wird.
        /// </summary>
        [CompatibilityLevel(CompatibilityLevel.Level240)]
        [JsonProperty(PropertyName = "enddatum", Required = Required.Default, Order = 8)]
        [JsonPropertyName("enddatum")]
        [ProtoMember(4)]
        public DateTime Enddatum { get; set; } // ToDo: use datetimeoffset as well

        /// <summary>
        ///     Gibt an, ob es sich um eine PROGNOSE oder eine MESSUNG handelt.
        /// </summary>
        /// <seealso cref="ENUM.Wertermittlungsverfahren" />
        [JsonProperty(PropertyName = "wertermittlungsverfahren", Required = Required.Always, Order = 5)]
        [JsonPropertyName("wertermittlungsverfahren")]
        [ProtoMember(5)]
        public Wertermittlungsverfahren Wertermittlungsverfahren { get; set; }

        /// <summary>
        ///     Enthält die Gültigkeit des angegebenen Wertes
        /// </summary>
        /// <seealso cref="ENUM.WertMengeArt" />
        [JsonProperty(PropertyName = "wertmengeart", Required = Required.Default, Order = 5)]
        [JsonPropertyName("wertmengeart")]
        [NonOfficial(NonOfficialCategory.UNSPECIFIED)]
        [ProtoMember(10)]
        public WertMengeArt? WertMengeArt { get; set; }


        /// <summary>
        /// Enthält die Auflistung der STS Segmente Plausibilisierungshinweis, Ersatzwertbildungsverfahren,
        /// Korrekturgrund, Gasqualität, Tarif, Grundlage der Energiemenge
        /// </summary>
        [JsonProperty(PropertyName = "stauszusatzinformationen", Required = Required.Default, Order = 5)]
        [JsonPropertyName("stauszusatzinformationen")]
        [NonOfficial(NonOfficialCategory.UNSPECIFIED)]
        [ProtoMember(11)]
        public List<StatusZusatzInformation> StatusZusatzInformationen { get; set; }

        /// <summary>
        ///     Die OBIS-Kennzahl für den Wert, die festlegt, welche Größe mit dem Stand gemeldet wird.
        /// </summary>
        /// <example>
        ///     1-0:1.8.1
        /// </example>
        [JsonProperty(PropertyName = "obiskennzahl", Required = Required.Always, Order = 6)]
        [JsonPropertyName("obiskennzahl")]
        [ProtoMember(6)]
        public string Obiskennzahl { get; set; }

        /// <summary>
        ///     Gibt den absoluten Wert der Menge an.
        /// </summary>
        [JsonProperty(PropertyName = "wert", Required = Required.Always, Order = 7)]
        [JsonPropertyName("wert")]
        [ProtoMember(7)]
        public decimal Wert { get; set; }

        /// <summary>
        ///     Gibt die Einheit zum jeweiligen Wert an.
        /// </summary>
        /// <seealso cref="Mengeneinheit" />
        [JsonProperty(PropertyName = "einheit", Required = Required.Always, Order = 8)]
        [JsonPropertyName("einheit")]
        [ProtoMember(8)]
        public Mengeneinheit Einheit { get; set; }

        /// <summary>type</summary>
        /// <example>arbeitleistungtagesparameterabhmalo | veranschlagtejahresmenge | TUMKundenwert</example>
        [NonOfficial(NonOfficialCategory.UNSPECIFIED)]
        [JsonProperty(PropertyName = "type", Required = Required.Default)]
        [JsonPropertyName("type")]
        [ProtoMember(9)]
        public Verbrauchsmengetyp? Type { get; set; }

        /// <param name="context"></param>
        [OnDeserialized]
        protected void FixSapBugs(StreamingContext context)
        {
            FixSapCdsBug();
        }

        /// <summary>
        ///     static version of <see cref="Verbrauch.FixSapCdsBug()" />
        /// </summary>
        /// <param name="v">verbrauch to be fixed</param>
        /// <returns>new Verbrauch instance with fixed bugs</returns>
        public static Verbrauch FixSapCdsBug(Verbrauch v)
        {
            var result = JsonConvert.DeserializeObject<Verbrauch>(JsonConvert.SerializeObject(v));
            result.FixSapCdsBug();
            return result;
        }

        /// <summary>
        ///     static version of <see cref="Verbrauch.FixSapCdsBug()" />
        /// </summary>
        /// <param name="v">verbrauch to be fixed</param>
        /// <returns>new Verbrauch instance with fixed bugs</returns>
        public static Verbrauch FixSapCdsBugSystemTextJson(Verbrauch v)
        {
            //clone via serialization
            var result = JsonSerializer.Deserialize<Verbrauch>(JsonSerializer.Serialize(v));
            result.FixSapCdsBug();
            return result;
        }

        /// <summary>
        ///     Our SAP Core Data Service view definition reading the profile values has a bug:
        ///     The time stamp of both start- and enddatum is simply a concatenated string using the
        ///     date (defining the table row) and the time (determining the column). The design of
        ///     the table eprofval is pure PITA but we've got to deal with it anyway. Since it's
        ///     impossible to artificially increment the date directly in the definition of the
        ///     ABAP/SQL view (as of SAP 7.51), we're attempting to fix it here. On 363 days a year
        ///     the symptom is easy to detect: The last time slice of the day ranges from 23:45 of
        ///     the current day and has the enddatum t 00:00 still on the same day instead of the
        ///     following. What makes it difficult are the edge cases. What happens on the day we
        ///     switch from daylight saving time to non-daylight saving time? The time difference
        ///     could be in the order of magnitude of 22 to 25 hours. Please add new unit tests for
        ///     every edge case.
        /// </summary>
        public void FixSapCdsBug()
        {
            //using (MiniProfiler.Current.Step("FixSapCdsBug (Verbrauch)")) // don't do this. it slows down everything !
            // {
            if (Startdatum > Enddatum)
            {
                var diff = Startdatum - Enddatum;
                if (diff.Hours <= 25
                    && diff.Hours >= 23
                    && diff.Minutes == 45
                    && Startdatum.Hour >= 22
                    && Enddatum.Hour == 0) Enddatum += new TimeSpan(diff.Hours + 1, 0, 0);
            }

            Startdatum = DateTime.SpecifyKind(Startdatum, DateTimeKind.Utc);
            Enddatum = DateTime.SpecifyKind(Enddatum, DateTimeKind.Utc);
            if ((int)(Enddatum - Startdatum).TotalHours == 2)
            {
                // check DST of start and enddatum
                var startdatumLocal = TimeZoneInfo.ConvertTimeFromUtc(Startdatum,
                    CentralEuropeStandardTime.CentralEuropeStandardTimezoneInfo);
                var enddatumLocal = TimeZoneInfo.ConvertTimeFromUtc(Enddatum,
                    CentralEuropeStandardTime.CentralEuropeStandardTimezoneInfo);
                if (!CentralEuropeStandardTime.CentralEuropeStandardTimezoneInfo.IsDaylightSavingTime(startdatumLocal -
                        new TimeSpan(0, 0, 1))
                    && CentralEuropeStandardTime.CentralEuropeStandardTimezoneInfo.IsDaylightSavingTime(enddatumLocal))
                    // change winter-->summer time (e.g. UTC+1-->UTC+2)
                    // this is an artefact of the sap enddatum computation
                    Enddatum -= new TimeSpan(1, 0, 0); // toDo: get offset from timezoneinfo->rules->dstOffset
            }
            else if ((int)(Enddatum - Startdatum).TotalMinutes == -45)
            {
                // check DST of start and enddatum
                //var startdatumLocal = TimeZoneInfo.ConvertTimeFromUtc(startdatum, CentralEuropeStandardTime.CENTRAL_EUROPE_STANDARD_TIME);
                var enddatumLocal = TimeZoneInfo.ConvertTimeFromUtc(Enddatum,
                    CentralEuropeStandardTime.CentralEuropeStandardTimezoneInfo);
                if (!CentralEuropeStandardTime.CentralEuropeStandardTimezoneInfo.IsDaylightSavingTime(enddatumLocal -
                        new TimeSpan(1, 0, 0))
                    && CentralEuropeStandardTime.CentralEuropeStandardTimezoneInfo.IsDaylightSavingTime(enddatumLocal -
                        new TimeSpan(1, 0, 1)))
                    // change winter-->summer time (e.g. UTC+1-->UTC+2)
                    // this is an artefact of the sap enddatum computation
                    Enddatum += new TimeSpan(1, 0, 0); // toDo: get offset from timezoneinfo->rules->dstOffset
            }

            if (UserProperties != null
                && UserProperties.TryGetValue(SapProfdecimalsKey, out var profDecimalsRaw))
            {
                var profDecimals = 0;
                switch (profDecimalsRaw)
                {
                    case string raw:
                        profDecimals = int.Parse(raw);
                        break;
                    case long value:
                        profDecimals = (int)value;
                        break;
                    case int decimalsRaw:
                        profDecimals = decimalsRaw;
                        break;
                    default:
                        profDecimals = JsonSerializer.Deserialize<int>(((JsonElement)profDecimalsRaw).GetRawText(),
                            VerbrauchSerializerOptions);
                        break;
                }

                if (profDecimals > 0)
                    // or should I import math.pow() for this purpose?
                    for (var i = 0; i < profDecimals; i++)
                        Wert /= 10.0M;
                UserProperties.Remove(SapProfdecimalsKey);
            }
        }

        /// <summary>
        ///     SAP systems are bad in date time and time zone handling. That's why we do it here, properly.
        ///     Time zones in SAP are customizing. We can only hope that our enum contains the actual customer values.
        /// </summary>
        protected enum SapTimezone
        {
            /// <summary>
            ///     universal time coordinated
            /// </summary>
            UTC,

            /// <summary>
            ///     Greenwich Mean Time
            /// </summary>
            GMT,

            /// <summary>
            ///     Central European Time
            /// </summary>
            CET,

            /// <summary>
            ///     Central European Time ("MittelEuropäische Zeit")
            /// </summary>
            MEZ,

            /// <summary>
            ///     Central European Summer Time
            /// </summary>
            CEST,

            /// <summary>
            ///     Central European Summer Time ("MittelEuropäische SommerZeit")
            /// </summary>
            MESZ
        }
    }

    /// <summary>
    /// </summary>
    public class VerbrauchConverter : System.Text.Json.Serialization.JsonConverter<Verbrauch>
    {
        /// <summary>
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="typeToConvert"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public override Verbrauch Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var result = JsonSerializer.Deserialize<Verbrauch>(ref reader, Verbrauch.VerbrauchSerializerOptions);
            result.FixSapCdsBug();
            return result;
        }

        /// <summary>
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="options"></param>
        public override void Write(Utf8JsonWriter writer, Verbrauch value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, Verbrauch.VerbrauchSerializerOptions);
        }
    }
}