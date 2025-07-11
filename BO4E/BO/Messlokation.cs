using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using BO4E.COM;
using BO4E.ENUM;
using BO4E.meta;
using BO4E.meta.LenientConverters;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.BO;

// The key order is actually relevant for the online validation. WTF!
// https://github.com/Hochfrequenz/energy-service-hub/issues/11
//@JsonPropertyOrder({ "versionStruktur", "boTyp", "messLokationsId", "sparte", "netzebeneMessung", "messgebietNr",
//       "grundzustaendigerMSBCodeNr", "grundzustaendigerMSBIMCodeNr", "grundzustaendigerMDLodeNr", "messadresse",
//        "geoadresse", "katasterinformation", "geraete", "messdienstleistung", "messlokationszaehler" })
/// <summary>
///     Objekt zur Aufnahme der Informationen zu einer Messlokation.
/// </summary>
[ProtoContract]
public class Messlokation : BusinessObject
{
    [Newtonsoft.Json.JsonIgnore]
    [System.Text.Json.Serialization.JsonIgnore]
    private static readonly Regex RegexValidate = new(@"[A-Z\d]{33}", RegexOptions.Compiled);

    /// <summary>
    ///     Die Messlokations-Identifikation. Das ist die frühere Zählpunktbezeichnung,
    ///     z.B. DE 47108151234567
    /// </summary>
    [DefaultValue("|null|")]
    [JsonProperty(PropertyName = "messlokationsId", Order = 10)]
    [JsonPropertyName("messlokationsId")]
    [JsonPropertyOrder(10)]
    [DataCategory(DataCategory.POD)]
    [BoKey]
    [ProtoMember(4)]
    public string MesslokationsId { get; set; }

    /// <summary>
    ///     * Sparte der Messlokation, z.B. Gas oder Strom.
    ///     <seealso cref="ENUM.Sparte" />
    /// </summary>
    [JsonProperty(PropertyName = "sparte", Order = 11)]
    [JsonPropertyName("sparte")]
    [JsonPropertyOrder(11)]
    [ProtoMember(5)]
    public Sparte Sparte { get; set; }

    ///<summary> Spannungsebene der Messung. <seealso cref="Netzebene" /></summary>
    [JsonProperty(PropertyName = "netzebeneMessung", Order = 12)] //explicitly set NOT required.
    [JsonPropertyName("netzebeneMessung")]
    [JsonPropertyOrder(12)]
    [ProtoMember(6)]
    public Netzebene? NetzebeneMessung { get; set; }

    /// <summary>Die Nummer des Messgebietes in der ene't-Datenbank.</summary>
    [JsonProperty(PropertyName = "messgebietNr", Order = 13)]
    [JsonPropertyOrder(13)]
    [JsonPropertyName("messgebietNr")]
    [ProtoMember(7)]
    public string? MessgebietNr { get; set; }

    /// <summary>
    ///     Codenummer des grundzuständigen Messstellenbetreibers, der für diese
    ///     Messlokation zuständig ist.( Dieser ist immer dann Messstellenbetreiber, wenn
    ///     kein anderer MSB die Einrichtungen an der Messlokation betreibt.)
    /// </summary>
    [JsonProperty(PropertyName = "grundzustaendigerMSBCodeNr", Order = 14)]
    [JsonPropertyOrder(14)]
    [JsonPropertyName("grundzustaendigerMSBCodeNr")]
    [ProtoMember(8)]
    public string? GrundzustaendigerMSBCodeNr { get; set; }

    /// <summary>
    ///     Codenummer des grundzuständigen Messstellenbetreibers für intelligente
    ///     Messsysteme der für diese Messlokation zuständig ist.(Dieser ist immer dann
    ///     Messstellenbetreiber, wenn kein anderer MSB die Einrichtungen an der
    ///     Messlokation betreibt.)
    /// </summary>
    [JsonProperty(PropertyName = "grundzustaendigerMSBIMCodeNr", Order = 15)]
    [JsonPropertyOrder(15)]
    [JsonPropertyName("grundzustaendigerMSBIMCodeNr")]
    [ProtoMember(9)]
    public string? GrundzustaendigerMSBIMCodeNr { get; set; } // grundzustaendigerMSB_IMCodenr;  https://github.com/Hochfrequenz/energy-service-hub/issues/11

