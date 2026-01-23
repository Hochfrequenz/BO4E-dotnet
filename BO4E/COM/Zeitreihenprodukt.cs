#nullable enable
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM;

/// <summary>Mit dieser Komponente werden Produkte von Summenzeitreihen modelliert.</summary>
[ProtoContract]
public class Zeitreihenprodukt : COM
{
    /// <summary>
    ///     Die OBIS-Kennzahl für das Produkt, die festlegt, welche auf die gemessene Größe mit dem Stand gemeldet wird.
    /// </summary>
    [JsonProperty(PropertyName = "identifikation", Order = 6)]
    [JsonPropertyName("identifikation")]
    [ProtoMember(6)]
    [JsonPropertyOrder(6)]
    public string? Identifikation { get; set; }

    /// <summary>
    ///     Korrekturfaktor der Zeitreihe
    /// </summary>
    [JsonProperty(PropertyName = "korrekturfaktor", Order = 7)]
    [JsonPropertyName("korrekturfaktor")]
    [ProtoMember(7)]
    [JsonPropertyOrder(7)]
    public decimal? Korrekturfaktor { get; set; }

    /// <summary>Der Verbrauch der Zeitreihe. Details <see cref="Verbrauch" /></summary>
    [JsonProperty(PropertyName = "verbrauch", Order = 8)]
    [JsonPropertyName("verbrauch")]
    [ProtoMember(8)]
    [JsonPropertyOrder(8)]
    public Verbrauch? Verbrauch { get; set; }

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
