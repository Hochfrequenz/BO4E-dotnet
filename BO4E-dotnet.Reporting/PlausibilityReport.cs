using BO4E.BO;
using BO4E.COM;
using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;

namespace BO4E.Reporting
{
    /// <summary>
    /// A plausibility report contains information about how likely it is that two objects of 
    /// of the type <see cref="Energiemenge"/> are actually from the same source. Typically
    /// you'd like to compare Energiemenge from meter readings with different graining.
    /// E.g. values that are transmitted periodically in 15minute intervals and isolated
    /// readings.
    /// </summary>
    public class PlausibilityReport : Report
    {
        /// <summary>
        /// all information is normalised to this reference time frame
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 7)]
        public Zeitraum referenceTimeFrame;

        /// <summary>
        /// refers to a <see cref="Energiemenge.lokationsId"/>
        /// </summary>
        [DataCategory(DataCategory.POD)]
        [JsonProperty(Required = Required.Always, Order = 8)]
        public string lokationsId;

        /// <summary>
        /// relative deviation of both Energiemengen within <see cref="referenceTimeFrame"/>.
        /// Null iff the <see cref="Verbrauch.Wert"/> of <see cref="verbrauchReference"/> is 0.
        /// </summary>
        /// <example>
        /// 0 = equal consumption
        /// +1 = other Energiemenge has twice the consumption of the reference
        /// -1 = other Energiemenge has 0 consumption
        /// </example>
        [JsonProperty(Required = Required.AllowNull, Order = 5)]
        public decimal? relativeDeviation;

        /// <summary>
        /// Verbrauch of the reference Energiemenge
        /// </summary>
        [DataCategory(DataCategory.METER_READING)]
        [JsonProperty(Required = Required.Always, Order = 6)]
        public Verbrauch verbrauchReference;

        /// <summary>
        /// Verbrauch of another Energiemenge
        /// </summary>
        [DataCategory(DataCategory.METER_READING)]
        [JsonProperty(Required = Required.Always, Order = 7)]
        public Verbrauch verbrauchOther;

        /// <summary>
        /// absolute value of the difference between <see cref="Verbrauch.Wert"/> of <see cref="verbrauchReference"/> and <see cref="verbrauchOther"/>
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 8)]
        public decimal absoluteDeviation;

        /// <summary>
        /// unit of <see cref="absoluteDeviation"/>
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 5)]
        public Mengeneinheit absoluteDeviationEinheit;

        /// <summary>
        /// This data class contains all the data required to start the PlausibilityReport generation.
        /// It's easier to handle than four single parameters passed to the constructor of the Plausibility Report.
        /// </summary>
        public class PlausibilityReportConfiguration
        {
            /// <summary>
            /// reference time frame
            /// </summary>
            [JsonProperty(Required = Required.AllowNull)]
            public Zeitraum timeframe;

            /// <summary>
            /// Energiemenge to be compared with the reference Energiemenge
            /// </summary>
            [JsonProperty(Required = Required.Always)]
            public Energiemenge other;

            /// <summary>
            /// set true to ignore if Energiemenge do have different <see cref="Energiemenge.lokationsId"/> or <see cref="Energiemenge.lokationstyp"/>
            /// </summary>
            [JsonProperty(Required = Required.Always)]
            public bool ignoreLocation;
        }
    }
}
