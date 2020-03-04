namespace BO4E.ENUM
{
    /// <summary>
    /// Einheit: Messgrößen, die per Messung oder Vorgabe ermittelt werden können.
    /// </summary>
    public enum Mengeneinheit
    {
        /// <summary>Wattstunde</summary>
        WH = 2,
        /// <summary>Kilowatt</summary>
        KW = 3,
        /// <summary>Kilowattstunde</summary>
        KWH = 1000 * WH,
        /// <summary>Megawatt</summary>
        MW = 1000 * KW,
        /// <summary>Megawattstunde</summary>
        MWH = 1000 * KWH,
        /// <summary>Anzahl</summary>
        ANZAHL = 7,
        /// <summary>Kubikmeter (Gas)</summary>
        KUBIKMETER = 11,
        /// <summary>Stunde</summary>
        STUNDE = 13,
        /// <summary>Tage</summary>
        TAG = 17,
        /// <summary>Monat</summary>
        MONAT = 19,
        /// <summary>Jahr</summary>
        JAHR = 12 * MONAT,
        /// <summary>
        /// Var (Blindleistung)
        /// </summary>
        VAR = 23,
        /// <summary>
        /// kilovar <seealso cref="VAR"/>
        /// </summary>
        KVAR = 1000 * VAR,
        /// <summary>
        /// var stunde
        /// </summary>
        VARH = 29,
        /// <summary>
        /// kilovar stunde
        /// </summary>
        KVARH = 1000 * VARH
    }
}