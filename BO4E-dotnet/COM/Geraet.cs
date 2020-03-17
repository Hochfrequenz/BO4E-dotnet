using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>Mit dieser Komponente werden alle Geräte modelliert, die keine Zähler sind.</summary>
    [ProtoContract]
    public class Geraet : COM
    {
        /// <summary>Die auf dem Geräte aufgedruckte Nummer, die vom MSB vergeben wird.</summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(3)]
        public string geraetenummer;
        /// <summary>Festlegung der Eigenschaften des Gerätes. Z.B. Wandler MS/NS. Details <see cref="Geraeteeigenschaften" /></summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(4)]
        public Geraeteeigenschaften geraeteeigenschaften;
    }
}