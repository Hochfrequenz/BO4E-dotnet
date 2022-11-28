using BO4E.meta;

using System.Runtime.Serialization;

namespace BO4E.ENUM
{
    /// <summary>Profiltyp (temperaturabhängig / standardlastprofil)</summary>
    [NonOfficial(NonOfficialCategory.REGULATORY_REQUIREMENTS)]
    public enum Profiltyp
    {
        /// <summary>SLP/SEP</summary>
        [EnumMember(Value = "SLP_SEP")]
        SLP_SEP,

        /// <summary>TLP/TEP</summary>
        [EnumMember(Value = "TLP_TEP")]
        TLP_TEP,
    }
}