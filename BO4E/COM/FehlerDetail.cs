using System.Text.Json.Serialization;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>
    ///     Die Komponente wird dazu verwendet Fehler innerhalb eines Statusberichtes mit mehr Details zu versorgen
    /// </summary>
    [ProtoContract]
    public class FehlerDetail : COM
    {
        /// <summary>Gibt den Code des Fehlers an.</summary>
        [JsonProperty(PropertyName = "code", Required = Required.Always)]
        [JsonPropertyName("code")]
        [ProtoMember(1)]
        public BO4E.ENUM.FehlerCode Code { get; set; }

        /// <summary>Eine Beschreibung des Fehlers.</summary>
        [JsonProperty(PropertyName = "beschreibung", Required = Required.Default)]
        [JsonPropertyName("beschreibung")]
        [ProtoMember(2)]
        public string? Beschreibung { get; set; }

        /// <summary>
        ///     Herkunft / Ursache des Fehlers
        /// </summary>
        [JsonProperty(PropertyName = "ursache", Required = Required.Default)]
        [JsonPropertyName("ursache")]
        [ProtoMember(3)]
        public FehlerUrsache? Ursache { get; set; }
    }
}