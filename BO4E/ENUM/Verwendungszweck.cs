using System.Runtime.Serialization;
using BO4E.meta.LenientConverters;

namespace BO4E.ENUM;

/// <summary>Verwendungungszweck der Werte Marktlokation</summary>
[System.Text.Json.Serialization.JsonConverter(typeof(SystemTextVerwendungszweckStringEnumConverter))]
[Newtonsoft.Json.JsonConverter(typeof(NewtonsoftVerwendungszweckStringEnumConverter))]
public enum Verwendungszweck
{
    /// <summary>Z84: Netznutzungsabrechnung</summary>
    [EnumMember(Value = "NETZNUTZUNGSABRECHNUNG")]
    NETZNUTZUNGSABRECHNUNG,

    /// <summary>Z85: Bilanzkreisabrechnung</summary>
    [EnumMember(Value = "BILANZKREISABRECHNUNG")]
    BILANZKREISABRECHNUNG,

    /// <summary>Z86: Mehrmindermengenabrechnung</summary>
    [EnumMember(Value = "MEHRMINDERMENGENABRECHNUNG")]
    MEHRMINDERMENGENABRECHNUNG,

    /// <summary>Z47: Endkundenabrechnung</summary>
    [EnumMember(Value = "ENDKUNDENABRECHNUNG")]
    ENDKUNDENABRECHNUNG,

    /// <summary>ZD1: Blindarbeitabrechnung / Betriebsführung</summary>
    [EnumMember(Value = "BLINDARBEITABRECHNUNG_BETRIEBSFUEHRUNG")]
    BLINDARBEITABRECHNUNG_BETRIEBSFUEHRUNG,

    /// <summary>
    /// Übermittlung an das Herkunftsnachweisregister (HKNR)
    /// </summary>
    /// <remarks>Z92</remarks>
    [EnumMember(Value = "UEBERMITTLUNG_AN_DAS_HKNR")]
    UEBERMITTLUNG_AN_DAS_HKNR,

    /// <summary>
    /// Zur Ermittlung der Ausgeglichenheit von Bilanzkreisen
    ///</summary>
    /// <remarks>ZB5</remarks>
    [EnumMember(Value = "ERMITTLUNG_AUSGEGLICHENHEIT_BILANZKREIS")]
    ERMITTLUNG_AUSGEGLICHENHEIT_BILANZKREIS,
}
