using Newtonsoft.Json.Linq;

using System;
using System.Collections.Generic;

namespace BO4E
{
    /// <summary>
    /// extensions for both <see cref="BO.BusinessObject.UserProperties"/> and <see cref="COM.COM.UserProperties"/>
    /// </summary>
    public static class UserPropertiesExtensions
    {
        /// <summary>
        /// try to get the Userproperty with key <paramref name="userPropertyKey"/> from <paramref name="up"/> if<paramref name="up"/> is not null and the key is present.
        /// </summary>
        /// <typeparam name="TUserProperty">type expected to be found in the User Property with key <paramref name="userPropertyKey"/></typeparam>
        /// <param name="up">user properties dict</param>
        /// <param name="userPropertyKey">key under which the <paramref name="value"/> is expected in <paramref name="up"/></param>
        /// <param name="value">default if false is returned, the stored value otherwise</param>
        /// <returns>true if found</returns>
        /// <exception cref="ArgumentNullException">iff <paramref name="userPropertyKey"/> is null or whitespace</exception>
        public static bool TryGetUserProperty<TUserProperty>(this IDictionary<string, JToken> up, string userPropertyKey, out TUserProperty value)
        {
            if (string.IsNullOrWhiteSpace(userPropertyKey)) throw new ArgumentNullException(nameof(userPropertyKey));
            if (up != null && up.TryGetValue(userPropertyKey, out var upToken))
            {
                value = upToken.Value<TUserProperty>();
                return true;
            }
            value = default;
            return false;
        }

        /// <summary>
        /// same as <see cref="TryGetUserProperty{TUserProperty}(IDictionary{string, JToken}, string, out TUserProperty)"/> but returns a default <paramref name="defaultValue"/> if <paramref name="userPropertyKey"/> was not found or the user properties are null
        /// </summary>
        /// <typeparam name="TUserProperty">type expected to be found in the User Property with key <paramref name="userPropertyKey"/></typeparam>
        /// <param name="userPropertyKey">key of the <paramref name="up"/> dictionary</param>
        /// <param name="up">user properties dict</param>
        /// <param name="defaultValue">default value returned if <paramref name="up"/> are null or the key was not found</param>
        /// <returns>the value stored in the userproperty or the default <paramref name="defaultValue"/></returns>
        /// <exception cref="ArgumentNullException">iff <paramref name="userPropertyKey"/> is null or whitespace</exception>
        public static TUserProperty GetUserProperty<TUserProperty>(this IDictionary<string, JToken> up, string userPropertyKey, TUserProperty defaultValue)
        {
            if (up.TryGetUserProperty(userPropertyKey, out TUserProperty actualValue))
            {
                return actualValue;
            }
            return defaultValue;
        }

        /// <summary>
        /// test if the <paramref name="up"/> value under key <paramref name="userPropertyKey"/> equals <paramref name="other"/>.
        /// </summary>
        /// <param name="up">user properties dict</param>
        /// <param name="userPropertyKey">key under which the value is expected</param>
        /// <param name="other">comparison value</param>
        /// <param name="ignoreWrongType">set true to automatically catch <see cref="FormatException"/> if the cast to <typeparamref name="TUserProperty"/> fails</param>
        /// <returns>true iff <paramref name="up"/>!=null and the value stored under key <paramref name="userPropertyKey"/> == <paramref name="other"/></returns>
        /// <exception cref="ArgumentNullException">iff <paramref name="userPropertyKey"/> is null or whitespace</exception>
        public static bool UserPropertyEquals<TUserProperty>(this IDictionary<string, JToken> up, string userPropertyKey, TUserProperty other, bool ignoreWrongType = true)
        {
            try
            {
                return up.EvaluateUserProperty<TUserProperty, bool>(userPropertyKey, (value) =>
                {
                    if (value == null && other != null)
                    {
                        return false;
                    }
                    else if (value == null)
                    {
                        return other == null;
                    }
                    else
                    {
                        return value.Equals(other);
                    }
                }
                );
            }
            catch (FormatException) when (ignoreWrongType)
            {
                return false;
            }
        }

        /// <summary>
        /// Apply <paramref name="evaluation"/> to the userproperty under <paramref name="userPropertyKey"/> if it exists
        /// </summary>
        /// <typeparam name="TUserProperty">type of the userproperty value</typeparam>
        /// <typeparam name="TEvaluationResult">type of the expected result</typeparam>
        /// <param name="up">user properties dict</param>
        /// <param name="userPropertyKey">key of the userproperty</param>
        /// <param name="evaluation">function to generate result from key value if present</param>
        /// <returns>result of <paramref name="evaluation"/> if the key exists, default otherwise</returns>
        /// <exception cref="ArgumentNullException">iff <paramref name="userPropertyKey"/> is null or whitespace</exception>
        public static TEvaluationResult EvaluateUserProperty<TUserProperty, TEvaluationResult>(this IDictionary<string, JToken> up, string userPropertyKey, Func<TUserProperty, TEvaluationResult> evaluation)
        {
            if (up.TryGetUserProperty<TUserProperty>(userPropertyKey, out var value))
            {
                return evaluation(value);
            }
            return default;
        }
    }
}