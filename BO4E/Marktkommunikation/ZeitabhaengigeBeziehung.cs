#nullable enable
using System;
using System.Text.Json.Serialization;
using BO4E.BO;

namespace BO4E.Marktkommunikation;

/// <summary>
/// Modelliert eine zeitabhängige Beziehung zwischen BusinessObjects.
/// 'Zeitabhängig' meint in dem Fall, z.B. dass ein Marktteilnehmer über einen bestimmten Zeitraum einer Lokation zugeordnet ist.
/// Diese zeitabhängige Beziehung ist nicht zu verwechseln mit dem <see cref="BusinessObject.Gueltigkeitszeitraum"/> jedes Objekts für sich.
/// </summary>
public class ZeitabhaengigeBeziehung
{
    /// <summary>
    /// inklusiver Start
    /// </summary>
    [JsonPropertyName("gueltigVon")]
    [JsonPropertyOrder(1)]
    [Newtonsoft.Json.JsonProperty(PropertyName = "gueltigVon", Order = 1)]
    public DateTimeOffset GueltigVon { get; set; }

    /// <summary>
    /// exklusives Ende, hier darf nur das Mavimale Enddatum eingetragen werden, sofern bekannt. Anderen Falls ist das Feld null.
    /// The maximum end date is NULL, this means DateTimeOffset.MaxValue is converted to null.
    /// </summary>
    [JsonPropertyName("gueltigBis")]
    [JsonPropertyOrder(2)]
    [Newtonsoft.Json.JsonProperty(PropertyName = "gueltigBis", Order = 2)]
    public DateTimeOffset? GueltigBis
    {
        get => _infiniteTime;
        set => _infiniteTime = (value == DateTimeOffset.MaxValue) ? null : value;
    }
    private DateTimeOffset? _infiniteTime;

    /// <summary>
    /// e.g.
    /// </summary>
    /// <example>"bo4e://netzlokation/E77MJ1X96G6"</example>
    [JsonPropertyName("parentId")]
    [JsonPropertyOrder(3)]
    [Newtonsoft.Json.JsonProperty(PropertyName = "parentId", Order = 3)]
    public string? ParentId { get; set; }

    /// <summary>
    /// Wer oder was ist dem mit <see cref="ParentId"/> beschriebenen Objekt zugeordnet?
    /// </summary>
    /// <example>"bo4e://marktteilnehmer/9991234567890"</example>
    [JsonPropertyName("childId")]
    [JsonPropertyOrder(4)]
    [Newtonsoft.Json.JsonProperty(PropertyName = "childId", Order = 4)]
    public string? ChildId { get; set; }

    /// <summary>
    /// An extra field to store or add additional information for further processing.
    /// This can be used to distinguish different kinds of relations between the same parent and child type.
    /// </summary>
    [JsonPropertyName("additionalInformation")]
    [JsonPropertyOrder(5)]
    [Newtonsoft.Json.JsonProperty(PropertyName = "additionalInformation", Order = 5)]
    public string? AdditionalInformation { get; set; }
}
