using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Aufzählung der Möglichkeiten zur Rechnungslegung in Ausschreibungen.</summary>
public enum Rechnungslegung
{
    /// <summary>monatsscharfe Rechnung</summary>
    [EnumMember(Value = "MONATSRECHN")]
    MONATSRECHN,

    /// <summary>Abschlag mit Monatsrechnung</summary>
    [EnumMember(Value = "ABSCHL_MONATSRECHN")]
    ABSCHL_MONATSRECHN,

    /// <summary>Abschlag mit Jahresrechnung</summary>
    [EnumMember(Value = "ABSCHL_JAHRESRECHN")]
    ABSCHL_JAHRESRECHN,

    /// <summary>Monatsrechnung mit Jahresrechnung</summary>
    [EnumMember(Value = "MONATSRECHN_JAHRESRECHN")]
    MONATSRECHN_JAHRESRECHN,

    /// <summary>Vorkasse</summary>
    [EnumMember(Value = "VORKASSE")]
    VORKASSE,
}
