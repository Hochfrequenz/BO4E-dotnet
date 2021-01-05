using BO4E.meta;

namespace BO4E.ENUM.EDI
{
    /// <summary>
    /// EDIFACT values of <see cref="Netznutzungsabrechnungsvariante"/>
    /// </summary>
    /// <author>Hochfrequenz Unternehmensberatung GmbH</author>
    public enum NetznutzungsabrechnungsvarianteEdi
    {
        /// <summary>Z14: Arbeitspreis/Grundpreis</summary>
        [Mapping(Netznutzungsabrechnungsvariante.ARBEITSPREIS_GRUNDPREIS)]
        Z14,

        /// <summary>Z15: Arbeitspreis/Leistungspreis</summary>
        [Mapping(Netznutzungsabrechnungsvariante.ARBEITSPREIS_LEISTUNGSPREIS)]
        Z15
    }
}
