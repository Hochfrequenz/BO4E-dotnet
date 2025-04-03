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
    [System.Text.Json.Serialization.JsonStringEnumMemberName("OFFEN")]
    OFFEN,

    /// <summary>
    ///     in Bearbeitung
    /// </summary>
    [EnumMember(Value = "IN_BEARBEITUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("IN_BEARBEITUNG")]
    IN_BEARBEITUNG,

    /// <summary>
    ///     abgeschlossen
    /// </summary>
    [EnumMember(Value = "ABGESCHLOSSEN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ABGESCHLOSSEN")]
    ABGESCHLOSSEN,

    /// <summary>
    ///     storniert
    /// </summary>
    [EnumMember(Value = "STORNIERT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("STORNIERT")]
    STORNIERT,

    /// <summary>
    ///     quittiert
    /// </summary>
    [EnumMember(Value = "QUITTIERT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("QUITTIERT")]
    QUITTIERT,

    /// <summary>
    ///     Benachrichtigung ist auf Wunsch des Users standardmäßig ausgeblendet.
    /// </summary>
    [EnumMember(Value = "IGNORIERT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("IGNORIERT")]
    IGNORIERT,
}
