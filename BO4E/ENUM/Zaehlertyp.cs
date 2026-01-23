#nullable enable
using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>
///     Bei diesem Enum handelt es sich die Abbildung von Zählertypen der Sparten Strom, Gas und Wasser.
/// </summary>
public enum Zaehlertyp
{
    /// <summary>Drehstromzaehler</summary>
    [EnumMember(Value = "DREHSTROMZAEHLER")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("DREHSTROMZAEHLER")]
    DREHSTROMZAEHLER,

    /// <summary>Balgengaszähler</summary>
    [EnumMember(Value = "BALGENGASZAEHLER")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BALGENGASZAEHLER")]
    BALGENGASZAEHLER,

    /// <summary>Drehkolbengaszähler</summary>
    [EnumMember(Value = "DREHKOLBENZAEHLER")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("DREHKOLBENZAEHLER")]
    DREHKOLBENZAEHLER,

    /// <summary>Smart Meter Zähler</summary>
    [EnumMember(Value = "SMARTMETER")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SMARTMETER")]
    SMARTMETER,

    /// <summary>leistungsmessender Zähler</summary>
    [EnumMember(Value = "LEISTUNGSZAEHLER")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("LEISTUNGSZAEHLER")]
    LEISTUNGSZAEHLER,

    /// <summary>Maximumzähler</summary>
    [EnumMember(Value = "MAXIMUMZAEHLER")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MAXIMUMZAEHLER")]
    MAXIMUMZAEHLER,

    /// <summary>Turbinenradgaszähler</summary>
    [EnumMember(Value = "TURBINENRADGASZAEHLER")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("TURBINENRADGASZAEHLER")]
    TURBINENRADGASZAEHLER,

    /// <summary>Ultraschallgaszähler</summary>
    [EnumMember(Value = "ULTRASCHALLGASZAEHLER")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ULTRASCHALLGASZAEHLER")]
    ULTRASCHALLGASZAEHLER,

    /// <summary>Wechselstromzähler</summary>
    [EnumMember(Value = "WECHSELSTROMZAEHLER")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("WECHSELSTROMZAEHLER")]
    WECHSELSTROMZAEHLER,

    /// <summary>Wirbelgaszähler</summary>
    [EnumMember(Value = "WIRBELGASZAEHLER")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("WIRBELGASZAEHLER")]
    WIRBELGASZAEHLER,

    /// <summary>Messdatenregistriergerät</summary>
    [EnumMember(Value = "MESSDATENREGISTRIERGERAET")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MESSDATENREGISTRIERGERAET")]
    MESSDATENREGISTRIERGERAET,

    /// <summary>elektronischer Haushaltszähler</summary>
    [EnumMember(Value = "ELEKTRONISCHERHAUSHALTSZAEHLER")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ELEKTRONISCHERHAUSHALTSZAEHLER")]
    ELEKTRONISCHERHAUSHALTSZAEHLER,

    /// <summary>Individuelle Abstimmung (Sonderausstattung)</summary>
    [EnumMember(Value = "SONDERAUSSTATTUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SONDERAUSSTATTUNG")]
    SONDERAUSSTATTUNG,

    ///<summary>Wasserzähler</summary>
    [EnumMember(Value = "WASSERZAEHLER")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("WASSERZAEHLER")]
    WASSERZAEHLER,

    ///<summary>Moderne Messeinrichtung</summary>
    [EnumMember(Value = "MODERNEMESSEINRICHTUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MODERNEMESSEINRICHTUNG")]
    MODERNEMESSEINRICHTUNG,

    ///<summary>Neue Messeinrichtung Gas</summary>
    [EnumMember(Value = "NEUEMESSEINRICHTUNGGAS")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("NEUEMESSEINRICHTUNGGAS")]
    NEUEMESSEINRICHTUNGGAS,

    ///<summary>Mengenumwerter</summary>
    [EnumMember(Value = "MENGENUMWERTER")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MENGENUMWERTER")]
    MENGENUMWERTER,
}
