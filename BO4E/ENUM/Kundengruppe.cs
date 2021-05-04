namespace BO4E.ENUM
{
    /// <summary>Kundengruppe für eine Marktlokation (orientiert sich an den Standard-Lastprofilen).</summary>
    public enum Kundengruppe
    {
        /// <summary>Kunde mit registrierender Leistungsmessung (kein SLP)</summary>
        RLM,

        /// <summary>Gewerbe allgemein</summary>
        SLP_S_G0,

        /// <summary>Werktags</summary>
        SLP_S_G1,

        /// <summary>Verbrauch in Abendstunden</summary>
        SLP_S_G2,

        /// <summary>Gewerbe durchlaufend</summary>
        SLP_S_G3,

        /// <summary>Laden, Friseur</summary>
        SLP_S_G4,

        /// <summary>Bäckerei mit Backstube</summary>
        SLP_S_G5,

        /// <summary>Wochenendbetrieb</summary>
        SLP_S_G6,

        /// <summary>Mobilfunksendestation</summary>
        SLP_S_G7,

        /// <summary>Landwirtschaft allgemein</summary>
        SLP_S_L0,

        /// <summary>Landwirtschaft mit Milchwirtschaft/Nebenerwerbs-Tierzucht</summary>
        SLP_S_L1,

        /// <summary>Übrige Landwirtschaftsbetriebe</summary>
        SLP_S_L2,

        /// <summary>Haushalt allgemein</summary>
        SLP_S_H0,

        /// <summary>Straßenbeleuchtung</summary>
        SLP_S_SB,

        /// <summary>Nachtspeicherheizung</summary>
        SLP_S_HZ,

        /// <summary>Wärmepumpe</summary>
        SLP_S_WP,

        /// <summary>Gebietskörpersch., Kreditinst. u. Versich., Org. o. Erwerbszw. &amp; öff. Einr.</summary>
        SLP_G_GKO,

        /// <summary>Einzelhandel, Großhandel</summary>
        SLP_G_GHA,

        /// <summary>Metall, Kfz</summary>
        SLP_G_GMK,

        /// <summary>sonst. betr. Dienstleistungen</summary>
        SLP_G_GBD,

        /// <summary>Beherbergung</summary>
        SLP_G_GGA,

        /// <summary>Gaststätten</summary>
        SLP_G_GBH,

        /// <summary>Bäckereien</summary>
        SLP_G_GBA,

        /// <summary>Wäschereien</summary>
        SLP_G_GWA,

        /// <summary>Gartenbau</summary>
        SLP_G_GGB,

        /// <summary>Papier und Druck</summary>
        SLP_G_GPD,

        /// <summary>haushaltsähnliche Gewerbebetriebe</summary>
        SLP_G_GMF,

        /// <summary>Einfamilienhaushalt</summary>
        SLP_G_HEF,

        /// <summary>Mehrfamilienhaushalt</summary>
        SLP_G_HMF,

        /// <summary>Kochgas</summary>
        SLP_G_HKO
    }
}