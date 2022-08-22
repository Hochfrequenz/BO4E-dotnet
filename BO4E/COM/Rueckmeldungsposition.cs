using BO4E.ENUM;
using BO4E.meta;

using Newtonsoft.Json;

using ProtoBuf;

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BO4E.COM
{
    /// <summary>
    /// Zur Angabe einer Rückmeldung einer einzelnen Position
    /// </summary>
    [ProtoContract]
    [NonOfficial(NonOfficialCategory.MISSING)]
    public class Rueckmeldungsposition : COM
    {

        /// <summary>
        /// Positionsnummer der Referenzierung
        /// </summary>
        [JsonProperty(PropertyName = "positionsnummer", Required = Required.Default, Order = 1)]
        [JsonPropertyName("positionsnummer")]
        [NonOfficial(NonOfficialCategory.MISSING)]
        [ProtoMember(1)]
        public string? Positionsnummer { get; set; }

        /// <summary>
        /// Abweichungspositionen
        /// </summary>
        [JsonProperty(PropertyName = "abweichungspositionen", Required = Required.Default, Order = 2)]
        [JsonPropertyName("abweichungspositionen")]
        [NonOfficial(NonOfficialCategory.MISSING)]
        [ProtoMember(2)]
        public List<Abweichungsposition>? Abweichungspositionen { get; set; }


    }
}