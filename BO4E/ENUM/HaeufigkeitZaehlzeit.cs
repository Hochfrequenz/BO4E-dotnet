#nullable enable
using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Häufigkeit der Übermittlung der Zählzeit</summary>
public enum HaeufigkeitZaehlzeit
{
    /// <summary>Einmalig</summary>
    [EnumMember(Value = "EINMALIG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("EINMALIG")]
    EINMALIG,

    /// <summary>Jährlich</summary>
    [EnumMember(Value = "JAEHRLICH")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("JAEHRLICH")]
    JAEHRLICH,
}
