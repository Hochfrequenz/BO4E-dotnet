using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Verbrauchsart einer Marktlokation.</summary>
public enum Verbrauchsart
{
    /// <summary>Kraft/Licht</summary>
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
}
