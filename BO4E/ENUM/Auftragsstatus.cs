using BO4E.meta;
using System.Runtime.Serialization;

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
    GESCHEITERT,

    /// <summary>
    /// Der Auftrag wurde erfolgreich bearbeitet
    /// </summary>
    /// <remarks>EDIFACT DE4405: Z14</remarks>
    [EnumMember(Value = "ERFOLGREICH")]
    ERFOLGREICH,

    /// <summary>
    /// Der Auftrag ist geplant
    /// </summary>
    /// <remarks>EDIFACT DE4405: Z17</remarks>
    [EnumMember(Value = "GEPLANT")]
    GEPLANT,

    /// <summary>
    /// Dem Auftrag wurde zugestimmmt (aber noch nicht durchgeführt)
    /// </summary>
    /// <remarks>EDIFACT DE4405: Z30</remarks>
    [EnumMember(Value = "ZUGESTIMMT")]
    ZUGESTIMMT,

    /// <summary>
    /// Dem Auftrag wurde widersprochen
    /// </summary>
    /// <remarks>EDIFACT DE4405: Z31</remarks>
    [EnumMember(Value = "WIDERSPROCHEN")]
    WIDERSPROCHEN,

    /// <summary>
    /// Der Auftrag wurde abgelehnt
    /// </summary>
    /// <remarks>EDIFACT DE4405: Z32</remarks>
    [EnumMember(Value = "ABGELEHNT")]
    ABGELEHNT,
}