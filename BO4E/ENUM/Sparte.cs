using ProtoBuf;

namespace BO4E.ENUM
{
    /// <summary>Unterscheidungsmöglichkeiten für die Sparte.</summary>
    public enum Sparte
    {
        /// <summary>Strom</summary>
        [ProtoEnum(Name = nameof(Sparte) + "_" + nameof(STROM))]
        STROM,

        /// <summary>Gas</summary>
        [ProtoEnum(Name = nameof(Sparte) + "_" + nameof(GAS))]
        GAS,

        /// <summary>Fernwärme</summary>
        [ProtoEnum(Name = nameof(Sparte) + "_" + nameof(FERNWAERME))]
        FERNWAERME,

        /// <summary>Nahwärme</summary>
        [ProtoEnum(Name = nameof(Sparte) + "_" + nameof(NAHWAERME))]
        NAHWAERME,

        /// <summary>Wasserversorgung</summary>
        [ProtoEnum(Name = nameof(Sparte) + "_" + nameof(WASSER))]
        WASSER,

        /// <summary>Abwasserentsorgung</summary>
        [ProtoEnum(Name = nameof(Sparte) + "_" + nameof(ABWASSER))]
        ABWASSER
    }
}