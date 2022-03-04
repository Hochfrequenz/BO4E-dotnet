using BO4E.meta;

namespace BO4E.ENUM.EDI
{
    /// <summary>
    ///     EDIFACT values of <see cref="Wertermittlungsverfahren" />
    /// </summary>
    public enum WertermittlungsverfahrenEdi
    {
        /// <summary>
        ///     Abgelesener Wert (wahrer Wert, abrechnungsrelevant)
        /// </summary>
        [Mapping(Wertermittlungsverfahren.MESSUNG)]
        _220,

        /// <summary>
        ///     Ersatzwert - geschätzt, veranschlagt
        /// </summary>
        [Mapping(Wertermittlungsverfahren.PROGNOSE)]
        _67,

        /// <summary>
        ///     Vorschlagswert (nicht abrechnungsrelevant)
        /// </summary>
        _201,

        /// <summary>
        ///     Nicht verwendbarer Wert (nicht abrechnungsrelevant)
        /// </summary>
        _20
    }
}