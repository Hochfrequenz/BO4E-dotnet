using System.Runtime.Serialization;
using ProtoBuf;

namespace BO4E.ENUM;

/// <summary>Stromverbrauchsart/Wärmenutzung Marktlokation</summary>
public enum Waermenutzung
{
    /// <summary>Z56: Speicherheizung</summary>
    [ProtoEnum(Name = nameof(Waermenutzung) + "_" + nameof(SPEICHERHEIZUNG))]
    [EnumMember(Value = "SPEICHERHEIZUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SPEICHERHEIZUNG")]
    SPEICHERHEIZUNG,

    /// <summary>Z57: Wärmepumpe</summary>
    [ProtoEnum(Name = nameof(Waermenutzung) + "_" + nameof(WAERMEPUMPE))]
    [EnumMember(Value = "WAERMEPUMPE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("WAERMEPUMPE")]
    WAERMEPUMPE,

    /// <summary>Z61: Direktheizung</summary>
    [ProtoEnum(Name = nameof(Waermenutzung) + "_" + nameof(DIREKTHEIZUNG))]
    [EnumMember(Value = "DIREKTHEIZUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("DIREKTHEIZUNG")]
    DIREKTHEIZUNG,

    /// <summary>ZV5: Wärmepumpe (Wärme+Kälte)</summary>
    [ProtoEnum(Name = nameof(Waermenutzung) + "_" + nameof(WAERMEPUMPE_WAERME_KAELTE))]
    [EnumMember(Value = "WAERMEPUMPE_WAERME_KAELTE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("WAERMEPUMPE_WAERME_KAELTE")]
    WAERMEPUMPE_WAERME_KAELTE,

    /// <summary>ZV6: Wärmepumpe (Kälte)</summary>
    [ProtoEnum(Name = nameof(Waermenutzung) + "_" + nameof(WAERMEPUMPE_KAELTE))]
    [EnumMember(Value = "WAERMEPUMPE_KAELTE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("WAERMEPUMPE_KAELTE")]
    WAERMEPUMPE_KAELTE,

    /// <summary>ZV7: Wärmepumpe (Wärme)</summary>
    [ProtoEnum(Name = nameof(Waermenutzung) + "_" + nameof(WAERMEPUMPE_WAERME))]
    [EnumMember(Value = "WAERMEPUMPE_WAERME")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("WAERMEPUMPE_WAERME")]
    WAERMEPUMPE_WAERME,
}
