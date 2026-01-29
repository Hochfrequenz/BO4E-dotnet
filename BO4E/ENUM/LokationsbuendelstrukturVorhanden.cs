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
    [EnumMember(Value = "VORHANDEN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("VORHANDEN")]
    VORHANDEN,

    /// <summary>
    /// Lokationsbündelstruktur nicht vorhanden (EDIFACT Z39)
    /// </summary>
    [ProtoEnum(Name = nameof(LokationsbuendelstrukturVorhanden) + "_" + nameof(NICHT_VORHANDEN))]
    [EnumMember(Value = "NICHT_VORHANDEN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("NICHT_VORHANDEN")]
    NICHT_VORHANDEN,
}
