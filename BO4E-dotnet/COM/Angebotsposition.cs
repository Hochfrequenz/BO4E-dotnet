
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>Unterhalb von Angebotsteilen sind die Angebotspositionen eingebunden. Hier werden die angebotenen Bestandteile einzeln aufgeführt. Beispiel:</summary>
    [ProtoContract]
    public class Angebotsposition : COM
    {
        /// <summary>Bezeichnung der jeweiligen Position des Angebotsteils.</summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(3)]
        public string positionsbezeichung;
        /// <summary>Summe der Verbräuche (z.B. in kWh), die zu dieser Angebotsposition gehören. Details <see cref="Menge" /></summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(4)]
        public Menge positionsmenge;
        /// <summary>Preis pro Einheit/Stückpreis der jeweiligen Angebotsposition. Details <see cref="Preis" /></summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(5)]
        public Preis positionspreis;
        /// <summary>Kosten (PositionsPreis * PositionsStückzahl) für diese Angebotsposition. Details <see cref="Betrag" /></summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(6)]
        public Betrag positionsbetrag; // or positionskosten??
    }
}