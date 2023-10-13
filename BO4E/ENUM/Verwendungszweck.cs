using System;
using System.Runtime.Serialization;

namespace BO4E.ENUM
{
    /// <summary>Verwendungungszweck der Werte Marktlokation</summary>
    public enum Verwendungszweck
    {
        /// <summary>Z84: Netznutzungsabrechnung</summary>
        [EnumMember(Value = "NETZNUTZUNGSABRECHNUNG")]
        NETZNUTZUNGSABRECHNUNG,

        /// <summary>Z85: Bilanzkreisabrechnung</summary>
        [EnumMember(Value = "BILANZKREISABRECHNUNG")]
        BILANZKREISABRECHNUNG,

        /// <summary>Z86: Mehrmindermengenabrechnung</summary>
        [EnumMember(Value = "MEHRMINDERMENGENABRECHNUNG")]
        MEHRMINDERMENGENABRECHNUNG,

        /// <summary>Z47: Endkundenabrechnung</summary>
        [EnumMember(Value = "ENDKUNDENABRECHNUNG")]
        ENDKUNDENABRECHNUNG,

        /// <summary>ZD1: Blindarbeitabrechnung / Betriebsführun</summary>
        [EnumMember(Value = "BLINDARBEITABRECHNUNG_BETRIEBSFÜHRUN")]
        BLINDARBEITABRECHNUNG_BETRIEBSFÜHRUN,

        /// <summary>
        /// Übermittlung an das Herkunftsnachweisregister (HKNR)
        /// </summary>
        /// <remarks>Z92</remarks>
        [EnumMember(Value = "UEBERMITTLUNG_AN_DAS_HKNR")]
        UEBERMITTLUNG_AN_DAS_HKNR,

        /// <summary>
        /// Zur Ermittlung der Ausgeglichenheit von Bilanzkreisen
        ///</summary>
        /// <remarks>ZB5</remarks>
        [EnumMember(Value = "ERMITTLUNG_AUSGEGLICHENHEIT_BILANZKREIS")]
        ERMITTLUNG_AUSGEGLICHENHEIT_BILANZKREIS,

        /// <summary>
        /// <inheritdoc cref="MEHRMINDERMENGENABRECHNUNG"/>
        /// </summary>
        [Obsolete("This is only to keep the library backwards compatible")]
        [EnumMember(Value = "MEHRMINDERMBENGENABRECHNUNG")]
        MEHRMINDERMBENGENABRECHNUNG = MEHRMINDERMENGENABRECHNUNG,
    }
}
