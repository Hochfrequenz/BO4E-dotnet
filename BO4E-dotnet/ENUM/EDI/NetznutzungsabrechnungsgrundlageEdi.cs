using BO4E.meta;

namespace BO4E.ENUM.EDI
{
    /// <summary>
    /// EDIFACT values of <see cref="Netznutzungsabrechnungsgrundlage"/>
    /// </summary>
    /// <author>Netznutzungsabrechnungsgrundlage</author>
    public enum NetznutzungsabrechnungsgrundlageEdi
    {
        /// <summary>Z12: Lieferschein</summary>
        [Mapping(Netznutzungsabrechnungsgrundlage.LIEFERSCHEIN)]
        Z12,

        /// <summary>Z13: Abweichend vertraglich mit Anschlussnutzer vereinbarte Grundlage</summary>
        [Mapping(Netznutzungsabrechnungsgrundlage.ABWEICHENDE_GRUNDLAGE)]
        Z13
    }
}
