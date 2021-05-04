using System;
using BO4E.meta;
using ProtoBuf;

namespace BO4E.ENUM
{
    /// <summary>Übersicht möglicher Anreden, z.B. eines Geschäftspartners.</summary>
    public enum Anrede
    {
        /// <summary>Herr</summary>
        HERR,

        /// <summary>Frau</summary>
        FRAU,

        /// <summary>Eheleute</summary>
        EHELEUTE,

        /// <summary>Firma</summary>
        FIRMA,

        /// <summary>Individuell festgelegt</summary>
        INDIVIDUELL,

        /// <summary>
        ///     Familien
        /// </summary>
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        FAMILIE,

        /// <summary>
        ///     Erbengemeinschaft
        /// </summary>
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        ERBENGEMEINSCHAFT,

        /// <summary>
        ///     WG
        /// </summary>
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        WOHNGEMEINSCHAFT,

        /// <summary>
        ///     Grundstückgemeinschaft
        /// </summary>
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        GRUNDSTUECKGEMEINSCHAFT,

        /// <summary>
        ///     Doktor
        /// </summary>
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [Obsolete("Use BO4E.ENUM.Titel instead", true)]
        [ProtoEnum(Name = nameof(Anrede) + "_" + "DR")]
        DR
    }
}