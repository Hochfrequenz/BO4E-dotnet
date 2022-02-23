using System.Text.Json.Serialization;
using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>
    ///     Unterhalb von Angebotsteilen sind die Angebotspositionen eingebunden. Hier werden die angebotenen Bestandteile
    ///     einzeln aufgeführt. Beispiel:
    /// </summary>
    [ProtoContract]
    public class Angebotsposition : COM
    {
        /// <summary>Bezeichnung der jeweiligen Position des Angebotsteils.</summary>
        [JsonProperty(PropertyName = "positionsbezeichung", Required = Required.Always)]
        [JsonPropertyName("positionsbezeichung")]
        [ProtoMember(3)]
        public string Positionsbezeichung { get; set; }

        /// <summary>
        ///     Summe der Verbräuche (z.B. in kWh), die zu dieser Angebotsposition gehören. Details <see cref="Menge" />
        /// </summary>
        [JsonProperty(PropertyName = "positionsmenge", Required = Required.Default)]
        [JsonPropertyName("positionsmenge")]
        [ProtoMember(4)]
        public Menge Positionsmenge { get; set; }

        /// <summary>Preis pro Einheit/Stückpreis der jeweiligen Angebotsposition. Details <see cref="Preis" /></summary>
        [JsonProperty(PropertyName = "positionspreis", Required = Required.Default)]
        [JsonPropertyName("positionspreis")]
        [ProtoMember(5)]
        public Preis Positionspreis { get; set; }

        /// <summary>
        ///     Kosten (PositionsPreis * PositionsStückzahl) für diese Angebotsposition. Details <see cref="Betrag" />
        /// </summary>
        [JsonProperty(PropertyName = "positionsbetrag", Required = Required.Default)]
        [JsonPropertyName("positionsbetrag")]
        [ProtoMember(6)]
        public Betrag Positionsbetrag { get; set; } // or positionskosten??

        /// <summary>Preisschlüsselstamm als Alternative zum Preis/></summary>
        [JsonProperty(PropertyName = "preisschluesselstamm", Required = Required.Default)]
        [JsonPropertyName("preisschluesselstamm")]
        [NonOfficial(NonOfficialCategory.MISSING)]
        [ProtoMember(7)]
        public string Preisschluesselstamm { get; set; }

        /// <summary>
        ///     Eine vom BDEW standardisierte Bezeichnung für die abgerechnete Leistungserbringung. Diese Artikelnummer wird
        ///     auch im Rechnungsteil der INVOIC verwendet. <seealso cref="BDEWArtikelnummer" />
        /// </summary>
        [JsonProperty(PropertyName = "bdewArtikelnummer", Required = Required.Default)]
        [JsonPropertyName("bdewArtikelnummer")]
        [NonOfficial(NonOfficialCategory.MISSING)]
        [ProtoMember(8)]
        public BDEWArtikelnummer? BdewArtikelnummer { get; set; }
    }
}