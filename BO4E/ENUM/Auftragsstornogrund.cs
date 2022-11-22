using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;

namespace BO4E.ENUM
{
    /// <summary>Auftragsstornogrund für Sperr- bzw. Entsperrauftragsstornoantworten for 19128 and 19129</summary>
    public enum Auftragsstornogrund
    {
        /// <summary>A02</summary>
        [EnumMember(Value = "STORNIERUNG_DER_ENTSPERRUNG_NICHT_MEHR_MOEGLICH")]
        STORNIERUNG_DER_ENTSPERRUNG_NICHT_MEHR_MOEGLICH,

        /// <summary>A05</summary>
        [EnumMember(Value = "STORNIERUNG_DER_SPERRUNG_NICHT_MEHR_MOEGLICH")]
        STORNIERUNG_DER_SPERRUNG_NICHT_MEHR_MOEGLICH,

        /// <summary>A01</summary>
        [EnumMember(Value = "STORNIERUNG_DER_ENTSPERRUNG_ERFOLGT")]
        STORNIERUNG_DER_ENTSPERRUNG_ERFOLGT,

        /// <summary>A04</summary>
        [EnumMember(Value = "STORNIERUNG_DER_SPERRUNG_ERFOLGT")]
        STORNIERUNG_DER_SPERRUNG_ERFOLGT,

        /// <summary>A03</summary>
        [EnumMember(Value = "STORNIERUNG_DER_SPERRUNG_BIS_ZUM_VORTAG_ERFOLGT")]
        STORNIERUNG_DER_SPERRUNG_BIS_ZUM_VORTAG_ERFOLGT
    }
}