using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Ermittlung des Leistungsmaximums bei atypischer Netznutzung</summary>
public enum ErmittlungLeistungsmaximum
{
    /// <summary>Verwendung des Hochlastzeitfensters</summary>
    [EnumMember(Value = "VERWENDUNG_HOCHLASTFENSTER")]
    VERWENDUNG_HOCHLASTFENSTER,

    /// <summary>keine Verwendung des Hochlastzeitfensters</summary>
    [EnumMember(Value = "KEINE_VERWENDUNG_HOCHLASTFENSTER")]
    KEINE_VERWENDUNG_HOCHLASTFENSTER,
}
