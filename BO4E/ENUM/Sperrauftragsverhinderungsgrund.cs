using BO4E.BO;
using BO4E.meta;

using System.Runtime.Serialization;

namespace BO4E.ENUM;

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
    [EnumMember(Value = "RECHTLICHER_GRUND_FEHLT")]
    RECHTLICHER_GRUND_FEHLT,

    /// <summary>
    /// Es lag eine aktive Zutrittsverweigerung vor
    /// </summary>
    /// <remarks>EBD 0472 A02</remarks>
    [EnumMember(Value = "AKTIVE_ZUTRITTSVERWEIGERUNG")]
    AKTIVE_ZUTRITTSVERWEIGERUNG,

    /// <summary>
    /// Es lag eine passive Zutrittsverweigerung vor
    /// </summary>
    /// <remarks>EBD 0472 A03</remarks>
    [EnumMember(Value = "PASSIVE_ZUTRITTSVERWEIGERUNG")]
    PASSIVE_ZUTRITTSVERWEIGERUNG,

    /// <summary>
    /// Anderer Verhinderungsgrund (z.B. Betrieb lebensnotwendiger Geräte)
    /// Details werden im Freitext <see cref="Auftrag.Bemerkungen"/> vermerkt.
    /// </summary>
    /// <remarks>EBD 0472 A04</remarks>
    [EnumMember(Value = "ANDERER_VERHINDERUNGSGRUND")]
    ANDERER_VERHINDERUNGSGRUND,

    /// <summary>
    /// Ein tatsächlicher Verhinderungsgrund liegt vor, wenn z.B. die MaLo nicht identifizierbar, der Zugang nicht möglich war oder ein Kundenwechsel festgestellt wurde
    /// Details werden im Freitext <see cref="Auftrag.Bemerkungen"/> vermerkt.        
    /// </summary>
    /// <remarks>EBD 0472 A05</remarks>
    [EnumMember(Value = "TATSAECHLICHER_VERHINDERUNGSGRUND")]
    TATSAECHLICHER_VERHINDERUNGSGRUND,

    /// <summary>
    /// Ein technischer Grund (z.B. andere betroffene MaLo) hat das Sperren verhindert.
    /// Details werden im Freitext <see cref="Auftrag.Bemerkungen"/> vermerkt.
    /// </summary>
    /// <remarks>EBD 0472 A06</remarks>
    [EnumMember(Value = "TECHNISCHER_VERHINDERUNGSGRUND")]
    TECHNISCHER_VERHINDERUNGSGRUND,

    /// <summary>
    /// Der Anschlussnutzer wurde nicht angetroffen. Es gab keine Anzeichen dafür, dass dieser anwesend war.
    /// Details werden im Freitext <see cref="Auftrag.Bemerkungen"/> vermerkt.
    /// </summary>
    /// <remarks>EBD 0472 A08</remarks>
    [EnumMember(Value = "ANSCHLUSSNUTZER_WURDE_NICHT_ANGETROFFEN")]
    ANSCHLUSSNUTZER_WURDE_NICHT_ANGETROFFEN,
}