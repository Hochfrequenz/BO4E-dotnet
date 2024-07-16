using BO4E.meta;
using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Fallgruppenzuordnung nach edi@energy </summary>
[NonOfficial(NonOfficialCategory.REGULATORY_REQUIREMENTS)]
public enum Fallgruppenzuordnung
{
    /// <summary>RLM mit Tagesband</summary>
    [EnumMember(Value = "GABI_RLMmT")]
    GABI_RLMmT,
    /// <summary>RLM ohne Tagesband</summary>
    [EnumMember(Value = "GABI_RLMoT")]
    GABI_RLMoT,
    /// <summary>RLM im Nominierungsersatzverfahren</summary>
    [EnumMember(Value = "GABI_RLMNEV")]
    GABI_RLMNEV
}
