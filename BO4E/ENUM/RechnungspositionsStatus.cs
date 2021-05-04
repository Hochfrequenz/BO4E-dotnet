namespace BO4E.ENUM
{
    /// <summary>Status einer Rechnungsposition (konkret SAP Convergent Invoicing).</summary>
    public enum RechnungspositionsStatus
    {
        // https://help.sap.com/doc/cef4c5536a51204be10000000a174cb4/3.6/de-DE/bf1cd054fa9a9121e10000000a44176d.html
        // https://imgflip.com/i/4e3u6m
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        ROH = 0,

        ROH_AUSGENOMMEN = 1,
        ABRECHENBAR = 2,
        ABRECHENBAR_AUSGENOMMEN = 3,
        ABGERECHNET = 4
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    }
}