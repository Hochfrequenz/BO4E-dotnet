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
    public class Konzessionsabgabe : COM
    {
        /// <summary>
        /// Art der Abgabe
        /// </summary>
        [JsonProperty(PropertyName = "satz", Required = Required.Always, Order = 8)]

        [System.Text.Json.Serialization.JsonPropertyName("satz")]
        [ProtoMember(3)]
        public AbgabeArt Satz { get; set; }

        /// <summary>
        /// Konzessionsabgabe in E/kWh
        /// </summary>
        [JsonProperty(PropertyName = "kosten", Required = Required.Always, Order = 5)]

        [System.Text.Json.Serialization.JsonPropertyName("kosten")]
        [ProtoMember(4)]
        public decimal Kosten { get; set; }

        /// <summary>
        /// Gebührenkategorie der Konzessionsabgabe
        /// </summary>
        [JsonProperty(PropertyName = "kategorie", Required = Required.Always, Order = 6)]

        [System.Text.Json.Serialization.JsonPropertyName("kategorie")]
        [ProtoMember(5)]
        public string Kategorie { get; set; }
    }
}
