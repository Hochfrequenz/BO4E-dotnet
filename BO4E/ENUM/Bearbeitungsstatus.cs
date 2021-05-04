namespace BO4E.ENUM
{
    /// <summary>
    ///     Gibt den Bearbeitungsstatus, z.b. einer <see cref="BO4E.BO.Benachrichtigung" /> an.
    /// </summary>
    public enum Bearbeitungsstatus
    {
        /// <summary>
        ///     offen oder neu
        /// </summary>
        OFFEN,

        /// <summary>
        ///     in Bearbeitung
        /// </summary>
        IN_BEARBEITUNG,

        /// <summary>
        ///     abgeschlossen
        /// </summary>
        ABGESCHLOSSEN,

        /// <summary>
        ///     storniert
        /// </summary>
        STORNIERT,

        /// <summary>
        ///     quittiert
        /// </summary>
        QUITTIERT,

        /// <summary>
        ///     Benachrichtigung ist auf Wunsch des Users standardmäßig ausgeblendet.
        /// </summary>
        IGNORIERT
    }
}