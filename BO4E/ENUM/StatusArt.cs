using System.Runtime.Serialization;
using BO4E.COM;
using BO4E.meta;

namespace BO4E.ENUM;

/// <summary>
/// Represents the Type of Wert (MSCONS SG10 STS 9015)
/// </summary>
/// <see cref="StatusZusatzInformation"/>
[NonOfficial(NonOfficialCategory.UNSPECIFIED)]
public enum StatusArt
{
    /// <summary> VERTRAG </summary>
    /// <remarks>6</remarks>
    [EnumMember(Value = "VERTRAG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("VERTRAG")]
    VERTRAG,

    /// <summary> MESSWERTQUALITAET </summary>
    /// <remarks>8</remarks>
    [EnumMember(Value = "MESSWERTQUALITAET")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MESSWERTQUALITAET")]
    MESSWERTQUALITAET,

    /// <summary> MESSKLASSIFIZIERUNG </summary>
    /// <remarks>10</remarks>
    [EnumMember(Value = "MESSKLASSIFIZIERUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MESSKLASSIFIZIERUNG")]
    MESSKLASSIFIZIERUNG,

    /// <summary> PLAUSIBILISIERUNGSHINWEIS </summary>
    /// <remarks>Z33</remarks>
    [EnumMember(Value = "PLAUSIBILISIERUNGSHINWEIS")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("PLAUSIBILISIERUNGSHINWEIS")]
    PLAUSIBILISIERUNGSHINWEIS,

    /// <summary> ERSATZWERTBILDUNGSVERFAHREN </summary>
    /// <remarks>Z32</remarks>
    [EnumMember(Value = "ERSATZWERTBILDUNGSVERFAHREN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ERSATZWERTBILDUNGSVERFAHREN")]
    ERSATZWERTBILDUNGSVERFAHREN,

    /// <summary> GRUND_ERSATZWERTBILDUNGSVERFAHREN </summary>
    /// <remarks>Z40</remarks>
    [EnumMember(Value = "GRUND_ERSATZWERTBILDUNGSVERFAHREN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GRUND_ERSATZWERTBILDUNGSVERFAHREN")]
    GRUND_ERSATZWERTBILDUNGSVERFAHREN,

    /// <summary> KORREKTURGRUND </summary>
    /// <remarks>Z34</remarks>
    [EnumMember(Value = "KORREKTURGRUND")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("KORREKTURGRUND")]
    KORREKTURGRUND,

    /// <summary> GASQUALITAET </summary>
    /// <remarks>Z31</remarks>
    [EnumMember(Value = "GASQUALITAET")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GASQUALITAET")]
    GASQUALITAET,
}
