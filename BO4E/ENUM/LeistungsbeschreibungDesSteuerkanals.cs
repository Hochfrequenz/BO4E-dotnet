using System.Runtime.Serialization;
using BO4E.meta;

namespace BO4E.ENUM;

/// <summary>
/// Welche Funktionen der Steuerkanal einer <see cref="BO.SteuerbareRessource"/> bereitstsellt.
/// </summary>
[NonOfficial(NonOfficialCategory.MISSING)]
public enum SteuerkanalsLeistungsbeschreibung
{
    /// <summary>
    /// AN/AUS
    /// </summary>
    /// <remarks>EDIFACT : CAV+ZF2:Z14</remarks>
    [EnumMember(Value = "AN_AUS")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("AN_AUS")]
    AN_AUS,

    /// <summary>
    /// GESTUFT
    /// </summary>
    /// <remarks>EDIFACT : CAV+ZF2:Z15</remarks>
    [EnumMember(Value = "GESTUFT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GESTUFT")]
    GESTUFT,
}
