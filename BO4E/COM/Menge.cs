using System.Text.Json.Serialization;
using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM;

/// <summary>Abbildung einer Menge mit Wert und Einheit.</summary>
[ProtoContract]
public class Menge : COM
{
    /// <summary>Gibt den absoluten Wert der Menge an.</summary>
    [JsonProperty(PropertyName = "wert", Required = Required.Always, Order = 10)]
    [JsonPropertyName("wert")]
    [FieldName("value", Language.EN)]
    [JsonPropertyOrder(10)]
    [ProtoMember(3)]
    public decimal Wert { get; set; }

    /// <summary>Gibt die Einheit zum jeweiligen Wert an. Details <see cref="Mengeneinheit" /></summary>
    [JsonProperty(PropertyName = "einheit", Required = Required.Default, Order = 11)]
    [JsonPropertyName("einheit")]
    [FieldName("unit", Language.EN)]
    [JsonPropertyOrder(11)]
    [ProtoMember(4)]
    public Mengeneinheit? Einheit { get; set; }
}
