#nullable enable
using System;
using System.Runtime.Serialization;
using ProtoBuf;

namespace BO4E.ENUM;

/// <summary>Unterscheidung für hoch- und niedrig-kalorisches Gas.</summary>
public enum Gasqualitaet
{
    [Obsolete(
        "This value is only a workaround for the proto3 syntax generation. You shouldn't actually use it"
    )]
#pragma warning disable CS0618 // Type or member is obsolete
    [ProtoEnum(Name = nameof(Gasqualitaet) + "_" + nameof(ZERO))]
#pragma warning restore CS0618 // Type or member is obsolete
    [Newtonsoft.Json.JsonIgnore]
    [System.Text.Json.Serialization.JsonIgnore]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    [EnumMember(Value = "ZERO")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ZERO")]
    ZERO = 0,

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

    /// <summary>High Caloric Gas</summary>
    [EnumMember(Value = "H_GAS")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("H_GAS")]
    H_GAS = 1,

    /// <summary>Low Caloric Gas</summary>
    [EnumMember(Value = "L_GAS")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("L_GAS")]
    L_GAS = 2,
}
