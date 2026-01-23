using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using BO4E.COM;
using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.BO;

/// <summary>
/// Eigenschaften einer (nicht) ausgerollten Schaltzeitdefinition
/// </summary>
[ProtoContract]
public class Schaltzeitdefinition : BusinessObject
{
    /// <summary>
    /// Ausgerollt oder nicht ausgerollt
    /// </summary>
    [JsonProperty(Required = Required.Default, Order = 10, PropertyName = "ausgerollt")]
    [JsonPropertyName("ausgerollt")]
    [ProtoMember(10)]
    [JsonPropertyOrder(10)]
    public bool? Ausgerollt { get; set; }

    [Newtonsoft.Json.JsonIgnore]
    [System.Text.Json.Serialization.JsonIgnore]
    [ProtoMember(11, Name = nameof(Aenderungszeitpunkt))]
    [CompatibilityLevel(CompatibilityLevel.Level240)]
    private DateTime _Aenderungszeitpunkt
    {
        get => Aenderungszeitpunkt.UtcDateTime;
        set => Aenderungszeitpunkt = DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }

    /// <summary>
    /// Schaltzeitänderungszeitpunkt
    /// </summary>
    [JsonProperty(Required = Required.Default, Order = 12, PropertyName = "aenderungszeitpunkt")]
    [JsonPropertyName("aenderungszeitpunkt")]
    [ProtoMember(12)]
    [JsonPropertyOrder(12)]
    [ProtoIgnore]
    public DateTimeOffset Aenderungszeitpunkt { get; set; }

    /// <summary>
    /// Code der Schaltzeitdefinition
    /// </summary>
    [BoKey]
    [JsonProperty(
        Required = Required.Default,
        Order = 13,
        PropertyName = "schaltzeitdefinitionscode"
    )]
    [JsonPropertyName("schaltzeitdefinitionscode")]
    [ProtoMember(13)]
    [JsonPropertyOrder(13)]
    public string? SchaltzeitdefinitionsCode { get; set; }

    /// <summary>
    /// Häufigkeit der Übermittlung
    /// </summary>
    [JsonProperty(Required = Required.Default, Order = 14, PropertyName = "haeufigkeit")]
    [JsonPropertyName("haeufigkeit")]
    [ProtoMember(14)]
    [JsonPropertyOrder(14)]
    public HaeufigkeitZaehlzeit? Haeufigkeit { get; set; }

    /// <summary>
    /// Übermittelbarkeit der ausgerollten Schaltzeitdefinition
    /// </summary>
    [JsonProperty(PropertyName = "uebermittelbarkeit", Order = 15, Required = Required.Default)]
    [JsonPropertyName("uebermittelbarkeit")]
    [ProtoMember(15)]
    [JsonPropertyOrder(15)]
    public UebermittelbarkeitZaehlzeit? Uebermittelbarkeit { get; set; }

    /// <summary>
    /// Schalthandlung an der Lokation
    /// </summary>
    [JsonProperty(PropertyName = "schalthandlung", Order = 16, Required = Required.Default)]
    [JsonPropertyName("schalthandlung")]
    [ProtoMember(16)]
    [JsonPropertyOrder(16)]
    public Schalthandlung? Schalthandlung { get; set; }
}
