using BO4E.meta;

namespace BO4E.ENUM
{
    /// <summary>Fallgruppenzuordnung nach edi@energy </summary>
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