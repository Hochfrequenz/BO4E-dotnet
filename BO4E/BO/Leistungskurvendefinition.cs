using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using BO4E.COM;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.BO;

/// <summary>
/// </summary>
[ProtoContract]
public class Leistungskurvendefinition : BusinessObject
{
    /// <summary>
    /// </summary>
    [JsonProperty(Required = Required.Default, Order = 1, PropertyName = "ausgerollt")]
    [JsonPropertyName("ausgerollt")]
    [ProtoMember(1)]
    [JsonPropertyOrder(1)]
    public bool? Ausgerollt { get; set; }
    
    
    [Newtonsoft.Json.JsonIgnore]
    [System.Text.Json.Serialization.JsonIgnore]
    [ProtoMember(2, Name = nameof(Aenderungszeitpunkt))]
    [CompatibilityLevel(CompatibilityLevel.Level240)]
    private DateTime _Aenderungszeitpunkt
    {
        get => Aenderungszeitpunkt.UtcDateTime;
        set => Aenderungszeitpunkt = DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }
    
    /// <summary>
    /// </summary>
    [JsonProperty(Required = Required.Default, Order = 2, PropertyName = "aenderungszeitpunkt")]
    [JsonPropertyName("aenderungszeitpunkt")]
    [ProtoMember(3)]
    [JsonPropertyOrder(2)]
    [ProtoIgnore]
    public DateTimeOffset Aenderungszeitpunkt { get; set; }

    /// <summary>
    /// </summary>
    [JsonProperty(Required = Required.Default, Order = 3, PropertyName = "leistungskurven")]
    [JsonPropertyName("leistungskurven")]
    [ProtoMember(4)]
    [JsonPropertyOrder(3)]
    public List<Schaltzeit>? Leistungskurven { get; set; }
    
    /// <summary>
    /// </summary>
    [JsonProperty(Required = Required.Default, Order = 4, PropertyName = "obererSchwellwert")]
    [JsonPropertyName("obererSchwellwert")]
    [ProtoMember(5)]
    [JsonPropertyOrder(4)]
    public string? ObererSchwellwert { get; set; }
}