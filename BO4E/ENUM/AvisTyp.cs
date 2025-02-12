using System.Runtime.Serialization;
using BO4E.meta;

namespace BO4E.ENUM;

/// <summary>
/// Gibt den Typ des Avis an. (REMADV BGM 1001)
/// </summary>
[NonOfficial(NonOfficialCategory.MISSING)]
public enum AvisTyp
{
    /// <summary> ABGELEHNTE_FORDERUNG </summary>
    /// <remarks>239</remarks>
    [EnumMember(Value = "ABGELEHNTE_FORDERUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ABGELEHNTE_FORDERUNG")]
    ABGELEHNTE_FORDERUNG,

    /// <summary> ZAHLUNGSAVIS </summary>
    /// <remarks>481</remarks>
    [EnumMember(Value = "ZAHLUNGSAVIS")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ZAHLUNGSAVIS")]
    ZAHLUNGSAVIS,
}
