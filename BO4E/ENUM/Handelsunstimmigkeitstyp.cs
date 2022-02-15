using BO4E.meta;

namespace BO4E.ENUM
{
    /// <summary>
    /// Gibt den Typ der Handelsunstimmigkeit an (COMDIS DOC 1001)
    /// </summary>
    [NonOfficial(NonOfficialCategory.MISSING)]
    public enum Handelsunstimmigkeitstyp
    {
        /// <summary> HANDELSRECHNUNG </summary>
        /// <remarks>380</remarks>
        HANDELSRECHNUNG,

        /// <summary> LIEFERSCHEIN_HANDELSUNSTIMMIGKEITSTYP </summary>
        /// <remarks>270</remarks>
        LIEFERSCHEIN_HANDELSUNSTIMMIGKEITSTYP,

        /// <summary> LIEFERSCHEIN_GRUND_ARBEITSPREIS</summary>
        /// <remarks>Z41</remarks>
        LIEFERSCHEIN_GRUND_ARBEITSPREIS,

        /// <summary> LIEFERSCHEIN_ARBEITS_LEISTUNGSPREIS </summary>
        /// <remarks>Z42</remarks>
        LIEFERSCHEIN_ARBEITS_LEISTUNGSPREIS,

    }
}