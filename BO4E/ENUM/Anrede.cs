using System;
using System.Runtime.Serialization;

using BO4E.meta;

using Newtonsoft.Json.Linq;

using ProtoBuf;

namespace BO4E.ENUM
{
    /// <summary>Übersicht möglicher Anreden, z.B. eines Geschäftspartners.</summary>
    public enum Anrede
    {
        /// <summary>Herr</summary>
        [EnumMember(Value = "HERR")]
        HERR,

        /// <summary>Frau</summary>
        [EnumMember(Value = "FRAU")]
        FRAU,

        /// <summary>Eheleute</summary>
        [EnumMember(Value = "EHELEUTE")]
        EHELEUTE,

        /// <summary>Firma</summary>
        [EnumMember(Value = "FIRMA")]
        FIRMA,

        /// <summary>Individuell festgelegt</summary>
        [EnumMember(Value = "INDIVIDUELL")]
        INDIVIDUELL,

        /// <summary>
        ///     Familien
        /// </summary>
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [EnumMember(Value = "FAMILIE")]
        FAMILIE,

        /// <summary>
        ///     Erbengemeinschaft
        /// </summary>
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [EnumMember(Value = "ERBENGEMEINSCHAFT")]
        ERBENGEMEINSCHAFT,

        /// <summary>
        ///     WG
        /// </summary>
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [EnumMember(Value = "WOHNGEMEINSCHAFT")]
        WOHNGEMEINSCHAFT,

        /// <summary>
        ///     Grundstückgemeinschaft
        /// </summary>
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [EnumMember(Value = "GRUNDSTUECKGEMEINSCHAFT")]
        GRUNDSTUECKGEMEINSCHAFT,

        /// <summary>
        ///     Doktor
        /// </summary>
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [Obsolete("Use BO4E.ENUM.Titel instead", true)]
        [ProtoEnum(Name = nameof(Anrede) + "_" + "DR")]
        [EnumMember(Value = "DR")]
        DR
    }
}