using BO4E.meta;

using Newtonsoft.Json;

using ProtoBuf;

using System.Collections.Generic;

namespace BO4E.COM
{

    /// <summary>
    /// Marktrolle
    /// </summary>
    [ProtoContract]
    [NonOfficial(NonOfficialCategory.REGULATORY_REQUIREMENTS)]
    public class Verwendungszweck : COM
    {
        /// <summary>
        /// rollencodenummer von Marktrolle
        /// </summary>
        [JsonProperty(PropertyName = "marktrolle", Required = Required.Always)]

        [System.Text.Json.Serialization.JsonPropertyName("marktrolle")]
        [ProtoMember(3)]
        public BO4E.ENUM.Marktrolle Marktrolle { get; set; }

        /// <summary>
        /// code von Marktrolle
        /// </summary>
        [JsonProperty(PropertyName = "zweck", Required = Required.Default)]

        [System.Text.Json.Serialization.JsonPropertyName("zweck")]
        [ProtoMember(4)]
        public List<BO4E.ENUM.Verwendungszweck> Zweck { get; set; }

    }
}