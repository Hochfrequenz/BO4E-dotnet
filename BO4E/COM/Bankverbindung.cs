using System.Text.Json.Serialization;
using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM;

/// <summary>Enthält eine Bankverbindung</summary>
[ProtoContract]
public class Bankverbindung : COM
{
    /// <summary>Der kontonummer. IBAN</summary>
    [DataCategory(DataCategory.FINANCE)]
    [JsonProperty(PropertyName = "kontonummer", Required = Required.Default, Order = 3)]
    [JsonPropertyName("kontonummer")]
    [ProtoMember(3)]
    [JsonPropertyOrder(3)]
    public string? Kontonummer { get; set; }

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

    /// <summary>Das bankcode</summary>
    [DataCategory(DataCategory.FINANCE)]
    [JsonProperty(PropertyName = "bankcode", Required = Required.Default, Order = 6)]
    [JsonPropertyName("bankcode")]
    [ProtoMember(6)]
    [JsonPropertyOrder(6)]
    public string? Bankcode { get; set; }

    /// <summary>Der Bankname</summary>
    [DataCategory(DataCategory.FINANCE)]
    [JsonProperty(PropertyName = "bankname", Required = Required.Default, Order = 7)]
    [JsonPropertyName("bankname")]
    [ProtoMember(7)]
    [JsonPropertyOrder(7)]
    public string? Bankname { get; set; }

    /// <summary>Das Land</summary>
    [DataCategory(DataCategory.FINANCE)]
    [JsonProperty(PropertyName = "land", Required = Required.Default, Order = 8)]
    [JsonPropertyName("land")]
    [ProtoMember(8)]
    [JsonPropertyOrder(8)]
    public Landescode? Land { get; set; }
}
