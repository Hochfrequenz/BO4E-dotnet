using System.Text.Json.Serialization;
using BO4E.ENUM;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM;

/// <summary>
///     Konzessionsabgabe
/// </summary>
/// <author>Hochfrequenz Unternehmensberatung GmbH</author>
[ProtoContract]
public class Konzessionsabgabe : COM
{
    /// <summary>
    ///     Art der Abgabe
    /// </summary>
    [JsonProperty(PropertyName = "satz", Order = 8)]
    [JsonPropertyName("satz")]
    [ProtoMember(3)]
    public AbgabeArt Satz { get; set; }

    /// <summary>
    ///     Konzessionsabgabe in E/kWh
    /// </summary>
    [JsonProperty(PropertyName = "kosten", Order = 5)]
    [JsonPropertyName("kosten")]
    [ProtoMember(4)]
    public decimal? Kosten { get; set; }

    /// <summary>
    ///     Gebührenkategorie der Konzessionsabgabe
    /// </summary>
    [JsonProperty(PropertyName = "kategorie", Order = 6)]
    [JsonPropertyName("kategorie")]
    [ProtoMember(5)]
    public string? Kategorie { get; set; }
}
