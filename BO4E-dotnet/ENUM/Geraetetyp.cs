using System;

namespace BO4E.ENUM
{
    /// <summary>Auflistung möglicher abzurechnender Gerätetypen.</summary>
    public enum Geraetetyp
    {
        /// <summary>Wechselstromzähler</summary>
        WECHSELSTROMZAEHLER,
        /// <summary>Drehstromzähler</summary>
        DREHSTROMZAEHLER,
        /// <summary>Zweirichtungszähler</summary>
        ZWEIRICHTUNGSZAEHLER,
        /// <summary>RLM-Zähler</summary>
        RLM_ZAEHLER,
        /// <summary>
        /// Zähler eines Intelligenten Messsystems
        /// </summary>
        IMS_ZAEHLER,
        /// <summary>Balgengaszähler</summary>
        BALGENGASZAEHLER,
        /// <summary>Maximumzähler (Schleppzähler)</summary>
        MAXIMUMZAEHLER,
        /// <summary>Multiplexeranlage</summary>
        MULTIPLEXANLAGE,
        /// <summary>Pauschalanlagen</summary>
        PAUSCHALANLAGE,
        /// <summary>Verstärkeranlage</summary>
        VERSTAERKERANLAGE,
        /// <summary>Summationsgerät</summary>
        SUMMATIONSGERAET,
        /// <summary>Impulsgeber</summary>
        IMPULSGEBER,
        /// <summary>EDL 21 Zähleraufsatz für Zähler</summary>
        EDL_21_ZAEHLERAUFSATZ,
        /// <summary>Vier-Quadranten-Lastgangzähler</summary>
        VIER_QUADRANTEN_LASTGANGZAEHLER,
        /// <summary>Mengenumwerter</summary>
        MENGENUMWERTER,
        /// <summary>Stromwandler</summary>
        STROMWANDLER,
        /// <summary>Spannungs-Wandler</summary>
        SPANNUNGSWANDLER,
        /// <summary>Datenlogger</summary>
        DATENLOGGER,
        /// <summary>Kommunikationsanschluss</summary>
        KOMMUNIKATIONSANSCHLUSS,
        /// <summary>Modem</summary>
        MODEM,
        /// <summary>
        /// vom Messstellenbetreiber beigestellte Telekommunikationseinrichtung (Telefonanschluss)
        ///</summary>
        TELEKOMMUNIKATIONSEINRICHTUNG,
        /// <summary>Drehkolbengaszähler</summary>
        DREHKOLBENGASZAEHLER,
        /// <summary>Turbinenradgaszähler</summary>
        TURBINENRADGASZAEHLER,
        /// <summary>Ultraschallzähler</summary>
        ULTRASCHALLZAEHLER,
        /// <summary>Wirbelgaszähler</summary>
        WIRBELGASZAEHLER,
        /// <summary>moderne Messeinrichtung</summary>
        MODERNE_MESSEINRICHTUNG,
        /// <summary>elektronischer Haushaltszähler</summary>
        ELEKTRONISCHER_HAUSHALTSZAEHLER,
        /// <summary>Steuereinrichtung</summary>
        STEUEREINRICHTUNG,
        /// <summary>technische Steuereinrichtung</summary>
        [Obsolete("Verwenden Sie die detailierte Steuereinrichtung",false)]
        TECHNISCHESTEUEREINRICHTUNG,
        /// <summary>Tarifschaltgerät</summary>
        TARIFSCHALTGERAET,
        /// <summary>Rundsteuerempfänger</summary>
        RUNDSTEUEREMPFAENGER,
        /// <summary>optionale zusätzliche Zähleinrichtung</summary>
        OPTIONALE_ZUS_ZAEHLEINRICHTUNG,
        /// <summary>Messwandlersatz Strom iMS und mME, NSP</summary>
        MESSWANDLERSATZ_IMS_MME,
        /// <summary>Kombimesswandlersatz (Strom u. Spg) iMS und mME</summary>
        KOMBIMESSWANDLER_IMS_MME,
        /// <summary>   Tarifschaltung iMS und mME</summary>
        TARIFSCHALTGERAET_IMS_MME,
        /// <summary>Rundsteuerempfänger iMS und mME</summary>
        RUNDSTEUEREMPFAENGER_IMS_MME,
        /// <summary>Temperaturkompensation</summary>
        TEMPERATUR_KOMPENSATION,
        /// <summary>Höchsbelastungsanzeiger</summary>
        HOECHSTBELASTUNGS_ANZEIGER,
        /// <summary>Sonstiges Gerät</summary>
        SONSTIGES_GERAET,
        /// <summary>Smartmetergateway</summary>
        SMARTMETERGATEWAY,
        /// <summary>Steuerbox</summary>
        STEUERBOX,
        /// <summary>BLOCKSTROMWANDLER</summary>
        BLOCKSTROMWANDLER,
        ///<summary>KOMBIMESSWANDLER</summary>
        KOMBIMESSWANDLER
    }
}