    /// <summary>
    ///     Codenummer des Messdienstleisters, der für diese Messlokation zuständig
    ///     ist.( Dieser ist immer dann Messdienstleister, wenn kein anderer MDL die
    ///     Messlokation abliest.)
    /// </summary>
    [JsonProperty(
        PropertyName = "grundzustaendigerMDLCodeNr",
        Order = 16,
        Required = Required.Default
    )]
    [JsonPropertyOrder(16)]
    [JsonPropertyName("grundzustaendigerMDLCodeNr")]
#pragma warning disable CS0618 // Type or member is obsolete
    [NonOfficial(NonOfficialCategory.PROPOSED_DELETION)]
#pragma warning restore CS0618 // Type or member is obsolete
    [ProtoMember(10)]
    [Obsolete("MDL is deprecated.", true)]
    public string? GrundzustaendigerMDLCodeNr { get; set; }

    /// <summary>
    ///     Die Adresse, an der die Messeinrichtungen zu finden sind.( Nur angeben, wenn
    ///     diese von der Adresse der Marktlokation abweicht.)
    ///     Achtung: Es darf immer nur eine Art der Ortsangabe vorhanden sein (entweder
    ///     eine Adresse oder eine GeoKoordinate oder eine Katasteradresse.
    /// </summary>
    [JsonProperty(PropertyName = "messadresse", Order = 17)]
    [JsonPropertyOrder(17)]
    [JsonPropertyName("messadresse")]
    [DataCategory(DataCategory.ADDRESS)]
    [ProtoMember(11)]
    public Adresse? Messadresse { get; set; }

    /// <summary>
    ///     Alternativ zu einer postalischen Adresse kann hier ein Ort mittels
    ///     Geokoordinaten angegeben werden (z.B. zur Identifikation von Sendemasten).
    ///     Achtung: Es darf immer nur eine Art der Ortsangabe vorhanden sein (entweder
    ///     eine Adresse oder eine GeoKoordinate oder eine Katasteradresse.
    /// </summary>
    [JsonProperty(PropertyName = "geoadresse", Order = 18)]
    [JsonPropertyOrder(18)]
    [JsonPropertyName("geoadresse")]
    [DataCategory(DataCategory.ADDRESS)]
    [ProtoMember(12)]
    public Geokoordinaten? Geoadresse { get; set; }

    /// <summary>
    ///     Alternativ zu einer postalischen Adresse und Geokoordinaten kann hier eine
    ///     Ortsangabe mittels Gemarkung und Flurstück erfolgen.
    ///     Achtung: Es darf immer nur eine Art der Ortsangabe vorhanden sein (entweder
    ///     eine Adresse oder eine GeoKoordinate oder eine Katasteradresse.
    /// </summary>
    /// */
    [JsonProperty(PropertyName = "katasterinformation", Order = 19)]
    [JsonPropertyOrder(19)]
    [JsonPropertyName("katasterinformation")]
    [ProtoMember(13)]
    [DataCategory(DataCategory.ADDRESS)]
    public Katasteradresse? Katasterinformation { get; set; }

    /// <summary>Liste der Hardware, die zu dieser Messstelle gehört.</summary>
    [JsonProperty(PropertyName = "geraete", Order = 20)]
    [JsonPropertyOrder(20)]
    [JsonPropertyName("geraete")]
    [ProtoMember(14)]
    public List<Hardware>? Geraete { get; set; }

    /// <summary>Liste der Messdienstleistungen, die zu dieser Messstelle gehört.</summary>
    [JsonProperty(PropertyName = "messdienstleistung", Order = 21)]
    [JsonPropertyOrder(21)]
    [JsonPropertyName("messdienstleistung")]
    [ProtoMember(15)]
    public List<Dienstleistung>? Messdienstleistung { get; set; }

