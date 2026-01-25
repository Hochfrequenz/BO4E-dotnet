using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using BO4E.meta;
using Newtonsoft.Json.Linq;

namespace BO4E;

#nullable disable warnings
/// <summary>
///     extensions for both <see cref="BO.BusinessObject.UserProperties" /> and <see cref="COM.COM.UserProperties" />
/// </summary>
public static class UserPropertiesExtensions
{
    /// <summary>
    ///     try to get the Userproperty with key <paramref name="userPropertyKey" /> from <paramref name="parent" /> if
    ///     <paramref name="parent" />.UserProperties is not null and the key is present.
    /// </summary>
    /// <typeparam name="TUserProperty">
    ///     type expected to be found in the User Property with key
    ///     <paramref name="userPropertyKey" />
    /// </typeparam>
    /// <typeparam name="TParent">class implementing <see cref="IUserProperties" /></typeparam>
    /// <param name="parent">object implementing <see cref="IUserProperties" /></param>
    /// <param name="userPropertyKey">
    ///     key under which the <paramref name="value" /> is expected in <paramref name="parent" />
    ///     .UserProperties
    /// </param>
    /// <param name="value">default if false is returned, the stored value otherwise</param>
    /// <returns>true if found</returns>
    /// <exception cref="ArgumentNullException">iff <paramref name="userPropertyKey" /> is null or whitespace</exception>
    public static bool TryGetUserProperty<TUserProperty, TParent>(
        this TParent parent,
        string userPropertyKey,
        out TUserProperty value
    )
        where TParent : IUserProperties
    {
        var up = parent.UserProperties;
        if (string.IsNullOrWhiteSpace(userPropertyKey))
        {
            throw new ArgumentNullException(nameof(userPropertyKey));
        }

        if (up != null && up.TryGetValue(userPropertyKey, out var upToken))
        {
            switch (upToken)
            {
                case null:
                    value = default;
                    return false;

                case string token:
                    value = new JValue(token).Value<TUserProperty>();
                    break;

                case double d:
                    value = new JValue(d).Value<TUserProperty>();
                    break;

                case long l:
                    value = new JValue(l).Value<TUserProperty>();
                    break;

                case bool b:
                    value = new JValue(b).Value<TUserProperty>();
                    break;

                case JValue jValue:
                    value = jValue.Value<TUserProperty>();
                    break;

                default:
                    try
                    {
                        value = JsonSerializer.Deserialize<TUserProperty>(
                            ((JsonElement)upToken).GetRawText(),
                            Defaults.JsonSerializerDefaultOptions
                        );
                    }
                    catch (JsonException)
                    {
                        throw new FormatException(
                            $"Could not convert {((JsonElement)upToken).GetRawText()} to {typeof(TUserProperty).Name}"
                        );
                    }

                    break;
            }

            return true;
        }

        value = default;
        return false;
    }

    /// <summary>
    ///     same as <see cref="TryGetUserProperty{TUserProperty,TParent}" /> if <paramref name="userPropertyKey" /> was not
    ///     found or the user properties are null
    /// </summary>
    /// <typeparam name="TUserProperty">
    ///     type expected to be found in the User Property with key
    ///     <paramref name="userPropertyKey" />
    /// </typeparam>
    /// <param name="userPropertyKey">key of the <paramref name="parent" />.UserProperties dictionary</param>
    /// <typeparam name="TParent">class implementing <see cref="IUserProperties" /></typeparam>
    /// <param name="parent">object implementing <see cref="IUserProperties" /></param>
    /// <param name="defaultValue">
    ///     default value returned if <paramref name="parent" />.UserProperties are null or the key was
    ///     not found
    /// </param>
    /// <returns>the value stored in the userproperty or the default <paramref name="defaultValue" /></returns>
    /// <exception cref="ArgumentNullException">iff <paramref name="userPropertyKey" /> is null or whitespace</exception>
    public static TUserProperty GetUserProperty<TUserProperty, TParent>(
        this TParent parent,
        string userPropertyKey,
        TUserProperty defaultValue
    )
        where TParent : IUserProperties
    {
        if (
            parent != null
            && parent.TryGetUserProperty(userPropertyKey, out TUserProperty actualValue)
        )
        {
            return actualValue;
        }

        return defaultValue;
    }

