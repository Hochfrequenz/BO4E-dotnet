using BO4E.meta;

using System.Runtime.Serialization;

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
        [EnumMember(Value = "ANMELDUNG_BESTAETIGT")] 
        ANMELDUNG_BESTAETIGT,

        /// <summary> ABRECHNUNGSBEGINN_GLEICH_BESTAETIGTEM_VERTRAGSBEGINN</summary>
        /// <remarks>Z59</remarks>
        [EnumMember(Value = "ABRECHNUNGSBEGINN_GLEICH_BESTAETIGTEM_VERTRAGSBEGINN")] 
        ABRECHNUNGSBEGINN_GLEICH_BESTAETIGTEM_VERTRAGSBEGINN,

        /// <summary> ABRECHNUNGSENDE_GLEICH_BESTAETIGTEM_VERTRAGSENDE</summary>
        /// <remarks>Z60</remarks>
        [EnumMember(Value = "ABRECHNUNGSENDE_GLEICH_BESTAETIGTEM_VERTRAGSENDE")] 
        ABRECHNUNGSENDE_GLEICH_BESTAETIGTEM_VERTRAGSENDE,

        /// <summary> NN_MSCONS_UEBERSENDET</summary>
        /// <remarks>Z61</remarks>
        [EnumMember(Value = "NN_MSCONS_UEBERSENDET")] 
        NN_MSCONS_UEBERSENDET,

        /// <summary> RICHTIGE_MESSWERTE_ENERGIEMENGEN_UEBERSENDET </summary>
        /// <remarks>Z62</remarks>
        [EnumMember(Value = "RICHTIGE_MESSWERTE_ENERGIEMENGEN_UEBERSENDET")] 
        RICHTIGE_MESSWERTE_ENERGIEMENGEN_UEBERSENDET,

        /// <summary> SONSTIGES_SIEHE_BEGRUENDUNG </summary>
        /// <remarks>28</remarks>
        [EnumMember(Value = "SONSTIGES_SIEHE_BEGRUENDUNG")] 
        SONSTIGES_SIEHE_BEGRUENDUNG,

        /// <summary> GUELTIGES_PREISBLATT_VERSENDET </summary>
        /// <remarks>A01</remarks>
        [EnumMember(Value = "GUELTIGES_PREISBLATT_VERSENDET")] 
        GUELTIGES_PREISBLATT_VERSENDET,

        /// <summary> GUELTIGER_SPERRAUFTRAG_VORHANDEN </summary>
        /// <remarks>A02</remarks>
        [EnumMember(Value = "GUELTIGER_SPERRAUFTRAG_VORHANDEN")] 
        GUELTIGER_SPERRAUFTRAG_VORHANDEN,

        /// <summary> KORREKTE_ARTIKEL_ID_IN_RECHNUNG </summary>
        /// <remarks>A03</remarks>
        [EnumMember(Value = "KORREKTE_ARTIKEL_ID_IN_RECHNUNG")] 
        KORREKTE_ARTIKEL_ID_IN_RECHNUNG,

        /// <summary> KORREKTER_PREIS_ZU_GUELTIGEM_PREISBLATT_IN_RECHNUNG </summary>
        /// <remarks>A04</remarks>
        [EnumMember(Value = "KORREKTER_PREIS_ZU_GUELTIGEM_PREISBLATT_IN_RECHNUNG")] 
        KORREKTER_PREIS_ZU_GUELTIGEM_PREISBLATT_IN_RECHNUNG,

        /// <summary> GUELTIGES_PREISBLATT_FRISTGERECHT_VERSENDET </summary>
        /// <remarks>A06</remarks>
        [EnumMember(Value = "GUELTIGES_PREISBLATT_FRISTGERECHT_VERSENDET")] 
        GUELTIGES_PREISBLATT_FRISTGERECHT_VERSENDET,

        /// <summary> GUELTIGE_RECHNUNG_VORHANDEN </summary>
        /// <remarks>A07</remarks>
        [EnumMember(Value = "GUELTIGE_RECHNUNG_VORHANDEN")] 
        GUELTIGE_RECHNUNG_VORHANDEN,

        /// <summary> KORREKTER_PREIS_IN_RECHNUNG_ABGERECHNET </summary>
        /// <remarks>A09</remarks>
        [EnumMember(Value = "KORREKTER_PREIS_IN_RECHNUNG_ABGERECHNET")] 
        KORREKTER_PREIS_IN_RECHNUNG_ABGERECHNET,

        /// <summary> GUELTIGES_PREISBLATT_BLINDARBEIT_VERSENDET </summary>
        /// <remarks>A12</remarks>
        [EnumMember(Value = "GUELTIGES_PREISBLATT_BLINDARBEIT_VERSENDET")] 
        GUELTIGES_PREISBLATT_BLINDARBEIT_VERSENDET,

        /// <summary> KORREKTE_ARTIKEL_ID_FUER_ABRECHNUNG_STORNIERTER_SPERRAUFTRAG_ANGEGEBEN </summary>
        /// <remarks>A15</remarks>
        [EnumMember(Value = "KORREKTE_ARTIKEL_ID_FUER_ABRECHNUNG_STORNIERTER_SPERRAUFTRAG_ANGEGEBEN")] 
        KORREKTE_ARTIKEL_ID_FUER_ABRECHNUNG_STORNIERTER_SPERRAUFTRAG_ANGEGEBEN,
    }
}