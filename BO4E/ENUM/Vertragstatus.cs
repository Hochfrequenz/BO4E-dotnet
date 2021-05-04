using ProtoBuf;

namespace BO4E.ENUM
{
    /// <summary>
    /// Abbildung einer Statusinformation für Verträge.
    /// </summary>
    public enum Vertragstatus
    {
        /// <summary>
        /// in Arbeit
        /// </summary>
        [ProtoEnum(Name = nameof(Vertragstatus) + "_" + nameof(IN_ARBEIT))]
        IN_ARBEIT,
        /// <summary>
        /// übermittelt
        /// </summary>
        [ProtoEnum(Name = nameof(Vertragstatus) + "_" + nameof(UEBERMITTELT))]
        UEBERMITTELT,
        /// <summary>
        /// angenommen
        /// </summary>
        [ProtoEnum(Name = nameof(Vertragstatus) + "_" + nameof(ANGENOMMEN))]
        ANGENOMMEN,
        /// <summary>
        /// aktiv
        /// </summary>
        [ProtoEnum(Name = nameof(Vertragstatus) + "_" + nameof(AKTIV))]
        AKTIV,
        /// <summary>
        /// abgelehnt
        /// </summary>
        [ProtoEnum(Name = nameof(Vertragstatus) + "_" + nameof(ABGELEHNT))]
        ABGELEHNT,
        /// <summary>
        /// widerrufen
        /// </summary>
        [ProtoEnum(Name = nameof(Vertragstatus) + "_" + nameof(WIDERRUFEN))]
        WIDERRUFEN,
        /// <summary>
        /// storniert
        /// </summary>
        [ProtoEnum(Name = nameof(Vertragstatus) + "_" + nameof(STORNIERT))]
        STORNIERT,
        /// <summary>
        /// gekündigt
        /// </summary>
        [ProtoEnum(Name = nameof(Vertragstatus) + "_" + nameof(GEKUENDIGT))]
        GEKUENDIGT,
        /// <summary>
        /// beendet
        /// </summary>
        [ProtoEnum(Name = nameof(Vertragstatus) + "_" + nameof(BEENDET))]
        BEENDET
    }
}
