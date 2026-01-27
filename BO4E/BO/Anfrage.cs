using System.Text.Json.Serialization;
using BO4E.COM;
using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.BO;

/// <summary>
/// Anfrage BO
/// </summary>
[ProtoContract]
[NonOfficial(NonOfficialCategory.MISSING)]
public class Anfrage : BusinessObject
{
    /// <summary>
    /// Für welche Markt- oder Messlokation gilt diese Anfrage.
    /// </summary>
    [JsonProperty(PropertyName = "lokationsId", Order = 6)]
    [JsonPropertyName("lokationsId")]
    [JsonPropertyOrder(6)]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(1000)]
    public string? LokationsId { get; set; }

    /// <summary>
    /// Gibt an, ob es sich um eine Markt- oder Messlokation handelt
    /// </summary>
    /// <see cref="Lokationstyp" />
    [JsonProperty(PropertyName = "lokationsTyp", Order = 7)]
    [JsonPropertyName("lokationsTyp")]
    [ProtoMember(1001)]
    [JsonPropertyOrder(7)]
    public Lokationstyp LokationsTyp { get; set; }

    /// <summary>
    /// OBIS-Kennzahl
    /// </summary>
    /// <example>
    ///     1-0:1.8.1
    /// </example>
    [JsonProperty(PropertyName = "obiskennzahl", Order = 8)]
    [JsonPropertyName("obiskennzahl")]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(1002)]
    [JsonPropertyOrder(8)]
    [BoKey]
    public string? Obiskennzahl { get; set; }

    /// <summary>
    /// Sollablesetermin / Zeitangabe für Messwertanfrage. Details <see cref="Zeitraum" />
    /// </summary>
    [JsonProperty(PropertyName = "ZeitraumMesswertanfrage", Order = 9)]
    [JsonPropertyName("ZeitraumMesswertanfrage")]
    [ProtoMember(1003)]
    [JsonPropertyOrder(9)]
    public Zeitraum? ZeitraumMesswertanfrage { get; set; }

    /// <summary>
    /// Kategorie der Anfrage (ORDERS ORDRSP BGM 1001)
    /// </summary>
    [JsonProperty(PropertyName = "anfragekategorie", Order = 10)]
    [JsonPropertyName("anfragekategorie")]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(1004)]
    [JsonPropertyOrder(10)]
    [BoKey]
    public Anfragekategorie Anfragekategorie { get; set; }

    /// <summary>
    /// Typ/Art der Anfrage (ORDERS ORDRSP IMD 7081)
    /// </summary>
    [JsonProperty(PropertyName = "anfragetyp", Order = 11)]
    [JsonPropertyName("anfragetyp")]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(1005)]
    [JsonPropertyOrder(11)]
    public Anfragetyp? Anfragetyp { get; set; }
    
    [JsonProperty(PropertyName = "positionsnummer", Order = 12)]
    [JsonPropertyName("positionsnummer")]
    [ProtoMember(1006)]
    [JsonPropertyOrder(12)]
    public string? Positionsnummer { get; set; } // it's indeed a string right now - I don't want to break it
}
