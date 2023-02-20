using System.Runtime.Serialization;

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

        /// <summary>Umsatzsteuer mit abweichendem Satz</summary>
        /// <remarks>Soll verwendet werden, wenn weder <see cref="UST_7"/> noch <see cref="UST_16"/> noch <see cref="UST_19"/> anwendbar sind.</remarks>
        [EnumMember(Value = "UST_SONDER")]
        UST_SONDER,
    }
}
