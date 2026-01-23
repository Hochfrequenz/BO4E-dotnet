#nullable enable
using System.Runtime.Serialization;
using BO4E.meta;

namespace BO4E.ENUM;

/// <summary>
/// Gründe aus denen ein <see cref="BO.Sperrauftrag"/> abgelehnt werden kann.
/// </summary>
/// <remarks>Diese Information kann in der EDIFACT-Nachricht des Typs 19117 verwendet werden</remarks>
[NonOfficial(NonOfficialCategory.REGULATORY_REQUIREMENTS)]
public enum Sperrauftragsablehngrund
{
    /// <summary>
    /// Sperrauftrag für Marktlokation liegt bereits vor bzw. ist bereits gesperrt.
    /// </summary>
    /// <remarks>EBD 0470 A01</remarks>
    [EnumMember(Value = "DUPLIKAT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("DUPLIKAT")]
    DUPLIKAT,

    /// <summary>
    /// An mindestens einer Messlokation ist ein anderer MSB zugeordnet als an der Marktlokation.
    /// </summary>
    /// <remarks>EBD 0470 A02</remarks>
    [EnumMember(Value = "FALSCHER_MSB")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("FALSCHER_MSB")]
    FALSCHER_MSB,

    /// <summary>
    /// Marktlokation ist bspw. nicht <see cref="Netzebene.NSP"/>
    /// </summary>
    /// <remarks>EBD 0470 A03</remarks>
    [EnumMember(Value = "FALSCHE_SPANNUNGSEBENE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("FALSCHE_SPANNUNGSEBENE")]
    FALSCHE_SPANNUNGSEBENE,

    /// <summary>
    /// Mindestens eine weitere Marktlokation ist von der Sperrung betroffen.
    /// </summary>
    /// <remarks>EBD 0470 A04</remarks>
    [EnumMember(Value = "WEITERE_MALO_BETROFFEN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("WEITERE_MALO_BETROFFEN")]
    WEITERE_MALO_BETROFFEN,

    /// <summary>
    /// Ein Verhinderungsgrund liegt vor und wird in <see cref="BO.Auftrag.Bemerkungen"/> genauer spezifiziert.
    /// </summary>
    /// <remarks>EBD 0470 A05</remarks>
    [EnumMember(Value = "ANDERER_ABLEHNGRUND")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ANDERER_ABLEHNGRUND")]
    ANDERER_ABLEHNGRUND,

    /// <summary>
    /// Fristverletzung bei einem termingebundenen Sperrauftrag
    /// </summary>
    /// <remarks>EBD 0470 A06</remarks>
    [EnumMember(Value = "FRISTVERLETZUNG_TERMINGEBUNDEN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("FRISTVERLETZUNG_TERMINGEBUNDEN")]
    FRISTVERLETZUNG_TERMINGEBUNDEN,

    /// <summary>
    /// Fristverletzung bei einem nicht termingebundenen Sperrauftrag
    /// </summary>
    /// <remarks>EBD 0470 A07</remarks>
    [EnumMember(Value = "FRISTVERLETZUNG_NICHT_TERMINGEBUNDEN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName(
        "FRISTVERLETZUNG_NICHT_TERMINGEBUNDEN"
    )]
    FRISTVERLETZUNG_NICHT_TERMINGEBUNDEN,

    /// <summary>
    /// Ein Fehler liegt vor und wird in <see cref="BO.Auftrag.Bemerkungen"/> genauer spezifiziert.
    /// </summary>
    /// <remarks>EBD 0470 A99</remarks>
    [EnumMember(Value = "ANDERER_FEHLER")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ANDERER_FEHLER")]
    ANDERER_FEHLER,

    /// <summary>
    /// Sperrauftrag für Marktlokation liegt bereits vor.
    /// </summary>
    /// <remarks>FV2304 EBD 0470 A10</remarks>
    [EnumMember(Value = "LIEGT_BEREITS_VOR")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("LIEGT_BEREITS_VOR")]
    LIEGT_BEREITS_VOR,

    /// <summary>
    /// Zukünftiger bestätigter Lieferbeginn liegt gegenüber anderem Lieferanten bereits vor.
    /// </summary>
    /// <remarks>FV2304 EBD 0470 A11</remarks>
    [EnumMember(Value = "ANDERER_ZUKUENFTIGER_LIEFERANT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ANDERER_ZUKUENFTIGER_LIEFERANT")]
    ANDERER_ZUKUENFTIGER_LIEFERANT,

    /// <summary>
    /// Im Ausführungszeitraum liegt bereits ein bestätigter Lieferbeginn gegenüber dem beauftragenden LF vor.
    /// </summary>
    /// <remarks>FV2304 EBD 0470 A12</remarks>
    [EnumMember(Value = "BESTAETIGTER_LIEFERBEGINN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BESTAETIGTER_LIEFERBEGINN")]
    BESTAETIGTER_LIEFERBEGINN,
}
