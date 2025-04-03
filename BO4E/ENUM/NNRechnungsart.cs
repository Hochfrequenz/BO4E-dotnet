using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Abbildung verschiedener in der INVOIC angegebenen Rechnungsarten.</summary>
public enum NNRechnungsart
{
    /// <summary>Selbst ausgestellte Rechnung, z.B. für Einspeiserechnungen.</summary>
    [EnumMember(Value = "SELBSTAUSGESTELLT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SELBSTAUSGESTELLT")]
    SELBSTAUSGESTELLT,
}
