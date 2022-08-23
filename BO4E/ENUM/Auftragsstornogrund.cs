namespace BO4E.ENUM
{
    /// <summary>Auftragsstornogrund für Sperr- bzw. Entsperrauftragsstornoantworten for 19128 and 19129</summary>
    public enum Auftragsstornogrund
    {
        /// <summary>A02</summary>
        STORNIERUNG_DER_ENTSPERRUNG_NICHT_MEHR_MOEGLICH,

        /// <summary>A05</summary>
        STORNIERUNG_DER_SPERRUNG_NICHT_MEHR_MOEGLICH,

        /// <summary>A01</summary>
        STORNIERUNG_DER_ENTSPERRUNG_ERFOLGT,

        /// <summary>A04</summary>
        STORNIERUNG_DER_SPERRUNG_ERFOLGT,

        /// <summary>A03</summary>
        STORNIERUNG_DER_SPERRUNG_BIS_ZUM_VORTAG_ERFOLGT
    }
}