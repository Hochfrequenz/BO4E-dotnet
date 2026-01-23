#nullable enable
using System.Runtime.Serialization;
using ProtoBuf;

namespace BO4E.ENUM;

/// <summary>Zur Abbildung von Messgrössen und zur Verwendung in energiewirtschaftlichen Berechnungen.</summary>
public enum Bemessungsgroesse
{
    /// <summary>elektrische Wirkarbeit</summary>
    [ProtoEnum(Name = nameof(Bemessungsgroesse) + "_" + nameof(WIRKARBEIT_EL))]
    [EnumMember(Value = "WIRKARBEIT_EL")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("WIRKARBEIT_EL")]
    WIRKARBEIT_EL,

    /// <summary>elektrische Leistung</summary>
    [ProtoEnum(Name = nameof(Bemessungsgroesse) + "_" + nameof(LEISTUNG_EL))]
    [EnumMember(Value = "LEISTUNG_EL")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("LEISTUNG_EL")]
    LEISTUNG_EL,

    /// <summary>Blindarbeit kapazitiv</summary>
    [ProtoEnum(Name = nameof(Bemessungsgroesse) + "_" + nameof(BLINDARBEIT_KAP))]
    [EnumMember(Value = "BLINDARBEIT_KAP")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BLINDARBEIT_KAP")]
    BLINDARBEIT_KAP,

    /// <summary>Blindarbeit induktiv</summary>
    [ProtoEnum(Name = nameof(Bemessungsgroesse) + "_" + nameof(BLINDARBEIT_IND))]
    [EnumMember(Value = "BLINDARBEIT_IND")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BLINDARBEIT_IND")]
    BLINDARBEIT_IND,

    /// <summary>Blindleistung kapazitiv</summary>
    [ProtoEnum(Name = nameof(Bemessungsgroesse) + "_" + nameof(BLINDLEISTUNG_KAP))]
    [EnumMember(Value = "BLINDLEISTUNG_KAP")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BLINDLEISTUNG_KAP")]
    BLINDLEISTUNG_KAP,

    /// <summary>Blindleistung induktiv</summary>
    [ProtoEnum(Name = nameof(Bemessungsgroesse) + "_" + nameof(BLINDLEISTUNG_IND))]
    [EnumMember(Value = "BLINDLEISTUNG_IND")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BLINDLEISTUNG_IND")]
    BLINDLEISTUNG_IND,

    /// <summary>thermische Wirkarbeit</summary>
    [ProtoEnum(Name = nameof(Bemessungsgroesse) + "_" + nameof(WIRKARBEIT_TH))]
    [EnumMember(Value = "WIRKARBEIT_TH")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("WIRKARBEIT_TH")]
    WIRKARBEIT_TH,

    /// <summary>thermische Leistung</summary>
    [ProtoEnum(Name = nameof(Bemessungsgroesse) + "_" + nameof(LEISTUNG_TH))]
    [EnumMember(Value = "LEISTUNG_TH")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("LEISTUNG_TH")]
    LEISTUNG_TH,

    /// <summary>Volumen</summary>
    [ProtoEnum(Name = nameof(Bemessungsgroesse) + "_" + nameof(VOLUMEN))]
    [EnumMember(Value = "VOLUMEN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("VOLUMEN")]
    VOLUMEN,

    /// <summary>Volumenstrom (Volumen/Zeit)</summary>
    [ProtoEnum(Name = nameof(Bemessungsgroesse) + "_" + nameof(VOLUMENSTROM))]
    [EnumMember(Value = "VOLUMENSTROM")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("VOLUMENSTROM")]
    VOLUMENSTROM,

    /// <summary>Benutzungsdauer (Arbeit/Leistung)</summary>
    [ProtoEnum(Name = nameof(Bemessungsgroesse) + "_" + nameof(BENUTZUNGSDAUER))]
    [EnumMember(Value = "BENUTZUNGSDAUER")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BENUTZUNGSDAUER")]
    BENUTZUNGSDAUER,

    /// <summary>Darstellung einer Stückzahl</summary>
    [ProtoEnum(Name = nameof(Bemessungsgroesse) + "_" + nameof(ANZAHL))]
    [EnumMember(Value = "ANZAHL")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ANZAHL")]
    ANZAHL,
}
