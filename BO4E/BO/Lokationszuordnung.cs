using System.Text.Json.Serialization;
using BO4E.COM;
using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.BO
{
    /// <summary>
    /// Modell für die Abbildung der Referenz auf die Lokationsbündelstruktur. Diese gibt an welche Marktlokationen,
    /// Messlokationen, Netzlokationen, technische/steuerbaren Ressourcen an einer Lokation vorhanden sind;
    /// </summary>
    [ProtoContract]

    public class Lokationszuordnung : BusinessObject
    {

        /// <summary>
        /// Liste mit IDs der referenzierten Marktlokationen
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 11, PropertyName = "marktlokationen")]
        [JsonPropertyName("marktlokationen")]
        [JsonPropertyOrder(11)]
        [ProtoMember(11)]
        public Marktlokation[]? Marktlokationen { get; set; }

        /// <summary>
        /// Liste mit IDs der referenzierten Messlokationen
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 12, PropertyName = "messlokationen")]
        [JsonPropertyName("messlokationen")]
        [JsonPropertyOrder(12)]
        [ProtoMember(12)]
        public Messlokation[]? Messlokationen { get; set; }

        /// <summary>
        /// Liste mit IDs der referenzierten Netzlokationen
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 13, PropertyName = "netzlokationen")]
        [JsonPropertyName("netzlokationen")]
        [JsonPropertyOrder(13)]
        [ProtoMember(13)]
        public Netzlokation[]? Netzlokationen { get; set; }

        /// <summary>
        /// Liste mit IDs der referenzierten technischen Ressourcen
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 14, PropertyName = "technischeRessourcen")]
        [JsonPropertyName("technischeRessourcen")]
        [JsonPropertyOrder(14)]
        [ProtoMember(14)]
        public TechnischeRessource[]? TechnischeRessourcen { get; set; }

        /// <summary>
        /// Liste mit IDs der referenzierten steuerbaren Ressourcen
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 15, PropertyName = "steuerbareRessourcen")]
        [JsonPropertyName("steuerbareRessourcen")]
        [JsonPropertyOrder(15)]
        [ProtoMember(15)]
        public SteuerbareRessource[]? SteuerebareRessourcen { get; set; }

        /// <summary>
        /// Zeitspanne der Gültigkeit
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 16, PropertyName = "gueltigkeit")]
        [JsonPropertyName("gueltigkeit")]
        [JsonPropertyOrder(16)]
        [ProtoMember(16)]
        // Instead of COM.Zeitspanne (bo4e-python)
        public Zeitraum[]? Gueltigkeit { get; set; }
        

        /// <summary>
        /// Verknüpfungsrichtung z.B. Malo-Melo
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 17, PropertyName = "zuordnungstyp")]
        [JsonPropertyName("zuordnungstyp")]
        [JsonPropertyOrder(17)]
        [ProtoMember(17)]
        public string? Zuordnungstyp { get; set; }
        
        /// <summary>
        /// Code, der angibt wie die Lokationsbündelstruktur zusammengesetzt ist (zu finden unter "Codeliste der Lokationsbündelstrukturen" auf https://www.edi-energy.de/index.php?id=38)
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 18, PropertyName = "lokationsbuendelcode")]
        [JsonPropertyName("lokationsbuendelcode")]
        [JsonPropertyOrder(18)]
        [ProtoMember(18)]
        [BoKey]
        public string? LokationsbuendelCode { get; set; }

    }
}