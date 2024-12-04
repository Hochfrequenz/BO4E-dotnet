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
    /// Offene Zeitscheiben werden mit <code>GueltigBis = null</code> modelliert, _nicht_ mit <code>DateTimeOffset.MaxValue</code>.
    /// The maximum end date is NULL, this means DateTimeOffset.MaxValue is converted to null by the setter.
    /// </summary>
    [JsonPropertyName("gueltigBis")]
    [JsonPropertyOrder(2)]
    [Newtonsoft.Json.JsonProperty(PropertyName = "gueltigBis", Order = 2)]
    public DateTimeOffset? GueltigBis
    {
        get => _gueltigBis;
        set => _gueltigBis = (value == DateTimeOffset.MaxValue) ? null : value;
    }
    private DateTimeOffset? _gueltigBis;

    /// <summary>
    /// e.g.
    /// </summary>
    /// <example>"bo4e://netzlokation/E77MJ1X96G6"</example>
    [JsonPropertyName("parentId")]
    [JsonPropertyOrder(3)]
    [Newtonsoft.Json.JsonProperty(PropertyName = "parentId", Order = 3)]
    public string? ParentId { get; set; }

    /// <summary>
    /// Wer oder was ist dem mit <see cref="ChildId"/> beschriebenen Objekt zugeordnet?
    /// </summary>
    /// <example>"bo4e://marktteilnehmer/9991234567890"</example>
    [JsonPropertyName("childId")]
    [JsonPropertyOrder(4)]
    [Newtonsoft.Json.JsonProperty(PropertyName = "ParentId", Order = 4)]
    public string? ChildId { get; set; }

    /// <summary>
    /// Mit dem Feld <see cref="AdditionalSpecification"/> können zusätzliche Spezifikationen angegeben werden.
    /// </summary>
    /// <example>"bo4e://marktteilnehmer/9991234567890"</example>
    [JsonPropertyName("additionalSpecification")]
    [JsonPropertyOrder(4)]
    [Newtonsoft.Json.JsonProperty(PropertyName = "additionalSpecification", Order = 4)]
    public string? AdditionalSpecification { get; set; }
}
