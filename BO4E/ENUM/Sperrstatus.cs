using BO4E.meta;


namespace BO4E.ENUM
{
    /// <summary>
    /// Der Sperrstatus beschreibt, ob ein Zähler gesperrt ist oder nicht.
    /// </summary>
    [NonOfficial(NonOfficialCategory.REGULATORY_REQUIREMENTS)]
    enum Sperrstatus
    {
        /// <summary>
        /// Der Zähler ist nicht gesperrt
        /// </summary>
        ENTSPERRT,

        /// <summary>
        /// Der Zähler ist gesperrt
        /// </summary>
        GESPERRT
    }
}