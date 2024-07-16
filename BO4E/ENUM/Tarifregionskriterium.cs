using ProtoBuf;

using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Mit diesen Kriterien können regionale Bereiche definiert werden.</summary>
public enum Tarifregionskriterium
{
    /// <summary>Netznummer</summary>
    [ProtoEnum(Name = nameof(Tarifregionskriterium) + "_" + nameof(NETZ_NUMMER))]
    [EnumMember(Value = "NETZ_NUMMER")]
    NETZ_NUMMER,

    /// <summary>Postleitzahl</summary>
    [ProtoEnum(Name = nameof(Tarifregionskriterium) + "_" + nameof(POSTLEITZAHL))]
    [EnumMember(Value = "POSTLEITZAHL")]
    POSTLEITZAHL,

    /// <summary>Ort</summary>
    [ProtoEnum(Name = nameof(Tarifregionskriterium) + "_" + nameof(ORT))]
    [EnumMember(Value = "ORT")]
    ORT,

    /// <summary>Nummer des Grundversorgers</summary>
    [ProtoEnum(Name = nameof(Tarifregionskriterium) + "_" + nameof(GRUNDVERSORGER_NUMMER))]
    [EnumMember(Value = "GRUNDVERSORGER_NUMMER")]
    GRUNDVERSORGER_NUMMER,
}
