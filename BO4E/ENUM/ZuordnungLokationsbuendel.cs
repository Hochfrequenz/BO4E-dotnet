using System.Runtime.Serialization;
using ProtoBuf;

namespace BO4E.ENUM;

/// <summary>
/// Gibt die Zuordnung einer Lokation zum Lokationsbündel an.
/// </summary>
public enum ZuordnungLokationsbuendel
{
    /// <summary>
    /// EDIFACT Z01
    /// </summary>
    [ProtoEnum(Name = nameof(ZuordnungLokationsbuendel) + "_" + nameof(Z01))]
    [EnumMember(Value = "Z01")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("Z01")]
    Z01,

    /// <summary>
    /// EDIFACT Z02
    /// </summary>
    [ProtoEnum(Name = nameof(ZuordnungLokationsbuendel) + "_" + nameof(Z02))]
    [EnumMember(Value = "Z02")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("Z02")]
    Z02,
}
