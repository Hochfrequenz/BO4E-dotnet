using System;
using System.Text.Json.Serialization;
using BO4E.COM;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

//[module: CompatibilityLevel(CompatibilityLevel.Level300)]
namespace BO4E.BO;

/// <summary>
///     Mit diesem BO können Statusberichte (vor allem CONTRL/APERAK-Nachrichten) ausgetauscht werden
/// </summary>
[ProtoContract]
public class Statusbericht : BusinessObject
{
    /// <summary>
    ///     Status des Berichtes (Fehlerhaft, Erfolgreich)
    /// </summary>
    [JsonProperty(Required = Required.Always, Order = 10, PropertyName = "status")]
    [JsonPropertyName("status")]
    [JsonPropertyOrder(10)]
    [ProtoMember(1)]
    public BO4E.ENUM.BerichtStatus Status { get; set; }

    /// <summary>
    ///    Das geprüfte Dokument, z.B. die Referenz auf die EDIFACT-Nachricht die geprüft / beanstandet wurde
    /// </summary>
    [JsonProperty(Required = Required.Default, Order = 11, PropertyName = "pruefgegenstand")]
    [JsonPropertyName("pruefgegenstand")]
    [ProtoMember(2)]
    [JsonPropertyOrder(11)]
    [BoKey]
    public string? Pruefgegenstand { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    [Newtonsoft.Json.JsonIgnore]
    [ProtoMember(3, Name = nameof(DatumPruefung))]
    [CompatibilityLevel(CompatibilityLevel.Level240)]
    private DateTime _DatumPruefung
    {
        get => DatumPruefung.UtcDateTime;
        set => DatumPruefung = DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }

    /// <summary>
    ///     Pruefdatum (wann wurde der <see cref="Pruefgegenstand" /> geprüft)
    /// </summary>
    /// <example>
    ///     2017-12-24
    /// </example>
    [JsonProperty(Required = Required.Always, Order = 12, PropertyName = "datumPruefung")]
    [JsonPropertyName("datumPruefung")]
    [JsonPropertyOrder(12)]
    [ProtoIgnore]
    public DateTimeOffset DatumPruefung { get; set; }

    /// <summary>
    ///    Liste der Fehler
    /// </summary>
    [JsonProperty(Required = Required.Default, Order = 13, PropertyName = "fehler")]
    [JsonPropertyName("fehler")]
    [JsonPropertyOrder(13)]
    public Fehler? Fehler { get; set; }
}
