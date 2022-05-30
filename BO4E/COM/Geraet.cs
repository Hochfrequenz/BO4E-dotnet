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
        [JsonProperty(PropertyName = "geraetenummer", Required = Required.Default, Order = 10)]
        [JsonPropertyName("geraetenummer")]
        [ProtoMember(3)]
        [JsonPropertyOrder(10)]
        public string? Geraetenummer { get; set; }

        /// <summary>
        ///     Festlegung der Eigenschaften des Gerätes. Z.B. Wandler MS/NS. Details
        ///     <see cref="BO4E.COM.Geraeteeigenschaften" />
        /// </summary>
        [JsonProperty(PropertyName = "geraeteeigenschaften", Required = Required.Default, Order = 11)]
        [JsonPropertyName("geraeteeigenschaften")]
        [ProtoMember(4)]
        [JsonPropertyOrder(11)]
        public Geraeteeigenschaften? Geraeteeigenschaften { get; set; }
    }
}
