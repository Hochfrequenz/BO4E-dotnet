using System.ComponentModel;
using System.Text.Json.Serialization;
using BO4E.COM;
using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.BO;

/// <summary>
/// Technische Ressource BO
/// </summary>
[ProtoContract]
[NonOfficial(NonOfficialCategory.MISSING)]
public class TechnischeRessource : BusinessObject
{
    /// <summary>
    /// Identifikationsnummer einer TechnischeRessource
    /// </summary>
    /// <remarks>Edi-beispiel: LOC+Z19+C816417ST77'</remarks>
    [DefaultValue("|null|")]
    [JsonProperty(PropertyName = "technischeRessourceId", Required = Required.Default, Order = 10)]
    [JsonPropertyName("technischeRessourceId")]
    [JsonPropertyOrder(10)]
    [DataCategory(DataCategory.DEVICE)]
    [BoKey]
    [ProtoMember(10)]
    public string? TechnischeRessourceId { get; set; }

    /// <summary>
    /// Vorgelagerte Messlokation ID
    /// Beispiel:
    /// RFF+Z34:DE00713739359S0000000000001222221'
    /// </summary>
    [JsonProperty(
        PropertyName = "vorgelagerteMesslokationsId",
        Required = Required.Default,
        Order = 11
    )]
    [JsonPropertyName("vorgelagerteMesslokationsId")]
    [JsonPropertyOrder(11)]
    [DataCategory(DataCategory.POD)]
    [ProtoMember(11)]
    public string? VorgelagerteMesslokationsId { get; set; }

    /// <summary>
    /// Referenz auf die der Technischen Ressource Zugeordneten Marktlokation
    /// Beispiel:
    /// RFF+Z16:20072281644'
    /// </summary>
    [JsonProperty(
        PropertyName = "zugeordneteMarktlokationsId",
        Required = Required.Default,
        Order = 12
    )]
    [JsonPropertyName("zugeordneteMarktlokationsId")]
    [JsonPropertyOrder(12)]
    [DataCategory(DataCategory.POD)]
    [ProtoMember(12)]
    public string? ZugeordneteMarktlokationsId { get; set; }

    /// <summary>
    /// Referenz auf die der Technischen Ressource zugeordneten Steuerbaren Ressource
    /// Beispiel:
    /// RFF+Z16:20072281644'
    /// </summary>
    [JsonProperty(
        PropertyName = "zugeordneteSteuerbareRessourceId",
        Required = Required.Default,
        Order = 13
    )]
    [JsonPropertyName("zugeordneteSteuerbareRessourceId")]
    [JsonPropertyOrder(13)]
    [DataCategory(DataCategory.POD)]
    [ProtoMember(13)]
    public string? ZugeordneteSteuerbareRessourceId { get; set; }

