using BO4E.meta;

namespace BO4E.ENUM
{
    /// <summary>Fallgruppenzuordnung nach edi@energy (https://www.edi-energy.de/index.php?id=38&tx_bdew_bdew%5Buid%5D=1203&tx_bdew_bdew%5Baction%5D=download&tx_bdew_bdew%5Bcontroller%5D=Dokument&cHash=dfbb27270e6f18ea28b534007d7a9783)</summary>
    [NonOfficial(NonOfficialCategory.REGULATORY_REQUIREMENTS)]
    public enum Fallgruppenzuordnung
    {
        /// <summary>RLM mit Tagesband</summary>
        GABI_RLMmT,
        /// <summary>RLM ohne Tagesband</summary>
        GABI_RLMoT,
        /// <summary>RLM im Nominierungsersatzverfahren</summary>
        GABI_RLMNEV
    }
}