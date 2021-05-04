using ProtoBuf;

namespace BO4E.ENUM
{
    /// <summary>Auflistung der Erzeugungsarten von Energie.</summary>
    public enum Erzeugungsart
    {
        /// <summary>Kraft-Waerme-Koppelung</summary>
        [ProtoEnum(Name = nameof(Erzeugungsart) + "_" + nameof(KWK))]
        KWK,

        /// <summary>Windkraft</summary>
        [ProtoEnum(Name = nameof(Erzeugungsart) + "_" + nameof(WIND))]
        WIND,

        /// <summary>Solarenergie</summary>
        [ProtoEnum(Name = nameof(Erzeugungsart) + "_" + nameof(SOLAR))]
        SOLAR,

        /// <summary>Kernkraft</summary>
        [ProtoEnum(Name = nameof(Erzeugungsart) + "_" + nameof(KERNKRAFT))]
        KERNKRAFT,

        /// <summary>Wasserkraft</summary>
        [ProtoEnum(Name = nameof(Erzeugungsart) + "_" + nameof(WASSER))]
        WASSER,

        /// <summary>Geothermie</summary>
        [ProtoEnum(Name = nameof(Erzeugungsart) + "_" + nameof(GEOTHERMIE))]
        GEOTHERMIE,

        /// <summary>Biomasse</summary>
        [ProtoEnum(Name = nameof(Erzeugungsart) + "_" + nameof(BIOMASSE))]
        BIOMASSE,

        /// <summary>Kohle</summary>
        [ProtoEnum(Name = nameof(Erzeugungsart) + "_" + nameof(KOHLE))]
        KOHLE,

        /// <summary>Erdgas</summary>
        [ProtoEnum(Name = nameof(Erzeugungsart) + "_" + nameof(GAS))]
        GAS,

        /// <summary>Sonstige</summary>
        [ProtoEnum(Name = nameof(Erzeugungsart) + "_" + nameof(SONSTIGE))]
        SONSTIGE,

        /// <summary>Sonstige nach EEG</summary>
        [ProtoEnum(Name = nameof(Erzeugungsart) + "_" + nameof(SONSTIGE_EEG))]
        SONSTIGE_EEG
    }
}