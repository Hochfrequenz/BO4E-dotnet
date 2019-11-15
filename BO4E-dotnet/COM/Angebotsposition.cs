
using Newtonsoft.Json;

namespace BO4E.COM
{
    /// <summary>Unterhalb von Angebotsteilen sind die Angebotspositionen eingebunden. Hier werden die angebotenen Bestandteile einzeln aufgeführt. Beispiel:</summary>
    public class Angebotsposition : COM
    {
        /// <summary>Bezeichnung der jeweiligen Position des Angebotsteils.</summary>
        [JsonProperty(Required = Required.Always)]
        public string positionsbezeichung;
        /// <summary>Summe der Verbräuche (z.B. in kWh), die zu dieser Angebotsposition gehören. Details <see cref="Menge" /></summary>
        [JsonProperty(Required = Required.Default)]
        public Menge positionsmenge;
        /// <summary>Preis pro Einheit/Stückpreis der jeweiligen Angebotsposition. Details <see cref="Preis" /></summary>
        [JsonProperty(Required = Required.Always)]
        public Preis positionspreis;
        /// <summary>Kosten (PositionsPreis * PositionsStückzahl) für diese Angebotsposition. Details <see cref="Betrag" /></summary>
        [JsonProperty(Required = Required.Default)]
        public Betrag positionsbetrag; // or positionskosten??
    }
}