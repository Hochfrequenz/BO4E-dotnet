using ProtoBuf;

namespace BO4E.ENUM
{
    /// <summary>Auflistung möglicher Einheiten zur Verwendung in zeitbezogenen Angaben.</summary>
    public enum Zeiteinheit
    {
        /// <summary>
        ///     Sekunde
        /// </summary>
        [ProtoEnum(Name = nameof(Zeiteinheit) + "_" + nameof(SEKUNDE))]
        SEKUNDE,

        /// <summary>
        ///     Minute
        /// </summary>
        [ProtoEnum(Name = nameof(Zeiteinheit) + "_" + nameof(MINUTE))]
        MINUTE,

        /// <summary>
        ///     Stunde
        /// </summary>
        [ProtoEnum(Name = nameof(Zeiteinheit) + "_" + nameof(STUNDE))]
        STUNDE,

        /// <summary>
        ///     Viertelstunde
        /// </summary>
        [ProtoEnum(Name = nameof(Zeiteinheit) + "_" + nameof(VIERTEL_STUNDE))]
        VIERTEL_STUNDE,

        /// <summary>
        ///     Tag
        /// </summary>
        [ProtoEnum(Name = nameof(Zeiteinheit) + "_" + nameof(TAG))]
        TAG,

        /// <summary>
        ///     Woche
        /// </summary>
        [ProtoEnum(Name = nameof(Zeiteinheit) + "_" + nameof(WOCHE))]
        WOCHE,

        /// <summary>
        ///     Monat
        /// </summary>
        [ProtoEnum(Name = nameof(Zeiteinheit) + "_" + nameof(MONAT))]
        MONAT,

        /// <summary>
        ///     Quartal
        /// </summary>
        [ProtoEnum(Name = nameof(Zeiteinheit) + "_" + nameof(QUARTAL))]
        QUARTAL,

        /// <summary>
        ///     Halbjahr
        /// </summary>
        [ProtoEnum(Name = nameof(Zeiteinheit) + "_" + nameof(HALBJAHR))]
        HALBJAHR,

        /// <summary>
        ///     Jahr
        /// </summary>
        [ProtoEnum(Name = nameof(Zeiteinheit) + "_" + nameof(JAHR))]
        JAHR
    }
}