using System;
using System.Runtime.Serialization;

using ProtoBuf;

namespace BO4E.ENUM;

/// <summary>Auflistung möglicher abzurechnender Gerätetypen.</summary>
public enum Geraetetyp
{
    /// <summary>Wechselstromzähler</summary>
    [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(WECHSELSTROMZAEHLER))]
    [EnumMember(Value = "WECHSELSTROMZAEHLER")]
    WECHSELSTROMZAEHLER,

    /// <summary>Drehstromzähler</summary>
    [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(DREHSTROMZAEHLER))]
    [EnumMember(Value = "DREHSTROMZAEHLER")]
    DREHSTROMZAEHLER,

    /// <summary>Zweirichtungszähler</summary>
    [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(ZWEIRICHTUNGSZAEHLER))]
    [EnumMember(Value = "ZWEIRICHTUNGSZAEHLER")]
    ZWEIRICHTUNGSZAEHLER,

    /// <summary>RLM-Zähler</summary>
    [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(RLM_ZAEHLER))]
    [EnumMember(Value = "RLM_ZAEHLER")]
    RLM_ZAEHLER,

    /// <summary>
    ///     Zähler eines Intelligenten Messsystems
    /// </summary>
    [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(IMS_ZAEHLER))]
    [EnumMember(Value = "IMS_ZAEHLER")]
    IMS_ZAEHLER,

    /// <summary>Balgengaszähler</summary>
    [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(BALGENGASZAEHLER))]
    [EnumMember(Value = "BALGENGASZAEHLER")]
    BALGENGASZAEHLER,

    /// <summary>Maximumzähler (Schleppzähler)</summary>
    [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(MAXIMUMZAEHLER))]
    [EnumMember(Value = "MAXIMUMZAEHLER")]
    MAXIMUMZAEHLER,

    /// <summary>Multiplexeranlage</summary>
    [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(MULTIPLEXANLAGE))]
    [EnumMember(Value = "MULTIPLEXANLAGE")]
    MULTIPLEXANLAGE,

    /// <summary>Pauschalanlagen</summary>
    [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(PAUSCHALANLAGE))]
    [EnumMember(Value = "PAUSCHALANLAGE")]
    PAUSCHALANLAGE,

    /// <summary>Verstärkeranlage</summary>
    [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(VERSTAERKERANLAGE))]
    [EnumMember(Value = "VERSTAERKERANLAGE")]
    VERSTAERKERANLAGE,

    /// <summary>Summationsgerät</summary>
    [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(SUMMATIONSGERAET))]
    [EnumMember(Value = "SUMMATIONSGERAET")]
    SUMMATIONSGERAET,

    /// <summary>Impulsgeber</summary>
    [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(IMPULSGEBER))]
    [EnumMember(Value = "IMPULSGEBER")]
    IMPULSGEBER,

    /// <summary>EDL 21 Zähleraufsatz für Zähler</summary>
    [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(EDL_21_ZAEHLERAUFSATZ))]
    [EnumMember(Value = "EDL_21_ZAEHLERAUFSATZ")]
    EDL_21_ZAEHLERAUFSATZ,

    /// <summary>Vier-Quadranten-Lastgangzähler</summary>
    [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(VIER_QUADRANTEN_LASTGANGZAEHLER))]
    [EnumMember(Value = "VIER_QUADRANTEN_LASTGANGZAEHLER")]
    VIER_QUADRANTEN_LASTGANGZAEHLER,

    /// <summary>Mengenumwerter</summary>
    [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(MENGENUMWERTER))]
    [EnumMember(Value = "MENGENUMWERTER")]
    MENGENUMWERTER,

    /// <summary>Stromwandler</summary>
    [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(STROMWANDLER))]
    [EnumMember(Value = "STROMWANDLER")]
    STROMWANDLER,

    /// <summary>Spannungs-Wandler</summary>
    [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(SPANNUNGSWANDLER))]
    [EnumMember(Value = "SPANNUNGSWANDLER")]
    SPANNUNGSWANDLER,

    /// <summary>Datenlogger</summary>
    [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(DATENLOGGER))]
    [EnumMember(Value = "DATENLOGGER")]
    DATENLOGGER,

    /// <summary>Kommunikationsanschluss</summary>
    [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(KOMMUNIKATIONSANSCHLUSS))]
    [EnumMember(Value = "KOMMUNIKATIONSANSCHLUSS")]
    KOMMUNIKATIONSANSCHLUSS,

    /// <summary>Modem</summary>
    [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(MODEM))]
    [EnumMember(Value = "MODEM")]
    MODEM,

    /// <summary>
    ///     vom Messstellenbetreiber beigestellte Telekommunikationseinrichtung (Telefonanschluss)
    /// </summary>
    [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(TELEKOMMUNIKATIONSEINRICHTUNG))]
    [EnumMember(Value = "TELEKOMMUNIKATIONSEINRICHTUNG")]
    TELEKOMMUNIKATIONSEINRICHTUNG,

    /// <summary>Drehkolbengaszähler</summary>
    [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(DREHKOLBENGASZAEHLER))]
    [EnumMember(Value = "DREHKOLBENGASZAEHLER")]
    DREHKOLBENGASZAEHLER,

    /// <summary>Turbinenradgaszähler</summary>
    [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(TURBINENRADGASZAEHLER))]
    [EnumMember(Value = "TURBINENRADGASZAEHLER")]
    TURBINENRADGASZAEHLER,

    /// <summary>Ultraschallzähler</summary>
    [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(ULTRASCHALLZAEHLER))]
    [EnumMember(Value = "ULTRASCHALLZAEHLER")]
    ULTRASCHALLZAEHLER,

    /// <summary>Wirbelgaszähler</summary>
    [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(WIRBELGASZAEHLER))]
    [EnumMember(Value = "WIRBELGASZAEHLER")]
    WIRBELGASZAEHLER,

    /// <summary>moderne Messeinrichtung</summary>
    [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(MODERNE_MESSEINRICHTUNG))]
    [EnumMember(Value = "MODERNE_MESSEINRICHTUNG")]
    MODERNE_MESSEINRICHTUNG,

    /// <summary>elektronischer Haushaltszähler</summary>
    [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(ELEKTRONISCHER_HAUSHALTSZAEHLER))]
    [EnumMember(Value = "ELEKTRONISCHER_HAUSHALTSZAEHLER")]
    ELEKTRONISCHER_HAUSHALTSZAEHLER,

    /// <summary>Steuereinrichtung</summary>
    [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(STEUEREINRICHTUNG))]
    [EnumMember(Value = "STEUEREINRICHTUNG")]
    STEUEREINRICHTUNG,

    /// <summary>technische Steuereinrichtung</summary>
    [Obsolete("Verwenden Sie die detailierte Steuereinrichtung", false)]
