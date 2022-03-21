using System.Text.Json.Serialization;
using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>
    /// Zur Angabe einer Abweichung bei Ablehnung einer COMDIS. (REMADV SG5 RFF und SG7 AJT/FTX)
    /// </summary>
    [ProtoContract]
    [NonOfficial(NonOfficialCategory.MISSING)]
    public class Abweichung : COM
    {
        /// <summary>
        /// Referenzierung auf eine vorherige COMDIS-Nachricht
        /// </summary>
        [JsonProperty(PropertyName = "referenz", Required = Required.Default, Order = 1)]
        [JsonPropertyName("referenz")]
        [NonOfficial(NonOfficialCategory.MISSING)]
        [ProtoMember(1)]
        public string? Referenz { get; set; }


        /// <summary>
        /// Angabe des Abweichungsgrunds
        /// </summary>
        [JsonProperty(PropertyName = "abweichungsgrund", Required = Required.Always, Order = 2)]
        [JsonPropertyName("abweichungsgrund")]
        [NonOfficial(NonOfficialCategory.MISSING)]
        [ProtoMember(2)]
        public Abweichungsgrund Abweichungsgrund { get; set; }

        /// <summary>
        /// Nähere Erläuterung zum Abweichungsgrund
        /// </summary>
        [JsonProperty(PropertyName = "abweichungsgrundBemerkung", Required = Required.Default, Order = 3)]
        [JsonPropertyName("abweichungsgrundBemerkung")]
        [NonOfficial(NonOfficialCategory.MISSING)]
        [ProtoMember(3)]
        public string? AbweichungsgrundBemerkung { get; set; }
    }
}