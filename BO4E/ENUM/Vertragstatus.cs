#nullable enable
using System.Runtime.Serialization;
using ProtoBuf;

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
    [System.Text.Json.Serialization.JsonStringEnumMemberName("IN_ARBEIT")]
    IN_ARBEIT,

    /// <summary>
    ///     übermittelt
    /// </summary>
    [ProtoEnum(Name = nameof(Vertragstatus) + "_" + nameof(UEBERMITTELT))]
    [EnumMember(Value = "UEBERMITTELT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("UEBERMITTELT")]
    UEBERMITTELT,

    /// <summary>
    ///     angenommen
    /// </summary>
    [ProtoEnum(Name = nameof(Vertragstatus) + "_" + nameof(ANGENOMMEN))]
    [EnumMember(Value = "ANGENOMMEN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ANGENOMMEN")]
    ANGENOMMEN,

    /// <summary>
    ///     aktiv
    /// </summary>
    [ProtoEnum(Name = nameof(Vertragstatus) + "_" + nameof(AKTIV))]
    [EnumMember(Value = "AKTIV")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("AKTIV")]
    AKTIV,

    /// <summary>
    ///     abgelehnt
    /// </summary>
    [ProtoEnum(Name = nameof(Vertragstatus) + "_" + nameof(ABGELEHNT))]
    [EnumMember(Value = "ABGELEHNT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ABGELEHNT")]
    ABGELEHNT,

    /// <summary>
    ///     widerrufen
    /// </summary>
    [ProtoEnum(Name = nameof(Vertragstatus) + "_" + nameof(WIDERRUFEN))]
    [EnumMember(Value = "WIDERRUFEN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("WIDERRUFEN")]
    WIDERRUFEN,

    /// <summary>
    ///     storniert
    /// </summary>
    [ProtoEnum(Name = nameof(Vertragstatus) + "_" + nameof(STORNIERT))]
    [EnumMember(Value = "STORNIERT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("STORNIERT")]
    STORNIERT,

    /// <summary>
    ///     gekündigt
    /// </summary>
    [ProtoEnum(Name = nameof(Vertragstatus) + "_" + nameof(GEKUENDIGT))]
    [EnumMember(Value = "GEKUENDIGT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GEKUENDIGT")]
    GEKUENDIGT,

    /// <summary>
    ///     beendet
    /// </summary>
    [ProtoEnum(Name = nameof(Vertragstatus) + "_" + nameof(BEENDET))]
    [EnumMember(Value = "BEENDET")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BEENDET")]
    BEENDET,
}
