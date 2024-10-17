using System.Collections.Generic;
using System.Text.Json.Serialization;
using BO4E.COM;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.BO;

/// <summary>
///     Modellierung einer Region als Menge von Kriterien, die eine Region beschreiben.
/// </summary>
[ProtoContract]
public class Region : BusinessObject
{
    /// <summary>
    ///     Bezeichnung der Region.
    /// </summary>
    [JsonProperty(Order = 4, PropertyName = "bezeichnung")]
    [JsonPropertyName("bezeichnung")]
    [ProtoMember(4)]
    [BoKey]
    public string Bezeichnung { get; set; }

    /// <summary>
    ///     Positivliste der Kriterien zur Definition der Region.
    /// </summary>
    [JsonProperty(Order = 5, PropertyName = "positivListe")]
    [JsonPropertyName("positivListe")]
    [ProtoMember(5)]
    public List<Regionskriterium> PositivListe { get; set; }

    /// <summary>
    ///     Negativliste der Kriterien zur Definition der Region.
    /// </summary>
    [JsonProperty(Required = Required.Default, Order = 6, PropertyName = "negativListe")]
    [JsonPropertyName("negativListe")]
    [ProtoMember(6)]
    public List<Regionskriterium>? NegativListe { get; set; }
}
