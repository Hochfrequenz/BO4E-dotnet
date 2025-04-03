using System.Runtime.Serialization;
using BO4E.meta.LenientConverters;

namespace BO4E.ENUM;

/// <summary>Verwendungungszweck der Werte Marktlokation</summary>
[System.Text.Json.Serialization.JsonConverter(
    typeof(SystemTextVerwendungszweckStringEnumConverter)
)]
[Newtonsoft.Json.JsonConverter(typeof(NewtonsoftVerwendungszweckStringEnumConverter))]
public enum Verwendungszweck
{
    /// <summary>Z84: Netznutzungsabrechnung</summary>
    [EnumMember(Value = "NETZNUTZUNGSABRECHNUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("NETZNUTZUNGSABRECHNUNG")]
    NETZNUTZUNGSABRECHNUNG,

    /// <summary>Z85: Bilanzkreisabrechnung</summary>
    [EnumMember(Value = "BILANZKREISABRECHNUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BILANZKREISABRECHNUNG")]
    BILANZKREISABRECHNUNG,

    /// <summary>Z86: Mehrmindermengenabrechnung</summary>
    [EnumMember(Value = "MEHRMINDERMENGENABRECHNUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MEHRMINDERMENGENABRECHNUNG")]
    MEHRMINDERMENGENABRECHNUNG,

    /// <summary>Z47: Endkundenabrechnung</summary>
    [EnumMember(Value = "ENDKUNDENABRECHNUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ENDKUNDENABRECHNUNG")]
    ENDKUNDENABRECHNUNG,

    /// <summary>ZD1: Blindarbeitabrechnung / Betriebsführung</summary>
    [EnumMember(Value = "BLINDARBEITABRECHNUNG_BETRIEBSFUEHRUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName(
        "BLINDARBEITABRECHNUNG_BETRIEBSFUEHRUNG"
    )]
    BLINDARBEITABRECHNUNG_BETRIEBSFUEHRUNG,

    /// <summary>
    /// Übermittlung an das Herkunftsnachweisregister (HKNR)
    /// </summary>
    /// <remarks>Z92</remarks>
    [EnumMember(Value = "UEBERMITTLUNG_AN_DAS_HKNR")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("UEBERMITTLUNG_AN_DAS_HKNR")]
    UEBERMITTLUNG_AN_DAS_HKNR,

    /// <summary>
    /// Zur Ermittlung der Ausgeglichenheit von Bilanzkreisen
    ///</summary>
    /// <remarks>ZB5</remarks>
    [EnumMember(Value = "ERMITTLUNG_AUSGEGLICHENHEIT_BILANZKREIS")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName(
        "ERMITTLUNG_AUSGEGLICHENHEIT_BILANZKREIS"
    )]
    ERMITTLUNG_AUSGEGLICHENHEIT_BILANZKREIS,
}
