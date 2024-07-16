using ProtoBuf;

using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Gibt den Status eines Angebotes an.</summary>
public enum Angebotsstatus
{
    /// <summary>
    ///     Konzeption
    /// </summary>
    [EnumMember(Value = "KONZEPTION")]
    KONZEPTION,

    /// <summary>
    ///     unverbindlich
    /// </summary>
    [EnumMember(Value = "UNVERBINDLICH")]
    UNVERBINDLICH,

    /// <summary>
    ///     verbindlich
    /// </summary>
    [EnumMember(Value = "VERBINDLICH")]
    VERBINDLICH,

    /// <summary>
    ///     beauftragt
    /// </summary>
    [EnumMember(Value = "BEAUFTRAGT")]
    BEAUFTRAGT,

    /// <summary>
    ///     ungültig
    /// </summary>
    [EnumMember(Value = "UNGUELTIG")]
    UNGUELTIG,

    /// <summary>
    ///     abgelehnt
    /// </summary>
    [ProtoEnum(Name = nameof(Angebotsstatus) + "_" + nameof(ABGELEHNT))]
    [EnumMember(Value = "ABGELEHNT")]
    ABGELEHNT,

    /// <summary>
    ///     nachgefasst
    /// </summary>
    [EnumMember(Value = "NACHGEFASST")]
    NACHGEFASST,

    /// <summary>
    ///     ausstehend
    /// </summary>
    [EnumMember(Value = "AUSSTEHEND")]
    AUSSTEHEND,

    /// <summary>
    ///     erledigt
    /// </summary>
    [EnumMember(Value = "ERLEDIGT")]
    ERLEDIGT
}
