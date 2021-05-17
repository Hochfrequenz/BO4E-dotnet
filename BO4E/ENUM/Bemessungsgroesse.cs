using ProtoBuf;

namespace BO4E.ENUM
{
    /// <summary>Zur Abbildung von Messgrössen und zur Verwendung in energiewirtschaftlichen Berechnungen.</summary>
    public enum Bemessungsgroesse
    {
        /// <summary>elektrische Wirkarbeit</summary>
        [ProtoEnum(Name = nameof(Bemessungsgroesse) + "_" + nameof(WIRKARBEIT_EL))]
        WIRKARBEIT_EL,

        /// <summary>elektrische Leistung</summary>
        [ProtoEnum(Name = nameof(Bemessungsgroesse) + "_" + nameof(LEISTUNG_EL))]
        LEISTUNG_EL,

        /// <summary>Blindarbeit kapazitiv</summary>
        [ProtoEnum(Name = nameof(Bemessungsgroesse) + "_" + nameof(BLINDARBEIT_KAP))]
        BLINDARBEIT_KAP,

        /// <summary>Blindarbeit induktiv</summary>
        [ProtoEnum(Name = nameof(Bemessungsgroesse) + "_" + nameof(BLINDARBEIT_IND))]
        BLINDARBEIT_IND,

        /// <summary>Blindleistung kapazitiv</summary>
        [ProtoEnum(Name = nameof(Bemessungsgroesse) + "_" + nameof(BLINDLEISTUNG_KAP))]
        BLINDLEISTUNG_KAP,

        /// <summary>Blindleistung induktiv</summary>
        [ProtoEnum(Name = nameof(Bemessungsgroesse) + "_" + nameof(BLINDLEISTUNG_IND))]
        BLINDLEISTUNG_IND,

        /// <summary>thermische Wirkarbeit</summary>
        [ProtoEnum(Name = nameof(Bemessungsgroesse) + "_" + nameof(WIRKARBEIT_TH))]
        WIRKARBEIT_TH,

        /// <summary>thermische Leistung</summary>
        [ProtoEnum(Name = nameof(Bemessungsgroesse) + "_" + nameof(LEISTUNG_TH))]
        LEISTUNG_TH,

        /// <summary>Volumen</summary>
        [ProtoEnum(Name = nameof(Bemessungsgroesse) + "_" + nameof(VOLUMEN))]
        VOLUMEN,

        /// <summary>Volumenstrom (Volumen/Zeit)</summary>
        [ProtoEnum(Name = nameof(Bemessungsgroesse) + "_" + nameof(VOLUMENSTROM))]
        VOLUMENSTROM,

        /// <summary>Benutzungsdauer (Arbeit/Leistung)</summary>
        [ProtoEnum(Name = nameof(Bemessungsgroesse) + "_" + nameof(BENUTZUNGSDAUER))]
        BENUTZUNGSDAUER,

        /// <summary>Darstellung einer Stückzahl</summary>
        [ProtoEnum(Name = nameof(Bemessungsgroesse) + "_" + nameof(ANZAHL))]
        ANZAHL
    }
}