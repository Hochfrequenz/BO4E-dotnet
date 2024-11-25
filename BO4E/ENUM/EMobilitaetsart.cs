using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Im Falle der E-Mobilität bei <see cref="TechnischeRessourceNutzung"/>, eine genauere Angabe über die Art der E-Mobilität zu definieren.</summary>
public enum EMobilitaetsart
{
    /// <summary>ZE6: Wallbox</summary>
    [EnumMember(Value = "WALLBOX")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("WALLBOX")]
    WALLBOX,

    /// <summary>Z87: E-Mobilitätsladesäule</summary>
    [EnumMember(Value = "E_MOBILITAETSLADESAEULE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("E_MOBILITAETSLADESAEULE")]
    E_MOBILITAETSLADESAEULE,

    /// <summary>ZE7: Ladepark</summary>
    [EnumMember(Value = "LADEPARK")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("LADEPARK")]
    LADEPARK,
}
