using System;
using System.Runtime.Serialization;
using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;

namespace BO4E.COM
{
    /// <summary>Diese Komponente wird zur Abbildung von Zeiträumen in Form von Dauern oder der Angabe von Start und Ende verwendet.</summary>
    public class Zeitraum : COM
    {
        /// <summary>Die Einheit in der die Dauer angeben ist. Z.B. Monate. <seealso cref="Zeiteinheit" /></summary>
        [JsonProperty(Required = Required.Default)]
        [FieldName("unit", Language.EN)]
        public Zeiteinheit? einheit;
        /// <summary>Gibt die Anzahl der Zeiteinheiten an, z.B. 3 (Monate).</summary>
        [JsonProperty(Required = Required.Default)]
        [FieldName("duration", Language.EN)]
        public decimal? dauer;
        /// <summary>Gibt Tag und Uhrzeit (falls vorhanden) an, wann der Zeitraum startet.</summary>
        [JsonProperty(Required = Required.Default)]
        [FieldName("startDate", Language.EN)]
        public DateTime? startdatum;
        /// <summary>Gibt Tag und Uhrzeit (falls vorhanden) an, wann der Zeitraum endet.</summary>
        [JsonProperty(Required = Required.Default)]
        [FieldName("endDate", Language.EN)]
        public DateTime? enddatum;

        /// <summary>
        /// sets <see cref="dauer"/> and <see cref="einheit"/> iff <see cref="startdatum"/> and <see cref="enddatum"/> are given.
        /// </summary>
        [OnSerialized]
        public void FillNullValues(StreamingContext context)
        {
            if (startdatum.HasValue && enddatum.HasValue)
            {
                TimeSpan ts = enddatum.Value - startdatum.Value;
                if (ts.TotalSeconds < 60)
                {
                    dauer = (decimal)ts.TotalSeconds;
                    einheit = Zeiteinheit.SEKUNDE;
                }
                else if (ts.TotalSeconds < 3600)
                {
                    dauer = (decimal)ts.TotalMinutes;
                    einheit = Zeiteinheit.MINUTE;
                }
                else if (ts.TotalSeconds < 24 * 3600)
                {
                    dauer = (decimal)ts.TotalHours;
                    einheit = Zeiteinheit.STUNDE;
                }
                else// if (ts.TotalDays < 31)
                {
                    dauer = (decimal)ts.TotalDays;
                    einheit = Zeiteinheit.TAG;
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