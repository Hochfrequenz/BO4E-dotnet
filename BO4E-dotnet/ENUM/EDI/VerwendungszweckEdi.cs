using BO4E.meta;

namespace BO4E.ENUM
{

    /// <summary>
    /// Verwendungungszweck der Werte Marktlokation
    /// EDIFACT values of <see cref="Verwendungszweck"/>
    /// </summary>
    /// <author>Hochfrequenz Unternehmensberatung GmbH</author>
    public enum VerwendungszweckEdi
    {
        /// <summary>Z84: Netznutzungsabrechnung</summary>
        [Mapping(Verwendungszweck.NETZNUTZUNGSABRECHNUNG)]
        Z84,
        /// <summary>Z85: Bilanzkreisabrechnung</summary>
        [Mapping(Verwendungszweck.BILANZKREISABRECHNUNG)]
        Z85,
        /// <summary>Z86: Mehrmindermbengenabrechnung</summary>
        [Mapping(Verwendungszweck.MEHRMINDERMBENGENABRECHNUNG)]
        Z86,
        /// <summary>Z47: Endkundenabrechnung</summary>
        [Mapping(Verwendungszweck.ENDKUNDENABRECHNUNG)]
        Z47,
    }

}