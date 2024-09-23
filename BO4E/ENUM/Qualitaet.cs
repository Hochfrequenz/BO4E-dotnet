using System.Runtime.Serialization;
using ProtoBuf;

namespace BO4E.ENUM;

/// <summary>Qualitätsstufen eines Business-Objektes, v.a. aus Sicht Marktkommunikation </summary>
public enum Qualitaet
{
    /// <summary>Vollstaendig</summary>
    [EnumMember(Value = "VOLLSTAENDIG")]
    [ProtoEnum(Name = nameof(Qualitaet) + "_" + nameof(VOLLSTAENDIG))]
    VOLLSTAENDIG,

    /// <summary>Informativ
    /// </summary>
    [EnumMember(Value = "INFORMATIV")]
    [ProtoEnum(Name = nameof(Qualitaet) + "_" + nameof(INFORMATIV))]
    INFORMATIV,

    /// <summary>Im System vorhanden</summary>
    [EnumMember(Value = "IM_SYSTEM_VORHANDEN")]
    [ProtoEnum(Name = nameof(Qualitaet) + "_" + nameof(IM_SYSTEM_VORHANDEN))]
    IM_SYSTEM_VORHANDEN,

    /// <summary>Erwartet</summary>
    [EnumMember(Value = "ERWARTET")]
    [ProtoEnum(Name = nameof(Qualitaet) + "_" + nameof(ERWARTET))]
    ERWARTET,

    /// <summary>Vorlaeufig</summary>
    [EnumMember(Value = "VORLAEUFIG")]
    [ProtoEnum(Name = nameof(Qualitaet) + "_" + nameof(VORLAEUFIG))]
    VORLAEUFIG,

    /// <summary>Unvollstaendig</summary>
    [EnumMember(Value = "UNVOLLSTAENDIG")]
    [ProtoEnum(Name = nameof(Qualitaet) + "_" + nameof(UNVOLLSTAENDIG))]
    UNVOLLSTAENDIG,
}
