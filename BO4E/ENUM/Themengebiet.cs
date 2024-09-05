using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Über dieses ENUM kann eine thematische Zuordnung, beispielsweise eines Ansprechpartners, vorgenommen werden.</summary>
public enum Themengebiet
{
    /// <summary>Allgemeiner Informationsaustausch</summary>
    [EnumMember(Value = "ALLGEMEINER_INFORMATIONSAUSTAUSCH")]
    ALLGEMEINER_INFORMATIONSAUSTAUSCH,

    /// <summary>An- und Abmeldung</summary>
    [EnumMember(Value = "AN_UND_ABMELDUNG")]
    AN_UND_ABMELDUNG,

    /// <summary>Ansprechpartner Allgemein</summary>
    [EnumMember(Value = "ANSPRECHPARTNER_ALLGEMEIN")]
    ANSPRECHPARTNER_ALLGEMEIN,

    /// <summary>Ansprechpartner BDEW/DVGW</summary>
    [EnumMember(Value = "ANSPRECHPARTNER_BDEW_DVGW")]
    ANSPRECHPARTNER_BDEW_DVGW,

    /// <summary>Ansprechpartner IT/Technik</summary>
    [EnumMember(Value = "ANSPRECHPARTNER_IT_TECHNIK")]
    ANSPRECHPARTNER_IT_TECHNIK,

    /// <summary>Bilanzierung</summary>
    [EnumMember(Value = "BILANZIERUNG")]
    BILANZIERUNG,

    /// <summary>Bilanzkreiskoordinator</summary>
    [EnumMember(Value = "BILANZKREISKOORDINATOR")]
    BILANZKREISKOORDINATOR,

    /// <summary>Bilanzkreisverantwortlicher</summary>
    [EnumMember(Value = "BILANZKREISVERANTWORTLICHER")]
    BILANZKREISVERANTWORTLICHER,

    /// <summary>Datenformate, Zertifikate, Verschlüsselungen</summary>
    [EnumMember(Value = "DATENFORMATE_ZERTIFIKATE_VERSCHLUESSELUNGEN")]
    DATENFORMATE_ZERTIFIKATE_VERSCHLUESSELUNGEN,

    /// <summary>Debitorenmanagement</summary>
    [EnumMember(Value = "DEBITORENMANAGEMENT")]
    DEBITORENMANAGEMENT,

    /// <summary>Demand-Side-Management</summary>
    [EnumMember(Value = "DEMAND_SIDE_MANAGEMENT")]
    DEMAND_SIDE_MANAGEMENT,

    /// <summary>EDI-Vereinbarung</summary>
    [EnumMember(Value = "EDI_VEREINBARUNG")]
    EDI_VEREINBARUNG,

    /// <summary>EDIFACT</summary>
    [EnumMember(Value = "EDIFACT")]
    EDIFACT,

    /// <summary>Energiedatenmanagement</summary>
    [EnumMember(Value = "ENERGIEDATENMANAGEMENT")]
    ENERGIEDATENMANAGEMENT,

    /// <summary>Fahrplanmanagement</summary>
    [EnumMember(Value = "FAHRPLANMANAGEMENT")]
    FAHRPLANMANAGEMENT,

    /// <summary>Format:ALOCAT</summary>
    [EnumMember(Value = "ALOCAT")]
    ALOCAT,

    /// <summary>Format:APERAK</summary>
    [EnumMember(Value = "APERAK")]
    APERAK,

    /// <summary>Format:CONTRL</summary>
    [EnumMember(Value = "CONTRL")]
    CONTRL,

    /// <summary>Format:INVOIC</summary>
    [EnumMember(Value = "INVOIC")]
    INVOIC,

    /// <summary>Format:MSCONS</summary>
    [EnumMember(Value = "MSCONS")]
    MSCONS,

    /// <summary>Format:ORDERS</summary>
    [EnumMember(Value = "ORDERS")]
    ORDERS,

    /// <summary>Format:ORDERSP</summary>
    [EnumMember(Value = "ORDERSP")]
    ORDERSP,

    /// <summary>Format:REMADV</summary>
    [EnumMember(Value = "REMADV")]
    REMADV,

    /// <summary>Format:UTILMD</summary>
    [EnumMember(Value = "UTILMD")]
    UTILMD,

    /// <summary>GaBi Gas</summary>
    [EnumMember(Value = "GABI")]
    GABI,

    /// <summary>GeLi Gas</summary>
    [EnumMember(Value = "GELI")]
    GELI,

    /// <summary>Geräterückgabe</summary>
    [EnumMember(Value = "GERAETERUECKGABE")]
    GERAETERUECKGABE,

    /// <summary>Gerätewechsel</summary>
    [EnumMember(Value = "GERAETEWECHSEL")]
    GERAETEWECHSEL,

    /// <summary>GPKE</summary>
    [EnumMember(Value = "GPKE")]
    GPKE,

