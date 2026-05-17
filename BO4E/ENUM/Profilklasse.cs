using System.Runtime.Serialization;
using BO4E.meta;

namespace BO4E.ENUM;

/// <summary>Profiltyp (temperaturabhängig / standardlastprofil)</summary>
[NonOfficial(NonOfficialCategory.REGULATORY_REQUIREMENTS)]
public enum Profilklasse
{
    /// <summary>Gewerbe Werktags</summary>
    [ProtoBuf.ProtoEnum(Name = nameof(Profilklasse) + "_" + nameof(GEWERBE))]
    [EnumMember(Value = "GEWERBE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GEWERBE")]
    GEWERBE,

    /// <summary>Gewerbe Werktags 9 bis 18 Uhr</summary>
    [EnumMember(Value = "GEWERBE_WERKTAG_9_BIS_18")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GEWERBE_WERKTAG_9_BIS_18")]
    GEWERBE_WERKTAG_9_BIS_18,

    /// <summary>Gewerbe mit starkem bis überwiegendem Verbrauch in den Abendstunden</summary>
    [EnumMember(Value = "GEWERBE_ABEND")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GEWERBE_ABEND")]
    GEWERBE_ABEND,

    /// <summary>Gewerbe durchlaufend</summary>
    [EnumMember(Value = "GEWERBE_DURCHLAUFEND")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GEWERBE_DURCHLAUFEND")]
    GEWERBE_DURCHLAUFEND,

    /// <summary>Gewerbe Laden/Friseur</summary>
    [EnumMember(Value = "GEWERBE_LADEN_FRISEUR")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GEWERBE_LADEN_FRISEUR")]
    GEWERBE_LADEN_FRISEUR,

    /// <summary>Gewerbe Bäckerei mit Backstube</summary>
    [EnumMember(Value = "GEWERBE_BAECKEREI")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GEWERBE_BAECKEREI")]
    GEWERBE_BAECKEREI,

    /// <summary>Gewerbe Wochenendbetrieb</summary>
    [EnumMember(Value = "GEWERBE_WOCHENENDE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GEWERBE_WOCHENENDE")]
    GEWERBE_WOCHENENDE,

    /// <summary>Landwirtschaftsbetriebe allgemein</summary>
    [EnumMember(Value = "LANDWIRTSCHAFT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("LANDWIRTSCHAFT")]
    LANDWIRTSCHAFT,

    /// <summary>Landwirtschaftsbetriebe mit Milchwirtschaft/Nebenerwerbs-Tierzucht</summary>
    [EnumMember(Value = "LANDWIRTSCHAFT_MIT_MILCH")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("LANDWIRTSCHAFT_MIT_MILCH")]
    LANDWIRTSCHAFT_MIT_MILCH,

    /// <summary>Landwirtschaft ohne Milchvieh</summary>
    [EnumMember(Value = "LANDWIRTSCHAFT_OHNE_MILCH")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("LANDWIRTSCHAFT_OHNE_MILCH")]
    LANDWIRTSCHAFT_OHNE_MILCH,

    /// <summary>Haushalt</summary>
    [EnumMember(Value = "HAUSHALT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("HAUSHALT")]
    HAUSHALT,

    /// <summary>Bandlast</summary>
    [EnumMember(Value = "BANDLAST")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BANDLAST")]
    BANDLAST,

    /// <summary>Unterbrechbare Verbrauchseinrichtung</summary>
    [EnumMember(Value = "UNTERBRECHBARE_VERBRAUCHSEINRICHTUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName(
        "UNTERBRECHBARE_VERBRAUCHSEINRICHTUNG"
    )]
    UNTERBRECHBARE_VERBRAUCHSEINRICHTUNG,

    /// <summary>Heizwärmespeicher</summary>
    [EnumMember(Value = "HEIZWAERMESPEICHER")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("HEIZWAERMESPEICHER")]
    HEIZWAERMESPEICHER,

    /// <summary>Straßenbeleuchtung</summary>
    [EnumMember(Value = "STRASSENBELEUCHTUNG")]
    [ProtoBuf.ProtoEnum(Name = nameof(Profilklasse) + "_" + nameof(STRASSENBELEUCHTUNG))]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("STRASSENBELEUCHTUNG")]
    STRASSENBELEUCHTUNG,

    /// <summary>Photovoltaik-Marktlokation</summary>
    [EnumMember(Value = "PHOTOVOLTAIK")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("PHOTOVOLTAIK")]
    PHOTOVOLTAIK,

    /// <summary>Blockheizkraftwerk</summary>
    [EnumMember(Value = "BLOCKHEIZKRAFTWERK")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BLOCKHEIZKRAFTWERK")]
    BLOCKHEIZKRAFTWERK,

    /// <summary>Sonstige verbrauchende Marktlokation</summary>
    [EnumMember(Value = "SONSTIGE_VERBRAUCHENDE_MARKTLOKATION")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName(
        "SONSTIGE_VERBRAUCHENDE_MARKTLOKATION"
    )]
    SONSTIGE_VERBRAUCHENDE_MARKTLOKATION,

    /// <summary>Sonstige erzeugende Marktlokation</summary>
    [EnumMember(Value = "SONSTIGE_ERZEUGENDE_MARKTLOKATION")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SONSTIGE_ERZEUGENDE_MARKTLOKATION")]
    SONSTIGE_ERZEUGENDE_MARKTLOKATION,

    /// <summary>E-Mobilität Ladepunkt im öffentlichen Bereich</summary>
    [EnumMember(Value = "EMOB_OEFFENTLICH")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("EMOB_OEFFENTLICH")]
    EMOB_OEFFENTLICH,

    /// <summary>E-Mobilität Ladepunkt eines Haushalts</summary>
    [EnumMember(Value = "EMOB_HAUSHALT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("EMOB_HAUSHALT")]
    EMOB_HAUSHALT,

    /// <summary>E-Mobilität Ladepunkt eines Gewerbes</summary>
    [EnumMember(Value = "EMOB_GEWERBE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("EMOB_GEWERBE")]
    EMOB_GEWERBE,
}
