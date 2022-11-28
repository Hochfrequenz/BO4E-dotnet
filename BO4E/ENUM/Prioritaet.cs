using System.Runtime.Serialization;

namespace BO4E.ENUM
{
    /// <summary>
    ///     Gibt die Priorität, z.b. einer <see cref="BO.Benachrichtigung" /> an.
    /// </summary>
    public enum Prioritaet
    {
        /// <summary>
        ///     sehr niedrig Priorität
        /// </summary>
        [EnumMember(Value = "SEHR_NIEDRIG")]
        SEHR_NIEDRIG,

        /// <summary>
        ///     niedrige Priorität
        /// </summary>
        [EnumMember(Value = "NIEDRIG")]
        NIEDRIG,

        /// <summary>
        ///     normale Priorität
        /// </summary>
        [EnumMember(Value = "NORMAL")]
        NORMAL,

        /// <summary>
        ///     hohe Priorität
        /// </summary>
        [EnumMember(Value = "HOCH")]
        HOCH,

        /// <summary>
        ///     sehr hohe Priorität
        /// </summary>
        [EnumMember(Value = "SEHR_HOCH")]
        SEHR_HOCH,
    }
}