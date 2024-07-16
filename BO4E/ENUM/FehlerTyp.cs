using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Typen von Fehlern</summary>
public enum FehlerTyp
{
    /// <summary>
    /// Modellfehler / Syntaxfehler
    /// </summary>
    [EnumMember(Value = "SYNTAX")]
    SYNTAX,

    /// <summary>Fehler in der Verarbeitung</summary>
    [EnumMember(Value = "VERARBEITUNG")]
    VERARBEITUNG
}
