using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Aulistung der verschiedenen Berechnungsmethoden für ein Preisblatt.</summary>
public enum Kalkulationsmethode
{
    /// <summary>Es wird keine Berechnung durchgeführt, sondern lediglich die Menge mit dem Preis multipliziert.</summary>
    [EnumMember(Value = "KEINE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("KEINE")]
    KEINE,

    /// <summary>
    ///     Staffelmodell, d.h. die Gesamtmenge wird in eine Staffel eingeordnet und für die gesamte Menge gilt der so
    ///     ermittelte Preis
    /// </summary>
    [EnumMember(Value = "STAFFELN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("STAFFELN")]
    STAFFELN,

    /// <summary>
    ///     Zonenmodell, d.h. die Gesamtmenge wird auf die Zonen aufgeteilt und für die Teilmengen gilt der jeweilige
    ///     Preis der Zone.
    /// </summary>
    [EnumMember(Value = "ZONEN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ZONEN")]
    ZONEN,

    /// <summary>Vorzonengrundpreis</summary>
    [EnumMember(Value = "VORZONEN_GP")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("VORZONEN_GP")]
    VORZONEN_GP,

    /// <summary>Sigmoidfunktion</summary>
    [EnumMember(Value = "SIGMOID")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SIGMOID")]
    SIGMOID,

    /// <summary>Blindarbeit oberhalb 50% der Wirkarbeit</summary>
    [EnumMember(Value = "BLINDARBEIT_GT_50_PROZENT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BLINDARBEIT_GT_50_PROZENT")]
    BLINDARBEIT_GT_50_PROZENT,

    /// <summary>Blindarbeit oberhalb 40% der Wirkarbeit</summary>
    [EnumMember(Value = "BLINDARBEIT_GT_40_PROZENT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BLINDARBEIT_GT_40_PROZENT")]
    BLINDARBEIT_GT_40_PROZENT,

    /// <summary>Arbeits- und Grundpreis gezont</summary>
    [EnumMember(Value = "AP_GP_ZONEN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("AP_GP_ZONEN")]
    AP_GP_ZONEN,

    /// <summary>Leistungsentgelt auf Grundlage der installierten Leistung</summary>
    [EnumMember(Value = "LP_INSTALL_LEISTUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("LP_INSTALL_LEISTUNG")]
    LP_INSTALL_LEISTUNG,

    /// <summary>AP auf Grundlage Transport- oder Verteilnetz</summary>
    [EnumMember(Value = "AP_TRANSPORT_ODER_VERTEILNETZ")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("AP_TRANSPORT_ODER_VERTEILNETZ")]
    AP_TRANSPORT_ODER_VERTEILNETZ,

    /// <summary>AP auf Grundlage Transport- oder Verteilnetz, Ortsverteilnetz über Sigmoid</summary>
    [EnumMember(Value = "AP_TRANSPORT_ODER_VERTEILNETZ_ORTSVERTEILNETZ_SIGMOID")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName(
        "AP_TRANSPORT_ODER_VERTEILNETZ_ORTSVERTEILNETZ_SIGMOID"
    )]
    AP_TRANSPORT_ODER_VERTEILNETZ_ORTSVERTEILNETZ_SIGMOID,

    /// <summary>Leistungsentgelt auf Grundlage des Jahresverbrauchs</summary>
    [EnumMember(Value = "LP_JAHRESVERBRAUCH")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("LP_JAHRESVERBRAUCH")]
    LP_JAHRESVERBRAUCH,

    /// <summary>LP auf Grundlage Transport- oder Verteilnetz</summary>
    [EnumMember(Value = "LP_TRANSPORT_ODER_VERTEILNETZ")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("LP_TRANSPORT_ODER_VERTEILNETZ")]
    LP_TRANSPORT_ODER_VERTEILNETZ,

    /// <summary>LP auf Grundlage Transport- oder Verteilnetz, Ortsverteilnetz über Sigmoid</summary>
    [EnumMember(Value = "LP_TRANSPORT_ODER_VERTEILNETZ_ORTSVERTEILNETZ_SIGMOID")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName(
        "LP_TRANSPORT_ODER_VERTEILNETZ_ORTSVERTEILNETZ_SIGMOID"
    )]
    LP_TRANSPORT_ODER_VERTEILNETZ_ORTSVERTEILNETZ_SIGMOID,

    /// <summary>Funktionsbezogene Leistungsermittlung bei Verbräuchen oberhalb der SLP Grenze. (ähnlich Sigmoid)</summary>
    [EnumMember(Value = "FUNKTIONEN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("FUNKTIONEN")]
    FUNKTIONEN,

    /// <summary>
    ///     Bei einem Verbrauch über der SLP-Grenze (letzte Staffelgrenze überschritten) erfolgt die Berechnung
    ///     funktionsbezogen (s.o.) als LGK.
    /// </summary>
    [EnumMember(Value = "VERBRAUCH_UEBER_SLP_GRENZE_FUNKTIONSBEZOGEN_WEITERE_BERECHNUNG_ALS_LGK")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName(
        "VERBRAUCH_UEBER_SLP_GRENZE_FUNKTIONSBEZOGEN_WEITERE_BERECHNUNG_ALS_LGK"
    )]
    VERBRAUCH_UEBER_SLP_GRENZE_FUNKTIONSBEZOGEN_WEITERE_BERECHNUNG_ALS_LGK,
}
