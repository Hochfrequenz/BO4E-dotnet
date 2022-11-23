using BO4E.meta;
using System.Runtime.Serialization;

namespace BO4E.ENUM
{
    /// <summary>
    /// Gibt einen Abweichungsgrund bei Ablehung einer COMDIS an. (REMADV SG7 AJT 4465)
    /// </summary>
    [NonOfficial(NonOfficialCategory.MISSING)]
    public enum Abweichungsgrund
    {
        /// <summary> PREIS_RECHENREGEL_FALSCH </summary>
        /// <remarks>5</remarks>
        [EnumMember(Value = "PREIS_RECHENREGEL_FALSCH")]
        PREIS_RECHENREGEL_FALSCH,

        /// <summary> FALSCHER_ABRECHNUNGSZEITRAUM </summary>
        /// <remarks>9</remarks>
        [EnumMember(Value = "FALSCHER_ABRECHNUNGSZEITRAUM")]
        FALSCHER_ABRECHNUNGSZEITRAUM,

        /// <summary> UNBEKANNTE_MARKTLOKATION_MESSLOKATION </summary>
        /// <remarks>14</remarks>
        [EnumMember(Value = "UNBEKANNTE_MARKTLOKATION_MESSLOKATION")]
        UNBEKANNTE_MARKTLOKATION_MESSLOKATION,

        /// <summary> SONSTIGER_ABWEICHUNGSGRUND </summary>
        /// <remarks>28</remarks>
        [EnumMember(Value = "SONSTIGER_ABWEICHUNGSGRUND")]
        SONSTIGER_ABWEICHUNGSGRUND,

        /// <summary> DOPPELTE_RECHNUNG </summary>
        /// <remarks>53</remarks>
        [EnumMember(Value = "DOPPELTE_RECHNUNG")]
        DOPPELTE_RECHNUNG,

        /// <summary> ABRECHNUNGSBEGINN_UNGLEICH_VERTRAGSBEGINN </summary>
        /// <remarks>Z01</remarks>
        [EnumMember(Value = "ABRECHNUNGSBEGINN_UNGLEICH_VERTRAGSBEGINN")]
        ABRECHNUNGSBEGINN_UNGLEICH_VERTRAGSBEGINN,

        /// <summary> ABRECHNUNGSENDE_UNGLEICH_VERTRAGSENDE </summary>
        /// <remarks>Z02</remarks>
        [EnumMember(Value = "ABRECHNUNGSENDE_UNGLEICH_VERTRAGSENDE")]
        ABRECHNUNGSENDE_UNGLEICH_VERTRAGSENDE,

        /// <summary> BETRAG_DER_ABSCHLAGSRECHNUNG_FALSCH </summary>
        /// <remarks>Z03</remarks>
        [EnumMember(Value = "BETRAG_DER_ABSCHLAGSRECHNUNG_FALSCH")]
        BETRAG_DER_ABSCHLAGSRECHNUNG_FALSCH,

        /// <summary> VORAUSBEZAHLTER_BETRAG_FALSCH </summary>
        /// <remarks>Z04</remarks>
        [EnumMember(Value = "VORAUSBEZAHLTER_BETRAG_FALSCH")]
        VORAUSBEZAHLTER_BETRAG_FALSCH,

        /// <summary> ARTIKEL_NICHT_VEREINBART </summary>
        /// <remarks>Z06</remarks>
        [EnumMember(Value = "ARTIKEL_NICHT_VEREINBART")]
        ARTIKEL_NICHT_VEREINBART,

        /// <summary> NETZNUTZUNGSMESSWERTE_ENERGIEMENGEN_FEHLEN </summary>
        /// <remarks>Z07</remarks>
        [EnumMember(Value = "NETZNUTZUNGSMESSWERTE_ENERGIEMENGEN_FEHLEN")]
        NETZNUTZUNGSMESSWERTE_ENERGIEMENGEN_FEHLEN,

        /// <summary> RECHNUNGSNUMMER_BEREITS_ERHALTEN </summary>
        /// <remarks>Z08</remarks>
        [EnumMember(Value = "RECHNUNGSNUMMER_BEREITS_ERHALTEN")]
        RECHNUNGSNUMMER_BEREITS_ERHALTEN,

        /// <summary> NETZNUTZUNGSMESSWERTE_ENERGIEMENGEN_FALSCH </summary>
        /// <remarks>Z10</remarks>
        [EnumMember(Value = "NETZNUTZUNGSMESSWERTE_ENERGIEMENGEN_FALSCH")]
        NETZNUTZUNGSMESSWERTE_ENERGIEMENGEN_FALSCH,

        /// <summary> ZEITLICHE_MENGENANGABE_FEHLERHAFT </summary>
        /// <remarks>Z33</remarks>
        [EnumMember(Value = "ZEITLICHE_MENGENANGABE_FEHLERHAFT")]
        ZEITLICHE_MENGENANGABE_FEHLERHAFT,

