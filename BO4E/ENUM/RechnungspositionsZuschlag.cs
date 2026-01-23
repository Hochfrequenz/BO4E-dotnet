#nullable enable
using System.Runtime.Serialization;
using ProtoBuf;

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
    [ProtoEnum(Name = nameof(RechnungspositionsZuschlag) + "_" + nameof(UMSPANNUNGSZUSCHLAG))]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("UMSPANNUNGSZUSCHLAG")]
    UMSPANNUNGSZUSCHLAG,

    /// <summary>
    /// allein genutzte Betriebsmittel nach § 19, Absatz 3 Stromnetzentgeltverordnung [Z03]
    /// </summary>
    [EnumMember(Value = "ALLEIN_GENUTZTE_BETRIEBSMITTEL_STROM_NEV")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName(
        "ALLEIN_GENUTZTE_BETRIEBSMITTEL_STROM_NEV"
    )]
    [ProtoEnum(
        Name = nameof(RechnungspositionsZuschlag)
            + "_"
            + nameof(ALLEIN_GENUTZTE_BETRIEBSMITTEL_STROM_NEV)
    )]
    ALLEIN_GENUTZTE_BETRIEBSMITTEL_STROM_NEV,

    /// <summary>
    /// Anpassung nach § 19, Absatz 2 Stromnetzentgeltverordnung [Z04]
    /// </summary>
    [EnumMember(Value = "ANPASSUNG_STROM_NEV_19_2")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ANPASSUNG_STROM_NEV_19_2")]
    ANPASSUNG_STROM_NEV_19_2,

    /// <summary>
    /// Anpassung Pauschale Netzentgeltreduzierung nach § 14a EnWG auf Höhe der NNE [Z05]
    /// </summary>
    [EnumMember(Value = "PAUSCHALE_NETZENTGELTREDUZIERUNG_ENWG_14A")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName(
        "PAUSCHALE_NETZENTGELTREDUZIERUNG_ENWG_14A"
    )]
    [ProtoEnum(
        Name = nameof(RechnungspositionsZuschlag)
            + "_"
            + nameof(PAUSCHALE_NETZENTGELTREDUZIERUNG_ENWG_14A)
    )]
    PAUSCHALE_NETZENTGELTREDUZIERUNG_ENWG_14A,
}
