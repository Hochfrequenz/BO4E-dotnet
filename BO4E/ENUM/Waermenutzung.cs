using ProtoBuf;

using System.Runtime.Serialization;

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
}
