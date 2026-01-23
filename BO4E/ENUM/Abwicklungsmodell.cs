using System.Runtime.Serialization;
using BO4E.meta;

namespace BO4E.ENUM;

/// <summary>Abwicklungsmodell (E-Mob) </summary>
[NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
public enum Abwicklungsmodell
{
    /// <summary>Modell 1 "Bilanzierung an der Marktlokation" </summary>
    /// <remarks>ZE9</remarks>
    [EnumMember(Value = "MODELL_1")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MODELL_1")]
    MODELL_1,

    /// <summary>Modell 2 "Bilanzierung im Bilanzierungsgebiet (BG) des LPB" </summary>
    /// <remarks>ZF0</remarks>
    [EnumMember(Value = "MODELL_2")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MODELL_2")]
    MODELL_2,
}
