using System.Runtime.Serialization;
using BO4E.meta;

namespace BO4E.ENUM;

/// <summary>
/// Auftragststatus (Planungsstatus in IFTSTA STS 4405 (21029) and Sperrauftragsstatus in IFTSTA STS 4405 (21039/21040))
/// Der Sperrauftragsstatus beschreibt den Status eines <see cref="BO.Sperrauftrag"/>s
/// </summary>
[NonOfficial(NonOfficialCategory.MISSING)]
public enum Auftragsstatus
{
    /// <summary>
    /// Der Auftrag ist gescheitert
    /// </summary>
    /// <remarks>EDIFACT DE4405: Z13</remarks>
    [EnumMember(Value = "GESCHEITERT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GESCHEITERT")]
    GESCHEITERT,

    /// <summary>
    /// Der Auftrag wurde erfolgreich bearbeitet
    /// </summary>
    /// <remarks>EDIFACT DE4405: Z14</remarks>
    [EnumMember(Value = "ERFOLGREICH")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ERFOLGREICH")]
    ERFOLGREICH,

    /// <summary>
    /// Der Auftrag ist geplant
    /// </summary>
    /// <remarks>EDIFACT DE4405: Z17</remarks>
    [EnumMember(Value = "GEPLANT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GEPLANT")]
    GEPLANT,

    /// <summary>
    /// Dem Auftrag wurde zugestimmmt (aber noch nicht durchgeführt)
    /// </summary>
    /// <remarks>EDIFACT DE4405: Z30</remarks>
    [EnumMember(Value = "ZUGESTIMMT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ZUGESTIMMT")]
    ZUGESTIMMT,

    /// <summary>
    /// Dem Auftrag wurde widersprochen
    /// </summary>
    /// <remarks>EDIFACT DE4405: Z31</remarks>
    [EnumMember(Value = "WIDERSPROCHEN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("WIDERSPROCHEN")]
    WIDERSPROCHEN,

    /// <summary>
    /// Der Auftrag wurde abgelehnt
    /// </summary>
    /// <remarks>EDIFACT DE4405: Z32</remarks>
    [EnumMember(Value = "ABGELEHNT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ABGELEHNT")]
    ABGELEHNT,
}
