using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>
/// </summary>
public enum Schalthandlung
{
    /// <summary>
    /// </summary>
    [EnumMember(Value = "LEISTUNG_LOKATION_AN")]
    LEISTUNG_LOKATION_AN,

    /// <summary>
    /// </summary>
    [EnumMember(Value = "LEISTUNG_LOKATION_AUS")]
    LEISTUNG_LOKATION_AUS,
}
