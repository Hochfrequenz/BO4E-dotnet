using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Auflistung möglicher Netzebenen innerhalb der Energiearten Strom und Gas.</summary>
public enum Netzebene
{
    /// <summary>Niederspannung</summary>
    [EnumMember(Value = "NSP")]
    NSP,

    /// <summary>Mittelspannung</summary>
    [EnumMember(Value = "MSP")]
    MSP,

    /// <summary>Hochspannung</summary>
    [EnumMember(Value = "HSP")]
    HSP,

    /// <summary>Hoechstspannung</summary>
    [EnumMember(Value = "HSS")]
    HSS,

    /// <summary>MS/NS Umspannung</summary>
    [EnumMember(Value = "MSP_NSP_UMSP")]
    MSP_NSP_UMSP,

    /// <summary>HS/MS Umspannung</summary>
    [EnumMember(Value = "HSP_MSP_UMSP")]
    HSP_MSP_UMSP,

    /// <summary>HOES/HS Umspannung</summary>
    [EnumMember(Value = "HSS_HSP_UMSP")]
    HSS_HSP_UMSP,

    /// <summary>Hochdruck</summary>
    [EnumMember(Value = "HD")]
    HD,

    /// <summary>Mitteldruck</summary>
    [EnumMember(Value = "MD")]
    MD,

    /// <summary>Niederdruck</summary>
    [EnumMember(Value = "ND")]
    ND,
}
