using BO4E.meta;

namespace BO4E.ENUM
{
    /// <summary>
    /// Der Sperrauftragsstatus beschreibt den Status eines <see cref="BO.Auftrag"/>s
    /// </summary>
    /// <remarks>Diese Information kann in der EDIFACT-Nachricht des Typs 21039/21040 bzw. 19128 verwendet werden</remarks>
    [NonOfficial(NonOfficialCategory.REGULATORY_REQUIREMENTS)]
    public enum Sperrauftragsstatus
    {
        /// <summary>
        /// Der Auftrag wurde erfolgreich bearbeitet
        /// </summary>
        /// <remarks>EDIFACT DE4405: Z14</remarks>
        ERFOLGREICH,

        /// <summary>
        /// Der Auftrag wurde abgelehnt
        /// </summary>
        /// <remarks>EDIFACT DE4405: Z32</remarks>
        ABGELEHNT,

        /// <summary>
        /// Der Auftrag ist gescheitert
        /// </summary>
        /// <remarks>EDIFACT DE4405: Z13</remarks>
        GESCHEITERT,

        /// <summary>
        /// Die (Ent)sperrung ist geplant
        /// </summary>
        /// <remarks>EDIFACT DE4405: Z17</remarks>
        GEPLANT,

        /// <summary>
        /// Die (Ent)sperrung wurde zugestimmmt (aber noch nicht durchgeführt)
        /// </summary>
        /// <remarks>EDIFACT DE4405: Z30</remarks>
        ZUGESTIMMT,
        
        /// <summary>
        /// Die (Ent)sperrung wurde (durch den Lieferanten) storniert
        /// </summary>
        /// <remarks>Prüfidentifikator 19128</remarks>
        STORNIERT,
    }
}
