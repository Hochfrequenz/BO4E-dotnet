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
/// Eigenschaften einer (nicht) ausgerollten Leistungskurvendefinition
/// </summary>
[ProtoContract]
public class Leistungskurvendefinition : BusinessObject
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
    /// Leistungskurvenänderungszeitpunkt
    /// </summary>
    [JsonProperty(Required = Required.Default, Order = 12, PropertyName = "aenderungszeitpunkt")]
    [JsonPropertyName("aenderungszeitpunkt")]
    [ProtoMember(12)]
    [JsonPropertyOrder(12)]
    [ProtoIgnore]
    public DateTimeOffset Aenderungszeitpunkt { get; set; }

    /// <summary>
    /// Code der Leistungskurvendefinition
    /// </summary>
    [BoKey]
    [JsonProperty(
        Required = Required.Default,
        Order = 13,
        PropertyName = "leistungskurvendefinitionscode"
    )]
    [JsonPropertyName("leistungskurvendefinitionscode")]
    [ProtoMember(13)]
    [JsonPropertyOrder(13)]
    public string? LeistungskurvendefinitionsCode { get; set; }

    /// <summary>
    /// Häufigkeit der Übermittlung
    /// </summary>
    [JsonProperty(Required = Required.Default, Order = 14, PropertyName = "haeufigkeit")]
    [JsonPropertyName("haeufigkeit")]
    [ProtoMember(14)]
    [JsonPropertyOrder(14)]
    public HaeufigkeitZaehlzeit? Haeufigkeit { get; set; }

    /// <summary>
    /// Übermittelbarkeit der ausgerollten Leistungskurvendefinition
    /// </summary>
    [JsonProperty(PropertyName = "uebermittelbarkeit", Order = 15, Required = Required.Default)]
    [JsonPropertyName("uebermittelbarkeit")]
    [ProtoMember(15)]
    [JsonPropertyOrder(15)]
    public UebermittelbarkeitZaehlzeit? Uebermittelbarkeit { get; set; }

    /// <summary>
    /// oberer Schwellwert
    /// </summary>
    [JsonProperty(Required = Required.Default, Order = 16, PropertyName = "obererSchwellwert")]
    [JsonPropertyName("obererSchwellwert")]
    [ProtoMember(16)]
    [JsonPropertyOrder(16)]
    public string? ObererSchwellwert { get; set; }

    /// <summary>
    /// EDIFACT-Datumsformat des Änderungszeitpunkts (z.B. "401").
    /// </summary>
    [JsonProperty(
        PropertyName = "aenderungszeitpunktDateFormat",
        Order = 17,
        Required = Required.Default
    )]
    [JsonPropertyName("aenderungszeitpunktDateFormat")]
    [ProtoMember(17)]
    [JsonPropertyOrder(17)]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    public string? AenderungszeitpunktDateFormat { get; set; }
}
