namespace BO4E.ENUM
{

    /// <summary>Auflistung möglicher abzurechnender Gerätetypen.</summary>
    public enum Geraetemerkmal
    {
        /// <summary>
        /// Eintarifzähler
        /// </summary>
        EINTARIF,
        /// <summary>
        /// Zweitarifzähler
        /// </summary>
        ZWEITARIF,
        /// <summary>
        /// Mehrtarifzähler
        /// </summary>
        MEHRTARIF,
        /// <summary>
        /// Gaszähler Größe G2.5
        /// </summary>
        GAS_G2P5, // changed to "GAS_G2P5" as "GAS_G2_5" and "GAS_G25" are equivalent in protobuf.
        /// <summary>
        /// Gaszähler Größe G4
        /// </summary>
        GAS_G4,
        /// <summary>
        /// Gaszähler Größe G6
        /// </summary>
        GAS_G6,
        /// <summary>
        /// Gaszähler Größe G10
        /// </summary>
        GAS_G10,
        /// <summary>
        /// Gaszähler Größe G16
        /// </summary>
        GAS_G16,
        /// <summary>
        /// Gaszähler Größe G25
        /// </summary>
        GAS_G25,
        /// <summary>
        /// Gaszähler Größe G40
        /// </summary>
        GAS_G40,
        /// <summary>
        /// Gaszähler Größe G65
        /// </summary>
        GAS_G65,
        /// <summary>
        /// Gaszähler Größe G100
        /// </summary>
        GAS_G100,
        /// <summary>
        /// Gaszähler Größe G160
        /// </summary>
        GAS_G160,
        /// <summary>
        /// Gaszähler Größe G250
        /// </summary>
        GAS_G250,
        /// <summary>
        /// Gaszähler Größe G400
        /// </summary>
        GAS_G400,
        /// <summary>
        /// Gaszähler Größe G650
        /// </summary>
        GAS_G650,
        /// <summary>
        /// Gaszähler Größe G1000
        /// </summary>
        GAS_G1000,
        /// <summary>
        /// Gaszähler Größe G1600
        /// </summary>
        GAS_G1600,
        /// <summary>
        /// Gaszähler Größe G2500
        /// </summary>
        GAS_G2500,
        /// <summary>
        /// Impulsgeber für Zähler G4 - G100
        /// </summary>
        IMPULSGEBER_G4_G100,
        /// <summary>
        /// Impulsgeber für Zähler größer G100
        /// </summary>
        IMPULSGEBER_G100,
        /// <summary>
        /// Modem-GSM
        /// </summary>
        MODEM_GSM,
        /// <summary>
        /// Modem-GPRS
        /// </summary>
        MODEM_GPRS,
        /// <summary>
        /// Modem-FUNK
        /// </summary>
        MODEM_FUNK,
        /// <summary>
        /// vom Messstellenbetreiber beigestelltes GSM-Modem ohne Lastgangmessung
        /// </summary>
        MODEM_GSM_O_LG,
        /// <summary>
        /// vom Messstellenbetreiber beigestelltes GSM-Modem mit Lastgangmessung
        /// </summary>
        MODEM_GSM_M_LG,
        /// <summary>
        /// vom Messstellenbetreiber beigestelltes Festnetz-Modem
        /// </summary>
        MODEM_FESTNETZ,
        /// <summary>
        /// vom Messstellenbetreiber bereitgestelltes GPRS-Modem Lastgangmessung
        /// </summary>
        MODEM_GPRS_M_LG,
        /// <summary>
        /// PLC-Kom.-Einrichtung (Powerline Communication)
        /// </summary>
        PLC_COM,
        /// <summary>
        /// Ethernet-Kom.-Einricht. LAN/WLAN
        /// </summary>
        ETHERNET_KOM,
        /// <summary>
        /// Ethernet-Kom.-Einricht. DSL
        /// </summary>
        DSL_KOM,
        /// <summary>
        /// Ethernet-Kom.-Einricht. LTE
        /// </summary>
        LTE_KOM,
        /// <summary>
        /// Rundsteuerempfänger
        /// </summary>
        RUNDSTEUEREMPFAENGER,
        /// <summary>
        /// Tarifschaltgerät
        /// </summary>
        TARIFSCHALTGERAET,
        /// <summary>
        /// Zustandsmengenumwerter
        /// </summary>
        ZUSTANDS_MU,
        /// <summary>
        /// Temperaturmengenumwerter
        /// </summary>
        TEMPERATUR_MU,
        /// <summary>
        /// Kompaktmengenumwerter
        /// </summary>
        KOMPAKT_MU,
        /// <summary>
        /// Systemmengenumwerter
        /// </summary>
        SYSTEM_MU,
        /// <summary>
        /// Unbestimmtes Merkmal
        /// </summary>
        UNBESTIMMT
    }
}
