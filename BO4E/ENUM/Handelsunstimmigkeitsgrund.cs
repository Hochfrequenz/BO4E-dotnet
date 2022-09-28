using BO4E.meta;

namespace BO4E.ENUM
{
    /// <summary>
    /// Begründung der Korrektheit der Rechnung oder des Lieferscheins (COMDIS SG3 AJT 4465)
    /// </summary>
    [NonOfficial(NonOfficialCategory.MISSING)]
    public enum Handelsunstimmigkeitsgrund
    {
        /// <summary> ANMELDUNG_BESTAETIGT</summary>
        /// <remarks>Z58</remarks>
        ANMELDUNG_BESTAETIGT,

        /// <summary> ABRECHNUNGSBEGINN_GLEICH_BESTAETIGTEM_VERTRAGSBEGINN</summary>
        /// <remarks>Z59</remarks>
        ABRECHNUNGSBEGINN_GLEICH_BESTAETIGTEM_VERTRAGSBEGINN,

        /// <summary> ABRECHNUNGSENDE_GLEICH_BESTAETIGTEM_VERTRAGSENDE</summary>
        /// <remarks>Z60</remarks>
        ABRECHNUNGSENDE_GLEICH_BESTAETIGTEM_VERTRAGSENDE,

        /// <summary> NN_MSCONS_UEBERSENDET</summary>
        /// <remarks>Z61</remarks>
        NN_MSCONS_UEBERSENDET,

        /// <summary> RICHTIGE_MESSWERTE_ENERGIEMENGEN_UEBERSENDET </summary>
        /// <remarks>Z62</remarks>
        RICHTIGE_MESSWERTE_ENERGIEMENGEN_UEBERSENDET,

        /// <summary> SONSTIGES_SIEHE_BEGRUENDUNG </summary>
        /// <remarks>28</remarks>
        SONSTIGES_SIEHE_BEGRUENDUNG,

        /// <summary> GUELTIGES_PREISBLATT_VERSENDET </summary>
        /// <remarks>A01</remarks>
        GUELTIGES_PREISBLATT_VERSENDET,

        /// <summary> GUELTIGER_SPERRAUFTRAG_VORHANDEN </summary>
        /// <remarks>A02</remarks>
        GUELTIGER_SPERRAUFTRAG_VORHANDEN,

        /// <summary> KORREKTE_ARTIKEL_ID_IN_RECHNUNG </summary>
        /// <remarks>A03</remarks>
        KORREKTE_ARTIKEL_ID_IN_RECHNUNG,

        /// <summary> KORREKTER_PREIS_ZU_GUELTIGEM_PREISBLATT_IN_RECHNUNG </summary>
        /// <remarks>A04</remarks>
        KORREKTER_PREIS_ZU_GUELTIGEM_PREISBLATT_IN_RECHNUNG,

        /// <summary> GUELTIGES_PREISBLATT_FRISTGERECHT_VERSENDET </summary>
        /// <remarks>A06</remarks>
        GUELTIGES_PREISBLATT_FRISTGERECHT_VERSENDET,

        /// <summary> GUELTIGE_RECHNUNG_VORHANDEN </summary>
        /// <remarks>A07</remarks>
        GUELTIGE_RECHNUNG_VORHANDEN,

        /// <summary> KORREKTER_PREIS_IN_RECHNUNG_ABGERECHNET </summary>
        /// <remarks>A09</remarks>
        KORREKTER_PREIS_IN_RECHNUNG_ABGERECHNET,

        /// <summary> GUELTIGES_PREISBLATT_BLINDARBEIT_VERSENDET </summary>
        /// <remarks>A12</remarks>
        GUELTIGES_PREISBLATT_BLINDARBEIT_VERSENDET,

        /// <summary> KORREKTE_ARTIKEL_ID_FUER_ABRECHNUNG_STORNIERTER_SPERRAUFTRAG_ANGEGEBEN </summary>
        /// <remarks>A15</remarks>
        KORREKTE_ARTIKEL_ID_FUER_ABRECHNUNG_STORNIERTER_SPERRAUFTRAG_ANGEGEBEN,
    }
}