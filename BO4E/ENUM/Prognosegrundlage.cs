using System.Runtime.Serialization;
using BO4E.meta;

namespace BO4E.ENUM;

/// <summary>Prognosegrundlage (WERTE, PROFILE)</summary>
[NonOfficial(NonOfficialCategory.REGULATORY_REQUIREMENTS)]
public enum Prognosegrundlage
{
    /// <summary>Prognose auf der Basis von Werten</summary>
    [EnumMember(Value = "WERTE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("WERTE")]
    WERTE,

    /// <summary>Prognose auf der Basis von Profilen</summary>
    [EnumMember(Value = "PROFILE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("PROFILE")]
    PROFILE,
}
