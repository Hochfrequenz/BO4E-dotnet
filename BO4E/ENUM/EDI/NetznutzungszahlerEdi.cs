using BO4E.meta;

namespace BO4E.ENUM.EDI
{
    /// <summary>
    ///     EDIFACT values of <see cref="Netznutzungszahler" />
    /// </summary>
    /// <author>Hochfrequenz Unternehmensberatung GmbH</author>
    public enum NetznutzungszahlerEdi
    {
        /// <summary>Z10: Kunde</summary>
        [Mapping(Netznutzungszahler.KUNDE)] Z10,

        /// <summary>Z11: Lieferant</summary>
        [Mapping(Netznutzungszahler.LIEFERANT)]
        Z11
    }
}