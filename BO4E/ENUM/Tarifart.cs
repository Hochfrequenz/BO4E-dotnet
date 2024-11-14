using System.Runtime.Serialization;

namespace BO4E.ENUM;

/**
 * Die Tarifart wird verwendet zur Charakterisierung von Zählern und daraus
 * resultierenden Tarifen.
 */
public enum Tarifart
{
    /// <summary>Eintarif</summary>
    [EnumMember(Value = "EINTARIF")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("EINTARIF")]
    EINTARIF,

    /// <summary>Zweitarif</summary>
    [EnumMember(Value = "ZWEITARIF")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ZWEITARIF")]
    ZWEITARIF,

    /// <summary>Mehrtarif</summary>
    [EnumMember(Value = "MEHRTARIF")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MEHRTARIF")]
    MEHRTARIF,

    /// <summary>Smart Meter Tarif</summary>
    [EnumMember(Value = "SMART_METER")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SMART_METER")]
    SMART_METER,

    /// <summary>Leistungsgemessener Tarif</summary>
    [EnumMember(Value = "LEISTUNGSGEMESSEN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("LEISTUNGSGEMESSEN")]
    LEISTUNGSGEMESSEN,
}
