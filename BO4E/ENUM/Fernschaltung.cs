using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Fernschaltung</summary>
public enum Fernschaltung
{
    /// <summary>Z06: vorhanden</summary>
    [EnumMember(Value = "VORHANDEN")]
    VORHANDEN,

    /// <summary>Z07: nicht vorhanden</summary>
    [EnumMember(Value = "NICHT_VORHANDEN")]
    NICHT_VORHANDEN
}