using System.Runtime.Serialization;

namespace BO4E.ENUM
{
    /// <summary>Abbildung verschiedener Rufnummerntypen.</summary>
    public enum Rufnummernart
    {
        /// <summary>Rufnummer Zentrale</summary>
        [EnumMember(Value = "RUF_ZENTRALE")] 
        RUF_ZENTRALE,

        /// <summary>Faxnummer Zentrale</summary>
        [EnumMember(Value = "FAX_ZENTRALE")] 
        FAX_ZENTRALE,

        /// <summary>Sammelrufnummer</summary>
        [EnumMember(Value = "SAMMELRUF")] 
        SAMMELRUF,

        /// <summary>Sammelfaxnummer</summary>
        [EnumMember(Value = "SAMMELFAX")] 
        SAMMELFAX,

        /// <summary>Rufnummer Abteilung</summary>
        [EnumMember(Value = "ABTEILUNGRUF")] 
        ABTEILUNGRUF,

        /// <summary>Faxnummer Abteilung</summary>
        [EnumMember(Value = "ABTEILUNGFAX")] 
        ABTEILUNGFAX,

        /// <summary>Rufnummer Durchwahl</summary>
        [EnumMember(Value = "RUF_DURCHWAHL")] 
        RUF_DURCHWAHL,

        /// <summary>Faxnummer Durchwahl</summary>
        [EnumMember(Value = "FAX_DURCHWAHL")] 
        FAX_DURCHWAHL,

        /// <summary>Nummer des mobilen Telefons</summary>
        [EnumMember(Value = "MOBIL_NUMMER")] 
        MOBIL_NUMMER,
    }
}