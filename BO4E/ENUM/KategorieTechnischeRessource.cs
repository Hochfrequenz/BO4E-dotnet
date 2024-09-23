using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Kategorisierung der technischen Ressource in Hinblick auf §14a EnWG.</summary>
public enum KategorieTechnischeRessource
{
    /// <summary>ZG8: Technischen Ressource fällt unter § 14a EnWG</summary>
    [EnumMember(Value = "FAELLT_UNTER_14A")]
    FAELLT_UNTER_14A,

    /// <summary>ZG9: Technischen Ressource fällt nicht unter § 14a EnWG</summary>
    [EnumMember(Value = "FAELLT_NICHT_UNTER_14A")]
    FAELLT_NICHT_UNTER_14A,
}