    /// <summary> Zähler, die zu dieser Messlokation gehören. Details</summary>
    [JsonProperty(PropertyName = "messlokationszaehler", Order = 22)]
    [JsonPropertyOrder(22)]
    [JsonPropertyName("messlokationszaehler")]
    [ProtoMember(16)]
    public List<Zaehler>? Messlokationszaehler { get; set; }

    /// <summary>
    ///     <see cref="Marktlokation.Bilanzierungsmethode" />
    /// </summary>
    [JsonProperty(PropertyName = "bilanzierungsmethode", Order = 23)]
    [JsonPropertyOrder(23)]
    [JsonPropertyName("bilanzierungsmethode")]
    [ProtoMember(17)]
    public Bilanzierungsmethode? Bilanzierungsmethode { get; set; }

    /// <summary>
    ///     Dieser Wert ist true, falls die Abrechnungs des Messstellenbetriebs die Netznutzungsabrechnung enthält. false
    ///     andernfalls
    /// </summary>
    [JsonProperty(PropertyName = "abrechnungmessstellenbetriebnna", Order = 24)]
    [JsonPropertyOrder(24)]
    [JsonPropertyName("abrechnungmessstellenbetriebnna")]
    [ProtoMember(1018)]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    public bool? Abrechnungmessstellenbetriebnna { get; set; }

    /// <summary>
    ///     marktrollen für EDIFACT mapping
    /// </summary>
    [JsonProperty(Order = 25, PropertyName = "marktrollen")]
    [JsonPropertyOrder(25)]
    [JsonPropertyName("marktrollen")]
    [ProtoMember(1019)]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    public List<MarktpartnerDetails>? Marktrollen { get; set; }

    /// <summary>
    ///     gasqualitaet für EDIFACT mapping
    /// </summary>
    [JsonProperty(
        PropertyName = "gasqualitaet",
        Order = 26,
        NullValueHandling = NullValueHandling.Ignore
    )]
    [JsonPropertyName("gasqualitaet")]
    [JsonPropertyOrder(26)]
    [ProtoMember(1020)]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    [System.Text.Json.Serialization.JsonConverter(
        typeof(SystemTextNullableGasqualitaetStringEnumConverter)
    )]
    [Newtonsoft.Json.JsonConverter(typeof(NewtonsoftGasqualitaetStringEnumConverter))]
    public Gasqualitaet? Gasqualitaet { get; set; }

    /// <summary>
    ///     verlustfaktor für EDIFACT mapping
    /// </summary>
    // ToDo: so does this mean that a factor of 0.0M has no losses?
    [JsonProperty(PropertyName = "verlustfaktor", Order = 27)]
    [JsonPropertyOrder(27)]
    [JsonPropertyName("verlustfaktor")]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    [ProtoMember(1021)]
    public decimal? Verlustfaktor { get; set; }

    /// <summary>
    ///     OBIS-Daten der Messlokation
    /// </summary>
    // ToDo: specify docstring.
    [JsonProperty(Order = 28, PropertyName = "zaehlwerke")]
    [JsonPropertyName("zaehlwerke")]
    [JsonPropertyOrder(28)]
    [ProtoMember(1022)]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    public List<Zaehlwerk>? Zaehlwerke { get; set; }

    /// <summary>
    ///     gasqualitaet für EDIFACT mapping
    /// </summary>
    [JsonProperty(
        PropertyName = "betriebszustand",
        Order = 29,
        NullValueHandling = NullValueHandling.Ignore
    )]
    [JsonPropertyName("betriebszustand")]
    [JsonPropertyOrder(29)]
    [ProtoMember(1023)]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    public Betriebszustand? Betriebszustand { get; set; }

    /// <summary>
    ///   Zugeordnete Messprodukte
    /// </summary>
    [JsonProperty(Order = 30, PropertyName = "messprodukte")]
    [JsonPropertyName("messprodukte")]
    [ProtoMember(1024)]
    [JsonPropertyOrder(30)]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    public List<Messprodukt>? Messprodukte { get; set; }

