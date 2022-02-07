namespace BO4E.ENUM
{
    /// <summary>verschiedene Fehler-Codes, vor allem für Statusberichte</summary>
    public enum FehlerCode
    {
        /// <summary>
        /// ID unbekannt
        /// </summary>
        ID_UNBEKANNT,
        /// <summary>
        /// Absender zum Zeitpunkt nicht zugeordnet
        /// </summary>
        ABSENDER_NICHT_ZUGEORDNET,
        /// <summary>
        /// Empfaenger zum Zeitpunkt nicht zugeordnet
        /// </summary>
        EMPFAENGER_NICHT_ZUGEORDNET,
        /// <summary>
        /// Geraet in Messlokation nicht bekannt
        /// </summary>
        GERAET_UNBEKANNT,
        /// <summary>
        /// Obis-Kennzahl in Meldepunkt/Tranche nicht bekannt
        /// </summary>
        OBIS_UNBEKANNT,
        /// <summary>
        /// Fehlerhafte Referenzierung
        /// </summary>
        REFERENZIERUNG_FEHLERHAFT,
        /// <summary>
        /// Zuodnungstupel unbekannt
        /// </summary>
        TUPEL_UNBEKANNT,
        /// <summary>
        /// Absender zum Zeitpunkt dem Tupel nicht zugeordnet
        /// </summary>
        ABSENDER_TUPEL_NICHT_ZUGEORDNET,
        /// <summary>
        /// Empfaenger zum Zeitpunkt dem Tupel nicht zugeordnet
        /// </summary>
        EMPFAENGER_TUPEL_NICHT_ZUGEORDNET,
        /// <summary>
        /// Vorkommastellen zu lang
        /// </summary>
        VORKOMMA_ZU_VIELE_STELLEN,
        /// <summary>
        /// Zeitreihe ist unvollständig
        /// </summary>
        ZEITREIHE_UNVOLLSTAENDIG,
        /// <summary>
        /// Referenziertes Tupel ist unbekannt
        /// </summary>
        REFERENZIERTES_TUPEL_UNBEKANNT,
        /// <summary>
        /// Marktlokation nicht gefunden
        /// </summary>
        MARKTLOKATION_UNBEKANNT,
        /// <summary>
        /// Messlokation nicht gefunden
        /// </summary>
        MESSLOKATION_UNBEKANNT,
        /// <summary>
        /// Meldepunkt nicht mehr im Netzgebiet
        /// </summary>
        MELDEPUNKT_NICHT_MEHR_IM_NETZ,
        /// <summary>
        /// Pflichtfeld nicht gefüllt
        /// </summary>
        ERFORDERLICHE_ANGABE_FEHLT,
        /// <summary>
        /// Geschaeftsvorfall wurde zurückgewiesen
        /// </summary>
        GESCHAEFTSVORFALL_ZURUECKGEWIESEN,
        /// <summary>
        /// Zeitintervall ist negativ oder null
        /// </summary>
        ZEITINTERVALL_NEGATIV,
        /// <summary>
        /// Formatvorgaben wurden nicht eingehalten
        /// </summary>
        FORMAT_NICHT_EINGEHALTEN,
        /// <summary>
        /// Geschaeftsvorfall darf vom Absender nicht benutzt werden
        /// </summary>
        GESCHAEFTSVORFALL_ABSENDER
    }
}