namespace BO4E.ENUM
{
    /// <summary>Voraussetzungen, die erfüllt sein müssen, damit dieser Tarif zur Anwendung kommen kann.</summary>
    public enum Voraussetzungen
    {
        /// <summary>Einzugsermaechtigung</summary>
        EINZUGSERMAECHTIGUNG,

        /// <summary>Vertrag muss zu einem bestimmten Zeitpunkt noch bestehen</summary>
        ZEITPUNKT,

        /// <summary>Lieferantenbindung für diese Energieart</summary>
        LIEFERANBINDUNG_EINE,

        /// <summary>Lieferantenbindung für alle Energiearten, die der Versorger anbietet</summary>
        LIEFERANBINDUNG_ALLE,

        /// <summary>Gewerbenachweis</summary>
        GEWERBE,

        /// <summary>Kunde muss einem bestimmten Lastprofil zuzuordnen sein</summary>
        LASTPROFIL,

        /// <summary>bestimmter Zaehlertyp oder Zaehlergroeße</summary>
        ZAEHLERTYP_GROESSE,

        /// <summary>Ausschluss von Großverbrauchern wie Industriekunden oder produzierendes Gewerbe</summary>
        AUSSCHLUSS_GROSSVERBRAUCHER,

        /// <summary>Neukunden ohne bisherige Lieferanbindung</summary>
        NEUKUNDE,

        /// <summary>bestimmte Vertragsformalitaeten wie z.B. Anmeldeformular muss an bestimmte Adresse versandt werden</summary>
        BESTIMMTE_VERTRAGSFORMALITAETEN,

        /// <summary>Selbstablesung durch den Kunden</summary>
        SELBSTABLESUNG,

        /// <summary>Onlinevoraussetzung</summary>
        ONLINEVORAUSSETZUNG,

        /// <summary>Mindestumsatz in einer bestimmten Zeiteinheit wie z.B. Mindestjahresumsatz 2500 EURO</summary>
        MINDESTUMSATZ,

        /// <summary>Zusatzprodukt zu bereits bestehendem Lieferverhaeltnis beim Versorger in dieser Energieart</summary>
        ZUSATZPRODUKT,

        /// <summary>geworbener Neukunde muss bestimmte Voraussetzungen erfüllen</summary>
        NEUKUNDE_MIT_VORAUSSETZUNGEN,

        /// <summary>Kunde wird durch Direktvertrieb gewonnen</summary>
        DIREKTVERTRIEB,

        /// <summary>Anlage mit bestimmter Anschlussart wie z.B. Festanschluss</summary>
        ANSCHLUSSART,

        /// <summary>bestimmte Anschlusswerte wie z. B. mindestens 30 kW</summary>
        ANSCHLUSSWERT,

        /// <summary>Alter einer Kundenanlage (z.B. Anlage wurde nach dem 01.01.2005 installiert)</summary>
        ALTER_KUNDENANLAGE,

        /// <summary>bestimmte Anlagebeschaffenheit, wie bivalente Energieversorgung, Geräte o.ä.</summary>
        ANLAGEBESCHAFFENHEIT,

        /// <summary>Betriebsstundenbegrenzung z.B. max 1500h/a oder mindestens 1000h/a</summary>
        BETRIEBSSTUNDENBEGRENZUNG,

        /// <summary>vorgeschriebene Freigabezeiten</summary>
        FREIGABEZEITEN,

        /// <summary>Familienstruktur wie z.B. bestimmte Anzahl Kinder oder Personen im Haushalt oder Eheleute</summary>
        FAMILIENSTRUKTUR,

        /// <summary>Mitgliedschaft in bestimmten Vereinen oder Verbaenden</summary>
        MITGLIEDSCHAFT,

        /// <summary>staatliche Foerderung wie z.B. Sozialtarif oder Studentenausweis</summary>
        STAATLICHE_FOERDERUNG,

        /// <summary>besondere Verbrauchsstellen wie Kirchen, Vereinsgebaeude usw.</summary>
        BESONDERE_VERBRAUCHSSTELLE,

        /// <summary>Niedrigenergieaustattung des Hauses</summary>
        NIEDRIGENERGIE,

        /// <summary>nur für bestimmte Ortsteile in diesem Liefergebiet</summary>
        ORTSTEILE_LIEFERGEBIET,

        /// <summary>Waermebedarf wird nur oder überwiegend mit Erdgas gedeckt</summary>
        WAERMEBEDARF_ERDGAS,

        /// <summary>beschraenkt auf max. Anzahl Zaehler oder Abnahmestellen</summary>
        MAX_ZAEHLER_LIEFERSTELLEN,

        /// <summary>Lieferungsbeschraenkung auf bestimmte Gasart, wie H-Gas oder L-Gas</summary>
        LIEFERUNGSBESCHRAENKUNG_GASART,

        /// <summary>Kombination von Boni, von denen mindestens einer sehr unwahrscheinlich zu erreichen ist</summary>
        KOMBI_BONI,

        /// <summary>nur für Altvertraege, die weiterhin gueltig sind</summary>
        ALTVERTRAG,

        /// <summary>vorgeschriebene Zusatzanlage wie z.B. Solaranlage etc.</summary>
        VORGESCHRIEBENE_ZUSATZANLAGE,

        /// <summary>mehr als 1 Zaehler oder 1 Abnahmestelle</summary>
        MEHRERE_ZAEHLER_ABNAHMESTELLEN,

        /// <summary>bestimmter Abnahmefall wie z.B. nur Gemeinschaftsheizungen o.ae.</summary>
        BESTIMMTER_ABNAHMEFALL,

        /// <summary>Zahlungsmodalitaet wie z.B. halbjaehrliche Zahlungsweise</summary>
        ZUSATZMODALITAET,

        /// <summary>Nachweis der Zahlungsfaehigkeit wie z.B. Bonitaetsprüfung</summary>
        NACHWEIS_ZAHLUNGSFAEHIGKEIT,

        /// <summary>Umstellung der Energieart</summary>
        UMSTELLUNG_ENERGIEART
    }
}