using System.Text.Json.Serialization;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.BO
{
    /// <summary>
    /// Ein AuftragsStorno beschreibt die Stornierung eines <see cref="Auftrag"/>s. 
    /// </summary>
    [NonOfficial(NonOfficialCategory.REGULATORY_REQUIREMENTS)]
    [ProtoContract]
    public abstract class AuftragsStorno : BusinessObject
    {
        /// <summary>
        /// Eindeutige Kennung des zu stornierenden <see cref="Auftrag"/>s
        /// </summary>
        [JsonProperty("auftragsId", Required = Required.Always)]
        [JsonPropertyName("auftragsId")]
        public string AuftragsId { get; set; }
    }
}