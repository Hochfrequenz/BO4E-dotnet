using System.Runtime.Serialization;
using BO4E.meta;

namespace BO4E.ENUM;

/// <summary>
/// Gibt einen Abweichungsgrund bei Ablehung einer COMDIS an. (REMADV SG7 AJT 4465)
/// </summary>
[NonOfficial(NonOfficialCategory.MISSING)]
public enum Abweichungsgrund
{
    /// <summary> PREIS_RECHENREGEL_FALSCH </summary>
    /// <remarks>5</remarks>
    [EnumMember(Value = "PREIS_RECHENREGEL_FALSCH")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("PREIS_RECHENREGEL_FALSCH")]
    PREIS_RECHENREGEL_FALSCH,

    /// <summary> FALSCHER_ABRECHNUNGSZEITRAUM </summary>
    /// <remarks>9</remarks>
    [EnumMember(Value = "FALSCHER_ABRECHNUNGSZEITRAUM")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("FALSCHER_ABRECHNUNGSZEITRAUM")]
    FALSCHER_ABRECHNUNGSZEITRAUM,

    /// <summary> UNBEKANNTE_MARKTLOKATION_MESSLOKATION </summary>
    /// <remarks>14</remarks>
    [EnumMember(Value = "UNBEKANNTE_MARKTLOKATION_MESSLOKATION")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName(
        "UNBEKANNTE_MARKTLOKATION_MESSLOKATION"
    )]
    UNBEKANNTE_MARKTLOKATION_MESSLOKATION,

