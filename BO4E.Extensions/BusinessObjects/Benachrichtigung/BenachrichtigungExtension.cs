using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using BO4E.COM;

namespace BO4E.Extensions.BusinessObjects.Benachrichtigung
{
    /// <summary>Additional methods for <see cref="Benachrichtigung" />.</summary>
    public static class BenachrichtigungExtension
    {
        /// <summary>
        ///     checks if <see cref="BO4E.BO.Benachrichtigung.Infos" /> contains a key value pair
        /// </summary>
        /// <param name="b"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool Has(this BO.Benachrichtigung b, string key, string value)
        {
            return Has(b, new GenericStringStringInfo
            {
                KeyColumn = key,
                Value = value
            });
        }

        /// <summary>
        ///     checks if <paramref name="b" /> contains a key value pair specified in <paramref name="gssi" /> in
        ///     <see cref="BO4E.BO.Benachrichtigung.Infos" />
        /// </summary>
        /// <param name="b"></param>
        /// <param name="gssi"></param>
        /// <returns></returns>
        public static bool Has(this BO.Benachrichtigung b, GenericStringStringInfo gssi)
        {
            if (b.Infos == null || b.Infos.Count == 0) return false;
            // ToDo für Hamid: Bitte prüfen, warum Contains false zurückliefert.
            return b.Infos.Any(m => m.KeyColumn == gssi.KeyColumn && m.Value == gssi.Value);
        }

        /// <summary>
        ///     check if a specific info exists
        /// </summary>
        /// <param name="b">Benachrichtigung</param>
        /// <param name="key">key to be checked</param>
        /// <returns>true if key is in <see cref="BO4E.BO.Benachrichtigung.Infos" /></returns>
        public static bool Has(this BO.Benachrichtigung b, string key)
        {
            if (b.Infos == null || b.Infos.Count == 0) return false;
            return b.Infos.Any(gssi => gssi.KeyColumn == key);
        }

        /// <summary>
        ///     checks if Benachrichtigung <paramref name="b" /> has an entry with key <paramref name="keyName" /> in
        ///     <see cref="BO4E.BO.Benachrichtigung.Infos" /> which fulfills a predicate
        /// </summary>
        /// <typeparam name="T">expected type of the info property</typeparam>
        /// <param name="b">Benachrichtigung object</param>
        /// <param name="keyName">key name of the info property</param>
        /// <param name="predicate"></param>
        /// <param name="passByDefault">defines default behaviour, e.g. if no such key is present</param>
        /// <param name="typeConverter">allows to provide an explicit type converter</param>
        /// <returns>
        ///     true if there's an info object with given key <paramref name="keyName" /> of type <typeparamref name="T" />
        ///     fulfilling <paramref name="predicate" /> or there's no such property but <paramref name="passByDefault" /> is true
        /// </returns>
        public static bool Has<T>(this BO.Benachrichtigung b, string keyName, Predicate<T> predicate,
            bool passByDefault = true, TypeConverter typeConverter = null) where T : IComparable
        {
            if (!b.Has(keyName)) return passByDefault;
            foreach (var info in b.Infos.Where(gssi => gssi.KeyColumn == keyName))
                try
                {
                    if (typeConverter == null) typeConverter = TypeDescriptor.GetConverter(typeof(T));

                    {
                        var value = (T)typeConverter.ConvertFromString(info.Value);
                        return predicate(value);
                    }
                }
                catch (NotSupportedException)
                {
                }

            return false;
        }

        /// <summary>
        ///     moves key value pairs from <see cref="BO4E.BO.Benachrichtigung.Infos" /> to
        ///     <see cref="BO4E.BO.BusinessObject.UserProperties" /> for more convenient handling.
        /// </summary>
        /// <param name="b">Benachrichtigung</param>
        /// <param name="overwriteExistingKeys">set true to overwrite userProperties with same key</param>
        // ToDo: make method generic MoveInfosTouserProperties<boT>(...)
        public static void MoveInfosToUserProperties(this BO.Benachrichtigung b, bool overwriteExistingKeys = false)
        {
            if (b.Infos != null && b.Infos.Count > 0)
            {
                if (b.UserProperties == null) b.UserProperties = new Dictionary<string, object>();
                foreach (var info in b.Infos)
                {
                    if (b.UserProperties.ContainsKey(info.KeyColumn) && overwriteExistingKeys)
                        b.UserProperties.Remove(info.KeyColumn);
                    b.UserProperties.Add(info.KeyColumn,
                        info.Value); // might throw exception if key exists and !overwriteExistingKeys. That's ok.
                }

                b.Infos = null; // set to null after all elements have been moved
            }
        }
    }
}