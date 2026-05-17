using System.Collections.Generic;
using System.Text.Json.Serialization;
using BO4E.COM;
using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.BO;

/// <summary>
/// Avis BO
/// </summary>
[ProtoContract]
[NonOfficial(NonOfficialCategory.MISSING)]
public class Avis : BusinessObject
{
    /// <summary>
    /// Eine im Verwendungskontext eindeutige Nummer für das Avis.
    /// </summary>
    [JsonProperty(PropertyName = "avisNummer")]
    [JsonPropertyName("avisNummer")]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(1000)]
    public string? AvisNummer { get; set; }

    /// <summary>
    /// Gibt den Typ des Avis an.
    /// </summary>
    /// <see cref="AvisTyp" />
    [JsonProperty(PropertyName = "avisTyp")]
    [JsonPropertyName("avisTyp")]
    [ProtoMember(1001)]
    public AvisTyp? AvisTyp { get; set; }

    /// <summary>
    /// Avispositionen
    /// </summary>
    [JsonProperty(PropertyName = "positionen")]
    [JsonPropertyName("positionen")]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(1002)]
    [BoKey]
    public List<Avisposition>? Positionen { get; set; }

    /// <summary>
    /// Summenbetrag
    /// </summary>
    [JsonProperty(PropertyName = "zuZahlen")]
    [JsonPropertyName("zuZahlen")]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(1003)]
    public Betrag? ZuZahlen { get; set; }
}
