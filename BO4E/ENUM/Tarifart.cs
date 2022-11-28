using System.Runtime.Serialization;

namespace BO4E.ENUM
{
    /**
     * Die Tarifart wird verwendet zur Charakterisierung von Zählern und daraus
     * resultierenden Tarifen.
     */
    public enum Tarifart
    {
        /// <summary>Eintarif</summary>
        [EnumMember(Value = "EINTARIF")]
        EINTARIF,

        /// <summary>Zweitarif</summary>
        [EnumMember(Value = "ZWEITARIF")]
        ZWEITARIF,

        /// <summary>Mehrtarif</summary>
        [EnumMember(Value = "MEHRTARIF")]
        MEHRTARIF,

        /// <summary>Smart Meter Tarif</summary>
        [EnumMember(Value = "SMART_METER")]
        SMART_METER,

        /// <summary>Leistungsgemessener Tarif</summary>
        [EnumMember(Value = "LEISTUNGSGEMESSEN")]
        LEISTUNGSGEMESSEN,
    }
}