#nullable enable
using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Schwachlastfähigkeit Marktlokation</summary>
public enum Schwachlastfaehig
{
    /// <summary>Z59: Nicht-Schwachlastfähig</summary>
    [EnumMember(Value = "NICHT_SCHWACHLASTFAEHIG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("NICHT_SCHWACHLASTFAEHIG")]
    NICHT_SCHWACHLASTFAEHIG,

    /// <summary>Z60: Schwachlast fähig</summary>
    [EnumMember(Value = "SCHWACHLASTFAEHIG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SCHWACHLASTFAEHIG")]
    SCHWACHLASTFAEHIG,
}