    /// <summary>
    ///     Sets the <paramref name="value" /> as a UserProperty. If a property already exists, the value is overwritten, else
    ///     a new property is created
    /// </summary>
    /// <typeparam name="TUserProperty">
    ///     type expected to be found in the User Property with key
    ///     <paramref name="userPropertyKey" />
    /// </typeparam>
    /// <param name="userPropertyKey">key of the <paramref name="parent" />.UserProperties dictionary</param>
    /// <typeparam name="TParent">class implementing <see cref="IUserProperties" /></typeparam>
    /// <param name="parent">object implementing <see cref="IUserProperties" /></param>
    /// <param name="value">Value of the property</param>
    /// <returns></returns>
    public static void SetUserProperty<TUserProperty, TParent>(
        this TParent parent,
        string userPropertyKey,
        TUserProperty value
    )
        where TParent : IUserProperties
    {
        // if user properties don't exist already, create them
        if (parent.UserProperties == null)
        {
            parent.UserProperties = new Dictionary<string, object>();
        }

        // if there is already an value for the property, delete ist first
        if (parent.UserProperties.ContainsKey(userPropertyKey))
        {
            parent.UserProperties.Remove(userPropertyKey);
        }

        // set the value
        parent.UserProperties.Add(userPropertyKey, value);
    }

    /// <summary>
    ///     Removes the Value of a UserProperty.
    /// </summary>
    /// <param name="userPropertyKey">key of the <paramref name="parent" />.UserProperties dictionary</param>
    /// <typeparam name="TParent">class implementing <see cref="IUserProperties" /></typeparam>
    /// <param name="parent">object implementing <see cref="IUserProperties" /></param>
    /// <returns></returns>
    public static void RemoveUserProperty<TParent>(this TParent parent, string userPropertyKey)
        where TParent : IUserProperties
    {
        // if user properties don't exist we cannot remove anything
        if (parent.UserProperties == null)
        {
            return;
        }

        // if there is already an value for the property, delete it
        if (parent.UserProperties.ContainsKey(userPropertyKey))
        {
            parent.UserProperties.Remove(userPropertyKey);
        }
    }

    /// <summary>
    ///     test if the <paramref name="parent" />.UserProperty value under key <paramref name="userPropertyKey" /> equals
    ///     <paramref name="other" />.
    /// </summary>
    /// <typeparam name="TParent">class implementing <see cref="IUserProperties" /></typeparam>
    /// <typeparam name="TUserProperty">
    ///     type expected to be found in the User Property with key
    ///     <paramref name="userPropertyKey" />
    /// </typeparam>
    /// <param name="parent">object implementing <see cref="IUserProperties" /></param>
    /// <param name="userPropertyKey">key under which the value is expected</param>
    /// <param name="other">comparison value</param>
    /// <param name="ignoreWrongType">
    ///     set true to automatically catch <see cref="FormatException" /> if the cast to
    ///     <typeparamref name="TUserProperty" /> fails
    /// </param>
    /// <returns>
    ///     true iff <paramref name="parent" />.UserProperties!=null and the value stored under key
    ///     <paramref name="userPropertyKey" /> == <paramref name="other" />
    /// </returns>
    /// <exception cref="ArgumentNullException">iff <paramref name="userPropertyKey" /> is null or whitespace</exception>
    public static bool UserPropertyEquals<TUserProperty, TParent>(
        this TParent parent,
        string userPropertyKey,
        TUserProperty other,
        bool ignoreWrongType = true
    )
        where TParent : IUserProperties
    {
        if (parent.UserProperties == null)
        {
            return false;
        }

        try
        {
            return parent.EvaluateUserProperty<TUserProperty, bool, TParent>(
                userPropertyKey,
                value =>
                {
                    if (value == null && other != null)
                    {
                        return false;
                    }

                    return value == null || value.Equals(other);
                }
            );
        }
        catch (FormatException) when (ignoreWrongType)
        {
            return false;
        }
    }

