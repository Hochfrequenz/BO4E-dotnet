using System.Text.Json.Serialization;
using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM;

/// <summary>
/// </summary>
[ProtoContract]
[NonOfficial(NonOfficialCategory.REGULATORY_REQUIREMENTS)]
public class Schaltzeit : COM
{
    /// <summary>
    /// Code
    /// </summary>
    [JsonProperty(PropertyName = "code", Order = 1, Required = Required.Default)]
    [JsonPropertyOrder(1)]
    [JsonPropertyName("code")]
    [ProtoMember(1)]
    public string? Code { get; set; }

    /// <summary>
    /// Häufigkeit der Übermittlung
    /// </summary>
    [JsonProperty(PropertyName = "haeufigkeit", Order = 2, Required = Required.Default)]
    [JsonPropertyName("haeufigkeit")]
    [JsonPropertyOrder(2)]
    [ProtoMember(2)]
    public HaeufigkeitZaehlzeit? Haeufigkeit { get; set; }

    /// <summary>
    /// Art der Übermittlung
    /// </summary>
    [JsonProperty(PropertyName = "uebermittelbarkeit", Order = 3, Required = Required.Default)]
    [JsonPropertyName("uebermittelbarkeit")]
    [JsonPropertyOrder(3)]
    [ProtoMember(3)]
    public UebermittelbarkeitZaehlzeit? Uebermittelbarkeit { get; set; }
}
