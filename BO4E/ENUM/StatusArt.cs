using BO4E.COM;
using BO4E.meta;

using System.Runtime.Serialization;

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
        [EnumMember(Value = "VERTRAG")]
        VERTRAG,

        /// <summary> MESSWERTQUALITAET </summary>
        /// <remarks>8</remarks>
        [EnumMember(Value = "MESSWERTQUALITAET")]
        MESSWERTQUALITAET,

        /// <summary> MESSKLASSIFIZIERUNG </summary>
        /// <remarks>10</remarks>
        [EnumMember(Value = "MESSKLASSIFIZIERUNG")]
        MESSKLASSIFIZIERUNG,

        /// <summary> PLAUSIBILISIERUNGSHINWEIS </summary>
        /// <remarks>Z33</remarks>
        [EnumMember(Value = "PLAUSIBILISIERUNGSHINWEIS")]
        PLAUSIBILISIERUNGSHINWEIS,

        /// <summary> ERSATZWERTBILDUNGSVERFAHREN </summary>
        /// <remarks>Z32</remarks>
        [EnumMember(Value = "ERSATZWERTBILDUNGSVERFAHREN")]
        ERSATZWERTBILDUNGSVERFAHREN,

        /// <summary> GRUND_ERSATZWERTBILDUNGSVERFAHREN </summary>
        /// <remarks>Z40</remarks>
        [EnumMember(Value = "GRUND_ERSATZWERTBILDUNGSVERFAHREN")]
        GRUND_ERSATZWERTBILDUNGSVERFAHREN,

        /// <summary> KORREKTURGRUND </summary>
        /// <remarks>Z34</remarks>
        [EnumMember(Value = "KORREKTURGRUND")]
        KORREKTURGRUND,

        /// <summary> GASQUALITAET </summary>
        /// <remarks>Z31</remarks>
        [EnumMember(Value = "GASQUALITAET")]
        GASQUALITAET,
    }
}