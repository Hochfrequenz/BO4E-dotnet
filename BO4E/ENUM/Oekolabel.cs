#nullable enable
using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Aufzählung der Labels für Öko-Strom von verschiedenen Herausgebern.</summary>
public enum Oekolabel
{
    /// <summary>energreen (durch Gruener Strom Label)</summary>
    [EnumMember(Value = "GASGREEN_GRUENER_STROM")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GASGREEN_GRUENER_STROM")]
    GASGREEN_GRUENER_STROM,

    /// <summary>gasgreen</summary>
    [EnumMember(Value = "GASGREEN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GASGREEN")]
    GASGREEN,

    /// <summary>Gruener Strom Label Gold</summary>
    [EnumMember(Value = "GRUENER_STROM_GOLD")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GRUENER_STROM_GOLD")]
    GRUENER_STROM_GOLD,

    /// <summary>Gruener Strom Label Silber</summary>
    [EnumMember(Value = "GRUENER_STROM_SILBER")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GRUENER_STROM_SILBER")]
    GRUENER_STROM_SILBER,

    /// <summary>Gruener Strom Label</summary>
    [EnumMember(Value = "GRUENER_STROM")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GRUENER_STROM")]
    GRUENER_STROM,

    /// <summary>Gruenes Gas Label</summary>
    [EnumMember(Value = "GRUENES_GAS")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GRUENES_GAS")]
    GRUENES_GAS,

    /// <summary>NaturWatt Strom</summary>
    [EnumMember(Value = "NATURWATT_STROM")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("NATURWATT_STROM")]
    NATURWATT_STROM,

    /// <summary>ok-Power</summary>
    [EnumMember(Value = "OK_POWER")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("OK_POWER")]
    OK_POWER,

    /// <summary>RenewablePLUS</summary>
    [EnumMember(Value = "RENEWABLE_PLUS")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("RENEWABLE_PLUS")]
    RENEWABLE_PLUS,

    /// <summary>Watergreen</summary>
    [EnumMember(Value = "WATERGREEN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("WATERGREEN")]
    WATERGREEN,

    /// <summary>Watergreen+</summary>
    [EnumMember(Value = "WATERGREEN_PLUS")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("WATERGREEN_PLUS")]
    WATERGREEN_PLUS,
}
