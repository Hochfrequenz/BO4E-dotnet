using BO4E.meta;

namespace BO4E.ENUM.EDI
{
    /// <summary>
    /// EDIFACT values of <see cref="BDEWArtikelnummer"/>
    /// </summary>
    /// <author>Hochfrequenz Unternehmensberatung GmbH</author>
    public enum BDEWArtikelnummerEdi
    {
        /// <inheritdoc cref="BDEWArtikelnummer.LEISTUNG"/>
        [Mapping(BDEWArtikelnummer.LEISTUNG)]
        _9990001000053,

        /// <inheritdoc cref="BDEWArtikelnummer.LEISTUNG_PAUSCHAL"/>
        [Mapping(BDEWArtikelnummer.LEISTUNG_PAUSCHAL)]
        _9990001000079,

        /// <inheritdoc cref="BDEWArtikelnummer.GRUNDPREIS"/>
        [Mapping(BDEWArtikelnummer.GRUNDPREIS)]
        _9990001000087,

        /// <inheritdoc cref="BDEWArtikelnummer.REGELENERGIE_ARBEIT"/>
        [Mapping(BDEWArtikelnummer.REGELENERGIE_ARBEIT)]
        _9990001000128,

        /// <inheritdoc cref="BDEWArtikelnummer.REGELENERGIE_LEISTUNG"/>
        [Mapping(BDEWArtikelnummer.REGELENERGIE_LEISTUNG)]
        _9990001000136,

        /// <inheritdoc cref="BDEWArtikelnummer.NOTSTROMLIEFERUNG_ARBEIT"/>
        [Mapping(BDEWArtikelnummer.NOTSTROMLIEFERUNG_ARBEIT)]
        _9990001000144,

        /// <inheritdoc cref="BDEWArtikelnummer.NOTSTROMLIEFERUNG_LEISTUNG"/>
        [Mapping(BDEWArtikelnummer.NOTSTROMLIEFERUNG_LEISTUNG)]
        _9990001000152,

        /// <inheritdoc cref="BDEWArtikelnummer.RESERVENETZKAPAZITAET"/>
        [Mapping(BDEWArtikelnummer.RESERVENETZKAPAZITAET)]
        _9990001000160,

        /// <inheritdoc cref="BDEWArtikelnummer.RESERVELEISTUNG"/>
        [Mapping(BDEWArtikelnummer.RESERVELEISTUNG)]
        _9990001000178,

        /// <inheritdoc cref="BDEWArtikelnummer.ZUSAETZLICHE_ABLESUNG"/>
        [Mapping(BDEWArtikelnummer.ZUSAETZLICHE_ABLESUNG)]
        _9990001000186,

        /// <inheritdoc cref="BDEWArtikelnummer.PRUEFGEBUEHREN_AUSSERPLANMAESSIG"/>
        [Mapping(BDEWArtikelnummer.PRUEFGEBUEHREN_AUSSERPLANMAESSIG)]
        _9990001000219,

        /// <inheritdoc cref="BDEWArtikelnummer.WIRKARBEIT"/>
        [Mapping(BDEWArtikelnummer.WIRKARBEIT)]
        _9990001000269,

        /// <inheritdoc cref="BDEWArtikelnummer.SINGULAER_GENUTZTE_BETRIEBSMITTEL"/>
        [Mapping(BDEWArtikelnummer.SINGULAER_GENUTZTE_BETRIEBSMITTEL)]
        _9990001000285,

        /// <inheritdoc cref="BDEWArtikelnummer.ABGABE_KWKG"/>
        [Mapping(BDEWArtikelnummer.ABGABE_KWKG)]
        _9990001000334,

        /// <inheritdoc cref="BDEWArtikelnummer.ABSCHLAG"/>
        [Mapping(BDEWArtikelnummer.ABSCHLAG)]
        _9990001000376,

        /// <inheritdoc cref="BDEWArtikelnummer.KONZESSIONSABGABE"/>
        [Mapping(BDEWArtikelnummer.KONZESSIONSABGABE)]
        _9990001000417,

        /// <inheritdoc cref="BDEWArtikelnummer.ENTGELT_FERNAUSLESUNG"/>
        [Mapping(BDEWArtikelnummer.ENTGELT_FERNAUSLESUNG)]
        _9990001000433,

        /// <inheritdoc cref="BDEWArtikelnummer.UNTERMESSUNG"/>
        [Mapping(BDEWArtikelnummer.UNTERMESSUNG)]
        _9990001000475,

        /// <inheritdoc cref="BDEWArtikelnummer.BLINDMEHRARBEIT"/>
        [Mapping(BDEWArtikelnummer.BLINDMEHRARBEIT)]
        _9990001000508,

        /// <inheritdoc cref="BDEWArtikelnummer.ENTGELT_ABRECHNUNG"/>
        [Mapping(BDEWArtikelnummer.ENTGELT_ABRECHNUNG)]
        _9990001000532,

        /// <inheritdoc cref="BDEWArtikelnummer.SPERRKOSTEN"/>
        [Mapping(BDEWArtikelnummer.SPERRKOSTEN)]
        _9990001000540,

        /// <inheritdoc cref="BDEWArtikelnummer.ENTSPERRKOSTEN"/>
        [Mapping(BDEWArtikelnummer.ENTSPERRKOSTEN)]
        _9990001000558,

