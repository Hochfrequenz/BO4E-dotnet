using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>
/// Wahlrecht der Prognosegrundlage der Marktlokation
/// </summary>
/// <remarks> SG10 CAV </remarks>
public enum WahlrechtPrognosegrundlage
{
    /// <summary>
    /// Wahlrecht durch LF gegeben
    /// </summary>
    /// <remarks> CAV+Z54 </remarks>
    [EnumMember(Value = "DURCH_LF")]
    DURCH_LF,
    /// <summary>
    /// Wahlrecht durch LF gegeben
    /// </summary>
    /// <remarks> CAV+ZE2 </remarks>
    [EnumMember(Value = "DURCH_LF_NICHT_GEGEBEN")]
    DURCH_LF_NICHT_GEGEBEN,

    /// <summary>
    /// Wahlrecht nicht vorhanden wegen Verbrauch > 10.000 kWh/a
    /// </summary>
    /// <remarks> CAV+Z55 </remarks>
    [EnumMember(Value = "NICHT_WEGEN_GROSSEN_VERBRAUCHS")]
    NICHT_WEGEN_GROSSEN_VERBRAUCHS,

    /// <summary>
    /// Wahlrecht nicht vorhanden wegen Eigenverbrauch
    /// </summary>
    /// <remarks> CAV+ZC1 </remarks>
    [EnumMember(Value = "NICHT_WEGEN_EIGENVERBRAUCH")]
    NICHT_WEGEN_EIGENVERBRAUCH,

    /// <summary>
    /// Wahlrecht nicht vorhanden wegen tagesparameterabhängigem Verbrauch
    /// </summary>
    /// <remarks> CAV+ZD2 </remarks>
    [EnumMember(Value = "NICHT_WEGEN_TAGES_VERBRAUCH")]
    NICHT_WEGEN_TAGES_VERBRAUCH,

    /// <summary>
    /// Wahlrecht nicht vorhanden wegen §14a EnWG
    /// </summary>
    /// <remarks> CAV+ZE3 </remarks>
    [EnumMember(Value = "NICHT_WEGEN_ENWG")]
    NICHT_WEGEN_ENWG,
}
