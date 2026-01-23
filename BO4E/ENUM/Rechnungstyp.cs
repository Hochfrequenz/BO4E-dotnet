#nullable enable
using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary> </summary>
public enum Rechnungstyp
{
    /// <summary>Abschlagsrechnung</summary>
    [EnumMember(Value = "ABSCHLAGSRECHNUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ABSCHLAGSRECHNUNG")]
    ABSCHLAGSRECHNUNG,

    /// <summary>Turnusrechnung</summary>
    [EnumMember(Value = "TURNUSRECHNUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("TURNUSRECHNUNG")]
    TURNUSRECHNUNG,

    /// <summary>Monatsrechnung</summary>
    [EnumMember(Value = "MONATSRECHNUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MONATSRECHNUNG")]
    MONATSRECHNUNG,

    /// <summary>Rechnung für WiM</summary>
    [EnumMember(Value = "WIMRECHNUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("WIMRECHNUNG")]
    WIMRECHNUNG,

    /// <summary>Zwischenrechnung</summary>
    [EnumMember(Value = "ZWISCHENRECHNUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ZWISCHENRECHNUNG")]
    ZWISCHENRECHNUNG,

    /// <summary>Integrierte 13. Rechnung</summary>
    [EnumMember(Value = "INTEGRIERTE_13TE_RECHNUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("INTEGRIERTE_13TE_RECHNUNG")]
    INTEGRIERTE_13TE_RECHNUNG,

    /// <summary>Zusätzliche 13. Rechnung</summary>
    [EnumMember(Value = "ZUSAETZLICHE_13TE_RECHNUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ZUSAETZLICHE_13TE_RECHNUNG")]
    ZUSAETZLICHE_13TE_RECHNUNG,

    /// <summary>Mehr/Mindermengenabrechnung</summary>
    [EnumMember(Value = "MEHRMINDERMENGENRECHNUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MEHRMINDERMENGENRECHNUNG")]
    MEHRMINDERMENGENRECHNUNG,

    /// <summary>Abschlussrechnung</summary>
    [EnumMember(Value = "ABSCHLUSSRECHNUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ABSCHLUSSRECHNUNG")]
    ABSCHLUSSRECHNUNG,

    /// <summary>Rechnung für Messstellenbetrieb</summary>
    [EnumMember(Value = "MSBRECHNUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MSBRECHNUNG")]
    MSBRECHNUNG,

    /// <summary>Kapazitätsrechnung</summary>
    [EnumMember(Value = "KAPAZITAETSRECHNUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("KAPAZITAETSRECHNUNG")]
    KAPAZITAETSRECHNUNG,

    /// <summary>Rechnung für Sperren und Wiederinbetriebnahme</summary>
    [EnumMember(Value = "SPERRUNG_INBETRIEBNAHME")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SPERRUNG_INBETRIEBNAHME")]
    SPERRUNG_INBETRIEBNAHME,

    /// <summary>
    /// Verzugskostenrechnung
    /// </summary>
    [EnumMember(Value = "VERZUGSKOSTEN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("VERZUGSKOSTEN")]
    VERZUGSKOSTEN,

    /// <summary>
    /// Blindarbeitsrechnung
    /// </summary>
    [EnumMember(Value = "BLINDARBEIT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BLINDARBEIT")]
    BLINDARBEIT,

    /// <summary>
    /// Sonderrechnung
    /// </summary>
    [EnumMember(Value = "SONDERRECHNUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SONDERRECHNUNG")]
    SONDERRECHNUNG,

    /// <summary>
    /// Abrechnung von Konfigurationen (Universalbestellprozess)
    /// </summary>
    [EnumMember(Value = "ABRECHNUNG_VON_KONFIGURATIONEN_UNIVERSALBESTELLPROZESS")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName(
        "ABRECHNUNG_VON_KONFIGURATIONEN_UNIVERSALBESTELLPROZESS"
    )]
    ABRECHNUNG_VON_KONFIGURATIONEN_UNIVERSALBESTELLPROZESS,

    /// <summary>
    /// ABRECHNUNG_TECHNIK
    /// </summary>
    [EnumMember(Value = "ABRECHNUNG_TECHNIK")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ABRECHNUNG_TECHNIK")]
    ABRECHNUNG_TECHNIK,
}
