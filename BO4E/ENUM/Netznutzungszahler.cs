using System.Runtime.Serialization;
using ProtoBuf;

namespace BO4E.ENUM;

/// <summary>Zahlung der Netznutzung</summary>
public enum Netznutzungszahler
{
    /// <summary>Z10: Kunde</summary>
    [ProtoEnum(Name = nameof(Netznutzungszahler) + "_" + nameof(KUNDE))]
    [EnumMember(Value = "KUNDE")]
    KUNDE,

    /// <summary>Z11: Lieferant</summary>
    [ProtoEnum(Name = nameof(Netznutzungszahler) + "_" + nameof(LIEFERANT))]
    [EnumMember(Value = "LIEFERANT")]
    LIEFERANT,
}
