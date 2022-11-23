using System.Runtime.Serialization;

namespace BO4E.ENUM
{
    /// <summary>
    ///     Zur Differenzierung von Grund/Ersatzversorgungstarifen und sonstigen
    ///     angebotenen Tarifen.
    /// </summary>
    public enum Tariftyp
    {
        /// <summary>Grund- und Ersatzversorgung</summary>
        [EnumMember(Value = "GRUND_ERSATZVERSORGUNG")]
        GRUND_ERSATZVERSORGUNG,

        /// <summary>Grundversorgung</summary>
        [EnumMember(Value = "GRUNDVERSORGUNG")]
        GRUNDVERSORGUNG,

        /// <summary>Ersatzversorgung</summary>
        [EnumMember(Value = "ERSATZVERSORGUNG")]
        ERSATZVERSORGUNG,

        /// <summary>Sondertarif</summary>
        [EnumMember(Value = "SONDERTARIF")]
        SONDERTARIF,
    }
}