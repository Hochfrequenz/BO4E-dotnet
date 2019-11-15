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
        private readonly string _text;
        private readonly Language _language;
        /// <summary>
        /// "translated" field name
        /// </summary>
        public string text
        {
            get
            {
                return this._text;
            }
        }
        /// <summary>
        /// language of the translation
        /// </summary>
        public Language language
        {
            get
            {
                return this._language;
            }
        }

        /// <summary>
        /// attribute is intialized by providing both language and translation
        /// </summary>
        /// <param name="text">translated field name</param>
        /// <param name="language">language of the translation</param>
        public FieldName(string text, Language language)
        {
            this._text = text;
            this._language = language;
        }
    }
}