using BO4E.meta;

namespace BO4E.ENUM.EDI
{
    /// <summary>
    /// Fernschaltung
    /// EDIFACT values of <see cref="Fernschaltung"/>
    /// </summary>
    /// <author>Hochfrequenz Unternehmensberatung GmbH</author>
    public enum FernschaltungEdi
    {
        /// <summary>Z06: vorhanden</summary>
        [Mapping(Fernschaltung.VORHANDEN)]
        Z06,
        /// <summary>Z07: nicht vorhanden</summary>
        [Mapping(Fernschaltung.NICHT_VORHANDEN)]
        Z07
    }
}