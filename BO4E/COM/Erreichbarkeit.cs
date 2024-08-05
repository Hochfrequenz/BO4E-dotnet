using System.Text.Json.Serialization;

using Newtonsoft.Json;

using ProtoBuf;

namespace BO4E.COM;

/// <summary>
/// Die Erreichbarkeit eines Unternehmens an Werktagen.
/// </summary>
[ProtoContract]
public class Erreichbarkeit : COM
{
    /// <summary>Erreichbarkeit am Montag (Format: HHMMHHMM).</summary>
    [JsonProperty(PropertyName = "montagErreichbarkeit", Required = Required.Default, Order = 3)]
    [JsonPropertyName("montagErreichbarkeit")]
    [ProtoMember(3)]
    [JsonPropertyOrder(3)]
    public string? MontagErreichbarkeit { get; set; }

    /// <summary>Erreichbarkeit am Dienstag (Format: HHMMHHMM).</summary>
    [JsonProperty(PropertyName = "dienstagErreichbarkeit", Required = Required.Default, Order = 4)]
    [JsonPropertyName("dienstagErreichbarkeit")]
    [ProtoMember(4)]
    [JsonPropertyOrder(4)]
    public string? DienstagErreichbarkeit { get; set; }

    /// <summary>Erreichbarkeit am Mittwoch (Format: HHMMHHMM).</summary>
    [JsonProperty(PropertyName = "mittwochErreichbarkeit", Required = Required.Default, Order = 5)]
    [JsonPropertyName("mittwochErreichbarkeit")]
    [ProtoMember(5)]
    [JsonPropertyOrder(5)]
    public string? MittwochErreichbarkeit { get; set; }

    /// <summary>Erreichbarkeit am Donnerstag (Format: HHMMHHMM).</summary>
    [JsonProperty(PropertyName = "donnerstagErreichbarkeit", Required = Required.Default, Order = 6)]
    [JsonPropertyName("donnerstagErreichbarkeit")]
    [ProtoMember(6)]
    [JsonPropertyOrder(6)]
    public string? DonnerstagErreichbarkeit { get; set; }

    /// <summary>Erreichbarkeit am Freitag (Format: HHMMHHMM).</summary>
    [JsonProperty(PropertyName = "freitagErreichbarkeit", Required = Required.Default, Order = 7)]
    [JsonPropertyName("freitagErreichbarkeit")]
    [ProtoMember(7)]
    [JsonPropertyOrder(7)]
    public string? FreitagErreichbarkeit { get; set; }

    /// <summary>Mittagspause (Ausschluss der Erreichbarkeit, Format: HHMMHHMM).</summary>
    [JsonProperty(PropertyName = "mittagspause", Required = Required.Default, Order = 8)]
    [JsonPropertyName("mittagspause")]
    [ProtoMember(8)]
    [JsonPropertyOrder(8)]
    public string? Mittagspause { get; set; }
}