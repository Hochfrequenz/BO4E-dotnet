using System.Runtime.Serialization;

namespace BO4E.ENUM
{
    /// <summary>
    ///     Angabe, wie eine Menge in Bezug auf einen Wert zu bilden ist.
    /// </summary>
    public enum Mengenoperator
    {
        /// <summary>
        ///     Alle Objekte mit einem Wert kleiner als der Bezugswert
        /// </summary>
        [EnumMember(Value = "KLEINER_ALS")]
        KLEINER_ALS,

        /// <summary>
        ///     Alle Objekte mit einem Wert größer als der Bezugswert
        /// </summary>
        [EnumMember(Value = "GROESSER_ALS")]
        GROESSER_ALS,

        /// <summary>
        ///     Alle Objekte mit gleichem Wert
        /// </summary>
        [EnumMember(Value = "GLEICH")]
        GLEICH,
    }
}