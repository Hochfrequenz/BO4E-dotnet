namespace BO4E.ENUM
{

    /// <summary>Mit dieser Aufzählung kann zwischen den Bilanzierungsmethoden bzw. -Grundlagen unterschieden werden.</summary>
    public enum Bilanzierungsmethode
    {
        /// <summary>Registrierende Leistungsmessung</summary>
        RLM,
        /// <summary>Standard Lastprofil</summary>
        SLP,
        /// <summary>TLP gemeinsame Messung</summary>
        TLP_GEMEINSAM,
        /// <summary>TLP getrennte Messung</summary>
        TLP_GETRENNT,
        /// <summary>Pauschale Betrachtung (Band)</summary>
        PAUSCHAL,
        /// <summary>
        /// intelligentes Messsystem / Smart Meter
        /// </summary>
        IMS
    }
}
