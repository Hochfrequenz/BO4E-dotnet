using System.Text.Json.Serialization;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM;

/// <summary>Diese Komponente liefert die Geokoordinaten für einen Ort.</summary>
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
    
    /// <summary> Gibt die Östliche Koordinate eines entsprechenden Ortes an.</summary>
    [JsonProperty(PropertyName = "oestlichelaenge")]
    [JsonPropertyName("oestlichelaenge")]
    [ProtoMember(5)]
    public decimal? OestlicheLaenge { get; set; }
    
    /// <summary> Gibt die Nördliche Koordinate eines entsprechenden Ortes an.</summary>
    [JsonProperty(PropertyName = "noerdlichebreite")]
    [JsonPropertyName("noerdlichebreite")]
    [ProtoMember(6)]
    public decimal? noerdlichebreite { get; set; }
    
    /// <summary> Gibt die UTM Zone des Ortes an.</summary>
    [JsonProperty(PropertyName = "zone")]
    [JsonPropertyName("zone")]
    [ProtoMember(7)]
    public string? Zone { get; set; }
    
    /// <summary> Gibt den Nordwert Ortes an.</summary>
    [JsonProperty(PropertyName = "nordwert")]
    [JsonPropertyName("nordwert")]
    [ProtoMember(8)]
    public string? nordwert { get; set; }
    
    /// <summary> Gibt Ostwert des Ortes an.</summary>
    [JsonProperty(PropertyName = "ostwert")]
    [JsonPropertyName("ostwert")]
    [ProtoMember(9)]
    public string? oestwert { get; set; }
}
