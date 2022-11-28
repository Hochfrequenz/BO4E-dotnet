using ProtoBuf;

using System.Runtime.Serialization;

namespace BO4E.ENUM
{
    /// <summary>Auflistung der Erzeugungsarten von Energie.</summary>
    public enum Erzeugungsart
    {
        /// <summary>Kraft-Waerme-Koppelung</summary>
        [ProtoEnum(Name = nameof(Erzeugungsart) + "_" + nameof(KWK))]
        [EnumMember(Value = "KWK")]
        KWK,

        /// <summary>Windkraft</summary>
        [ProtoEnum(Name = nameof(Erzeugungsart) + "_" + nameof(WIND))]
        [EnumMember(Value = "WIND")]
        WIND,

        /// <summary>Solarenergie</summary>
        [ProtoEnum(Name = nameof(Erzeugungsart) + "_" + nameof(SOLAR))]
        [EnumMember(Value = "SOLAR")]
        SOLAR,

        /// <summary>Kernkraft</summary>
        [ProtoEnum(Name = nameof(Erzeugungsart) + "_" + nameof(KERNKRAFT))]
        [EnumMember(Value = "KERNKRAFT")]
        KERNKRAFT,

        /// <summary>Wasserkraft</summary>
        [ProtoEnum(Name = nameof(Erzeugungsart) + "_" + nameof(WASSER))]
        [EnumMember(Value = "WASSER")]
        WASSER,

        /// <summary>Geothermie</summary>
        [ProtoEnum(Name = nameof(Erzeugungsart) + "_" + nameof(GEOTHERMIE))]
        [EnumMember(Value = "GEOTHERMIE")]
        GEOTHERMIE,

        /// <summary>Biomasse</summary>
        [ProtoEnum(Name = nameof(Erzeugungsart) + "_" + nameof(BIOMASSE))]
        [EnumMember(Value = "BIOMASSE")]
        BIOMASSE,

        /// <summary>Kohle</summary>
        [ProtoEnum(Name = nameof(Erzeugungsart) + "_" + nameof(KOHLE))]
        [EnumMember(Value = "KOHLE")]
        KOHLE,

        /// <summary>Erdgas</summary>
        [ProtoEnum(Name = nameof(Erzeugungsart) + "_" + nameof(GAS))]
        [EnumMember(Value = "GAS")]
        GAS,

        /// <summary>Sonstige</summary>
        [ProtoEnum(Name = nameof(Erzeugungsart) + "_" + nameof(SONSTIGE))]
        [EnumMember(Value = "SONSTIGE")]
        SONSTIGE,

        /// <summary>Sonstige nach EEG</summary>
        [ProtoEnum(Name = nameof(Erzeugungsart) + "_" + nameof(SONSTIGE_EEG))]
        [EnumMember(Value = "SONSTIGE_EEG")]
        SONSTIGE_EEG
    }
}