    /// <summary>
    ///     Apply <paramref name="evaluation" /> to the user property under <paramref name="userPropertyKey" /> if it exists
    /// </summary>
    /// <typeparam name="TUserProperty">type of the userproperty value</typeparam>
    /// <typeparam name="TEvaluationResult">type of the expected result</typeparam>
    /// <typeparam name="TParent">class implementing <see cref="IUserProperties" /></typeparam>
    /// <param name="parent">object implementing <see cref="IUserProperties" /></param>
    /// <param name="userPropertyKey">key under which the value is expected</param>
    /// <param name="evaluation">function to generate result from key value if present</param>
    /// <returns>result of <paramref name="evaluation" /> if the key exists, default otherwise</returns>
    /// <exception cref="ArgumentNullException">iff <paramref name="userPropertyKey" /> is null or whitespace</exception>
    public static TEvaluationResult EvaluateUserProperty<TUserProperty, TEvaluationResult, TParent>(
        this TParent parent,
        string userPropertyKey,
        Func<TUserProperty, TEvaluationResult> evaluation
    )
        where TParent : IUserProperties
    {
        var up = parent.UserProperties;
        if (up == null)
        {
            throw new ArgumentNullException(nameof(up));
        }

        return parent.TryGetUserProperty<TUserProperty, TParent>(userPropertyKey, out var value)
            ? evaluation(value)
            : default;
    }

    /// <summary>
    ///     set the value of flag <paramref name="flagKey" /> to <paramref name="flagValue" />.
    ///     If there is no such flag or not user properties yet, they will be created.
    /// </summary>
    /// <remarks>
    ///     "having a flag set" means that the Business Object has a UserProperty entry that has
    ///     <paramref name="flagKey" /> as key and the value of the user property is true.
    /// </remarks>
    /// <param name="parent">
    ///     object that implements <see cref="IUserProperties" /> (so either inheriting from
    ///     <see cref="BO4E.BO.BusinessObject" /> or <see cref="BO4E.COM.COM" />
    /// </param>
    /// <param name="flagKey">key in the userproperties that should hold the value <paramref name="flagValue" /></param>
    /// <param name="flagValue">flag value, use null to remove the flag</param>
    /// <returns>true iff userProperties had been modified, false if not</returns>
    public static bool SetFlag<TParent>(this TParent parent, string flagKey, bool? flagValue = true)
        where TParent : class, IUserProperties
    {
        if (string.IsNullOrWhiteSpace(flagKey))
        {
            throw new ArgumentNullException(nameof(flagKey));
        }

        if (parent.UserProperties == null)
        {
            parent.UserProperties = new Dictionary<string, object>();
            if (!flagValue.HasValue)
            {
                return false;
            }
        }
        else if (flagValue.HasValue && flagValue.Value == parent.HasFlagSet(flagKey))
        {
            return false;
        }

        if (!flagValue.HasValue)
        {
            if (!parent.UserProperties.ContainsKey(flagKey))
            {
                return false;
            }

            parent.UserProperties.Remove(flagKey);
            return true;
        }

        try
        {
            if (
                parent.TryGetUserProperty<bool?, TParent>(flagKey, out var existingValue)
                && existingValue == flagValue.Value
            )
            {
                return false;
            }
        }
        catch (FormatException fe) when (fe.Message.StartsWith("Could not convert"))
        {
            // see unittest TestConvertingUserPropertyToBoolean
        }
        parent.UserProperties[flagKey] = flagValue.Value;
        return true;
    }

