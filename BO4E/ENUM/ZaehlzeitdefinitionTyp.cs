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
    WAERMEPUMPE,

    /// <summary>
    /// Nachtspeicherheizung
    /// </summary>
    /// <remarks>Z30</remarks>
    [EnumMember(Value = "NACHTSPEICHERHEIZUNG")]
    NACHTSPEICHERHEIZUNG,

    /// <summary>
    /// Schwachlastzeifenster
    /// </summary>
    /// <remarks>Z31</remarks>
    [EnumMember(Value = "SCHWACHLASTZEITFENSTER")]
    SCHWACHLASTZEITFENSTER,

    /// <summary>
    /// sonstige Zaehlzeitdefinition
    /// </summary>
    /// <remarks>Z32</remarks>
    [EnumMember(Value = "SONSTIGE")]
    SONSTIGE,

    /// <summary>
    /// Hochlastzeitfenster
    /// </summary>
    /// <remarks>Z35</remarks>
    [EnumMember(Value = "HOCHLASTZEITFENSTER")]
    HOCHLASTZEITFENSTER,
}
