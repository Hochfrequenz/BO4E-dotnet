#nullable enable
using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Im Falle der Speicher bei <see cref="TechnischeRessourceNutzung"/>, eine genauere Angabe über die Art der Speicher zu definieren.</summary>
public enum Speicherart
{
    /// <summary>ZF7: Wasserstoffspeicher</summary>
    [EnumMember(Value = "WASSERSTOFFSPEICHER")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("WASSERSTOFFSPEICHER")]
    WASSERSTOFFSPEICHER,

    /// <summary>ZF8: Pumpspeicher</summary>
    [EnumMember(Value = "PUMPSPEICHER")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("PUMPSPEICHER")]
    PUMPSPEICHER,

    /// <summary>ZF9: Batteriespeicher</summary>
    [EnumMember(Value = "BATTERIESPEICHER")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BATTERIESPEICHER")]
    BATTERIESPEICHER,

    /// <summary>ZG6: Sonstige Speicherart</summary>
    [EnumMember(Value = "SONSTIGE_SPEICHERART")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SONSTIGE_SPEICHERART")]
    SONSTIGE_SPEICHERART,
}
