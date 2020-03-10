using BO4E.meta;

namespace BO4E.ENUM
{
    /// <summary>Übersicht möglicher Anreden, z.B. eines Geschäftspartners.</summary>
    public enum Anrede
    {
        /// <summary>Herr</summary>
        HERR,
        /// <summary>Frau</summary>
        FRAU,
        /// <summary>Eheleute</summary>
        EHELEUTE,
        /// <summary>Firma</summary>
        FIRMA,
        /// <summary>Individuell festgelegt</summary>
        INDIVIDUELL,
        /// <summary>
        /// Doktor
        /// </summary>
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        DR
    }
}