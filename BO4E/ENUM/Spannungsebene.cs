namespace BO4E.ENUM
{
    /// <summary>
    /// Auflistung möglicher Spannungsebenen, die leider bei Edifact immer wieder unterschiedliche Kürzel haben und man daher
    /// zum Beispiel für die PRICAT das enum "Netzebene" nicht benutzen kann, alternativ können wir auch das enum Netzebene 
    /// noch erweitern?
    /// </summary>
    public enum Spannungsebene
    {
        /// <summary>Z11 Niederspannung</summary>
        NIEDERSPANNUNG,

        /// <summary>Z10 Mittelspannung</summary>
        MITTELSPANNUNG,

        /// <summary>Z09 Hochspannung</summary>
        HOCHSPANNUNG,

        /// <summary>Z08 Hoechstspannung</summary>
        HOECHSTSPANNUNG,
    }
}