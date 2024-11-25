using System.Runtime.Serialization;
using ProtoBuf;

namespace BO4E.ENUM;

/// <summary>Aufzählung der Möglichkeiten zu Vertragsformen in Ausschreibungen.</summary>
public enum Vertragsform
{
    /// <summary>Online</summary>
    [EnumMember(Value = "ONLINE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ONLINE")]
    ONLINE,

    /// <summary>Direkt</summary>
    [EnumMember(Value = "DIREKT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("DIREKT")]
    DIREKT,

    /// <summary>Auftragsfax</summary>
    [ProtoEnum(Name = nameof(Vertragsform) + "_" + nameof(FAX))]
    [EnumMember(Value = "FAX")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("FAX")]
    FAX,
}
