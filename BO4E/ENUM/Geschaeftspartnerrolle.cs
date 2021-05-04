using ProtoBuf;

namespace BO4E.ENUM
{
    /// <summary>Diese Rollen kann ein Geschäftspartner einnehmen.</summary>
    public enum Geschaeftspartnerrolle
    {
        /// <summary>Lieferant</summary>
        [ProtoEnum(Name = nameof(Geschaeftspartnerrolle) + "_" + nameof(LIEFERANT))]
        LIEFERANT,
        /// <summary>Dienstleister</summary>
        [ProtoEnum(Name = nameof(Geschaeftspartnerrolle) + "_" + nameof(DIENSTLEISTER))]
        DIENSTLEISTER,
        /// <summary>Kunde</summary>
        [ProtoEnum(Name = nameof(Geschaeftspartnerrolle) + "_" + nameof(KUNDE))]
        KUNDE,
        /// <summary>Interessent</summary>
        [ProtoEnum(Name = nameof(Geschaeftspartnerrolle) + "_" + nameof(INTERESSENT))]
        INTERESSENT,
        /// <summary>Marktpartner</summary>
        [ProtoEnum(Name = nameof(Geschaeftspartnerrolle) + "_" + nameof(MARKTPARTNER))]
        MARKTPARTNER
    }
}