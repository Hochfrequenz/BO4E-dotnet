namespace BO4E.ENUM
{

    /// <summary>Aufzählung der Möglichkeiten für die Vergabe von Preisgarantien</summary>
    public enum Preisgarantietyp
    {
        /// <summary>Der Versorger gewährt eine Preisgarantie auf alle Preisbestandteile ohne die Umsatzsteuer</summary>
        ALLE_PREISBESTANDTEILE_NETTO,
        /// <summary>Der Versorger gewährt eine Preisgarantie auf alle Preisbestandteile ohne Abgaben (Energiesteuern, Umlagen, Abgaben)</summary>
        PREISBESTANDTEILE_OHNE_ABGABEN,
        /// <summary>Der Versorger garantiert ausschließlich den Energiepreis</summary>
        NUR_ENERGIEPREIS
    }
}