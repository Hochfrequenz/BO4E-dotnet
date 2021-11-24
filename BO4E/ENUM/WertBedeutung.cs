using BO4E.meta;

namespace BO4E.ENUM
{
    /// <summary>
    /// Represents the Type of Wert (SG10 STS 9015)
    /// </summary>
    [NonOfficial(NonOfficialCategory.UNSPECIFIED)]
    public enum WertBedeutung
    {
        /// <summary> 6 </summary>
        VERTRAG,

        /// <summary> 8 </summary>
        MESSWERTQUALITAET,

        /// <summary> 10 </summary>
        MESSKLASSIFIZIERUNG,

        /// <summary> Z33 </summary>
        PLAUSIBILISIERUNGSHINWEIS,

        /// <summary> Z32 </summary>
        ERSATZWERTBILDUNGSVERFAHREN,

        /// <summary>Z34 </summary>
        KORREKTURGRUND,

        /// <summary> Z31 </summary>
        GASQUALITAET,
    }
}