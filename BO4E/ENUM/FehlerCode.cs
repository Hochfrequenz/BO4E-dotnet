using System.Runtime.Serialization;
using ProtoBuf;

namespace BO4E.ENUM;

/// <summary>verschiedene Fehler-Codes, vor allem für Statusberichte</summary>
public enum FehlerCode
{
    /// <summary>
    /// ID unbekannt
    /// </summary>
    [EnumMember(Value = "ID_UNBEKANNT")]
    ID_UNBEKANNT,

    /// <summary>
    /// Absender zum Zeitpunkt nicht zugeordnet
    /// </summary>
    [EnumMember(Value = "ABSENDER_NICHT_ZUGEORDNET")]
    ABSENDER_NICHT_ZUGEORDNET,

    /// <summary>
    /// Empfaenger zum Zeitpunkt nicht zugeordnet
    /// </summary>
    [EnumMember(Value = "EMPFAENGER_NICHT_ZUGEORDNET")]
    EMPFAENGER_NICHT_ZUGEORDNET,

    /// <summary>
    /// Geraet in Messlokation nicht bekannt
    /// </summary>
    [EnumMember(Value = "GERAET_UNBEKANNT")]
    GERAET_UNBEKANNT,

    /// <summary>
    /// Obis-Kennzahl in Meldepunkt/Tranche nicht bekannt
    /// </summary>
    [EnumMember(Value = "OBIS_UNBEKANNT")]
    OBIS_UNBEKANNT,

    /// <summary>
    /// Fehlerhafte Referenzierung
    /// </summary>
    [EnumMember(Value = "REFERENZIERUNG_FEHLERHAFT")]
    REFERENZIERUNG_FEHLERHAFT,

    /// <summary>
    /// Zuodnungstupel unbekannt
    /// </summary>
    [EnumMember(Value = "TUPEL_UNBEKANNT")]
    TUPEL_UNBEKANNT,

    /// <summary>
    /// Absender zum Zeitpunkt dem Tupel nicht zugeordnet
    /// </summary>
    [EnumMember(Value = "ABSENDER_TUPEL_NICHT_ZUGEORDNET")]
    ABSENDER_TUPEL_NICHT_ZUGEORDNET,

    /// <summary>
    /// Empfaenger zum Zeitpunkt dem Tupel nicht zugeordnet
    /// </summary>
    [EnumMember(Value = "EMPFAENGER_TUPEL_NICHT_ZUGEORDNET")]
    EMPFAENGER_TUPEL_NICHT_ZUGEORDNET,

    /// <summary>
    /// Vorkommastellen zu lang
    /// </summary>
    [EnumMember(Value = "VORKOMMA_ZU_VIELE_STELLEN")]
    VORKOMMA_ZU_VIELE_STELLEN,

    /// <summary>
    /// Zeitreihe ist unvollständig
    /// </summary>
    [EnumMember(Value = "ZEITREIHE_UNVOLLSTAENDIG")]
    ZEITREIHE_UNVOLLSTAENDIG,

    /// <summary>
    /// Referenziertes Tupel ist unbekannt
    /// </summary>
    [EnumMember(Value = "REFERENZIERTES_TUPEL_UNBEKANNT")]
    REFERENZIERTES_TUPEL_UNBEKANNT,

    /// <summary>
    /// Marktlokation nicht gefunden
    /// </summary>
    [EnumMember(Value = "MARKTLOKATION_UNBEKANNT")]
    MARKTLOKATION_UNBEKANNT,

    /// <summary>
    /// Messlokation nicht gefunden
    /// </summary>
    [EnumMember(Value = "MESSLOKATION_UNBEKANNT")]
    MESSLOKATION_UNBEKANNT,

    /// <summary>
    /// Meldepunkt nicht mehr im Netzgebiet
    /// </summary>
    [EnumMember(Value = "MELDEPUNKT_NICHT_MEHR_IM_NETZ")]
    MELDEPUNKT_NICHT_MEHR_IM_NETZ,

    /// <summary>
    /// Pflichtfeld nicht gefüllt
    /// </summary>
    [EnumMember(Value = "ERFORDERLICHE_ANGABE_FEHLT")]
    ERFORDERLICHE_ANGABE_FEHLT,

    /// <summary>
    /// Geschaeftsvorfall wurde zurückgewiesen
    /// </summary>
    [EnumMember(Value = "GESCHAEFTSVORFALL_ZURUECKGEWIESEN")]
    GESCHAEFTSVORFALL_ZURUECKGEWIESEN,

