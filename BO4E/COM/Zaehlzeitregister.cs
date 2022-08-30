using BO4E.ENUM;
using BO4E.meta;

using Newtonsoft.Json;

using ProtoBuf;

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BO4E.COM
{
    /// <summary>
    ///     Zaehlzeit
    /// </summary>
    [ProtoContract]
    [NonOfficial(NonOfficialCategory.REGULATORY_REQUIREMENTS)]
    public class Zaehlzeitregister : COM
    {
        /// <summary>
        ///  Zählzeitdefinition
        /// </summary>
        [JsonProperty(PropertyName = "zaehlzeitDefinition", Order = 4, Required = Required.Default)]
        [JsonPropertyOrder(4)]
        [JsonPropertyName("zaehlzeitDefinition")]
        [ProtoMember(4)]
        public string? ZaehlzeitDefinition { get; set; }

        /// <summary>
        ///     Zählzeitregister
        /// </summary>
        [JsonProperty(PropertyName = "register", Order = 5, Required = Required.Default)]
        [JsonPropertyName("register")]
        [JsonPropertyOrder(5)]
        [ProtoMember(5)]
        public string? Register { get; set; }

        /// <summary>
        ///     Schwachlastfähigkeit des Registers
        /// </summary>
        [JsonProperty(PropertyName = "schwachlastfaehig", Order = 6, Required = Required.Default)]
        [JsonPropertyName("schwachlastfaehig")]
        [JsonPropertyOrder(6)]
        [ProtoMember(6)]
        public Schwachlastfaehig? Schwachlastfaehig { get; set; }
    }
}