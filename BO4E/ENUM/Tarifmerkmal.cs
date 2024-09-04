using ProtoBuf;

using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary> </summary>
public enum Tarifmerkmal
{
    /// <summary>Vorkassenprodukt</summary>
    [ProtoEnum(Name = nameof(Tarifmerkmal) + "_" + nameof(VORKASSE))]
    [EnumMember(Value = "VORKASSE")]
    VORKASSE,

    /// <summary>Paketpreisprodukt</summary>
    [ProtoEnum(Name = nameof(Tarifmerkmal) + "_" + nameof(PAKET))]
    [EnumMember(Value = "PAKET")]
    PAKET,

    /// <summary>Kombiprodukt</summary>
    [ProtoEnum(Name = nameof(Tarifmerkmal) + "_" + nameof(KOMBI))]
    [EnumMember(Value = "KOMBI")]
    KOMBI,

    /// <summary>Festpreisprodukt</summary>
    [ProtoEnum(Name = nameof(Tarifmerkmal) + "_" + nameof(FESTPREIS))]
    [EnumMember(Value = "FESTPREIS")]
    FESTPREIS,

    /// <summary>Baustromprodukt</summary>
    [ProtoEnum(Name = nameof(Tarifmerkmal) + "_" + nameof(BAUSTROM))]
    [EnumMember(Value = "BAUSTROM")]
    BAUSTROM,

    /// <summary>Hauslichtprodukt</summary>
    [ProtoEnum(Name = nameof(Tarifmerkmal) + "_" + nameof(HAUSLICHT))]
    [EnumMember(Value = "HAUSLICHT")]
    HAUSLICHT,

    /// <summary>Heizstromprodukt</summary>
    [ProtoEnum(Name = nameof(Tarifmerkmal) + "_" + nameof(HEIZSTROM))]
    [EnumMember(Value = "HEIZSTROM")]
    HEIZSTROM,
}