using System;
using System.Collections.Generic;
using System.Linq;

using BO4E.COM;
using BO4E.ENUM;
using BO4E.meta;

using Newtonsoft.Json;

namespace BO4E.Reporting
{
    /// <summary>
    /// A completeness report contains information about the completeness of a pure
    /// <see cref="Energiemenge"/>. In this context "pure" means, that the Energiemenge
    /// does only contain one distinct set of (<see cref="Verbrauch.Obiskennzahl"/>, <see cref="Verbrauch.Einheit"/>,
    /// <see cref="Verbrauch.Wertermittlungsverfahren"/>).
    /// </summary>
    public class CompletenessReport : Report, IComparable<CompletenessReport>
    {
        /// <summary>
        /// all information like e.g. <see cref="Coverage"/> is normalised to this reference time frame.
        /// Must only be null if an error occurred and <see cref="ErrorMessage"/> is not null.
        /// </summary>
        [JsonProperty(PropertyName = "referenceTimeFrame", Required = Required.AllowNull, Order = 7)]
        public Zeitraum ReferenceTimeFrame { get; set; }

        /// <summary>
        /// <see cref="Energiemenge.lokationsId"/>
        /// </summary>
        [DataCategory(DataCategory.POD)]
        [JsonProperty(PropertyName = "lokationsId", Required = Required.Always, Order = 8)]
        public string LokationsId { get; set; }

        /// <summary>
        /// <see cref="Verbrauch.Obiskennzahl"/>
        /// </summary>
        [JsonProperty(PropertyName = "obiskennzahl", Required = Required.Default, Order = 5)]
        public string Obiskennzahl { get; set; }

        /// <summary>
        /// <see cref="Verbrauch.Einheit"/>
        /// </summary>
        [JsonProperty(PropertyName = "einheit", Required = Required.Default, Order = 6)]
        public Mengeneinheit Einheit { get; set; }

        /// <summary>
        /// <see cref="Verbrauch.Wertermittlungsverfahren"/>
        /// </summary>
        [JsonProperty(PropertyName = "wertermittlungsverfahren", Required = Required.Default, Order = 7)]
        public Wertermittlungsverfahren wertermittlungsverfahren { get; set; }

        /// <summary>
        /// ratio of time with data present compared to <see cref="ReferenceTimeFrame"/>.
        /// 1.0 means 100% coverage.
        /// </summary>
        [JsonProperty(PropertyName = "coverage", Required = Required.AllowNull, Order = 8)]
        public decimal? Coverage { get; set; }

        /// <summary>
        /// values
        /// </summary>
        [JsonProperty(PropertyName = "values", Required = Required.Default, Order = 5)]
        [DataCategory(DataCategory.METER_READING)]
        public List<BasicVerbrauch> Values { get; set; }

        /// <summary>
        /// gaps are continous values (<see cref="Values"/>) with value null.
        /// </summary>
        [JsonProperty(PropertyName = "gaps", Required = Required.Default, Order = 6)]
        public List<BasicVerbrauch> Gaps { get; set; }

        /// <summary>
        /// optional field for storing error messages
        /// </summary>
        [JsonProperty(PropertyName = "_errorMessage", Required = Required.Default)]
        public string ErrorMessage { get; set; }

