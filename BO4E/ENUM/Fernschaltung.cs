#nullable enable
using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Fernschaltung</summary>
public enum Fernschaltung
{
    /// <summary>Z06: vorhanden</summary>
    [EnumMember(Value = "VORHANDEN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("VORHANDEN")]
    VORHANDEN,

    /// <summary>Z07: nicht vorhanden</summary>
    [EnumMember(Value = "NICHT_VORHANDEN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("NICHT_VORHANDEN")]
    NICHT_VORHANDEN,
}
