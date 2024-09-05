using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>
///     Gibt den Bearbeitungsstatus, z.b. einer <see cref="BO4E.BO.Benachrichtigung" /> an.
/// </summary>
public enum Bearbeitungsstatus
{
    /// <summary>
    ///     offen oder neu
    /// </summary>
    [EnumMember(Value = "OFFEN")]
    OFFEN,

    /// <summary>
    ///     in Bearbeitung
    /// </summary>
    [EnumMember(Value = "IN_BEARBEITUNG")]
    IN_BEARBEITUNG,

    /// <summary>
    ///     abgeschlossen
    /// </summary>
    [EnumMember(Value = "ABGESCHLOSSEN")]
    ABGESCHLOSSEN,

    /// <summary>
    ///     storniert
    /// </summary>
    [EnumMember(Value = "STORNIERT")]
    STORNIERT,

    /// <summary>
    ///     quittiert
    /// </summary>
    [EnumMember(Value = "QUITTIERT")]
    QUITTIERT,

    /// <summary>
    ///     Benachrichtigung ist auf Wunsch des Users standardmäßig ausgeblendet.
    /// </summary>
    [EnumMember(Value = "IGNORIERT")]
    IGNORIERT,
}
