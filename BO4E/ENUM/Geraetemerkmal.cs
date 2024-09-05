using System.Runtime.Serialization;
using ProtoBuf;

namespace BO4E.ENUM;

/// <summary>Auflistung möglicher abzurechnender Gerätetypen.</summary>
public enum Geraetemerkmal
{
    /// <summary>
    ///     Eintarifzähler
    /// </summary>
    [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(EINTARIF))]
    [EnumMember(Value = "EINTARIF")]
    EINTARIF,

    /// <summary>
    ///     Zweitarifzähler
    /// </summary>
    [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(ZWEITARIF))]
    [EnumMember(Value = "ZWEITARIF")]
    ZWEITARIF,

    /// <summary>
    ///     Mehrtarifzähler
    /// </summary>
    [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(MEHRTARIF))]
    [EnumMember(Value = "MEHRTARIF")]
    MEHRTARIF,

    /// <summary>
    ///     Gaszähler Größe G2.5
    /// </summary>
    [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(GAS_G2P5))]
    [EnumMember(Value = "GAS_G2P5")]
    GAS_G2P5, // changed to "GAS_G2P5" as "GAS_G2_5" and "GAS_G25" are equivalent in protobuf.

    /// <summary>
    ///     Gaszähler Größe G4
    /// </summary>
    [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(GAS_G4))]
    [EnumMember(Value = "GAS_G4")]
    GAS_G4,

    /// <summary>
    ///     Gaszähler Größe G6
    /// </summary>
    [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(GAS_G6))]
    [EnumMember(Value = "GAS_G6")]
    GAS_G6,

    /// <summary>
    ///     Gaszähler Größe G10
    /// </summary>
    [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(GAS_G10))]
    [EnumMember(Value = "GAS_G10")]
    GAS_G10,

    /// <summary>
    ///     Gaszähler Größe G16
    /// </summary>
    [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(GAS_G16))]
    [EnumMember(Value = "GAS_G16")]
    GAS_G16,

    /// <summary>
    ///     Gaszähler Größe G25
    /// </summary>
    [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(GAS_G25))]
    [EnumMember(Value = "GAS_G25")]
    GAS_G25,

    /// <summary>
    ///     Gaszähler Größe G40
    /// </summary>
    [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(GAS_G40))]
    [EnumMember(Value = "GAS_G40")]
    GAS_G40,

    /// <summary>
    ///     Gaszähler Größe G65
    /// </summary>
    [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(GAS_G65))]
    [EnumMember(Value = "GAS_G65")]
    GAS_G65,

    /// <summary>
    ///     Gaszähler Größe G100
    /// </summary>
    [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(GAS_G100))]
    [EnumMember(Value = "GAS_G100")]
    GAS_G100,

    /// <summary>
    ///     Gaszähler Größe G160
    /// </summary>
    [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(GAS_G160))]
    [EnumMember(Value = "GAS_G160")]
    GAS_G160,

    /// <summary>
    ///     Gaszähler Größe G250
    /// </summary>
    [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(GAS_G250))]
    [EnumMember(Value = "GAS_G250")]
    GAS_G250,

    /// <summary>
    ///     Gaszähler Größe G400
    /// </summary>
    [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(GAS_G400))]
    [EnumMember(Value = "GAS_G400")]
    GAS_G400,

    /// <summary>
    ///     Gaszähler Größe G650
    /// </summary>
    [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(GAS_G650))]
    [EnumMember(Value = "GAS_G650")]
    GAS_G650,

    /// <summary>
    ///     Gaszähler Größe G1000
    /// </summary>
    [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(GAS_G1000))]
    [EnumMember(Value = "GAS_G1000")]
    GAS_G1000,

    /// <summary>
    ///     Gaszähler Größe G1600
    /// </summary>
    [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(GAS_G1600))]
    [EnumMember(Value = "GAS_G1600")]
    GAS_G1600,

    /// <summary>
    ///     Gaszähler Größe G2500
    /// </summary>
    [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(GAS_G2500))]
    [EnumMember(Value = "GAS_G2500")]
    GAS_G2500,

    /// <summary>
    ///     Impulsgeber für Zähler G4 - G100
    /// </summary>
    [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(IMPULSGEBER_G4_G100))]
    [EnumMember(Value = "IMPULSGEBER_G4_G100")]
    IMPULSGEBER_G4_G100,

    /// <summary>
    ///     Impulsgeber für Zähler größer G100
    /// </summary>
    [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(IMPULSGEBER_G100))]
    [EnumMember(Value = "IMPULSGEBER_G100")]
    IMPULSGEBER_G100,

    /// <summary>
    ///     Modem-GSM
    /// </summary>
    [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(MODEM_GSM))]
    [EnumMember(Value = "MODEM_GSM")]
    MODEM_GSM,

    /// <summary>
    ///     Modem-GPRS
    /// </summary>
    [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(MODEM_GPRS))]
    [EnumMember(Value = "MODEM_GPRS")]
    MODEM_GPRS,

    /// <summary>
    ///     Modem-FUNK
    /// </summary>
    [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(MODEM_FUNK))]
    [EnumMember(Value = "MODEM_FUNK")]
    MODEM_FUNK,

    /// <summary>
    ///     vom Messstellenbetreiber beigestelltes GSM-Modem ohne Lastgangmessung
    /// </summary>
    [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(MODEM_GSM_O_LG))]
    [EnumMember(Value = "MODEM_GSM_O_LG")]
    MODEM_GSM_O_LG,

    /// <summary>
    ///     vom Messstellenbetreiber beigestelltes GSM-Modem mit Lastgangmessung
    /// </summary>
    [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(MODEM_GSM_M_LG))]
    [EnumMember(Value = "MODEM_GSM_M_LG")]
    MODEM_GSM_M_LG,

    /// <summary>
    ///     vom Messstellenbetreiber beigestelltes Festnetz-Modem
    /// </summary>
    [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(MODEM_FESTNETZ))]
    [EnumMember(Value = "MODEM_FESTNETZ")]
    MODEM_FESTNETZ,

    /// <summary>
    ///     vom Messstellenbetreiber bereitgestelltes GPRS-Modem Lastgangmessung
    /// </summary>
    [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(MODEM_GPRS_M_LG))]
    [EnumMember(Value = "MODEM_GPRS_M_LG")]
    MODEM_GPRS_M_LG,

    /// <summary>
    ///     PLC-Kom.-Einrichtung (Powerline Communication)
    /// </summary>
    [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(PLC_COM))]
    [EnumMember(Value = "PLC_COM")]
    PLC_COM,

    /// <summary>
    ///     Ethernet-Kom.-Einricht. LAN/WLAN
    /// </summary>
    [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(ETHERNET_KOM))]
    [EnumMember(Value = "ETHERNET_KOM")]
    ETHERNET_KOM,

    /// <summary>
    ///     Ethernet-Kom.-Einricht. DSL
    /// </summary>
    [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(DSL_KOM))]
    [EnumMember(Value = "DSL_KOM")]
    DSL_KOM,

    /// <summary>
    ///     Ethernet-Kom.-Einricht. LTE
    /// </summary>
    [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(LTE_KOM))]
    [EnumMember(Value = "LTE_KOM")]
    LTE_KOM,

    /// <summary>
    ///     Rundsteuerempfänger
    /// </summary>
    [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(RUNDSTEUEREMPFAENGER))]
    [EnumMember(Value = "RUNDSTEUEREMPFAENGER")]
    RUNDSTEUEREMPFAENGER,

    /// <summary>
    ///     Tarifschaltgerät
    /// </summary>
    [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(TARIFSCHALTGERAET))]
    [EnumMember(Value = "TARIFSCHALTGERAET")]
    TARIFSCHALTGERAET,

    /// <summary>
    ///     Zustandsmengenumwerter
    /// </summary>
    [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(ZUSTANDS_MU))]
    [EnumMember(Value = "ZUSTANDS_MU")]
    ZUSTANDS_MU,

    /// <summary>
    ///     Temperaturmengenumwerter
    /// </summary>
    [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(TEMPERATUR_MU))]
    [EnumMember(Value = "TEMPERATUR_MU")]
    TEMPERATUR_MU,

    /// <summary>
    ///     Kompaktmengenumwerter
    /// </summary>
    [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(KOMPAKT_MU))]
    [EnumMember(Value = "KOMPAKT_MU")]
    KOMPAKT_MU,

    /// <summary>
    ///     Systemmengenumwerter
    /// </summary>
    [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(SYSTEM_MU))]
    [EnumMember(Value = "SYSTEM_MU")]
    SYSTEM_MU,

    /// <summary>
    ///     Unbestimmtes Merkmal
    /// </summary>
    [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(UNBESTIMMT))]
    [EnumMember(Value = "UNBESTIMMT")]
    UNBESTIMMT,

    /// <summary>
    ///  Wasserzähler Größe MWZW Meßkapsel Wohnungswasserzähler
    /// </summary>
    [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(WASSER_MWZW))]
    [EnumMember(Value = "WASSER_MWZW")]
    WASSER_MWZW,

    /// <summary>
    ///  Wasserzähler Größe WZWW Wohnungswasserzähler
    /// </summary>
    [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(WASSER_WZWW))]
    [EnumMember(Value = "WASSER_WZWW")]
    WASSER_WZWW,

    /// <summary>
    ///  Wasserzähler Größe WZ01 Wasserzähler W01 5 m³/h
    /// </summary>
    [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(WASSER_WZ01))]
    [EnumMember(Value = "WASSER_WZ01")]
    WASSER_WZ01,

    /// <summary>
    ///  Wasserzähler Größe WZ02 Wasserzähler W02 10 m³/h
    /// </summary>
    [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(WASSER_WZ02))]
    [EnumMember(Value = "WASSER_WZ02")]
    WASSER_WZ02,

    /// <summary>
    ///  Wasserzähler Größe WZ03 Wasserzähler W03 20 m³/h
    /// </summary>
    [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(WASSER_WZ03))]
    [EnumMember(Value = "WASSER_WZ03")]
    WASSER_WZ03,

    /// <summary>
    ///  Wasserzähler Größe WZ04 Wasserzähler W04 30 m³/h
    /// </summary>
    [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(WASSER_WZ04))]
    [EnumMember(Value = "WASSER_WZ04")]
    WASSER_WZ04,

    /// <summary>
    ///  Wasserzähler Größe WZ05 Wasserzähler W05 80 m³/h
    /// </summary>
    [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(WASSER_WZ05))]
    [EnumMember(Value = "WASSER_WZ05")]
    WASSER_WZ05,

    /// <summary>
    ///  Wasserzähler Größe WZ06 Wasserzähler W06 120 m³/h
    /// </summary>
    [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(WASSER_WZ06))]
    [EnumMember(Value = "WASSER_WZ06")]
    WASSER_WZ06,

    /// <summary>
    ///  Wasserzähler Größe WZ07 Wasserzähler W07 300 m³/h
    /// </summary>
    [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(WASSER_WZ07))]
    [EnumMember(Value = "WASSER_WZ07")]
    WASSER_WZ07,

    /// <summary>
    ///  Wasserzähler Größe WZ08 Wasserzähler W08 180 m³/h
    /// </summary>
    [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(WASSER_WZ08))]
    [EnumMember(Value = "WASSER_WZ08")]
    WASSER_WZ08,

    /// <summary>
    ///  Wasserzähler Größe WZ09 Wasserzähler W09 140 m³/h
    /// </summary>
    [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(WASSER_WZ09))]
    [EnumMember(Value = "WASSER_WZ09")]
    WASSER_WZ09,

    /// <summary>
    ///  Wasserzähler Größe WZ10 Wasserzähler W10 600 m³/h
    /// </summary>
    [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(WASSER_WZ10))]
    [EnumMember(Value = "WASSER_WZ10")]
    WASSER_WZ10,

    /// <summary>
    ///  Wasserzähler Größe VWZ04 Verbundwasserzähler 30m³/h
    /// </summary>
    [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(WASSER_VWZ04))]
    [EnumMember(Value = "WASSER_VWZ04")]
    WASSER_VWZ04,

    /// <summary>
    ///  Wasserzähler Größe VWZ05 Verbundwasserzähler 80m³/h
    /// </summary>
    [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(WASSER_VWZ05))]
    [EnumMember(Value = "WASSER_VWZ05")]
    WASSER_VWZ05,

    /// <summary>
    ///  Wasserzähler Größe VWZ06 Verbundwasserzähler 120m³/h
    /// </summary>
    [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(WASSER_VWZ06))]
    [EnumMember(Value = "WASSER_VWZ06")]
    WASSER_VWZ06,

    /// <summary>
    ///  Wasserzähler Größe VWZ07 Verbundwasserzähler 300m³/h
    /// </summary>
    [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(WASSER_VWZ07))]
    [EnumMember(Value = "WASSER_VWZ07")]
    WASSER_VWZ07,

    /// <summary>
    ///  Wasserzähler Größe VWZ10 Verbundwasserzähler 600m³/h
    /// </summary>
    [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(WASSER_VWZ10))]
    [EnumMember(Value = "WASSER_VWZ10")]
    WASSER_VWZ10,

    /// <summary>
    ///  Gaszähler Größe G350
    /// </summary>
    [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(GAS_G350))]
    [EnumMember(Value = "GAS_G350")]
    GAS_G350,

    /// <summary>
    ///  Gaszähler Größe G4000
    /// </summary>
    [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(GAS_G4000))]
    [EnumMember(Value = "GAS_G4000")]
    GAS_G4000,

    /// <summary>
    ///  Gaszähler Größe G6500
    /// </summary>
    [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(GAS_G6500))]
    [EnumMember(Value = "GAS_G6500")]
    GAS_G6500,

    /// <summary>
    ///  Gaszähler Größe G10000
    /// </summary>
    [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(GAS_G10000))]
    [EnumMember(Value = "GAS_G10000")]
    GAS_G10000,

    /// <summary>
    ///  Gaszähler Größe G12500
    /// </summary>
    [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(GAS_G12500))]
    [EnumMember(Value = "GAS_G12500")]
    GAS_G12500,

    /// <summary>
    ///  Gaszähler Größe G16000
    /// </summary>
    [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(GAS_G16000))]
    [EnumMember(Value = "GAS_G16000")]
    GAS_G16000,
}
