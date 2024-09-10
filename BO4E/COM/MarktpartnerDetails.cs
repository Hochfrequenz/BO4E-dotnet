using System;
using System.Text.Json.Serialization;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM;

[Obsolete(
    "This class has been renamed to COM."
        + nameof(MarktpartnerDetails)
        + " to avoid further naming confusion.",
    true
)]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public class Marktrolle : MarktpartnerDetails { }

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

/// <summary>
/// Used in Marktlokation and Messlokation to represent data about MSB
/// </summary>
[ProtoContract]
[NonOfficial(NonOfficialCategory.UNSPECIFIED)]
public class MarktpartnerDetails : COM
{
    /// <summary>
    /// Rollencodenummer von Marktrolle
    /// </summary>
    [JsonProperty(PropertyName = "rollencodenummer", Required = Required.Default)]
    [JsonPropertyName("rollencodenummer")]
    [ProtoMember(3)]
    public string? Rollencodenummer { get; set; }

    /// <summary>
    /// Code von Marktrolle
    /// </summary>
    [JsonProperty(PropertyName = "code", Required = Required.Default)]
    [JsonPropertyName("code")]
    [NonOfficial(NonOfficialCategory.UNSPECIFIED)]
    [ProtoMember(4)]
    public string? Code { get; set; }

    /// <summary>
    /// Marktrolle. Details siehe <see cref="ENUM.Marktrolle" />
    /// </summary>
    [JsonProperty(Required = Required.Default)]
    [ProtoMember(5)]
#pragma warning disable IDE1006 // Naming Styles because Marktrolle is already the name of the enum
    // ReSharper disable once InconsistentNaming
    public ENUM.Marktrolle? marktrolle { get; set; }

    /// <summary>
    /// Weiterverpflichtung des MSB />
    /// </summary>
    [JsonProperty(PropertyName = "weiterverpflichtet", Required = Required.Default, Order = 10)]
    [JsonPropertyName("weiterverpflichtet")]
    [ProtoMember(10)]
    [JsonPropertyOrder(10)]
    public bool? Weiterverpflichtet { get; set; }

#pragma warning restore IDE1006 // Naming Styles
}
