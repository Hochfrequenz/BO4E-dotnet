using System.Collections.Generic;
using BO4E.BO;

namespace BO4E.meta;

/// <summary>
///     Any class implementing this interface has a userProperties dictionary.
///     <seealso cref="BusinessObject.UserProperties" />, <seealso cref="BO4E.COM.COM.UserProperties" />.
///     User Properties are key value pairs that are not part of the official BO4E Standard but can still be part of JSONs.
///     When deserializing JSON, any fields that cannot be mapped to model properties are stored in UserProperties.
///     To check if all fields were successfully mapped (i.e., UserProperties is empty), use the extension methods
///     <see cref="UserPropertiesExtensions.HasEmptyUserProperties{TParent}" /> for a single object or
///     <see cref="UserPropertiesExtensions.HasAllEmptyUserPropertiesRecursive{TParent}" /> to recursively check
///     all nested IUserProperties objects.
/// </summary>
public interface IUserProperties
{
    /// <summary>
    ///     Dictionary containing JSON fields that could not be mapped to model properties during deserialization.
    ///     Null or empty indicates all JSON fields were successfully mapped.
    ///     <seealso cref="BusinessObject.UserProperties" />, <seealso cref="BO4E.COM.COM.UserProperties" />
    ///     <seealso cref="UserPropertiesExtensions.HasEmptyUserProperties{TParent}" />
    ///     <seealso cref="UserPropertiesExtensions.HasAllEmptyUserPropertiesRecursive{TParent}" />
    /// </summary>
    IDictionary<string, object>? UserProperties { get; set; }
}
