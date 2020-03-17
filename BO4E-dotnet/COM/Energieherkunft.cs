using BO4E.ENUM;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>Energieherkunft</summary>
    [ProtoContract]
    public class Energieherkunft : COM
    {
        /// <summary>Art der Erzeugung der Energie. Details <see cref="Erzeugungsart" /></summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(3)]
        public Erzeugungsart erzeugungsart;
        /// <summary>Prozentualer Anteil der jeweiligen Erzeugungsart.</summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(4)]
        public decimal anteilProzent;
    }
}