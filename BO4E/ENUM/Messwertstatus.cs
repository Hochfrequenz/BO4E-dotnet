using BO4E.meta;

using System.Runtime.Serialization;

namespace BO4E.ENUM
{
    /// <summary>
    /// Gibt auskunft über die Gültigkeit des angegebenen Verbrauchswertes. Bildet MSCONS SG10 QTY 6063 ab. 
    /// </summary>
    public enum Messwertstatus
    {
        /// <summary> Wahrer Wert: 220 </summary>
        [EnumMember(Value = "ABGELESEN")]
        ABGELESEN,

        /// <summary> Ersatzwert: 67 </summary>
        [EnumMember(Value = "ERSATZWERT")]
        ERSATZWERT,

        /// <summary> Vorläufiger Wert: Z18 </summary>
        [EnumMember(Value = "VOLAEUFIGERWERT")]
        VOLAEUFIGERWERT,

        /// <summary> Angabe für Lieferschein: Z31 </summary>
        [NonOfficial(NonOfficialCategory.UNSPECIFIED)]
        [EnumMember(Value = "ANGABE_FUER_LIEFERSCHEIN")]
        ANGABE_FUER_LIEFERSCHEIN,

        /// <summary> Vorschlagswert: 201 </summary>
        [EnumMember(Value = "VORSCHLAGSWERT")]
        VORSCHLAGSWERT,

        /// <summary> Nicht verwendbarer Wert: 20 </summary>
        [EnumMember(Value = "NICHT_VERWENDBAR")]
        NICHT_VERWENDBAR,

        /// <summary> Prognosewert: 187 </summary>
        [EnumMember(Value = "PROGNOSEWERT")]
        PROGNOSEWERT,

        /// <summary> Energiemenge summiert: 79 </summary>
        [EnumMember(Value = "ENERGIEMENGESUMMIERT")]
        ENERGIEMENGESUMMIERT,

        /// <summary> Fehlender Wert: Z30 </summary>
        [EnumMember(Value = "FEHLT")]
        FEHLT,
    }
}