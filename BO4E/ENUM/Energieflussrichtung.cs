using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>
/// Die Energieflussrichtung gibt an, ob die gemessene Energie an der Messlokation zum Netz fließt(Erzeugung) oder vom Netz wegfließt(Verbrauch).
/// </summary>
public enum Energieflussrichtung
{
    /// <summary>
    /// Z71: Verbrauch
    /// </summary>
    [EnumMember(Value = "VERBRAUCH")]
    VERBRAUCH,

    /// <summary>
    /// Z72: Erzeugung
    /// </summary>
    [EnumMember(Value = "ERZEUGUNG")]
    ERZEUGUNG,
}