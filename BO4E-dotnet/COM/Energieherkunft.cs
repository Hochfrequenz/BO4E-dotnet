using BO4E.ENUM;

using Newtonsoft.Json;

using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>Energieherkunft</summary>
    [ProtoContract]
    public class Energieherkunft : Com
    {
        /// <summary>Art der Erzeugung der Energie. Details <see cref="ENUM.Erzeugungsart" /></summary>
        [JsonProperty(PropertyName = "erzeugungsart", Required = Required.Always)]
        [ProtoMember(3)]
        public Erzeugungsart Erzeugungsart { get; set; }
        /// <summary>Prozentualer Anteil der jeweiligen Erzeugungsart.</summary>
        [JsonProperty(PropertyName = "anteilProzent", Required = Required.Always)]
        [ProtoMember(4)]
        public decimal AnteilProzent { get; set; }
    }
}