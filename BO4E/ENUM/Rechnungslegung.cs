using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Aufzählung der Möglichkeiten zur Rechnungslegung in Ausschreibungen.</summary>
public enum Rechnungslegung
{
    /// <summary>monatsscharfe Rechnung</summary>
    [EnumMember(Value = "MONATSRECHN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MONATSRECHN")]
    MONATSRECHN,

    /// <summary>Abschlag mit Monatsrechnung</summary>
    [EnumMember(Value = "ABSCHL_MONATSRECHN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ABSCHL_MONATSRECHN")]
    ABSCHL_MONATSRECHN,

    /// <summary>Abschlag mit Jahresrechnung</summary>
    [EnumMember(Value = "ABSCHL_JAHRESRECHN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ABSCHL_JAHRESRECHN")]
    ABSCHL_JAHRESRECHN,

    /// <summary>Monatsrechnung mit Jahresrechnung</summary>
    [EnumMember(Value = "MONATSRECHN_JAHRESRECHN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MONATSRECHN_JAHRESRECHN")]
    MONATSRECHN_JAHRESRECHN,

    /// <summary>Vorkasse</summary>
    [EnumMember(Value = "VORKASSE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("VORKASSE")]
    VORKASSE,
}
