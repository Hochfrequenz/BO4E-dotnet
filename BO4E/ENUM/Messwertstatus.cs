using BO4E.meta;

namespace BO4E.ENUM
{
    /// <summary>
    /// Gibt auskunft über die Gültigkeit des angegebenen Verbrauchswertes. Bildet MSCONS SG10 QTY 6063 ab. 
    /// </summary>
    public enum Messwertstatus
    {
        /// <summary> Wahrer Wert: 220 </summary>
        ABGELESEN,

        /// <summary> Ersatzwert: 67 </summary>
        ERSATZWERT,

        /// <summary> Vorläufiger Wert: Z18 </summary>
        VOLAEUFIGERWERT,

        /// <summary> Angabe für Lieferschein: Z31 </summary>
        [NonOfficial(NonOfficialCategory.UNSPECIFIED)]
        ANGABE_FUER_LIEFERSCHEIN,

        /// <summary> Vorschlagswert: 201 </summary>
        VORSCHLAGSWERT,

        /// <summary> Nicht verwendbarer Wert: 20 </summary>
        NICHT_VERWENDBAR,

        /// <summary> Prognosewert: 187 </summary>
        PROGNOSEWERT,

        /// <summary> Energiemenge summiert: 79 </summary>
        ENERGIEMENGESUMMIERT,

        /// <summary> Fehlender Wert: Z30 </summary>
        FEHLT
    }
}