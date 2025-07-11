#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json.Serialization;
using BO4E.COM;
using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.BO;

/// <summary>
///     Objekt zur Aufnahme der Informationen zu einer Netzlokation
/// </summary>
[ProtoContract]
public class Netzlokation : BusinessObject
{
    /// <summary>
    ///     Identifikationsnummer einer Netzlokation, an der Energie entweder
    ///     verbraucht, oder erzeugt wird (Like MarktlokationsId <see cref="Marktlokation"/>)
    /// </summary>
    [DefaultValue("|null|")]
    [JsonProperty(Order = 10, PropertyName = "netzlokationsId")]
    [JsonPropertyName("netzlokationsId")]
    [JsonPropertyOrder(10)]
    [DataCategory(DataCategory.POD)]
    [BoKey]
    [ProtoMember(4)]
    public string? NetzlokationsId { get; set; }

    /// <summary>Sparte der Netzlokation, z.B. Gas oder Strom.</summary>
    [JsonProperty(Order = 11, PropertyName = "sparte")]
    [JsonPropertyOrder(11)]
    [JsonPropertyName("sparte")]
    [ProtoMember(5)]
    public Sparte? Sparte { get; set; }

    /// <summary>
    /// Netzanschlussleistungsmenge der Netzlokation
    /// </summary>
    [JsonProperty(Order = 12, PropertyName = "netzanschlussleistung")]
    [JsonPropertyOrder(12)]
    [JsonPropertyName("netzanschlussleistung")]
    [ProtoMember(6)]
    public Menge? Netzanschlussleistung { get; set; }

    /// <summary>
    /// Codenummer des grundzuständigen Messstellenbetreibers, der für diese
    /// Netzlokation zuständig ist.
    /// </summary>
    [JsonProperty(Order = 13, PropertyName = "grundzustaendigerMSBCodeNr")]
    [JsonPropertyOrder(13)]
    [JsonPropertyName("grundzustaendigerMSBCodeNr")]
    [ProtoMember(7)]
    public string? GrundzustaendigerMSBCodeNr { get; set; }

    /// <summary>
    /// Ob ein Steuerkanal der Netzlokation zugeordnet ist und somit die Netzlokation gesteuert
    /// werden kann.
    /// ZF2: Kein Steuerkanal vorhanden
    /// ZF3: Steuerkanal vorhanden
    /// </summary>
    [JsonProperty(Order = 14, PropertyName = "steuerkanal")]
    [JsonPropertyOrder(14)]
    [JsonPropertyName("steuerkanal")]
    [ProtoMember(8)]
    public bool? Steuerkanal { get; set; }

    /// <summary>
    /// Die OBIS-Kennzahl für die Netzlokation
    /// </summary>
    [JsonProperty(Order = 15, PropertyName = "obisKennzahl")]
    [JsonPropertyOrder(15)]
    [JsonPropertyName("obisKennzahl")]
    [ProtoMember(9)]
    public string? ObisKennzahl { get; set; }

    /// <summary>Verwendungungszweck der Werte Netzlokation</summary>
    [JsonProperty(Order = 16, PropertyName = "verwendungszweck")]
    [JsonPropertyOrder(16)]
    [JsonPropertyName("verwendungszweck")]
    [ProtoMember(10)]
    public COM.Verwendungszweck? Verwendungszweck { get; set; }

    /// <summary>
    /// Produkt-Daten der Netzlokation
    /// </summary>
    [JsonProperty(Order = 17, PropertyName = "konfigurationsprodukte")]
    [JsonPropertyName("konfigurationsprodukte")]
    [ProtoMember(11)]
    [JsonPropertyOrder(17)]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    public List<Konfigurationsprodukt>? Konfigurationsprodukte { get; set; }

    /// <summary>
    /// Eigenschaft des Messstellenbetreiber an der Lokation
    /// </summary>
    [JsonProperty(Order = 18, PropertyName = "eigenschaftMSBLokation")]
    [JsonPropertyName("eigenschaftMSBLokation")]
    [ProtoMember(12)]
    [JsonPropertyOrder(18)]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    public ENUM.Marktrolle? EigenschaftMSBLokation { get; set; }

    // /// <summary>
    // /// Lokationszuordnung, um bspw. die zugehörigen Messlokationen anzugeben
    // /// </summary>
    // [JsonProperty(
    //
    //     Order = 19,
    //     PropertyName = "lokationszuordnungen"
    // )]
    // [JsonPropertyName("lokationszuordnungen")]
    // [ProtoMember(13)]
    // [JsonPropertyOrder(19)]
    // public List<Lokationszuordnung>? Lokationszuordnungen { get; set; }

    /// <summary>
    /// Lokationsbuendel Code, der die Funktion dieses BOs an der Lokationsbuendelstruktur beschreibt.
    /// </summary>
    [JsonProperty(Order = 20, PropertyName = "lokationsbuendelObjektcode")]
    [JsonPropertyName("lokationsbuendelObjektcode")]
    [ProtoMember(14)]
    [JsonPropertyOrder(20)]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    public string? LokationsbuendelObjektcode { get; set; }

    /// <summary>
    /// Enthält die ID der vorgelagerten Lokation. Kann IDs unterschiedlicher Lokationen enthalten, also zum Beispiel
    /// einer Messlokation oder Netzlokation
    /// </summary>
    [Obsolete("Abgelöst durch 'VorgelagerteLokationsIds'.")]
    [JsonProperty(Order = 21, PropertyName = "vorgelagerteLokationsId")]
    [JsonPropertyName("vorgelagerteLokationsId")]
    [ProtoMember(15)]
    [JsonPropertyOrder(21)]
    public string? VorgelagerteLokationsId { get; set; }

    /// <summary>
    /// Abrechnungsdaten der Netzlokation
    /// </summary>
    [JsonProperty(Order = 22, PropertyName = "abrechnungsdaten")]
    [JsonPropertyName("abrechnungsdaten")]
    [ProtoMember(16)]
    [JsonPropertyOrder(22)]
    public List<Netzlokationsabrechnungsdaten>? Abrechnungsdaten { get; set; }

    /// <summary>
    /// Ergänzt die Marktrollen zu der Netzlokation
    /// </summary>
    [JsonProperty(Order = 23, PropertyName = "marktrollen")]
    [JsonPropertyName("marktrollen")]
    [ProtoMember(17)]
    [JsonPropertyOrder(23)]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    public List<MarktpartnerDetails>? Marktrollen { get; set; } // ToDo: evaluate this

    /// <summary>
    /// Enthält die ID's der vorgelagerten Lokationen. Kann IDs unterschiedlicher Lokationen enthalten, also zum Beispiel
    /// einer Messlokation oder Netzlokation
    /// </summary>
    [JsonProperty(Order = 24, PropertyName = "vorgelagerteLokationsIds")]
    [JsonPropertyName("vorgelagerteLokationsIds")]
    [ProtoMember(18)]
    [JsonPropertyOrder(24)]
    public List<LokationsTypZuordnung>? VorgelagerteLokationsIds { get; set; }
}
