namespace BO4E.ENUM {

/// <summary>Aufzählung der Möglichkeiten zur Rechnungslegung in Ausschreibungen.</summary>
public enum Rechnungslegung {
	/// <summary>monatsscharfe Rechnung</summary>
	MONATSRECHN,
	/// <summary>Abschlag mit Monatsrechnung</summary>
	ABSCHL_MONATSRECHN,
	/// <summary>Abschlag mit Jahresrechnung</summary>
	ABSCHL_JAHRESRECHN,
	/// <summary>Monatsrechnung mit Jahresrechnung</summary>
	MONATSRECHN_JAHRESRECHN,
	/// <summary>Vorkasse</summary>
	VORKASSE
}
}