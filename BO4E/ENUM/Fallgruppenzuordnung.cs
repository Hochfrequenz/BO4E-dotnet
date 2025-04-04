using System.Runtime.Serialization;
using BO4E.meta;

namespace BO4E.ENUM;

/// <summary>Fallgruppenzuordnung nach edi@energy </summary>
[NonOfficial(NonOfficialCategory.REGULATORY_REQUIREMENTS)]
public enum Fallgruppenzuordnung
{
    /// <summary>RLM mit Tagesband</summary>
    [EnumMember(Value = "GABI_RLMmT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GABI_RLMmT")]
    GABI_RLMmT,

    /// <summary>RLM ohne Tagesband</summary>
    [EnumMember(Value = "GABI_RLMoT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GABI_RLMoT")]
    GABI_RLMoT,

    /// <summary>RLM im Nominierungsersatzverfahren</summary>
    [EnumMember(Value = "GABI_RLMNEV")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GABI_RLMNEV")]
    GABI_RLMNEV,
}
