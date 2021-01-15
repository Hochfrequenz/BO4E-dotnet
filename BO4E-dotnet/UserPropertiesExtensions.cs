using System;
using System.Collections.Generic;

using BO4E.meta;

using Newtonsoft.Json.Linq;

namespace BO4E
{
    /// <summary>
    /// extensions for both <see cref="BO.BusinessObject.UserProperties"/> and <see cref="COM.COM.UserProperties"/>
    /// </summary>
    public static class UserPropertiesExtensions
    {
        /// <summary>
        /// try to get the Userproperty with key <paramref name="userPropertyKey"/> from <paramref name="parent"/> if <paramref name="parent"/>.UserProperties is not null and the key is present.
        /// </summary>
        /// <typeparam name="TUserProperty">type expected to be found in the User Property with key <paramref name="userPropertyKey"/></typeparam>
        /// <typeparam name="TParent">class implementing <see cref="IUserProperties"/></typeparam>
        /// <param name="parent">object implementing <see cref="IUserProperties"/></param>
        /// <param name="userPropertyKey">key under which the <paramref name="value"/> is expected in <paramref name="parent"/>.UserProperties</param>
        /// <param name="value">default if false is returned, the stored value otherwise</param>
        /// <returns>true if found</returns>
        /// <exception cref="ArgumentNullException">iff <paramref name="userPropertyKey"/> is null or whitespace</exception>
        public static bool TryGetUserProperty<TUserProperty, TParent>(this TParent parent, string userPropertyKey,
            out TUserProperty value) where TParent : IUserProperties
        {
            var up = parent.UserProperties;
            if (string.IsNullOrWhiteSpace(userPropertyKey)) throw new ArgumentNullException(nameof(userPropertyKey));
            if (up != null && up.TryGetValue(userPropertyKey, out var upToken))
            {
                if (upToken is null)
                {
                    value = default;
                    return false;
                }
                if (upToken is string token)
                {
                    value = new JValue(token).Value<TUserProperty>();
                }
                else if (upToken is double d)
                {
                    value = new JValue(d).Value<TUserProperty>();
                }
                else if (upToken is long l)
                {
                    value = new JValue(l).Value<TUserProperty>();
                }
                else if (upToken is bool b)
                {
                    value = new JValue(b).Value<TUserProperty>();
                }
                else if (upToken is JValue jValue)
                {
                    value = jValue.Value<TUserProperty>();
                }
                else
                {
                    value = System.Text.Json.JsonSerializer.Deserialize<TUserProperty>(((System.Text.Json.JsonElement)upToken).GetRawText());
                }
                return true;
            }

            value = default;
            return false;
        }

        /// <summary>
        /// same as <see cref="TryGetUserProperty{TUserProperty,TParent}"/> if <paramref name="userPropertyKey"/> was not found or the user properties are null
        /// </summary>
        /// <typeparam name="TUserProperty">type expected to be found in the User Property with key <paramref name="userPropertyKey"/></typeparam>
        /// <param name="userPropertyKey">key of the <paramref name="parent"/>.UserProperties dictionary</param>
        /// <typeparam name="TParent">class implementing <see cref="IUserProperties"/></typeparam>
        /// <param name="parent">object implementing <see cref="IUserProperties"/></param>
        /// <param name="defaultValue">default value returned if <paramref name="parent"/>.UserProperties are null or the key was not found</param>
        /// <returns>the value stored in the userproperty or the default <paramref name="defaultValue"/></returns>
        /// <exception cref="ArgumentNullException">iff <paramref name="userPropertyKey"/> is null or whitespace</exception>
        public static TUserProperty GetUserProperty<TUserProperty, TParent>(this TParent parent, string userPropertyKey,
            TUserProperty defaultValue) where TParent : IUserProperties
        {
            if (parent != null && parent.TryGetUserProperty(userPropertyKey, out TUserProperty actualValue))
            {
                return actualValue;
            }

            return defaultValue;
        }

