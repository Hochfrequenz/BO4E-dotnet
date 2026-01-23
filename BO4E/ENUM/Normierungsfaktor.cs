#nullable enable
using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>
///     Normierungsfaktor eines Profils
/// </summary>
public enum Normierungsfaktor
{
    /// <summary>
    ///    	1.000.000 kWh/a
    /// </summary>
    [EnumMember(Value = "NORMIERUNGSFAKTOR_1_000_000_KWH_A")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("NORMIERUNGSFAKTOR_1_000_000_KWH_A")]
    NORMIERUNGSFAKTOR_1_000_000_KWH_A,

    /// <summary>
    ///     300 kWh/K
    /// </summary>
    [EnumMember(Value = "NORMIERUNGSFAKTOR_300_KWH_K")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("NORMIERUNGSFAKTOR_300_KWH_K")]
    NORMIERUNGSFAKTOR_300_KWH_K,

    /// <summary>
    ///     1.000.000 kW
    /// </summary>
    [EnumMember(Value = "NORMIERUNGSFAKTOR_1_000_000_KW")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("NORMIERUNGSFAKTOR_1_000_000_KW")]
    NORMIERUNGSFAKTOR_1_000_000_KW,
}
