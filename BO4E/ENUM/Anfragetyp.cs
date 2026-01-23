#nullable enable
using System.Runtime.Serialization;
using BO4E.meta;

namespace BO4E.ENUM;

/// <summary>
/// Typ/Art der Anfrage (ORDERS/ORDRSP/QUOTES IMD 7081)
/// Segment heißt entweder Produkt-/ Leistungsbeschreibung, Abonnement oder Lieferrichtung.
/// </summary>
[NonOfficial(NonOfficialCategory.MISSING)]
public enum Anfragetyp
{
    /// <summary>START_ABO</summary>
    /// <remarks>Z01</remarks>
    [EnumMember(Value = "START_ABO")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("START_ABO")]
    START_ABO,

    /// <summary>ENDE_ABO</summary>
    /// <remarks>Z02</remarks>
    [EnumMember(Value = "ENDE_ABO")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ENDE_ABO")]
    ENDE_ABO,

    /// <summary>KAUF</summary>
    /// <remarks>Z07</remarks>
    [EnumMember(Value = "KAUF")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("KAUF")]
    KAUF,

    /// <summary>NUTZUNGSUEBERLASSUNG</summary>
    /// <remarks>Z08</remarks>
    [EnumMember(Value = "NUTZUNGSUEBERLASSUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("NUTZUNGSUEBERLASSUNG")]
    NUTZUNGSUEBERLASSUNG,

    /// <summary>KANN_NICHT_ANGEBOTEN_WERDEN</summary>
    /// <remarks>Z09</remarks>
    [EnumMember(Value = "KANN_NICHT_ANGEBOTEN_WERDEN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("KANN_NICHT_ANGEBOTEN_WERDEN")]
    KANN_NICHT_ANGEBOTEN_WERDEN,

    /// <summary>ABRECHNUNGSBRENNWERT_UND_ZUSTANDSZAHL</summary>
    /// <remarks>Z10</remarks>
    [EnumMember(Value = "ABRECHNUNGSBRENNWERT_UND_ZUSTANDSZAHL")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName(
        "ABRECHNUNGSBRENNWERT_UND_ZUSTANDSZAHL"
    )]
    ABRECHNUNGSBRENNWERT_UND_ZUSTANDSZAHL,

    /// <summary>LASTGANGDATEN</summary>
    /// <remarks>Z11</remarks>
    [EnumMember(Value = "LASTGANGDATEN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("LASTGANGDATEN")]
    LASTGANGDATEN,

    /// <summary>ZAEHLERSTAENDE</summary>
    /// <remarks>Z12</remarks>
    [EnumMember(Value = "ZAEHLERSTAENDE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ZAEHLERSTAENDE")]
    ZAEHLERSTAENDE,

    /// <summary>WERTEERMITTLUNG</summary>
    /// <remarks>Z13</remarks>
    [EnumMember(Value = "WERTEERMITTLUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("WERTEERMITTLUNG")]
    WERTEERMITTLUNG,

    /// <summary>LIEFERRICHTUNG</summary>
    /// <remarks>Z14</remarks>
    [EnumMember(Value = "LIEFERRICHTUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("LIEFERRICHTUNG")]
    LIEFERRICHTUNG,

    /// <summary>ANGEBOT_AUF_BASIS_PREISBLATT</summary>
    /// <remarks>Z33</remarks>
    [EnumMember(Value = "ANGEBOT_AUF_BASIS_PREISBLATT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ANGEBOT_AUF_BASIS_PREISBLATT")]
    ANGEBOT_AUF_BASIS_PREISBLATT,

    /// <summary>INDIVIDUELLES_ANGEBOT</summary>
    /// <remarks>Z34</remarks>
    [EnumMember(Value = "INDIVIDUELLES_ANGEBOT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("INDIVIDUELLES_ANGEBOT")]
    INDIVIDUELLES_ANGEBOT,

    /// <summary>ENERGIEMENGE_EINZELWERT</summary>
    /// <remarks>Z35</remarks>
    [EnumMember(Value = "ENERGIEMENGE_EINZELWERT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ENERGIEMENGE_EINZELWERT")]
    ENERGIEMENGE_EINZELWERT,
}
