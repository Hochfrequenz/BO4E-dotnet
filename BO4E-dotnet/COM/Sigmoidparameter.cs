using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>Sigmoidparameter</summary>
    [ProtoContract]
    public class Sigmoidparameter : COM
    {
        /// <summary>Briefmarke Ortsverteilnetz</summary> //?
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(3)]
        public decimal A;

        /// <summary>Wendepunkt für die bepreiste Menge</summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(4)]
        public decimal B;

        /// <summary>Exponent</summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(5)]
        public decimal C;

        /// <summary>Briefmarke Transportnetz</summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(6)]
        public decimal D;
    }
}