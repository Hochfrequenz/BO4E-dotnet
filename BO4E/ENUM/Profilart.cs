using BO4E.meta;

namespace BO4E.ENUM
{
    /// <summary>Profilart (temperaturabhängig / standardlastprofil)</summary>
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    public enum Profilart
    {
        /// <summary>ART_STANDARDLASTPROFIL</summary>
        /// <remarks>Z02</remarks>
        ART_STANDARDLASTPROFIL,

        /// <summary>ART_TAGESPARAMETERABHAENGIGES_LASTPROFIL</summary>
        /// <remarks>Z03</remarks>
        ART_TAGESPARAMETERABHAENGIGES_LASTPROFIL,

        /// <summary>ART_LASTPROFIL</summary>
        /// <remarks>Z12</remarks>
        ART_LASTPROFIL
    }
}