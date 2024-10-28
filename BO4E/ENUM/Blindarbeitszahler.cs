using System.Runtime.Serialization;
using ProtoBuf;

namespace BO4E.ENUM;

/// <summary>Zahlung der Blindarbeit</summary>
public enum Blindarbeitszahler
{
    /// <summary>Z10: Kunde</summary>
    [ProtoEnum(Name = nameof(Blindarbeitszahler) + "_" + nameof(ANSCHLUSSNEHMER))]
    [EnumMember(Value = "ANSCHLUSSNEHMER")]
    ANSCHLUSSNEHMER,

    /// <summary>Z11: Lieferant</summary>
    [ProtoEnum(Name = nameof(Blindarbeitszahler) + "_" + nameof(LIEFERANT))]
    [EnumMember(Value = "LIEFERANT")]
    LIEFERANT,
}
