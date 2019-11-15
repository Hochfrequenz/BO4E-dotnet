using BO4E.meta;

namespace BO4E.ENUM.EDI
{
    /// <summary>
    /// EDIFACT values of <see cref="Energierichtung"/>
    /// </summary>
    public enum EnergierichtungEdi
    {
        /// <summary>Erzeugung</summary>
        [Mapping(Energierichtung.EINSP)]
        Z06,
        /// <summary>Verbrauch</summary>
        [Mapping(Energierichtung.AUSSP)]
        Z07
    }
}