    /// <summary>
    /// Nennleistung (Aufnahme)
    /// Beispiel: QTY+Z43:100:KWT'
    /// </summary>
    [JsonProperty(PropertyName = "nennleistungAufnahme", Required = Required.Default, Order = 14)]
    [JsonPropertyName("nennleistungAufnahme")]
    [JsonPropertyOrder(14)]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(14)]
    public Menge? NennleistungAufnahme { get; set; }

    /// <summary>
    /// Nennleistung (Abgabe)
    /// Beispiel: QTY+Z44:100:KWT'
    /// </summary>
    [JsonProperty(PropertyName = "nennleistungAbgabe", Required = Required.Default, Order = 15)]
    [JsonPropertyName("nennleistungAbgabe")]
    [JsonPropertyOrder(15)]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(15)]
    public Menge? NennleistungAbgabe { get; set; }

    /// <summary>
    /// Speicherkapazität
    /// Beispiel: QTY+Z42:100:KWH'
    /// </summary>
    [JsonProperty(PropertyName = "speicherkapazitaet", Required = Required.Default, Order = 16)]
    [JsonPropertyName("speicherkapazitaet")]
    [JsonPropertyOrder(16)]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(16)]
    public Menge? Speicherkapazitaet { get; set; }

    /// <summary>
    /// Art und Nutzung der Technischen Ressource
    /// Beispiel: CCI+Z17'
    ///     Z17: Stromverbrauchsart
    ///     Z50: Stromerzeugungsart
    ///     Z56: Speicher
    /// </summary>
    [JsonProperty(
        PropertyName = "technischeRessourceNutzung",
        Required = Required.Default,
        Order = 17
    )]
    [JsonPropertyName("technischeRessourceNutzung")]
    [JsonPropertyOrder(17)]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(17)]
    public TechnischeRessourceNutzung? TechnischeRessourceNutzung { get; set; }

    /// <summary>
    /// Verbrauchsart der Technischen Ressource
    /// Beispiel: CAV+Z64'
    ///     Z64: Kraft/Licht
    ///     Z65: Wärme
    ///     ZE5: E-Mobilität
    ///     ZA8: Straßenbeleuchtung
    /// </summary>
    [JsonProperty(PropertyName = "verbrauchsart", Required = Required.Default, Order = 18)]
    [JsonPropertyOrder(18)]
    [JsonPropertyName("verbrauchsart")]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(18)]
    public TechnischeRessourceVerbrauchsart? Verbrauchsart { get; set; }

    /// <summary>
    /// Wärmenutzung
    /// Beispiel: CAV+Z56'
    ///     Z56: Speicherheizung
    ///     Z57: Wärmepumpe (unspezifiziert)
    ///     Z61: Direktheizung
    ///     ZV5: Wärmepumpe (Wärme und Kälte)
    ///     ZV6: Wärmepumpe (Kälte)
    ///     ZV7: Wärmepumpe (Wärme)
    /// </summary>
    [JsonProperty(PropertyName = "waermenutzung", Required = Required.Default, Order = 19)]
    [JsonPropertyOrder(19)]
    [JsonPropertyName("waermenutzung")]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(19)]
    public Waermenutzung? Waermenutzung { get; set; }

    /// <summary>
    /// Art der E-Mobilität
    /// Das Segment dient dazu, im Falle der E-Mobilität eine genauere Angabe über die Art der E-Mobilität zu definieren.
    /// Beispiel: CAV+Z87'
    ///     ZE6: Wallbox: An der Marktlokation ist eine nicht öffentlliche Lademöglichkeit vorhanden
    ///     Z87: E-Mobilitätsladesäule: Es handelt sich um eine öffentliche Ladesäule mit ggf. mehreren Ladeanschlüssen an der Marktlokation.
    ///     ZE7: Ladepark: Es handelt sich um mehr als eine öffentliche Ladesäule an der Marktlokation
    /// </summary>
    [JsonProperty(PropertyName = "emobilitaetsart", Required = Required.Default, Order = 20)]
    [JsonPropertyOrder(20)]
    [JsonPropertyName("emobilitaetsart")]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(20)]
    public EMobilitaetsart? EMobilitaetsart { get; set; }

    /// <summary>
    /// Art der Erzeugung der Energie. Details <see cref="ENUM.Erzeugungsart" />
    /// Beispiel: CAV+ZF5'
    /// Erzeugungsart:
    ///     ZF5: Solar
    ///     ZF6: Wind
    ///     ZG0: Gas
    ///     ZG1: Wasser
    ///     ZG5: Sonstige Erzeugungsart
    /// </summary>
    [JsonProperty(PropertyName = "erzeugungsart", Required = Required.Default, Order = 21)]
    [JsonPropertyOrder(21)]
    [JsonPropertyName("erzeugungsart")]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(21)]
    public Erzeugungsart? Erzeugungsart { get; set; }

    /// <summary>
    /// Art der speicher. Details <see cref="ENUM.Speicherart" />
    /// Beispiel: CAV+ZF7'
    /// Speicherart:
    ///     ZF7: Wasserstoffspeicher
    ///     ZF8: Pumpspeicher
    ///     ZF9: Batteriespeicher
    ///     ZG6: Sonstige Speicherart
    /// </summary>
    [JsonProperty(PropertyName = "speicherart", Required = Required.Default, Order = 22)]
    [JsonPropertyOrder(22)]
    [JsonPropertyName("speicherart")]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(22)]
    public Speicherart? Speicherart { get; set; }

    // /// <summary>
    // /// Lokationszuordnung, um bspw. die zugehörigen Messlokationen anzugeben
    // /// </summary>
    // [JsonProperty(
    //     Required = Required.Default,
    //     Order = 23,
    //     PropertyName = "lokationszuordnungen"
    // )]
    // [JsonPropertyName("lokationszuordnungen")]
    // [ProtoMember(23)]
    // [JsonPropertyOrder(23)]
    // public List<Lokationszuordnung>? Lokationszuordnungen { get; set; }

    /// <summary>
    /// Lokationsbuendel Code, der die Funktion dieses BOs an der Lokationsbuendelstruktur beschreibt.
    /// </summary>
    [JsonProperty(
        Required = Required.Default,
        Order = 24,
        PropertyName = "lokationsbuendelObjektcode"
    )]
    [JsonPropertyName("lokationsbuendelObjektcode")]
    [ProtoMember(24)]
    [JsonPropertyOrder(24)]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    public string? LokationsbuendelObjektcode { get; set; }

    /// <summary>
    /// Enthält die ID der vorgelagerten Lokation. Kann IDs unterschiedlicher Lokationen enthalten, also zum Beispiel
    /// einer Messlokation oder Netzlokation
    /// </summary>
    [JsonProperty(
        Required = Required.Default,
        Order = 25,
        PropertyName = "vorgelagerteLokationsId"
    )]
    [JsonPropertyName("vorgelagerteLokationsId")]
    [ProtoMember(25)]
    [JsonPropertyOrder(25)]
    public string? VorgelagerteLokationsId { get; set; }

    /// <summary>
    ///Kategorie der verbrauchenden Technischen Ressource
    /// </summary>
    [JsonProperty(Required = Required.Default, Order = 26, PropertyName = "kategorie")]
    [JsonPropertyName("kategorie")]
    [ProtoMember(26)]
    [JsonPropertyOrder(26)]
    public KategorieTechnischeRessource? Kategorie { get; set; }

    /// <summary>
    ///Inbetriebsetzungsdatum der verbrauchenden Technischen Ressource nach § 14a EnWG
    /// </summary>
    [JsonProperty(Required = Required.Default, Order = 27, PropertyName = "inbetriebsetzung")]
    [JsonPropertyName("inbetriebsetzung")]
    [ProtoMember(27)]
    [JsonPropertyOrder(27)]
    public InbetriebsetzungTechnischeRessource? Inbetriebsetzung { get; set; }

    /// <summary>
    ///Einordnung der verbrauchenden Technischen Ressource nach § 14a EnWG mit Inbetriebsetzung vor 2024
    /// </summary>
    [JsonProperty(Required = Required.Default, Order = 28, PropertyName = "einordnung")]
    [JsonPropertyName("einordnung")]
    [ProtoMember(28)]
    [JsonPropertyOrder(28)]
    public EinordnungTechnischeRessource? Einordnung { get; set; }

    /// <summary>
    ///Information zu weiteren technischen Einrichtungen
    /// </summary>
    [JsonProperty(Required = Required.Default, Order = 29, PropertyName = "weitereEinrichtung")]
    [JsonPropertyName("weitereEinrichtung")]
    [ProtoMember(29)]
    [JsonPropertyOrder(29)]
    public InformationWeitereTechnischeRessource? WeitereEinrichtung { get; set; }
}
