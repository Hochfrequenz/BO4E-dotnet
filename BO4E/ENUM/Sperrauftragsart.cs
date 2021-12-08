using BO4E.meta;

namespace BO4E.ENUM
{
    /// <summary>
    /// Der Sperrauftragsstatus beschreibt die Art eines <see cref="BO.Sperrauftrag"/>s.
    /// </summary>
    [NonOfficial(NonOfficialCategory.REGULATORY_REQUIREMENTS)]
    public enum Sperrauftragsart
    {
        /// <summary>
        /// Ein Zähler soll gesperrt werden
        /// </summary>
        /// <remarks>EDIFACT Z51 in Nachricht 17115/17116</remarks>
        SPERREN,

        /// <summary>
        /// Ein Zähler soll entsperrt werden
        /// </summary>
        /// <remarks>EDIFACT Z52 in Nachricht 17117</remarks>
        ENTSPERREN
    }
}