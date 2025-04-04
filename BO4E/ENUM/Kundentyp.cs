using System.Runtime.Serialization;
using ProtoBuf;

namespace BO4E.ENUM;

/// <summary> </summary>
public enum Kundentyp
{
    /// <summary>Privatkunden</summary>
    [ProtoEnum(Name = nameof(Kundentyp) + "_" + nameof(PRIVAT))]
    [EnumMember(Value = "PRIVAT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("PRIVAT")]
    PRIVAT,

    /// <summary>Landwirte</summary>
    [ProtoEnum(Name = nameof(Kundentyp) + "_" + nameof(LANDWIRT))]
    [EnumMember(Value = "LANDWIRT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("LANDWIRT")]
    LANDWIRT,

    /// <summary>Sonstige Endkunden</summary>
    [ProtoEnum(Name = nameof(Kundentyp) + "_" + nameof(SONSTIGE))]
    [EnumMember(Value = "SONSTIGE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SONSTIGE")]
    SONSTIGE,

    /// <summary>Haushaltskunden</summary>
    [ProtoEnum(Name = nameof(Kundentyp) + "_" + nameof(HAUSHALT))]
    [EnumMember(Value = "HAUSHALT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("HAUSHALT")]
    HAUSHALT,

    /// <summary>Direktheizungen</summary>
    [ProtoEnum(Name = nameof(Kundentyp) + "_" + nameof(DIREKTHEIZUNG))]
    [EnumMember(Value = "DIREKTHEIZUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("DIREKTHEIZUNG")]
    DIREKTHEIZUNG,

    /// <summary>Gemeinschaftseinrichtungen von MFH</summary>
    [ProtoEnum(Name = nameof(Kundentyp) + "_" + nameof(GEMEINSCHAFT_MFH))]
    [EnumMember(Value = "GEMEINSCHAFT_MFH")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GEMEINSCHAFT_MFH")]
    GEMEINSCHAFT_MFH,

    /// <summary>Kirchen und caritative Einrichtungen</summary>
    [ProtoEnum(Name = nameof(Kundentyp) + "_" + nameof(KIRCHE))]
    [EnumMember(Value = "KIRCHE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("KIRCHE")]
    KIRCHE,

    /// <summary>KWK-Anlagen</summary>
    [ProtoEnum(Name = nameof(Kundentyp) + "_" + nameof(KWK))]
    [EnumMember(Value = "KWK")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("KWK")]
    KWK,

    /// <summary>Ladesäulen</summary>
    [ProtoEnum(Name = nameof(Kundentyp) + "_" + nameof(LADESAEULE))]
    [EnumMember(Value = "LADESAEULE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("LADESAEULE")]
    LADESAEULE,

    /// <summary>Öffentliche Beleuchtungen</summary>
    [ProtoEnum(Name = nameof(Kundentyp) + "_" + nameof(BELEUCHTUNG_OEFFENTLICH))]
    [EnumMember(Value = "BELEUCHTUNG_OEFFENTLICH")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BELEUCHTUNG_OEFFENTLICH")]
    BELEUCHTUNG_OEFFENTLICH,

    /// <summary>Straßenbeleuchtungen</summary>
    [ProtoEnum(Name = nameof(Kundentyp) + "_" + nameof(BELEUCHTUNG_STRASSE))]
    [EnumMember(Value = "BELEUCHTUNG_STRASSE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BELEUCHTUNG_STRASSE")]
    BELEUCHTUNG_STRASSE,

    /// <summary>Speicherheizungen</summary>
    [ProtoEnum(Name = nameof(Kundentyp) + "_" + nameof(SPEICHERHEIZUNG))]
    [EnumMember(Value = "SPEICHERHEIZUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SPEICHERHEIZUNG")]
    SPEICHERHEIZUNG,

    /// <summary>Unterbrechbare Verbrauchseinrichtungen</summary>
    [ProtoEnum(Name = nameof(Kundentyp) + "_" + nameof(UNTERBR_EINRICHTUNG))]
    [EnumMember(Value = "UNTERBR_EINRICHTUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("UNTERBR_EINRICHTUNG")]
    UNTERBR_EINRICHTUNG,

    /// <summary>Wärmepumpen</summary>
    [ProtoEnum(Name = nameof(Kundentyp) + "_" + nameof(WAERMEPUMPE))]
    [EnumMember(Value = "WAERMEPUMPE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("WAERMEPUMPE")]
    WAERMEPUMPE,
}