    /// <summary>
    /// Zeitintervall ist negativ oder null
    /// </summary>
    [EnumMember(Value = "ZEITINTERVALL_NEGATIV")]
    ZEITINTERVALL_NEGATIV,

    /// <summary>
    /// Formatvorgaben wurden nicht eingehalten
    /// </summary>
    [EnumMember(Value = "FORMAT_NICHT_EINGEHALTEN")]
    FORMAT_NICHT_EINGEHALTEN,

    /// <summary>
    /// Geschaeftsvorfall darf vom Absender nicht benutzt werden
    /// </summary>
    [EnumMember(Value = "GESCHAEFTSVORFALL_ABSENDER")]
    GESCHAEFTSVORFALL_ABSENDER,

    /// <summary>
    /// Konfigurations-ID zum angegebenen Zeitpunkt nicht bekannt
    /// </summary>
    [EnumMember(Value = "KONFIGURATIONSID_UNBEKANNT")]
    KONFIGURATIONSID_UNBEKANNT,

    /// <summary>
    /// Maximale Segmentwiederholung überschritten
    /// </summary>
    [EnumMember(Value = "SEGMENTWIEDERHOLUNG_UEBERSCHRITTEN")]
    SEGMENTWIEDERHOLUNG_UEBERSCHRITTEN,

    /// <summary>
    /// Anzahl der Codes überschreitet Paketdefinition
    /// </summary>
    [EnumMember(Value = "ANZAHLCODES_UEBERSCHRITTEN")]
    ANZAHLCODES_UEBERSCHRITTEN,

    /// <summary>
    /// Zeitangabe unplausibel
    /// </summary>
    [EnumMember(Value = "ZEITANGABE_UNPLAUSIBEL")]
    ZEITANGABE_UNPLAUSIBEL,

    /// <summary>
    /// Syntaxversion nicht unterstützt
    /// </summary>
    [EnumMember(Value = "SYNTAXVERSION_NICHT_UNTERSTUETZT")]
    SYNTAXVERSION_NICHT_UNTERSTUETZT,

    /// <summary>
    /// Falscher Empfänger
    /// </summary>
    [EnumMember(Value = "FALSCHER_EMPFAENGER")]
    FALSCHER_EMPFAENGER,

    /// <summary>
    /// Ungültiger Wert
    /// </summary>
    [EnumMember(Value = "WERT_UNGUELTIG")]
    WERT_UNGUELTIG,

    /// <summary>
    /// Wert fehlt
    /// </summary>
    [EnumMember(Value = "WERT_FEHLT")]
    WERT_FEHLT,

    /// <summary>
    /// Zu viele Werte
    /// </summary>
    [EnumMember(Value = "WERT_UEBERFLUESSIG")]
    WERT_UEBERFLUESSIG,

    /// <summary>
    /// Falsches Service-Zeichen
    /// </summary>
    [EnumMember(Value = "BEGRENZER_UNPLAUSIBEL")]
    BEGRENZER_UNPLAUSIBEL,

    /// <summary>
    /// Zeichen unplausibel
    /// </summary>
    [EnumMember(Value = "ZEICHEN_UNPLAUSIBEL")]
    ZEICHEN_UNPLAUSIBEL,

    /// <summary>
    /// Absender unbekannt
    /// </summary>
    [EnumMember(Value = "ABSENDER_UNBEKANNT")]
    ABSENDER_UNBEKANNT,

    /// <summary>
    /// Testkennzeichen nicht unterstützt
    /// </summary>
    [EnumMember(Value = "TESTKENNZEICHEN_UNPLAUSIBEL")]
    TESTKENNZEICHEN_UNPLAUSIBEL,

    /// <summary>
    /// Duplikat
    /// </summary>
    [EnumMember(Value = "DUPLIKAT")]
    [ProtoEnum(Name = "FehlerCode_" + nameof(DUPLIKAT))]
    DUPLIKAT,

    /// <summary>
    /// Kontrollzähler unplausibel
    /// </summary>
    [EnumMember(Value = "KONTROLLZAEHLER_UNPLAUSIBEL")]
    KONTROLLZAEHLER_UNPLAUSIBEL,

    /// <summary>
    /// Wert zu lang
    /// </summary>
    [EnumMember(Value = "WERT_ZU_LANG")]
    WERT_ZU_LANG,

    /// <summary>
    /// Zu viele Wiederholungen
    /// </summary>
    [EnumMember(Value = "WIEDERHOLUNG_UNPLAUSIBEL")]
    WIEDERHOLUNG_UNPLAUSIBEL,
}
