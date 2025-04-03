using System.Runtime.Serialization;

namespace BO4E.meta;

/// <summary>
///     List of languages for making translatedJson in JsonConvert.SerializeObject() function.
/// </summary>
public enum Language
{
    /// <summary>
    ///     Englisch
    /// </summary>
    [EnumMember(Value = "EN")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("EN")]
    EN,

    /// <summary>
    ///     Deutsch
    /// </summary>
    [EnumMember(Value = "DE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("DE")]
    DE,

    /// <summary>
    ///     Französisch
    /// </summary>
    [EnumMember(Value = "FR")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("FR")]
    FR,

    /// <summary>
    ///     Spanisch
    /// </summary>
    [EnumMember(Value = "SP")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SP")]
    SP,
}
