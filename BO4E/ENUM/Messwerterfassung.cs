using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Messwerterfassung</summary>
public enum Messwerterfassung
{
    /// <summary>AMR: fernauslesbare Zähler</summary>
    [EnumMember(Value = "FERNAUSLESBAR")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("FERNAUSLESBAR")]
    FERNAUSLESBAR,

    /// <summary>MMR: manuell ausgelesene Zähler</summary>
    [EnumMember(Value = "MANUELL_AUSGELESENE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MANUELL_AUSGELESENE")]
    MANUELL_AUSGELESENE,
}
