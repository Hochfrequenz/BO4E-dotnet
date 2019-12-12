namespace BO4E.ENUM
{

    /// <summary>
    /// Klassifizierung der Kriterien für eine regionale Eingrenzung.
    /// </summary>
    public enum Regionskriteriumtyp
    {
        /// <summary>
        /// offizielle Bundeslandkennziffer
        /// </summary>
        BUNDESLANDKENNZIFFER,
        /// <summary>
        /// Bundesland Name
        /// </summary>
        BUNDESLAND_NAME,
        /// <summary>
        /// offizielle Marktgebiet-Codenummer
        /// </summary>
        MARKTGEBIET_NUMMER,
        /// <summary>
        /// Marktgebiet Name
        /// </summary>
        MARKTGEBIET_NAME,
        /// <summary>
        /// offizielle Regelgebiet Nummer
        /// </summary>
        REGELGEBIET_NUMMER,
        /// <summary>
        /// Regelgebiet Name
        /// </summary>
        REGELGEBIET_NAME,
        /// <summary>
        /// offizielle Netzbetreiber-Codenummer
        /// </summary>
        NETZBETREIBER_NUMMER,
        /// <summary>
        /// Netzbetreiber Name
        /// </summary>
        NETZBETREIBER_NAME,
        /// <summary>
        /// Strom: Bilanzierungsgebietsnummer, Gas: Netzkontonummer
        /// </summary>
        BILANZIERUNGS_GEBIET_NUMMER,
        /// <summary>
        /// offizielle Messstellenbetreiber-Codenummer
        /// </summary>
        MSB_NUMMER,
        /// <summary>
        /// Name des MSB
        /// </summary>
        MSB_NAME,

        /// <summary>
        /// offizielle Lieferanten-Codenummer eines Versorgers
        /// </summary>
        VERSORGER_NUMMER,
        /// <summary>
        /// Name eines Versorgers
        /// </summary>
        VERSORGER_NAME,
        /// <summary>
        /// offizielle Lieferanten-Codenummer des Grundversorgers
        /// </summary>
        GRUNDVERSORGER_NUMMER,
        /// <summary>
        /// Name des Grundversorger
        /// </summary>
        GRUNDVERSORGER_NAME,
        /// <summary>
        /// Kreis
        /// </summary>
        KREIS_NAME,
        /// <summary>
        /// offizielle Kreiskennziffer
        /// </summary>
        KREISKENNZIFFER,
        /// <summary>
        /// Gemeinde
        /// </summary>
        GEMEINDE_NAME,
        /// <summary>
        /// offizielle Gemeindekennziffer
        /// </summary>
        GEMEINDEKENNZIFFER,
        /// <summary>
        /// Postleitzahl
        /// </summary>
        POSTLEITZAHL,
        /// <summary>
        /// Ort
        /// </summary>
        ORT,
        /// <summary>
        /// Einwohnerzahl Gemeinde
        /// </summary>
        EINWOHNERZAHL_GEMEINDE,
        /// <summary>
        /// Einwohnerzahl Ort
        /// </summary>
        EINWOHNERZAHL_ORT,
        /// <summary>
        /// km Umkreis
        /// </summary>
        KM_UMKREIS,
        /// <summary>
        /// bundesweite Betrachtung
        /// </summary>
        BUNDESWEIT
    }
}
