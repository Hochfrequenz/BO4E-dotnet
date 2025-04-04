using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Typen von Fehlern</summary>
public enum FehlerTyp
{
    /// <summary>
    /// Modellfehler / Syntaxfehler
    /// </summary>
    [EnumMember(Value = "SYNTAX")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SYNTAX")]
    SYNTAX,

    /// <summary>Fehler in der Verarbeitung</summary>
    [EnumMember(Value = "VERARBEITUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("VERARBEITUNG")]
    VERARBEITUNG,
}
