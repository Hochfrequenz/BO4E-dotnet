using System.Runtime.Serialization;

namespace BO4E.ENUM
{
    /// <summary> </summary>
    public enum Rechnungstyp
    {
        /// <summary>Abschlagsrechnung</summary>
        [EnumMember(Value = "ABSCHLAGSRECHNUNG")]
        ABSCHLAGSRECHNUNG,

        /// <summary>Turnusrechnung</summary>
        [EnumMember(Value = "TURNUSRECHNUNG")]
        TURNUSRECHNUNG,

        /// <summary>Monatsrechnung</summary>
        [EnumMember(Value = "MONATSRECHNUNG")]
        MONATSRECHNUNG,

        /// <summary>Rechnung für WiM</summary>
        [EnumMember(Value = "WIMRECHNUNG")]
        WIMRECHNUNG,

        /// <summary>Zwischenrechnung</summary>
        [EnumMember(Value = "ZWISCHENRECHNUNG")]
        ZWISCHENRECHNUNG,

        /// <summary>Integrierte 13. Rechnung</summary>
        [EnumMember(Value = "INTEGRIERTE_13TE_RECHNUNG")]
        INTEGRIERTE_13TE_RECHNUNG,

        /// <summary>Zusätzliche 13. Rechnung</summary>
        [EnumMember(Value = "ZUSAETZLICHE_13TE_RECHNUNG")]
        ZUSAETZLICHE_13TE_RECHNUNG,

        /// <summary>Mehr/Mindermengenabrechnung</summary>
        [EnumMember(Value = "MEHRMINDERMENGENRECHNUNG")]
        MEHRMINDERMENGENRECHNUNG,

        /// <summary>Abschlussrechnung</summary>
        [EnumMember(Value = "ABSCHLUSSRECHNUNG")]
        ABSCHLUSSRECHNUNG,
        /// <summary>Rechnung für Messstellenbetrieb</summary>
        [EnumMember(Value = "MSBRECHNUNG")]
        MSBRECHNUNG,
        /// <summary>Kapazitätsrechnung</summary>
        [EnumMember(Value = "KAPAZITAETSRECHNUNG")]
        KAPAZITAETSRECHNUNG,
        /// <summary>Rechnung für Sperren und Wiederinbetriebnahme</summary>
        [EnumMember(Value = "SPERRUNG_INBETRIEBNAHME")]
        SPERRUNG_INBETRIEBNAHME,
        /// <summary>
        /// Verzugskostenrechnung
        /// </summary>
        [EnumMember(Value = "VERZUGSKOSTEN")]
        VERZUGSKOSTEN,
        /// <summary>
        /// Blindarbeitsrechnung
        /// </summary>
        [EnumMember(Value = "BLINDARBEIT")]
        BLINDARBEIT,
        /// <summary>
        /// Sonderrechnung
        /// </summary>
        [EnumMember(Value = "SONDERRECHNUNG")]
        SONDERRECHNUNG,
    }
}