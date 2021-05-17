using ProtoBuf;

namespace BO4E.ENUM
{
    /// <summary>Gibt den Status eines Angebotes an.</summary>
    public enum Angebotsstatus
    {
        /// <summary>
        ///     Konzeption
        /// </summary>
        KONZEPTION,

        /// <summary>
        ///     unverbindlich
        /// </summary>
        UNVERBINDLICH,

        /// <summary>
        ///     verbindlich
        /// </summary>
        VERBINDLICH,

        /// <summary>
        ///     beauftragt
        /// </summary>
        BEAUFTRAGT,

        /// <summary>
        ///     ungültig
        /// </summary>
        UNGUELTIG,

        /// <summary>
        ///     abgelehnt
        /// </summary>
        [ProtoEnum(Name = nameof(Angebotsstatus) + "_" + nameof(ABGELEHNT))]
        ABGELEHNT,

        /// <summary>
        ///     nachgefasst
        /// </summary>
        NACHGEFASST,

        /// <summary>
        ///     ausstehend
        /// </summary>
        AUSSTEHEND,

        /// <summary>
        ///     erledigt
        /// </summary>
        ERLEDIGT
    }
}