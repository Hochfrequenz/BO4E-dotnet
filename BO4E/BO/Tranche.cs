using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json.Serialization;
using BO4E.COM;
using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.BO;

/// <summary>
///     Objekt zur Aufnahme der Informationen zu einer Tranche
/// </summary>
[ProtoContract]
public class Tranche : BusinessObject
{
    /// <summary>
    ///     Identifikationsnummer einer Tranche, an der Energie entweder
    ///     verbraucht, oder erzeugt wird (Like MarktlokationsId <see cref="Marktlokation"/>)
    /// </summary>
    [DefaultValue("|null|")]
    [JsonProperty(Order = 10, PropertyName = "trancheId")]
    [JsonPropertyName("trancheId")]
    [JsonPropertyOrder(10)]
    [DataCategory(DataCategory.POD)]
    [BoKey]
    [ProtoMember(4)]
    public string TrancheId { get; set; }

    /// <summary>Sparte der Tranche, z.B. Gas oder Strom.</summary>
    [JsonProperty(Order = 11, PropertyName = "sparte")]
    [JsonPropertyOrder(11)]
    [JsonPropertyName("sparte")]
    [ProtoMember(5)]
    public Sparte Sparte { get; set; }

    /// <summary>
    /// Prozentualer Anteil der Tranche an der erzeugenden Marktlokation in Prozent mit 2 Nachkommastellen
    /// </summary>
    [JsonProperty(Order = 12, PropertyName = "aufteilungsmenge")]
    [JsonPropertyOrder(12)]
    [JsonPropertyName("aufteilungsmenge")]
    [ProtoMember(6)]
    public decimal? Aufteilungsmenge { get; set; }

    /// <summary>
    ///     Die OBIS-Kennzahl für die Tranche, die festlegt, welche auf die gemessene Größe mit dem Stand gemeldet wird.
    /// </summary>
    [JsonProperty(Order = 13, PropertyName = "obisKennzahl")]
    [JsonPropertyOrder(13)]
    [JsonPropertyName("obisKennzahl")]
    [ProtoMember(7)]
    public string? ObisKennzahl { get; set; }

    /// <summary>
    ///     Zugeordnete Marktpartner
    /// </summary>
    [JsonProperty(Order = 14, PropertyName = "marktrollen")]
    [JsonPropertyName("marktrollen")]
    [JsonPropertyOrder(14)]
    [ProtoMember(8)]
    public List<MarktpartnerDetails>? Marktrollen { get; set; }

    /// <summary>
    /// Liefert zusätzliche Spezifizierungen zu dem prozentualen Anteil der Tranche an der erzeugenden Marktlokation
    /// </summary>
    [JsonProperty(Order = 15, PropertyName = "spezifizierungAufteilungsmenge")]
    [JsonPropertyOrder(15)]
    [JsonPropertyName("spezifizierungAufteilungsmenge")]
    [ProtoMember(9)]
    public string? SpezifizierungAufteilungsmenge { get; set; }
}
