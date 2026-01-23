#nullable enable
using System.Runtime.Serialization;
using ProtoBuf;

namespace BO4E.ENUM;

/// <summary>Auflistung möglicher Geraetearten. This is more broadly defined as a <see cref="Geraetetyp"/>, so a Zaehleinrichtung as Gerateart could be a elektronischer Haushaltszähler as a Gerätetyp.</summary>
public enum Geraeteart
{
    /// <summary>Wandler</summary>
    [ProtoEnum(Name = nameof(Geraeteart) + "_" + nameof(WANDLER))]
    [EnumMember(Value = "WANDLER")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("WANDLER")]
    WANDLER,

    /// <summary>Kommunikationseinrichtung</summary>
    [ProtoEnum(Name = nameof(Geraeteart) + "_" + nameof(KOMMUNIKATIONSEINRICHTUNG))]
    [EnumMember(Value = "KOMMUNIKATIONSEINRICHTUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("KOMMUNIKATIONSEINRICHTUNG")]
    KOMMUNIKATIONSEINRICHTUNG,

    /// <summary>Technische Steuereinrichtung</summary>
    [ProtoEnum(Name = nameof(Geraeteart) + "_" + nameof(TECHNISCHE_STEUEREINRICHTUNG))]
    [EnumMember(Value = "TECHNISCHE_STEUEREINRICHTUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("TECHNISCHE_STEUEREINRICHTUNG")]
    TECHNISCHE_STEUEREINRICHTUNG,

    /// <summary>Mengenumwerter</summary>
    [ProtoEnum(Name = nameof(Geraeteart) + "_" + nameof(MENGENUMWERTER))]
    [EnumMember(Value = "MENGENUMWERTER")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MENGENUMWERTER")]
    MENGENUMWERTER,

    /// <summary>Smartmeter-Gateway</summary>
    [ProtoEnum(Name = nameof(Geraeteart) + "_" + nameof(SMARTMETER_GATEWAY))]
    [EnumMember(Value = "SMARTMETER_GATEWAY")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SMARTMETER_GATEWAY")]
    SMARTMETER_GATEWAY,

    /// <summary>Steuerbox</summary>
    [ProtoEnum(Name = nameof(Geraeteart) + "_" + nameof(STEUERBOX))]
    [EnumMember(Value = "STEUERBOX")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("STEUERBOX")]
    STEUERBOX,

    /// <summary>Zaehleinrichtung</summary>
    [ProtoEnum(Name = nameof(Geraeteart) + "_" + nameof(ZAEHLEINRICHTUNG))]
    [EnumMember(Value = "ZAEHLEINRICHTUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ZAEHLEINRICHTUNG")]
    ZAEHLEINRICHTUNG,
}
