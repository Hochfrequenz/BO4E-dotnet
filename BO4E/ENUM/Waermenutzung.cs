using System.Runtime.Serialization;
using ProtoBuf;

namespace BO4E.ENUM;

/// <summary>Stromverbrauchsart/Wärmenutzung Marktlokation</summary>
public enum Waermenutzung
{
    /// <summary>Z56: Speicherheizung</summary>
    [ProtoEnum(Name = nameof(Waermenutzung) + "_" + nameof(SPEICHERHEIZUNG))]
    [EnumMember(Value = "SPEICHERHEIZUNG")]
    SPEICHERHEIZUNG,

    /// <summary>Z57: Wärmepumpe</summary>
    [ProtoEnum(Name = nameof(Waermenutzung) + "_" + nameof(WAERMEPUMPE))]
    [EnumMember(Value = "WAERMEPUMPE")]
    WAERMEPUMPE,

    /// <summary>Z61: Direktheizung</summary>
    [ProtoEnum(Name = nameof(Waermenutzung) + "_" + nameof(DIREKTHEIZUNG))]
    [EnumMember(Value = "DIREKTHEIZUNG")]
    DIREKTHEIZUNG,

    /// <summary>ZV5: Wärmepumpe (Wärme+Kälte)</summary>
    [ProtoEnum(Name = nameof(Waermenutzung) + "_" + nameof(WAERMEPUMPE_WAERME_KAELTE))]
    [EnumMember(Value = "WAERMEPUMPE_WAERME_KAELTE")]
    WAERMEPUMPE_WAERME_KAELTE,

    /// <summary>ZV6: Wärmepumpe (Kälte)</summary>
    [ProtoEnum(Name = nameof(Waermenutzung) + "_" + nameof(WAERMEPUMPE_KAELTE))]
    [EnumMember(Value = "WAERMEPUMPE_KAELTE")]
    WAERMEPUMPE_KAELTE,

    /// <summary>ZV7: Wärmepumpe (Wärme)</summary>
    [ProtoEnum(Name = nameof(Waermenutzung) + "_" + nameof(WAERMEPUMPE_WAERME))]
    [EnumMember(Value = "WAERMEPUMPE_WAERME")]
    WAERMEPUMPE_WAERME,
}
