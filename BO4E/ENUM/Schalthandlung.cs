using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>
/// Angabe der Schalthandlung zu einem Schaltzeitänderungszeitpunkt
/// </summary>
public enum Schalthandlung
{
    /// <summary>
    /// Leistung an der Lokation an (ZF4)
    /// </summary>
    [EnumMember(Value = "LEISTUNG_LOKATION_AN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("LEISTUNG_LOKATION_AN")]
    LEISTUNG_LOKATION_AN,

    /// <summary>
    /// Leistung an der Lokation aus (ZF5)
    /// </summary>
    [EnumMember(Value = "LEISTUNG_LOKATION_AUS")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("LEISTUNG_LOKATION_AUS")]
    LEISTUNG_LOKATION_AUS,
}
