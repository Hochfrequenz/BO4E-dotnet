using System.Text.Json.Serialization;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM;

/// <summary>
/// Diese Komponente liefert die Geokoordinaten für einen Ort.
/// Hierbei kann es sich um Breiten- und Längengrad oder um UTM-Koordinaten handeln. Diese lassen sich zwar ineinander
/// umrechnen, jedoch sind die UTM-Koordinaten genauer, benötigen aber auch mehr Werte.
/// Ein Mapping ist nicht vorgesehen in UTM-Koordinaten ist aktuell nicht vorgesehen.
/// </summary>
[ProtoContract]
public class Geokoordinaten : COM
{
    /// <summary>Gibt den Breitengrad eines entsprechenden Ortes an.</summary>
    [JsonProperty(PropertyName = "breitengrad")]
    [JsonPropertyName("breitengrad")]
    [ProtoMember(3)]
    public decimal? Breitengrad { get; set; }

    /// <summary>Gibt den Längengrad eines entsprechenden Ortes an.</summary>
    [JsonProperty(PropertyName = "laengengrad")]
    [JsonPropertyName("laengengrad")]
    [ProtoMember(4)]
    public decimal? Laengengrad { get; set; }

    /// <summary> Gibt die Östliche Länge im UTM-Koordinaten eines entsprechenden Ortes an.</summary>
    [JsonProperty(PropertyName = "oestlicheLaenge")]
    [JsonPropertyName("oestlicheLaenge")]
    [ProtoMember(5)]
    public decimal? OestlicheLaenge { get; set; }

    /// <summary> Gibt die Nördliche Breite in UTM-Koordinate eines entsprechenden Ortes an.</summary>
    [JsonProperty(PropertyName = "noerdlicheBreite")]
    [JsonPropertyName("noerdlicheBreite")]
    [ProtoMember(6)]
    public decimal? NoerdlicheBreite { get; set; }

    /// <summary> Gibt die UTM Zone des Ortes an.</summary>
    [JsonProperty(PropertyName = "zone")]
    [JsonPropertyName("zone")]
    [ProtoMember(7)]
    public string? Zone { get; set; }

    /// <summary> Gibt den Nordwert Ortes in UTM-Koordinaten an.</summary>
    [JsonProperty(PropertyName = "nordWert")]
    [JsonPropertyName("nordwert")]
    [ProtoMember(8)]
    public string? NordWert { get; set; }

    /// <summary> Gibt Ostwert des Ortes in UTM-Koordinaten an.</summary>
    [JsonProperty(PropertyName = "ostWert")]
    [JsonPropertyName("ostwert")]
    [ProtoMember(9)]
    public string? OstWert { get; set; }
}
