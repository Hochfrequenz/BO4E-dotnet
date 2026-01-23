#nullable enable
using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Abbildung verschiedener Rufnummerntypen.</summary>
public enum Rufnummernart
{
    /// <summary>Rufnummer Zentrale</summary>
    [EnumMember(Value = "RUF_ZENTRALE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("RUF_ZENTRALE")]
    RUF_ZENTRALE,

    /// <summary>Faxnummer Zentrale</summary>
    [EnumMember(Value = "FAX_ZENTRALE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("FAX_ZENTRALE")]
    FAX_ZENTRALE,

    /// <summary>Sammelrufnummer</summary>
    [EnumMember(Value = "SAMMELRUF")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SAMMELRUF")]
    SAMMELRUF,

    /// <summary>Sammelfaxnummer</summary>
    [EnumMember(Value = "SAMMELFAX")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SAMMELFAX")]
    SAMMELFAX,

    /// <summary>Rufnummer Abteilung</summary>
    [EnumMember(Value = "ABTEILUNGRUF")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ABTEILUNGRUF")]
    ABTEILUNGRUF,

    /// <summary>Faxnummer Abteilung</summary>
    [EnumMember(Value = "ABTEILUNGFAX")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ABTEILUNGFAX")]
    ABTEILUNGFAX,

    /// <summary>Rufnummer Durchwahl</summary>
    [EnumMember(Value = "RUF_DURCHWAHL")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("RUF_DURCHWAHL")]
    RUF_DURCHWAHL,

    /// <summary>Faxnummer Durchwahl</summary>
    [EnumMember(Value = "FAX_DURCHWAHL")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("FAX_DURCHWAHL")]
    FAX_DURCHWAHL,

    /// <summary>Nummer des mobilen Telefons</summary>
    [EnumMember(Value = "MOBIL_NUMMER")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MOBIL_NUMMER")]
    MOBIL_NUMMER,
}
