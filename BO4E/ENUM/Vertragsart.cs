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
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ENERGIELIEFERVERTRAG")]
    ENERGIELIEFERVERTRAG,

    /// <summary>
    ///     Netznutzungsvertrag
    /// </summary>
    [EnumMember(Value = "NETZNUTZUNGSVERTRAG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("NETZNUTZUNGSVERTRAG")]
    NETZNUTZUNGSVERTRAG,

    /// <summary>
    ///     Bilanzierungsvertrag
    /// </summary>
    [EnumMember(Value = "BILANZIERUNGSVERTRAG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BILANZIERUNGSVERTRAG")]
    BILANZIERUNGSVERTRAG,

    /// <summary>
    ///     Messstellenabetriebsvertrag
    /// </summary>
    [EnumMember(Value = "MESSSTELLENBETRIEBSVERTRAG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MESSSTELLENBETRIEBSVERTRAG")]
    MESSSTELLENBETRIEBSVERTRAG,

    /// <summary>
    ///     Bündelvertrag
    /// </summary>
    [EnumMember(Value = "BUENDELVERTRAG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BUENDELVERTRAG")]
    BUENDELVERTRAG,
}
