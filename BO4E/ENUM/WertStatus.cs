using BO4E.meta;

namespace BO4E.ENUM
{
    /// <summary>
    /// Gibt auskunft über die Gültigkeit des angegebenen Verbrauchswertes. Bildet MSCONS SG10 QTY 6063 ab. 
    /// </summary>
    [NonOfficial(NonOfficialCategory.UNSPECIFIED)]
    public enum WertStatus
    {
        /// <summary> Wahrer Wert: 220 </summary>
        WAHRER_WERT,

        /// <summary> Ersatzwert: 67 </summary>
        ERSATZWERT,

        /// <summary> Vorläufiger Wert: Z18 </summary>
        VORLAUUFIGER_WERT,

        /// <summary> Angabe für Lieferschein: Z31 </summary>
        ANGABE_FUER_LIEFERSCHEIN,

        /// <summary> Vorschlagswert: 201 </summary>
        VORSCHLAGSWERT,

        /// <summary> Nicht verwendbarer Wert: 20 </summary>
        NICHT_VERWENDBARER_WERT,

        /// <summary> Prognosewert: 187 </summary>
        PROGNOSEWERT,

        /// <summary> Energiemenge summiert: 79 </summary>
        ENERGIEMENGE_SUMMIERT,
    }
}