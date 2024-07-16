using BO4E.ENUM;
using BO4E.meta;

using Newtonsoft.Json;

using ProtoBuf;
using System.Text.Json.Serialization;

namespace BO4E.COM;

/// <summary>
///     Zaehlzeit
/// </summary>
[ProtoContract]
[NonOfficial(NonOfficialCategory.REGULATORY_REQUIREMENTS)]
public class Zaehlzeit : COM
{
    /// <summary>
    ///  Zählzeitdefinition
    /// </summary>
    [JsonProperty(PropertyName = "code", Order = 4, Required = Required.Default)]
    [JsonPropertyOrder(4)]
    [JsonPropertyName("code")]
    [ProtoMember(4)]
    public string? Code { get; set; }

    /// <summary>
    ///     Häufigkeit der Übermittlung
    /// </summary>
    [JsonProperty(PropertyName = "haeufigkeit", Order = 5, Required = Required.Default)]
    [JsonPropertyName("haeufigkeit")]
    [JsonPropertyOrder(5)]
    [ProtoMember(5)]
    public HaeufigkeitZaehlzeit? Haeufigkeit { get; set; }

    /// <summary>
    ///     Art der Übermittlung
    /// </summary>
    [JsonProperty(PropertyName = "uebermittelbarkeit", Order = 6, Required = Required.Default)]
    [JsonPropertyName("uebermittelbarkeit")]
    [JsonPropertyOrder(6)]
    [ProtoMember(6)]
    public UebermittelbarkeitZaehlzeit? Uebermittelbarkeit { get; set; }

    /// <summary>
    ///     Ermittlung Leistungsmaximum
    /// </summary>
    [JsonProperty(PropertyName = "ermittlungLeistungsmaximum", Order = 7, Required = Required.Default)]
    [JsonPropertyName("ermittlungLeistungsmaximum")]
    [JsonPropertyOrder(7)]
    [ProtoMember(7)]
    public ErmittlungLeistungsmaximum? ErmittlungLeistungsmaximum { get; set; }

    /// <summary>
    ///     Ist die Zählzeit bestellbar?
    /// </summary>
    [JsonProperty(PropertyName = "istBestellbar", Order = 8, Required = Required.Default)]
    [JsonPropertyName("istBestellbar")]
    [JsonPropertyOrder(8)]
    [ProtoMember(8)]
    public bool? IstBestellbar { get; set; }

    /// <summary>
    ///     ZählzeitdefinitionTyp
    /// </summary>
    [JsonProperty(PropertyName = "typ", Order = 9, Required = Required.Default)]
    [JsonPropertyName("typ")]
    [JsonPropertyOrder(9)]
    [ProtoMember(9)]
    public ZaehlzeitdefinitionTyp? Typ { get; set; }

    /// <summary>
    ///     Beschreibung des ZählzeitdefinitionTyp
    /// </summary>
    [JsonProperty(PropertyName = "beschreibungTyp", Order = 10, Required = Required.Default)]
    [JsonPropertyName("beschreibungTyp")]
    [JsonPropertyOrder(10)]
    [ProtoMember(10)]
    public string? BeschreibungTyp { get; set; }
}
