using System;

namespace BO4E.meta
{
    /// <summary>
    /// A Custom attribute for make fields and properties multilingual 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Constructor | AttributeTargets.Field |
        AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
    public class FieldName : Attribute
    {
        /// <summary>
        /// "translated" field name
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// language of the translation
        /// </summary>
        public Language Language { get; }

        /// <summary>
        /// attribute is initialized by providing both language and translation
        /// </summary>
        /// <param name="text">translated field name</param>
        /// <param name="language">language of the translation</param>
        public FieldName(string text, Language language)
        {
            this.Text = text;
            this.Language = language;
        }
    }
}