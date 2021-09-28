using BO4E.meta;

namespace BO4E.ENUM
{
    /// <summary>Profiltyp (temperaturabhängig / standardlastprofil)</summary>
    [NonOfficial(NonOfficialCategory.REGULATORY_REQUIREMENTS)]
    public enum Profiltyp
    {
        /// <summary>SLP/SEP</summary>
        SLP_SEP,

        /// <summary>TLP/TEP</summary>
        TLP_TEP
    }
}