using Newtonsoft.Json;

using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>Sigmoidparameter</summary>
    [ProtoContract]
    public class Sigmoidparameter : Com
    {
        /// <summary>Briefmarke Ortsverteilnetz</summary> //?
        [JsonProperty(PropertyName = "A", Required = Required.Always)]
        [ProtoMember(3)]
        public decimal A { get; set; }

        /// <summary>Wendepunkt für die bepreiste Menge</summary>
        [JsonProperty(PropertyName = "B", Required = Required.Always)]
        [ProtoMember(4)]
        public decimal B { get; set; }

        /// <summary>Exponent</summary>
        [JsonProperty(PropertyName = "C", Required = Required.Always)]
        [ProtoMember(5)]
        public decimal C { get; set; }

        /// <summary>Briefmarke Transportnetz</summary>
        [JsonProperty(PropertyName = "D", Required = Required.Always)]
        [ProtoMember(6)]
        public decimal D { get; set; }
    }
}