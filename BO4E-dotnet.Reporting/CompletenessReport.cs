using System;
using System.Collections.Generic;
using BO4E.COM;
using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;

namespace BO4E.Reporting
{
    /// <summary>
    /// A completeness report contains information about the completeness of a pure
    /// <see cref="Energiemenge"/>. In this context "pure" means, that the Energiemenge
    /// does only contain one distinct set of (<see cref="Verbrauch.obiskennzahl"/>, <see cref="Verbrauch.einheit"/>,
    /// <see cref="Verbrauch.wertermittlungsverfahren"/>).
    /// </summary>
    public class CompletenessReport : Report, IComparable<CompletenessReport>
    {
        /// <summary>
        /// all information like e.g. <see cref="coverage"/> is normalised to this reference time frame.
        /// Must only be null if an error occurred and <see cref="_errorMessage"/> is not null.
        /// </summary>
        [JsonProperty(Required = Required.AllowNull, Order = 7)]
        public Zeitraum referenceTimeFrame;

        /// <summary>
        /// <see cref="Energiemenge.lokationsId"/>
        /// </summary>
        [DataCategory(DataCategory.POD)]
        [JsonProperty(Required = Required.Always, Order = 8)]
        public string lokationsId;

        /// <summary>
        /// <see cref="Verbrauch.obiskennzahl"/>
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 5)]
        public string obiskennzahl;

        /// <summary>
        /// <see cref="Verbrauch.einheit"/>
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 6)]
        public Mengeneinheit einheit;

        /// <summary>
        /// <see cref="Verbrauch.wertermittlungsverfahren"/>
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 7)]
        public Wertermittlungsverfahren wertermittlungsverfahren;

        /// <summary>
        /// ratio of time with data present compared to <see cref="referenceTimeFrame"/>.
        /// 1.0 means 100% coverage.
        /// </summary>
        [JsonProperty(Required = Required.AllowNull, Order = 8)]
        public decimal? coverage;

        /// <summary>
        /// values
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 5)]
        [DataCategory(DataCategory.METER_READING)]
        public List<BasicVerbrauch> values;

        /// <summary>
        /// gaps are continous values (<see cref="values"/>) with value null.
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 6)]
        public List<BasicVerbrauch> gaps;

        /// <summary>
        /// optional field for storing error messages
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public string _errorMessage;

        // ToDo: make it nice.
        /// <summary>
        /// sorts two completeness reports such that those with earlier reference time are before others
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(CompletenessReport other)
        {
            if(this.referenceTimeFrame==null && other.referenceTimeFrame == null)
            {
                return 0;
            }
            if(this.referenceTimeFrame!=null && other.referenceTimeFrame == null)
            {
                return 1;
            }
            if(this.referenceTimeFrame==null && other.referenceTimeFrame != null)
            {
                return -1;
            }
            if(this.referenceTimeFrame!=null && other.referenceTimeFrame != null)
            {
                if(this.referenceTimeFrame.startdatum.HasValue && other.referenceTimeFrame.startdatum.HasValue)
                {
                    return Comparer<DateTime>.Default.Compare(referenceTimeFrame.startdatum.Value, other.referenceTimeFrame.startdatum.Value);
                }
                if (this.referenceTimeFrame.startdatum.HasValue)
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
            /// <see cref="Verbrauch.startdatum"/>
            /// </summary>
            [JsonProperty(Required = Required.Always)]
            public DateTime startdatum;
            /// <summary>
            /// <see cref="Verbrauch.enddatum"/>
            /// </summary>
            [JsonProperty(Required = Required.Always)]
            public DateTime enddatum;
            /// <summary>
            /// <see cref="Verbrauch.wert"/>. Make it null to express no value present.
            /// </summary>
            [DataCategory(DataCategory.METER_READING)]
            [JsonProperty(Required = Required.AllowNull)]
            public decimal? wert;

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
            [JsonProperty(Required = Required.Always, Order = 7)]
            public Zeitraum referenceTimeFrame;

            /// <summary>
            /// Wertermittlungsverfahren (<see cref="Verbrauch.wertermittlungsverfahren"/>) to be taken into account.
            /// </summary>
            [JsonProperty(Required = Required.Default, Order = 8)]
            public Wertermittlungsverfahren wertermittlungsverfahren;

            /// <summary>
            /// OBIS ID (<see cref="Verbrauch.obiskennzahl"/>) to be taken into account.
            /// </summary>
            [JsonProperty(Required = Required.Default, Order = 5)]
            public string obis;

            /// <summary>
            /// Unit (<see cref="Verbrauch.einheit"/>) to be taken into account.
            /// </summary>
            [JsonProperty(Required = Required.Default, Order = 6)]
            public Mengeneinheit einheit;
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
