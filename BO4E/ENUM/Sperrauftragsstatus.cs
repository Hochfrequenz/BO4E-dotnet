namespace BO4E.ENUM
{
    /// <summary>
    /// Der Sperrauftragsstatus beschreibt den Status eines <see cref="BO.Auftrag"/>s
    /// </summary>
    /// <remarks>Diese Information kann in der EDIFACT-Nachricht des Typs 21039 verwendet werden</remarks>
    public enum Sperrauftragsstatus
    {
        /// <summary>
        /// Der Auftrag wurde erfolgreich bearbeitet
        /// </summary>
        /// <remarks>EDIFACT DE4405: Z14</remarks>
        ERFOLGREICH,

        /// <summary>
        /// Der Auftrag wurde abgelehnt
        /// </summary>
        /// <remarks>EDIFACT DE4405: Z32</remarks>
        ABGELEHNT,

        /// <summary>
        /// Der Auftrag ist gescheitert
        /// </summary>
        /// <remarks>EDIFACT DE4405: Z13</remarks>
        GESCHEITERT
    }
}