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
    /// <summary>Erreichbarkeit am Montag</summary>
    [JsonProperty(PropertyName = "montagErreichbarkeit", Required = Required.Default, Order = 3)]
    [JsonPropertyName("montagErreichbarkeit")]
    [ProtoMember(3)]
    [JsonPropertyOrder(3)]
    public Zeitfenster? MontagErreichbarkeit { get; set; }

    /// <summary>Erreichbarkeit am Dienstag</summary>
    [JsonProperty(PropertyName = "dienstagErreichbarkeit", Required = Required.Default, Order = 4)]
    [JsonPropertyName("dienstagErreichbarkeit")]
    [ProtoMember(4)]
    [JsonPropertyOrder(4)]
    public Zeitfenster? DienstagErreichbarkeit { get; set; }

    /// <summary>Erreichbarkeit am Mittwoch</summary>
    [JsonProperty(PropertyName = "mittwochErreichbarkeit", Required = Required.Default, Order = 5)]
    [JsonPropertyName("mittwochErreichbarkeit")]
    [ProtoMember(5)]
    [JsonPropertyOrder(5)]
    public Zeitfenster? MittwochErreichbarkeit { get; set; }

    /// <summary>Erreichbarkeit am Donnerstag</summary>
    [JsonProperty(
        PropertyName = "donnerstagErreichbarkeit",
        Required = Required.Default,
        Order = 6
    )]
    [JsonPropertyName("donnerstagErreichbarkeit")]
    [ProtoMember(6)]
    [JsonPropertyOrder(6)]
    public Zeitfenster? DonnerstagErreichbarkeit { get; set; }

    /// <summary>Erreichbarkeit am Freitag</summary>
    [JsonProperty(PropertyName = "freitagErreichbarkeit", Required = Required.Default, Order = 7)]
    [JsonPropertyName("freitagErreichbarkeit")]
    [ProtoMember(7)]
    [JsonPropertyOrder(7)]
    public Zeitfenster? FreitagErreichbarkeit { get; set; }

    /// <summary>Mittagspause (Ausschluss der Erreichbarkeit)</summary>
    [JsonProperty(PropertyName = "mittagspause", Required = Required.Default, Order = 8)]
    [JsonPropertyName("mittagspause")]
    [ProtoMember(8)]
    [JsonPropertyOrder(8)]
    public Zeitfenster? Mittagspause { get; set; }
}