    /// <summary>
    ///     checks if the BusinessObject has a flag set.
    /// </summary>
    /// <param name="parent">
    ///     object that implements <see cref="IUserProperties" /> (so either inheriting from
    ///     <see cref="BO4E.BO.BusinessObject" /> or <see cref="BO4E.COM.COM" />
    /// </param>
    /// <remarks>
    ///     "having a flag set" means that the Business Object has a UserProperty entry that has
    ///     <paramref name="flagKey" /> as key and the value of the user property is true.
    /// </remarks>
    /// <param name="flagKey"></param>
    /// <returns>true iff flag is set and has value true</returns>
    public static bool HasFlagSet<TParent>(this TParent parent, string flagKey)
        where TParent : class, IUserProperties
    {
        if (string.IsNullOrWhiteSpace(flagKey))
        {
            throw new ArgumentNullException(nameof(flagKey));
        }

        try
        {
            return parent.UserProperties != null && parent.UserPropertyEquals(flagKey, (bool?)true);
        }
        catch (ArgumentNullException ane) when (ane.ParamName == "value")
        {
            return false;
        }
    }

    #region UserProperties Emptiness Check

    /// <summary>
    ///     Cache for properties that need to be checked recursively per type.
    ///     Key: Type, Value: Array of PropertyInfo for properties that are IUserProperties or collections of IUserProperties.
    /// </summary>
    private static readonly ConcurrentDictionary<Type, PropertyInfo[]> PropertiesToCheckCache =
        new();

    /// <summary>
    ///     Checks if the <see cref="IUserProperties.UserProperties" /> dictionary is empty.
    ///     Empty means the dictionary is either null or has no entries.
    /// </summary>
    /// <remarks>
    ///     This method checks only the immediate object, not nested objects.
    ///     Use <see cref="HasAllEmptyUserPropertiesRecursive{TParent}" /> for recursive checking.
    ///     An empty UserProperties indicates that all JSON fields could be mapped to model properties.
    /// </remarks>
    /// <typeparam name="TParent">Type implementing <see cref="IUserProperties" /></typeparam>
    /// <param name="parent">The object to check</param>
    /// <returns>true if UserProperties is null or empty; false if it contains any entries</returns>
    public static bool HasEmptyUserProperties<TParent>(this TParent parent)
        where TParent : class, IUserProperties
    {
        if (parent == null)
        {
            return true;
        }

        return parent.UserProperties == null || parent.UserProperties.Count == 0;
    }

    /// <summary>
    ///     Recursively checks if this object and all nested <see cref="IUserProperties" /> objects
    ///     have empty UserProperties dictionaries.
    /// </summary>
    /// <remarks>
    ///     This method traverses all public properties that are either <see cref="IUserProperties" />
    ///     or collections containing <see cref="IUserProperties" /> items (e.g., List, arrays).
    ///     Property metadata is cached per type for performance on repeated calls.
    ///     Circular references are handled by tracking visited objects.
    /// </remarks>
    /// <typeparam name="TParent">Type implementing <see cref="IUserProperties" /></typeparam>
    /// <param name="parent">The root object to check</param>
    /// <param name="nonEmptyPaths">
    ///     When returning false, contains paths to objects with non-empty UserProperties.
    ///     Paths use dot notation with array indices, e.g., "Energieverbrauch[0]" or "Property.SubProperty[2]".
    ///     When returning true, this list is empty.
    /// </param>
    /// <returns>true if all UserProperties (this object and all nested) are empty; false otherwise</returns>
    public static bool HasAllEmptyUserPropertiesRecursive<TParent>(
        this TParent parent,
        out IReadOnlyList<string> nonEmptyPaths
    )
        where TParent : class, IUserProperties
    {
        var paths = new List<string>();
        var visited = new HashSet<object>(ReferenceEqualityComparer.Instance);

        CheckRecursive(parent, string.Empty, paths, visited);

        nonEmptyPaths = paths;
        return paths.Count == 0;
    }

