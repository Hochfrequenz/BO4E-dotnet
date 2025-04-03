using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Ausschreibungsstatus</summary>
public enum Ausschreibungsstatus
{
    /// <summary>Phase1: Teilnahmewettbewerb</summary>
    [EnumMember(Value = "PHASE1")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("PHASE1")]
    PHASE1,

    /// <summary>Phase2: Angebotsphase</summary>
    [EnumMember(Value = "PHASE2")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("PHASE2")]
    PHASE2,

    /// <summary>Phase3: Verhandlungsphase</summary>
    [EnumMember(Value = "PHASE3")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("PHASE3")]
    PHASE3,

    /// <summary>Phase4: Zuschlagserteilung</summary>
    [EnumMember(Value = "PHASE4")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("PHASE4")]
    PHASE4,
}
