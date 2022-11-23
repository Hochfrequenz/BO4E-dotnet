using BO4E.meta;

using System.Runtime.Serialization;

namespace BO4E.ENUM
{
    /// <summary>
    /// Die Sperrauftragsart beschreibt die Art eines <see cref="BO.Sperrauftrag"/>s.
    /// </summary>
    [NonOfficial(NonOfficialCategory.REGULATORY_REQUIREMENTS)]
    public enum Sperrauftragsart
    {
        /// <summary>
        /// Ein Zähler soll gesperrt werden
        /// </summary>
        /// <remarks>EDIFACT Z51 in Nachricht 17115/17116</remarks>
        [EnumMember(Value = "SPERREN")] 
        SPERREN,

        /// <summary>
        /// Ein Zähler soll entsperrt werden
        /// </summary>
        /// <remarks>EDIFACT Z52 in Nachricht 17117</remarks>
        [EnumMember(Value = "ENTSPERREN")] 
        ENTSPERREN,
    }
}