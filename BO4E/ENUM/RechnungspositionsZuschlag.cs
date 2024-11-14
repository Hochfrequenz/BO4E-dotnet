using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>
/// Zuschlag einer Rechnungsposition
/// </summary>
public enum RechnungspositionsZuschlag
{
    /// <summary>
    /// Umspannungszuschlag [Z02]
    /// </summary>
    [EnumMember(Value = "UMSPANNUNGSZUSCHLAG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("UMSPANNUNGSZUSCHLAG")]
    UMSPANNUNGSZUSCHLAG,

    /// <summary>
    /// allein genutzte Betriebsmittel nach § 19, Absatz 3 Stromnetzentgeltverordnung [Z03]
    /// </summary>
    [EnumMember(Value = "ALLEIN_GENUTZTE_BETRIEBSMITTEL")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ALLEIN_GENUTZTE_BETRIEBSMITTEL")]
    ALLEIN_GENUTZTE_BETRIEBSMITTEL,

    /// <summary>
    /// Anpassung nach § 19, Absatz 2 Stromnetzentgeltverordnung [Z04]
    /// </summary>
    [EnumMember(Value = "ZUSCHLAG_ANPASSUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ZUSCHLAG_ANPASSUNG")]
    ZUSCHLAG_ANPASSUNG,

    /// <summary>
    /// Anpassung Pauschale Netzentgeltreduzierung nach § 14a EnWG auf Höhe der NNE [Z05]
    /// </summary>
    [EnumMember(Value = "ANPASSUNG_PAUSCHALE_NETZENTGELTREDUZIERUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName(
        "ANPASSUNG_PAUSCHALE_NETZENTGELTREDUZIERUNG"
    )]
    ANPASSUNG_PAUSCHALE_NETZENTGELTREDUZIERUNG,
}
