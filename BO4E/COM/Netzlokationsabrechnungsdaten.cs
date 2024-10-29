using System.Collections.Generic;
using System.Text.Json.Serialization;
using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM;

/// <summary>
///     Abrechnungsdaten der Netzlokation
/// </summary>
[ProtoContract]
[NonOfficial(NonOfficialCategory.REGULATORY_REQUIREMENTS)]
public class Netzlokationsabrechnungsdaten : COM
{
    /// <summary>
    ///     Artikel oder Gruppen-ArtikelId
    /// </summary>
    [JsonProperty(PropertyName = "artikelId", Order = 4)]
    [JsonPropertyOrder(4)]
    [JsonPropertyName("artikelId")]
    [ProtoMember(4)]
    public string? ArtikelId { get; set; }

    /// <summary>
    ///     Typ der ArtikelId (Einzel oder Gruppe)
    /// </summary>
    [JsonProperty(PropertyName = "artikelIdTyp", Order = 5)]
    [JsonPropertyName("artikelIdTyp")]
    [JsonPropertyOrder(5)]
    [ProtoMember(5)]
    public ENUM.ArtikelIdTyp? ArtikelIdTyp { get; set; }

    /// <summary>
    /// Zahler der Blindarbeit
    /// </summary>
    [JsonProperty(PropertyName = "blindarbeitszahler", Order = 10)]
    [JsonPropertyName("blindarbeitszahler")]
    [JsonPropertyOrder(10)]
    [ProtoMember(10)]
    public Blindarbeitszahler? Blindarbeitszahler { get; set; }

    /// <summary>
    /// Findet eine Abrechnung der Blindarbeit statt?
    /// </summary>
    [JsonProperty(PropertyName = "findetBlindarbeitsAbrechnungStatt", Order = 11)]
    [JsonPropertyName("findetBlindarbeitsAbrechnungStatt")]
    [JsonPropertyOrder(11)]
    [ProtoMember(11)]
    public bool? FindetBlindarbeitsAbrechnungStatt { get; set; }

    /// <summary>
    /// Ist der Lieferant bereit die Blindarbeit zu zahlen
    /// </summary>
    [JsonProperty(PropertyName = "lieferantBereitZurZahlungBlindarbeit", Order = 12)]
    [JsonPropertyName("lieferantBereitZurZahlungBlindarbeit")]
    [JsonPropertyOrder(12)]
    [ProtoMember(12)]
    public bool? LieferantBereitZurZahlungBlindarbeit { get; set; }
}
