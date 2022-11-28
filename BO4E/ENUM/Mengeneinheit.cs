using System;
using System.Runtime.Serialization;

using ProtoBuf;

namespace BO4E.ENUM
{
    /// <summary>
    ///     Einheit: Messgrößen, die per Messung oder Vorgabe ermittelt werden können.
    /// </summary>
    public enum Mengeneinheit
    {
        [Obsolete("This value is only a workaround for the proto3 syntax generation. You shouldn't actually use it")]
#pragma warning disable CS0618 // Type or member is obsolete
        [ProtoEnum(Name = nameof(Mengeneinheit) + "_" + nameof(ZERO))]
#pragma warning restore CS0618 // Type or member is obsolete
        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        [EnumMember(Value = "ZERO")]
        ZERO = 0,

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

        /// <summary>Wattstunde</summary>
        [EnumMember(Value = "WH")]
        WH = 2,

        /// <summary>Kilowatt</summary>
        [EnumMember(Value = "KW")]
        KW = 3,

        /// <summary>Kilowattstunde</summary>
        [EnumMember(Value = "KWH")]
        KWH = 1000 * WH,

        /// <summary>Megawatt</summary>
        [EnumMember(Value = "MW")]
        MW = 1000 * KW,

        /// <summary>Megawattstunde</summary>
        [EnumMember(Value = "MWH")]
        MWH = 1000 * KWH,

        /// <summary>Anzahl</summary>
        [EnumMember(Value = "ANZAHL")]
        ANZAHL = 7,

        /// <summary>Kubikmeter</summary>
        [EnumMember(Value = "KUBIKMETER")]
        KUBIKMETER = 11,

        /// <summary>Stunde</summary>
        [EnumMember(Value = "STUNDE")]
        STUNDE = 13,

        /// <summary>Tage</summary>
        [EnumMember(Value = "TAG")]
        TAG = 17,

        /// <summary>Monat</summary>
        [EnumMember(Value = "MONAT")]
        MONAT = 19,

        /// <summary>Jahr</summary>
        [EnumMember(Value = "JAHR")]
        JAHR = 12 * MONAT,

        /// <summary>
        ///     Var (Blindleistung)
        /// </summary>
        [EnumMember(Value = "VAR")]
        VAR = 23,

        /// <summary>
        ///     kilovar <seealso cref="VAR" />
        /// </summary>
        [EnumMember(Value = "KVAR")]
        KVAR = 1000 * VAR,

        /// <summary>
        ///     var stunde
        /// </summary>
        [EnumMember(Value = "VARH")]
        VARH = 29,

        /// <summary>
        ///     kilovar stunde
        /// </summary>
        [EnumMember(Value = "KVARH")]
        KVARH = 1000 * VARH,

        /// <summary>
        ///     kWh/K (Kilowatt-Stunde pro Kelvin)
        /// </summary>
        [EnumMember(Value = "KWHK")]
        KWHK = 40,
    }
}