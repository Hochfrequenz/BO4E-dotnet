#nullable enable
using System;
using System.Text.Json.Serialization;
using BO4E.meta;
using BO4E.meta.LenientConverters;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM;

/// <summary>
///     Aufgabe als Teil einer <see cref="BO4E.BO.Benachrichtigung" />.
///     Aufgaben entsprechen den Klärfall-Lösungsmethoden im SAP.
/// </summary>
[NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
[ProtoContract]
public class Aufgabe : COM
{
    /// <summary>
    ///     Eindeutige Kennzeichnung der Aufgabe
    /// </summary>
    [JsonProperty(PropertyName = "aufgabenId")]
    [JsonPropertyName("aufgabenId")]
    [ProtoMember(3)]
    public string? AufgabenId { get; set; }

    /// <summary>
    ///     Optionale Beschreibung der Aufgabe
    /// </summary>
    [JsonProperty(PropertyName = "beschreibung")]
    [JsonPropertyName("beschreibung")]
    [ProtoMember(4)]
    public string? Beschreibung { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    [Newtonsoft.Json.JsonIgnore]
    [ProtoMember(5, Name = nameof(Deadline))]
    [CompatibilityLevel(CompatibilityLevel.Level240)]
    private DateTime _Deadline
    {
        get => Deadline?.UtcDateTime ?? default;
        set => Deadline = value == default ? null : DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }

    /// <summary>
    ///     Optionale Deadline bis zu der die Aufgabe ausführt werden kann oder ihre Ausführung
    ///     sinnvoll ist.
    /// </summary>
    [JsonProperty(PropertyName = "deadline")]
    [JsonPropertyName("deadline")]
    [ProtoIgnore]
    public DateTimeOffset? Deadline { get; set; }

    /// <summary>
    ///     Wurde diese Aufgabe schon ausgeführt (true)? Steht sie noch zur Bearbeitung an (false)?
    /// </summary>
    [JsonProperty(PropertyName = "ausgefuehrt")]
    [JsonPropertyName("ausgefuehrt")]
    [ProtoMember(6)]
    public bool Ausgefuehrt { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    [Newtonsoft.Json.JsonIgnore]
    [ProtoMember(7, Name = nameof(Ausfuehrungszeitpunkt))]
    [CompatibilityLevel(CompatibilityLevel.Level240)]
    private DateTime _Ausfuehrungszeitpunkt
    {
        get => Ausfuehrungszeitpunkt?.UtcDateTime ?? default;
        set =>
            Ausfuehrungszeitpunkt =
                value == default ? null : DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }

    /// <summary>
    ///     Zeitpunkt zu dem die Aufgabe ausgeführt wurde. (Nur sinnvoll, wenn <c>ausgefuehrt==true</c>)
    /// </summary>
    [Newtonsoft.Json.JsonConverter(typeof(LenientDateTimeConverter))]
    [System.Text.Json.Serialization.JsonConverter(
        typeof(LenientSystemTextJsonNullableDateTimeOffsetConverter)
    )]
    [JsonProperty(PropertyName = "ausfuehrungszeitpunkt")]
    [JsonPropertyName("ausfuehrungszeitpunkt")]
    [ProtoIgnore]
    public DateTimeOffset? Ausfuehrungszeitpunkt { get; set; }

    /// <summary>
    ///     Eindeutige Kennung des Benutzers, der diese Aufgabe ausführt hat.
    ///     (Nur sinnvoll, wenn <c>ausgefuehrt==true</c>)
    /// </summary>
    [JsonProperty(PropertyName = "ausfuehrender")]
    [JsonPropertyName("ausfuehrender")]
    [ProtoMember(8)]
    public string? Ausfuehrender { get; set; }
}
