using BO4E.meta;

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
        PREIS_RECHENREGEL_FALSCH,

        /// <summary> FALSCHER_ABRECHNUNGSZEITRAUM </summary>
        /// <remarks>9</remarks>
        FALSCHER_ABRECHNUNGSZEITRAUM,

        /// <summary> UNBEKANNTE_MARKTLOKATION_MESSLOKATION </summary>
        /// <remarks>14</remarks>
        UNBEKANNTE_MARKTLOKATION_MESSLOKATION,

        /// <summary> SONSTIGER_ABWEICHUNGSGRUND </summary>
        /// <remarks>28</remarks>
        SONSTIGER_ABWEICHUNGSGRUND,

        /// <summary> DOPPELTE_RECHNUNG </summary>
        /// <remarks>53</remarks>
        DOPPELTE_RECHNUNG,

        /// <summary> ABRECHNUNGSBEGINN_UNGLEICH_VERTRAGSBEGINN </summary>
        /// <remarks>Z01</remarks>
        ABRECHNUNGSBEGINN_UNGLEICH_VERTRAGSBEGINN,

        /// <summary> ABRECHNUNGSENDE_UNGLEICH_VERTRAGSENDE </summary>
        /// <remarks>Z02</remarks>
        ABRECHNUNGSENDE_UNGLEICH_VERTRAGSENDE,

        /// <summary> BETRAG_DER_ABSCHLAGSRECHNUNG_FALSCH </summary>
        /// <remarks>Z03</remarks>
        BETRAG_DER_ABSCHLAGSRECHNUNG_FALSCH,

        /// <summary> VORAUSBEZAHLTER_BETRAG_FALSCH </summary>
        /// <remarks>Z04</remarks>
        VORAUSBEZAHLTER_BETRAG_FALSCH,

        /// <summary> ARTIKEL_NICHT_VEREINBART </summary>
        /// <remarks>Z06</remarks>
        ARTIKEL_NICHT_VEREINBART,

        /// <summary> NETZNUTZUNGSMESSWERTE_ENERGIEMENGEN_FEHLEN </summary>
        /// <remarks>Z07</remarks>
        NETZNUTZUNGSMESSWERTE_ENERGIEMENGEN_FEHLEN,

        /// <summary> RECHNUNGSNUMMER_BEREITS_ERHALTEN </summary>
        /// <remarks>Z08</remarks>
        RECHNUNGSNUMMER_BEREITS_ERHALTEN,

        /// <summary> NETZNUTZUNGSMESSWERTE_ENERGIEMENGEN_FALSCH </summary>
        /// <remarks>Z10</remarks>
        NETZNUTZUNGSMESSWERTE_ENERGIEMENGEN_FALSCH,

        /// <summary> ZEITLICHE_MENGENANGABE_FEHLERHAFT </summary>
        /// <remarks>Z33</remarks>
        ZEITLICHE_MENGENANGABE_FEHLERHAFT,

        /// <summary> FALSCHER_BILANZIERUNGSBEGINN </summary>
        /// <remarks>Z35</remarks>
        FALSCHER_BILANZIERUNGSBEGINN,

        /// <summary> FALSCHES_NETZNUTZUNGSENDE </summary>
        /// <remarks>Z36</remarks>
        FALSCHES_NETZNUTZUNGSENDE,

        /// <summary> BILANZIERTE_MENGE_FEHLT </summary>
        /// <remarks>Z37</remarks>
        BILANZIERTE_MENGE_FEHLT,

        /// <summary> BILANZIERTE_MENGE_FALSCH </summary>
        /// <remarks>Z38</remarks>
        BILANZIERTE_MENGE_FALSCH,

        /// <summary> NETZNUTZUNGSABRECHNUNG_FEHLT </summary>
        /// <remarks>Z39</remarks>
        NETZNUTZUNGSABRECHNUNG_FEHLT,

        /// <summary> REVERSE_CHARGE_ANWENDUNG_FEHLT_ODER_FEHLERHAFT </summary>
        /// <remarks>Z40</remarks>
        REVERSE_CHARGE_ANWENDUNG_FEHLT_ODER_FEHLERHAFT,

        /// <summary> ALLOKATIONSLISTE_FEHLT </summary>
        /// <remarks>Z41</remarks>
        ALLOKATIONSLISTE_FEHLT,

        /// <summary> MEHR_MINDERMENGE_FALSCH </summary>
        /// <remarks>Z42</remarks>
        MEHR_MINDERMENGE_FALSCH,

        /// <summary> UNGUELTIGES_RECHNUNGSDATUM </summary>
        /// <remarks>Z43</remarks>
        UNGUELTIGES_RECHNUNGSDATUM,

        /// <summary> ZEITINTERVALL_DER_BILANZIERTEN_MENGE_INKONSISTENT </summary>
        /// <remarks>Z44</remarks>
        ZEITINTERVALL_DER_BILANZIERTEN_MENGE_INKONSISTENT,

        /// <summary> RECHNUNGSEMPFAENGER_WIDERSPRICHT_DER_STEUERRECHTLICHEN_EINSCHAETZUNG_DES_RECHNUNGSSTELLERS </summary>
        /// <remarks>Z45</remarks>
        RECHNUNGSEMPFAENGER_WIDERSPRICHT_DER_STEUERRECHTLICHEN_EINSCHAETZUNG_DES_RECHNUNGSSTELLERS,

        /// <summary> ANGEGEBENE_QUOTES_AN_MARKTLOKATION_NICHT_VORHANDEN </summary>
        /// <remarks>Z52</remarks>
        ANGEGEBENE_QUOTES_AN_MARKTLOKATION_NICHT_VORHANDEN,

        /// <summary> RECHNUNGSABWICKLUNG_NICHT_VEREINBART </summary>
        /// <remarks>Z53</remarks>
        RECHNUNGSABWICKLUNG_NICHT_VEREINBART,

        /// <summary> COMDIS_WIRD_ABGELEHNT </summary>
        /// <remarks>Z63</remarks>
        COMDIS_WIRD_ABGELEHNT,
    }
}