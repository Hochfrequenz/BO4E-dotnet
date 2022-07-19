using BO4E.BO;
using BO4E.meta;

namespace BO4E.ENUM
{
    /// <summary>
    /// Gründe aus denen ein <see cref="BO.Sperrauftrag"/> nicht durchgeführt wird/wurde.
    /// </summary>
    /// <remarks>Diese Information kann in der EDIFACT-Nachricht des Typs 21039 verwendet werden</remarks>
    [NonOfficial(NonOfficialCategory.REGULATORY_REQUIREMENTS)]
    public enum Sperrauftragsverhinderungsgrund
    {
        /// <summary>
        /// Eine Sperrung ist aus rechtlichen Gründen nicht möglich
        /// </summary>
        /// <remarks>EBD 0472 A01</remarks>
        RECHTLICHER_GRUND_FEHLT,

        /// <summary>
        /// Es lag eine aktive Zutrittsverweigerung vor
        /// </summary>
        /// <remarks>EBD 0472 A02</remarks>
        AKTIVE_ZUTRITTSVERWEIGERUNG,

        /// <summary>
        /// Es lag eine passive Zutrittsverweigerung vor
        /// </summary>
        /// <remarks>EBD 0472 A03</remarks>
        PASSIVE_ZUTRITTSVERWEIGERUNG,

        /// <summary>
        /// Anderer Verhinderungsgrund (z.B. Betrieb lebensnotwendiger Geräte)
        /// Details werden im Freitext <see cref="Auftrag.Bemerkungen"/> vermerkt.
        /// </summary>
        /// <remarks>EBD 0472 A04</remarks>
        ANDERER_VERHINDERUNGSGRUND,

        /// <summary>
        /// Ein tatsächlicher Verhinderungsgrund liegt vor, wenn z.B. die MaLo nicht identifizierbar, der Zugang nicht möglich war oder ein Kundenwechsel festgestellt wurde
        /// Details werden im Freitext <see cref="Auftrag.Bemerkungen"/> vermerkt.        
        /// </summary>
        /// <remarks>EBD 0472 A05</remarks>
        TATSAECHLICHER_VERHINDERUNGSGRUND,

        /// <summary>
        /// Ein technischer Grund (z.B. andere betroffene MaLo) hat das Sperren verhindert.
        /// Details werden im Freitext <see cref="Auftrag.Bemerkungen"/> vermerkt.
        /// </summary>
        /// <remarks>EBD 0472 A06</remarks>
        TECHNISCHER_VERHINDERUNGSGRUND,
    }
}