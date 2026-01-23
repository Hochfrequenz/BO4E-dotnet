#nullable enable
using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Verbrauchsart einer Marktlokation.</summary>
public enum Verbrauchsart
{
    /// <summary>Z64: Kraft/Licht</summary>
    [EnumMember(Value = "KL")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("KL")]
    KL,

    /// <summary>Kraft/Licht/Wärme</summary>
    [EnumMember(Value = "KLW")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("KLW")]
    KLW,

    /// <summary>Kraft/Licht/Wärme/Speicherheizung</summary>
    [EnumMember(Value = "KLWS")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("KLWS")]
    KLWS,

    /// <summary>Wärme</summary>
    [EnumMember(Value = "W")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("W")]
    W,

    /// <summary>Wärme/Speicherheizung</summary>
    [EnumMember(Value = "WS")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("WS")]
    WS,

    /// <summary>Z65: Wärme/Kälte</summary>
    [EnumMember(Value = "WK")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("WK")]
    WK,

    /// <summary>ZE5: E-Mobilität</summary>
    [EnumMember(Value = "EM")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("EM")]
    EM,

    /// <summary>ZA8: Straßenbeleuchtung</summary>
    [EnumMember(Value = "STRB")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("STRB")]
    STRB,

    /// <summary>ZB3: Steuerung Wärmeabgabe</summary>
    [EnumMember(Value = "STW")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("STW")]
    STW,
}
