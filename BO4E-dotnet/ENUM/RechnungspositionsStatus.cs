namespace BO4E.ENUM
{
    /// <summary>Status einer Rechnungsposition (konkret SAP Convergent Invoicing).</summary>
    public enum RechnungspositionsStatus
    {
        ROH = 0,
        ROH_AUSGENOMMEN = 1,
        ABRECHENBAR = 2,
        ABRECHENBAR_AUSGENOMMEN = 3,
        ABGERECHNET = 4
    }
}
