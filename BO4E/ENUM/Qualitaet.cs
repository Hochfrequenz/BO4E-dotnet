using System.Runtime.Serialization;
using ProtoBuf;

namespace BO4E.ENUM;

/// <summary>Qualitätsstufen eines Business-Objektes, v.a. aus Sicht Marktkommunikation </summary>
public enum Qualitaet
{
    /// <summary>Vollstaendig</summary>
    [EnumMember(Value = "VOLLSTAENDIG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("VOLLSTAENDIG")]
    [ProtoEnum(Name = nameof(Qualitaet) + "_" + nameof(VOLLSTAENDIG))]
    VOLLSTAENDIG,

    /// <summary>Informativ
    /// </summary>
    [EnumMember(Value = "INFORMATIV")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("INFORMATIV")]
    [ProtoEnum(Name = nameof(Qualitaet) + "_" + nameof(INFORMATIV))]
    INFORMATIV,

    /// <summary>Im System vorhanden</summary>
    [EnumMember(Value = "IM_SYSTEM_VORHANDEN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("IM_SYSTEM_VORHANDEN")]
    [ProtoEnum(Name = nameof(Qualitaet) + "_" + nameof(IM_SYSTEM_VORHANDEN))]
    IM_SYSTEM_VORHANDEN,

    /// <summary>Erwartet</summary>
    [EnumMember(Value = "ERWARTET")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ERWARTET")]
    [ProtoEnum(Name = nameof(Qualitaet) + "_" + nameof(ERWARTET))]
    ERWARTET,

    /// <summary>Vorlaeufig</summary>
    [EnumMember(Value = "VORLAEUFIG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("VORLAEUFIG")]
    [ProtoEnum(Name = nameof(Qualitaet) + "_" + nameof(VORLAEUFIG))]
    VORLAEUFIG,

    /// <summary>Unvollstaendig</summary>
    [EnumMember(Value = "UNVOLLSTAENDIG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("UNVOLLSTAENDIG")]
    [ProtoEnum(Name = nameof(Qualitaet) + "_" + nameof(UNVOLLSTAENDIG))]
    UNVOLLSTAENDIG,
}
