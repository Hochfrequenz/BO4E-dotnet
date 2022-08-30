namespace BO4E.ENUM
{
    /// <summary>
    /// Beschreibt, ob eine Zählzeitdefinition notwendig ist
    /// </summary>
    /// <remarks>Enspricht dem UTILTS SG5+STS Datenelement 4405 "Status der Nutzung von Zählzeitdefinitione"</remarks>
    public enum ZaehlzeitdefinitionNotwendigkeit
    {
        /// <summary>
        /// Berechnungsformel angefügt
        /// </summary>
        /// <remarks>Z02</remarks>
        ZAEHLZEITDEFINITIONEN_WERDEN_VERWENDET,
        /// <summary>
        /// Berechnungsformel muss beim Absender angefragt werden
        /// </summary>
        /// <remarks>Z03</remarks>
        ZAEHLZEITDEFINITIONEN_WERDEN_NICHT_VERWENDET,
    }
}
