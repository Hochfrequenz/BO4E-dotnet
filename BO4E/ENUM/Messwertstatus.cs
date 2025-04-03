using System.Runtime.Serialization;
using BO4E.meta;

namespace BO4E.ENUM;

/// <summary>
/// Gibt auskunft über die Gültigkeit des angegebenen Verbrauchswertes. Bildet MSCONS SG10 QTY 6063 ab.
/// </summary>
public enum Messwertstatus
{
    /// <summary> Wahrer Wert: 220 </summary>
    [EnumMember(Value = "ABGELESEN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ABGELESEN")]
    ABGELESEN,

    /// <summary> Ersatzwert: 67 </summary>
    [EnumMember(Value = "ERSATZWERT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ERSATZWERT")]
    ERSATZWERT,

    /// <summary> Vorläufiger Wert: Z18 </summary>
    [EnumMember(Value = "VOLAEUFIGERWERT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("VOLAEUFIGERWERT")]
    VOLAEUFIGERWERT,

    /// <summary> Angabe für Lieferschein: Z31 </summary>
    [NonOfficial(NonOfficialCategory.UNSPECIFIED)]
    [EnumMember(Value = "ANGABE_FUER_LIEFERSCHEIN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ANGABE_FUER_LIEFERSCHEIN")]
    ANGABE_FUER_LIEFERSCHEIN,

    /// <summary> Vorschlagswert: 201 </summary>
    [EnumMember(Value = "VORSCHLAGSWERT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("VORSCHLAGSWERT")]
    VORSCHLAGSWERT,

    /// <summary> Nicht verwendbarer Wert: 20 </summary>
    [EnumMember(Value = "NICHT_VERWENDBAR")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("NICHT_VERWENDBAR")]
    NICHT_VERWENDBAR,

    /// <summary> Prognosewert: 187 </summary>
    [EnumMember(Value = "PROGNOSEWERT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("PROGNOSEWERT")]
    PROGNOSEWERT,

    /// <summary> Energiemenge summiert: 79 </summary>
    [EnumMember(Value = "ENERGIEMENGESUMMIERT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ENERGIEMENGESUMMIERT")]
    ENERGIEMENGESUMMIERT,

    /// <summary> Fehlender Wert: Z30 </summary>
    [EnumMember(Value = "FEHLT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("FEHLT")]
    FEHLT,

    /// <summary> Grundlage POG-Ermittlung: Z47 </summary>
    [EnumMember(Value = "GRUNDLAGE_POG_ERMITTLUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GRUNDLAGE_POG_ERMITTLUNG")]
    GRUNDLAGE_POG_ERMITTLUNG,
}
