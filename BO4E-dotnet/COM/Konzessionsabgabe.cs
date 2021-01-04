using BO4E.ENUM;

using Newtonsoft.Json;

using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>
    /// Konzessionsabgabe
    /// </summary>
    /// <author>Hochfrequenz Unternehmensberatung GmbH</author>
    [ProtoContract]
    public class Konzessionsabgabe : Com
    {
        /// <summary>
        /// Art der Abgabe
        /// </summary>
        [JsonProperty(PropertyName = "satz", Required = Required.Always, Order = 8)]
        [ProtoMember(3)]
        public AbgabeArt Satz { get; set; }

        /// <summary>
        /// Konzessionsabgabe in E/kWh
        /// </summary>
        [JsonProperty(PropertyName = "kosten", Required = Required.Always, Order = 5)]
        [ProtoMember(4)]
        public decimal Kosten { get; set; }

        /// <summary>
        /// Gebührenkategorie der Konzessionsabgabe
        /// </summary>
        [JsonProperty(PropertyName = "kategorie", Required = Required.Always, Order = 6)]
        [ProtoMember(5)]
        public string Kategorie { get; set; }
    }
}
