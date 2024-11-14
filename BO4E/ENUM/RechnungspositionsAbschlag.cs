using System.Runtime.Serialization;

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
    GEMEINDERABATT,

    /// <summary>
    /// Anpassung nach § 19, Absatz 2 Stromnetzentgeltverordnung [Z04]
    /// </summary>
    [EnumMember(Value = "ABSCHLAG_ANPASSUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ABSCHLAG_ANPASSUNG")]
    ABSCHLAG_ANPASSUNG,
}
