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
    public class Zaehlzeit : COM
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
        [JsonProperty(PropertyName = "zaehlzeitRegister", Order = 5, Required = Required.Default)]
        [JsonPropertyName("zaehlzeitRegister")]
        [JsonPropertyOrder(5)]
        [ProtoMember(5)]
        public string? ZaehlzeitRegister { get; set; }
    }
}