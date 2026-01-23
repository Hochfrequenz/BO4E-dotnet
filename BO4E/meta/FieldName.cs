using System;

namespace BO4E.meta;

/// <summary>
///     A Custom attribute for make fields and properties multilingual
/// </summary>
[AttributeUsage(
    AttributeTargets.Class
        | AttributeTargets.Constructor
        | AttributeTargets.Field
        | AttributeTargets.Method
        | AttributeTargets.Property,
    AllowMultiple = true
)]
public class FieldName : Attribute
{
    /// <summary>
    ///     attribute is initialized by providing both language and translation
    /// </summary>
    /// <param name="text">translated field name</param>
    /// <param name="language">language of the translation</param>
    public FieldName(string text, Language language)
    {
        Text = text;
        Language = language;
    }

    /// <summary>
    ///     "translated" field name
    /// </summary>
    public string Text { get; }

    /// <summary>
    ///     language of the translation
    /// </summary>
    public Language Language { get; }
}
