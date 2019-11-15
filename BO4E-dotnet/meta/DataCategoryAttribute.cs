using System;
using System.Collections.Generic;
using System.Linq;

namespace BO4E.meta
{    /// <summary>
     /// This class provides a custom attribute used to annotated fields of Business Objects with a data category.
     /// </summary>
     /// <seealso cref="DataCategory"/>
     /// <example>
     /// <code>
     /// public class Ansprechpartner : BusinessObject
     /// {
     ///    ...
     /// [DataCategory(DataCategory.NAME)]
     /// public string nachname;
     ///    ...
     /// [DataCategory(DataCategory.ADDRESS)]
     /// public string eMailAdresse;
     ///   ...
     /// }
     ///</code>
     ///</example>
    public class DataCategoryAttribute : Attribute
    {
        /// <summary>
        /// contains those DataCategories (<see cref="DataCategory"/>) annotated to the field.
        /// </summary>
        public HashSet<Enum> Mapping { get; set; }
        public DataCategoryAttribute(params object[] enums)
        {
            if (enums.Any(r => r.GetType().BaseType != typeof(Enum)))
            {
                throw new ArgumentException("enums");
            }
            Mapping = new HashSet<Enum>();
            foreach (Enum e in enums)
            {
                Mapping.Add(e);
            }
        }
    }
}
