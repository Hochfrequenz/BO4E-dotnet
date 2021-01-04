using System;
using System.Runtime.Serialization;

using BO4E.ENUM;
using BO4E.meta;
using BO4E.meta.LenientConverters;

using Newtonsoft.Json;

using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>Diese Komponente wird zur Abbildung von Zeiträumen in Form von Dauern oder der Angabe von Start und Ende verwendet.</summary>
    [ProtoContract]
    public class Zeitraum : COM
    {
        /// <summary>Die Einheit in der die Dauer angeben ist. Z.B. Monate. <seealso cref="Zeiteinheit" /></summary>
        [JsonProperty(PropertyName = "einheit", Required = Required.Default)]
        [FieldName("unit", Language.EN)]
        [ProtoMember(3)]
        public Zeiteinheit? Einheit { get; set; }

        /// <summary>Gibt die Anzahl der Zeiteinheiten an, z.B. 3 (Monate).</summary>
        [JsonProperty(PropertyName = "dauer", Required = Required.Default)]
        [FieldName("duration", Language.EN)]
        [ProtoMember(4)]
        public decimal? Dauer { get; set; }

        /// <summary>Gibt Tag und Uhrzeit (falls vorhanden) an, wann der Zeitraum startet.</summary>
        [JsonProperty(PropertyName = "startdatum", Required = Required.Default)]
        [FieldName("startDate", Language.EN)]
        [ProtoMember(5)]
        [JsonConverter(typeof(LenientDateTimeConverter))]
        public DateTimeOffset? Startdatum { get; set; }

        /// <summary>Gibt Tag und Uhrzeit (falls vorhanden) an, wann der Zeitraum endet.</summary>
        [JsonProperty(PropertyName = "enddatum", Required = Required.Default)]
        [FieldName("endDate", Language.EN)]
        [ProtoMember(6)]
        [JsonConverter(typeof(LenientDateTimeConverter))]
        public DateTimeOffset? Enddatum { get; set; }

        /// <summary>
        /// sets <see cref="Dauer"/> and <see cref="Einheit"/> iff <see cref="Startdatum"/> and <see cref="Enddatum"/> are given.
        /// </summary>
        [OnSerialized]
        public void FillNullValues(StreamingContext context)
        {
            if (Startdatum.HasValue && Enddatum.HasValue)
            {
                var ts = Enddatum.Value - Startdatum.Value;
                if (ts.TotalSeconds < 60)
                {
                    Dauer = (decimal)ts.TotalSeconds;
                    Einheit = Zeiteinheit.SEKUNDE;
                }
                else if (ts.TotalSeconds < 3600)
                {
                    Dauer = (decimal)ts.TotalMinutes;
                    Einheit = Zeiteinheit.MINUTE;
                }
                else if (ts.TotalSeconds < 24 * 3600)
                {
                    Dauer = (decimal)ts.TotalHours;
                    Einheit = Zeiteinheit.STUNDE;
                }
                else// if (ts.TotalDays < 31)
                {
                    Dauer = (decimal)ts.TotalDays;
                    Einheit = Zeiteinheit.TAG;
                }
            }
        }
        /*
        /// <summary>
        /// perform consistency check
        /// </summary>
        [OnDeserialized]
        public void CheckConsistency()
        {
            if (dauer != null && !einheit.HasValue)
            {
                th
            }
        }*/

        // ToDo: Implement typeconverter for Zeitraum<-->TimeRange
    }
}