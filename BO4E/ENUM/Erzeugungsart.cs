using System.Runtime.Serialization;
using ProtoBuf;

namespace BO4E.ENUM;

/// <summary>Auflistung der Erzeugungsarten von Energie.</summary>
public enum Erzeugungsart
{
    /// <summary>Kraft-Waerme-Koppelung</summary>
    [ProtoEnum(Name = nameof(Erzeugungsart) + "_" + nameof(KWK))]
    [EnumMember(Value = "KWK")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("KWK")]
    KWK,

    /// <summary>Windkraft</summary>
    [ProtoEnum(Name = nameof(Erzeugungsart) + "_" + nameof(WIND))]
    [EnumMember(Value = "WIND")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("WIND")]
    WIND,

    /// <summary>Solarenergie</summary>
    [ProtoEnum(Name = nameof(Erzeugungsart) + "_" + nameof(SOLAR))]
    [EnumMember(Value = "SOLAR")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SOLAR")]
    SOLAR,

    /// <summary>Kernkraft</summary>
    [ProtoEnum(Name = nameof(Erzeugungsart) + "_" + nameof(KERNKRAFT))]
    [EnumMember(Value = "KERNKRAFT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("KERNKRAFT")]
    KERNKRAFT,

    /// <summary>Wasserkraft</summary>
    [ProtoEnum(Name = nameof(Erzeugungsart) + "_" + nameof(WASSER))]
    [EnumMember(Value = "WASSER")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("WASSER")]
    WASSER,

    /// <summary>Geothermie</summary>
    [ProtoEnum(Name = nameof(Erzeugungsart) + "_" + nameof(GEOTHERMIE))]
    [EnumMember(Value = "GEOTHERMIE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GEOTHERMIE")]
    GEOTHERMIE,

    /// <summary>Biomasse</summary>
    [ProtoEnum(Name = nameof(Erzeugungsart) + "_" + nameof(BIOMASSE))]
    [EnumMember(Value = "BIOMASSE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BIOMASSE")]
    BIOMASSE,

    /// <summary>Kohle</summary>
    [ProtoEnum(Name = nameof(Erzeugungsart) + "_" + nameof(KOHLE))]
    [EnumMember(Value = "KOHLE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("KOHLE")]
    KOHLE,

    /// <summary>Erdgas</summary>
    [ProtoEnum(Name = nameof(Erzeugungsart) + "_" + nameof(GAS))]
    [EnumMember(Value = "GAS")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GAS")]
    GAS,

    /// <summary>Sonstige</summary>
    [ProtoEnum(Name = nameof(Erzeugungsart) + "_" + nameof(SONSTIGE))]
    [EnumMember(Value = "SONSTIGE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SONSTIGE")]
    SONSTIGE,

    /// <summary>Sonstige nach EEG</summary>
    [ProtoEnum(Name = nameof(Erzeugungsart) + "_" + nameof(SONSTIGE_EEG))]
    [EnumMember(Value = "SONSTIGE_EEG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SONSTIGE_EEG")]
    SONSTIGE_EEG,
}
