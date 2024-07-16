using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>
///     Aufzählung der Vertragsarten
/// </summary>
public enum Vertragsart
{
    /// <summary>
    ///     Energieliefervertrag
    /// </summary>
    [EnumMember(Value = "ENERGIELIEFERVERTRAG")]
    ENERGIELIEFERVERTRAG,

    /// <summary>
    ///     Netznutzungsvertrag
    /// </summary>
    [EnumMember(Value = "NETZNUTZUNGSVERTRAG")]
    NETZNUTZUNGSVERTRAG,

    /// <summary>
    ///     Bilanzierungsvertrag
    /// </summary>
    [EnumMember(Value = "BILANZIERUNGSVERTRAG")]
    BILANZIERUNGSVERTRAG,

    /// <summary>
    ///     Messstellenabetriebsvertrag
    /// </summary>
    [EnumMember(Value = "MESSSTELLENBETRIEBSVERTRAG")]
    MESSSTELLENBETRIEBSVERTRAG,

    /// <summary>
    ///     Bündelvertrag
    /// </summary>
    [EnumMember(Value = "BUENDELVERTRAG")]
    BUENDELVERTRAG,
}