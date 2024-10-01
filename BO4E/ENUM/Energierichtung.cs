using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Spezifiziert die Energierichtung einer Markt- und/oder Messlokation.</summary>
public enum Energierichtung
{
    /// <summary>Ausspeisung</summary>
    /// <remarks>UTILTS DE7037 Z07: Verbrauch</remarks>
    [EnumMember(Value = "AUSSP")]
    AUSSP,

    /// <summary>Einspeisung</summary>
    /// <remarks>UTILTS DE7037 Z06: Erzeugung</remarks>
    [EnumMember(Value = "EINSP")]
    EINSP,

    /// <summary>Ruhende Lokation (in einer Kundenanlage)</summary>
    [EnumMember(Value = "RUHEND")]
    RUHEND,
}
