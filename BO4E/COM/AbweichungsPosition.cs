#nullable enable
using System.Text.Json.Serialization;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM;

/// <summary>
/// Zur Angabe einer Abweichung einer einzelnen Position
/// </summary>
[ProtoContract]
[NonOfficial(NonOfficialCategory.MISSING)]
public class Abweichungsposition : COM
{
    /// <summary>
    /// Angabe des Abweichungsgrunds (Code)
    /// </summary>
    [JsonProperty(PropertyName = "abweichungsgrundCode", Order = 7)]
    [JsonPropertyName("abweichungsgrundCode")]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(7)]
    [JsonPropertyOrder(7)]
    public string? AbweichungsgrundCode { get; set; }

    /// <summary>
    /// Angabe des Abweichungsgrunds (Codeliste)
    /// </summary>
    [JsonProperty(PropertyName = "abweichungsgrundCodeliste", Order = 3)]
    [JsonPropertyName("abweichungsgrundCodeliste")]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(3)]
    [JsonPropertyOrder(3)]
    public string? AbweichungsgrundCodeliste { get; set; }

    /// <summary>
    /// Nähere Erläuterung zum Abweichungsgrund
    /// </summary>
    [JsonProperty(PropertyName = "abweichungsgrundBemerkung", Order = 4)]
    [JsonPropertyName("abweichungsgrundBemerkung")]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(4)]
    [JsonPropertyOrder(4)]
    public string? AbweichungsgrundBemerkung { get; set; }

    /// <summary>
    /// Zugehörige Rechnung
    /// </summary>
    [JsonProperty(PropertyName = "zugehoerigeRechnung", Order = 5)]
    [JsonPropertyName("zugehoerigeRechnung")]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(5)]
    [JsonPropertyOrder(5)]
    public string? ZugehoerigeRechnung { get; set; }

    /// <summary>
    /// Zugehörige Bestellung
    /// </summary>
    [JsonProperty(PropertyName = "zugehoerigeBestellung", Order = 6)]
    [JsonPropertyName("zugehoerigeBestellung")]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(6)]
    [JsonPropertyOrder(6)]
    public string? ZugehoerigeBestellung { get; set; }
}
