using BO4E.meta;

namespace BO4E.ENUM
{

    /// <summary>
    /// Messwerterfassung
    /// EDIFACT values of <see cref="Messwerterfassung"/>
    /// </summary>
    /// <author>Hochfrequenz Unternehmensberatung GmbH</author>
    public enum MesswerterfassungEdi
    {
        /// <summary>AMR: fernauslesbare Zähler</summary>
        [Mapping(Messwerterfassung.FERNAUSLESBARE)]
        AMR,
        /// <summary>MMR: manuell ausgelesene Zähler</summary>
        [Mapping(Messwerterfassung.MANUELL_AUSGELESENE)]
        MMR,       
    }
}