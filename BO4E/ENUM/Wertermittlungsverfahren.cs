#nullable enable
using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>
///     Gibt an, ob es sich um eine Prognose oder eine Messung handelt, beispielsweise bei der Abbildung eines Verbrauchs.
/// </summary>
public enum Wertermittlungsverfahren
{
    /// <summary>
    ///     Prognose
    /// </summary>
    [EnumMember(Value = "PROGNOSE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("PROGNOSE")]
    PROGNOSE,

    /// <summary>
    ///     Messung
    /// </summary>
    [EnumMember(Value = "MESSUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MESSUNG")]
    MESSUNG,
}
