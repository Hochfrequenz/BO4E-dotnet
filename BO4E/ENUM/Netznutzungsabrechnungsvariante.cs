using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Netznutzungsabrechnungsvariante</summary>
public enum Netznutzungsabrechnungsvariante
{
    /// <summary>Z14: Arbeitspreis/Grundpreis</summary>
    [EnumMember(Value = "ARBEITSPREIS_GRUNDPREIS")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ARBEITSPREIS_GRUNDPREIS")]
    ARBEITSPREIS_GRUNDPREIS,

    /// <summary>Z15: Arbeitspreis/Leistungspreis</summary>
    [EnumMember(Value = "ARBEITSPREIS_LEISTUNGSPREIS")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ARBEITSPREIS_LEISTUNGSPREIS")]
    ARBEITSPREIS_LEISTUNGSPREIS,
}
