using BO4E.meta;

namespace BO4E.ENUM
{
    /// <summary>Codes der SummenzeitreihentypenDie nachfolgenden Codes sind in DE7111 zu nutzen:</summary>
    // https://www.edi-energy.de/index.php?id=38&tx_bdew_bdew%5Buid%5D=695&tx_bdew_bdew%5Baction%5D=download&tx_bdew_bdew%5Bcontroller%5D=Dokument&cHash=67782e05d8b0f75fbe3a0e1801d07ed0
    [NonOfficial(NonOfficialCategory.REGULATORY_REQUIREMENTS)]
    public enum Zeitreihentyp
    {
        /// <summary>Einspeisegangsumme</summary>
        EGS,

        /// <summary>Lastgangsumme</summary>
        LGS,

        /// <summary>Netzzeitreihe</summary>
        NZR,

        /// <summary>Standardeinspeiseprofilsumme</summary>
        SES,

        /// <summary>Standardlastsumme</summary>
        SLS,

        /// <summary>Tagesparameterabhängige Einspeiseprofilsumme</summary>
        TES,

        /// <summary>Tagesparameterabhängige Lastprofilsumme</summary>
        TLS,
        /// <summary>
        /// gemeinsame Messung aus SLS und TLS
        /// </summary>
        SLS_TLS,
        /// <summary>
        /// Gemeinsame Messung aus SES und TES
        /// </summary>
        SES_TES,
    }
}