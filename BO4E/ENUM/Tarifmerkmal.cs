using System.Runtime.Serialization;
using ProtoBuf;

namespace BO4E.ENUM;

/// <summary> </summary>
public enum Tarifmerkmal
{
    /// <summary>Vorkassenprodukt</summary>
    [ProtoEnum(Name = nameof(Tarifmerkmal) + "_" + nameof(VORKASSE))]
    [EnumMember(Value = "VORKASSE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("VORKASSE")]
    VORKASSE,

    /// <summary>Paketpreisprodukt</summary>
    [ProtoEnum(Name = nameof(Tarifmerkmal) + "_" + nameof(PAKET))]
    [EnumMember(Value = "PAKET")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("PAKET")]
    PAKET,

    /// <summary>Kombiprodukt</summary>
    [ProtoEnum(Name = nameof(Tarifmerkmal) + "_" + nameof(KOMBI))]
    [EnumMember(Value = "KOMBI")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("KOMBI")]
    KOMBI,

    /// <summary>Festpreisprodukt</summary>
    [ProtoEnum(Name = nameof(Tarifmerkmal) + "_" + nameof(FESTPREIS))]
    [EnumMember(Value = "FESTPREIS")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("FESTPREIS")]
    FESTPREIS,

    /// <summary>Baustromprodukt</summary>
    [ProtoEnum(Name = nameof(Tarifmerkmal) + "_" + nameof(BAUSTROM))]
    [EnumMember(Value = "BAUSTROM")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BAUSTROM")]
    BAUSTROM,

    /// <summary>Hauslichtprodukt</summary>
    [ProtoEnum(Name = nameof(Tarifmerkmal) + "_" + nameof(HAUSLICHT))]
    [EnumMember(Value = "HAUSLICHT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("HAUSLICHT")]
    HAUSLICHT,

    /// <summary>Heizstromprodukt</summary>
    [ProtoEnum(Name = nameof(Tarifmerkmal) + "_" + nameof(HEIZSTROM))]
    [EnumMember(Value = "HEIZSTROM")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("HEIZSTROM")]
    HEIZSTROM,
}
