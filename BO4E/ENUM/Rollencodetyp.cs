using System;
using System.Runtime.Serialization;
using ProtoBuf;

namespace BO4E.ENUM;

/// <summary>Gibt den Codetyp einer Rolle, beispielsweise einer Marktrolle, an.</summary>
public enum Rollencodetyp
{
    [Obsolete(
        "This value is only a workaround for the proto3 syntax generation. You shouldn't actually use it"
    )]
#pragma warning disable CS0618 // Type or member is obsolete
    [ProtoEnum(Name = nameof(Rollencodetyp) + "_" + nameof(ZERO))]
#pragma warning restore CS0618 // Type or member is obsolete
    [Newtonsoft.Json.JsonIgnore]
    [System.Text.Json.Serialization.JsonIgnore]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    [EnumMember(Value = "ZERO")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ZERO")]
    ZERO = 0,

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

    /// <summary>Bundesverband der Energie- u. Wasserwirtschaft</summary>
    [EnumMember(Value = "BDEW")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BDEW")]
    BDEW = 293,

    /// <summary>Deutscher Verein des Gas- und Wasserfaches</summary>
    [EnumMember(Value = "DVGW")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("DVGW")]
    DVGW = 332,

    /// <summary>Global Location Number</summary>
    [EnumMember(Value = "GLN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GLN")]
    GLN = 9,
}
