using System.Runtime.Serialization;

namespace BO4E.meta
{
    /// <summary>
    ///     List of languages for making translatedJson in JsonConvert.SerializeObject() function.
    /// </summary>
    public enum Language
    {
        /// <summary>
        ///     Englisch
        /// </summary>
        [EnumMember(Value = "EN")]
        EN,

        /// <summary>
        ///     Deutsch
        /// </summary>
        [EnumMember(Value = "DE")]
        DE,

        /// <summary>
        ///     Französisch
        /// </summary>
        [EnumMember(Value = "FR")]
        FR,

        /// <summary>
        ///     Spanisch
        /// </summary>
        [EnumMember(Value = "SP")]
        SP,
    }
}