    // /// <summary>
    // /// Lokationszuordnung, um bspw. die zugehörigen Marktlokationen anzugeben
    // /// </summary>
    // [JsonProperty(
    //
    //     Order = 31,
    //     PropertyName = "lokationszuordnungen"
    // )]
    // [JsonPropertyName("lokationszuordnungen")]
    // [ProtoMember(1025)]
    // [JsonPropertyOrder(31)]
    // public List<Lokationszuordnung>? Lokationszuordnungen { get; set; }

    /// <summary>
    /// Lokationsbuendel Code, der die Funktion dieses BOs an der Lokationsbuendelstruktur beschreibt.
    /// </summary>
    [JsonProperty(Order = 32, PropertyName = "lokationsbuendelObjektcode")]
    [JsonPropertyName("lokationsbuendelObjektcode")]
    [ProtoMember(1026)]
    [JsonPropertyOrder(32)]
    public string? LokationsbuendelObjektcode { get; set; }

    /// <summary>
    /// Enthält die ID der vorgelagerten Lokation. Kann IDs unterschiedlicher Lokationen enthalten, also zum Beispiel
    /// einer Messlokation oder Netzlokation
    /// </summary>
    [Obsolete("Abgelöst durch 'VorgelagerteLokationsIds'.")]
    [JsonProperty(Order = 33, PropertyName = "vorgelagerteLokationsId")]
    [JsonPropertyName("vorgelagerteLokationsId")]
    [ProtoMember(1027)]
    [JsonPropertyOrder(33)]
    public string? VorgelagerteLokationsId { get; set; }

    /// <summary>
    /// Behelfs-Flag das anzeigt, ob eine Messlokation für die Lieferanmeldung relevant ist (true).
    /// </summary>
    /// <remarks>
    /// Das kann in Systemen hilfreich sein, die nicht die volle Komplexität von Lokationsbündeln abbildeln.
    /// </remarks>
    [JsonProperty(Order = 34, PropertyName = "istFuerLieferanmeldungRelevant")]
    [JsonPropertyName("istFuerLieferanmeldungRelevant")]
    [ProtoMember(1028)]
    [JsonPropertyOrder(34)]
    public bool? IstFuerLieferanmeldungRelevant { get; set; } = null;

    /// <summary>
    /// Enthält die ID's der vorgelagerten Lokationen. Kann IDs unterschiedlicher Lokationen enthalten, also zum Beispiel
    /// einer Messlokation oder Netzlokation
    /// </summary>
    [JsonProperty(Order = 35, PropertyName = "vorgelagerteLokationsIds")]
    [JsonPropertyName("vorgelagerteLokationsIds")]
    [ProtoMember(1029)]
    [JsonPropertyOrder(35)]
    public List<LokationsTypZuordnung>? VorgelagerteLokationsIds { get; set; }

    /// <summary>
    ///     Test if a <paramref name="id" /> is a valid messlokations ID.
    /// </summary>
    /// <param name="id">id to test</param>
    /// <returns></returns>
    public static bool ValidateId(string id)
    {
        return !string.IsNullOrWhiteSpace(id) && RegexValidate.IsMatch(id);
    }

    /// <summary>
    ///     Test if the <see cref="MesslokationsId" /> is valid.
    /// </summary>
    /// <returns>if messlokationsId matches the expected format</returns>
    public bool HasValidId()
    {
        return ValidateId(MesslokationsId);
    }

    /// <summary>
    ///     same as <see cref="BusinessObject.IsValid()" /> if <paramref name="checkId" /> is false but by default additionally
    ///     checks if the <see cref="MesslokationsId" /> is valid using <see cref="HasValidId" />.
    /// </summary>
    /// <param name="checkId">validate the <see cref="MesslokationsId" />, too</param>
    /// <returns>true if the marktlokation is valid</returns>
    public bool IsValid(bool checkId = true)
    {
        return base.IsValid() && (!checkId || HasValidId());
    }
}
