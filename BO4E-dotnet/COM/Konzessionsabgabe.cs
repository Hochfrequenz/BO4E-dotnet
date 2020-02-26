using BO4E.ENUM;
using Newtonsoft.Json;

namespace BO4E.COM
{
    /// <summary>
    /// Konzessionsabgabe
    /// </summary>
    /// <author>Hochfrequenz Unternehmensberatung GmbH</author>
    public class Konzessionsabgabe : COM
    {
        /// <summary>
        /// Art der Abgabe
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 0)]
        public AbgabeArt satz;

        /// <summary>
        /// Konzessionsabgabe in E/kWh
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 1)]
        public decimal kosten;

        /// <summary>
        /// Gebührenkategorie der Konzessionsabgabe
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 2)]
        public string kategorie;
    }
}
