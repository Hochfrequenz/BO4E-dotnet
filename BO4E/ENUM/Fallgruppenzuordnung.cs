using BO4E.meta;

using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;

namespace BO4E.ENUM
{
    /// <summary>Fallgruppenzuordnung nach edi@energy </summary>
    [NonOfficial(NonOfficialCategory.REGULATORY_REQUIREMENTS)]
    public enum Fallgruppenzuordnung
    {
        /// <summary>RLM mit Tagesband</summary>
        [EnumMember(Value = "GABI_RLMMT")]
        GABI_RLMmT,
        /// <summary>RLM ohne Tagesband</summary>
        [EnumMember(Value = "GABI_RLMOT")]
        GABI_RLMoT,
        /// <summary>RLM im Nominierungsersatzverfahren</summary>
        [EnumMember(Value = "GABI_RLMNEV")]
        GABI_RLMNEV
    }
}