#nullable enable
using System.Runtime.Serialization;
using ProtoBuf;

namespace BO4E.ENUM;

/// <summary>Auflistung möglicher Einheiten zur Verwendung in zeitbezogenen Angaben.</summary>
public enum Zeiteinheit
{
    /// <summary>
    ///     Sekunde
    /// </summary>
    [ProtoEnum(Name = nameof(Zeiteinheit) + "_" + nameof(SEKUNDE))]
    [EnumMember(Value = "SEKUNDE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SEKUNDE")]
    SEKUNDE,

    /// <summary>
    ///     Minute
    /// </summary>
    [ProtoEnum(Name = nameof(Zeiteinheit) + "_" + nameof(MINUTE))]
    [EnumMember(Value = "MINUTE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MINUTE")]
    MINUTE,

    /// <summary>
    ///     Stunde
    /// </summary>
    [ProtoEnum(Name = nameof(Zeiteinheit) + "_" + nameof(STUNDE))]
    [EnumMember(Value = "STUNDE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("STUNDE")]
    STUNDE,

    /// <summary>
    ///     Viertelstunde
    /// </summary>
    [ProtoEnum(Name = nameof(Zeiteinheit) + "_" + nameof(VIERTEL_STUNDE))]
    [EnumMember(Value = "VIERTEL_STUNDE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("VIERTEL_STUNDE")]
    VIERTEL_STUNDE,

    /// <summary>
    ///     Tag
    /// </summary>
    [ProtoEnum(Name = nameof(Zeiteinheit) + "_" + nameof(TAG))]
    [EnumMember(Value = "TAG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("TAG")]
    TAG,

    /// <summary>
    ///     Woche
    /// </summary>
    [ProtoEnum(Name = nameof(Zeiteinheit) + "_" + nameof(WOCHE))]
    [EnumMember(Value = "WOCHE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("WOCHE")]
    WOCHE,

    /// <summary>
    ///     Monat
    /// </summary>
    [ProtoEnum(Name = nameof(Zeiteinheit) + "_" + nameof(MONAT))]
    [EnumMember(Value = "MONAT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MONAT")]
    MONAT,

    /// <summary>
    ///     Quartal
    /// </summary>
    [ProtoEnum(Name = nameof(Zeiteinheit) + "_" + nameof(QUARTAL))]
    [EnumMember(Value = "QUARTAL")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("QUARTAL")]
    QUARTAL,

    /// <summary>
    ///     Halbjahr
    /// </summary>
    [ProtoEnum(Name = nameof(Zeiteinheit) + "_" + nameof(HALBJAHR))]
    [EnumMember(Value = "HALBJAHR")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("HALBJAHR")]
    HALBJAHR,

    /// <summary>
    ///     Jahr
    /// </summary>
    [ProtoEnum(Name = nameof(Zeiteinheit) + "_" + nameof(JAHR))]
    [EnumMember(Value = "JAHR")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("JAHR")]
    JAHR,
}
