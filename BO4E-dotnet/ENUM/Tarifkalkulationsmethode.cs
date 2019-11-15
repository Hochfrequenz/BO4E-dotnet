namespace BO4E.ENUM {

/// <summary>Aulistung der verschiedenen Berechnungsmethoden für ein Preisblatt.</summary>
public enum Tarifkalkulationsmethode {
	/// <summary>Staffelmodell, d.h. die Gesamtmenge wird in eine Staffel eingeordnet und für die gesamte Menge gilt der so ermittelte Preis</summary>
	STAFFELN,
	/// <summary>Zonenmodell, d.h. die Gesamtmenge wird auf die Zonen aufgeteilt und für die Teilmengen gilt der jeweilige Preis der Zone.</summary>
	ZONEN,
	/// <summary>Bestabrechnung innerhalb der Staffelung</summary>
	BESTABRECHNUNG_STAFFEL,
	/// <summary>Preis für ein Paket (eine Menge).</summary>
	PAKETPREIS
}
}