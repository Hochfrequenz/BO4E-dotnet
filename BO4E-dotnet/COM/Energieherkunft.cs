using BO4E.ENUM;

using Newtonsoft.Json;

using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>Energieherkunft</summary>
    [ProtoContract]
    public class Energieherkunft : COM
    {
        /// <summary>Art der Erzeugung der Energie. Details <see cref="ENUM.Erzeugungsart" /></summary>
        [JsonProperty(PropertyName = "erzeugungsart", Required = Required.Always)]

        [System.Text.Json.Serialization.JsonPropertyName("erzeugungsart")]
        [ProtoMember(3)]
        public Erzeugungsart Erzeugungsart { get; set; }
        /// <summary>Prozentualer Anteil der jeweiligen Erzeugungsart.</summary>
        [JsonProperty(PropertyName = "anteilProzent", Required = Required.Always)]

        [System.Text.Json.Serialization.JsonPropertyName("anteilProzent")]
        [ProtoMember(4)]
        public decimal AnteilProzent { get; set; }
    }
}