        /// <inheritdoc cref="BDEWArtikelnummer.MAHNKOSTEN"/>
        [Mapping(BDEWArtikelnummer.MAHNKOSTEN)]
        _9990001000566,

        /// <inheritdoc cref="BDEWArtikelnummer.MEHR_MINDERMENGEN"/>
        [Mapping(BDEWArtikelnummer.MEHR_MINDERMENGEN)]
        _9990001000574,

        /// <inheritdoc cref="BDEWArtikelnummer.INKASSOKOSTEN"/>
        [Mapping(BDEWArtikelnummer.INKASSOKOSTEN)]
        _9990001000582,

        /// <inheritdoc cref="BDEWArtikelnummer.BLINDMEHRLEISTUNG"/>
        [Mapping(BDEWArtikelnummer.BLINDMEHRLEISTUNG)]
        _9990001000590,

        /// <inheritdoc cref="BDEWArtikelnummer.ENTGELT_MESSUNG_ABLESUNG"/>
        [Mapping(BDEWArtikelnummer.ENTGELT_MESSUNG_ABLESUNG)]
        _9990001000615,

        /// <inheritdoc cref="BDEWArtikelnummer.ENTGELT_EINBAU_BETRIEB_WARTUNG_MESSTECHNIK"/>
        [Mapping(BDEWArtikelnummer.ENTGELT_EINBAU_BETRIEB_WARTUNG_MESSTECHNIK)]
        _9990001000623,

        /// <inheritdoc cref="BDEWArtikelnummer.AUSGLEICHSENERGIE"/>
        [Mapping(BDEWArtikelnummer.AUSGLEICHSENERGIE)]
        _9990001000631,

        /// <inheritdoc cref="BDEWArtikelnummer.ZAEHLEINRICHTUNG"/>
        [Mapping(BDEWArtikelnummer.ZAEHLEINRICHTUNG)]
        _9990001000649,

        /// <inheritdoc cref="BDEWArtikelnummer.WANDLER_MENGENUMWERTER"/>
        [Mapping(BDEWArtikelnummer.WANDLER_MENGENUMWERTER)]
        _9990001000657,

        /// <inheritdoc cref="BDEWArtikelnummer.KOMMUNIKATIONSEINRICHTUNG"/>
        [Mapping(BDEWArtikelnummer.KOMMUNIKATIONSEINRICHTUNG)]
        _9990001000665,

        /// <inheritdoc cref="BDEWArtikelnummer.TECHNISCHE_STEUEREINRICHTUNG"/>
        [Mapping(BDEWArtikelnummer.TECHNISCHE_STEUEREINRICHTUNG)]
        _9990001000673,

        /// <inheritdoc cref="BDEWArtikelnummer.PARAGRAF_19_STROM_NEV_UMLAGE"/>
        [Mapping(BDEWArtikelnummer.PARAGRAF_19_STROM_NEV_UMLAGE)]
        _9990001000681,

        /// <inheritdoc cref="BDEWArtikelnummer.BEFESTIGUNGSEINRICHTUNG"/>
        [Mapping(BDEWArtikelnummer.BEFESTIGUNGSEINRICHTUNG)]
        _9990001000699,

        /// <inheritdoc cref="BDEWArtikelnummer.OFFSHORE_HAFTUNGSUMLAGE"/>
        [Mapping(BDEWArtikelnummer.OFFSHORE_HAFTUNGSUMLAGE)]
        _9990001000706,

        /// <inheritdoc cref="BDEWArtikelnummer.FIXE_ARBEITSENTGELTKOMPONENTE"/>
        [Mapping(BDEWArtikelnummer.FIXE_ARBEITSENTGELTKOMPONENTE)]
        _9990001000714,

        /// <inheritdoc cref="BDEWArtikelnummer.FIXE_LEISTUNGSENTGELTKOMPONENTE"/>
        [Mapping(BDEWArtikelnummer.FIXE_LEISTUNGSENTGELTKOMPONENTE)]
        _9990001000722,

        /// <inheritdoc cref="BDEWArtikelnummer.UMLAGE_ABSCHALTBARE_LASTEN"/>
        [Mapping(BDEWArtikelnummer.UMLAGE_ABSCHALTBARE_LASTEN)]
        _9990001000730,

        /// <inheritdoc cref="BDEWArtikelnummer.MEHRMENGE"/>
        [Mapping(BDEWArtikelnummer.MEHRMENGE)]
        _9990001000748,

        /// <inheritdoc cref="BDEWArtikelnummer.MINDERMENGE"/>
        [Mapping(BDEWArtikelnummer.MINDERMENGE)]
        _9990001000756,

        /// <inheritdoc cref="BDEWArtikelnummer.ENERGIESTEUER"/>
        [Mapping(BDEWArtikelnummer.ENERGIESTEUER)]
        _9990001000764,

        /// <inheritdoc cref="BDEWArtikelnummer.SMARTMETER_GATEWAY"/>
        [Mapping(BDEWArtikelnummer.SMARTMETER_GATEWAY)]
        _9990001000772,

        /// <inheritdoc cref="BDEWArtikelnummer.STEUERBOX"/>
        [Mapping(BDEWArtikelnummer.STEUERBOX)]
        _9990001000780,

        /// <inheritdoc cref="BDEWArtikelnummer.MSB_INKL_MESSUNG"/>
        [Mapping(BDEWArtikelnummer.MSB_INKL_MESSUNG)]
        _9990001000798
    }
}