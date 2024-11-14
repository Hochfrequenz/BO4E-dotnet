using System.Runtime.Serialization;
using BO4E.meta;

namespace BO4E.ENUM;

/// <summary>
/// Grundlage zur Verringerung der Umlagen nach EnFG (UTILMD Strom)
/// </summary>
[NonOfficial(NonOfficialCategory.MISSING)]
public enum GrundlageZurVerringerungDerUmlagenNachEnfg
{
    /// <summary> Kunde erfüllt die Voraussetzung nach EnFG </summary>
    /// <remarks>ZF9</remarks>
    [EnumMember(Value = "KUNDE_ERFUELLT_VORAUSSETZUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("KUNDE_ERFUELLT_VORAUSSETZUNG")]
    KUNDE_ERFUELLT_VORAUSSETZUNG,

    /// <summary> Kunde erfüllt die Voraussetzung nach EnFG nicht </summary>
    /// <remarks>ZG0</remarks>
    [EnumMember(Value = "KUNDE_ERFUELLT_VORAUSSETZUNG_NICHT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("KUNDE_ERFUELLT_VORAUSSETZUNG_NICHT")]
    KUNDE_ERFUELLT_VORAUSSETZUNG_NICHT,

    /// <summary> Keine Angabe, da Marktlokation die Voraussetzung zur Verringerung der Umlagen nach EnFG nicht erfüllt </summary>
    /// <remarks>ZG1</remarks>
    [EnumMember(Value = "KEINE_ANGABE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("KEINE_ANGABE")]
    KEINE_ANGABE,
}
