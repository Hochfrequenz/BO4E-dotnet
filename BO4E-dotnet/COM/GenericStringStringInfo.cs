using System.Collections.Generic;

namespace BO4E.COM
{
    /// <summary>
    /// generic object to retrieve values from a dummy Core Data Service View
    /// </summary>
    public class GenericStringStringInfo : COM
    {
        /// <summary>
        /// key (named differently because key is a reserved keyword)
        /// </summary>
        public string keyColumn;
        /// <summary>
        /// value
        /// </summary>
        public string value;

        /// <summary>
        /// convert object to a key value pair
        /// </summary>
        /// <returns></returns>
        public KeyValuePair<string, string> ToKeyValuePair()
        {
            return new KeyValuePair<string, string>(this.keyColumn, this.value);
        }
    }
}
