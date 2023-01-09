using System;
using System.Runtime.Serialization;

namespace BO4E.meta
{
    /// <summary>
    ///     Describes in what sense / with which intensions / why a non-conformance with the standardised BO4E (as approved and
    ///     published by the "Interessensgemeinschaft Geschäftsobjekte Energiewirtschaft e.V") was introduced in this
    ///     implementation.
    /// </summary>
    /// <seealso cref="NonOfficialAttribute" />
    public enum NonOfficialCategory
    {
        /// <summary>
        ///     none of the other reasons apply
        /// </summary>
        [EnumMember(Value = "UNSPECIFIED")]
        UNSPECIFIED,

        /// <summary>
        ///     an information (probably mostly in ENUMs) is not yet included in the official BO4E standard and hereby added to our
        ///     implementation
        /// </summary>
        [EnumMember(Value = "MISSING")]
        MISSING,

        /// <summary>
        ///     a field or information is necessary to represent (German) regulatory requirements but is not (yet) part of the
        ///     official BO4E standard
        /// </summary>
        [EnumMember(Value = "REGULATORY_REQUIREMENTS")]
        REGULATORY_REQUIREMENTS,

        /// <summary>
        ///     an information or field is no longer necessary or outdated (please use <see cref="System.ObsoleteAttribute" />
        ///     too). Hochfrequenz favors removal of this field from the official BO4E standard.
        /// </summary>
        [Obsolete("Hochfrequenz favours the removal of this field/property from BO4E.")]
        [EnumMember(Value = "PROPOSED_DELETION")]
        PROPOSED_DELETION,

        /// <summary>
        ///     a field or information is necessary to represent requirements of a customer but is not (yet) part of the official
        ///     BO4E standard
        /// </summary>
        [EnumMember(Value = "CUSTOMER_REQUIREMENTS")]
        CUSTOMER_REQUIREMENTS,
    }
}