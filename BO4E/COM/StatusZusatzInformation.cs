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
    public class StatusZusatzInformation
    {
        /// <summary>
        ///     Enthält die Zusatzinformation Art des angegebenen Wertes
        /// </summary>
        /// <see cref="ENUM.WertStatuskategorie" />
        [JsonProperty(PropertyName = "wertstatuskategorie", Required = Required.Default, Order = 1)]
        [JsonPropertyName("wertstatuskategorie")]
        [NonOfficial(NonOfficialCategory.UNSPECIFIED)]
        [ProtoMember(1)]
        public WertStatuskategorie? WertStatuskategorie { get; set; }


        /// <summary>
        ///     Enthält die Zusatzinformation Status des angegebenen Wertes
        /// </summary>
        /// <see cref="ENUM.WertStatus" />
        [JsonProperty(PropertyName = "wertstatus", Required = Required.Default, Order = 2)]
        [JsonPropertyName("wertstatus")]
        [NonOfficial(NonOfficialCategory.UNSPECIFIED)]
        [ProtoMember(2)]
        public WertStatus? WertStatus { get; set; }

        /// <summary>
        ///     Enthält die Zusatzinformation Status des angegebenen Wertes
        /// </summary>
        /// <see cref="ENUM.WertStatus" />
        [JsonProperty(PropertyName = "wertstatusanlass", Required = Required.Default, Order = 3)]
        [JsonPropertyName("wertstatusanlass")]
        [NonOfficial(NonOfficialCategory.UNSPECIFIED)]
        [ProtoMember(3)]
        public WertStatusanlass? WertStatusanlass { get; set; }
    }
}