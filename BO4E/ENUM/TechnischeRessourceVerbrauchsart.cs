using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Verbrauchsart der Technischen Ressource.</summary>
public enum TechnischeRessourceVerbrauchsart
{
    /// <summary>Z64: Kraft/Licht</summary>
    [EnumMember(Value = "KRAFT_LICHT")]
    KRAFT_LICHT,

    /// <summary>Z65: Wärme</summary>
    [EnumMember(Value = "WAERME")]
    WAERME,

    /// <summary>ZE5: E-Mobilität</summary>
    [EnumMember(Value = "E_MOBILITAET")]
    E_MOBILITAET,

    /// <summary>ZA8: Straßenbeleuchtung</summary>
    [EnumMember(Value = "STRASSENBELEUCHTUNG")]
    STRASSENBELEUCHTUNG,
}
