using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Kundengruppe für eine Marktlokation (orientiert sich an den Standard-Lastprofilen).</summary>
public enum Kundengruppe
{
    /// <summary>Kunde mit registrierender Leistungsmessung (kein SLP)</summary>
    [EnumMember(Value = "RLM")]
    RLM,

    /// <summary>Gewerbe allgemein</summary>
    [EnumMember(Value = "SLP_S_G0")]
    SLP_S_G0,

    /// <summary>Werktags</summary>
    [EnumMember(Value = "SLP_S_G1")]
    SLP_S_G1,

    /// <summary>Verbrauch in Abendstunden</summary>
    [EnumMember(Value = "SLP_S_G2")]
    SLP_S_G2,

    /// <summary>Gewerbe durchlaufend</summary>
    [EnumMember(Value = "SLP_S_G3")]
    SLP_S_G3,

    /// <summary>Laden, Friseur</summary>
    [EnumMember(Value = "SLP_S_G4")]
    SLP_S_G4,

    /// <summary>Bäckerei mit Backstube</summary>
    [EnumMember(Value = "SLP_S_G5")]
    SLP_S_G5,

    /// <summary>Wochenendbetrieb</summary>
    [EnumMember(Value = "SLP_S_G6")]
    SLP_S_G6,

    /// <summary>Mobilfunksendestation</summary>
    [EnumMember(Value = "SLP_S_G7")]
    SLP_S_G7,

    /// <summary>Landwirtschaft allgemein</summary>
    [EnumMember(Value = "SLP_S_L0")]
    SLP_S_L0,

    /// <summary>Landwirtschaft mit Milchwirtschaft/Nebenerwerbs-Tierzucht</summary>
    [EnumMember(Value = "SLP_S_L1")]
    SLP_S_L1,

    /// <summary>Übrige Landwirtschaftsbetriebe</summary>
    [EnumMember(Value = "SLP_S_L2")]
    SLP_S_L2,

    /// <summary>Haushalt allgemein</summary>
    [EnumMember(Value = "SLP_S_H0")]
    SLP_S_H0,

    /// <summary>Straßenbeleuchtung</summary>
    [EnumMember(Value = "SLP_S_SB")]
    SLP_S_SB,

    /// <summary>Nachtspeicherheizung</summary>
    [EnumMember(Value = "SLP_S_HZ")]
    SLP_S_HZ,

    /// <summary>Wärmepumpe</summary>
    [EnumMember(Value = "SLP_S_WP")]
    SLP_S_WP,

    /// <summary>Gebietskörpersch., Kreditinst. u. Versich., Org. o. Erwerbszw. &amp; öff. Einr.</summary>
    [EnumMember(Value = "SLP_G_GKO")]
    SLP_G_GKO,

    /// <summary>Einzelhandel, Großhandel</summary>
    [EnumMember(Value = "SLP_G_GHA")]
    SLP_G_GHA,

    /// <summary>Metall, Kfz</summary>
    [EnumMember(Value = "SLP_G_GMK")]
    SLP_G_GMK,

    /// <summary>sonst. betr. Dienstleistungen</summary>
    [EnumMember(Value = "SLP_G_GBD")]
    SLP_G_GBD,

    /// <summary>Beherbergung</summary>
    [EnumMember(Value = "SLP_G_GGA")]
    SLP_G_GGA,

    /// <summary>Gaststätten</summary>
    [EnumMember(Value = "SLP_G_GBH")]
    SLP_G_GBH,

    /// <summary>Bäckereien</summary>
    [EnumMember(Value = "SLP_G_GBA")]
    SLP_G_GBA,

    /// <summary>Wäschereien</summary>
    [EnumMember(Value = "SLP_G_GWA")]
    SLP_G_GWA,

    /// <summary>Gartenbau</summary>
    [EnumMember(Value = "SLP_G_GGB")]
    SLP_G_GGB,

    /// <summary>Papier und Druck</summary>
    [EnumMember(Value = "SLP_G_GPD")]
    SLP_G_GPD,

    /// <summary>haushaltsähnliche Gewerbebetriebe</summary>
    [EnumMember(Value = "SLP_G_GMF")]
    SLP_G_GMF,

    /// <summary>Einfamilienhaushalt</summary>
    [EnumMember(Value = "SLP_G_HEF")]
    SLP_G_HEF,

    /// <summary>Mehrfamilienhaushalt</summary>
    [EnumMember(Value = "SLP_G_HMF")]
    SLP_G_HMF,

    /// <summary>Kochgas</summary>
    [EnumMember(Value = "SLP_G_HKO")]
    SLP_G_HKO,
}
