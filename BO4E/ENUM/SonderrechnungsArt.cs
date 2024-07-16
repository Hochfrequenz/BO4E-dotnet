using ProtoBuf;

using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary> </summary>
public enum Sonderrechnungsart
{
    /// <summary>
    ///  Z01: Konzessionsabgabe (Testat)
    /// </summary>
    [EnumMember(Value = "KONZESSIONSABGABE_TESTAT")]
    KONZESSIONSABGABE_TESTAT,
    /// <summary>
    /// Z02: Individuelle Vereinbarung für atypische und energieintensive Netznutzung
    /// </summary>
    [EnumMember(Value = "INDIVIDUELL_ATYPISCH")]
    INDIVIDUELL_ATYPISCH,
    /// <summary>
    /// Z03: Individuelle Vereinbarung für singuläre Netznutzung
    /// </summary>
    [EnumMember(Value = "INDIVIDUELL_SINGULAER")]
    INDIVIDUELL_SINGULAER,
    /// <summary>
    /// Z04: KWKG-Umlage
    /// </summary>
    [EnumMember(Value = "KWKG_UMLAGE")]
    KWKG_UMLAGE,
    /// <summary>
    /// Z05: Offshore-Netzumlage
    /// </summary>
    [ProtoEnum(Name = nameof(Sonderrechnungsart) + "_" + nameof(OFFSHORE_UMLAGE))]
    [EnumMember(Value = "OFFSHORE_UMLAGE")]
    OFFSHORE_UMLAGE,
    /// <summary>
    /// Z06: § 19 StromNEV-Umlage
    /// </summary>
    [EnumMember(Value = "P19_STROM_NEV_UMLAGE")]
    P19_STROM_NEV_UMLAGE,
    /// <summary>
    /// Z07: §18 AbLaV
    /// </summary>
    [EnumMember(Value = "P18_ABLAV")]
    P18_ABLAV,
    /// <summary>
    /// Z08: Konzessionsabgabe (Wechsel auf Lastgangmessung)
    /// </summary>
    [EnumMember(Value = "KONZESSIONSABGABE_WECHSEL_RLM")]
    KONZESSIONSABGABE_WECHSEL_RLM,
    /// <summary>
    /// Z09: Privilegierung nach EnFG
    /// </summary>
    [EnumMember(Value = "PRIVILEGIERUNG_NACH_ENFG")]
    PRIVILEGIERUNG_NACH_ENFG,

}
