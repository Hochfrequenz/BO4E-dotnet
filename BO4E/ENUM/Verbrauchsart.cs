using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Verbrauchsart einer Marktlokation.</summary>
public enum Verbrauchsart
{
    /// <summary>Kraft/Licht</summary>
    [EnumMember(Value = "KL")]
    KL,

    /// <summary>Kraft/Licht/Wärme</summary>
    [EnumMember(Value = "KLW")]
    KLW,

    /// <summary>Kraft/Licht/Wärme/Speicherheizung</summary>
    [EnumMember(Value = "KLWS")]
    KLWS,

    /// <summary>Wärme</summary>
    [EnumMember(Value = "W")]
    W,

    /// <summary>Wärme/Speicherheizung</summary>
    [EnumMember(Value = "WS")]
    WS,
}
