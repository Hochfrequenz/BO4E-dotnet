namespace BO4E.ENUM
{

    /// <summary>Aulistung der verschiedenen Berechnungsmethoden für ein Preisblatt.</summary>
    public enum Kalkulationsmethode
    {
        /// <summary>Es wird keine Berechnung durchgeführt, sondern lediglich die Menge mit dem Preis multipliziert.</summary>
        KEINE,
        /// <summary>Staffelmodell, d.h. die Gesamtmenge wird in eine Staffel eingeordnet und für die gesamte Menge gilt der so ermittelte Preis</summary>
        STAFFELN,
        /// <summary>Zonenmodell, d.h. die Gesamtmenge wird auf die Zonen aufgeteilt und für die Teilmengen gilt der jeweilige Preis der Zone.</summary>
        ZONEN,
        /// <summary>Vorzonengrundpreis</summary>
        VORZONEN_GP,
        /// <summary>Sigmoidfunktion</summary>
        SIGMOID,
        /// <summary>Blindarbeit oberhalb 50% der Wirkarbeit</summary>
        BLINDARBEIT_GT_50_PROZENT,
        /// <summary>Blindarbeit oberhalb 40% der Wirkarbeit</summary>
        BLINDARBEIT_GT_40_PROZENT,
        /// <summary>Arbeits- und Grundpreis gezont</summary>
        AP_GP_ZONEN,
        /// <summary>Leistungsentgelt auf Grundlage der installierten Leistung</summary>
        LP_INSTALL_LEISTUNG,
        /// <summary>AP auf Grundlage Transport- oder Verteilnetz</summary>
        AP_TRANSPORT_ODER_VERTEILNETZ,
        /// <summary>AP auf Grundlage Transport- oder Verteilnetz, Ortsverteilnetz über Sigmoid</summary>
        AP_TRANSPORT_ODER_VERTEILNETZ_ORTSVERTEILNETZ_SIGMOID,
        /// <summary>Leistungsentgelt auf Grundlage des Jahresverbrauchs</summary>
        LP_JAHRESVERBRAUCH,
        /// <summary>LP auf Grundlage Transport- oder Verteilnetz</summary>
        LP_TRANSPORT_ODER_VERTEILNETZ,
        /// <summary>LP auf Grundlage Transport- oder Verteilnetz, Ortsverteilnetz über Sigmoid</summary>
        LP_TRANSPORT_ODER_VERTEILNETZ_ORTSVERTEILNETZ_SIGMOID,
        /// <summary>Funktionsbezogene Leistungsermittlung bei Verbräuchen oberhalb der SLP Grenze. (ähnlich Sigmoid)</summary>
        FUNKTIONEN,
        /// <summary>Bei einem Verbrauch über der SLP-Grenze (letzte Staffelgrenze überschritten) erfolgt die Berechnung funktionsbezogen (s.o.) als LGK.</summary>
        VERBRAUCH_UEBER_SLP_GRENZE_FUNKTIONSBEZOGEN_WEITERE_BERECHNUNG_ALS_LGK
    }
}