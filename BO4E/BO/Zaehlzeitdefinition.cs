#nullable enable
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
/// Der NB bzw. LF nutzt Zählzeitdefinitionen für die Tarifierung von Werten.
/// <remarks>Zaehlzeitdefinitionen werden in der Marktkommunikation mit Prüfidentifikator 25001 (UTILTS) übermittelt</remarks>
/// Eine Zählzeitdefinition umfasst dabei eine Liste von möglichen Zählzeiten,
/// den dazugehörigen Registern und der tatsächlich ausgerollten Zählzeit (wenn diese elektronisch übermittelt wird)
/// </summary>
[ProtoContract]
public class Zaehlzeitdefinition : BusinessObject
{
    // The UTILTS "Lieferrichtung der Marktlokation" is contained in the marktlokations-bo
    // Also the relation between Zaehlzeitdefinitionen↔ Marktlokation is modelled as "link"

    [System.Text.Json.Serialization.JsonIgnore]
    [Newtonsoft.Json.JsonIgnore]
    [ProtoMember(6, Name = nameof(Beginndatum))]
    [CompatibilityLevel(CompatibilityLevel.Level240)]
    private DateTime _Beginndatum
    {
        get => Beginndatum?.UtcDateTime ?? DateTime.MinValue;
        set => Beginndatum = DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }

    /// <summary>
    /// Der inklusive Zeitpunkt ab dem die Zaehlzeitdefinitionen ausgerollt sind
    /// </summary>
    /// <remarks>UTILTS SG5 DTM+Z34</remarks>
    [JsonProperty(Order = 6, PropertyName = "beginndatum")]
    [JsonPropertyName("beginndatum")]
    [JsonPropertyOrder(6)]
    [ProtoIgnore]
    public DateTimeOffset? Beginndatum { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    [Newtonsoft.Json.JsonIgnore]
    [ProtoMember(7, Name = nameof(Endedatum))]
    [CompatibilityLevel(CompatibilityLevel.Level240)]
    private DateTime _Endedatum
    {
        get => Endedatum?.UtcDateTime ?? DateTime.MinValue;
        set => Endedatum = DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }

    /// <summary>
    /// Der exklusive Zeitpunkt bis zu dem die Zaehlzeitdefinitionen ausgerollt sind
    /// </summary>
    /// <remarks>UTILTS SG5 DTM+Z35</remarks>
    [JsonProperty(Order = 7, PropertyName = "endedatum")]
    [JsonPropertyName("endedatum")]
    [ProtoIgnore]
    [JsonPropertyOrder(7)]
    public DateTimeOffset? Endedatum { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    [Newtonsoft.Json.JsonIgnore]
    [ProtoMember(8, Name = nameof(Version))]
    [CompatibilityLevel(CompatibilityLevel.Level240)]
    private DateTime _Version
    {
        get => Version.UtcDateTime;
        set => Version = DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }

    /// <summary>
    /// Version der Zählzeitdefinition als Datum
    ///</summary>
    [JsonProperty(Order = 8, PropertyName = "version")]
    [JsonPropertyName("version")]
    [ProtoIgnore]
    [BoKey]
    [JsonPropertyOrder(8)]
    public DateTimeOffset Version { get; set; }

    /// <summary>
    /// Beschreibt ob eine Zaehlzeitdefinitionen notwendig ist
    /// </summary>
    /// <remarks>UTILTS SG5 STS 4405</remarks>
    [JsonProperty(Order = 9, PropertyName = "notwendigkeit")]
    [JsonPropertyName("notwendigkeit")]
    [ProtoMember(9)]
    [JsonPropertyOrder(9)]
    public DefinitionenNotwendigkeit? Notwendigkeit { get; set; }

    /// <summary>
    /// Liste der Zählzeiten [1 - 99999]
    /// </summary>
    [JsonProperty(Order = 10, PropertyName = "zaehlzeiten")]
    [JsonPropertyName("zaehlzeiten")]
    [ProtoMember(10)]
    [JsonPropertyOrder(10)]
    public List<Zaehlzeit>? Zaehlzeiten { get; set; }

    /// <summary>
    /// Liste der Zählzeitregister
    /// </summary>
    [JsonProperty(Order = 11, PropertyName = "zaehlzeitregister")]
    [JsonPropertyName("zaehlzeitregister")]
    [ProtoMember(11)]
    [JsonPropertyOrder(11)]
    public List<Zaehlzeitregister>? Zaehlzeitregister { get; set; }

    /// <summary>
    /// Liste der ausgerollten Zählzeiten
    /// </summary>
    [JsonProperty(Order = 12, PropertyName = "ausgerollteZaehlzeiten")]
    [JsonPropertyName("ausgerollteZaehlzeiten")]
    [ProtoMember(12)]
    [JsonPropertyOrder(12)]
    public List<AusgerollteZaehlzeit>? AusgerollteZaehlzeiten { get; set; }
}
