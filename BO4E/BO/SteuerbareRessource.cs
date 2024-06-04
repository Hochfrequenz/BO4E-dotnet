using System.Collections.Generic;
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
    /// Steuerbare Ressource BO
    /// </summary>
    [ProtoContract]
    [NonOfficial(NonOfficialCategory.MISSING)]
    public class SteuerbareRessource : BusinessObject
    {
        /// <summary>
        /// Identifikationsnummer einer SteuerbareRessource
        /// </summary>
        /// <remarks>Edi-beispiel: LOC+Z19+C816417ST77'</remarks>
        [DefaultValue("|null|")]
        [JsonProperty(
            Required = Required.Always,
            Order = 10,
            PropertyName = "steuerbareRessourceId"
        )]
        [JsonPropertyName("steuerbareRessourceId")]
        [JsonPropertyOrder(10)]
        [DataCategory(DataCategory.DEVICE)]
        [BoKey]
        [ProtoMember(10)]
        public string SteuerbareRessourceId { get; set; }

        /// <summary>
        /// Leistungsbeschreibung des Steuerkanals
        /// </summary>
        /// <remarks>Edi-beispiel: CAV+ZF2:Z14'</remarks>
        [JsonProperty(
            Required = Required.Default,
            Order = 11,
            PropertyName = "steuerkanalsLeistungsbeschreibung"
        )]
        [JsonPropertyName("steuerkanalsLeistungsbeschreibung")]
        [JsonPropertyOrder(11)]
        [NonOfficial(NonOfficialCategory.MISSING)]
        [ProtoMember(11)]
        public SteuerkanalsLeistungsbeschreibung? SteuerkanalsLeistungsbeschreibung { get; set; }

        /// <summary>
        /// Angabe des Messstellenbetreibers, der der Steuerbaren Ressource zugeordnet ist.
        /// </summary>
        /// <remarks>Edi-beispiel: CAV+Z91:9900000000002'</remarks>
        [JsonProperty(
            Required = Required.Default,
            Order = 12,
            PropertyName = "zugeordnetMSBCodeNr"
        )]
        [JsonPropertyOrder(12)]
        [JsonPropertyName("zugeordnetMSBCodeNr")]
        [ProtoMember(12)]
        public string? ZugeordnetMSBCodeNr { get; set; }

        /// <summary>
        /// Produkt-Daten der Steuerbaren Ressource
        /// </summary>
        [JsonProperty(
            Required = Required.Default,
            Order = 13,
            PropertyName = "konfigurationsprodukte"
        )]
        [JsonPropertyName("konfigurationsprodukte")]
        [ProtoMember(13)]
        [JsonPropertyOrder(13)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        public List<Konfigurationsprodukt>? Konfigurationsprodukte { get; set; }

        /// <summary>
        /// Eigenschaft des Messstellenbetreiber an der Lokation
        /// </summary>
        [JsonProperty(
            Required = Required.Default,
            Order = 14,
            PropertyName = "eigenschaftMSBLokation"
        )]
        [JsonPropertyName("eigenschaftMSBLokation")]
        [ProtoMember(14)]
        [JsonPropertyOrder(14)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        public ENUM.Marktrolle? EigenschaftMSBLokation { get; set; }

        /// <summary>
        /// Lokationszuordnung, um bspw. die zugehörigen Messlokationen anzugeben
        /// </summary>
        [JsonProperty(
            Required = Required.Default,
            Order = 15,
            PropertyName = "lokationszuordnungen"
        )]
        [JsonPropertyName("lokationszuordnungen")]
        [ProtoMember(15)]
        [JsonPropertyOrder(15)]
        public Lokationszuordnung[]? Lokationszuordnungen { get; set; }

        /// <summary>
        /// Lokationsbuendel Code, der die Funktion dieses BOs an der Lokationsbuendelstruktur beschreibt.
        /// </summary>
        [JsonProperty(
            Required = Required.Default,
            Order = 16,
            PropertyName = "lokationsbuendelObjektcode"
        )]
        [JsonPropertyName("lokationsbuendelObjektcode")]
        [ProtoMember(16)]
        [JsonPropertyOrder(16)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        public string? LokationsbuendelObjektcode { get; set; }
    }
}
