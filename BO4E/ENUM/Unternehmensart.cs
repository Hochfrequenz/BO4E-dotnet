namespace BO4E.ENUM;

/// <summary>
/// kategorisiert Unternehmen nach Ihrer Marktrolle (basierend auf dem PARTIN-Datenmodell)
/// </summary>
public enum Unternehmensart
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    LIEFERANT,
    NETZBETREIBER,
    MESSSTELLENBETREIBER,
    ÜBERTRAGUNGSNETZBETREIBER,
    BILANZKOORDINATOR,
    BILANZKREISVERANTWORTLICHER,
    ENERGIESERVICEANBIETER,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
