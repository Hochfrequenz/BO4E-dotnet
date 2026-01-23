#nullable enable
using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Zertifikate für Ökostrom von verschiedenen Herausgebern.</summary>
public enum Oekozertifikat
{
    /// <summary>CMS Standard EEO2</summary>
    [EnumMember(Value = "CMS_EE02")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("CMS_EE02")]
    CMS_EE02,

    /// <summary>EECS</summary>
    [EnumMember(Value = "EECS")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("EECS")]
    EECS,

    /// <summary>Fraunhofer Institut</summary>
    [EnumMember(Value = "FRAUNHOFER")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("FRAUNHOFER")]
    FRAUNHOFER,

    /// <summary>Gutachten von BET Aachen</summary>
    [EnumMember(Value = "BET")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BET")]
    BET,

    /// <summary>KlimaINVEST</summary>
    [EnumMember(Value = "KLIMA_INVEST")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("KLIMA_INVEST")]
    KLIMA_INVEST,

    /// <summary>LGA (Landesgewerbeanstalt Bayern)</summary>
    [EnumMember(Value = "LGA")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("LGA")]
    LGA,

    /// <summary>Oeko Institut e.V. Freiburg</summary>
    [EnumMember(Value = "FREIBERG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("FREIBERG")]
    FREIBERG,

    /// <summary>RECS</summary>
    [EnumMember(Value = "RECS")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("RECS")]
    RECS,

    /// <summary>REGS für EGL AG</summary>
    [EnumMember(Value = "REGS_EGL")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("REGS_EGL")]
    REGS_EGL,

    /// <summary>TUEV</summary>
    [EnumMember(Value = "TUEV")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("TUEV")]
    TUEV,

    /// <summary>TUEV Hessen</summary>
    [EnumMember(Value = "TUEV_HESSEN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("TUEV_HESSEN")]
    TUEV_HESSEN,

    /// <summary>TUEV Nord</summary>
    [EnumMember(Value = "TUEV_NORD")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("TUEV_NORD")]
    TUEV_NORD,

    /// <summary>TUEV Rheinland</summary>
    [EnumMember(Value = "TUEV_RHEINLAND")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("TUEV_RHEINLAND")]
    TUEV_RHEINLAND,

    /// <summary>TUEV Sued</summary>
    [EnumMember(Value = "TUEV_SUED")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("TUEV_SUED")]
    TUEV_SUED,

    /// <summary>TUEV Sued EE01</summary>
    [EnumMember(Value = "TUEV_SUED_EE01")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("TUEV_SUED_EE01")]
    TUEV_SUED_EE01,

    /// <summary>TUEV Sued EE02</summary>
    [EnumMember(Value = "TUEV_SUED_EE02")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("TUEV_SUED_EE02")]
    TUEV_SUED_EE02,
}
