using System.Runtime.Serialization;
using ProtoBuf;

namespace BO4E.ENUM;

/// <summary>Gibt den Status eines Angebotes an.</summary>
public enum Angebotsstatus
{
    /// <summary>
    ///     Konzeption
    /// </summary>
    [EnumMember(Value = "KONZEPTION")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("KONZEPTION")]
    KONZEPTION,

    /// <summary>
    ///     unverbindlich
    /// </summary>
    [EnumMember(Value = "UNVERBINDLICH")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("UNVERBINDLICH")]
    UNVERBINDLICH,

    /// <summary>
    ///     verbindlich
    /// </summary>
    [EnumMember(Value = "VERBINDLICH")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("VERBINDLICH")]
    VERBINDLICH,

    /// <summary>
    ///     beauftragt
    /// </summary>
    [EnumMember(Value = "BEAUFTRAGT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BEAUFTRAGT")]
    BEAUFTRAGT,

    /// <summary>
    ///     ungültig
    /// </summary>
    [EnumMember(Value = "UNGUELTIG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("UNGUELTIG")]
    UNGUELTIG,

    /// <summary>
    ///     abgelehnt
    /// </summary>
    [ProtoEnum(Name = nameof(Angebotsstatus) + "_" + nameof(ABGELEHNT))]
    [EnumMember(Value = "ABGELEHNT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ABGELEHNT")]
    ABGELEHNT,

    /// <summary>
    ///     nachgefasst
    /// </summary>
    [EnumMember(Value = "NACHGEFASST")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("NACHGEFASST")]
    NACHGEFASST,

    /// <summary>
    ///     ausstehend
    /// </summary>
    [EnumMember(Value = "AUSSTEHEND")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("AUSSTEHEND")]
    AUSSTEHEND,

    /// <summary>
    ///     erledigt
    /// </summary>
    [EnumMember(Value = "ERLEDIGT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ERLEDIGT")]
    ERLEDIGT,
}
