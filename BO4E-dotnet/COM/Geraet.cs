using Newtonsoft.Json;

namespace BO4E.COM
{
    /// <summary>Mit dieser Komponente werden alle Geräte modelliert, die keine Zähler sind.</summary>
    public class Geraet : COM
    {
        /// <summary>Die auf dem Geräte aufgedruckte Nummer, die vom MSB vergeben wird.</summary>
        [JsonProperty(Required = Required.Default)]
        public string geraetenummer;
        /// <summary>Festlegung der Eigenschaften des Gerätes. Z.B. Wandler MS/NS. Details <see cref="Geraeteeigenschaften" /></summary>
        [JsonProperty(Required = Required.Default)]
        public string geraeteeigenschaften;
    }
}