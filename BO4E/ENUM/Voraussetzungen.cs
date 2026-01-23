using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Voraussetzungen, die erfüllt sein müssen, damit dieser Tarif zur Anwendung kommen kann.</summary>
public enum Voraussetzungen
{
    /// <summary>Einzugsermaechtigung</summary>
    [EnumMember(Value = "EINZUGSERMAECHTIGUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("EINZUGSERMAECHTIGUNG")]
    EINZUGSERMAECHTIGUNG,

    /// <summary>Vertrag muss zu einem bestimmten Zeitpunkt noch bestehen</summary>
    [EnumMember(Value = "ZEITPUNKT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ZEITPUNKT")]
    ZEITPUNKT,

    /// <summary>Lieferantenbindung für diese Energieart</summary>
    [EnumMember(Value = "LIEFERANBINDUNG_EINE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("LIEFERANBINDUNG_EINE")]
    LIEFERANBINDUNG_EINE,

    /// <summary>Lieferantenbindung für alle Energiearten, die der Versorger anbietet</summary>
    [EnumMember(Value = "LIEFERANBINDUNG_ALLE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("LIEFERANBINDUNG_ALLE")]
    LIEFERANBINDUNG_ALLE,

    /// <summary>Gewerbenachweis</summary>
    [EnumMember(Value = "GEWERBE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GEWERBE")]
    GEWERBE,

    /// <summary>Kunde muss einem bestimmten Lastprofil zuzuordnen sein</summary>
    [EnumMember(Value = "LASTPROFIL")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("LASTPROFIL")]
    LASTPROFIL,

    /// <summary>bestimmter Zaehlertyp oder Zaehlergroeße</summary>
    [EnumMember(Value = "ZAEHLERTYP_GROESSE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ZAEHLERTYP_GROESSE")]
    ZAEHLERTYP_GROESSE,

    /// <summary>Ausschluss von Großverbrauchern wie Industriekunden oder produzierendes Gewerbe</summary>
    [EnumMember(Value = "AUSSCHLUSS_GROSSVERBRAUCHER")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("AUSSCHLUSS_GROSSVERBRAUCHER")]
    AUSSCHLUSS_GROSSVERBRAUCHER,

    /// <summary>Neukunden ohne bisherige Lieferanbindung</summary>
    [EnumMember(Value = "NEUKUNDE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("NEUKUNDE")]
    NEUKUNDE,

    /// <summary>bestimmte Vertragsformalitaeten wie z.B. Anmeldeformular muss an bestimmte Adresse versandt werden</summary>
    [EnumMember(Value = "BESTIMMTE_VERTRAGSFORMALITAETEN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BESTIMMTE_VERTRAGSFORMALITAETEN")]
    BESTIMMTE_VERTRAGSFORMALITAETEN,

    /// <summary>Selbstablesung durch den Kunden</summary>
    [EnumMember(Value = "SELBSTABLESUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SELBSTABLESUNG")]
    SELBSTABLESUNG,

    /// <summary>Onlinevoraussetzung</summary>
    [EnumMember(Value = "ONLINEVORAUSSETZUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ONLINEVORAUSSETZUNG")]
    ONLINEVORAUSSETZUNG,

    /// <summary>Mindestumsatz in einer bestimmten Zeiteinheit wie z.B. Mindestjahresumsatz 2500 EURO</summary>
    [EnumMember(Value = "MINDESTUMSATZ")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MINDESTUMSATZ")]
    MINDESTUMSATZ,

    /// <summary>Zusatzprodukt zu bereits bestehendem Lieferverhaeltnis beim Versorger in dieser Energieart</summary>
    [EnumMember(Value = "ZUSATZPRODUKT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ZUSATZPRODUKT")]
    ZUSATZPRODUKT,

    /// <summary>geworbener Neukunde muss bestimmte Voraussetzungen erfüllen</summary>
    [EnumMember(Value = "NEUKUNDE_MIT_VORAUSSETZUNGEN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("NEUKUNDE_MIT_VORAUSSETZUNGEN")]
    NEUKUNDE_MIT_VORAUSSETZUNGEN,

    /// <summary>Kunde wird durch Direktvertrieb gewonnen</summary>
    [EnumMember(Value = "DIREKTVERTRIEB")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("DIREKTVERTRIEB")]
    DIREKTVERTRIEB,

    /// <summary>Anlage mit bestimmter Anschlussart wie z.B. Festanschluss</summary>
    [EnumMember(Value = "ANSCHLUSSART")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ANSCHLUSSART")]
    ANSCHLUSSART,

    /// <summary>bestimmte Anschlusswerte wie z. B. mindestens 30 kW</summary>
    [EnumMember(Value = "ANSCHLUSSWERT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ANSCHLUSSWERT")]
    ANSCHLUSSWERT,

    /// <summary>Alter einer Kundenanlage (z.B. Anlage wurde nach dem 01.01.2005 installiert)</summary>
    [EnumMember(Value = "ALTER_KUNDENANLAGE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ALTER_KUNDENANLAGE")]
    ALTER_KUNDENANLAGE,

    /// <summary>bestimmte Anlagebeschaffenheit, wie bivalente Energieversorgung, Geräte o.ä.</summary>
    [EnumMember(Value = "ANLAGEBESCHAFFENHEIT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ANLAGEBESCHAFFENHEIT")]
    ANLAGEBESCHAFFENHEIT,

    /// <summary>Betriebsstundenbegrenzung z.B. max 1500h/a oder mindestens 1000h/a</summary>
    [EnumMember(Value = "BETRIEBSSTUNDENBEGRENZUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BETRIEBSSTUNDENBEGRENZUNG")]
    BETRIEBSSTUNDENBEGRENZUNG,

    /// <summary>vorgeschriebene Freigabezeiten</summary>
    [EnumMember(Value = "FREIGABEZEITEN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("FREIGABEZEITEN")]
    FREIGABEZEITEN,

    /// <summary>Familienstruktur wie z.B. bestimmte Anzahl Kinder oder Personen im Haushalt oder Eheleute</summary>
    [EnumMember(Value = "FAMILIENSTRUKTUR")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("FAMILIENSTRUKTUR")]
    FAMILIENSTRUKTUR,

    /// <summary>Mitgliedschaft in bestimmten Vereinen oder Verbaenden</summary>
    [EnumMember(Value = "MITGLIEDSCHAFT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MITGLIEDSCHAFT")]
    MITGLIEDSCHAFT,

    /// <summary>staatliche Foerderung wie z.B. Sozialtarif oder Studentenausweis</summary>
    [EnumMember(Value = "STAATLICHE_FOERDERUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("STAATLICHE_FOERDERUNG")]
    STAATLICHE_FOERDERUNG,

    /// <summary>besondere Verbrauchsstellen wie Kirchen, Vereinsgebaeude usw.</summary>
    [EnumMember(Value = "BESONDERE_VERBRAUCHSSTELLE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BESONDERE_VERBRAUCHSSTELLE")]
    BESONDERE_VERBRAUCHSSTELLE,

    /// <summary>Niedrigenergieaustattung des Hauses</summary>
    [EnumMember(Value = "NIEDRIGENERGIE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("NIEDRIGENERGIE")]
    NIEDRIGENERGIE,

    /// <summary>nur für bestimmte Ortsteile in diesem Liefergebiet</summary>
    [EnumMember(Value = "ORTSTEILE_LIEFERGEBIET")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ORTSTEILE_LIEFERGEBIET")]
    ORTSTEILE_LIEFERGEBIET,

    /// <summary>Waermebedarf wird nur oder überwiegend mit Erdgas gedeckt</summary>
    [EnumMember(Value = "WAERMEBEDARF_ERDGAS")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("WAERMEBEDARF_ERDGAS")]
    WAERMEBEDARF_ERDGAS,

    /// <summary>beschraenkt auf max. Anzahl Zaehler oder Abnahmestellen</summary>
    [EnumMember(Value = "MAX_ZAEHLER_LIEFERSTELLEN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MAX_ZAEHLER_LIEFERSTELLEN")]
    MAX_ZAEHLER_LIEFERSTELLEN,

    /// <summary>Lieferungsbeschraenkung auf bestimmte Gasart, wie H-Gas oder L-Gas</summary>
    [EnumMember(Value = "LIEFERUNGSBESCHRAENKUNG_GASART")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("LIEFERUNGSBESCHRAENKUNG_GASART")]
    LIEFERUNGSBESCHRAENKUNG_GASART,

    /// <summary>Kombination von Boni, von denen mindestens einer sehr unwahrscheinlich zu erreichen ist</summary>
    [EnumMember(Value = "KOMBI_BONI")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("KOMBI_BONI")]
    KOMBI_BONI,

    /// <summary>nur für Altvertraege, die weiterhin gueltig sind</summary>
    [EnumMember(Value = "ALTVERTRAG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ALTVERTRAG")]
    ALTVERTRAG,

    /// <summary>vorgeschriebene Zusatzanlage wie z.B. Solaranlage etc.</summary>
    [EnumMember(Value = "VORGESCHRIEBENE_ZUSATZANLAGE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("VORGESCHRIEBENE_ZUSATZANLAGE")]
    VORGESCHRIEBENE_ZUSATZANLAGE,

    /// <summary>mehr als 1 Zaehler oder 1 Abnahmestelle</summary>
    [EnumMember(Value = "MEHRERE_ZAEHLER_ABNAHMESTELLEN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MEHRERE_ZAEHLER_ABNAHMESTELLEN")]
    MEHRERE_ZAEHLER_ABNAHMESTELLEN,

    /// <summary>bestimmter Abnahmefall wie z.B. nur Gemeinschaftsheizungen o.ae.</summary>
    [EnumMember(Value = "BESTIMMTER_ABNAHMEFALL")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BESTIMMTER_ABNAHMEFALL")]
    BESTIMMTER_ABNAHMEFALL,

    /// <summary>Zahlungsmodalitaet wie z.B. halbjaehrliche Zahlungsweise</summary>
    [EnumMember(Value = "ZUSATZMODALITAET")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ZUSATZMODALITAET")]
    ZUSATZMODALITAET,

    /// <summary>Nachweis der Zahlungsfaehigkeit wie z.B. Bonitaetsprüfung</summary>
    [EnumMember(Value = "NACHWEIS_ZAHLUNGSFAEHIGKEIT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("NACHWEIS_ZAHLUNGSFAEHIGKEIT")]
    NACHWEIS_ZAHLUNGSFAEHIGKEIT,

    /// <summary>Umstellung der Energieart</summary>
    [EnumMember(Value = "UMSTELLUNG_ENERGIEART")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("UMSTELLUNG_ENERGIEART")]
    UMSTELLUNG_ENERGIEART,
}
