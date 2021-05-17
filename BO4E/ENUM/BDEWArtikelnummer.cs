using ProtoBuf;

namespace BO4E.ENUM
{
    /// <summary>BDEWArtikelnummer</summary>
    public enum BDEWArtikelnummer
    {
        /// <summary>9990001000053</summary>
        [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(LEISTUNG))]
        LEISTUNG,

        /// <summary>9990001000079</summary>
        [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(LEISTUNG_PAUSCHAL))]
        LEISTUNG_PAUSCHAL,

        /// <summary>9990001000087</summary>
        [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(GRUNDPREIS))]
        GRUNDPREIS,

        /// <summary>9990001000128</summary>
        [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(REGELENERGIE_ARBEIT))]
        REGELENERGIE_ARBEIT,

        /// <summary>9990001000136</summary>
        [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(REGELENERGIE_LEISTUNG))]
        REGELENERGIE_LEISTUNG,

        /// <summary>9990001000144</summary>
        [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(NOTSTROMLIEFERUNG_ARBEIT))]
        NOTSTROMLIEFERUNG_ARBEIT,

        /// <summary>9990001000152</summary>
        [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(NOTSTROMLIEFERUNG_LEISTUNG))]
        NOTSTROMLIEFERUNG_LEISTUNG,

        /// <summary>9990001000160</summary>
        [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(RESERVENETZKAPAZITAET))]
        RESERVENETZKAPAZITAET,

        /// <summary>9990001000178</summary>
        [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(RESERVELEISTUNG))]
        RESERVELEISTUNG,

        /// <summary>9990001000186</summary>
        [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(ZUSAETZLICHE_ABLESUNG))]
        ZUSAETZLICHE_ABLESUNG,

        /// <summary>9990001000219</summary>
        [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(PRUEFGEBUEHREN_AUSSERPLANMAESSIG))]
        PRUEFGEBUEHREN_AUSSERPLANMAESSIG,

        /// <summary>9990001000269</summary>
        [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(WIRKARBEIT))]
        WIRKARBEIT,

        /// <summary>9990001000285</summary>
        [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(SINGULAER_GENUTZTE_BETRIEBSMITTEL))]
        SINGULAER_GENUTZTE_BETRIEBSMITTEL,

        /// <summary>9990001000334</summary>
        [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(ABGABE_KWKG))]
        ABGABE_KWKG,

        /// <summary>9990001000376</summary>
        [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(ABSCHLAG))]
        ABSCHLAG,

        /// <summary>9990001000417</summary>
        [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(KONZESSIONSABGABE))]
        KONZESSIONSABGABE,

        /// <summary>9990001000433</summary>
        [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(ENTGELT_FERNAUSLESUNG))]
        ENTGELT_FERNAUSLESUNG,

        /// <summary>9990001000475</summary>
        [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(UNTERMESSUNG))]
        UNTERMESSUNG,

        /// <summary>9990001000508</summary>
        [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(BLINDMEHRARBEIT))]
        BLINDMEHRARBEIT,

        /// <summary>9990001000532</summary>
        [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(ENTGELT_ABRECHNUNG))]
        ENTGELT_ABRECHNUNG,

        /// <summary>9990001000540</summary>
        [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(SPERRKOSTEN))]
        SPERRKOSTEN,

        /// <summary>9990001000558</summary>
        [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(ENTSPERRKOSTEN))]
        ENTSPERRKOSTEN,

        /// <summary>9990001000566</summary>
        [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(MAHNKOSTEN))]
        MAHNKOSTEN,

        /// <summary>9990001000574</summary>
        [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(MEHR_MINDERMENGEN))]
        MEHR_MINDERMENGEN,

        /// <summary>9990001000582</summary>
        [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(INKASSOKOSTEN))]
        INKASSOKOSTEN,

        /// <summary>9990001000590</summary>
        [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(BLINDMEHRLEISTUNG))]
        BLINDMEHRLEISTUNG,

        /// <summary>9990001000615</summary>
        [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(ENTGELT_MESSUNG_ABLESUNG))]
        ENTGELT_MESSUNG_ABLESUNG,

        /// <summary>9990001000623</summary>
        [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(ENTGELT_EINBAU_BETRIEB_WARTUNG_MESSTECHNIK))]
        ENTGELT_EINBAU_BETRIEB_WARTUNG_MESSTECHNIK,

        /// <summary>9990001000631</summary>
        [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(AUSGLEICHSENERGIE))]
        AUSGLEICHSENERGIE,

        /// <summary>9990001000649</summary>
        [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(ZAEHLEINRICHTUNG))]
        ZAEHLEINRICHTUNG,

        /// <summary>9990001000657</summary>
        [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(WANDLER_MENGENUMWERTER))]
        WANDLER_MENGENUMWERTER,

        /// <summary>9990001000665</summary>
        [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(KOMMUNIKATIONSEINRICHTUNG))]
        KOMMUNIKATIONSEINRICHTUNG,

        /// <summary>9990001000673</summary>
        [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(TECHNISCHE_STEUEREINRICHTUNG))]
        TECHNISCHE_STEUEREINRICHTUNG,

        /// <summary>9990001000681</summary>
        [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(PARAGRAF_19_STROM_NEV_UMLAGE))]
        PARAGRAF_19_STROM_NEV_UMLAGE,

        /// <summary>9990001000699</summary>
        [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(BEFESTIGUNGSEINRICHTUNG))]
        BEFESTIGUNGSEINRICHTUNG,

        /// <summary>9990001000706</summary>
        [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(OFFSHORE_HAFTUNGSUMLAGE))]
        OFFSHORE_HAFTUNGSUMLAGE,

        /// <summary>9990001000714</summary>
        [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(FIXE_ARBEITSENTGELTKOMPONENTE))]
        FIXE_ARBEITSENTGELTKOMPONENTE,

        /// <summary>9990001000722</summary>
        [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(FIXE_LEISTUNGSENTGELTKOMPONENTE))]
        FIXE_LEISTUNGSENTGELTKOMPONENTE,

        /// <summary>9990001000730</summary>
        [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(UMLAGE_ABSCHALTBARE_LASTEN))]
        UMLAGE_ABSCHALTBARE_LASTEN,

        /// <summary>9990001000748</summary>
        [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(MEHRMENGE))]
        MEHRMENGE,

        /// <summary>9990001000756</summary>
        [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(MINDERMENGE))]
        MINDERMENGE,

        /// <summary>9990001000764</summary>
        [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(ENERGIESTEUER))]
        ENERGIESTEUER,

        /// <summary>9990001000772</summary>
        [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(SMARTMETER_GATEWAY))]
        SMARTMETER_GATEWAY,

        /// <summary>9990001000780</summary>
        [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(STEUERBOX))]
        STEUERBOX,

        /// <summary>9990001000798</summary>
        [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(MSB_INKL_MESSUNG))]
        MSB_INKL_MESSUNG
    }
}