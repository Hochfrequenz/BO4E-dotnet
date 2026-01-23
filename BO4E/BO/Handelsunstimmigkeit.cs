#nullable enable
using System.Text.Json.Serialization;
using BO4E.COM;
using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.BO;

/// <summary>
/// Handelsunstimmigkeit BO
/// </summary>
[ProtoContract]
[NonOfficial(NonOfficialCategory.MISSING)]
public class Handelsunstimmigkeit : BusinessObject
{
    /// <summary>
    /// Handelsunstimmigkeitsnummer
    /// </summary>
    [JsonProperty(PropertyName = "nummer", Order = 10)]
    [JsonPropertyName("nummer")]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(1000)]
    [JsonPropertyOrder(10)]
    [BoKey]
    public string? Nummer { get; set; }

    /// <summary>
    /// Gibt den Typ der Handelsunstimmigkeit an.
    /// </summary>
    /// <see cref="Handelsunstimmigkeitstyp" />
    [JsonProperty(PropertyName = "typ", Order = 11)]
    [JsonPropertyName("typ")]
    [JsonPropertyOrder(11)]
    [ProtoMember(1001)]
    public Handelsunstimmigkeitstyp Typ { get; set; }

    /// <summary>
    /// Handelsunstimmigskeitsbegründung
    /// </summary>
    /// <see cref="Handelsunstimmigkeitsbegruendung" />
    [JsonProperty(PropertyName = "begruendung", Order = 12)]
    [JsonPropertyName("begruendung")]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [JsonPropertyOrder(12)]
    [ProtoMember(1002)]
    public Handelsunstimmigkeitsbegruendung? Begruendung { get; set; }

    /// <summary>
    /// angeforderter Betrag
    /// </summary>
    [JsonProperty(PropertyName = "zuZahlen", Order = 13)]
    [JsonPropertyName("zuZahlen")]
    [JsonPropertyOrder(13)]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(1003)]
    public Betrag? ZuZahlen { get; set; }
}