    /// <summary>Inbetriebnahme</summary>
    [EnumMember(Value = "INBETRIEBNAHME")]
    INBETRIEBNAHME,

    /// <summary>Kapazitätsmanagement</summary>
    [EnumMember(Value = "KAPAZITAETSMANAGEMENT")]
    KAPAZITAETSMANAGEMENT,

    /// <summary>Klärfälle</summary>
    [EnumMember(Value = "KLAERFAELLE")]
    KLAERFAELLE,

    /// <summary>Lastgänge RLM</summary>
    [EnumMember(Value = "LASTGAENGE_RLM")]
    LASTGAENGE_RLM,

    /// <summary>Lieferantenrahmenvertrag</summary>
    [EnumMember(Value = "LIEFERANTENRAHMENVERTRAG")]
    LIEFERANTENRAHMENVERTRAG,

    /// <summary>Lieferantenwechsel</summary>
    [EnumMember(Value = "LIEFERANTENWECHSEL")]
    LIEFERANTENWECHSEL,

    /// <summary>MaBiS</summary>
    [EnumMember(Value = "MABIS")]
    MABIS,

    /// <summary>Mahnwesen</summary>
    [EnumMember(Value = "MAHNWESEN")]
    MAHNWESEN,

    /// <summary>Marktgebietsverantwortlicher</summary>
    [EnumMember(Value = "MARKTGEBIETSVERANTWORTLICHER")]
    MARKTGEBIETSVERANTWORTLICHER,

    /// <summary>Marktkommunikation</summary>
    [EnumMember(Value = "MARKTKOMMUNIKATION")]
    MARKTKOMMUNIKATION,

    /// <summary>Mehr- Mindermengen</summary>
    [EnumMember(Value = "MEHR_MINDERMENGEN")]
    MEHR_MINDERMENGEN,

    /// <summary>MSB - MDL</summary>
    [EnumMember(Value = "MSB_MDL")]
    MSB_MDL,

    /// <summary>Netzabrechnung</summary>
    [EnumMember(Value = "NETZABRECHNUNG")]
    NETZABRECHNUNG,

    /// <summary>Netzentgelte</summary>
    [EnumMember(Value = "NETZENTGELTE")]
    NETZENTGELTE,

    /// <summary>Netzmanagement</summary>
    [EnumMember(Value = "NETZMANAGEMENT")]
    NETZMANAGEMENT,

    /// <summary>Recht</summary>
    [EnumMember(Value = "RECHT")]
    RECHT,

    /// <summary>Regulierungsmanagement</summary>
    [EnumMember(Value = "REGULIERUNGSMANAGEMENT")]
    REGULIERUNGSMANAGEMENT,

    /// <summary>Reklamationen</summary>
    [EnumMember(Value = "REKLAMATIONEN")]
    REKLAMATIONEN,

    /// <summary>Sperren/Entsperren/Inkasso</summary>
    [EnumMember(Value = "SPERREN_ENTSPERREN_INKASSO")]
    SPERREN_ENTSPERREN_INKASSO,

    /// <summary>Stammdaten</summary>
    [EnumMember(Value = "STAMMDATEN")]
    STAMMDATEN,

    /// <summary>Übermittlung_Störungsfälle</summary>
    [EnumMember(Value = "STOERUNGSFAELLE")]
    STOERUNGSFAELLE,

    /// <summary>Technische Fragen</summary>
    [EnumMember(Value = "TECHNISCHE_FRAGEN")]
    TECHNISCHE_FRAGEN,

    /// <summary>Umstellung INVOIC</summary>
    [EnumMember(Value = "UMSTELLUNG_INVOIC")]
    UMSTELLUNG_INVOIC,

    /// <summary>Verschlüsselung/Signatur</summary>
    [EnumMember(Value = "VERSCHLUESSELUNG_SIGNATUR")]
    VERSCHLUESSELUNG_SIGNATUR,

    /// <summary>Vertragsmanagement</summary>
    [EnumMember(Value = "VERTRAGSMANAGEMENT")]
    VERTRAGSMANAGEMENT,

    /// <summary>Vertrieb</summary>
    [EnumMember(Value = "VERTRIEB")]
    VERTRIEB,

    /// <summary>WiM</summary>
    [EnumMember(Value = "WIM")]
    WIM,

    /// <summary>Zählerstände SLP</summary>
    [EnumMember(Value = "ZAEHLERSTAENDE_SLP")]
    ZAEHLERSTAENDE_SLP,

    /// <summary>Zahlungsverkehr</summary>
    [EnumMember(Value = "ZAHLUNGSVERKEHR")]
    ZAHLUNGSVERKEHR,

    /// <summary>Zuordnungsvereinbarung</summary>
    [EnumMember(Value = "ZUORDNUNGSVEREINBARUNG")]
    ZUORDNUNGSVEREINBARUNG,
}
