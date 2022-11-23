using ProtoBuf;

using System.Runtime.Serialization;

namespace BO4E.ENUM
{
    /// <summary>Unterscheidungsmöglichkeiten für die Sparte.</summary>
    public enum Sparte
    {
        /// <summary>Strom</summary>
        [ProtoEnum(Name = nameof(Sparte) + "_" + nameof(STROM))]
        [EnumMember(Value = "STROM")]
        STROM,

        /// <summary>Gas</summary>
        [ProtoEnum(Name = nameof(Sparte) + "_" + nameof(GAS))]
        [EnumMember(Value = "GAS")]
        GAS,

        /// <summary>Fernwärme</summary>
        [ProtoEnum(Name = nameof(Sparte) + "_" + nameof(FERNWAERME))]
        [EnumMember(Value = "FERNWAERME")]
        FERNWAERME,

        /// <summary>Nahwärme</summary>
        [ProtoEnum(Name = nameof(Sparte) + "_" + nameof(NAHWAERME))]
        [EnumMember(Value = "NAHWAERME")]
        NAHWAERME,

        /// <summary>Wasserversorgung</summary>
        [ProtoEnum(Name = nameof(Sparte) + "_" + nameof(WASSER))]
        [EnumMember(Value = "WASSER")]
        WASSER,

        /// <summary>Abwasserentsorgung</summary>
        [ProtoEnum(Name = nameof(Sparte) + "_" + nameof(ABWASSER))]
        [EnumMember(Value = "ABWASSER")]
        ABWASSER,
    }
}