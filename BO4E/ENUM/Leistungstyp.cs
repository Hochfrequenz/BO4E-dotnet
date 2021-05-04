namespace BO4E.ENUM
{
    /// <summary> </summary>
    public enum Leistungstyp
    {
        /// <summary>Arbeitspreis zur Abrechnung der Wirkarbeit</summary>
        ARBEITSPREIS_WIRKARBEIT,

        /// <summary>Leistungspreis zur Abrechnung der Wirkleistung</summary>
        LEISTUNGSPREIS_WIRKLEISTUNG,

        /// <summary>Arbeitspreis zur Abrechnung der Blindarbeit induktiv</summary>
        ARBEITSPREIS_BLINDARBEIT_IND,

        /// <summary>Arbeitspreis zur Abrechnung der Blindarbeit kapazitiv</summary>
        ARBEITSPREIS_BLINDARBEIT_KAP,

        /// <summary>Grundpreis (pro Zeiteinheit)</summary>
        GRUNDPREIS,

        /// <summary>Mehr- oder Mindermenge</summary>
        MEHRMINDERMENGE,

        /// <summary>Preis pro Zeiteinheit</summary>
        MESSSTELLENBETRIEB,

        /// <summary>Preis pro Zeiteinheit</summary>
        MESSDIENSTLEISTUNG,

        /// <summary>MDL inklusive der Messung (ab 2017), Preis pro Zeiteinheit</summary>
        MESSDIENSTLEISTUNG_INKL_MESSUNG,

        /// <summary>Preis pro Zeiteinheit</summary>
        ABRECHNUNG,

        /// <summary>Konzessionsabgabe</summary>
        KONZESSIONS_ABGABE,

        /// <summary>KWK-Umlage</summary>
        KWK_UMLAGE,

        /// <summary>Offshore-Haftungsumlage</summary>
        OFFSHORE_UMLAGE,

        /// <summary>Umlage für abschatbare Lasten</summary>
        ABLAV_UMLAGE,

        /// <summary>Regelenergieumlage</summary>
        REGELENERGIE_UMLAGE,

        /// <summary>Bilanzierungsumlage</summary>
        BILANZIERUNG_UMLAGE,

        /// <summary>Zusätzliche Auslesung (pro Vorgang)</summary>
        AUSLESUNG_ZUSAETZLICH,

        /// <summary>Zusätzliche Ablesung (pro Vorgang)</summary>
        ABLESUNG_ZUSAETZLICH,

        /// <summary>Zusätzliche Abresung (pro Vorgang)</summary>
        ABRECHNUNG_ZUSAETZLICH,

        /// <summary>Sperrung einer Abnahmestelle</summary>
        SPERRUNG,

        /// <summary>Entsperrung einer Abnahmestelle</summary>
        ENTSPERRUNG,

        /// <summary>Mahnkosten</summary>
        MAHNKOSTEN,

        /// <summary>Inkassokosten</summary>
        INKASSOKOSTEN
    }
}