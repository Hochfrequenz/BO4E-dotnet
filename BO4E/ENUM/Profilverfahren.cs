using System.Runtime.Serialization;
using BO4E.meta;

namespace BO4E.ENUM;

/// <summary>Profilverfahren (synthetisch/ analytisch)</summary>
[NonOfficial(NonOfficialCategory.REGULATORY_REQUIREMENTS)]
public enum Profilverfahren
{
    /// <summary>SLP</summary>
    [EnumMember(Value = "SYNTHETISCH")]
    SYNTHETISCH,

    /// <summary>ALP</summary>
    [EnumMember(Value = "ANALYTISCH")]
    ANALYTISCH,
}
