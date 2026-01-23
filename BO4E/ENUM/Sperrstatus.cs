#nullable enable
using System.Runtime.Serialization;
using BO4E.meta;
using ProtoBuf;

namespace BO4E.ENUM;

/// <summary>
/// Der Sperrstatus beschreibt, ob ein Zähler gesperrt ist oder nicht.
/// </summary>
[NonOfficial(NonOfficialCategory.REGULATORY_REQUIREMENTS)]
public enum Sperrstatus
{
    /// <summary>
    /// Der Zähler ist nicht gesperrt
    /// </summary>
    [ProtoEnum(Name = nameof(Sperrstatus) + "_" + nameof(ENTSPERRT))]
    [EnumMember(Value = "ENTSPERRT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ENTSPERRT")]
    ENTSPERRT,

    /// <summary>
    /// Der Zähler ist gesperrt
    /// </summary>
    [ProtoEnum(Name = nameof(Sperrstatus) + "_" + nameof(GESPERRT))]
    [EnumMember(Value = "GESPERRT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GESPERRT")]
    GESPERRT,
}
