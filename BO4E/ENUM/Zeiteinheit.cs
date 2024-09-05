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
    SEKUNDE,

    /// <summary>
    ///     Minute
    /// </summary>
    [ProtoEnum(Name = nameof(Zeiteinheit) + "_" + nameof(MINUTE))]
    [EnumMember(Value = "MINUTE")]
    MINUTE,

    /// <summary>
    ///     Stunde
    /// </summary>
    [ProtoEnum(Name = nameof(Zeiteinheit) + "_" + nameof(STUNDE))]
    [EnumMember(Value = "STUNDE")]
    STUNDE,

    /// <summary>
    ///     Viertelstunde
    /// </summary>
    [ProtoEnum(Name = nameof(Zeiteinheit) + "_" + nameof(VIERTEL_STUNDE))]
    [EnumMember(Value = "VIERTEL_STUNDE")]
    VIERTEL_STUNDE,

    /// <summary>
    ///     Tag
    /// </summary>
    [ProtoEnum(Name = nameof(Zeiteinheit) + "_" + nameof(TAG))]
    [EnumMember(Value = "TAG")]
    TAG,

    /// <summary>
    ///     Woche
    /// </summary>
    [ProtoEnum(Name = nameof(Zeiteinheit) + "_" + nameof(WOCHE))]
    [EnumMember(Value = "WOCHE")]
    WOCHE,

    /// <summary>
    ///     Monat
    /// </summary>
    [ProtoEnum(Name = nameof(Zeiteinheit) + "_" + nameof(MONAT))]
    [EnumMember(Value = "MONAT")]
    MONAT,

    /// <summary>
    ///     Quartal
    /// </summary>
    [ProtoEnum(Name = nameof(Zeiteinheit) + "_" + nameof(QUARTAL))]
    [EnumMember(Value = "QUARTAL")]
    QUARTAL,

    /// <summary>
    ///     Halbjahr
    /// </summary>
    [ProtoEnum(Name = nameof(Zeiteinheit) + "_" + nameof(HALBJAHR))]
    [EnumMember(Value = "HALBJAHR")]
    HALBJAHR,

    /// <summary>
    ///     Jahr
    /// </summary>
    [ProtoEnum(Name = nameof(Zeiteinheit) + "_" + nameof(JAHR))]
    [EnumMember(Value = "JAHR")]
    JAHR,
}
