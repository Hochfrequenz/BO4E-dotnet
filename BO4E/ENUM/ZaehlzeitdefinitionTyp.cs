#nullable enable
using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>
/// Zählzeitdefinitionstyp
/// </summary>
public enum ZaehlzeitdefinitionTyp
{
    /// <summary>
    /// Wärmepumpe
    /// </summary>
    /// <remarks>Z29</remarks>
    [EnumMember(Value = "WAERMEPUMPE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("WAERMEPUMPE")]
    WAERMEPUMPE,

    /// <summary>
    /// Nachtspeicherheizung
    /// </summary>
    /// <remarks>Z30</remarks>
    [EnumMember(Value = "NACHTSPEICHERHEIZUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("NACHTSPEICHERHEIZUNG")]
    NACHTSPEICHERHEIZUNG,

    /// <summary>
    /// Schwachlastzeifenster
    /// </summary>
    /// <remarks>Z31</remarks>
    [EnumMember(Value = "SCHWACHLASTZEITFENSTER")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SCHWACHLASTZEITFENSTER")]
    SCHWACHLASTZEITFENSTER,

    /// <summary>
    /// sonstige Zaehlzeitdefinition
    /// </summary>
    /// <remarks>Z32</remarks>
    [EnumMember(Value = "SONSTIGE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SONSTIGE")]
    SONSTIGE,

    /// <summary>
    /// Hochlastzeitfenster
    /// </summary>
    /// <remarks>Z35</remarks>
    [EnumMember(Value = "HOCHLASTZEITFENSTER")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("HOCHLASTZEITFENSTER")]
    HOCHLASTZEITFENSTER,
}
