using System.Runtime.Serialization;
using BO4E.meta;

namespace BO4E.ENUM;

/// <summary>Profilart (temperaturabhängig / standardlastprofil)</summary>
[NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
public enum Profilart
{
    /// <summary>ART_STANDARDLASTPROFIL</summary>
    /// <remarks>Z02</remarks>
    [EnumMember(Value = "ART_STANDARDLASTPROFIL")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ART_STANDARDLASTPROFIL")]
    ART_STANDARDLASTPROFIL,

    /// <summary>ART_TAGESPARAMETERABHAENGIGES_LASTPROFIL</summary>
    /// <remarks>Z03</remarks>
    [EnumMember(Value = "ART_TAGESPARAMETERABHAENGIGES_LASTPROFIL")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName(
        "ART_TAGESPARAMETERABHAENGIGES_LASTPROFIL"
    )]
    ART_TAGESPARAMETERABHAENGIGES_LASTPROFIL,

    /// <summary>ART_LASTPROFIL</summary>
    /// <remarks>Z12</remarks>
    [EnumMember(Value = "ART_LASTPROFIL")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ART_LASTPROFIL")]
    ART_LASTPROFIL,

    /// <summary>Z04 Standardeinspeiseprofil</summary>
    /// <remarks>Z04</remarks>
    [EnumMember(Value = "ART_STANDARDEINSPEISEPROFIL")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ART_STANDARDEINSPEISEPROFIL")]
    ART_STANDARDEINSPEISEPROFIL,

    /// <summary>Z05 tagesparameterabhängiges Einspeiseprofil</summary>
    /// <remarks>Z05</remarks>
    [EnumMember(Value = "ART_TAGESPARAMETERABHAENGIGES_EINSPEISEPROFIL")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName(
        "ART_TAGESPARAMETERABHAENGIGES_EINSPEISEPROFIL"
    )]
    ART_TAGESPARAMETERABHAENGIGES_EINSPEISEPROFIL,
}
