using BO4E.BO;
using BO4E.COM;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;

namespace BO4E.Extensions.BusinessObjects
{
    /// <summary>
    /// common extensions for all BusinessObjects
    /// </summary>
    public static class BusinessObjectExtensions
    {
        /// <summary>
        /// Create a deep copy of a Business Object
        /// </summary>
        /// <typeparam name="T">Type of the BusinessObject</typeparam>
        /// <param name="source">the BO that is copied</param>
        /// <returns>the deep copy</returns>
        public static T DeepClone<T>(this T source) where T : BusinessObject
        {
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(source));
        }

        /// <summary>
        /// <inheritdoc cref="ExterneReferenzExtensions.TryGetExterneReferenz(ICollection{ExterneReferenz}, string, out string)"/>
        /// </summary>
        public static bool TryGetExterneReferenz(this BusinessObject bo, string extRefName, out string extRefWert)
            => bo.ExterneReferenzen.TryGetExterneReferenz(extRefName, out extRefWert);

        /// <summary>
        /// <inheritdoc cref="ExterneReferenzExtensions.SetExterneReferenz"/>
        /// </summary>
        public static void SetExterneReferenz(this BusinessObject bo, ExterneReferenz extRef, bool overwriteExisting = false)
            => bo.ExterneReferenzen = bo.ExterneReferenzen.SetExterneReferenz(extRef, overwriteExisting);
    }

    /// <summary>
    /// easy access methods for <see cref="List{ExterneReferenz}"/> to allow easier setting and getting.
    /// </summary>
    public static class ExterneReferenzExtensions
    {
        /// <summary>
        /// try to get a value from <see cref="BusinessObject.ExterneReferenzen"/>
        /// </summary>
        /// <param name="extRefName">name of the externe referenz</param>
        /// <param name="extRefWert">non-null if the externe referenz was found</param>
        /// <param name="extReferences">list of external references</param>
        /// <returns>true if externe referenz with name <paramref name="extRefName"/> was found</returns>
        public static bool TryGetExterneReferenz(this ICollection<ExterneReferenz> extReferences, string extRefName, out string extRefWert)
        {
            if (extRefName == null) throw new System.ArgumentNullException(nameof(extRefName));
            if (extReferences == null)
            {
                extRefWert = null;
                return false;
            }
            var externeReferenz = extReferences.SingleOrDefault(er => er.ExRefName == extRefName);
            if (externeReferenz == null)
            {
                extRefWert = null;
                return false;
            }
            extRefWert = externeReferenz.ExRefWert;
            return true;
        }

        /// <summary>
        /// Adds a new value to <paramref name="extReferences"/> and created the list if it's null.
        /// </summary>
        /// <param name="extReferences">list of external references</param>
        /// <param name="extRef">new externe Referenz</param>
        /// <param name="overwriteExisting">set true to overwrite existing values</param>
        /// <exception cref="InvalidOperationException">if there is a conflicting value and <paramref name="overwriteExisting"/> is false</exception>
        public static List<ExterneReferenz> SetExterneReferenz(this List<ExterneReferenz> extReferences, ExterneReferenz extRef, bool overwriteExisting = false)
        {
            if (extRef == null) throw new ArgumentNullException(nameof(extRef));
            if (!extRef.IsValid())
            {
                throw new ArgumentException($"The external reference with {nameof(extRef.ExRefName)}='{extRef.ExRefName}' and {nameof(extRef.ExRefWert)}='{extRef.ExRefWert}' you tried to add is invalid.", nameof(extRef));
            }
            if (extReferences == null)
            {
                return new List<ExterneReferenz>() { extRef };
            }
            else if (extReferences.Any() && extReferences.TryGetExterneReferenz(extRef.ExRefName, out var existingRefWert))
            {
                if (overwriteExisting)
                {
                    extReferences.RemoveAll(er => er.ExRefName == extRef.ExRefName);
                }
                else
                {
                    if (existingRefWert != extRef.ExRefWert)
                    {
                        throw new InvalidOperationException($"There is already an with {nameof(extRef.ExRefName)}='{extRef.ExRefName}' having {nameof(extRef.ExRefWert)}='{existingRefWert}'!='{extRef.ExRefWert}'. Use {nameof(overwriteExisting)}=true to overwrite it.");
                    }
                    else
                    {
                        return extReferences;
                    }
                }
            }
            extReferences.Add(extRef);
            return extReferences;
        }
    }
}