using System.Runtime.Serialization;
using BO4E.meta;

namespace BO4E.ENUM;

/// <summary>Codes der SummenzeitreihentypenDie nachfolgenden Codes sind in DE7111 zu nutzen:</summary>
// https://www.edi-energy.de/index.php?id=38&tx_bdew_bdew%5Buid%5D=695&tx_bdew_bdew%5Baction%5D=download&tx_bdew_bdew%5Bcontroller%5D=Dokument&cHash=67782e05d8b0f75fbe3a0e1801d07ed0
[NonOfficial(NonOfficialCategory.REGULATORY_REQUIREMENTS)]
public enum Zeitreihentyp
{
    /// <summary>Einspeisegangsumme</summary>
    [EnumMember(Value = "EGS")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("EGS")]
    EGS,

    /// <summary>Lastgangsumme</summary>
    [EnumMember(Value = "LGS")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("LGS")]
    LGS,

    /// <summary>Netzzeitreihe</summary>
    [EnumMember(Value = "NZR")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("NZR")]
    NZR,

    /// <summary>Standardeinspeiseprofilsumme</summary>
    [EnumMember(Value = "SES")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SES")]
    SES,

    /// <summary>Standardlastsumme</summary>
    [EnumMember(Value = "SLS")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SLS")]
    SLS,

    /// <summary>Tagesparameterabhängige Einspeiseprofilsumme</summary>
    [EnumMember(Value = "TES")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("TES")]
    TES,

    /// <summary>Tagesparameterabhängige Lastprofilsumme</summary>
    [EnumMember(Value = "TLS")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("TLS")]
    TLS,

    /// <summary>
    /// gemeinsame Messung aus SLS und TLS
    /// </summary>
    [EnumMember(Value = "SLS_TLS")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SLS_TLS")]
    SLS_TLS,

    /// <summary>
    /// Gemeinsame Messung aus SES und TES
    /// </summary>
    [EnumMember(Value = "SES_TES")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SES_TES")]
    SES_TES,
}
