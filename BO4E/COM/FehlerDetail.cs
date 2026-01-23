#nullable enable
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM;

/// <summary>
///     Die Komponente wird dazu verwendet Fehler innerhalb eines Statusberichtes mit mehr Details zu versorgen
/// </summary>
[ProtoContract]
public class FehlerDetail : COM
{
    /// <summary>Gibt den Code des Fehlers an.</summary>
    [JsonProperty(PropertyName = "code", Order = 10)]
    [JsonPropertyName("code")]
    [JsonPropertyOrder(10)]
    [ProtoMember(1)]
    public BO4E.ENUM.FehlerCode? Code { get; set; }

    /// <summary>Eine Beschreibung des Fehlers.</summary>
    [JsonProperty(PropertyName = "beschreibung", Order = 11)]
    [JsonPropertyName("beschreibung")]
    [JsonPropertyOrder(11)]
    [ProtoMember(2)]
    public string? Beschreibung { get; set; }

    /// <summary>
    ///     Herkunft / Ursache des Fehlers
    /// </summary>
    [JsonProperty(PropertyName = "ursache", Order = 12)]
    [JsonPropertyName("ursache")]
    [JsonPropertyOrder(12)]
    [ProtoMember(3)]
    public FehlerUrsache? Ursache { get; set; }
}
