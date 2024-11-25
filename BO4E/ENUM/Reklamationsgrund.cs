using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Reklamationsgrund</summary>
public enum Reklamationsgrund
{
    /// <summary>Werte zu hoch im angegebenen Zeitintervall</summary>
    [EnumMember(Value = "WERTE_ZU_HOCH")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("WERTE_ZU_HOCH")]
    WERTE_ZU_HOCH,

    /// <summary>Werte zu niedrig im angegebenen Zeitintervall</summary>
    [EnumMember(Value = "WERTE_ZU_NIEDRIG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("WERTE_ZU_NIEDRIG")]
    WERTE_ZU_NIEDRIG,

    /// <summary>Werte fehlen im angegebenen Zeitintervall</summary>
    [EnumMember(Value = "WERTE_FEHLEN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("WERTE_FEHLEN")]
    WERTE_FEHLEN,
}
