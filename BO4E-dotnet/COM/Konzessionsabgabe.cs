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
        [JsonProperty(Required = Required.Always, Order = 8)]
        [ProtoMember(3)]
        public AbgabeArt satz;

        /// <summary>
        /// Konzessionsabgabe in E/kWh
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 5)]
        [ProtoMember(4)]
        public decimal kosten;

        /// <summary>
        /// Gebührenkategorie der Konzessionsabgabe
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 6)]
        [ProtoMember(5)]
        public string kategorie;
    }
}
