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
        [JsonProperty(Required = Required.Always, Order = 10, PropertyName = "technischeRessourceId")]
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
        [JsonProperty(PropertyName = "vorgelagerteMesslokationsId", Required = Required.Always, Order = 10)]
        [JsonPropertyName("vorgelagerteMesslokationsId")]
        [JsonPropertyOrder(10)]
        [DataCategory(DataCategory.POD)]
        [ProtoMember(4)]
        public string? VorgelagerteMesslokationsId { get; set; }

        /// <summary>
        /// Referenz auf die der Technischen Ressource Zugeordneten Marktlokation
        /// Beispiel:
        /// RFF+Z16:20072281644'
        /// </summary>
        [JsonProperty(PropertyName = "zugeordneteMarktlokationsId", Required = Required.Always, Order = 10)]
        [JsonPropertyName("zugeordneteMarktlokationsId")]
        [JsonPropertyOrder(10)]
        [DataCategory(DataCategory.POD)]
        [ProtoMember(4)]
        public string? ZugeordneteMarktlokationsId { get; set; }

        /// <summary>
        /// Referenz auf die der Technischen Ressource zugeordneten Steuerbaren Ressource
        /// Beispiel:
        /// RFF+Z16:20072281644'
        /// </summary>
        [JsonProperty(PropertyName = "zugeordneteSteuerbareRessourceId", Required = Required.Always, Order = 10)]
        [JsonPropertyName("zugeordneteSteuerbareRessourceId")]
        [JsonPropertyOrder(10)]
        [DataCategory(DataCategory.POD)]
        [ProtoMember(4)]
        public string? ZugeordneteSteuerbareRessourceId { get; set; }

        /// <summary>
        /// Nennleistung (Aufnahme)
        /// Beispiel: QTY+Z43:100:KWT'
        /// </summary>
        [JsonProperty(PropertyName = "nennleistungAufnahme", Required = Required.Default, Order = 17)]
        [JsonPropertyName("nennleistungAufnahme")]
        [JsonPropertyOrder(17)]
        [NonOfficial(NonOfficialCategory.MISSING)]
        [ProtoMember(1006)]
        public Menge? NennleistungAufnahme { get; set; }

        /// <summary>
        /// Nennleistung (Abgabe)
        /// Beispiel: QTY+Z44:100:KWT'
        /// </summary>
        [JsonProperty(PropertyName = "nennleistungAbgabe", Required = Required.Default, Order = 17)]
        [JsonPropertyName("nennleistungAbgabe")]
        [JsonPropertyOrder(17)]
        [NonOfficial(NonOfficialCategory.MISSING)]
        [ProtoMember(1006)]
        public Menge? NennleistungAbgabe { get; set; }

        /// <summary>
        /// Speicherkapazität
        /// Beispiel: QTY+Z42:100:KWH'
        /// </summary>
        [JsonProperty(PropertyName = "speicherkapazitaet", Required = Required.Default, Order = 17)]
        [JsonPropertyName("speicherkapazitaet")]
        [JsonPropertyOrder(17)]
        [NonOfficial(NonOfficialCategory.MISSING)]
        [ProtoMember(1006)]
        public Menge? Speicherkapazitaet { get; set; }

        /// <summary>
        /// Art und Nutzung der Technischen Ressource
        /// Beispiel: CCI+Z17'
        /// </summary>
        [JsonProperty(PropertyName = "technischeRessourceNutzung", Required = Required.Default, Order = 17)]
        [JsonPropertyName("technischeRessourceNutzung")]
        [JsonPropertyOrder(17)]
        [NonOfficial(NonOfficialCategory.MISSING)]
        [ProtoMember(1006)]
        public TechnischeRessourceNutzung? TechnischeRessourceNutzung { get; set; }

        /// <summary>
        /// Verbrauchsart der Technischen Ressource
        /// Beispiel: CAV+Z64'
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 14, PropertyName = "verbrauchsart")]
        [JsonPropertyOrder(14)]
        [JsonPropertyName("verbrauchsart")]
        [ProtoMember(8)]
        public TechnischeRessourceVerbrauchsart? Verbrauchsart { get; set; }

        /// <summary>
        /// Wärmenutzung
        /// Beispiel: CAV+Z56'
        /// </summary>
        [JsonProperty(PropertyName = "waermenutzung", Order = 1014, Required = Required.Default)]
        [JsonPropertyName("waermenutzung")]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1014)]
        [JsonPropertyOrder(1014)]
        public Waermenutzung? Waermenutzung { get; set; }
    }
}
