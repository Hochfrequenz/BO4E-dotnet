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
        [Mapping(Netznutzungsabrechnungsvariante.Arbeitspreis_Grundpreis)]
        Z14,

        /// <summary>Z15: Arbeitspreis/Leistungspreis</summary>
        [Mapping(Netznutzungsabrechnungsvariante.Arbeitspreis_Leistungspreis)]
        Z15,
    }
}
