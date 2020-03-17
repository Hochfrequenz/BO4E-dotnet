namespace BO4E.ENUM
{

    /// <summary>Codes der SummenzeitreihentypenDie nachfolgenden Codes sind in DE7111 zu nutzen:</summary>
    /// <see cref="https://www.edi-energy.de/index.php?id=38&tx_bdew_bdew%5Buid%5D=695&tx_bdew_bdew%5Baction%5D=download&tx_bdew_bdew%5Bcontroller%5D=Dokument&cHash=67782e05d8b0f75fbe3a0e1801d07ed0"/>
    public enum Zeitreihentyp
    {
        /// <summary>Bilanzkreissummenzeit-reihe, Lieferantensummenzeit-reihe, Bilanzierungsgebietssummenzeitreihe</summary>
        EGS,
        /// <summary>Bilanzkreissummenzeit-reihe, Lieferantensummenzeit-reihe, Bilanzierungsgebietssummenzeitreihe</summary>
        LGS,
        /// <summary>Netzzeitreihe</summary>
        NZR,
        /// <summary>Bilanzkreissummenzeit-reihe, Lieferantensummenzeit-reihe</summary>
        SES,
        /// <summary>Bilanzkreissummenzeit-reihe, Lieferantensummenzeit-reihe, Bilanzierungsgebietssummenzeitreihe</summary>
        SLS,
        /// <summary>Bilanzkreissummenzeit-reihe, Lieferantensummenzeit-reihe</summary>
        TES,
        /// <summary>Bilanzkreissummenzeit-reihe, Lieferantensummenzeit-reihe</summary>
        TLS,
    }
}