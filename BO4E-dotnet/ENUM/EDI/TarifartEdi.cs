using BO4E.meta;

namespace BO4E.ENUM.EDI
{
    /// <summary>
    /// EDIFACT values of <see cref="Tarifart"/>
    /// </summary>
    /// <author>Hochfrequenz Unternehmensberatung GmbH</author>
    public enum TarifartEdi
    {
        /// <summary>Eintarif</summary>
        [Mapping(Tarifart.EINTARIF)]
        ETZ,
        /// <summary>Zweitarif</summary>
        [Mapping(Tarifart.ZWEITARIF)]
        ZTZ,
        /// <summary>Mehrtarif</summary>
        [Mapping(Tarifart.MEHRTARIF)]
        NTZ
    }
}
