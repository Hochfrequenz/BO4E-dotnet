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
        [JsonProperty(PropertyName = "positionsnummer", Required = Required.Default, Order = 3)]
        [JsonPropertyName("positionsnummer")]
        [NonOfficial(NonOfficialCategory.MISSING)]
        [ProtoMember(3)]
        [JsonPropertyOrder(3)]
        public string? Positionsnummer { get; set; }

        /// <summary>
        /// Abweichungspositionen
        /// </summary>
        [JsonProperty(PropertyName = "abweichungspositionen", Required = Required.Default, Order = 4)]
        [JsonPropertyName("abweichungspositionen")]
        [NonOfficial(NonOfficialCategory.MISSING)]
        [ProtoMember(4)]
        [JsonPropertyOrder(4)]
        public List<Abweichungsposition>? Abweichungspositionen { get; set; }


    }
}