using System.Runtime.Serialization;
using ProtoBuf;

namespace BO4E.ENUM;

/// <summary>
/// Gibt an, ob eine Lokationsbündelstruktur vorhanden ist.
/// </summary>
public enum LokationsbuendelstrukturVorhanden
{
    /// <summary>
    /// Lokationsbündelstruktur vorhanden (EDIFACT Z31)
    /// </summary>
    [ProtoEnum(Name = nameof(LokationsbuendelstrukturVorhanden) + "_" + nameof(VORHANDEN))]
    [EnumMember(Value = "Z31")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("Z31")]
    VORHANDEN,

    /// <summary>
    /// Lokationsbündelstruktur nicht vorhanden (EDIFACT Z39)
    /// </summary>
    [ProtoEnum(Name = nameof(LokationsbuendelstrukturVorhanden) + "_" + nameof(NICHT_VORHANDEN))]
    [EnumMember(Value = "Z39")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("Z39")]
    NICHT_VORHANDEN,
}
