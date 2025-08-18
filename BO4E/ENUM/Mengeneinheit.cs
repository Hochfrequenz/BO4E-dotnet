using System;
using System.Runtime.Serialization;
using ProtoBuf;

namespace BO4E.ENUM;

/// <summary>
///     Einheit: Messgrößen, die per Messung oder Vorgabe ermittelt werden können.
/// </summary>
public enum Mengeneinheit
{
    [Obsolete(
        "This value is only a workaround for the proto3 syntax generation. You shouldn't actually use it"
    )]
#pragma warning disable CS0618 // Type or member is obsolete
    [ProtoEnum(Name = nameof(Mengeneinheit) + "_" + nameof(ZERO))]
#pragma warning restore CS0618 // Type or member is obsolete
    [Newtonsoft.Json.JsonIgnore]
    [System.Text.Json.Serialization.JsonIgnore]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    [EnumMember(Value = "ZERO")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ZERO")]
    ZERO = 0,

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

    /// <summary>Wattstunde</summary>
    [EnumMember(Value = "WH")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("WH")]
    WH = 2,

    /// <summary>Kilowatt</summary>
    [EnumMember(Value = "KW")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("KW")]
    KW = 3,

    /// <summary>Kilowattstunde</summary>
    [EnumMember(Value = "KWH")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("KWH")]
    KWH = 1000 * WH,

    /// <summary>Megawatt</summary>
    [EnumMember(Value = "MW")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MW")]
    MW = 1000 * KW,

    /// <summary>Megawattstunde</summary>
    [EnumMember(Value = "MWH")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MWH")]
    MWH = 1000 * KWH,

    /// <summary>Anzahl</summary>
    [EnumMember(Value = "ANZAHL")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ANZAHL")]
    ANZAHL = 7,

    /// <summary>Kubikmeter</summary>
    [EnumMember(Value = "KUBIKMETER")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("KUBIKMETER")]
    KUBIKMETER = 11,

    /// <summary>Stunde</summary>
    [EnumMember(Value = "STUNDE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("STUNDE")]
    STUNDE = 13,

    /// <summary>Tage</summary>
    [EnumMember(Value = "TAG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("TAG")]
    TAG = 17,

    /// <summary>Monat</summary>
    [EnumMember(Value = "MONAT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MONAT")]
    MONAT = 19,

    /// <summary>Jahr</summary>
    [EnumMember(Value = "JAHR")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("JAHR")]
    JAHR = 12 * MONAT,

    /// <summary>
    ///     Var (Blindleistung)
    /// </summary>
    [EnumMember(Value = "VAR")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("VAR")]
    VAR = 23,

    /// <summary>
    ///     kilovar <seealso cref="VAR" />
    /// </summary>
    [EnumMember(Value = "KVAR")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("KVAR")]
    KVAR = 1000 * VAR,

    /// <summary>
    ///     var stunde
    /// </summary>
    [EnumMember(Value = "VARH")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("VARH")]
    VARH = 29,

    /// <summary>
    ///     kilovar stunde
    /// </summary>
    [EnumMember(Value = "KVARH")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("KVARH")]
    KVARH = 1000 * VARH,

    /// <summary>
    ///     kWh/K (Kilowatt-Stunde pro Kelvin)
    /// </summary>
    [EnumMember(Value = "KWHK")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("KWHK")]
    KWHK = 40,

    /// <summary>
    ///     W/m**2 (Watt pro Quadratmeter)
    /// </summary>
    [EnumMember(Value = "W_M2")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("W_M2")]
    W_M2 = 50,

    /// <summary>
    ///     m/s (Meter pro Sekunde)
    /// </summary>
    [EnumMember(Value = "M_S")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("M_S")]
    M_S = 60,
}
