using BO4E.meta;

namespace BO4E.ENUM.EDI
{
    /// <summary>
    ///     Stromverbrauchsart/Unterbrechbarkeit Marktlokation
    ///     EDIFACT values of <see cref="Unterbrechbarkeit" />
    /// </summary>
    /// <author>Hochfrequenz Unternehmensberatung GmbH</author>
    public enum UnterbrechbarkeitEdi
    {
        /// <summary>Z62: unterbrechbare Verbrauchseinrichtung</summary>
        [Mapping(Unterbrechbarkeit.UV)] Unterbrechbare_Verbrauchseinrichtung,

        /// <summary>Z63: nicht unterbrechbare Verbrauchseinrichtung</summary>
        [Mapping(Unterbrechbarkeit.NUV)] Nicht_Unterbrechbare_Verbrauchseinrichtung
    }
}