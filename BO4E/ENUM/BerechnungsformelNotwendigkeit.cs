namespace BO4E.ENUM
{
    /// <summary>
    /// Beschreibt, ob eine Berechnungsformel notwendig ist
    /// </summary>
    /// <remarks>Enspricht dem UTILTS SG5+STS Datenelement 4405 "Status der Berechnungsformel"</remarks>
    public enum BerechnungsformelNotwendigkeit
    {
        /// <summary>
        /// Berechnungsformel angefügt
        /// </summary>
        /// <remarks>Z33</remarks>
        BERECHNUNGSFORMEL_NOTWENDIG,
        /// <summary>
        /// Berechnungsformel muss beim Absender angefragt werden
        /// </summary>
        /// <remarks>Z34</remarks>
        BERECHNUNGSFORMEL_MUSS_ANGEFRAGT_WERDEN,
        /// <summary>
        /// Berechnungsformel besitzt keine Rechenoperation
        /// </summary>
        /// <remarks>Z40</remarks>
        BERECHNUNGSFORMEL_TRIVIAL,
        /// <summary>
        /// Berechnungsformel ist nicht erforderlich
        /// </summary>
        BERECHNUNGSFORMEL_NICHT_NOTWENDIG,
    }
}
