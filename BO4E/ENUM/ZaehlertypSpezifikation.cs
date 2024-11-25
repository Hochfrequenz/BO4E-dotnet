using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>
///     Bei diesem Enum handelt es sich die Abbildung von Zählertypen der Sparten Strom und Gas.
/// </summary>
public enum ZaehlertypSpezifikation
{
    /// <summary>Z01</summary>
    [EnumMember(Value = "EDL40")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("EDL40")]
    EDL40,

    /// <summary>Z02</summary>
    [EnumMember(Value = "EDL21")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("EDL21")]
    EDL21,

    /// <summary>Z03</summary>
    [EnumMember(Value = "SONSTIGER_EHZ")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SONSTIGER_EHZ")]
    SONSTIGER_EHZ,

    /// <summary>Z04</summary>
    [EnumMember(Value = "MME_STANDARD")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MME_STANDARD")]
    MME_STANDARD,

    /// <summary>Z05</summary>
    [EnumMember(Value = "MME_MEDA")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MME_MEDA")]
    MME_MEDA,
}
