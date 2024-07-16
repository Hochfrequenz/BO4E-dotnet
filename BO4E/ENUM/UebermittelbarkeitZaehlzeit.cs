using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Übermittelbarkeit der ausgerollten Zählzeit</summary>
public enum UebermittelbarkeitZaehlzeit
{
    /// <summary>Der LF bzw. NB übermittelt die ausgerollte Zählzeit per EDIFACT mit dem Nachrichtenformat UTILTS.</summary>
    [EnumMember(Value = "ELEKTRONISCH")]
    ELEKTRONISCH,

    /// <summary>Der NB übermittelt die ausgerollte Zählzeit auf einem bilateral vereinbarten Weg. Dieser Weg wird hier nicht weiter beschrieben</summary>
    [EnumMember(Value = "NICHT_ELEKTRONISCH")]
    NICHT_ELEKTRONISCH,
}