    /// <summary>
    ///     Internal recursive implementation for checking UserProperties emptiness.
    /// </summary>
    private static void CheckRecursive(
        object obj,
        string currentPath,
        List<string> nonEmptyPaths,
        HashSet<object> visited
    )
    {
        if (obj == null)
        {
            return;
        }

        // Prevent infinite loops from circular references
        if (!visited.Add(obj))
        {
            return;
        }

        // Check if this object implements IUserProperties
        if (obj is IUserProperties userPropertiesObj)
        {
            if (
                userPropertiesObj.UserProperties != null
                && userPropertiesObj.UserProperties.Count > 0
            )
            {
                nonEmptyPaths.Add(string.IsNullOrEmpty(currentPath) ? "(root)" : currentPath);
            }
        }

        // Get cached properties to check for this type
        var propertiesToCheck = GetPropertiesToCheck(obj.GetType());

        foreach (var property in propertiesToCheck)
        {
            object propertyValue;
            try
            {
                propertyValue = property.GetValue(obj);
            }
            catch
            {
                // Skip properties that throw on access (e.g., not initialized)
                continue;
            }

            if (propertyValue == null)
            {
                continue;
            }

            var propertyPath = string.IsNullOrEmpty(currentPath)
                ? property.Name
                : $"{currentPath}.{property.Name}";

            // Check if it's a collection of IUserProperties
            var elementType = GetUserPropertiesElementType(property.PropertyType);
            if (elementType != null && propertyValue is IEnumerable enumerable)
            {
                var index = 0;
                foreach (var item in enumerable)
                {
                    if (item != null)
                    {
                        CheckRecursive(item, $"{propertyPath}[{index}]", nonEmptyPaths, visited);
                    }
                    index++;
                }
            }
            // Check if it's a single IUserProperties object
            else if (typeof(IUserProperties).IsAssignableFrom(property.PropertyType))
            {
                CheckRecursive(propertyValue, propertyPath, nonEmptyPaths, visited);
            }
        }
    }

    /// <summary>
    ///     Gets the cached array of properties that need recursive checking for a given type.
    /// </summary>
    private static PropertyInfo[] GetPropertiesToCheck(Type type)
    {
        return PropertiesToCheckCache.GetOrAdd(
            type,
            t =>
                t.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(p =>
                        p.CanRead
                        && (
                            typeof(IUserProperties).IsAssignableFrom(p.PropertyType)
                            || GetUserPropertiesElementType(p.PropertyType) != null
                        )
                    )
                    .ToArray()
        );
    }

    /// <summary>
    ///     Gets the element type if the given type is a collection of IUserProperties.
    ///     Returns null if not a collection or elements don't implement IUserProperties.
    /// </summary>
    private static Type GetUserPropertiesElementType(Type type)
    {
        // Skip string (implements IEnumerable<char>)
        if (type == typeof(string))
        {
            return null;
        }

        // Check if type itself is IEnumerable<T> (e.g., property declared as IEnumerable<SomeType>)
        // GetInterfaces() doesn't include the type itself when the type IS the interface
        if (
            type.IsGenericType
            && type.GetGenericTypeDefinition() == typeof(IEnumerable<>)
        )
        {
            var elementType = type.GetGenericArguments()[0];
            if (typeof(IUserProperties).IsAssignableFrom(elementType))
            {
                return elementType;
            }
        }

        // Check for generic IEnumerable<T> in implemented interfaces where T : IUserProperties
        foreach (
            var interfaceType in type.GetInterfaces()
                .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEnumerable<>))
        )
        {
            var elementType = interfaceType.GetGenericArguments()[0];
            if (typeof(IUserProperties).IsAssignableFrom(elementType))
            {
                return elementType;
            }
        }

        // Check for arrays
        if (type.IsArray)
        {
            var elementType = type.GetElementType();
            if (elementType != null && typeof(IUserProperties).IsAssignableFrom(elementType))
            {
                return elementType;
            }
        }

        return null;
    }

    /// <summary>
    ///     Comparer that uses reference equality for the visited set.
    /// </summary>
    private sealed class ReferenceEqualityComparer : IEqualityComparer<object>
    {
        public static readonly ReferenceEqualityComparer Instance = new();

        private ReferenceEqualityComparer() { }

        public new bool Equals(object x, object y) => ReferenceEquals(x, y);

        public int GetHashCode(object obj) =>
            System.Runtime.CompilerServices.RuntimeHelpers.GetHashCode(obj);
    }

    #endregion
}
