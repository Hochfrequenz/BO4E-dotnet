#nullable enable
using System;
using System.Text.Json.Serialization;
using BO4E.meta;
using BO4E.meta.LenientConverters;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM;

/// <summary>
///     Abbildung für einen Vertragsteil. Der Vertragsteil wird dazu verwendet, eine vertragliche Leistung in Bezug zu
///     einer Lokation (Markt- oder Messlokation) festzulegen.
///     https://www.bo4e.de/dokumentation/komponenten/com-vertragsteil
/// </summary>
[ProtoContract]
public class Vertragsteil : COM
{
    [System.Text.Json.Serialization.JsonIgnore]
    [Newtonsoft.Json.JsonIgnore]
    [ProtoMember(3, Name = nameof(Vertragsteilbeginn))]
    [CompatibilityLevel(CompatibilityLevel.Level240)]
    private DateTime _Vertragsteilbeginn
    {
        get => Vertragsteilbeginn?.UtcDateTime ?? DateTime.MinValue;
        set => Vertragsteilbeginn = DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }

    /// <summary>
    ///     Start der Gültigkeit des Vertragsteils.
    /// </summary>
    [JsonProperty(PropertyName = "vertragsteilbeginn")]
    [JsonPropertyName("vertragsteilbeginn")]
    [ProtoIgnore]
    [Newtonsoft.Json.JsonConverter(typeof(LenientDateTimeConverter))]
    public DateTimeOffset? Vertragsteilbeginn { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    [Newtonsoft.Json.JsonIgnore]
    [ProtoMember(4, Name = nameof(Vertragsteilende))]
    [CompatibilityLevel(CompatibilityLevel.Level240)]
    private DateTime _Vertragsteilende
    {
        get => Vertragsteilende?.UtcDateTime ?? DateTime.MinValue;
        set => Vertragsteilende = DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }

    /// <summary>
    ///     Ende der Gültigkeit des Vertragsteils.
    /// </summary>
    [JsonProperty(PropertyName = "vertragsteilende")]
    [JsonPropertyName("vertragsteilende")]
    [ProtoIgnore]
    [Newtonsoft.Json.JsonConverter(typeof(LenientDateTimeConverter))]
    public DateTimeOffset? Vertragsteilende { get; set; }

    /// <summary>
    ///     Der Identifier für diejenigen Markt- oder Messlokation, die zu diesem Vertragsteil gehören.
    ///     Verträge für mehrere Lokationen werden mit mehreren Vertragsteilen abgebildet.
    /// </summary>
    [ProtoMember(5)]
    [JsonProperty(PropertyName = "lokation")]
    [JsonPropertyName("lokation")]
    public string? Lokation { get; set; }

    /// <summary>
    ///     Für die Lokation festgeschriebene Abnahmemenge. Siehe COM Menge
    /// </summary>
    [JsonProperty(PropertyName = "vertraglichFixierteMenge")]
    [JsonPropertyName("vertraglichFixierteMenge")]
    [ProtoMember(6)]
    public Menge? VertraglichFixierteMenge { get; set; }

    /// <summary>
    ///     Für die Lokation festgelegte Mindestabnahmemenge. Siehe COM Menge
    /// </summary>
    [JsonProperty(PropertyName = "minimaleAbnahmemenge")]
    [JsonPropertyName("minimaleAbnahmemenge")]
    [ProtoMember(7)]
    public Menge? MinimaleAbnahmemenge { get; set; }

    /// <summary>
    ///     Für die Lokation festgelegte maximale Abnahmemenge. Siehe COM Menge
    /// </summary>
    [JsonProperty(PropertyName = "maximaleAbnahmemenge")]
    [JsonPropertyName("maximaleAbnahmemenge")]
    [ProtoMember(8)]
    public Menge? MaximaleAbnahmemenge { get; set; }

    /// <summary>
    ///     jahresverbrauchsprognose für EDIFACT mapping
    /// </summary>
    [JsonProperty(PropertyName = "jahresverbrauchsprognose")]
    [JsonPropertyName("jahresverbrauchsprognose")]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    [ProtoMember(1009)]
    public Menge? Jahresverbrauchsprognose { get; set; }

    /// <summary>
    ///     kundenwert für EDIFACT mapping
    /// </summary>
    [JsonProperty(PropertyName = "kundenwert")]
    [JsonPropertyName("kundenwert")]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    [ProtoMember(1010)]
    public Menge? Kundenwert { get; set; }

    /// <summary>
    ///     verbrauchsaufteilung für EDIFACT mapping
    /// </summary>
    [JsonProperty(PropertyName = "verbrauchsaufteilung")]
    [JsonPropertyName("verbrauchsaufteilung")]
    [ProtoMember(1011)]
    public string? Verbrauchsaufteilung { get; set; } // ToDo: evaluate if this actually should be an enum
}
