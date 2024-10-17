using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM;

/// <summary>
///     Modellierung einer Unterschrift, z.B. für Verträge, Angebote etc.
///     https://www.bo4e.de/dokumentation/komponenten/com-unterschrift
/// </summary>
[ProtoContract]
public class Unterschrift : COM
{
    /// <summary>
    ///     Ort, an dem die Unterschrift geleistet wird
    /// </summary>
    [JsonProperty(PropertyName = "ort")]
    [JsonPropertyName("ort")]
    [ProtoMember(3)]
    public string? Ort { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    [Newtonsoft.Json.JsonIgnore]
    [ProtoMember(4, Name = nameof(Datum))]
    [CompatibilityLevel(CompatibilityLevel.Level240)]
    private DateTime _Datum
    {
        get => Datum?.UtcDateTime ?? default;
        set => Datum = value == default ? null : DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }

    /// <summary>
    ///     Datum der Unterschrift
    /// </summary>
    [JsonProperty(PropertyName = "datum")]
    [JsonPropertyName("datum")]
    [ProtoIgnore]
    public DateTimeOffset? Datum { get; set; }

    /// <summary>
    ///     Name des Unterschreibers
    /// </summary>
    [JsonProperty(PropertyName = "name")]
    [JsonPropertyName("name")]
    [ProtoMember(5)]
    public string? Name { get; set; }
}
