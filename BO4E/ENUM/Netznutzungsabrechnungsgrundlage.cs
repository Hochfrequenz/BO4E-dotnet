#nullable enable
using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Netznutzungsabrechnungsgrundlage</summary>
public enum Netznutzungsabrechnungsgrundlage
{
    /// <summary>Z12: Lieferschein</summary>
    [EnumMember(Value = "LIEFERSCHEIN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("LIEFERSCHEIN")]
    LIEFERSCHEIN,

    /// <summary>Z13: Abweichend vertraglich mit Anschlussnutzer vereinbarte Grundlage</summary>
    [EnumMember(Value = "ABWEICHENDE_GRUNDLAGE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ABWEICHENDE_GRUNDLAGE")]
    ABWEICHENDE_GRUNDLAGE,
}
