namespace BO4E.ENUM
{
    /// <summary>Abbildung verschiedener Zustände, die im Rahmen der Rechnungsbearbeitung durchlaufen werden.</summary>
    public enum Rechnungsstatus
    {
        /// <summary>Eine Rechnung vom Netzbetreiber an den Netznutzer. (i.d.R. der Lieferant) über die Netznutzung.</summary>
        GEPRUEFT_OK,

        /// <summary>
        ///     Eine Rechnung vom Netzbetreiber an den Netznutzer (i.d.R. der Lieferant) zur Abrechnung von Mengen-Differenzen
        ///     zwischen Bilanzierung und Messung.
        /// </summary>
        GEPRUEFT_FEHLERHAFT,

        /// <summary>Rechnung eines Messstellenbetreibers an den Messkunden.</summary>
        GEBUCHT,

        /// <summary>Rechnungen zwischen einem Händler und Einkäufer von Energie.</summary>
        BEZAHLT
    }
}