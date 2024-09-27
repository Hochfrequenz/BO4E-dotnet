using System.Collections.Generic;
using System.Text.Json.Serialization;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM;

/// <summary>
///     Netznutzungsabrechnungsdaten
/// </summary>
[ProtoContract]
[NonOfficial(NonOfficialCategory.REGULATORY_REQUIREMENTS)]
public class Netznutzungsabrechnungsdaten : COM
{
    /// <summary>
    ///     Artikel oder Gruppen-ArtikelId
    /// </summary>
    [JsonProperty(PropertyName = "artikelId", Order = 4, Required = Required.Default)]
    [JsonPropertyOrder(4)]
    [JsonPropertyName("artikelId")]
    [ProtoMember(4)]
    public string? ArtikelId { get; set; }

    /// <summary>
    ///     Typ der ArtikelId (Einzel oder Gruppe)
    /// </summary>
    [JsonProperty(PropertyName = "artikelIdTyp", Order = 5, Required = Required.Default)]
    [JsonPropertyName("artikelIdTyp")]
    [JsonPropertyOrder(5)]
    [ProtoMember(5)]
    public ENUM.ArtikelIdTyp? ArtikelIdTyp { get; set; }

    /// <summary>
    ///     Anzahl der Positionen für diese ArtikelId
    /// </summary>
    [JsonProperty(PropertyName = "anzahl", Order = 6, Required = Required.Default)]
    [JsonPropertyOrder(6)]
    [JsonPropertyName("anzahl")]
    [ProtoMember(6)]
    public int? Anzahl { get; set; }

    /// <summary>
    ///     Gemeinderabatt
    /// </summary>
    [JsonProperty(Required = Required.Default, Order = 7, PropertyName = "gemeinderabatt")]
    [JsonPropertyName("gemeinderabatt")]
    [JsonPropertyOrder(7)]
    [ProtoMember(7)]
    public decimal? Gemeinderabatt { get; set; }

    /// <summary>
    ///     Zuschlag
    /// </summary>
    [JsonProperty(Required = Required.Default, Order = 8, PropertyName = "zuschlag")]
    [JsonPropertyName("zuschlag")]
    [JsonPropertyOrder(8)]
    [ProtoMember(8)]
    public decimal? Zuschlag { get; set; }

    /// <summary>
    ///     Abschlag
    /// </summary>
    [JsonProperty(Required = Required.Default, Order = 9, PropertyName = "abschlag")]
    [JsonPropertyName("abschlag")]
    [JsonPropertyOrder(9)]
    [ProtoMember(9)]
    public decimal? Abschlag { get; set; }

    /// <summary>
    ///     Singuläre Betriebsmittel
    /// </summary>
    [JsonProperty(
        PropertyName = "singulaereBetriebsmittel",
        Order = 10,
        Required = Required.Default
    )]
    [JsonPropertyOrder(10)]
    [JsonPropertyName("singulaereBetriebsmittel")]
    [ProtoMember(10)]
    public Menge? SingulaereBetriebsmittel { get; set; }

    /// <summary>
    ///     Preis für singuläre Betriebsmittel
    /// </summary>
    [JsonProperty(
        PropertyName = "preisSingulaereBetriebsmittel",
        Order = 11,
        Required = Required.Default
    )]
    [JsonPropertyOrder(11)]
    [JsonPropertyName("preisSingulaereBetriebsmittel")]
    [ProtoMember(11)]
    public Preis? PreisSingulaereBetriebsmittel { get; set; }

    /// <summary>
    /// Zählzeit
    /// </summary>
    [JsonProperty(PropertyName = "zaehlzeit", Order = 12, Required = Required.Default)]
    [JsonPropertyName("zaehlzeit")]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    [ProtoMember(12)]
    [JsonPropertyOrder(12)]
    public Zaehlzeitregister? Zaehlzeit { get; set; }

    /// <summary>
    /// Sind es Original oder Differenz-Netznutzungsabrechnungsdaten
    /// </summary>
    [JsonProperty(PropertyName = "istDifferenz", Order = 13, Required = Required.Default)]
    [JsonPropertyName("istDifferenz")]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    [ProtoMember(13)]
    [JsonPropertyOrder(13)]
    public bool? IstDifferenz { get; set; }

    /// <summary>
    /// Zu den Netznutzungsabrechnungsdaten gehörende Marktrollen (z.B. Netzbetreiber)
    /// </summary>
    [JsonProperty(Required = Required.Default, Order = 14, PropertyName = "marktrollen")]
    [JsonPropertyName("marktrollen")]
    [JsonPropertyOrder(14)]
    [ProtoMember(14)]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    public List<MarktpartnerDetails>? Marktrollen { get; set; }
}
