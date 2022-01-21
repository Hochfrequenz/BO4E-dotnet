using System;
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
        ZERO = 0,

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

        /// <summary>Wattstunde</summary>
        WH = 2,

        /// <summary>Kilowatt</summary>
        KW = 3,

        /// <summary>Kilowattstunde</summary>
        KWH = 1000 * WH,

        /// <summary>Megawatt</summary>
        MW = 1000 * KW,

        /// <summary>Megawattstunde</summary>
        MWH = 1000 * KWH,

        /// <summary>Anzahl</summary>
        ANZAHL = 7,

        /// <summary>Kubikmeter (Gas)</summary>
        KUBIKMETER = 11,

        /// <summary>Stunde</summary>
        STUNDE = 13,

        /// <summary>Tage</summary>
        TAG = 17,

        /// <summary>Monat</summary>
        MONAT = 19,

        /// <summary>Jahr</summary>
        JAHR = 12 * MONAT,

        /// <summary>
        ///     Var (Blindleistung)
        /// </summary>
        VAR = 23,

        /// <summary>
        ///     kilovar <seealso cref="VAR" />
        /// </summary>
        KVAR = 1000 * VAR,

        /// <summary>
        ///     var stunde
        /// </summary>
        VARH = 29,

        /// <summary>
        ///     kilovar stunde
        /// </summary>
        KVARH = 1000 * VARH,

        /// <summary>
        ///     kWh/K (Kilowatt-Stunde pro Kelvin)
        /// </summary>
        KWHK = 40,
    }
}