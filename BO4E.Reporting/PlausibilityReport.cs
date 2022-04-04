using BO4E.BO;
using BO4E.COM;
using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;

namespace BO4E.Reporting
{
    /// <summary>
    ///     A plausibility report contains information about how likely it is that two objects of
    ///     of the type <see cref="Energiemenge" /> are actually from the same source. Typically
    ///     you'd like to compare Energiemenge from meter readings with different graining.
    ///     E.g. values that are transmitted periodically in 15minute intervals and isolated
    ///     readings.
    /// </summary>
    public class PlausibilityReport : Report
    {
        /// <summary>
        ///     all information is normalised to this reference time frame
        /// </summary>
        [JsonProperty(PropertyName = "referenceTimeFrame", Required = Required.Always, Order = 7)]
        public Zeitraum ReferenceTimeFrame { get; set; }

        /// <summary>
        ///     refers to a <see cref="Energiemenge.LokationsId" />
        /// </summary>
        [DataCategory(DataCategory.POD)]
        [JsonProperty(PropertyName = "lokationsId", Required = Required.Always, Order = 8)]
        public string LokationsId { get; set; }

        /// <summary>
        ///     relative deviation of both Energiemengen within <see cref="ReferenceTimeFrame" />.
        ///     Null iff the <see cref="Verbrauch.Wert" /> of <see cref="VerbrauchReference" /> is 0.
        /// </summary>
        /// <example>
        ///     0 = equal consumption
        ///     +1 = other Energiemenge has twice the consumption of the reference
        ///     -1 = other Energiemenge has 0 consumption
        /// </example>
        [JsonProperty(PropertyName = "relativeDeviation", Required = Required.Default, Order = 5)]
        public decimal? RelativeDeviation { get; set; }

        /// <summary>
        ///     Verbrauch of the reference Energiemenge
        /// </summary>
        [DataCategory(DataCategory.METER_READING)]
        [JsonProperty(PropertyName = "verbrauchReference", Required = Required.Always, Order = 6)]
        public Verbrauch VerbrauchReference { get; set; }

        /// <summary>
        ///     Verbrauch of another Energiemenge
        /// </summary>
        [DataCategory(DataCategory.METER_READING)]
        [JsonProperty(PropertyName = "verbrauchOther", Required = Required.Always, Order = 7)]
        public Verbrauch VerbrauchOther { get; set; }

        /// <summary>
        ///     absolute value of the difference between <see cref="Verbrauch.Wert" /> of <see cref="VerbrauchReference" /> and
        ///     <see cref="VerbrauchOther" />
        /// </summary>
        [JsonProperty(PropertyName = "absoluteDeviation", Required = Required.Always, Order = 8)]
        public decimal AbsoluteDeviation { get; set; }

        /// <summary>
        ///     unit of <see cref="AbsoluteDeviation" />
        /// </summary>
        [JsonProperty(PropertyName = "absoluteDeviationEinheit", Required = Required.Always, Order = 5)]
        public Mengeneinheit AbsoluteDeviationEinheit { get; set; }

        /// <summary>
        ///     This data class contains all the data required to start the PlausibilityReport generation.
        ///     It's easier to handle than four single parameters passed to the constructor of the Plausibility Report.
        /// </summary>
        public class PlausibilityReportConfiguration
        {
            /// <summary>
            ///     reference time frame
            /// </summary>
            [JsonProperty(PropertyName = "timeframe", Required = Required.Default)]
            public Zeitraum Timeframe { get; set; }

            /// <summary>
            ///     Energiemenge to be compared with the reference Energiemenge
            /// </summary>
            [JsonProperty(PropertyName = "other", Required = Required.Always)]
            public Energiemenge Other { get; set; }

            /// <summary>
            ///     set true to ignore if Energiemenge do have different <see cref="Energiemenge.LokationsId" /> or
            ///     <see cref="Energiemenge.LokationsTyp" />
            /// </summary>
            [JsonProperty(PropertyName = "ignoreLocation", Required = Required.Always)]
            public bool IgnoreLocation { get; set; }
        }
    }
}
