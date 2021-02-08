using Newtonsoft.Json;

using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>Sigmoidparameter</summary>
    [ProtoContract]
    public class Sigmoidparameter : COM
    {
        /// <summary>Briefmarke Ortsverteilnetz</summary> //?
        [JsonProperty(PropertyName = "A", Required = Required.Always)]

        [System.Text.Json.Serialization.JsonPropertyName("A")]
        [ProtoMember(3)]
        public decimal A { get; set; }

        /// <summary>Wendepunkt für die bepreiste Menge</summary>
        [JsonProperty(PropertyName = "B", Required = Required.Always)]

        [System.Text.Json.Serialization.JsonPropertyName("B")]
        [ProtoMember(4)]
        public decimal B { get; set; }

        /// <summary>Exponent</summary>
        [JsonProperty(PropertyName = "C", Required = Required.Always)]

        [System.Text.Json.Serialization.JsonPropertyName("C")]
        [ProtoMember(5)]
        public decimal C { get; set; }

        /// <summary>Briefmarke Transportnetz</summary>
        [JsonProperty(PropertyName = "D", Required = Required.Always)]

        [System.Text.Json.Serialization.JsonPropertyName("D")]
        [ProtoMember(6)]
        public decimal D { get; set; }
    }
}