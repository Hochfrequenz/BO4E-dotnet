using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>
///     Zur Differenzierung von Grund/Ersatzversorgungstarifen und sonstigen
///     angebotenen Tarifen.
/// </summary>
public enum Tariftyp
{
    /// <summary>Grund- und Ersatzversorgung</summary>
    [EnumMember(Value = "GRUND_ERSATZVERSORGUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GRUND_ERSATZVERSORGUNG")]
    GRUND_ERSATZVERSORGUNG,

    /// <summary>Grundversorgung</summary>
    [EnumMember(Value = "GRUNDVERSORGUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GRUNDVERSORGUNG")]
    GRUNDVERSORGUNG,

    /// <summary>Ersatzversorgung</summary>
    [EnumMember(Value = "ERSATZVERSORGUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ERSATZVERSORGUNG")]
    ERSATZVERSORGUNG,

    /// <summary>Sondertarif</summary>
    [EnumMember(Value = "SONDERTARIF")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SONDERTARIF")]
    SONDERTARIF,
}
