using ProtoBuf;

namespace BO4E.ENUM
{
    /// <summary> </summary>
    public enum Kundentyp
    {
        /// <summary>Privatkunden</summary>
        [ProtoEnum(Name = nameof(Kundentyp) + "_" + nameof(PRIVAT))]
        PRIVAT,

        /// <summary>Landwirte</summary>
        [ProtoEnum(Name = nameof(Kundentyp) + "_" + nameof(LANDWIRT))]
        LANDWIRT,

        /// <summary>Sonstige Endkunden</summary>
        [ProtoEnum(Name = nameof(Kundentyp) + "_" + nameof(SONSTIGE))]
        SONSTIGE,

        /// <summary>Haushaltskunden</summary>
        [ProtoEnum(Name = nameof(Kundentyp) + "_" + nameof(HAUSHALT))]
        HAUSHALT,

        /// <summary>Direktheizungen</summary>
        [ProtoEnum(Name = nameof(Kundentyp) + "_" + nameof(DIREKTHEIZUNG))]
        DIREKTHEIZUNG,

        /// <summary>Gemeinschaftseinrichtungen von MFH</summary>
        [ProtoEnum(Name = nameof(Kundentyp) + "_" + nameof(GEMEINSCHAFT_MFH))]
        GEMEINSCHAFT_MFH,

        /// <summary>Kirchen und caritative Einrichtungen</summary>
        [ProtoEnum(Name = nameof(Kundentyp) + "_" + nameof(KIRCHE))]
        KIRCHE,

        /// <summary>KWK-Anlagen</summary>
        [ProtoEnum(Name = nameof(Kundentyp) + "_" + nameof(KWK))]
        KWK,

        /// <summary>Ladesäulen</summary>
        [ProtoEnum(Name = nameof(Kundentyp) + "_" + nameof(LADESAEULE))]
        LADESAEULE,

        /// <summary>Öffentliche Beleuchtungen</summary>
        [ProtoEnum(Name = nameof(Kundentyp) + "_" + nameof(BELEUCHTUNG_OEFFENTLICH))]
        BELEUCHTUNG_OEFFENTLICH,

        /// <summary>Straßenbeleuchtungen</summary>
        [ProtoEnum(Name = nameof(Kundentyp) + "_" + nameof(BELEUCHTUNG_STRASSE))]
        BELEUCHTUNG_STRASSE,

        /// <summary>Speicherheizungen</summary>
        [ProtoEnum(Name = nameof(Kundentyp) + "_" + nameof(SPEICHERHEIZUNG))]
        SPEICHERHEIZUNG,

        /// <summary>Unterbrechbare Verbrauchseinrichtungen</summary>
        [ProtoEnum(Name = nameof(Kundentyp) + "_" + nameof(UNTERBR_EINRICHTUNG))]
        UNTERBR_EINRICHTUNG,

        /// <summary>Wärmepumpen</summary>
        [ProtoEnum(Name = nameof(Kundentyp) + "_" + nameof(WAERMEPUMPE))]
        WAERMEPUMPE
    }
}