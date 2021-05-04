using ProtoBuf;

namespace BO4E.ENUM
{
    /// <summary>Auflistung möglicher abzurechnender Gerätetypen.</summary>
    public enum Geraetemerkmal
    {
        /// <summary>
        ///     Eintarifzähler
        /// </summary>
        [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(EINTARIF))]
        EINTARIF,

        /// <summary>
        ///     Zweitarifzähler
        /// </summary>
        [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(ZWEITARIF))]
        ZWEITARIF,

        /// <summary>
        ///     Mehrtarifzähler
        /// </summary>
        [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(MEHRTARIF))]
        MEHRTARIF,

        /// <summary>
        ///     Gaszähler Größe G2.5
        /// </summary>
        [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(GAS_G2P5))]
        GAS_G2P5, // changed to "GAS_G2P5" as "GAS_G2_5" and "GAS_G25" are equivalent in protobuf.

        /// <summary>
        ///     Gaszähler Größe G4
        /// </summary>
        [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(GAS_G4))]
        GAS_G4,

        /// <summary>
        ///     Gaszähler Größe G6
        /// </summary>
        [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(GAS_G6))]
        GAS_G6,

        /// <summary>
        ///     Gaszähler Größe G10
        /// </summary>
        [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(GAS_G10))]
        GAS_G10,

        /// <summary>
        ///     Gaszähler Größe G16
        /// </summary>
        [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(GAS_G16))]
        GAS_G16,

        /// <summary>
        ///     Gaszähler Größe G25
        /// </summary>
        [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(GAS_G25))]
        GAS_G25,

        /// <summary>
        ///     Gaszähler Größe G40
        /// </summary>
        [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(GAS_G40))]
        GAS_G40,

        /// <summary>
        ///     Gaszähler Größe G65
        /// </summary>
        [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(GAS_G65))]
        GAS_G65,

        /// <summary>
        ///     Gaszähler Größe G100
        /// </summary>
        [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(GAS_G100))]
        GAS_G100,

        /// <summary>
        ///     Gaszähler Größe G160
        /// </summary>
        [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(GAS_G160))]
        GAS_G160,

        /// <summary>
        ///     Gaszähler Größe G250
        /// </summary>
        [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(GAS_G250))]
        GAS_G250,

        /// <summary>
        ///     Gaszähler Größe G400
        /// </summary>
        [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(GAS_G400))]
        GAS_G400,

        /// <summary>
        ///     Gaszähler Größe G650
        /// </summary>
        [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(GAS_G650))]
        GAS_G650,

        /// <summary>
        ///     Gaszähler Größe G1000
        /// </summary>
        [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(GAS_G1000))]
        GAS_G1000,

        /// <summary>
        ///     Gaszähler Größe G1600
        /// </summary>
        [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(GAS_G1600))]
        GAS_G1600,

        /// <summary>
        ///     Gaszähler Größe G2500
        /// </summary>
        [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(GAS_G2500))]
        GAS_G2500,

        /// <summary>
        ///     Impulsgeber für Zähler G4 - G100
        /// </summary>
        [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(IMPULSGEBER_G4_G100))]
        IMPULSGEBER_G4_G100,

        /// <summary>
        ///     Impulsgeber für Zähler größer G100
        /// </summary>
        [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(IMPULSGEBER_G100))]
        IMPULSGEBER_G100,

        /// <summary>
        ///     Modem-GSM
        /// </summary>
        [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(MODEM_GSM))]
        MODEM_GSM,

        /// <summary>
        ///     Modem-GPRS
        /// </summary>
        [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(MODEM_GPRS))]
        MODEM_GPRS,

        /// <summary>
        ///     Modem-FUNK
        /// </summary>
        [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(MODEM_FUNK))]
        MODEM_FUNK,

        /// <summary>
        ///     vom Messstellenbetreiber beigestelltes GSM-Modem ohne Lastgangmessung
        /// </summary>
        [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(MODEM_GSM_O_LG))]
        MODEM_GSM_O_LG,

        /// <summary>
        ///     vom Messstellenbetreiber beigestelltes GSM-Modem mit Lastgangmessung
        /// </summary>
        [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(MODEM_GSM_M_LG))]
        MODEM_GSM_M_LG,

        /// <summary>
        ///     vom Messstellenbetreiber beigestelltes Festnetz-Modem
        /// </summary>
        [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(MODEM_FESTNETZ))]
        MODEM_FESTNETZ,

        /// <summary>
        ///     vom Messstellenbetreiber bereitgestelltes GPRS-Modem Lastgangmessung
        /// </summary>
        [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(MODEM_GPRS_M_LG))]
        MODEM_GPRS_M_LG,

        /// <summary>
        ///     PLC-Kom.-Einrichtung (Powerline Communication)
        /// </summary>
        [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(PLC_COM))]
        PLC_COM,

        /// <summary>
        ///     Ethernet-Kom.-Einricht. LAN/WLAN
        /// </summary>
        [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(ETHERNET_KOM))]
        ETHERNET_KOM,

        /// <summary>
        ///     Ethernet-Kom.-Einricht. DSL
        /// </summary>
        [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(DSL_KOM))]
        DSL_KOM,

        /// <summary>
        ///     Ethernet-Kom.-Einricht. LTE
        /// </summary>
        [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(LTE_KOM))]
        LTE_KOM,

        /// <summary>
        ///     Rundsteuerempfänger
        /// </summary>
        [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(RUNDSTEUEREMPFAENGER))]
        RUNDSTEUEREMPFAENGER,

        /// <summary>
        ///     Tarifschaltgerät
        /// </summary>
        [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(TARIFSCHALTGERAET))]
        TARIFSCHALTGERAET,

        /// <summary>
        ///     Zustandsmengenumwerter
        /// </summary>
        [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(ZUSTANDS_MU))]
        ZUSTANDS_MU,

        /// <summary>
        ///     Temperaturmengenumwerter
        /// </summary>
        [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(TEMPERATUR_MU))]
        TEMPERATUR_MU,

        /// <summary>
        ///     Kompaktmengenumwerter
        /// </summary>
        [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(KOMPAKT_MU))]
        KOMPAKT_MU,

        /// <summary>
        ///     Systemmengenumwerter
        /// </summary>
        [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(SYSTEM_MU))]
        SYSTEM_MU,

        /// <summary>
        ///     Unbestimmtes Merkmal
        /// </summary>
        [ProtoEnum(Name = nameof(Geraetemerkmal) + "_" + nameof(UNBESTIMMT))]
        UNBESTIMMT
    }
}