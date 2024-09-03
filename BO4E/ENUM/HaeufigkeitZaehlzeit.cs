using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Häufigkeit der Übermittlung der Zählzeit</summary>
public enum HaeufigkeitZaehlzeit
{
    /// <summary>Einmalig</summary>
    [EnumMember(Value = "EINMALIG")]
    EINMALIG,

    /// <summary>Jährlich</summary>
    [EnumMember(Value = "JAEHRLICH")]
    JAEHRLICH
}