        /// <summary>
        /// test if the <paramref name="parent"/>.UserProperty value under key <paramref name="userPropertyKey"/> equals <paramref name="other"/>.
        /// </summary>
        /// <typeparam name="TParent">class implementing <see cref="IUserProperties"/></typeparam>
        /// <typeparam name="TUserProperty">type expected to be found in the User Property with key <paramref name="userPropertyKey"/></typeparam>
        /// <param name="parent">object implementing <see cref="IUserProperties"/></param>
        /// <param name="userPropertyKey">key under which the value is expected</param>
        /// <param name="other">comparison value</param>
        /// <param name="ignoreWrongType">set true to automatically catch <see cref="FormatException"/> if the cast to <typeparamref name="TUserProperty"/> fails</param>
        /// <returns>true iff <paramref name="parent"/>.UserProperties!=null and the value stored under key <paramref name="userPropertyKey"/> == <paramref name="other"/></returns>
        /// <exception cref="ArgumentNullException">iff <paramref name="userPropertyKey"/> is null or whitespace</exception>
        public static bool UserPropertyEquals<TUserProperty, TParent>(this TParent parent, string userPropertyKey,
            TUserProperty other, bool ignoreWrongType = true) where TParent : IUserProperties
        {
            if (parent.UserProperties == null)
            {
                return false;
            }

            try
            {
                return parent.EvaluateUserProperty<TUserProperty, bool, TParent>(userPropertyKey, value =>
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
        /// Apply <paramref name="evaluation"/> to the user property under <paramref name="userPropertyKey"/> if it exists
        /// </summary>
        /// <typeparam name="TUserProperty">type of the userproperty value</typeparam>
        /// <typeparam name="TEvaluationResult">type of the expected result</typeparam>
        /// <typeparam name="TParent">class implementing <see cref="IUserProperties"/></typeparam>
        /// <param name="parent">object implementing <see cref="IUserProperties"/></param>
        /// <param name="userPropertyKey">key under which the value is expected</param>
        /// <param name="evaluation">function to generate result from key value if present</param>
        /// <returns>result of <paramref name="evaluation"/> if the key exists, default otherwise</returns>
        /// <exception cref="ArgumentNullException">iff <paramref name="userPropertyKey"/> is null or whitespace</exception>
        public static TEvaluationResult EvaluateUserProperty<TUserProperty, TEvaluationResult, TParent>(
            this TParent parent, string userPropertyKey, Func<TUserProperty, TEvaluationResult> evaluation)
            where TParent : IUserProperties
        {
            var up = parent.UserProperties;
            if (up == null) throw new ArgumentNullException(nameof(up));
            return parent.TryGetUserProperty<TUserProperty, TParent>(userPropertyKey, out var value)
                ? evaluation(value)
                : default;
        }

        /// <summary>
        /// set the value of flag <paramref name="flagKey"/> to <paramref name="flagValue"/>.
        /// If there is no such flag or not user properties yet, they will be created.
        /// </summary>
        /// <remarks>"having a flag set" means that the Business Object has a UserProperty entry that has <paramref name="flagKey"/> as key and the value of the user property is true.</remarks>
        /// <param name="parent">object that implements <see cref="IUserProperties"/> (so either inheriting from <see cref="BO4E.BO.BusinessObject"/> or <see cref="BO4E.COM.COM"/></param>
        /// <param name="flagKey">key in the userproperties that should hold the value <paramref name="flagValue"/></param>
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

            if (parent.TryGetUserProperty<bool?, TParent>(flagKey, out var existingValue) &&
                existingValue == flagValue.Value)
            {
                return false;
            }

            parent.UserProperties[flagKey] = flagValue.Value;
            return true;
        }

        /// <summary>
        /// checks if the BusinessObject has a flag set.
        /// </summary>
        /// <param name="parent">object that implements <see cref="IUserProperties"/> (so either inheriting from <see cref="BO4E.BO.BusinessObject"/> or <see cref="BO4E.COM.COM"/></param>
        /// <remarks>"having a flag set" means that the Business Object has a UserProperty entry that has <paramref name="flagKey"/> as key and the value of the user property is true.</remarks>
        /// <param name="flagKey"></param>
        /// <returns>true iff flag is set and has value true</returns>
        public static bool HasFlagSet<TParent>(this TParent parent, string flagKey) where TParent : class, IUserProperties
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
    }
}