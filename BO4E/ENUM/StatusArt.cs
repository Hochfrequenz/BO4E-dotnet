using BO4E.COM;
using BO4E.meta;

namespace BO4E.ENUM
{
    /// <summary>
    /// Represents the Type of Wert (MSCONS SG10 STS 9015)
    /// </summary>
    /// <see cref="StatusZusatzInformation"/>
    [NonOfficial(NonOfficialCategory.UNSPECIFIED)]
    public enum StatusArt
    {
        /// <summary> VERTRAG </summary>
        /// <remarks>6</remarks>
        VERTRAG,

        /// <summary> MESSWERTQUALITAET </summary>
        /// <remarks>8</remarks>
        MESSWERTQUALITAET,

        /// <summary> MESSKLASSIFIZIERUNG </summary>
        /// <remarks>10</remarks>
        MESSKLASSIFIZIERUNG,

        /// <summary> PLAUSIBILISIERUNGSHINWEIS </summary>
        /// <remarks>Z33</remarks>
        PLAUSIBILISIERUNGSHINWEIS,

        /// <summary> ERSATZWERTBILDUNGSVERFAHREN </summary>
        /// <remarks>Z32</remarks>
        ERSATZWERTBILDUNGSVERFAHREN,

        /// <summary> KORREKTURGRUND </summary>
        /// <remarks>Z34</remarks>
        KORREKTURGRUND,

        /// <summary> GASQUALITAET </summary>
        /// <remarks>Z31</remarks>
        GASQUALITAET,
    }
}