#pragma warning disable CS0618 // Type or member is obsolete
    [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(TECHNISCHESTEUEREINRICHTUNG))]
#pragma warning restore CS0618 // Type or member is obsolete
    [EnumMember(Value = "TECHNISCHESTEUEREINRICHTUNG")]
    TECHNISCHESTEUEREINRICHTUNG,

    /// <summary>Tarifschaltgerät</summary>
    [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(TARIFSCHALTGERAET))]
    [EnumMember(Value = "TARIFSCHALTGERAET")]
    TARIFSCHALTGERAET,

    /// <summary>Rundsteuerempfänger</summary>
    [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(RUNDSTEUEREMPFAENGER))]
    [EnumMember(Value = "RUNDSTEUEREMPFAENGER")]
    RUNDSTEUEREMPFAENGER,

    /// <summary>optionale zusätzliche Zähleinrichtung</summary>
    [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(OPTIONALE_ZUS_ZAEHLEINRICHTUNG))]
    [EnumMember(Value = "OPTIONALE_ZUS_ZAEHLEINRICHTUNG")]
    OPTIONALE_ZUS_ZAEHLEINRICHTUNG,

    /// <summary>Messwandlersatz Strom iMS und mME</summary>
    [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(MESSWANDLERSATZ_IMS_MME))]
    [EnumMember(Value = "MESSWANDLERSATZ_IMS_MME")]
    MESSWANDLERSATZ_IMS_MME,

    /// <summary>Kombimesswandlersatz (Strom u. Spg) iMS und mME</summary>
    [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(KOMBIMESSWANDLER_IMS_MME))]
    [EnumMember(Value = "KOMBIMESSWANDLER_IMS_MME")]
    KOMBIMESSWANDLER_IMS_MME,

    /// <summary>   Tarifschaltung iMS und mME</summary>
    [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(TARIFSCHALTGERAET_IMS_MME))]
    [EnumMember(Value = "TARIFSCHALTGERAET_IMS_MME")]
    TARIFSCHALTGERAET_IMS_MME,

    /// <summary>Rundsteuerempfänger iMS und mME</summary>
    [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(RUNDSTEUEREMPFAENGER_IMS_MME))]
    [EnumMember(Value = "RUNDSTEUEREMPFAENGER_IMS_MME")]
    RUNDSTEUEREMPFAENGER_IMS_MME,

    /// <summary>Temperaturkompensation</summary>
    [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(TEMPERATUR_KOMPENSATION))]
    [EnumMember(Value = "TEMPERATUR_KOMPENSATION")]
    TEMPERATUR_KOMPENSATION,

    /// <summary>Höchsbelastungsanzeiger</summary>
    [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(HOECHSTBELASTUNGS_ANZEIGER))]
    [EnumMember(Value = "HOECHSTBELASTUNGS_ANZEIGER")]
    HOECHSTBELASTUNGS_ANZEIGER,

    /// <summary>Sonstiges Gerät</summary>
    [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(SONSTIGES_GERAET))]
    [EnumMember(Value = "SONSTIGES_GERAET")]
    SONSTIGES_GERAET,

    /// <summary>Smartmetergateway</summary>
    [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(SMARTMETERGATEWAY))]
    [EnumMember(Value = "SMARTMETERGATEWAY")]
    SMARTMETERGATEWAY,

    /// <summary>Steuerbox</summary>
    [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(STEUERBOX))]
    [EnumMember(Value = "STEUERBOX")]
    STEUERBOX,

    /// <summary>BLOCKSTROMWANDLER</summary>
    [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(BLOCKSTROMWANDLER))]
    [EnumMember(Value = "BLOCKSTROMWANDLER")]
    BLOCKSTROMWANDLER,

    ///<summary>KOMBIMESSWANDLER</summary>
    [ProtoEnum(Name = nameof(Geraetetyp) + "_" + nameof(KOMBIMESSWANDLER))]
    [EnumMember(Value = "KOMBIMESSWANDLER")]
    KOMBIMESSWANDLER,
}