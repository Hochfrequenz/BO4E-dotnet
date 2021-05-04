using System;
using ProtoBuf;

namespace BO4E.ENUM
{
    /// <summary>Auflistung möglicher abzurechnender Gerätetypen.</summary>
    public enum Geraetetyp
    {
        /// <summary>Wechselstromzähler</summary>
        [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(WECHSELSTROMZAEHLER))]
        WECHSELSTROMZAEHLER,

        /// <summary>Drehstromzähler</summary>
        [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(DREHSTROMZAEHLER))]
        DREHSTROMZAEHLER,

        /// <summary>Zweirichtungszähler</summary>
        [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(ZWEIRICHTUNGSZAEHLER))]
        ZWEIRICHTUNGSZAEHLER,

        /// <summary>RLM-Zähler</summary>
        [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(RLM_ZAEHLER))]
        RLM_ZAEHLER,

        /// <summary>
        ///     Zähler eines Intelligenten Messsystems
        /// </summary>
        [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(IMS_ZAEHLER))]
        IMS_ZAEHLER,

        /// <summary>Balgengaszähler</summary>
        [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(BALGENGASZAEHLER))]
        BALGENGASZAEHLER,

        /// <summary>Maximumzähler (Schleppzähler)</summary>
        [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(MAXIMUMZAEHLER))]
        MAXIMUMZAEHLER,

        /// <summary>Multiplexeranlage</summary>
        [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(MULTIPLEXANLAGE))]
        MULTIPLEXANLAGE,

        /// <summary>Pauschalanlagen</summary>
        [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(PAUSCHALANLAGE))]
        PAUSCHALANLAGE,

        /// <summary>Verstärkeranlage</summary>
        [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(VERSTAERKERANLAGE))]
        VERSTAERKERANLAGE,

        /// <summary>Summationsgerät</summary>
        [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(SUMMATIONSGERAET))]
        SUMMATIONSGERAET,

        /// <summary>Impulsgeber</summary>
        [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(IMPULSGEBER))]
        IMPULSGEBER,

        /// <summary>EDL 21 Zähleraufsatz für Zähler</summary>
        [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(EDL_21_ZAEHLERAUFSATZ))]
        EDL_21_ZAEHLERAUFSATZ,

        /// <summary>Vier-Quadranten-Lastgangzähler</summary>
        [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(VIER_QUADRANTEN_LASTGANGZAEHLER))]
        VIER_QUADRANTEN_LASTGANGZAEHLER,

        /// <summary>Mengenumwerter</summary>
        [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(MENGENUMWERTER))]
        MENGENUMWERTER,

        /// <summary>Stromwandler</summary>
        [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(STROMWANDLER))]
        STROMWANDLER,

        /// <summary>Spannungs-Wandler</summary>
        [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(SPANNUNGSWANDLER))]
        SPANNUNGSWANDLER,

        /// <summary>Datenlogger</summary>
        [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(DATENLOGGER))]
        DATENLOGGER,

        /// <summary>Kommunikationsanschluss</summary>
        [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(KOMMUNIKATIONSANSCHLUSS))]
        KOMMUNIKATIONSANSCHLUSS,

        /// <summary>Modem</summary>
        [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(MODEM))]
        MODEM,

        /// <summary>
        ///     vom Messstellenbetreiber beigestellte Telekommunikationseinrichtung (Telefonanschluss)
        /// </summary>
        [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(TELEKOMMUNIKATIONSEINRICHTUNG))]
        TELEKOMMUNIKATIONSEINRICHTUNG,

        /// <summary>Drehkolbengaszähler</summary>
        [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(DREHKOLBENGASZAEHLER))]
        DREHKOLBENGASZAEHLER,

        /// <summary>Turbinenradgaszähler</summary>
        [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(TURBINENRADGASZAEHLER))]
        TURBINENRADGASZAEHLER,

        /// <summary>Ultraschallzähler</summary>
        [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(ULTRASCHALLZAEHLER))]
        ULTRASCHALLZAEHLER,

        /// <summary>Wirbelgaszähler</summary>
        [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(WIRBELGASZAEHLER))]
        WIRBELGASZAEHLER,

        /// <summary>moderne Messeinrichtung</summary>
        [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(MODERNE_MESSEINRICHTUNG))]
        MODERNE_MESSEINRICHTUNG,

        /// <summary>elektronischer Haushaltszähler</summary>
        [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(ELEKTRONISCHER_HAUSHALTSZAEHLER))]
        ELEKTRONISCHER_HAUSHALTSZAEHLER,

        /// <summary>Steuereinrichtung</summary>
        [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(STEUEREINRICHTUNG))]
        STEUEREINRICHTUNG,

        /// <summary>technische Steuereinrichtung</summary>
        [Obsolete("Verwenden Sie die detailierte Steuereinrichtung", false)]
#pragma warning disable CS0618 // Type or member is obsolete
        [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(TECHNISCHESTEUEREINRICHTUNG))]
#pragma warning restore CS0618 // Type or member is obsolete
        TECHNISCHESTEUEREINRICHTUNG,

        /// <summary>Tarifschaltgerät</summary>
        [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(TARIFSCHALTGERAET))]
        TARIFSCHALTGERAET,

        /// <summary>Rundsteuerempfänger</summary>
        [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(RUNDSTEUEREMPFAENGER))]
        RUNDSTEUEREMPFAENGER,

        /// <summary>optionale zusätzliche Zähleinrichtung</summary>
        [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(OPTIONALE_ZUS_ZAEHLEINRICHTUNG))]
        OPTIONALE_ZUS_ZAEHLEINRICHTUNG,

        /// <summary>Messwandlersatz Strom iMS und mME</summary>
        [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(MESSWANDLERSATZ_IMS_MME))]
        MESSWANDLERSATZ_IMS_MME,

        /// <summary>Kombimesswandlersatz (Strom u. Spg) iMS und mME</summary>
        [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(KOMBIMESSWANDLER_IMS_MME))]
        KOMBIMESSWANDLER_IMS_MME,

        /// <summary>   Tarifschaltung iMS und mME</summary>
        [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(TARIFSCHALTGERAET_IMS_MME))]
        TARIFSCHALTGERAET_IMS_MME,

        /// <summary>Rundsteuerempfänger iMS und mME</summary>
        [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(RUNDSTEUEREMPFAENGER_IMS_MME))]
        RUNDSTEUEREMPFAENGER_IMS_MME,

        /// <summary>Temperaturkompensation</summary>
        [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(TEMPERATUR_KOMPENSATION))]
        TEMPERATUR_KOMPENSATION,

        /// <summary>Höchsbelastungsanzeiger</summary>
        [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(HOECHSTBELASTUNGS_ANZEIGER))]
        HOECHSTBELASTUNGS_ANZEIGER,

        /// <summary>Sonstiges Gerät</summary>
        [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(SONSTIGES_GERAET))]
        SONSTIGES_GERAET,

        /// <summary>Smartmetergateway</summary>
        [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(SMARTMETERGATEWAY))]
        SMARTMETERGATEWAY,

        /// <summary>Steuerbox</summary>
        [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(STEUERBOX))]
        STEUERBOX,

        /// <summary>BLOCKSTROMWANDLER</summary>
        [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(BLOCKSTROMWANDLER))]
        BLOCKSTROMWANDLER,

        ///<summary>KOMBIMESSWANDLER</summary>
        [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(KOMBIMESSWANDLER))]
        KOMBIMESSWANDLER
    }
}