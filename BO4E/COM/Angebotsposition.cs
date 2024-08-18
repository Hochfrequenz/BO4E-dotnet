#nullable enable
using BO4E.ENUM;
using BO4E.meta;

using Newtonsoft.Json;

using ProtoBuf;

using System.Text.Json.Serialization;

namespace BO4E.COM;

/// <summary>
///     Unterhalb von Angebotsteilen sind die Angebotspositionen eingebunden. Hier werden die angebotenen Bestandteile
///     einzeln aufgeführt. Beispiel:
/// </summary>
[ProtoContract]
public class Angebotsposition : COM
{
    /// <summary>Bezeichnung der jeweiligen Position des Angebotsteils.</summary>
    [JsonProperty(PropertyName = "positionsbezeichung", Required = Required.Always, Order = 10)]
    [JsonPropertyName("positionsbezeichung")]
    [JsonPropertyOrder(10)]
    [ProtoMember(3)]
    public string? Positionsbezeichung { get; set; }

    /// <summary>
    ///     Summe der Verbräuche (z.B. in kWh), die zu dieser Angebotsposition gehören. Details <see cref="Menge" />
    /// </summary>
    [JsonProperty(PropertyName = "positionsmenge", Required = Required.Default, Order = 11)]
    [JsonPropertyName("positionsmenge")]
    [JsonPropertyOrder(11)]
    [ProtoMember(4)]
    public Menge? Positionsmenge { get; set; }

    /// <summary>Preis pro Einheit/Stückpreis der jeweiligen Angebotsposition. Details <see cref="Preis" /></summary>
    [JsonProperty(PropertyName = "positionspreis", Required = Required.Default, Order = 12)]
    [JsonPropertyName("positionspreis")]
    [JsonPropertyOrder(12)]
    [ProtoMember(5)]
    public Preis? Positionspreis { get; set; }

    /// <summary>
    ///     Kosten (PositionsPreis * PositionsStückzahl) für diese Angebotsposition. Details <see cref="Betrag" />
    /// </summary>
    [JsonProperty(PropertyName = "positionsbetrag", Required = Required.Default, Order = 13)]
    [JsonPropertyName("positionsbetrag")]
    [JsonPropertyOrder(13)]
    [ProtoMember(6)]
    public Betrag? Positionsbetrag { get; set; } // or positionskosten??

    /// <summary>Preisschlüsselstamm als Alternative zum Preis/></summary>
    [JsonProperty(PropertyName = "preisschluesselstamm", Required = Required.Default, Order = 14)]
    [JsonPropertyName("preisschluesselstamm")]
    [JsonPropertyOrder(14)]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(7)]
    public string? Preisschluesselstamm { get; set; }

    /// <summary>
    ///     Eine vom BDEW standardisierte Bezeichnung für die abgerechnete Leistungserbringung. Diese Artikelnummer wird
    ///     auch im Rechnungsteil der INVOIC verwendet. <seealso cref="BDEWArtikelnummer" />
    /// </summary>
    [JsonProperty(PropertyName = "bdewArtikelnummer", Required = Required.Default, Order = 15)]
    [JsonPropertyName("bdewArtikelnummer")]
    [JsonPropertyOrder(15)]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(8)]
    public BDEWArtikelnummer? BdewArtikelnummer { get; set; }

    /// <summary>
    ///  Die genauen Bedeutungen der einzelnen Artikel-IDs sind in der EDI@Energy Codeliste der Artikelnummern 
    /// und Artikel-IDs zu finden, die in der Spalte des entsprechenden Prüfidentifikator ein X haben
    /// </summary>
    [JsonProperty(PropertyName = "artikelId", Order = 16, Required = Required.Default)]
    [JsonPropertyName("artikelId")]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [JsonPropertyOrder(16)]
    [ProtoMember(9)]
    public string? ArtikelId { get; set; }
}
