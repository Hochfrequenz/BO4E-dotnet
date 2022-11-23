using System.Runtime.Serialization;

namespace BO4E.ENUM
{
    /// <summary>
    ///     Bei diesem Enum handelt es sich die Abbildung von Zählertypen der Sparten Strom, Gas und Wasser.
    /// </summary>
    public enum Zaehlertyp
    {
        /// <summary>Drehstromzaehler</summary>
        [EnumMember(Value = "DREHSTROMZAEHLER")]
        DREHSTROMZAEHLER,

        /// <summary>Balgengaszähler</summary>
        [EnumMember(Value = "BALGENGASZAEHLER")]
        BALGENGASZAEHLER,

        /// <summary>Drehkolbengaszähler</summary>
        [EnumMember(Value = "DREHKOLBENZAEHLER")]
        DREHKOLBENZAEHLER,

        /// <summary>Smart Meter Zähler</summary>
        [EnumMember(Value = "SMARTMETER")]
        SMARTMETER,

        /// <summary>leistungsmessender Zähler</summary>
        [EnumMember(Value = "LEISTUNGSZAEHLER")]
        LEISTUNGSZAEHLER,

        /// <summary>Maximumzähler</summary>
        [EnumMember(Value = "MAXIMUMZAEHLER")]
        MAXIMUMZAEHLER,

        /// <summary>Turbinenradgaszähler</summary>
        [EnumMember(Value = "TURBINENRADGASZAEHLER")]
        TURBINENRADGASZAEHLER,

        /// <summary>Ultraschallgaszähler</summary>
        [EnumMember(Value = "ULTRASCHALLGASZAEHLER")]
        ULTRASCHALLGASZAEHLER,

        /// <summary>Wechselstromzähler</summary>
        [EnumMember(Value = "WECHSELSTROMZAEHLER")]
        WECHSELSTROMZAEHLER,

        /// <summary>Wirbelgaszähler</summary>
        [EnumMember(Value = "WIRBELGASZAEHLER")]
        WIRBELGASZAEHLER,

        /// <summary>Messdatenregistriergerät</summary>
        [EnumMember(Value = "MESSDATENREGISTRIERGERAET")]
        MESSDATENREGISTRIERGERAET,

        /// <summary>elektronischer Haushaltszähler</summary>
        [EnumMember(Value = "ELEKTRONISCHERHAUSHALTSZAEHLER")]
        ELEKTRONISCHERHAUSHALTSZAEHLER,

        /// <summary>Individuelle Abstimmung (Sonderausstattung)</summary>
        [EnumMember(Value = "SONDERAUSSTATTUNG")]
        SONDERAUSSTATTUNG,

        ///<summary>Wasserzähler</summary>
        [EnumMember(Value = "WASSERZAEHLER")]
        WASSERZAEHLER,
    }
}