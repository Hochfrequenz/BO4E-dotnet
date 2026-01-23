#nullable enable
using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary> </summary>
public enum Leistungstyp
{
    /// <summary>Arbeitspreis zur Abrechnung der Wirkarbeit</summary>
    [EnumMember(Value = "ARBEITSPREIS_WIRKARBEIT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ARBEITSPREIS_WIRKARBEIT")]
    ARBEITSPREIS_WIRKARBEIT,

    /// <summary>Leistungspreis zur Abrechnung der Wirkleistung</summary>
    [EnumMember(Value = "LEISTUNGSPREIS_WIRKLEISTUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("LEISTUNGSPREIS_WIRKLEISTUNG")]
    LEISTUNGSPREIS_WIRKLEISTUNG,

    /// <summary>Arbeitspreis zur Abrechnung der Blindarbeit induktiv</summary>
    [EnumMember(Value = "ARBEITSPREIS_BLINDARBEIT_IND")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ARBEITSPREIS_BLINDARBEIT_IND")]
    ARBEITSPREIS_BLINDARBEIT_IND,

    /// <summary>Arbeitspreis zur Abrechnung der Blindarbeit kapazitiv</summary>
    [EnumMember(Value = "ARBEITSPREIS_BLINDARBEIT_KAP")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ARBEITSPREIS_BLINDARBEIT_KAP")]
    ARBEITSPREIS_BLINDARBEIT_KAP,

    /// <summary>Grundpreis (pro Zeiteinheit)</summary>
    [EnumMember(Value = "GRUNDPREIS")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GRUNDPREIS")]
    GRUNDPREIS,

    /// <summary>Mehr- oder Mindermenge</summary>
    [EnumMember(Value = "MEHRMINDERMENGE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MEHRMINDERMENGE")]
    MEHRMINDERMENGE,

    /// <summary>Preis pro Zeiteinheit</summary>
    [EnumMember(Value = "MESSSTELLENBETRIEB")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MESSSTELLENBETRIEB")]
    MESSSTELLENBETRIEB,

    /// <summary>Preis pro Zeiteinheit</summary>
    [EnumMember(Value = "MESSDIENSTLEISTUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MESSDIENSTLEISTUNG")]
    MESSDIENSTLEISTUNG,

    /// <summary>MDL inklusive der Messung (ab 2017), Preis pro Zeiteinheit</summary>
    [EnumMember(Value = "MESSDIENSTLEISTUNG_INKL_MESSUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MESSDIENSTLEISTUNG_INKL_MESSUNG")]
    MESSDIENSTLEISTUNG_INKL_MESSUNG,

    /// <summary>Preis pro Zeiteinheit</summary>
    [EnumMember(Value = "ABRECHNUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ABRECHNUNG")]
    ABRECHNUNG,

    /// <summary>Konzessionsabgabe</summary>
    [EnumMember(Value = "KONZESSIONS_ABGABE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("KONZESSIONS_ABGABE")]
    KONZESSIONS_ABGABE,

    /// <summary>KWK-Umlage</summary>
    [EnumMember(Value = "KWK_UMLAGE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("KWK_UMLAGE")]
    KWK_UMLAGE,

    /// <summary>Offshore-Haftungsumlage</summary>
    [EnumMember(Value = "OFFSHORE_UMLAGE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("OFFSHORE_UMLAGE")]
    OFFSHORE_UMLAGE,

    /// <summary>Umlage für abschatbare Lasten</summary>
    [EnumMember(Value = "ABLAV_UMLAGE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ABLAV_UMLAGE")]
    ABLAV_UMLAGE,

    /// <summary>Regelenergieumlage</summary>
    [EnumMember(Value = "REGELENERGIE_UMLAGE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("REGELENERGIE_UMLAGE")]
    REGELENERGIE_UMLAGE,

    /// <summary>Bilanzierungsumlage</summary>
    [EnumMember(Value = "BILANZIERUNG_UMLAGE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BILANZIERUNG_UMLAGE")]
    BILANZIERUNG_UMLAGE,

    /// <summary>Zusätzliche Auslesung (pro Vorgang)</summary>
    [EnumMember(Value = "AUSLESUNG_ZUSAETZLICH")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("AUSLESUNG_ZUSAETZLICH")]
    AUSLESUNG_ZUSAETZLICH,

    /// <summary>Zusätzliche Ablesung (pro Vorgang)</summary>
    [EnumMember(Value = "ABLESUNG_ZUSAETZLICH")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ABLESUNG_ZUSAETZLICH")]
    ABLESUNG_ZUSAETZLICH,

    /// <summary>Zusätzliche Abresung (pro Vorgang)</summary>
    [EnumMember(Value = "ABRECHNUNG_ZUSAETZLICH")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ABRECHNUNG_ZUSAETZLICH")]
    ABRECHNUNG_ZUSAETZLICH,

    /// <summary>Sperrung einer Abnahmestelle</summary>
    [EnumMember(Value = "SPERRUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SPERRUNG")]
    SPERRUNG,

    /// <summary>Entsperrung einer Abnahmestelle</summary>
    [EnumMember(Value = "ENTSPERRUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ENTSPERRUNG")]
    ENTSPERRUNG,

    /// <summary>Mahnkosten</summary>
    [EnumMember(Value = "MAHNKOSTEN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MAHNKOSTEN")]
    MAHNKOSTEN,

    /// <summary>Inkassokosten</summary>
    [EnumMember(Value = "INKASSOKOSTEN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("INKASSOKOSTEN")]
    INKASSOKOSTEN,
}
