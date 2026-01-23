#nullable enable
using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Befestigungsart</summary>
public enum Befestigungsart
{
    /// <summary>BKE</summary>
    [EnumMember(Value = "STECKTECHNIK")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("STECKTECHNIK")]
    STECKTECHNIK,

    /// <summary>DPA</summary>
    [EnumMember(Value = "DREIPUNKT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("DREIPUNKT")]
    DREIPUNKT,

    /// <summary>HUT</summary>
    [EnumMember(Value = "HUTSCHIENE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("HUTSCHIENE")]
    HUTSCHIENE,

    /// <summary>Z31</summary>
    [EnumMember(Value = "EINSTUTZEN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("EINSTUTZEN")]
    EINSTUTZEN,

    /// <summary>Z32</summary>
    [EnumMember(Value = "ZWEISTUTZEN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ZWEISTUTZEN")]
    ZWEISTUTZEN,
}
