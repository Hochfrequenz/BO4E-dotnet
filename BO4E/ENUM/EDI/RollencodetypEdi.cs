using BO4E.meta;

namespace BO4E.ENUM.EDI
{
    /// <summary>
    ///     EDIFACT values of <see cref="Rollencodetyp" />
    /// </summary>
    /// <author>Hochfrequenz Unternehmensberatung GmbH</author>
    public enum RollencodetypEdi
    {
        /// <summary>DE, BDEW (Bundesverband der Energie und Wasserwirtschaft e.V.)</summary>
        [Mapping(Rollencodetyp.BDEW)] _293,

        /// <summary>DE, DVGW Service &amp; Consult GmbH</summary>
        [Mapping(Rollencodetyp.DVGW)] _332
    }
}