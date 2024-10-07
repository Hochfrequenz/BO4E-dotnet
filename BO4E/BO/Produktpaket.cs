using System.Collections.Generic;
using System.Text.Json.Serialization;
using BO4E.COM;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.BO;

/// <summary>
///     Sammlung von Produktkonfigurationen im Rahmen der Marktkommunikation.
/// </summary>
[ProtoContract]
public class Produktpaket : BusinessObject
{
    /// <summary>
    ///     Paket-Identifikation (Durchnummerierung).
    /// </summary>
    [JsonProperty(Required = Required.Always, Order = 8, PropertyName = "paketId")]
    [JsonPropertyName("paketId")]
    [ProtoMember(8)]
    [JsonPropertyOrder(8)]
    [BoKey]
    public int PaketId { get; set; }

    /// <summary>
    ///     Liste an Produktkonfigurationen
    /// </summary>
    [JsonProperty(Required = Required.Default, Order = 9, PropertyName = "konfigurationen")]
    [JsonPropertyName("konfigurationen")]
    [ProtoMember(9)]
    [JsonPropertyOrder(9)]
    public List<Produktkonfiguration>? Konfigurationen { get; set; }

    /// <summary>
    ///     Prioritaet des Pakets (1-5, 1 ist die hoechste Prioritaet)
    /// </summary>
    [JsonProperty(Required = Required.Default, Order = 10, PropertyName = "prioritaet")]
    [JsonPropertyName("prioritaet")]
    [ProtoMember(10)]
    [JsonPropertyOrder(10)]
    public int? Prioritaet { get; set; }

    /// <summary>
    ///     Muss das Paket vollstaendig umgesetzt werden?
    /// </summary>
    [JsonProperty(Required = Required.Default, Order = 11, PropertyName = "mussVollstaendigSein")]
    [JsonPropertyName("mussVollstaendigSein")]
    [ProtoMember(11)]
    [JsonPropertyOrder(11)]
    public bool? MussVollstaendigSein { get; set; }
}
