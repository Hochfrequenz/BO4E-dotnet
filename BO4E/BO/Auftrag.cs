using System;
using System.Text.Json.Serialization;
using BO4E.COM;
using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;

namespace BO4E.BO
{
    /// <summary>
    /// Ein Auftrag beschreibt einen Vorgang, der von einem anderen Marktpartner auszuführen ist. 
    /// </summary>
    [NonOfficial(NonOfficialCategory.REGULATORY_REQUIREMENTS)]
    public abstract class Auftrag : BusinessObject
    {
        /// <summary>
        /// Das Ausführungsdatum beschreibt zu welchem Zeitpunkt ein Auftrag ausgeführt werden soll.
        /// </summary>
        [JsonProperty("ausfuehrungsdatum", Required = Required.Always)]
        [JsonPropertyName("ausfuerhungsdatum")]
        public DateTimeOffset Ausfuehrungsdatum { get; set; }

        /// <summary>
        /// Die Adresse, die sich in Belieferung befindet.
        /// </summary>
        [JsonProperty("lieferanschrift", Required = Required.Default)]
        [JsonPropertyName("lieferanschrift")]
        public Adresse Lieferanschrift { get; set; }

        /// <summary>
        /// Die ID der Marktlokation der der zu sperrende Zähler zugeordnet ist.
        /// </summary>
        [JsonProperty("marktlokationsId", Required = Required.Always)]
        [JsonPropertyName("marktlokationsId")]
        public string MarktlokationsId { get; set; }

        /// <summary>
        /// Ein zusätzlicher Freitext
        /// </summary>
        [JsonProperty("bemerkung", Required = Required.Default)]
        [JsonPropertyName("bemerkung")]
        public string Bemerkung { get; set; }
    }
}