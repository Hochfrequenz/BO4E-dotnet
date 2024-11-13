using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>
/// Zuschlag einer Rechnungsposition
/// </summary>
public enum RechnungspositionsZuschlag
{
    /// <summary>
    /// Umspannungszuschlag
    /// </summary>
    [EnumMember(Value = "UMSPANNUNGSZUSCHLAG")]
    UMSPANNUNGSZUSCHLAG,

    /// <summary>
    /// allein genutzte Betriebsmittel nach § 19, Absatz 3 Stromnetzentgeltverordnung
    /// </summary>
    [EnumMember(Value = "ALLEIN_GENUTZTE_BETRIEBSMITTEL")]
    ALLEIN_GENUTZTE_BETRIEBSMITTEL,

    /// <summary>
    /// Anpassung nach § 19, Absatz 2 Stromnetzentgeltverordnung
    /// </summary>
    [EnumMember(Value = "ANPASSUNG")]
    ANPASSUNG,

    /// <summary>
    /// Anpassung Pauschale Netzentgeltreduzierung nach § 14a EnWG auf Höhe der NNE
    /// </summary>
    [EnumMember(Value = "ANPASSUNG_PAUSCHALE_NETZENTGELTREDUZIERUNG")]
    ANPASSUNG_PAUSCHALE_NETZENTGELTREDUZIERUNG,
}