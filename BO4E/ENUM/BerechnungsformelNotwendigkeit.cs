using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>
/// Beschreibt, ob eine Berechnungsformel notwendig ist
/// </summary>
/// <remarks>Enspricht dem UTILTS SG5+STS Datenelement 4405 "Status der Berechnungsformel"</remarks>
public enum BerechnungsformelNotwendigkeit
{
    /// <summary>
    /// Berechnungsformel angefügt
    /// </summary>
    /// <remarks>Z33</remarks>
    [EnumMember(Value = "BERECHNUNGSFORMEL_NOTWENDIG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BERECHNUNGSFORMEL_NOTWENDIG")]
    BERECHNUNGSFORMEL_NOTWENDIG,

    /// <summary>
    /// Berechnungsformel muss beim Absender angefragt werden
    /// </summary>
    /// <remarks>Z34</remarks>
    [EnumMember(Value = "BERECHNUNGSFORMEL_MUSS_ANGEFRAGT_WERDEN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName(
        "BERECHNUNGSFORMEL_MUSS_ANGEFRAGT_WERDEN"
    )]
    BERECHNUNGSFORMEL_MUSS_ANGEFRAGT_WERDEN,

    /// <summary>
    /// Berechnungsformel besitzt keine Rechenoperation
    /// </summary>
    /// <remarks>Z40</remarks>
    [EnumMember(Value = "BERECHNUNGSFORMEL_TRIVIAL")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BERECHNUNGSFORMEL_TRIVIAL")]
    BERECHNUNGSFORMEL_TRIVIAL,

    /// <summary>
    /// Berechnungsformel ist nicht erforderlich
    /// </summary>
    [EnumMember(Value = "BERECHNUNGSFORMEL_NICHT_NOTWENDIG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BERECHNUNGSFORMEL_NICHT_NOTWENDIG")]
    BERECHNUNGSFORMEL_NICHT_NOTWENDIG,
}
