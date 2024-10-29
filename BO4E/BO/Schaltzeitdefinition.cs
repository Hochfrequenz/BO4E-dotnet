using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using BO4E.COM;
using BO4E.ENUM;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.BO;

/// <summary>
/// Eigenschaften der Schaltdefinition und einer ausgerollten Schaltzeitdefinitionen
/// </summary>
[ProtoContract]
public class Schaltzeitdefinition : BusinessObject
{
    /// <summary>
    /// Ausgerollt oder nicht ausgerollt
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
    /// Schaltzeitänderungszeitpunkt
    /// </summary>
    [JsonProperty(Required = Required.Default, Order = 2, PropertyName = "aenderungszeitpunkt")]
    [JsonPropertyName("aenderungszeitpunkt")]
    [ProtoMember(3)]
    [JsonPropertyOrder(2)]
    [ProtoIgnore]
    public DateTimeOffset Aenderungszeitpunkt { get; set; }
    
    /// <summary>
    /// Code der Schaltzeitdefinition
    /// </summary>
    [JsonProperty(Required = Required.Default, Order = 3, PropertyName = "code")]
    [JsonPropertyName("code")]
    [ProtoMember(4)]
    [JsonPropertyOrder(3)]
    public string? Code { get; set; }
    
    /// <summary>
    /// Häufigkeit der Übermittlung
    /// </summary>
    [JsonProperty(Required = Required.Default, Order = 4, PropertyName = "haeufigkeit")]
    [JsonPropertyName("haeufigkeit")]
    [ProtoMember(5)]
    [JsonPropertyOrder(4)]
    public HaeufigkeitZaehlzeit? Haeufigkeit { get; set; }
    
    /// <summary>
    /// Übermittelbarkeit der ausgerollten Schaltzeitdefinition
    /// </summary>
    [JsonProperty(PropertyName = "uebermittelbarkeit", Order = 5, Required = Required.Default)]
    [JsonPropertyName("uebermittelbarkeit")]
    [JsonPropertyOrder(6)]
    [ProtoMember(5)]
    public UebermittelbarkeitZaehlzeit? Uebermittelbarkeit { get; set; }
    
    /// <summary>
    /// Schalthandlung an der Lokation
    /// </summary>
    [JsonProperty(PropertyName = "schalthandlung", Order = 6, Required = Required.Default)]
    [JsonPropertyName("schalthandlung")]
    [JsonPropertyOrder(7)]
    [ProtoMember(6)]
    public Schalthandlung? Schalthandlung { get; set; }
}