#nullable enable
using System;
using System.Text.Json.Serialization;
using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM;

/// <summary>
///     Mit dieser Komponente werden Messlokationen zu Marktlokationen zugeordnet. Dabei kann eine arithmetische
///     Operation (Addition, Subtraktion) angegeben werden, mit der die Messlokation zum Verbrauch der Marklokation
///     beiträgt.
/// </summary>
[ProtoContract]
public class Messlokationszuordnung : COM
{
    /// <summary>Die Messlokations-ID, früher die Zählpunktbezeichnung.</summary>
    [DataCategory(DataCategory.POD)]
    [JsonProperty(PropertyName = "messlokationsId")]
    [JsonPropertyName("messlokationsId")]
    [ProtoMember(3)]
    public string? MesslokationsId { get; set; }

    /// <summary>
    ///     Die Operation, mit der eine Messung an dieser Lokation für den Gesamtverbrauch der Marktlokation verrechnet
    ///     wird. Beispielsweise bei einer Untermessung, wird der Verbauch der Untermessung subtrahiert. Details
    ///     <see cref="ArithmetischeOperation" />
    /// </summary>
    [JsonProperty(PropertyName = "arithmetik")] // Default weil Hochfrequenz/energy-service-hub#35
    [JsonPropertyName("arithmetik")]
    [ProtoMember(4)]
    public ArithmetischeOperation? Arithmetik { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    [Newtonsoft.Json.JsonIgnore]
    [ProtoMember(5, Name = nameof(GueltigSeit))]
    [CompatibilityLevel(CompatibilityLevel.Level240)]
    private DateTime _GueltigSeit
    {
        get => GueltigSeit?.UtcDateTime ?? default;
        set =>
            GueltigSeit = value == default ? null : DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }

    /// <summary>Zeitpunkt, ab dem die Messlokation zur Marktlokation gehört</summary>
    [JsonProperty(PropertyName = "gueltigSeit")]
    [JsonPropertyName("gueltigSeit")]
    [ProtoIgnore]
    public DateTimeOffset? GueltigSeit { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    [Newtonsoft.Json.JsonIgnore]
    [ProtoMember(6, Name = nameof(GueltigBis))]
    [CompatibilityLevel(CompatibilityLevel.Level240)]
    private DateTime _GueltigBis
    {
        get => GueltigBis?.UtcDateTime ?? default;
        set => GueltigBis = value == default ? null : DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }

    /// <summary>Zeitpunkt, bis zu dem die Messlokation zur Marktlokation gehört</summary>
    [JsonProperty(PropertyName = "gueltigBis")]
    [JsonPropertyName("gueltigBis")]
    [ProtoIgnore]
    public DateTimeOffset? GueltigBis { get; set; }
}
