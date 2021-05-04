using System.Text.Json.Serialization;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>Mit dieser Komponente werden alle Geräte modelliert, die keine Zähler sind.</summary>
    [ProtoContract]
    public class Geraet : COM
    {
        /// <summary>Die auf dem Geräte aufgedruckte Nummer, die vom MSB vergeben wird.</summary>
        [JsonProperty(PropertyName = "geraetenummer", Required = Required.Default)]
        [JsonPropertyName("geraetenummer")]
        [ProtoMember(3)]
        public string Geraetenummer { get; set; }

        /// <summary>
        ///     Festlegung der Eigenschaften des Gerätes. Z.B. Wandler MS/NS. Details
        ///     <see cref="BO4E.COM.Geraeteeigenschaften" />
        /// </summary>
        [JsonProperty(PropertyName = "geraeteeigenschaften", Required = Required.Default)]
        [JsonPropertyName("geraeteeigenschaften")]
        [ProtoMember(4)]
        public Geraeteeigenschaften Geraeteeigenschaften { get; set; }
    }
}