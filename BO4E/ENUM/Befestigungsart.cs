using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Befestigungsart</summary>
public enum Befestigungsart
{
    /// <summary>BKE</summary>
    [EnumMember(Value = "STECKTECHNIK")]
    STECKTECHNIK,

    /// <summary>DPA</summary>
    [EnumMember(Value = "DREIPUNKT")]
    DREIPUNKT,

    /// <summary>HUT</summary>
    [EnumMember(Value = "HUTSCHIENE")]
    HUTSCHIENE,

    /// <summary>Z31</summary>
    [EnumMember(Value = "EINSTUTZEN")]
    EINSTUTZEN,

    /// <summary>Z32</summary>
    [EnumMember(Value = "ZWEISTUTZEN")]
    ZWEISTUTZEN
}