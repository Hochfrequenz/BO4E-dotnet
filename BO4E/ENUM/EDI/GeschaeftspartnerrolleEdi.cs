using System;
using BO4E.meta;

namespace BO4E.ENUM.EDI
{
    /// <summary>
    ///     EDIFACT values of <see cref="Geschaeftspartnerrolle" />.
    /// </summary>
    public enum GeschaeftspartnerrolleEdi
    {
        /// <summary>
        ///     Lieferant / SUpplier
        /// </summary>
        [Mapping(Geschaeftspartnerrolle.LIEFERANT)]
        SU,

        /// <summary>
        ///     Messstellenbetreiber / Dienstleister
        /// </summary>
        [Mapping(Geschaeftspartnerrolle.DIENSTLEISTER)]
        DEB,

        /// <summary>
        ///     Letztverbraucher / Kunde
        /// </summary>
        [Mapping(Geschaeftspartnerrolle.KUNDE)]
        UD,

        /// <summary>
        ///     Absender / Marktpartner
        /// </summary>
        [Mapping(Geschaeftspartnerrolle.MARKTPARTNER)]
        [Obsolete("Not biunique!")]
        MS,

        /// <summary>
        ///     Empfänger / Marktpartner
        /// </summary>
        [Mapping(Geschaeftspartnerrolle.MARKTPARTNER)]
        [Obsolete("Not biunique!")]
        MR,

        /// <summary>
        ///     andere zugehörige Partei / Interessent
        /// </summary>
        [Mapping(Geschaeftspartnerrolle.INTERESSENT)]
        VY
    }
}