        /// <summary> FALSCHER_BILANZIERUNGSBEGINN </summary>
        /// <remarks>Z35</remarks>
        [EnumMember(Value = "FALSCHER_BILANZIERUNGSBEGINN")]
        FALSCHER_BILANZIERUNGSBEGINN,

        /// <summary> FALSCHES_NETZNUTZUNGSENDE </summary>
        /// <remarks>Z36</remarks>
        [EnumMember(Value = "FALSCHES_NETZNUTZUNGSENDE")]
        FALSCHES_NETZNUTZUNGSENDE,

        /// <summary> BILANZIERTE_MENGE_FEHLT </summary>
        /// <remarks>Z37</remarks>
        [EnumMember(Value = "BILANZIERTE_MENGE_FEHLT")]
        BILANZIERTE_MENGE_FEHLT,

        /// <summary> BILANZIERTE_MENGE_FALSCH </summary>
        /// <remarks>Z38</remarks>
        [EnumMember(Value = "BILANZIERTE_MENGE_FALSCH")]
        BILANZIERTE_MENGE_FALSCH,

        /// <summary> NETZNUTZUNGSABRECHNUNG_FEHLT </summary>
        /// <remarks>Z39</remarks>
        [EnumMember(Value = "NETZNUTZUNGSABRECHNUNG_FEHLT")]
        NETZNUTZUNGSABRECHNUNG_FEHLT,

        /// <summary> REVERSE_CHARGE_ANWENDUNG_FEHLT_ODER_FEHLERHAFT </summary>
        /// <remarks>Z40</remarks>
        [EnumMember(Value = "REVERSE_CHARGE_ANWENDUNG_FEHLT_ODER_FEHLERHAFT")]
        REVERSE_CHARGE_ANWENDUNG_FEHLT_ODER_FEHLERHAFT,

        /// <summary> ALLOKATIONSLISTE_FEHLT </summary>
        /// <remarks>Z41</remarks>
        [EnumMember(Value = "ALLOKATIONSLISTE_FEHLT")]
        ALLOKATIONSLISTE_FEHLT,

        /// <summary> MEHR_MINDERMENGE_FALSCH </summary>
        /// <remarks>Z42</remarks>
        [EnumMember(Value = "MEHR_MINDERMENGE_FALSCH")]
        MEHR_MINDERMENGE_FALSCH,

        /// <summary> UNGUELTIGES_RECHNUNGSDATUM </summary>
        /// <remarks>Z43</remarks>
        [EnumMember(Value = "UNGUELTIGES_RECHNUNGSDATUM")]
        UNGUELTIGES_RECHNUNGSDATUM,

        /// <summary> ZEITINTERVALL_DER_BILANZIERTEN_MENGE_INKONSISTENT </summary>
        /// <remarks>Z44</remarks>
        [EnumMember(Value = "ZEITINTERVALL_DER_BILANZIERTEN_MENGE_INKONSISTENT")]
        ZEITINTERVALL_DER_BILANZIERTEN_MENGE_INKONSISTENT,

        /// <summary> RECHNUNGSEMPFAENGER_WIDERSPRICHT_DER_STEUERRECHTLICHEN_EINSCHAETZUNG_DES_RECHNUNGSSTELLERS </summary>
        /// <remarks>Z45</remarks>
        [EnumMember(Value = "RECHNUNGSEMPFAENGER_WIDERSPRICHT_DER_STEUERRECHTLICHEN_EINSCHAETZUNG_DES_RECHNUNGSSTELLERS")]
        RECHNUNGSEMPFAENGER_WIDERSPRICHT_DER_STEUERRECHTLICHEN_EINSCHAETZUNG_DES_RECHNUNGSSTELLERS,

        /// <summary> ANGEGEBENE_QUOTES_AN_MARKTLOKATION_NICHT_VORHANDEN </summary>
        /// <remarks>Z52</remarks>
        [EnumMember(Value = "ANGEGEBENE_QUOTES_AN_MARKTLOKATION_NICHT_VORHANDEN")]
        ANGEGEBENE_QUOTES_AN_MARKTLOKATION_NICHT_VORHANDEN,

        /// <summary> RECHNUNGSABWICKLUNG_NICHT_VEREINBART </summary>
        /// <remarks>Z53</remarks>
        [EnumMember(Value = "RECHNUNGSABWICKLUNG_NICHT_VEREINBART")]
        RECHNUNGSABWICKLUNG_NICHT_VEREINBART,

        /// <summary> COMDIS_WIRD_ABGELEHNT </summary>
        /// <remarks>Z63</remarks>
        [EnumMember(Value = "COMDIS_WIRD_ABGELEHNT")]
        COMDIS_WIRD_ABGELEHNT,
    }
}