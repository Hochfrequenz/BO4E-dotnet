namespace BO4E.ENUM
{
    /// <summary>Schwachlastfähigkeit Marktlokation</summary>
    public enum AbgabeArt
    {
        /// <summary>KAS: für alle konzessionsvertraglichen Sonderregelungen, die nicht in die Systematik der KAV eingegliedert sind</summary>
        KAS,
        /// <summary>SA: Sondervertragskunden  1 kV, Preis nach § 2 (3) (für Strom 0,11 ct/kWh und für Gas 0,03 ct/kWh)</summary>
        SA,
        /// <summary>SAS: Kennzeichnung, dass ein abweichender Preis für Sondervertragskunden vorliegt</summary>
        SAS,
        /// <summary>TA: Tarifkunden, für Strom § 2. (2) 1b HT bzw.ET(hohe KA) und für Gas § 2 (2) 2b</summary>
        TA,
        /// <summary>TAS: Kennzeichnung, dass ein abweichender Preis für Tarifkunden vorliegt</summary>
        TAS,
        /// <summary>TK: für Gas nach KAV § 2 (2) 2a bei ausschließlicher Nutzung zum Kochen und Warmwassererzeugung</summary>
        TK,
        /// <summary>TKS: Kennzeichnung, wenn nach KAV § 2 (2) 2a ein anderen Preis zu verwenden ist</summary>
        TKS,
        /// <summary>TS: für Strom mit Schwachlast § 2. (2) 1a NT(niedrige KA, 0,61 ct/kWh)</summary>
        TS,
        /// <summary>TSS: Kennzeichnung, dass ein abweichender Preis für Schwachlast angewendet wird</summary>
        TSS
    }
}