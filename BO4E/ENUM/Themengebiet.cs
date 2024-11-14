using System.Runtime.Serialization;

namespace BO4E.ENUM;

/// <summary>Über dieses ENUM kann eine thematische Zuordnung, beispielsweise eines Ansprechpartners, vorgenommen werden.</summary>
public enum Themengebiet
{
    /// <summary>Allgemeiner Informationsaustausch</summary>
    [EnumMember(Value = "ALLGEMEINER_INFORMATIONSAUSTAUSCH")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ALLGEMEINER_INFORMATIONSAUSTAUSCH")]
    ALLGEMEINER_INFORMATIONSAUSTAUSCH,

    /// <summary>An- und Abmeldung</summary>
    [EnumMember(Value = "AN_UND_ABMELDUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("AN_UND_ABMELDUNG")]
    AN_UND_ABMELDUNG,

    /// <summary>Ansprechpartner Allgemein</summary>
    [EnumMember(Value = "ANSPRECHPARTNER_ALLGEMEIN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ANSPRECHPARTNER_ALLGEMEIN")]
    ANSPRECHPARTNER_ALLGEMEIN,

    /// <summary>Ansprechpartner BDEW/DVGW</summary>
    [EnumMember(Value = "ANSPRECHPARTNER_BDEW_DVGW")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ANSPRECHPARTNER_BDEW_DVGW")]
    ANSPRECHPARTNER_BDEW_DVGW,

    /// <summary>Ansprechpartner IT/Technik</summary>
    [EnumMember(Value = "ANSPRECHPARTNER_IT_TECHNIK")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ANSPRECHPARTNER_IT_TECHNIK")]
    ANSPRECHPARTNER_IT_TECHNIK,

    /// <summary>Bilanzierung</summary>
    [EnumMember(Value = "BILANZIERUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BILANZIERUNG")]
    BILANZIERUNG,

    /// <summary>Bilanzkreiskoordinator</summary>
    [EnumMember(Value = "BILANZKREISKOORDINATOR")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BILANZKREISKOORDINATOR")]
    BILANZKREISKOORDINATOR,

    /// <summary>Bilanzkreisverantwortlicher</summary>
    [EnumMember(Value = "BILANZKREISVERANTWORTLICHER")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BILANZKREISVERANTWORTLICHER")]
    BILANZKREISVERANTWORTLICHER,

    /// <summary>Datenformate, Zertifikate, Verschlüsselungen</summary>
    [EnumMember(Value = "DATENFORMATE_ZERTIFIKATE_VERSCHLUESSELUNGEN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName(
        "DATENFORMATE_ZERTIFIKATE_VERSCHLUESSELUNGEN"
    )]
    DATENFORMATE_ZERTIFIKATE_VERSCHLUESSELUNGEN,

    /// <summary>Debitorenmanagement</summary>
    [EnumMember(Value = "DEBITORENMANAGEMENT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("DEBITORENMANAGEMENT")]
    DEBITORENMANAGEMENT,

    /// <summary>Demand-Side-Management</summary>
    [EnumMember(Value = "DEMAND_SIDE_MANAGEMENT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("DEMAND_SIDE_MANAGEMENT")]
    DEMAND_SIDE_MANAGEMENT,

    /// <summary>EDI-Vereinbarung</summary>
    [EnumMember(Value = "EDI_VEREINBARUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("EDI_VEREINBARUNG")]
    EDI_VEREINBARUNG,

    /// <summary>EDIFACT</summary>
    [EnumMember(Value = "EDIFACT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("EDIFACT")]
    EDIFACT,

    /// <summary>Energiedatenmanagement</summary>
    [EnumMember(Value = "ENERGIEDATENMANAGEMENT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ENERGIEDATENMANAGEMENT")]
    ENERGIEDATENMANAGEMENT,

    /// <summary>Fahrplanmanagement</summary>
    [EnumMember(Value = "FAHRPLANMANAGEMENT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("FAHRPLANMANAGEMENT")]
    FAHRPLANMANAGEMENT,

    /// <summary>Format:ALOCAT</summary>
    [EnumMember(Value = "ALOCAT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ALOCAT")]
    ALOCAT,

    /// <summary>Format:APERAK</summary>
    [EnumMember(Value = "APERAK")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("APERAK")]
    APERAK,

    /// <summary>Format:CONTRL</summary>
    [EnumMember(Value = "CONTRL")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("CONTRL")]
    CONTRL,

    /// <summary>Format:INVOIC</summary>
    [EnumMember(Value = "INVOIC")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("INVOIC")]
    INVOIC,

    /// <summary>Format:MSCONS</summary>
    [EnumMember(Value = "MSCONS")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MSCONS")]
    MSCONS,

    /// <summary>Format:ORDERS</summary>
    [EnumMember(Value = "ORDERS")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ORDERS")]
    ORDERS,

    /// <summary>Format:ORDERSP</summary>
    [EnumMember(Value = "ORDERSP")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ORDERSP")]
    ORDERSP,

    /// <summary>Format:REMADV</summary>
    [EnumMember(Value = "REMADV")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("REMADV")]
    REMADV,

    /// <summary>Format:UTILMD</summary>
    [EnumMember(Value = "UTILMD")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("UTILMD")]
    UTILMD,

    /// <summary>GaBi Gas</summary>
    [EnumMember(Value = "GABI")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GABI")]
    GABI,

    /// <summary>GeLi Gas</summary>
    [EnumMember(Value = "GELI")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GELI")]
    GELI,

    /// <summary>Geräterückgabe</summary>
    [EnumMember(Value = "GERAETERUECKGABE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GERAETERUECKGABE")]
    GERAETERUECKGABE,

    /// <summary>Gerätewechsel</summary>
    [EnumMember(Value = "GERAETEWECHSEL")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GERAETEWECHSEL")]
    GERAETEWECHSEL,

    /// <summary>GPKE</summary>
    [EnumMember(Value = "GPKE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("GPKE")]
    GPKE,

    /// <summary>Inbetriebnahme</summary>
    [EnumMember(Value = "INBETRIEBNAHME")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("INBETRIEBNAHME")]
    INBETRIEBNAHME,

    /// <summary>Kapazitätsmanagement</summary>
    [EnumMember(Value = "KAPAZITAETSMANAGEMENT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("KAPAZITAETSMANAGEMENT")]
    KAPAZITAETSMANAGEMENT,

    /// <summary>Klärfälle</summary>
    [EnumMember(Value = "KLAERFAELLE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("KLAERFAELLE")]
    KLAERFAELLE,

    /// <summary>Lastgänge RLM</summary>
    [EnumMember(Value = "LASTGAENGE_RLM")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("LASTGAENGE_RLM")]
    LASTGAENGE_RLM,

    /// <summary>Lieferantenrahmenvertrag</summary>
    [EnumMember(Value = "LIEFERANTENRAHMENVERTRAG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("LIEFERANTENRAHMENVERTRAG")]
    LIEFERANTENRAHMENVERTRAG,

    /// <summary>Lieferantenwechsel</summary>
    [EnumMember(Value = "LIEFERANTENWECHSEL")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("LIEFERANTENWECHSEL")]
    LIEFERANTENWECHSEL,

    /// <summary>MaBiS</summary>
    [EnumMember(Value = "MABIS")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MABIS")]
    MABIS,

    /// <summary>Mahnwesen</summary>
    [EnumMember(Value = "MAHNWESEN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MAHNWESEN")]
    MAHNWESEN,

    /// <summary>Marktgebietsverantwortlicher</summary>
    [EnumMember(Value = "MARKTGEBIETSVERANTWORTLICHER")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MARKTGEBIETSVERANTWORTLICHER")]
    MARKTGEBIETSVERANTWORTLICHER,

    /// <summary>Marktkommunikation</summary>
    [EnumMember(Value = "MARKTKOMMUNIKATION")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MARKTKOMMUNIKATION")]
    MARKTKOMMUNIKATION,

    /// <summary>Mehr- Mindermengen</summary>
    [EnumMember(Value = "MEHR_MINDERMENGEN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MEHR_MINDERMENGEN")]
    MEHR_MINDERMENGEN,

    /// <summary>MSB - MDL</summary>
    [EnumMember(Value = "MSB_MDL")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MSB_MDL")]
    MSB_MDL,

    /// <summary>Netzabrechnung</summary>
    [EnumMember(Value = "NETZABRECHNUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("NETZABRECHNUNG")]
    NETZABRECHNUNG,

    /// <summary>Netzentgelte</summary>
    [EnumMember(Value = "NETZENTGELTE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("NETZENTGELTE")]
    NETZENTGELTE,

    /// <summary>Netzmanagement</summary>
    [EnumMember(Value = "NETZMANAGEMENT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("NETZMANAGEMENT")]
    NETZMANAGEMENT,

    /// <summary>Recht</summary>
    [EnumMember(Value = "RECHT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("RECHT")]
    RECHT,

    /// <summary>Regulierungsmanagement</summary>
    [EnumMember(Value = "REGULIERUNGSMANAGEMENT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("REGULIERUNGSMANAGEMENT")]
    REGULIERUNGSMANAGEMENT,

    /// <summary>Reklamationen</summary>
    [EnumMember(Value = "REKLAMATIONEN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("REKLAMATIONEN")]
    REKLAMATIONEN,

    /// <summary>Sperren/Entsperren/Inkasso</summary>
    [EnumMember(Value = "SPERREN_ENTSPERREN_INKASSO")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SPERREN_ENTSPERREN_INKASSO")]
    SPERREN_ENTSPERREN_INKASSO,

    /// <summary>Stammdaten</summary>
    [EnumMember(Value = "STAMMDATEN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("STAMMDATEN")]
    STAMMDATEN,

    /// <summary>Übermittlung_Störungsfälle</summary>
    [EnumMember(Value = "STOERUNGSFAELLE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("STOERUNGSFAELLE")]
    STOERUNGSFAELLE,

    /// <summary>Technische Fragen</summary>
    [EnumMember(Value = "TECHNISCHE_FRAGEN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("TECHNISCHE_FRAGEN")]
    TECHNISCHE_FRAGEN,

    /// <summary>Umstellung INVOIC</summary>
    [EnumMember(Value = "UMSTELLUNG_INVOIC")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("UMSTELLUNG_INVOIC")]
    UMSTELLUNG_INVOIC,

    /// <summary>Verschlüsselung/Signatur</summary>
    [EnumMember(Value = "VERSCHLUESSELUNG_SIGNATUR")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("VERSCHLUESSELUNG_SIGNATUR")]
    VERSCHLUESSELUNG_SIGNATUR,

    /// <summary>Vertragsmanagement</summary>
    [EnumMember(Value = "VERTRAGSMANAGEMENT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("VERTRAGSMANAGEMENT")]
    VERTRAGSMANAGEMENT,

    /// <summary>Vertrieb</summary>
    [EnumMember(Value = "VERTRIEB")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("VERTRIEB")]
    VERTRIEB,

    /// <summary>WiM</summary>
    [EnumMember(Value = "WIM")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("WIM")]
    WIM,

    /// <summary>Zählerstände SLP</summary>
    [EnumMember(Value = "ZAEHLERSTAENDE_SLP")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ZAEHLERSTAENDE_SLP")]
    ZAEHLERSTAENDE_SLP,

    /// <summary>Zahlungsverkehr</summary>
    [EnumMember(Value = "ZAHLUNGSVERKEHR")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ZAHLUNGSVERKEHR")]
    ZAHLUNGSVERKEHR,

    /// <summary>Zuordnungsvereinbarung</summary>
    [EnumMember(Value = "ZUORDNUNGSVEREINBARUNG")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ZUORDNUNGSVEREINBARUNG")]
    ZUORDNUNGSVEREINBARUNG,
}
