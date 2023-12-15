using System.ComponentModel;
using System.Text.Json.Serialization;

using BO4E.COM;
using BO4E.ENUM;
using BO4E.meta;

using Newtonsoft.Json;

using ProtoBuf;

namespace BO4E.BO
{
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
        [JsonProperty(PropertyName = "technischeRessourceId", Required = Required.Always, Order = 1)]
        [JsonPropertyName("technischeRessourceId")]
        [JsonPropertyOrder(1)]
        [DataCategory(DataCategory.DEVICE)]
        [BoKey]
        [ProtoMember(1)]
        public string? TechnischeRessourceId { get; set; }

        /// <summary>
        /// Vorgelagerte Messlokation ID
        /// Beispiel:
        /// RFF+Z34:DE00713739359S0000000000001222221'
        /// </summary>
        [JsonProperty(PropertyName = "vorgelagerteMesslokationsId", Required = Required.Always, Order = 2)]
        [JsonPropertyName("vorgelagerteMesslokationsId")]
        [JsonPropertyOrder(2)]
        [DataCategory(DataCategory.POD)]
        [ProtoMember(2)]
        public string? VorgelagerteMesslokationsId { get; set; }

        /// <summary>
        /// Referenz auf die der Technischen Ressource Zugeordneten Marktlokation
        /// Beispiel:
        /// RFF+Z16:20072281644'
        /// </summary>
        [JsonProperty(PropertyName = "zugeordneteMarktlokationsId", Required = Required.Always, Order = 3)]
        [JsonPropertyName("zugeordneteMarktlokationsId")]
        [JsonPropertyOrder(3)]
        [DataCategory(DataCategory.POD)]
        [ProtoMember(3)]
        public string? ZugeordneteMarktlokationsId { get; set; }

        /// <summary>
        /// Referenz auf die der Technischen Ressource zugeordneten Steuerbaren Ressource
        /// Beispiel:
        /// RFF+Z16:20072281644'
        /// </summary>
        [JsonProperty(PropertyName = "zugeordneteSteuerbareRessourceId", Required = Required.Always, Order = 4)]
        [JsonPropertyName("zugeordneteSteuerbareRessourceId")]
        [JsonPropertyOrder(4)]
        [DataCategory(DataCategory.POD)]
        [ProtoMember(4)]
        public string? ZugeordneteSteuerbareRessourceId { get; set; }

        /// <summary>
        /// Nennleistung (Aufnahme)
        /// Beispiel: QTY+Z43:100:KWT'
        /// </summary>
        [JsonProperty(PropertyName = "nennleistungAufnahme", Required = Required.Default, Order = 5)]
        [JsonPropertyName("nennleistungAufnahme")]
        [JsonPropertyOrder(5)]
        [NonOfficial(NonOfficialCategory.MISSING)]
        [ProtoMember(5)]
        public Menge? NennleistungAufnahme { get; set; }

        /// <summary>
        /// Nennleistung (Abgabe)
        /// Beispiel: QTY+Z44:100:KWT'
        /// </summary>
        [JsonProperty(PropertyName = "nennleistungAbgabe", Required = Required.Default, Order = 6)]
        [JsonPropertyName("nennleistungAbgabe")]
        [JsonPropertyOrder(6)]
        [NonOfficial(NonOfficialCategory.MISSING)]
        [ProtoMember(6)]
        public Menge? NennleistungAbgabe { get; set; }

        /// <summary>
        /// Speicherkapazität
        /// Beispiel: QTY+Z42:100:KWH'
        /// </summary>
        [JsonProperty(PropertyName = "speicherkapazitaet", Required = Required.Default, Order = 7)]
        [JsonPropertyName("speicherkapazitaet")]
        [JsonPropertyOrder(7)]
        [NonOfficial(NonOfficialCategory.MISSING)]
        [ProtoMember(7)]
        public Menge? Speicherkapazitaet { get; set; }

        /// <summary>
        /// Art und Nutzung der Technischen Ressource
        /// Beispiel: CCI+Z17'
        ///     Z17: Stromverbrauchsart
        ///     Z50: Stromerzeugungsart
        ///     Z56: Speicher
        /// </summary>
        [JsonProperty(PropertyName = "technischeRessourceNutzung", Required = Required.Default, Order = 8)]
        [JsonPropertyName("technischeRessourceNutzung")]
        [JsonPropertyOrder(8)]
        [NonOfficial(NonOfficialCategory.MISSING)]
        [ProtoMember(8)]
        public TechnischeRessourceNutzung? TechnischeRessourceNutzung { get; set; }

        /// <summary>
        /// Verbrauchsart der Technischen Ressource
        /// Beispiel: CAV+Z64'
        ///     Z64: Kraft/Licht
        ///     Z65: Wärme
        ///     ZE5: E-Mobilität
        ///     ZA8: Straßenbeleuchtung
        /// </summary>
        [JsonProperty(PropertyName = "verbrauchsart", Required = Required.Default, Order = 9)]
        [JsonPropertyOrder(9)]
        [JsonPropertyName("verbrauchsart")]
        [NonOfficial(NonOfficialCategory.MISSING)]
        [ProtoMember(9)]
        public TechnischeRessourceVerbrauchsart? Verbrauchsart { get; set; }

        /// <summary>
        /// Wärmenutzung
        /// Beispiel: CAV+Z56'
        ///     Z56: Speicherheizung
        ///     Z57: Wärmepumpe
        ///     Z61: Direktheizung
        /// </summary>
        [JsonProperty(PropertyName = "waermenutzung", Required = Required.Default, Order = 10)]
        [JsonPropertyOrder(10)]
        [JsonPropertyName("waermenutzung")]
        [NonOfficial(NonOfficialCategory.MISSING)]
        [ProtoMember(10)]
        public Waermenutzung? Waermenutzung { get; set; }

        /// <summary>
        /// Art der E-Mobilität
        /// Das Segment dient dazu, im Falle der E-Mobilität eine genauere Angabe über die Art der E-Mobilität zu definieren.
        /// Beispiel: CAV+Z87'
        ///     ZE6: Wallbox: An der Marktlokation ist eine nicht öffentlliche Lademöglichkeit vorhanden
        ///     Z87: E-Mobilitätsladesäule: Es handelt sich um eine öffentliche Ladesäule mit ggf. mehreren Ladeanschlüssen an der Marktlokation.
        ///     ZE7: Ladepark: Es handelt sich um mehr als eine öffentliche Ladesäule an der Marktlokation
        /// </summary>
        [JsonProperty(PropertyName = "emobilitaetsart", Required = Required.Default, Order = 11)]
        [JsonPropertyOrder(11)]
        [JsonPropertyName("emobilitaetsart")]
        [NonOfficial(NonOfficialCategory.MISSING)]
        [ProtoMember(11)]
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
        [JsonProperty(PropertyName = "erzeugungsart", Required = Required.Always, Order = 12)]
        [JsonPropertyOrder(12)]
        [JsonPropertyName("erzeugungsart")]
        [NonOfficial(NonOfficialCategory.MISSING)]
        [ProtoMember(12)]
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
        [JsonProperty(PropertyName = "speicherart", Required = Required.Always, Order = 13)]
        [JsonPropertyOrder(13)]
        [JsonPropertyName("speicherart")]
        [NonOfficial(NonOfficialCategory.MISSING)]
        [ProtoMember(13)]
        public Speicherart? Speicherart { get; set; }
    }
}
