using BO4E.BO;

using Newtonsoft.Json.Linq;

using System.Collections.Generic;
using BO4E.COM;

namespace BO4E.meta
{
    /// <summary>
    /// Any class implementing this interface has a userProperties dictionary.
    /// <seealso cref="BusinessObject.UserProperties"/>, <seealso cref="Com.UserProperties"/>.
    /// User Properties are key value pairs that are not part of the official BO4E Standard but can still be part of JSONs.
    /// </summary>
    public interface IUserProperties
    {
        /// <summary>
        /// <see cref="BusinessObject.UserProperties"/>, <see cref="Com.UserProperties"/>
        /// </summary>
        IDictionary<string, JToken> UserProperties { get; set; }
    }
}
