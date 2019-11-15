namespace BO4E.ENUM
{
    /// <summary>Der Preis, auf den sich ein Auf- oder Abschlag bezieht.</summary>
    public enum AufAbschlagsziel
    {
        /// <summary>Auf/Abschlag auf den Arbeitspreis HT</summary>
        ARBEITSPREIS_HT,
        /// <summary>Auf/Abschlag auf den Arbeitspreis NT</summary>
        ARBEITSPREIS_NT,
        /// <summary>Auf/Abschlag auf den Arbeitspreis HT und NT</summary>
        ARBEITSPREIS_HT_NT,
        /// <summary>Auf/Abschlag auf den Grundpreis</summary>
        GRUNDPREIS,
        /// <summary>Auf/Abschlag auf den Gesamtpreis</summary>
        GESAMTPREIS
    }
}