        // ToDo: make it nice.
        /// <summary>
        /// sorts two completeness reports such that those with earlier reference time are before others
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(CompletenessReport other)
        {
            if (this.ReferenceTimeFrame == null && other.ReferenceTimeFrame == null)
            {
                return 0;
            }
            if (this.ReferenceTimeFrame != null && other.ReferenceTimeFrame == null)
            {
                return 1;
            }
            if (this.ReferenceTimeFrame == null && other.ReferenceTimeFrame != null)
            {
                return -1;
            }
            if (this.ReferenceTimeFrame != null && other.ReferenceTimeFrame != null)
            {
                if (this.ReferenceTimeFrame.Startdatum.HasValue && other.ReferenceTimeFrame.Startdatum.HasValue)
                {
                    return Comparer<DateTimeOffset>.Default.Compare(ReferenceTimeFrame.Startdatum.Value, other.ReferenceTimeFrame.Startdatum.Value);
                }
                if (this.ReferenceTimeFrame.Startdatum.HasValue)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            return 0;
        }

        /// <summary>
        /// similar to <see cref="Verbrauch"/> but with less obligatory values.
        /// </summary>
        // howto inherit from Verbrauch but change the JsonProperties?
        public class BasicVerbrauch // : Verbrauch
        {
            /// <summary>
            /// <see cref="Verbrauch.Startdatum"/>
            /// </summary>
            [JsonProperty(PropertyName = "startdatum", Required = Required.Always)]
            public DateTime Startdatum { get; set; }
            /// <summary>
            /// <see cref="Verbrauch.Enddatum"/>
            /// </summary>
            [JsonProperty(PropertyName = "enddatum", Required = Required.Always)]
            public DateTime Enddatum { get; set; }
            /// <summary>
            /// <see cref="Verbrauch.Wert"/>. Make it null to express no value present.
            /// </summary>
            [DataCategory(DataCategory.METER_READING)]
            [JsonProperty(PropertyName = "wert", Required = Required.AllowNull)]
            public decimal? Wert { get; set; }

            /*
            [JsonIgnore]
            [JsonProperty(Required = Required.Default)]
            private new readonly Wertermittlungsverfahren wertermittlungsverfahren;

            [JsonIgnore]
            [JsonProperty(Required = Required.Default)]
            private new readonly Mengeneinheit mengeneinheit;

            [JsonIgnore]
            [JsonProperty(Required = Required.Default)]
            private new readonly string obiskennzahl;
            */
        }

        /// <summary>
        /// This data class contains all the parameters required to start the CompletenessReport generation.
        /// It's easier to handle than four single parameters passed to the constructor of the CompletenessReport.
        /// </summary>
        public class CompletenessReportConfiguration
        {
            /// <summary>
            /// reference time frame to be analysed
            /// </summary>
            [JsonProperty(PropertyName = "referenceTimeFrame", Required = Required.Always, Order = 7)]
            public Zeitraum ReferenceTimeFrame { get; set; }

            /// <summary>
            /// Wertermittlungsverfahren (<see cref="Verbrauch.Wertermittlungsverfahren"/>) to be taken into account.
            /// </summary>
            [JsonProperty(PropertyName = "wertermittlungsverfahren", Required = Required.Default, Order = 8)]
            public Wertermittlungsverfahren Wertermittlungsverfahren { get; set; }

            /// <summary>
            /// OBIS ID (<see cref="Verbrauch.Obiskennzahl"/>) to be taken into account.
            /// </summary>
            [JsonProperty(PropertyName = "obis", Required = Required.Default, Order = 5)]
            public string Obis { get; set; }

            /// <summary>
            /// Unit (<see cref="Verbrauch.Einheit"/>) to be taken into account.
            /// </summary>
            [JsonProperty(PropertyName = "einheit", Required = Required.Default, Order = 6)]
            public Mengeneinheit Einheit { get; set; }
        }

        public string toCSV(char separator = ';', bool headerLine = true, string lineTerminator = "\\n", List<Dictionary<string, string>> reihenfolge = null)
        {
            string returnCSV = "";
            if (headerLine)
            {
                returnCSV = "Startdatum" + separator + "Enddatum" + separator + "Melo" + separator + "Malo" + separator + "Messung" + separator + "MSB" + separator +
                    "Profil-Nr" + separator + "Profil-Typ" + separator + "Zeitbereich in dem kein wahrer Wert vorhanden ist von" +
                    separator + "Zeitbereich in dem kein wahrer Wert vorhanden ist bis" + separator + "Anzahl fehlende Werte" +
                    separator + "Prozentuale Vollständigkeit" + separator + "Status" + lineTerminator;
            }
            returnCSV += this.ReferenceTimeFrame.Startdatum.Value.ToString("yyyy-MM-ddTHH:mm:ssZ") + separator +
                this.ReferenceTimeFrame.Enddatum.Value.ToString("yyyy-MM-ddTHH:mm:ssZ") + separator;

            returnCSV += LokationsId + separator; // Melo
            returnCSV += LokationsId + separator; // Malo

            string messung = "RLM";
            if (Obiskennzahl.Contains("-65:"))
            {
                messung = "IMS";
            }
            returnCSV += messung + separator;
            returnCSV += "MSB" + separator; // MSB
            if (this.UserProperties.TryGetValue("profil", out var profil))
            {
                returnCSV += profil.ToString() + separator;
            }
            else
            {
                returnCSV += separator;
            }

            if (this.UserProperties.TryGetValue("profilRolle", out var profilRolle))
            {
                returnCSV += profilRolle.ToString() + separator;
            }
            else
            {
                returnCSV += separator;
            }
            if (Gaps.Count > 0)
            {
                DateTime minGap = this.Gaps.OrderBy(x => x.Startdatum).First().Startdatum;
                DateTime maxGap = this.Gaps.OrderByDescending(x => x.Enddatum).First().Startdatum;
                returnCSV += minGap.ToString("yyyy-MM-ddTHH:mm:ssZ") + separator + maxGap.ToString("yyyy-MM-ddTHH:mm:ssZ") + separator;
            }
            else
            {
                returnCSV += separator + separator;
            }
            returnCSV += ((1 - this.Coverage) * (ReferenceTimeFrame.Dauer / 15)).ToString() + separator;
            returnCSV += (this.Coverage * 100).ToString() + " %" + separator;
            returnCSV += "Status" + lineTerminator;
            return returnCSV;
        }

        /*
        /// <summary>
        /// allows sorting completeness reports based on <see cref="CompletenessReport.referenceTimeFrame.startdatum"/>
        /// </summary>
        public class CompletenessReportComparer : IComparer<CompletenessReport>
        {
            public int Compare(CompletenessReport x, CompletenessReport y)
            {
                if (x.referenceTimeFrame != null && x.referenceTimeFrame.startdatum.HasValue && y.referenceTimeFrame != null && y.referenceTimeFrame.startdatum.HasValue)
                {
                    return x.referenceTimeFrame.startdatum < y.referenceTimeFrame.startdatum ? 0 : 1;
                }
                else if (x.referenceTimeFrame != null && x.referenceTimeFrame.startdatum.HasValue)
                {
                    return -1;
                }
                else
                {
                    return x.referenceTimeFrame != null ? 0 : 1;
                }
            }
        }*/

    }
}
