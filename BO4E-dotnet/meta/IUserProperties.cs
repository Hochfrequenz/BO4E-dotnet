using BO4E.BO;

using System.Collections.Generic;

namespace BO4E.meta
{
    /// <summary>
    /// Any class implementing this interface has a userProperties dictionary.
    /// <seealso cref="BusinessObject.UserProperties"/>, <seealso cref="BO4E.COM.COM.UserProperties"/>.
    /// User Properties are key value pairs that are not part of the official BO4E Standard but can still be part of JSONs.
    /// </summary>
    public interface IUserProperties
    {
        /// <summary>
        /// <see cref="BusinessObject.UserProperties"/>, <see cref="BO4E.COM.COM.UserProperties"/>
        /// </summary>
        Dictionary<string, object> UserProperties { get; set; }
    }
}
