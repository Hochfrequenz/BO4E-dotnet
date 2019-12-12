namespace BO4E.ENUM {

/// <summary>Auflistung möglicher abzurechnender Dienstleistungen.</summary>
public enum Dienstleistungstyp {
	/// <summary>Datenbereitstellung täglich</summary>
	DATENBEREITSTELLUNG_TAEGLICH,
	/// <summary>Datenbereitstellung wöchentlich</summary>
	DATENBEREITSTELLUNG_WOECHENTLICH,
	/// <summary>Datenbereitstellung monatlich</summary>
	DATENBEREITSTELLUNG_MONATLICH,
	/// <summary>Datenbereitstellung jährlich</summary>
	DATENBEREITSTELLUNG_JAEHRLICH,
	/// <summary>Datenbereitstellung historischer Lastgänge</summary>
	DATENBEREITSTELLUNG_HISTORISCHE_LG,
	/// <summary>Datenbereitstellung stündlich</summary>
	DATENBEREITSTELLUNG_STUENDLICH,
	/// <summary>Datenbereitstellung vierteljährlich</summary>
	DATENBEREITSTELLUNG_VIERTELJAEHRLICH,
	/// <summary>Datenbereitstellung halbjährlich</summary>
	DATENBEREITSTELLUNG_HALBJAEHRLICH,
	/// <summary>Datenbereitstellung monatlich zusätzlich</summary>
	DATENBEREITSTELLUNG_MONATLICH_ZUSAETZLICH,
	/// <summary>Datenbereitstellung einmalig</summary>
	DATENBEREITSTELLUNG_EINMALIG,
	/// <summary>Auslesung 2x täglich mittels Fernauslesung</summary>
	AUSLESUNG_2X_TAEGLICH_FERNAUSLESUNG,
	/// <summary>Auslesung täglich mittels Fernauslesung</summary>
	AUSLESUNG_TAEGLICH_FERNAUSLESUNG,
	/// <summary>Auslesung, LGK, Manuell vom Messstellenbetreiber vorgenommen</summary>
	AUSLESUNG_LGK_MANUELL_MSB,
	/// <summary>Auslesung monatlich bei SLP mittels Fernauslesung</summary>
	AUSLESUNG_MONATLICH_SLP_FERNAUSLESUNG,
	/// <summary>Auslesung jährlich bei SLP mittels Fernauslesung</summary>
	AUSLESUNG_JAEHRLICH_SLP_FERNAUSLESUNG,
	/// <summary>Auslesung mit mobiler Daten Erfassung (MDE) SLP</summary>
	AUSLESUNG_MDE_SLP,
	/// <summary>Ablesung monatlich SLP</summary>
	ABLESUNG_MONATLICH_SLP,
	/// <summary>Ablesung vierteljährlich SLP</summary>
	ABLESUNG_VIERTELJAEHRLICH_SLP,
	/// <summary>Ablesung halbjährlich SLP</summary>
	ABLESUNG_HALBJAEHRLICH_SLP,
	/// <summary>Ablesung jährlich SLP</summary>
	ABLESUNG_JAEHRLICH_SLP,
	/// <summary>Auslesung bei SLP mittels Fernauslesung</summary>
	AUSLESUNG_SLP_FERNAUSLESUNG,
	/// <summary>Ablesung SLP, zusätzlich vom Messstellenbetreiber vorgenommen</summary>
	ABLESUNG_SLP_ZUSAETZLICH_MSB,
	/// <summary>Ablesung SLP, zusätzlich vom Kunden vorgenommen</summary>
	ABLESUNG_SLP_ZUSAETZLICH_KUNDE,
	/// <summary>Auslesung LGK, mittels Fernauslesung, zusätzlich vom Messstellenbetreiber vorgenommen</summary>
	AUSLESUNG_LGK_FERNAUSLESUNG_ZUSAETZLICH_MSB,
	/// <summary>Auslesung monatlich mittels Fernauslesung</summary>
	AUSLESUNG_MOATLICH_FERNAUSLESUNG,
	/// <summary>Auslesung stündlich mittels Fernauslesung</summary>
	AUSLESUNG_STUENDLICH_FERNAUSLESUNG,
	/// <summary>Ablesung monatlich LGK</summary>
	ABLESUNG_MONATLICH_LGK,
	/// <summary>Auslesung Temperaturmengenumwerter</summary>
	AUSLESUNG_TEMERATURMENGENUMWERTER,
	/// <summary>Auslesung Zustandsmengenumwerter</summary>
	AUSLESUNG_ZUSTANDSMENGENUMWERTER,
	/// <summary>Auslesung Systemmengenumwerter</summary>
	AUSLESUNG_SYSTEMMENGENUMWERTER,
	/// <summary>Auslesung je Vorgang SLP</summary>
	AUSLESUNG_VORGANG_SLP,
	/// <summary>Auslesung Kompaktmengenumwerter</summary>
	AUSLESUUNG_KOMPAKTMENGENUMWERTER,
	/// <summary>Auslesung mit mobiler Daten Erfassung (MDE) LGK</summary>
	AUSLESUNG_MDE_LGK,
	/// <summary>Sperrung einer SLP-Abnahmestelle</summary>
	SPERRUNG_SLP,
	/// <summary>Entsperrung einer SLP-Abnahmestelle</summary>
	ENTSPERRUNG_SLP,
	/// <summary>Sperrung einer RLM-Abnahmestelle</summary>
	SPERRUNG_RLM,
	/// <summary>Entsperrung einer RLM-Abnahmestelle</summary>
	ENTSPERRUNG_RLM,
	/// <summary>Mahnkosten</summary>
	MAHNKOSTEN,
	/// <summary>Inkassokosten</summary>
	INKASSOKOSTEN}
}
