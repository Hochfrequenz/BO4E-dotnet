using BO4E.meta;

using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Profilart (temperaturabhängig / standardlastprofil)</summary>
[NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
public enum Profilart
{
    /// <summary>ART_STANDARDLASTPROFIL</summary>
    /// <remarks>Z02</remarks>
    [EnumMember(Value = "ART_STANDARDLASTPROFIL")]
    ART_STANDARDLASTPROFIL,

    /// <summary>ART_TAGESPARAMETERABHAENGIGES_LASTPROFIL</summary>
    /// <remarks>Z03</remarks>
    [EnumMember(Value = "ART_TAGESPARAMETERABHAENGIGES_LASTPROFIL")]
    ART_TAGESPARAMETERABHAENGIGES_LASTPROFIL,

    /// <summary>ART_LASTPROFIL</summary>
    /// <remarks>Z12</remarks>
    [EnumMember(Value = "ART_LASTPROFIL")]
    ART_LASTPROFIL,
}
