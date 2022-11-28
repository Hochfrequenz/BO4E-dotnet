using System.Runtime.Serialization;

namespace BO4E.ENUM
{
    /// <summary> </summary>
    public enum Leistungstyp
    {
        /// <summary>Arbeitspreis zur Abrechnung der Wirkarbeit</summary>
        [EnumMember(Value = "ARBEITSPREIS_WIRKARBEIT")]
        ARBEITSPREIS_WIRKARBEIT,

        /// <summary>Leistungspreis zur Abrechnung der Wirkleistung</summary>
        [EnumMember(Value = "LEISTUNGSPREIS_WIRKLEISTUNG")]
        LEISTUNGSPREIS_WIRKLEISTUNG,

        /// <summary>Arbeitspreis zur Abrechnung der Blindarbeit induktiv</summary>
        [EnumMember(Value = "ARBEITSPREIS_BLINDARBEIT_IND")]
        ARBEITSPREIS_BLINDARBEIT_IND,

        /// <summary>Arbeitspreis zur Abrechnung der Blindarbeit kapazitiv</summary>
        [EnumMember(Value = "ARBEITSPREIS_BLINDARBEIT_KAP")]
        ARBEITSPREIS_BLINDARBEIT_KAP,

        /// <summary>Grundpreis (pro Zeiteinheit)</summary>
        [EnumMember(Value = "GRUNDPREIS")]
        GRUNDPREIS,

        /// <summary>Mehr- oder Mindermenge</summary>
        [EnumMember(Value = "MEHRMINDERMENGE")]
        MEHRMINDERMENGE,

        /// <summary>Preis pro Zeiteinheit</summary>
        [EnumMember(Value = "MESSSTELLENBETRIEB")]
        MESSSTELLENBETRIEB,

        /// <summary>Preis pro Zeiteinheit</summary>
        [EnumMember(Value = "MESSDIENSTLEISTUNG")]
        MESSDIENSTLEISTUNG,

        /// <summary>MDL inklusive der Messung (ab 2017), Preis pro Zeiteinheit</summary>
        [EnumMember(Value = "MESSDIENSTLEISTUNG_INKL_MESSUNG")]
        MESSDIENSTLEISTUNG_INKL_MESSUNG,

        /// <summary>Preis pro Zeiteinheit</summary>
        [EnumMember(Value = "ABRECHNUNG")]
        ABRECHNUNG,

        /// <summary>Konzessionsabgabe</summary>
        [EnumMember(Value = "KONZESSIONS_ABGABE")]
        KONZESSIONS_ABGABE,

        /// <summary>KWK-Umlage</summary>
        [EnumMember(Value = "KWK_UMLAGE")]
        KWK_UMLAGE,

        /// <summary>Offshore-Haftungsumlage</summary>
        [EnumMember(Value = "OFFSHORE_UMLAGE")]
        OFFSHORE_UMLAGE,

        /// <summary>Umlage für abschatbare Lasten</summary>
        [EnumMember(Value = "ABLAV_UMLAGE")]
        ABLAV_UMLAGE,

        /// <summary>Regelenergieumlage</summary>
        [EnumMember(Value = "REGELENERGIE_UMLAGE")]
        REGELENERGIE_UMLAGE,

        /// <summary>Bilanzierungsumlage</summary>
        [EnumMember(Value = "BILANZIERUNG_UMLAGE")]
        BILANZIERUNG_UMLAGE,

        /// <summary>Zusätzliche Auslesung (pro Vorgang)</summary>
        [EnumMember(Value = "AUSLESUNG_ZUSAETZLICH")]
        AUSLESUNG_ZUSAETZLICH,

        /// <summary>Zusätzliche Ablesung (pro Vorgang)</summary>
        [EnumMember(Value = "ABLESUNG_ZUSAETZLICH")]
        ABLESUNG_ZUSAETZLICH,

        /// <summary>Zusätzliche Abresung (pro Vorgang)</summary>
        [EnumMember(Value = "ABRECHNUNG_ZUSAETZLICH")]
        ABRECHNUNG_ZUSAETZLICH,

        /// <summary>Sperrung einer Abnahmestelle</summary>
        [EnumMember(Value = "SPERRUNG")]
        SPERRUNG,

        /// <summary>Entsperrung einer Abnahmestelle</summary>
        [EnumMember(Value = "ENTSPERRUNG")]
        ENTSPERRUNG,

        /// <summary>Mahnkosten</summary>
        [EnumMember(Value = "MAHNKOSTEN")]
        MAHNKOSTEN,

        /// <summary>Inkassokosten</summary>
        [EnumMember(Value = "INKASSOKOSTEN")]
        INKASSOKOSTEN,
    }
}