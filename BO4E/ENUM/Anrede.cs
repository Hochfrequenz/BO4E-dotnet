#nullable enable
using System;
using System.Runtime.Serialization;
using BO4E.meta;
using ProtoBuf;

namespace BO4E.ENUM;

/// <summary>Übersicht möglicher Anreden, z.B. eines Geschäftspartners.</summary>
public enum Anrede
{
    /// <summary>Herr</summary>
    [EnumMember(Value = "HERR")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("HERR")]
    HERR,

    /// <summary>Frau</summary>
    [EnumMember(Value = "FRAU")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("FRAU")]
    FRAU,

    /// <summary>Eheleute</summary>
    [EnumMember(Value = "EHELEUTE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("EHELEUTE")]
    EHELEUTE,

    /// <summary>Firma</summary>
    [EnumMember(Value = "FIRMA")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("FIRMA")]
    FIRMA,

    /// <summary>Individuell festgelegt</summary>
    [EnumMember(Value = "INDIVIDUELL")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("INDIVIDUELL")]
    INDIVIDUELL,

    /// <summary>
    ///     Familien
    /// </summary>
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    [EnumMember(Value = "FAMILIE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("FAMILIE")]
    FAMILIE,

    /// <summary>
    ///     Erbengemeinschaft
    /// </summary>
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    [EnumMember(Value = "ERBENGEMEINSCHAFT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ERBENGEMEINSCHAFT")]
    ERBENGEMEINSCHAFT,

    /// <summary>
    ///     WG
    /// </summary>
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    [EnumMember(Value = "WOHNGEMEINSCHAFT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("WOHNGEMEINSCHAFT")]
    WOHNGEMEINSCHAFT,

    /// <summary>
    ///     Grundstückgemeinschaft
    /// </summary>
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    [EnumMember(Value = "GRUNDSTUECKGEMEINSCHAFT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GRUNDSTUECKGEMEINSCHAFT")]
    GRUNDSTUECKGEMEINSCHAFT,

    /// <summary>
    ///     Doktor
    /// </summary>
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    [Obsolete("Use BO4E.ENUM.Titel instead", true)]
    [ProtoEnum(Name = nameof(Anrede) + "_" + "DR")]
    [EnumMember(Value = "DR")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("DR")]
    DR,
}
