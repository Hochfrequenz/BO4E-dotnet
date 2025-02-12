using System.Text.Json.Serialization;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM;

/// <summary>
///     Die Komponente wird dazu verwendet die Ursache bzw. Herkunft von Fehlern genauer zu spezifizieren
/// </summary>
[ProtoContract]
public class FehlerUrsache : COM
{
    /// <summary>Das Dokument (im EDIFACT das UNB-Segment).</summary>
    [JsonProperty(PropertyName = "dokument")]
    [JsonPropertyName("dokument")]
    [ProtoMember(1)]
    public string? Dokument { get; set; }

    /// <summary>Die Nachricht (im EDIFACT das UNH-Segment).</summary>
    [JsonProperty(PropertyName = "nachricht")]
    [JsonPropertyName("nachricht")]
    [ProtoMember(2)]
    public string? Nachricht { get; set; }

    /// <summary>Die Transaktion (im EDIFACT das BGM/IDE-Segment).</summary>
    [JsonProperty(PropertyName = "transaktion")]
    [JsonPropertyName("transaktion")]
    [ProtoMember(3)]
    public string? Transaktion { get; set; }

    /// <summary>Die Gruppe (im EDIFACT Segment-Gruppe).</summary>
    [JsonProperty(PropertyName = "gruppe")]
    [JsonPropertyName("gruppe")]
    [ProtoMember(4)]
    public string? Gruppe { get; set; }

    /// <summary>Das Segment (im EDIFACT Segment).</summary>
    [JsonProperty(PropertyName = "segment")]
    [JsonPropertyName("segment")]
    [ProtoMember(5)]
    public string? Segment { get; set; }

    /// <summary>Zusätzliche Fehlerbeschreibung.</summary>
    [JsonProperty(PropertyName = "beschreibung")]
    [JsonPropertyName("beschreibung")]
    [ProtoMember(5)]
    public string? Beschreibung { get; set; }
}
