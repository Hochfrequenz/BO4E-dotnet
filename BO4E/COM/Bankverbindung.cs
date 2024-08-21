using System.Text.Json.Serialization;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM;

/// <summary>Enthält eine Bankverbindung</summary>
[ProtoContract]
public class Bankverbindung : COM
{
    /// <summary>IBAN</summary>
    [DataCategory(DataCategory.FINANCE)]
    [JsonProperty(PropertyName = "iban", Required = Required.Default, Order = 3)]
    [JsonPropertyName("iban")]
    [ProtoMember(3)]
    [JsonPropertyOrder(3)]
    public string? IBAN { get; set; }

    /// <summary>Der kontoinhaber</summary>
    [DataCategory(DataCategory.FINANCE)]
    [JsonProperty(PropertyName = "kontoinhaber", Required = Required.Default, Order = 4)]
    [JsonPropertyName("kontoinhaber")]
    [ProtoMember(4)]
    [JsonPropertyOrder(4)]
    public string? Kontoinhaber { get; set; }

    /// <summary>Die Bankkennung, BIC</summary>
    [DataCategory(DataCategory.FINANCE)]
    [JsonProperty(PropertyName = "bankkennung", Required = Required.Default, Order = 5)]
    [JsonPropertyName("bankkennung")]
    [ProtoMember(5)]
    [JsonPropertyOrder(5)]
    public string? Bankkennung { get; set; }

    /// <summary>Der Bankname</summary>
    [DataCategory(DataCategory.FINANCE)]
    [JsonProperty(PropertyName = "bankname", Required = Required.Default, Order = 6)]
    [JsonPropertyName("bankname")]
    [ProtoMember(6)]
    [JsonPropertyOrder(6)]
    public string? Bankname { get; set; }
}
