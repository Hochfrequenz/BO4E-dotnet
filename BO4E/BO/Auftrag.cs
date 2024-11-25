#nullable enable
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using BO4E.COM;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.BO;

/// <summary>
/// Ein Auftrag beschreibt einen Vorgang, der von einem anderen Marktpartner auszuführen ist.
/// </summary>
[NonOfficial(NonOfficialCategory.REGULATORY_REQUIREMENTS)]
[ProtoContract]
public abstract class Auftrag : BusinessObject
{
    /// <summary>
    /// workaround
    /// </summary>
    [System.Text.Json.Serialization.JsonIgnore]
    [Newtonsoft.Json.JsonIgnore]
    [ProtoMember(4, Name = nameof(Ausfuehrungsdatum))]
    [CompatibilityLevel(CompatibilityLevel.Level240)]
    protected DateTime? _Ausfuehrungsdatum
    {
        get => Ausfuehrungsdatum?.UtcDateTime;
        set =>
            Ausfuehrungsdatum =
                value != null ? DateTime.SpecifyKind(value.Value, DateTimeKind.Utc) : null;
    }

    /// <summary>
    /// Das Ausführungsdatum beschreibt zu welchem Zeitpunkt ein Auftrag ausgeführt werden soll.
    /// </summary>
    [JsonProperty("ausfuehrungsdatum", Order = 1)]
    [JsonPropertyName("ausfuehrungsdatum")]
    [JsonPropertyOrder(1)]
    [ProtoIgnore]
    public DateTimeOffset? Ausfuehrungsdatum { get; set; }

    /// <summary>
    /// workaround
    /// </summary>
    [System.Text.Json.Serialization.JsonIgnore]
    [Newtonsoft.Json.JsonIgnore]
    [ProtoMember(5, Name = nameof(Fertigstellungsdatum))]
    [CompatibilityLevel(CompatibilityLevel.Level240)]
    protected DateTime _Fertigstellungsdatum
    {
        get => Fertigstellungsdatum?.UtcDateTime ?? DateTime.MinValue;
        set =>
            Fertigstellungsdatum =
                value == default ? null : DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }

    /// <summary>
    /// Das Fertigstellungsdatum beschreibt zu welchem Zeitpunkt ein Auftrag ausgeführt wurde/wird.
    /// </summary>
    [JsonProperty("fertigstellungsdatum", Order = 2)]
    [JsonPropertyName("fertigstellungsdatum")]
    [JsonPropertyOrder(2)]
    [ProtoIgnore]
    public DateTimeOffset? Fertigstellungsdatum { get; set; }

    /// <summary>
    /// Die Sparte in der der Auftrag relevant ist
    /// </summary>
    [JsonProperty("sparte", Order = 3)]
    [JsonPropertyName("sparte")]
    [JsonPropertyOrder(3)]
    public ENUM.Sparte? Sparte { get; set; }

    /// <summary>
    /// Die Adresse, die sich in Belieferung befindet.
    /// </summary>
    [JsonProperty("lieferanschrift", Order = 4)]
    [JsonPropertyName("lieferanschrift")]
    [JsonPropertyOrder(4)]
    [ProtoMember(6)]
    public Adresse? Lieferanschrift { get; set; }

    /// <summary>
    /// Die ID der Marktlokation der der zu sperrende Zähler zugeordnet ist.
    /// </summary>
    [JsonProperty("marktlokationsId", Order = 5)]
    [JsonPropertyName("marktlokationsId")]
    [JsonPropertyOrder(5)]
    [ProtoMember(7)]
    public string? MarktlokationsId { get; set; }

    /// <summary>
    /// Ein zusätzlicher Freitext
    /// </summary>
    [JsonProperty("bemerkungen", Order = 6)]
    [JsonPropertyName("bemerkungen")]
    [JsonPropertyOrder(6)]
    [ProtoMember(11)]
    public List<string>? Bemerkungen { get; set; }

    /// <summary>
    /// Der Mindestpreis eines Auftrags (z.B. für eine Sperrung)
    /// </summary>
    [JsonProperty("mindestpreis", Order = 7)]
    [JsonPropertyName("mindestpreis")]
    [JsonPropertyOrder(7)]
    [ProtoMember(9)]
    public Preis? Mindestpreis { get; set; }

    /// <summary>
    /// Der Höchstpreis eines Auftrags (z.B. für eine Sperrung)
    /// </summary>
    [JsonProperty("hoechstpreis", Order = 8)]
    [JsonPropertyName("hoechstpreis")]
    [JsonPropertyOrder(8)]
    [ProtoMember(10)]
    public Preis? Hoechstpreis { get; set; }
}
