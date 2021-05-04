using BO4E.meta;

namespace BO4E.ENUM.EDI
{
    /// <summary>
    ///     EDIFACT values of <see cref="Netzebene" />
    /// </summary>
    public enum NetzebeneEdi
    {
        /// <summary>Höchstspannung</summary>
        [Mapping(Netzebene.HSS)] E03,

        /// <summary>Hochspannung</summary>
        [Mapping(Netzebene.HSP)] E04,

        /// <summary>Mittelspannung</summary>
        [Mapping(Netzebene.MSP)] E05,

        /// <summary>Niederspannung</summary>
        [Mapping(Netzebene.NSP)] E06,

        /// <summary>Nös/HS Umspannung</summary>
        [Mapping(Netzebene.HSS_HSP_UMSP)] E07,

        /// <summary>HS/MS Umspannung</summary>
        [Mapping(Netzebene.HSP_MSP_UMSP)] E08,

        /// <summary>MS/NS Umspannung</summary>
        [Mapping(Netzebene.MSP_NSP_UMSP)] E09,

        /// <summary>Hochdruck</summary>
        [Mapping(Netzebene.HD)] Y01,

        /// <summary>Mitteldruck</summary>
        [Mapping(Netzebene.MD)] Y02,

        /// <summary>Niederdruck</summary>
        [Mapping(Netzebene.ND)] Y03
    }
}