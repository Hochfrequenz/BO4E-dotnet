using System.Runtime.Serialization;
using BO4E.meta;

namespace BO4E.ENUM;

/// <summary>
/// Gibt den Typ der Handelsunstimmigkeit an (COMDIS DOC 1001)
/// </summary>
[NonOfficial(NonOfficialCategory.MISSING)]
public enum Handelsunstimmigkeitstyp
{
    /// <summary> HANDELSRECHNUNG </summary>
    /// <remarks>380</remarks>
    [EnumMember(Value = "HANDELSRECHNUNG")]
    HANDELSRECHNUNG,

    /// <summary> LIEFERSCHEIN_HANDELSUNSTIMMIGKEITSTYP </summary>
    /// <remarks>270</remarks>
    [EnumMember(Value = "LIEFERSCHEIN_HANDELSUNSTIMMIGKEITSTYP")]
    LIEFERSCHEIN_HANDELSUNSTIMMIGKEITSTYP,

    /// <summary> LIEFERSCHEIN_GRUND_ARBEITSPREIS</summary>
    /// <remarks>Z41</remarks>
    [EnumMember(Value = "LIEFERSCHEIN_GRUND_ARBEITSPREIS")]
    LIEFERSCHEIN_GRUND_ARBEITSPREIS,

    /// <summary> LIEFERSCHEIN_ARBEITS_LEISTUNGSPREIS </summary>
    /// <remarks>Z42</remarks>
    [EnumMember(Value = "LIEFERSCHEIN_ARBEITS_LEISTUNGSPREIS")]
    LIEFERSCHEIN_ARBEITS_LEISTUNGSPREIS,
}
