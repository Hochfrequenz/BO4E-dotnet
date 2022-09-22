namespace BO4E.ENUM
{
    /// <summary>
    /// Wahlrecht der Prognosegrundlage der Marktlokation
    /// </summary>
    /// <remarks> SG10 CAV </remarks>
    public enum WahlrechtPrognosegrundlage
    {
        /// <summary>
        /// Wahlrecht durch LF gegeben
        /// </summary>
        /// <remarks> CAV+Z54 </remarks>
        DURCH_LF,
        /// <summary>
        /// Wahlrecht durch LF gegeben
        /// </summary>
        /// <remarks> CAV+ZE2 </remarks>
        DURCH_LF_NICHT_GEGEBEN,

        /// <summary>
        /// Wahlrecht nicht vorhanden wegen Verbrauch > 10.000 kWh/a
        /// </summary>
        /// <remarks> CAV+Z55 </remarks>
        NICHT_WEGEN_GROSSEN_VERBRAUCHS,

        /// <summary>
        /// Wahlrecht nicht vorhanden wegen Eigenverbrauch
        /// </summary>
        /// <remarks> CAV+ZC1 </remarks>
        NICHT_WEGEN_EIGENVERBRAUCH,

        /// <summary>
        /// Wahlrecht nicht vorhanden wegen tagesparameterabhängigem Verbrauch
        /// </summary>
        /// <remarks> CAV+ZD2 </remarks>
        NICHT_WEGEN_TAGES_VERBRAUCH,

        /// <summary>
        /// Wahlrecht nicht vorhanden wegen §14a EnWG
        /// </summary>
        /// <remarks> CAV+ZE3 </remarks>
        NICHT_WEGEN_ENWG
    }
}