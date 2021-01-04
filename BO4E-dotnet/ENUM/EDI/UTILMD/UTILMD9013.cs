namespace BO4E.ENUM.EDI.UTILMD
{
    /// <summary>
    /// Es erfolgt die Angabe, ob ein entsprechender Vertrag zwischen dem Anschlussnutzer und MSB vorliegt.
    /// Zusätzlich kann auch noch angegeben werden, ob auch die Vertragsbeendigung mit dem vorigen Vertragspartner vor der
    /// Anmeldung beendet wurde und vorliegt.
    /// </summary>
    public enum UTILMD7433
    {
        /// <summary>
        /// Vertrag zwischen AN MSB
        /// </summary>
        Z04,
        /// <summary>
        /// Vertragsbeendigung liegt vor
        /// </summary>
        Z06
    }
}
