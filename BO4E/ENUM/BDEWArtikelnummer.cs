using System.Runtime.Serialization;
using ProtoBuf;

namespace BO4E.ENUM;

/// <summary>BDEWArtikelnummer</summary>
public enum BDEWArtikelnummer
{
    /// <summary>9990001000053</summary>
    [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(LEISTUNG))]
    [EnumMember(Value = "LEISTUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("LEISTUNG")]
    LEISTUNG,

    /// <summary>9990001000079</summary>
    [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(LEISTUNG_PAUSCHAL))]
    [EnumMember(Value = "LEISTUNG_PAUSCHAL")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("LEISTUNG_PAUSCHAL")]
    LEISTUNG_PAUSCHAL,

    /// <summary>9990001000087</summary>
    [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(GRUNDPREIS))]
    [EnumMember(Value = "GRUNDPREIS")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GRUNDPREIS")]
    GRUNDPREIS,

    /// <summary>9990001000128</summary>
    [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(REGELENERGIE_ARBEIT))]
    [EnumMember(Value = "REGELENERGIE_ARBEIT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("REGELENERGIE_ARBEIT")]
    REGELENERGIE_ARBEIT,

    /// <summary>9990001000136</summary>
    [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(REGELENERGIE_LEISTUNG))]
    [EnumMember(Value = "REGELENERGIE_LEISTUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("REGELENERGIE_LEISTUNG")]
    REGELENERGIE_LEISTUNG,

    /// <summary>9990001000144</summary>
    [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(NOTSTROMLIEFERUNG_ARBEIT))]
    [EnumMember(Value = "NOTSTROMLIEFERUNG_ARBEIT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("NOTSTROMLIEFERUNG_ARBEIT")]
    NOTSTROMLIEFERUNG_ARBEIT,

    /// <summary>9990001000152</summary>
    [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(NOTSTROMLIEFERUNG_LEISTUNG))]
    [EnumMember(Value = "NOTSTROMLIEFERUNG_LEISTUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("NOTSTROMLIEFERUNG_LEISTUNG")]
    NOTSTROMLIEFERUNG_LEISTUNG,

    /// <summary>9990001000160</summary>
    [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(RESERVENETZKAPAZITAET))]
    [EnumMember(Value = "RESERVENETZKAPAZITAET")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("RESERVENETZKAPAZITAET")]
    RESERVENETZKAPAZITAET,

    /// <summary>9990001000178</summary>
    [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(RESERVELEISTUNG))]
    [EnumMember(Value = "RESERVELEISTUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("RESERVELEISTUNG")]
    RESERVELEISTUNG,

    /// <summary>9990001000186</summary>
    [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(ZUSAETZLICHE_ABLESUNG))]
    [EnumMember(Value = "ZUSAETZLICHE_ABLESUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ZUSAETZLICHE_ABLESUNG")]
    ZUSAETZLICHE_ABLESUNG,

    /// <summary>9990001000219</summary>
    [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(PRUEFGEBUEHREN_AUSSERPLANMAESSIG))]
    [EnumMember(Value = "PRUEFGEBUEHREN_AUSSERPLANMAESSIG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("PRUEFGEBUEHREN_AUSSERPLANMAESSIG")]
    PRUEFGEBUEHREN_AUSSERPLANMAESSIG,

    /// <summary>9990001000269</summary>
    [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(WIRKARBEIT))]
    [EnumMember(Value = "WIRKARBEIT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("WIRKARBEIT")]
    WIRKARBEIT,

    /// <summary>9990001000285</summary>
    [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(SINGULAER_GENUTZTE_BETRIEBSMITTEL))]
    [EnumMember(Value = "SINGULAER_GENUTZTE_BETRIEBSMITTEL")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SINGULAER_GENUTZTE_BETRIEBSMITTEL")]
    SINGULAER_GENUTZTE_BETRIEBSMITTEL,

    /// <summary>9990001000334</summary>
    [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(ABGABE_KWKG))]
    [EnumMember(Value = "ABGABE_KWKG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ABGABE_KWKG")]
    ABGABE_KWKG,

    /// <summary>9990001000376</summary>
    [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(ABSCHLAG))]
    [EnumMember(Value = "ABSCHLAG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ABSCHLAG")]
    ABSCHLAG,

    /// <summary>9990001000417</summary>
    [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(KONZESSIONSABGABE))]
    [EnumMember(Value = "KONZESSIONSABGABE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("KONZESSIONSABGABE")]
    KONZESSIONSABGABE,

    /// <summary>9990001000433</summary>
    [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(ENTGELT_FERNAUSLESUNG))]
    [EnumMember(Value = "ENTGELT_FERNAUSLESUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ENTGELT_FERNAUSLESUNG")]
    ENTGELT_FERNAUSLESUNG,

    /// <summary>9990001000475</summary>
    [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(UNTERMESSUNG))]
    [EnumMember(Value = "UNTERMESSUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("UNTERMESSUNG")]
    UNTERMESSUNG,

    /// <summary>9990001000508</summary>
    [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(BLINDMEHRARBEIT))]
    [EnumMember(Value = "BLINDMEHRARBEIT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BLINDMEHRARBEIT")]
    BLINDMEHRARBEIT,

    /// <summary>9990001000532</summary>
    [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(ENTGELT_ABRECHNUNG))]
    [EnumMember(Value = "ENTGELT_ABRECHNUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ENTGELT_ABRECHNUNG")]
    ENTGELT_ABRECHNUNG,

    /// <summary>9990001000540</summary>
    [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(SPERRKOSTEN))]
    [EnumMember(Value = "SPERRKOSTEN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SPERRKOSTEN")]
    SPERRKOSTEN,

    /// <summary>9990001000558</summary>
    [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(ENTSPERRKOSTEN))]
    [EnumMember(Value = "ENTSPERRKOSTEN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ENTSPERRKOSTEN")]
    ENTSPERRKOSTEN,

    /// <summary>9990001000566</summary>
    [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(MAHNKOSTEN))]
    [EnumMember(Value = "MAHNKOSTEN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MAHNKOSTEN")]
    MAHNKOSTEN,

    /// <summary>9990001000574</summary>
    [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(MEHR_MINDERMENGEN))]
    [EnumMember(Value = "MEHR_MINDERMENGEN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MEHR_MINDERMENGEN")]
    MEHR_MINDERMENGEN,

    /// <summary>9990001000582</summary>
    [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(INKASSOKOSTEN))]
    [EnumMember(Value = "INKASSOKOSTEN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("INKASSOKOSTEN")]
    INKASSOKOSTEN,

    /// <summary>9990001000590</summary>
    [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(BLINDMEHRLEISTUNG))]
    [EnumMember(Value = "BLINDMEHRLEISTUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BLINDMEHRLEISTUNG")]
    BLINDMEHRLEISTUNG,

    /// <summary>9990001000615</summary>
    [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(ENTGELT_MESSUNG_ABLESUNG))]
    [EnumMember(Value = "ENTGELT_MESSUNG_ABLESUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ENTGELT_MESSUNG_ABLESUNG")]
    ENTGELT_MESSUNG_ABLESUNG,

    /// <summary>9990001000623</summary>
    [ProtoEnum(
        Name = nameof(BDEWArtikelnummer) + "_" + nameof(ENTGELT_EINBAU_BETRIEB_WARTUNG_MESSTECHNIK)
    )]
    [EnumMember(Value = "ENTGELT_EINBAU_BETRIEB_WARTUNG_MESSTECHNIK")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName(
        "ENTGELT_EINBAU_BETRIEB_WARTUNG_MESSTECHNIK"
    )]
    ENTGELT_EINBAU_BETRIEB_WARTUNG_MESSTECHNIK,

    /// <summary>9990001000631</summary>
    /// <remarks>Ausgleichsenergie Überdeckung</remarks>
    [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(AUSGLEICHSENERGIE))]
    [EnumMember(Value = "AUSGLEICHSENERGIE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("AUSGLEICHSENERGIE")]
    AUSGLEICHSENERGIE,

    /// <summary>9990001000805</summary>
    /// <remarks>Ausgleichsenergie Unterdeckung</remarks>
    [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(AUSGLEICHSENERGIE_UNTERDECKUNG))]
    [EnumMember(Value = "AUSGLEICHSENERGIE_UNTERDECKUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("AUSGLEICHSENERGIE_UNTERDECKUNG")]
    AUSGLEICHSENERGIE_UNTERDECKUNG,

    /// <summary>9990001000649</summary>
    [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(ZAEHLEINRICHTUNG))]
    [EnumMember(Value = "ZAEHLEINRICHTUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ZAEHLEINRICHTUNG")]
    ZAEHLEINRICHTUNG,

    /// <summary>9990001000657</summary>
    [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(WANDLER_MENGENUMWERTER))]
    [EnumMember(Value = "WANDLER_MENGENUMWERTER")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("WANDLER_MENGENUMWERTER")]
    WANDLER_MENGENUMWERTER,

    /// <summary>9990001000665</summary>
    [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(KOMMUNIKATIONSEINRICHTUNG))]
    [EnumMember(Value = "KOMMUNIKATIONSEINRICHTUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("KOMMUNIKATIONSEINRICHTUNG")]
    KOMMUNIKATIONSEINRICHTUNG,

    /// <summary>9990001000673</summary>
    [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(TECHNISCHE_STEUEREINRICHTUNG))]
    [EnumMember(Value = "TECHNISCHE_STEUEREINRICHTUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("TECHNISCHE_STEUEREINRICHTUNG")]
    TECHNISCHE_STEUEREINRICHTUNG,

    /// <summary>9990001000681</summary>
    [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(PARAGRAF_19_STROM_NEV_UMLAGE))]
    [EnumMember(Value = "PARAGRAF_19_STROM_NEV_UMLAGE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("PARAGRAF_19_STROM_NEV_UMLAGE")]
    PARAGRAF_19_STROM_NEV_UMLAGE,

    /// <summary>9990001000699</summary>
    [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(BEFESTIGUNGSEINRICHTUNG))]
    [EnumMember(Value = "BEFESTIGUNGSEINRICHTUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BEFESTIGUNGSEINRICHTUNG")]
    BEFESTIGUNGSEINRICHTUNG,

    /// <summary>9990001000706</summary>
    [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(OFFSHORE_HAFTUNGSUMLAGE))]
    [EnumMember(Value = "OFFSHORE_HAFTUNGSUMLAGE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("OFFSHORE_HAFTUNGSUMLAGE")]
    OFFSHORE_HAFTUNGSUMLAGE,

    /// <summary>9990001000714</summary>
    [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(FIXE_ARBEITSENTGELTKOMPONENTE))]
    [EnumMember(Value = "FIXE_ARBEITSENTGELTKOMPONENTE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("FIXE_ARBEITSENTGELTKOMPONENTE")]
    FIXE_ARBEITSENTGELTKOMPONENTE,

    /// <summary>9990001000722</summary>
    [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(FIXE_LEISTUNGSENTGELTKOMPONENTE))]
    [EnumMember(Value = "FIXE_LEISTUNGSENTGELTKOMPONENTE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("FIXE_LEISTUNGSENTGELTKOMPONENTE")]
    FIXE_LEISTUNGSENTGELTKOMPONENTE,

    /// <summary>9990001000730</summary>
    [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(UMLAGE_ABSCHALTBARE_LASTEN))]
    [EnumMember(Value = "UMLAGE_ABSCHALTBARE_LASTEN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("UMLAGE_ABSCHALTBARE_LASTEN")]
    UMLAGE_ABSCHALTBARE_LASTEN,

    /// <summary>9990001000748</summary>
    [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(MEHRMENGE))]
    [EnumMember(Value = "MEHRMENGE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MEHRMENGE")]
    MEHRMENGE,

    /// <summary>9990001000756</summary>
    [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(MINDERMENGE))]
    [EnumMember(Value = "MINDERMENGE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MINDERMENGE")]
    MINDERMENGE,

    /// <summary>9990001000764</summary>
    [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(ENERGIESTEUER))]
    [EnumMember(Value = "ENERGIESTEUER")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ENERGIESTEUER")]
    ENERGIESTEUER,

    /// <summary>9990001000772</summary>
    [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(SMARTMETER_GATEWAY))]
    [EnumMember(Value = "SMARTMETER_GATEWAY")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SMARTMETER_GATEWAY")]
    SMARTMETER_GATEWAY,

    /// <summary>9990001000780</summary>
    [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(STEUERBOX))]
    [EnumMember(Value = "STEUERBOX")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("STEUERBOX")]
    STEUERBOX,

    /// <summary>9990001000798</summary>
    /// <remarks>Entgelt für  Messstellenbetrieb</remarks>
    [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(MSB_INKL_MESSUNG))]
    [EnumMember(Value = "MSB_INKL_MESSUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MSB_INKL_MESSUNG")]
    MSB_INKL_MESSUNG,

    /// <summary>9990001000813</summary>
    /// <remarks>Zusatzdienstleistung nach § 35 Abs. 2 Nr. 1 MsbG</remarks>
    [ProtoEnum(
        Name = nameof(BDEWArtikelnummer) + "_" + nameof(ZUSATZDIENSTLEISTUNG_PARAGRAPH_35_2_1_MSBG)
    )]
    [EnumMember(Value = "ZUSATZDIENSTLEISTUNG_PARAGRAPH_35_2_1_MSBG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName(
        "ZUSATZDIENSTLEISTUNG_PARAGRAPH_35_2_1_MSBG"
    )]
    ZUSATZDIENSTLEISTUNG_PARAGRAPH_35_2_1_MSBG,

    /// <summary>9990001000821</summary>
    /// <remarks>Zusatzdienstleistung nach § 35 Abs. 2 Nr. 2 MsbG</remarks>
    [ProtoEnum(
        Name = nameof(BDEWArtikelnummer) + "_" + nameof(ZUSATZDIENSTLEISTUNG_PARAGRAPH_35_2_2_MSBG)
    )]
    [EnumMember(Value = "ZUSATZDIENSTLEISTUNG_PARAGRAPH_35_2_2_MSBG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName(
        "ZUSATZDIENSTLEISTUNG_PARAGRAPH_35_2_2_MSBG"
    )]
    ZUSATZDIENSTLEISTUNG_PARAGRAPH_35_2_2_MSBG,

    /// <summary>9990001000839</summary>
    /// <remarks>Zusatzdienstleistung nach § 35 Abs. 2 Nr. 3 MsbG</remarks>
    [ProtoEnum(
        Name = nameof(BDEWArtikelnummer) + "_" + nameof(ZUSATZDIENSTLEISTUNG_PARAGRAPH_35_2_3_MSBG)
    )]
    [EnumMember(Value = "ZUSATZDIENSTLEISTUNG_PARAGRAPH_35_2_3_MSBG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName(
        "ZUSATZDIENSTLEISTUNG_PARAGRAPH_35_2_3_MSBG"
    )]
    ZUSATZDIENSTLEISTUNG_PARAGRAPH_35_2_3_MSBG,

    /// <summary>9990001000847</summary>
    /// <remarks>Zusatzdienstleistung nach § 35 Abs. 2 Nr. 4 MsbG</remarks>
    [ProtoEnum(
        Name = nameof(BDEWArtikelnummer) + "_" + nameof(ZUSATZDIENSTLEISTUNG_PARAGRAPH_35_2_4_MSBG)
    )]
    [EnumMember(Value = "ZUSATZDIENSTLEISTUNG_PARAGRAPH_35_2_4_MSBG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName(
        "ZUSATZDIENSTLEISTUNG_PARAGRAPH_35_2_4_MSBG"
    )]
    ZUSATZDIENSTLEISTUNG_PARAGRAPH_35_2_4_MSBG,

    /// <summary>9990001000855</summary>
    /// <remarks>Zusatzdienstleistung nach § 35 Abs. 2 Nr. 5 MsbG</remarks>
    [ProtoEnum(
        Name = nameof(BDEWArtikelnummer) + "_" + nameof(ZUSATZDIENSTLEISTUNG_PARAGRAPH_35_2_5_MSBG)
    )]
    [EnumMember(Value = "ZUSATZDIENSTLEISTUNG_PARAGRAPH_35_2_5_MSBG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName(
        "ZUSATZDIENSTLEISTUNG_PARAGRAPH_35_2_5_MSBG"
    )]
    ZUSATZDIENSTLEISTUNG_PARAGRAPH_35_2_5_MSBG,

    /// <summary>9990001000863</summary>
    /// <remarks>Zusatzdienstleistung nach § 35 Abs. 3 MsbG</remarks>
    [ProtoEnum(
        Name = nameof(BDEWArtikelnummer) + "_" + nameof(ZUSATZDIENSTLEISTUNG_PARAGRAPH_35_3_MSBG)
    )]
    [EnumMember(Value = "ZUSATZDIENSTLEISTUNG_PARAGRAPH_35_3_MSBG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName(
        "ZUSATZDIENSTLEISTUNG_PARAGRAPH_35_3_MSBG"
    )]
    ZUSATZDIENSTLEISTUNG_PARAGRAPH_35_3_MSBG,

    /// <summary>9991000002305</summary>
    /// <remarks>Einbau iMS, Produkt-Code (Änderung an einer Lokation in der Sparte Strom)</remarks>
    [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(EINBAU_IMS))]
    [EnumMember(Value = "EINBAU_IMS")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("EINBAU_IMS")]
    EINBAU_IMS,

    /// <summary>9991000002313</summary>
    /// <remarks>Einbau kME / rLM, Produkt-Code (Änderung an einer Lokation in der Sparte Strom)</remarks>
    [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(EINBAU_KME_RLM))]
    [EnumMember(Value = "EINBAU_KME_RLM")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("EINBAU_KME_RLM")]
    EINBAU_KME_RLM,

    /// <summary>9991000002321</summary>
    /// <remarks>Einbau Wandler, Produkt-Code (Änderung an einer Lokation in der Sparte Strom)</remarks>
    [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(EINBAU_WANDLER))]
    [EnumMember(Value = "EINBAU_WANDLER")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("EINBAU_WANDLER")]
    EINBAU_WANDLER,

    /// <summary>9991000002339</summary>
    /// <remarks>weitere Energieflussrichtung, Produkt-Code (Änderung an einer Lokation in der Sparte Strom)</remarks>
    [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(WEITERE_ENERGIEFLUSSRICHTUNG))]
    [EnumMember(Value = "WEITERE_ENERGIEFLUSSRICHTUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("WEITERE_ENERGIEFLUSSRICHTUNG")]
    WEITERE_ENERGIEFLUSSRICHTUNG,

    /// <summary>9991000002347</summary>
    /// <remarks>Vergleichsmessung, Produkt-Code (Änderung an einer Lokation in der Sparte Strom)</remarks>
    [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(VERGLEICHSMESSUNG))]
    [EnumMember(Value = "VERGLEICHSMESSUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("VERGLEICHSMESSUNG")]
    VERGLEICHSMESSUNG,

    /// <summary>9991000002355</summary>
    /// <remarks>Änderung Messebene, Produkt-Code (Änderung an einer Lokation in der Sparte Strom)</remarks>
    [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(ÄNDERUNG_MESSEBENE))]
    [EnumMember(Value = "ÄNDERUNG_MESSEBENE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ÄNDERUNG_MESSEBENE")]
    ÄNDERUNG_MESSEBENE,

    /// <summary>9991000002363 (an SR),
    /// 9991000002389 (an NeLo)</summary>
    /// <remarks>Einbau einer Steuerbox, Produkt-Code (Änderung an einer Lokation in der Sparte Strom)</remarks>
    [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(EINBAU_STEUERBOX))]
    [EnumMember(Value = "EINBAU_STEUERBOX")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("EINBAU_STEUERBOX")]
    EINBAU_STEUERBOX,

    /// <summary>9991000002371</summary>
    /// <remarks>Anschluss weiterer Technischer Ressource an die Steuerbare Ressource der Steuerbox, Produkt-Code (Änderung an einer Lokation in der Sparte Strom)</remarks>
    [ProtoEnum(Name = nameof(BDEWArtikelnummer) + "_" + nameof(ANSCHLUSS_TR_STEUERBOX_SR))]
    [EnumMember(Value = "ANSCHLUSS_TR_STEUERBOX_SR")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ANSCHLUSS_TR_STEUERBOX_SR")]
    ANSCHLUSS_TR_STEUERBOX_SR,
}
