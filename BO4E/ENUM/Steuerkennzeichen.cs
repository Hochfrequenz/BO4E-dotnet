using System.Runtime.Serialization;
using BO4E.COM;

namespace BO4E.ENUM
{
    /// <summary> </summary>
    public enum Steuerkennzeichen
    {
        /// <summary>Umsatzsteuer 19%</summary>
        [EnumMember(Value = "UST_19")]
        UST_19,
        /// <summary>Umsatzsteuer 16%</summary>
        [EnumMember(Value = "UST_16")]
        UST_16,

        /// <summary>Umsatzsteuer 7%</summary>
        [EnumMember(Value = "UST_7")]
        UST_7,

        /// <summary>
        /// Fälle, die mit den übrigen Steuersätzen <see cref="UST_19"/>, <see cref="UST_16"/>, <see cref="UST_7"/> nicht abbildbar sind. 
        /// </summary>
        /// <remarks>Der abweichende Steuersatz kann in <see cref="Steuerbetrag.Steuerwert"/> angegeben werden.</remarks>
        [EnumMember(Value = "UST_SONDER")]
        UST_SONDER,

        /// <summary>Keine Vorsteuer, bzw. nicht steuerbar.</summary>
        [EnumMember(Value = "VST_0")]
        VST_0,

        /// <summary>Vorsteuer 19%</summary>
        [EnumMember(Value = "VST_19")]
        VST_19,
        /// <summary>Vorsteuer 16%</summary>
        [EnumMember(Value = "VST_16")]
        VST_16,

        /// <summary>Vorsteuer 7%</summary>
        [EnumMember(Value = "VST_7")]
        VST_7,

        /// <summary>Reverse Charge Verfahren (Umkehrung der Steuerpflicht)</summary>
        [EnumMember(Value = "RCV")]
        RCV,
    }
}
