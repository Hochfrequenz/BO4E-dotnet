using System.Runtime.Serialization;
using BO4E.meta;

namespace BO4E.ENUM
{
    /// <summary>Codes der Summenzeitreihentypen. Die nachfolgenden Codes sind in DE7111 zu nutzen:</summary>
    // https://www.bdew-mako.de/pdf/Codeliste_der_Zeitreihentypen_1_1d_Lesefassung_20210716.pdf
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

        /// <summary>Ausfallarbeitssumme</summary>
        [EnumMember(Value = "AUS")]
        [System.Text.Json.Serialization.JsonStringEnumMemberName("AUS")]
        AUS,

        /// <summary>Bilanzkreisabweichungssaldo</summary>
        [EnumMember(Value = "BAS")]
        [System.Text.Json.Serialization.JsonStringEnumMemberName("BAS")]
        BAS,

        /// <summary>Differenzzeitreihe</summary>
        [EnumMember(Value = "DBA")]
        [System.Text.Json.Serialization.JsonStringEnumMemberName("DBA")]
        DBA,

        /// <summary>Deltazeitreihe</summary>
        [EnumMember(Value = "DZR")]
        [System.Text.Json.Serialization.JsonStringEnumMemberName("DZR")]
        DZR,

        /// <summary>Deltazeitreihenübertrag</summary>
        [EnumMember(Value = "DZÜ")]
        [System.Text.Json.Serialization.JsonStringEnumMemberName("DZÜ")]
        DZÜ,

        /// <summary>Fahrplanentnahmesumme</summary>
        [EnumMember(Value = "FPE")]
        [System.Text.Json.Serialization.JsonStringEnumMemberName("FPE")]
        FPE,

        /// <summary>Fahrplaneinspeisesumme</summary>
        [EnumMember(Value = "FPI")]
        [System.Text.Json.Serialization.JsonStringEnumMemberName("FPI")]
        FPI,

        /// <summary>Überführungszeitreihe Sekundärregelleistung (Export)</summary>
        [EnumMember(Value = "SRE")]
        [System.Text.Json.Serialization.JsonStringEnumMemberName("SRE")]
        SRE,

        /// <summary>Überführungszeitreihe Sekundärregelleistung (Import)</summary>
        [EnumMember(Value = "SRI")]
        [System.Text.Json.Serialization.JsonStringEnumMemberName("SRI")]
        SRI,

        /// <summary>Verlustzeitreihe</summary>
        [EnumMember(Value = "VZR")]
        [System.Text.Json.Serialization.JsonStringEnumMemberName("VZR")]
        VZR,
    }
}
