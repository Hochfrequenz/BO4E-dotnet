#nullable enable
using System.Runtime.Serialization;
using ProtoBuf;

namespace BO4E.ENUM;

/// <summary>
/// Abschlag einer Rechnungsposition
/// </summary>
public enum RechnungspositionsAbschlag
{
    /// <summary>
    /// Gemeinderabatt nach Konzessionsabgabenverordnung [Z01]
    /// </summary>
    [EnumMember(Value = "GEMEINDERABATT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GEMEINDERABATT")]
    [ProtoEnum(Name = nameof(RechnungspositionsAbschlag) + "_" + nameof(GEMEINDERABATT))]
    GEMEINDERABATT,

    /// <summary>
    /// Anpassung nach § 19, Absatz 2 Stromnetzentgeltverordnung [Z04]
    /// </summary>
    [EnumMember(Value = "ANPASSUNG_STROM_NEV_19_2")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ANPASSUNG_STROM_NEV_19_2")]
    [ProtoEnum(Name = nameof(RechnungspositionsAbschlag) + "_" + nameof(ANPASSUNG_STROM_NEV_19_2))]
    ANPASSUNG_STROM_NEV_19_2,
}
