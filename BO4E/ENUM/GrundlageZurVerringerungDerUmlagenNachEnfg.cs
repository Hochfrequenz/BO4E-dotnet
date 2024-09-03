using BO4E.meta;
using System.Runtime.Serialization;

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
    KUNDE_ERFUELLT_VORAUSSETZUNG,

    /// <summary> Kunde erfüllt die Voraussetzung nach EnFG nicht </summary>
    /// <remarks>ZG0</remarks>
    [EnumMember(Value = "KUNDE_ERFUELLT_VORAUSSETZUNG_NICHT")]
    KUNDE_ERFUELLT_VORAUSSETZUNG_NICHT,

    /// <summary> Keine Angabe, da Marktlokation die Voraussetzung zur Verringerung der Umlagen nach EnFG nicht erfüllt </summary>
    /// <remarks>ZG1</remarks>
    [EnumMember(Value = "KEINE_ANGABE")]
    KEINE_ANGABE,
}