    /// <summary> SONSTIGER_ABWEICHUNGSGRUND </summary>
    /// <remarks>28</remarks>
    [EnumMember(Value = "SONSTIGER_ABWEICHUNGSGRUND")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SONSTIGER_ABWEICHUNGSGRUND")]
    SONSTIGER_ABWEICHUNGSGRUND,

    /// <summary> DOPPELTE_RECHNUNG </summary>
    /// <remarks>53</remarks>
    [EnumMember(Value = "DOPPELTE_RECHNUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("DOPPELTE_RECHNUNG")]
    DOPPELTE_RECHNUNG,

    /// <summary> ABRECHNUNGSBEGINN_UNGLEICH_VERTRAGSBEGINN </summary>
    /// <remarks>Z01</remarks>
    [EnumMember(Value = "ABRECHNUNGSBEGINN_UNGLEICH_VERTRAGSBEGINN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName(
        "ABRECHNUNGSBEGINN_UNGLEICH_VERTRAGSBEGINN"
    )]
    ABRECHNUNGSBEGINN_UNGLEICH_VERTRAGSBEGINN,

    /// <summary> ABRECHNUNGSENDE_UNGLEICH_VERTRAGSENDE </summary>
    /// <remarks>Z02</remarks>
    [EnumMember(Value = "ABRECHNUNGSENDE_UNGLEICH_VERTRAGSENDE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName(
        "ABRECHNUNGSENDE_UNGLEICH_VERTRAGSENDE"
    )]
    ABRECHNUNGSENDE_UNGLEICH_VERTRAGSENDE,

    /// <summary> BETRAG_DER_ABSCHLAGSRECHNUNG_FALSCH </summary>
    /// <remarks>Z03</remarks>
    [EnumMember(Value = "BETRAG_DER_ABSCHLAGSRECHNUNG_FALSCH")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BETRAG_DER_ABSCHLAGSRECHNUNG_FALSCH")]
    BETRAG_DER_ABSCHLAGSRECHNUNG_FALSCH,

    /// <summary> VORAUSBEZAHLTER_BETRAG_FALSCH </summary>
    /// <remarks>Z04</remarks>
    [EnumMember(Value = "VORAUSBEZAHLTER_BETRAG_FALSCH")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("VORAUSBEZAHLTER_BETRAG_FALSCH")]
    VORAUSBEZAHLTER_BETRAG_FALSCH,

    /// <summary> ARTIKEL_NICHT_VEREINBART </summary>
    /// <remarks>Z06</remarks>
    [EnumMember(Value = "ARTIKEL_NICHT_VEREINBART")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ARTIKEL_NICHT_VEREINBART")]
    ARTIKEL_NICHT_VEREINBART,

    /// <summary> NETZNUTZUNGSMESSWERTE_ENERGIEMENGEN_FEHLEN </summary>
    /// <remarks>Z07</remarks>
    [EnumMember(Value = "NETZNUTZUNGSMESSWERTE_ENERGIEMENGEN_FEHLEN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName(
        "NETZNUTZUNGSMESSWERTE_ENERGIEMENGEN_FEHLEN"
    )]
    NETZNUTZUNGSMESSWERTE_ENERGIEMENGEN_FEHLEN,

    /// <summary> RECHNUNGSNUMMER_BEREITS_ERHALTEN </summary>
    /// <remarks>Z08</remarks>
    [EnumMember(Value = "RECHNUNGSNUMMER_BEREITS_ERHALTEN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("RECHNUNGSNUMMER_BEREITS_ERHALTEN")]
    RECHNUNGSNUMMER_BEREITS_ERHALTEN,

    /// <summary> NETZNUTZUNGSMESSWERTE_ENERGIEMENGEN_FALSCH </summary>
    /// <remarks>Z10</remarks>
    [EnumMember(Value = "NETZNUTZUNGSMESSWERTE_ENERGIEMENGEN_FALSCH")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName(
        "NETZNUTZUNGSMESSWERTE_ENERGIEMENGEN_FALSCH"
    )]
    NETZNUTZUNGSMESSWERTE_ENERGIEMENGEN_FALSCH,

    /// <summary> ZEITLICHE_MENGENANGABE_FEHLERHAFT </summary>
    /// <remarks>Z33</remarks>
    [EnumMember(Value = "ZEITLICHE_MENGENANGABE_FEHLERHAFT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ZEITLICHE_MENGENANGABE_FEHLERHAFT")]
    ZEITLICHE_MENGENANGABE_FEHLERHAFT,

    /// <summary> FALSCHER_BILANZIERUNGSBEGINN </summary>
    /// <remarks>Z35</remarks>
    [EnumMember(Value = "FALSCHER_BILANZIERUNGSBEGINN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("FALSCHER_BILANZIERUNGSBEGINN")]
    FALSCHER_BILANZIERUNGSBEGINN,

    /// <summary> FALSCHES_NETZNUTZUNGSENDE </summary>
    /// <remarks>Z36</remarks>
    [EnumMember(Value = "FALSCHES_NETZNUTZUNGSENDE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("FALSCHES_NETZNUTZUNGSENDE")]
    FALSCHES_NETZNUTZUNGSENDE,

    /// <summary> BILANZIERTE_MENGE_FEHLT </summary>
    /// <remarks>Z37</remarks>
    [EnumMember(Value = "BILANZIERTE_MENGE_FEHLT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BILANZIERTE_MENGE_FEHLT")]
    BILANZIERTE_MENGE_FEHLT,

    /// <summary> BILANZIERTE_MENGE_FALSCH </summary>
    /// <remarks>Z38</remarks>
    [EnumMember(Value = "BILANZIERTE_MENGE_FALSCH")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BILANZIERTE_MENGE_FALSCH")]
    BILANZIERTE_MENGE_FALSCH,

    /// <summary> NETZNUTZUNGSABRECHNUNG_FEHLT </summary>
    /// <remarks>Z39</remarks>
    [EnumMember(Value = "NETZNUTZUNGSABRECHNUNG_FEHLT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("NETZNUTZUNGSABRECHNUNG_FEHLT")]
    NETZNUTZUNGSABRECHNUNG_FEHLT,

    /// <summary> REVERSE_CHARGE_ANWENDUNG_FEHLT_ODER_FEHLERHAFT </summary>
    /// <remarks>Z40</remarks>
    [EnumMember(Value = "REVERSE_CHARGE_ANWENDUNG_FEHLT_ODER_FEHLERHAFT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName(
        "REVERSE_CHARGE_ANWENDUNG_FEHLT_ODER_FEHLERHAFT"
    )]
    REVERSE_CHARGE_ANWENDUNG_FEHLT_ODER_FEHLERHAFT,

    /// <summary> ALLOKATIONSLISTE_FEHLT </summary>
    /// <remarks>Z41</remarks>
    [EnumMember(Value = "ALLOKATIONSLISTE_FEHLT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ALLOKATIONSLISTE_FEHLT")]
    ALLOKATIONSLISTE_FEHLT,

    /// <summary> MEHR_MINDERMENGE_FALSCH </summary>
    /// <remarks>Z42</remarks>
    [EnumMember(Value = "MEHR_MINDERMENGE_FALSCH")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MEHR_MINDERMENGE_FALSCH")]
    MEHR_MINDERMENGE_FALSCH,

    /// <summary> UNGUELTIGES_RECHNUNGSDATUM </summary>
    /// <remarks>Z43</remarks>
    [EnumMember(Value = "UNGUELTIGES_RECHNUNGSDATUM")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("UNGUELTIGES_RECHNUNGSDATUM")]
    UNGUELTIGES_RECHNUNGSDATUM,

    /// <summary> ZEITINTERVALL_DER_BILANZIERTEN_MENGE_INKONSISTENT </summary>
    /// <remarks>Z44</remarks>
    [EnumMember(Value = "ZEITINTERVALL_DER_BILANZIERTEN_MENGE_INKONSISTENT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName(
        "ZEITINTERVALL_DER_BILANZIERTEN_MENGE_INKONSISTENT"
    )]
    ZEITINTERVALL_DER_BILANZIERTEN_MENGE_INKONSISTENT,

    /// <summary> RECHNUNGSEMPFAENGER_WIDERSPRICHT_DER_STEUERRECHTLICHEN_EINSCHAETZUNG_DES_RECHNUNGSSTELLERS </summary>
    /// <remarks>Z45</remarks>
    [EnumMember(
        Value = "RECHNUNGSEMPFAENGER_WIDERSPRICHT_DER_STEUERRECHTLICHEN_EINSCHAETZUNG_DES_RECHNUNGSSTELLERS"
    )]
    [System.Text.Json.Serialization.JsonStringEnumMemberName(
        "RECHNUNGSEMPFAENGER_WIDERSPRICHT_DER_STEUERRECHTLICHEN_EINSCHAETZUNG_DES_RECHNUNGSSTELLERS"
    )]
    RECHNUNGSEMPFAENGER_WIDERSPRICHT_DER_STEUERRECHTLICHEN_EINSCHAETZUNG_DES_RECHNUNGSSTELLERS,

    /// <summary> ANGEGEBENE_QUOTES_AN_MARKTLOKATION_NICHT_VORHANDEN </summary>
    /// <remarks>Z52</remarks>
    [EnumMember(Value = "ANGEGEBENE_QUOTES_AN_MARKTLOKATION_NICHT_VORHANDEN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName(
        "ANGEGEBENE_QUOTES_AN_MARKTLOKATION_NICHT_VORHANDEN"
    )]
    ANGEGEBENE_QUOTES_AN_MARKTLOKATION_NICHT_VORHANDEN,

    /// <summary> RECHNUNGSABWICKLUNG_NICHT_VEREINBART </summary>
    /// <remarks>Z53</remarks>
    [EnumMember(Value = "RECHNUNGSABWICKLUNG_NICHT_VEREINBART")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName(
        "RECHNUNGSABWICKLUNG_NICHT_VEREINBART"
    )]
    RECHNUNGSABWICKLUNG_NICHT_VEREINBART,

    /// <summary> COMDIS_WIRD_ABGELEHNT </summary>
    /// <remarks>Z63</remarks>
    [EnumMember(Value = "COMDIS_WIRD_ABGELEHNT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("COMDIS_WIRD_ABGELEHNT")]
    COMDIS_WIRD_ABGELEHNT,

    /// <summary>Der Beginn des Abrechnungszeitraums ist kleiner als 01.01.2024 00:00 Uhr </summary>
    /// <remarks>AE6</remarks>
    [EnumMember(Value = "BEGINN_DES_ABRECHNUNGSZEITRAUMS_VOR_2024")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName(
        "BEGINN_DES_ABRECHNUNGSZEITRAUMS_VOR_2024"
    )]
    BEGINN_DES_ABRECHNUNGSZEITRAUMS_VOR_2024,

    /// <summary>Erwartete Position nicht vorhanden</summary>
    /// <remarks>AE7</remarks>
    [EnumMember(Value = "ERWARTETE_POSITION_NICHT_VORHANDEN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ERWARTETE_POSITION_NICHT_VORHANDEN")]
    ERWARTETE_POSITION_NICHT_VORHANDEN,

    /// <summary>Im gesamten Abrechnungszeitraum ist an keiner Messlokation der Marktlokation ein iMS eingebaut</summary>
    /// <remarks>AE8</remarks>
    [EnumMember(Value = "KEIN_IMS_IM_GESAMTEN_ABRECHNUNGSZEITRAUM")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName(
        "KEIN_IMS_IM_GESAMTEN_ABRECHNUNGSZEITRAUM"
    )]
    KEIN_IMS_IM_GESAMTEN_ABRECHNUNGSZEITRAUM,

    /// <summary>Der MSB ist der Marktlokation nicht einen Tag des Abrechnungszeitraumes zugeordnet</summary>
    /// <remarks>AE9</remarks>
    [EnumMember(Value = "MSB_IM_ABRECHNUNGSZEITRAUM_NICHT_IMMER_ZUGEORDNET")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName(
        "MSB_IM_ABRECHNUNGSZEITRAUM_NICHT_IMMER_ZUGEORDNET"
    )]
    MSB_IM_ABRECHNUNGSZEITRAUM_NICHT_IMMER_ZUGEORDNET,

    /// <summary>Der MSB ist im gesamten Abrechnungszeitraum nicht der Marktlokation zugeordnet</summary>
    /// <remarks>AF0</remarks>
    [EnumMember(Value = "MSB_IM_GESAMTEN_ABRECHNUNGSZEITRAUM_NICHT_ZUGEORDNET")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName(
        "MSB_IM_GESAMTEN_ABRECHNUNGSZEITRAUM_NICHT_ZUGEORDNET"
    )]
    MSB_IM_GESAMTEN_ABRECHNUNGSZEITRAUM_NICHT_ZUGEORDNET,

    /// <summary>Die in der angegebenen Position verwendete Artikel-ID hätte nicht für den gesamten Positionszeitraum aufgeführt werde</summary>
    /// <remarks>AF1</remarks>
    [EnumMember(Value = "ARTIKELID_DER_POSITION_NICHT_IM_GESAMTEN_POSITIONSZEITRAUM_GUELTIG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName(
        "ARTIKELID_DER_POSITION_NICHT_IM_GESAMTEN_POSITIONSZEITRAUM_GUELTIG"
    )]
    ARTIKELID_DER_POSITION_NICHT_IM_GESAMTEN_POSITIONSZEITRAUM_GUELTIG,

    /// <summary>Diese Artikel-ID ist für diesen Rechnungstyp in dem besagten Positionszeitraum nicht zulässig</summary>
    /// <remarks>AF2</remarks>
    [EnumMember(Value = "ARTIKELID_FUER_RECHNUNGSTYP_IM_POSITIONSZEITRAUM_NICHT_ZULAESSIG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName(
        "ARTIKELID_FUER_RECHNUNGSTYP_IM_POSITIONSZEITRAUM_NICHT_ZULAESSIG"
    )]
    ARTIKELID_FUER_RECHNUNGSTYP_IM_POSITIONSZEITRAUM_NICHT_ZULAESSIG,
}
