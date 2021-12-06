using System.Text.Json.Serialization;
using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>
    /// Enhält das STS Segemt
    /// </summary>
    [NonOfficial(NonOfficialCategory.UNSPECIFIED)]
    public class StatusZusatzInformation : COM
    {
        /// <summary>
        ///     Enthält die Zusatzinformation Art des angegebenen Wertes
        /// </summary>
        /// <see cref="StatusArt" />
        [JsonProperty(PropertyName = "art", Required = Required.Default, Order = 1)]
        [JsonPropertyName("art")]
        [NonOfficial(NonOfficialCategory.UNSPECIFIED)]
        [ProtoMember(1)]
        public StatusArt? Art { get; set; }


        /// <summary>
        ///     Enthält die Zusatzinformation Status des angegebenen Wertes
        /// </summary>
        /// <see cref="Status" />
        [JsonProperty(PropertyName = "status", Required = Required.Default, Order = 2)]
        [JsonPropertyName("status")]
        [NonOfficial(NonOfficialCategory.UNSPECIFIED)]
        [ProtoMember(2)]
        public Status? Status { get; set; }
    }
}