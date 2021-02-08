
using Newtonsoft.Json;

using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>Unterhalb von Angebotsteilen sind die Angebotspositionen eingebunden. Hier werden die angebotenen Bestandteile einzeln aufgeführt. Beispiel:</summary>
    [ProtoContract]
    public class Angebotsposition : COM
    {
        /// <summary>Bezeichnung der jeweiligen Position des Angebotsteils.</summary>
        [JsonProperty(PropertyName = "positionsbezeichung", Required = Required.Always)]

        [System.Text.Json.Serialization.JsonPropertyName("positionsbezeichung")]
        [ProtoMember(3)]
        public string Positionsbezeichung { get; set; }
        /// <summary>Summe der Verbräuche (z.B. in kWh), die zu dieser Angebotsposition gehören. Details <see cref="Menge" /></summary>
        [JsonProperty(PropertyName = "positionsmenge", Required = Required.Default)]

        [System.Text.Json.Serialization.JsonPropertyName("positionsmenge")]
        [ProtoMember(4)]
        public Menge Positionsmenge { get; set; }
        /// <summary>Preis pro Einheit/Stückpreis der jeweiligen Angebotsposition. Details <see cref="Preis" /></summary>
        [JsonProperty(PropertyName = "positionspreis", Required = Required.Always)]

        [System.Text.Json.Serialization.JsonPropertyName("positionspreis")]
        [ProtoMember(5)]
        public Preis Positionspreis { get; set; }
        /// <summary>Kosten (PositionsPreis * PositionsStückzahl) für diese Angebotsposition. Details <see cref="Betrag" /></summary>
        [JsonProperty(PropertyName = "positionsbetrag", Required = Required.Default)]

        [System.Text.Json.Serialization.JsonPropertyName("positionsbetrag")]
        [ProtoMember(6)]
        public Betrag Positionsbetrag { get; set; } // or positionskosten??
    }
}