namespace BO4E.ENUM
{

    /// <summary>Zur Abbildung von Messgrössen und zur Verwendung in energiewirtschaftlichen Berechnungen.</summary>
    public enum Bemessungsgroesse
    {
        /// <summary>elektrische Wirkarbeit</summary>
        WIRKARBEIT_EL,
        /// <summary>elektrische Leistung</summary>
        LEISTUNG_EL,
        /// <summary>Blindarbeit kapazitiv</summary>
        BLINDARBEIT_KAP,
        /// <summary>Blindarbeit induktiv</summary>
        BLINDARBEIT_IND,
        /// <summary>Blindleistung kapazitiv</summary>
        BLINDLEISTUNG_KAP,
        /// <summary>Blindleistung induktiv</summary>
        BLINDLEISTUNG_IND,
        /// <summary>thermische Wirkarbeit</summary>
        WIRKARBEIT_TH,
        /// <summary>thermische Leistung</summary>
        LEISTUNG_TH,
        /// <summary>Volumen</summary>
        VOLUMEN,
        /// <summary>Volumenstrom (Volumen/Zeit)</summary>
        VOLUMENSTROM,
        /// <summary>Benutzungsdauer (Arbeit/Leistung)</summary>
        BENUTZUNGSDAUER,
        /// <summary>Darstellung einer Stückzahl</summary>
        ANZAHL
    }
}