namespace BO4E.ENUM
{
    /// <summary>Auflistung möglicher Netzebenen innerhalb der Energiearten Strom und Gas.</summary>
    public enum Netzebene
    {
        /// <summary>Niederspannung</summary>
        NSP,

        /// <summary>Mittelspannung</summary>
        MSP,

        /// <summary>Hochspannung</summary>
        HSP,

        /// <summary>Hoechstspannung</summary>
        HSS,

        /// <summary>MS/NS Umspannung</summary>
        MSP_NSP_UMSP,

        /// <summary>HS/MS Umspannung</summary>
        HSP_MSP_UMSP,

        /// <summary>HOES/HS Umspannung</summary>
        HSS_HSP_UMSP,

        /// <summary>Hochdruck</summary>
        HD,

        /// <summary>Mitteldruck</summary>
        MD,

        /// <summary>Niederdruck</summary>
        ND
    }
}