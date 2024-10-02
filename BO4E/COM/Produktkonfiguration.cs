using System.Text.Json.Serialization;
using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM;

/// <summary>Einzelne Produktkonfiguration in einem Produktpaket.</summary>
[ProtoContract]
public class Produktkonfiguration : COM
{
    /// <summary>Eindeutiger Code der Konfiguration</summary>
    [JsonProperty(PropertyName = "code", Order = 3, Required = Required.Default)]
    [JsonPropertyName("code")]
    [ProtoMember(3)]
    [JsonPropertyOrder(3)]
    public Produktcode? Code { get; set; }

    /// <summary>Eigenschaftswert zur Konfiguration (als Code)</summary>
    [JsonProperty(PropertyName = "eigenschaft", Order = 4, Required = Required.Default)]
    [JsonPropertyName("eigenschaft")]
    [ProtoMember(4)]
    [JsonPropertyOrder(4)]
    public Produktcode? Eigenschaft { get; set; }

    /// <summary>Zusätzlicher Eigenschaftswert</summary>
    [JsonProperty(PropertyName = "zusatzeigenschaft", Order = 5, Required = Required.Default)]
    [JsonPropertyName("zusatzeigenschaft")]
    [ProtoMember(5)]
    [JsonPropertyOrder(5)]
    public string? Zusatzeigenschaft { get; set; }
}
