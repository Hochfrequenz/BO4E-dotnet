namespace BO4E.ENUM
{
    /// <summary>
    /// Wahlrecht der Prognosegrundlage der Marktlokation
    /// </summary>
    public enum WahlrechtPrognosegrundlage
    {
        /// <summary>
        /// Wahlrecht durch LF gegeben
        /// </summary>
        DURCH_LF,

        /// <summary>
        /// Wahlrecht nicht vorhanden wegen Verbrauch > 10.000 kWh/a
        /// </summary>
        NICHT_WEGEN_GROSSEN_VERBRAUCHS,

        /// <summary>
        /// Wahlrecht nicht vorhanden wegen Eigenverbrauch
        /// </summary>
        NICHT_WEGEN_EIGENVERBRAUCH,

        /// <summary>
        /// Wahlrecht nicht vorhanden wegen tagesparameterabhängigem Verbrauch
        /// </summary>
        NICHT_WEGEN_TAGES_VERBRAUCH,

        /// <summary>
        /// Wahlrecht nicht vorhanden wegen §14a EnWG
        /// </summary>
        NICHT_WEGEN_ENWG
    }
}