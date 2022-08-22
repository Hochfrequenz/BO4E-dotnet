using BO4E.ENUM;
using BO4E.meta;

using Newtonsoft.Json;

using ProtoBuf;

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BO4E.COM
{
    /// <summary>
    /// Zur Angabe einer Abweichung einer einzelnen Position
    /// </summary>
    [ProtoContract]
    [NonOfficial(NonOfficialCategory.MISSING)]
    public class Abweichungsposition : COM
    {

        /// <summary>
        /// Angabe des Abweichungsgrunds (Code)
        /// </summary>
        [JsonProperty(PropertyName = "abweichungsgrundCode", Required = Required.Always, Order = 2)]
        [JsonPropertyName("abweichungsgrundCode")]
        [NonOfficial(NonOfficialCategory.MISSING)]
        [ProtoMember(2)]
        public string? AbweichungsgrundCode { get; set; }
        /// <summary>
        /// Angabe des Abweichungsgrunds (Codeliste)
        /// </summary>
        [JsonProperty(PropertyName = "abweichungsgrundCodeliste", Required = Required.Always, Order = 3)]
        [JsonPropertyName("abweichungsgrundCodeliste")]
        [NonOfficial(NonOfficialCategory.MISSING)]
        [ProtoMember(3)]
        public string? AbweichungsgrundCodeliste { get; set; }

        /// <summary>
        /// Nähere Erläuterung zum Abweichungsgrund
        /// </summary>
        [JsonProperty(PropertyName = "abweichungsgrundBemerkung", Required = Required.Default, Order = 4)]
        [JsonPropertyName("abweichungsgrundBemerkung")]
        [NonOfficial(NonOfficialCategory.MISSING)]
        [ProtoMember(4)]
        public string? AbweichungsgrundBemerkung { get; set; }

        /// <summary>
        /// Zugehörige Rechnung
        /// </summary>
        [JsonProperty(PropertyName = "zugehoerigeRechnung", Required = Required.Default, Order = 5)]
        [JsonPropertyName("zugehoerigeRechnung")]
        [NonOfficial(NonOfficialCategory.MISSING)]
        [ProtoMember(5)]
        public string? ZugehoerigeRechnung { get; set; }

        /// <summary>
        /// Zugehörige Bestellung
        /// </summary>
        [JsonProperty(PropertyName = "zugehoerigeBestellung", Required = Required.Default, Order = 6)]
        [JsonPropertyName("zugehoerigeBestellung")]
        [NonOfficial(NonOfficialCategory.MISSING)]
        [ProtoMember(6)]
        public string? ZugehoerigeBestellung { get; set; }

    }
}