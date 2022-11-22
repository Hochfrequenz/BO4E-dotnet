using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;

namespace BO4E.ENUM
{
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
        ZEITANGABE_UNPLAUSIBEL
    }
}