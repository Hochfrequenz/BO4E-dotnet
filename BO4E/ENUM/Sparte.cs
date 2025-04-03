using System.Runtime.Serialization;
using ProtoBuf;

namespace BO4E.ENUM;

/// <summary>Unterscheidungsmöglichkeiten für die Sparte.</summary>
public enum Sparte
{
    /// <summary>Strom</summary>
    [ProtoEnum(Name = nameof(Sparte) + "_" + nameof(STROM))]
    [EnumMember(Value = "STROM")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("STROM")]
    STROM,

    /// <summary>Gas</summary>
    [ProtoEnum(Name = nameof(Sparte) + "_" + nameof(GAS))]
    [EnumMember(Value = "GAS")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GAS")]
    GAS,

    /// <summary>Fernwärme</summary>
    [ProtoEnum(Name = nameof(Sparte) + "_" + nameof(FERNWAERME))]
    [EnumMember(Value = "FERNWAERME")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("FERNWAERME")]
    FERNWAERME,

    /// <summary>Nahwärme</summary>
    [ProtoEnum(Name = nameof(Sparte) + "_" + nameof(NAHWAERME))]
    [EnumMember(Value = "NAHWAERME")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("NAHWAERME")]
    NAHWAERME,

    /// <summary>Wasserversorgung</summary>
    [ProtoEnum(Name = nameof(Sparte) + "_" + nameof(WASSER))]
    [EnumMember(Value = "WASSER")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("WASSER")]
    WASSER,

    /// <summary>Abwasserentsorgung</summary>
    [ProtoEnum(Name = nameof(Sparte) + "_" + nameof(ABWASSER))]
    [EnumMember(Value = "ABWASSER")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ABWASSER")]
    ABWASSER,
}
