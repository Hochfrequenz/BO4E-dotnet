using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Bezeichnung der Preismodelle in Ausschreibungen für die Energielieferung.</summary>
public enum Preismodell
{
    /// <summary>Tranche</summary>
    [EnumMember(Value = "TRANCHE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("TRANCHE")]
    TRANCHE,
}
