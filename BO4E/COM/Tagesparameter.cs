using BO4E.meta;

using Newtonsoft.Json;

using ProtoBuf;

using System.Text.Json.Serialization;

namespace BO4E.COM
{
    /// <summary>
    ///     Tagesparameter
    /// </summary>
    [ProtoContract]
    [NonOfficial(NonOfficialCategory.REGULATORY_REQUIREMENTS)]
    public class Tagesparameter : COM
    {
        /// <summary>
        ///     Qualifier der Klimazone
        /// </summary>
        [JsonProperty(PropertyName = "klimazone", Required = Required.Always)]
        [JsonPropertyName("klimazone")]
        [ProtoMember(3)]
        public string Klimazone { get; set; }

        /// <summary>
        ///     Qualifier der Temperaturmessstelle
        /// </summary>
        [JsonProperty(PropertyName = "temperaturmessstelle", Required = Required.Always)]
        [JsonPropertyName("temperaturmessstelle")]
        [ProtoMember(4)]
        public string Temperaturmessstelle { get; set; }

        /// <summary>
        ///    Dienstanbieter (bei Temperaturmessstellen)
        /// </summary>
        [JsonProperty(PropertyName = "dienstanbieter", Required = Required.Default)]
        [JsonPropertyName("dienstanbieter")]
        [ProtoMember(5)]
        public string Dienstanbieter { get; set; }
    }
}