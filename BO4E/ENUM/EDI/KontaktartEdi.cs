using System;
using BO4E.meta;

namespace BO4E.ENUM.EDI
{
    /// <summary>
    /// EDIFACT values of <see cref="Kontaktart"/>
    /// </summary>
    public enum KontaktartEdi
    {
        /// <summary>
        /// Email
        /// </summary>
        [Mapping(Kontaktart.E_MAIL)]
        EM,
        /// <summary>
        /// Fax
        /// </summary>
        [Mapping(Kontaktart.FAX)]
        FX,
        /// <summary>
        /// Telefon
        /// </summary>
        [Mapping(Kontaktart.TELEFONAT)]
        TE,
        /// <summary>
        /// weiteres Telefon
        /// </summary>
        [Obsolete("No Mapping defined yet!")]
        AJ,
        /// <summary>
        /// Handy
        /// </summary>
        [Mapping(Kontaktart.SMS)]
        AL
    }
}