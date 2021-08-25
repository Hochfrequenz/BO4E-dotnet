using ProtoBuf;

namespace BO4E.ENUM
{
    /// <summary>Aulistung der verschiedenen Berechnungsmethoden für ein Preisblatt.</summary>
    public enum Tarifkalkulationsmethode
    {
        /// <summary>
        ///     Staffelmodell, d.h. die Gesamtmenge wird in eine Staffel eingeordnet und für die gesamte Menge gilt der so
        ///     ermittelte Preis
        /// </summary>
        [ProtoEnum(Name = nameof(Tarifkalkulationsmethode) + "_" + nameof(STAFFELN))]
        STAFFELN,

        /// <summary>
        ///     Zonenmodell, d.h. die Gesamtmenge wird auf die Zonen aufgeteilt und für die Teilmengen gilt der jeweilige
        ///     Preis der Zone.
        /// </summary>
        [ProtoEnum(Name = nameof(Tarifkalkulationsmethode) + "_" + nameof(ZONEN))]
        ZONEN,

        /// <summary>Bestabrechnung innerhalb der Staffelung</summary>
        [ProtoEnum(Name = nameof(Tarifkalkulationsmethode) + "_" + nameof(BESTABRECHNUNG_STAFFEL))]
        BESTABRECHNUNG_STAFFEL,

        /// <summary>Preis für ein Paket (eine Menge).</summary>
        [ProtoEnum(Name = nameof(Tarifkalkulationsmethode) + "_" + nameof(PAKETPREIS))]
        PAKETPREIS
    }
}