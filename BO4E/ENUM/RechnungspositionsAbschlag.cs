using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>
/// Abschlag einer Rechnungsposition
/// </summary>
public enum RechnungspositionsAbschlag
{
    /// <summary>
    /// Gemeinderabatt nach Konzessionsabgabenverordnung
    /// </summary>
    [EnumMember(Value = "GEMEINDERABATT")]
    GEMEINDERABATT,

    /// <summary>
    /// Anpassung nach § 19, Absatz 2 Stromnetzentgeltverordnung
    /// </summary>
    [EnumMember(Value = "ANPASSUNG")]
    ANPASSUNG,
}
