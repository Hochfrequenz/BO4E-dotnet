using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>* Gibt an, ob es sich um einen Einrichtungs- oder Zweirichtungszähler handelt.</summary>
public enum Zaehlerauspraegung
{
    /// <summary>Einrichtungszaehler</summary>
    [EnumMember(Value = "EINRICHTUNGSZAEHLER")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("EINRICHTUNGSZAEHLER")]
    EINRICHTUNGSZAEHLER,

    /// <summary>Zweirichtungszaehler</summary>
    [EnumMember(Value = "ZWEIRICHTUNGSZAEHLER")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ZWEIRICHTUNGSZAEHLER")]
    ZWEIRICHTUNGSZAEHLER,
}
