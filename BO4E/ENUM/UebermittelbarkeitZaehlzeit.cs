namespace BO4E.ENUM
{
    /// <summary>Übermittelbarkeit der ausgerollten Zählzeit</summary>
    public enum UebermittelbarkeitZaehlzeit
    {
        /// <summary>Der LF bzw. NB übermittelt die ausgerollte Zählzeit per EDIFACT mit dem Nachrichtenformat UTILTS.</summary>
        ELEKTRONISCH,

        /// <summary>Der NB übermittelt die ausgerollte Zählzeit auf einem bilateral vereinbarten Weg. Dieser Weg wird hier nicht weiter beschrieben</summary>
        NICHT_ELEKTRONISCH
    }
}