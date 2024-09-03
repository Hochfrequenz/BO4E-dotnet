using ProtoBuf;

using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>
///     Abbildung einer Statusinformation für Verträge.
/// </summary>
public enum Vertragstatus
{
    /// <summary>
    ///     in Arbeit
    /// </summary>
    [ProtoEnum(Name = nameof(Vertragstatus) + "_" + nameof(IN_ARBEIT))]
    [EnumMember(Value = "IN_ARBEIT")]
    IN_ARBEIT,

    /// <summary>
    ///     übermittelt
    /// </summary>
    [ProtoEnum(Name = nameof(Vertragstatus) + "_" + nameof(UEBERMITTELT))]
    [EnumMember(Value = "UEBERMITTELT")]
    UEBERMITTELT,

    /// <summary>
    ///     angenommen
    /// </summary>
    [ProtoEnum(Name = nameof(Vertragstatus) + "_" + nameof(ANGENOMMEN))]
    [EnumMember(Value = "ANGENOMMEN")]
    ANGENOMMEN,

    /// <summary>
    ///     aktiv
    /// </summary>
    [ProtoEnum(Name = nameof(Vertragstatus) + "_" + nameof(AKTIV))]
    [EnumMember(Value = "AKTIV")]
    AKTIV,

    /// <summary>
    ///     abgelehnt
    /// </summary>
    [ProtoEnum(Name = nameof(Vertragstatus) + "_" + nameof(ABGELEHNT))]
    [EnumMember(Value = "ABGELEHNT")]
    ABGELEHNT,

    /// <summary>
    ///     widerrufen
    /// </summary>
    [ProtoEnum(Name = nameof(Vertragstatus) + "_" + nameof(WIDERRUFEN))]
    [EnumMember(Value = "WIDERRUFEN")]
    WIDERRUFEN,

    /// <summary>
    ///     storniert
    /// </summary>
    [ProtoEnum(Name = nameof(Vertragstatus) + "_" + nameof(STORNIERT))]
    [EnumMember(Value = "STORNIERT")]
    STORNIERT,

    /// <summary>
    ///     gekündigt
    /// </summary>
    [ProtoEnum(Name = nameof(Vertragstatus) + "_" + nameof(GEKUENDIGT))]
    [EnumMember(Value = "GEKUENDIGT")]
    GEKUENDIGT,

    /// <summary>
    ///     beendet
    /// </summary>
    [ProtoEnum(Name = nameof(Vertragstatus) + "_" + nameof(BEENDET))]
    [EnumMember(Value = "BEENDET")]
    BEENDET,
}