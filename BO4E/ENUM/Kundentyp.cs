using System.Runtime.Serialization;
using ProtoBuf;

namespace BO4E.ENUM;

/// <summary> </summary>
public enum Kundentyp
{
    /// <summary>Privatkunden</summary>
    [ProtoEnum(Name = nameof(Kundentyp) + "_" + nameof(PRIVAT))]
    [EnumMember(Value = "PRIVAT")]
    PRIVAT,

    /// <summary>Landwirte</summary>
    [ProtoEnum(Name = nameof(Kundentyp) + "_" + nameof(LANDWIRT))]
    [EnumMember(Value = "LANDWIRT")]
    LANDWIRT,

    /// <summary>Sonstige Endkunden</summary>
    [ProtoEnum(Name = nameof(Kundentyp) + "_" + nameof(SONSTIGE))]
    [EnumMember(Value = "SONSTIGE")]
    SONSTIGE,

    /// <summary>Haushaltskunden</summary>
    [ProtoEnum(Name = nameof(Kundentyp) + "_" + nameof(HAUSHALT))]
    [EnumMember(Value = "HAUSHALT")]
    HAUSHALT,

    /// <summary>Direktheizungen</summary>
    [ProtoEnum(Name = nameof(Kundentyp) + "_" + nameof(DIREKTHEIZUNG))]
    [EnumMember(Value = "DIREKTHEIZUNG")]
    DIREKTHEIZUNG,

    /// <summary>Gemeinschaftseinrichtungen von MFH</summary>
    [ProtoEnum(Name = nameof(Kundentyp) + "_" + nameof(GEMEINSCHAFT_MFH))]
    [EnumMember(Value = "GEMEINSCHAFT_MFH")]
    GEMEINSCHAFT_MFH,

    /// <summary>Kirchen und caritative Einrichtungen</summary>
    [ProtoEnum(Name = nameof(Kundentyp) + "_" + nameof(KIRCHE))]
    [EnumMember(Value = "KIRCHE")]
    KIRCHE,

    /// <summary>KWK-Anlagen</summary>
    [ProtoEnum(Name = nameof(Kundentyp) + "_" + nameof(KWK))]
    [EnumMember(Value = "KWK")]
    KWK,

    /// <summary>Ladesäulen</summary>
    [ProtoEnum(Name = nameof(Kundentyp) + "_" + nameof(LADESAEULE))]
    [EnumMember(Value = "LADESAEULE")]
    LADESAEULE,

    /// <summary>Öffentliche Beleuchtungen</summary>
    [ProtoEnum(Name = nameof(Kundentyp) + "_" + nameof(BELEUCHTUNG_OEFFENTLICH))]
    [EnumMember(Value = "BELEUCHTUNG_OEFFENTLICH")]
    BELEUCHTUNG_OEFFENTLICH,

    /// <summary>Straßenbeleuchtungen</summary>
    [ProtoEnum(Name = nameof(Kundentyp) + "_" + nameof(BELEUCHTUNG_STRASSE))]
    [EnumMember(Value = "BELEUCHTUNG_STRASSE")]
    BELEUCHTUNG_STRASSE,

    /// <summary>Speicherheizungen</summary>
    [ProtoEnum(Name = nameof(Kundentyp) + "_" + nameof(SPEICHERHEIZUNG))]
    [EnumMember(Value = "SPEICHERHEIZUNG")]
    SPEICHERHEIZUNG,

    /// <summary>Unterbrechbare Verbrauchseinrichtungen</summary>
    [ProtoEnum(Name = nameof(Kundentyp) + "_" + nameof(UNTERBR_EINRICHTUNG))]
    [EnumMember(Value = "UNTERBR_EINRICHTUNG")]
    UNTERBR_EINRICHTUNG,

    /// <summary>Wärmepumpen</summary>
    [ProtoEnum(Name = nameof(Kundentyp) + "_" + nameof(WAERMEPUMPE))]
    [EnumMember(Value = "WAERMEPUMPE")]
    WAERMEPUMPE,
}
