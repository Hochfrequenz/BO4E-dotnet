using System;

namespace BO4E.meta
{
    /// <summary>
    /// Describes in what sense / with which intensions / why a non-conformance with the standardised BO4E (as approved and published by the "Interessensgemeinschaft Geschäftsobjekte Energiewirtschaft e.V") was introduced in this implementation.
    /// </summary>
    /// <seealso cref="NonOfficialAttribute"/>
    public enum NonOfficialCategory
    {
        /// <summary>
        /// none of the other reasons apply
        /// </summary>
        [Obsolete("Please consider adding your reason to the BO4E.meta.NonOfficialCategory enum")] 
        UNSPECIFIED,
        /// <summary>
        /// an information (probably mostly in ENUMs) is not yet included in the official BO4E standard and hereby added to our implementation
        /// </summary>
        MISSING,
        /// <summary>
        /// a field or information is necessary to represent (German) regulatory requirements but is not (yet) part of the official BO4E standard
        /// </summary>
        REGULATORY_REQUIREMENTS,
        /// <summary>
        /// an information or field is no longer necessary or outdated (please use <see cref="System.ObsoleteAttribute"/> too). Hochfrequenz favours removal of this field from the official BO4E standard.
        /// </summary>
        [Obsolete("Hochfrequenz favours the removal of this field/property from BO4E.")]
        PROPOSED_DELETION,
        /// <summary>
        /// a field or information is necessary to represent requirements of a customer but is not (yet) part of the official BO4E standard
        /// </summary>
        CUSTOMER_REQUIREMENTS
    }
}
