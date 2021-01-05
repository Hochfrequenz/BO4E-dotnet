using BO4E.BO;
using BO4E.meta;
using BO4E.meta.LenientConverters;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace BO4E
{
    /// <summary>
    /// This class maps generic JObjects to BO4E business objects.
    /// </summary>
    [Obsolete("The BoMapper is obsolete and should be replace with JsonConvert.DeserializeObject<T>(...) in the long run. It's not a good coding style but still thoroughly tested.")]
    public abstract class BoMapper
    {
        private static readonly Regex BoRegex = new Regex(@"BO4E\.(?:Extensions\.)?BO\.\b(?<boName>\w+)\b", RegexOptions.Compiled);

        /// <summary>
        /// namespace.subnamespace for the BO4E package. maybe there's a more elegant way using self reflection.
        /// </summary>
        public const string PackagePrefix = "BO4E.BO";

        /// <summary>
        /// shortcut for MapObject with an empty userProperties white list
        /// </summary>
        /// <param name="jobject">business object json</param>
        /// <param name="lenient">lenient parsing flags</param>
        /// <returns><see cref="MapObject(string, JObject, LenientParsing)"/></returns>
        public static BusinessObject MapObject(JObject jobject, LenientParsing lenient = LenientParsing.STRICT)
        {
            return MapObject(jobject, new HashSet<string>(), lenient);
        }

        /// <summary>
        /// shortcut for <see cref="MapObject(string, JObject, LenientParsing)"/> iff <paramref name="jobject"/> has key 'boTyp'
        /// </summary>
        /// <param name="jobject">business object json</param>
        /// <param name="lenient">lenient parsing flags</param>
        /// <param name="userPropertiesWhiteList">white list of non BO4E standard field you'd like to have de-serialized</param>
        /// <returns><see cref="MapObject(string, JObject, LenientParsing)"/></returns>
        public static BusinessObject MapObject(JObject jobject, HashSet<string> userPropertiesWhiteList, LenientParsing lenient = LenientParsing.STRICT)
        {
            if (jobject["boTyp"] == null)
            {
                throw new ArgumentNullException(nameof(jobject), "Either call MapObject(JObject) with a Business Object containing the mandatory 'boTyp' key or explicitly name the Object");
            }
            var businessObjectType = GetTypeForBoName(jobject["boTyp"].ToString());
            return MapObject(businessObjectType, jobject, userPropertiesWhiteList, lenient);
        }

        /// <summary>
        /// <see cref="MapObject(string, JObject, HashSet{string}, LenientParsing)"/> with empty user properties white list
        /// </summary>
        public static BusinessObject MapObject(string businessObjectName, JObject jobject, LenientParsing lenient = LenientParsing.STRICT)
        {
            return MapObject(GetTypeForBoName(businessObjectName), jobject, new HashSet<string>(), lenient);
        }

        /// <summary>
        /// <see cref="MapObject(Type, JObject, HashSet{string}, LenientParsing)"/> with empty user properties white list
        /// </summary>
        public static BusinessObject MapObject(Type businessObjectType, JObject jobject, LenientParsing lenient = LenientParsing.STRICT)
        {
            return MapObject(businessObjectType, jobject, new HashSet<string>(), lenient);
        }

        /// <summary>
        /// <see cref="MapObject(Type, JObject, HashSet{string}, LenientParsing)"/>
        /// </summary>
        public static TBusinessObjectType MapObject<TBusinessObjectType>(JObject jobject, LenientParsing lenient = LenientParsing.STRICT)
        {
            return (TBusinessObjectType)Convert.ChangeType(MapObject(typeof(TBusinessObjectType), jobject, lenient), typeof(TBusinessObjectType));
        }

        /// <summary>
        /// <see cref="MapObject(Type, JObject, HashSet{string}, LenientParsing)"/>
        /// </summary>
        /// <param name="businessObjectName"></param>
        /// <param name="jobject"></param>
        /// <param name="userPropertiesWhiteList"></param>
        /// <param name="lenient"></param>
        /// <returns></returns>
        [Obsolete("DEPRECATED! Please use the overloaded method MapObject<T>(...) or MapObject(Type t,...) that accept types, not strings.")]
        public static BusinessObject MapObject(string businessObjectName, JObject jobject, HashSet<string> userPropertiesWhiteList, LenientParsing lenient = LenientParsing.STRICT)
        {
            return MapObject(GetTypeForBoName(businessObjectName), jobject, userPropertiesWhiteList, lenient);
        }

        /// <summary>
        /// This method tries to map the given jobject to a BO4E style
        /// Business Object of a given type. It works using reflection.
        /// </summary>
        /// If the mapping fails, there either is no BO with the given name or
        /// you mixed up or forgot some attributes. Most of assertion errors
        /// are likely to happen due to misspelled and case sensitive attributes.
        /// The assertion error message should be a good hint to what is wrong.
        /// If the method passes without an assertion error, there are at
        /// least no unknown or wrong attributes.
        ///
        /// <param name="jobject">JObject that should be mapped to a BO4E business object.</param>
        /// <param name="userPropertiesWhiteList">white list of non BO4E standard field you'd like to have de-serialised</param>
        /// <param name="businessObjectType">type of the business object</param>
        /// <param name="lenient">allow less strict input objects</param>
        /// <returns>
        /// <list type="bullet">
        /// <item><description>null iff there is no BO4E Business Object that matches the provided businessObjectName. Check the case sensitive spelling of the business object name</description></item>
        /// <item><description>a BO4E business object (<see cref="BusinessObject"/>) of the type provided in businessObjectName</description></item>
        /// </list>
        /// </returns>
        [Obsolete("DEPRECATED! Please use the overloaded method MapObject<T>(...) or MapObject(Type t,...) that accept types, not strings.")]
        public static BusinessObject MapObject(Type businessObjectType, JObject jobject, HashSet<string> userPropertiesWhiteList, LenientParsing lenient = LenientParsing.STRICT)
        {
            if (!businessObjectType.IsSubclassOf(typeof(BusinessObject)))
            {
                throw new ArgumentException("Mapping is only allowed for types derived from BO4E.BO.BusinessObject");
            }

            if (lenient == LenientParsing.STRICT && userPropertiesWhiteList.Count == 0)
            {
                return (BusinessObject)jobject.ToObject(businessObjectType);
            }

            var settings = lenient.GetJsonSerializerSettings();
            return (BusinessObject)JsonConvert.DeserializeObject(jobject.ToString(), businessObjectType, settings);
        }

        /// <summary>
        /// <see cref="MapObject(Type, JObject, HashSet{string}, LenientParsing)"/>
        /// </summary>
        /// <typeparam name="BusinessObjectType">type of return value</typeparam>
        /// <param name="jobject"><see cref="MapObject(Type, JObject, HashSet{string}, LenientParsing)"/></param>
        /// <param name="userPropertiesWhiteList"><see cref="MapObject(Type, JObject, HashSet{string}, LenientParsing)"/></param>
        /// <param name="lenient"><see cref="MapObject(Type, JObject, HashSet{string}, LenientParsing)"/></param>
        /// <returns><see cref="MapObject(Type, JObject, HashSet{string}, LenientParsing)"/></returns>
        public static BusinessObjectType MapObject<BusinessObjectType>(JObject jobject, HashSet<string> userPropertiesWhiteList, LenientParsing lenient = LenientParsing.STRICT)
        {
            var businessObjectType = typeof(BusinessObjectType);
            return (BusinessObjectType)Convert.ChangeType(MapObject(businessObjectType, jobject, userPropertiesWhiteList, lenient), typeof(BusinessObjectType));
        }

        /// <summary>
        /// Get a list of those strings that are known BO4E types (e.g. "Messlokation", "Energiemenge"...)
        /// </summary>
        /// <returns>a list of valid BO4E names; upper/lower case sensitive</returns>
        public static HashSet<string> GetValidBoNames()
        {
            var result = new HashSet<string>();
            var types = Assembly.GetExecutingAssembly().GetTypes();
            foreach (var t in types)
            {
                var m = BoRegex.Match(t.ToString());
                if (m.Success)
                {
                    result.Add(m.Groups["boName"].Value);
                }
            }
            return result;
        }

        /// <summary>
        /// Returns a Type for given Business Object name. This method is useful to avoid stringified code.
        /// </summary>
        /// <param name="businessObjectName">name of a business object; is lenient regarding upper/lower case</param>
        /// <returns>a BusinessObjectType or null if no matching type was found</returns>
        /// <exception cref="ArgumentNullException">if argument is null</exception>
        /// <example>
        /// <code>
        /// BoMapper.GetTypeForBoName("Energiemenge"); // returns typeof(BO4E.BO.Energiemenge)
        /// BoMapper.GetTypeForBoName("eNeRgIeMENgE"); // returns typeof(BO4E.BO.Energiemenge)
        /// BoMapper.GetTypeForBoName("non existent BO"); // returns null
        /// </code>
        /// </example>
        public static Type GetTypeForBoName(string businessObjectName)
        {
            if (businessObjectName == null)
            {
                throw new ArgumentNullException(nameof(businessObjectName));
            }

            //Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            var clazz = Assembly.GetExecutingAssembly().GetType(PackagePrefix + "." + businessObjectName);
            if (clazz != null)
            {
                return clazz;
            }
            else
            {
                foreach (var boName in GetValidBoNames())
                {
                    // fallback.
                    if (String.Equals(boName, businessObjectName, StringComparison.CurrentCultureIgnoreCase))
                    {
                        return Assembly.GetExecutingAssembly().GetType(PackagePrefix + "." + boName);
                    }
                }
            }
            //throw new ArgumentException($"No implemented BusinessObject type matches the name '{businessObjectName}'.");
            return null;
        }

        /// <summary>
        /// Get JSON Scheme for given Business Object name
        /// </summary>
        /// See <see cref="GetValidBoNames"/> for a list of valid arguments.
        /// <param name="businessObjectName">Business Object name (e.g. "Messlokation")</param>
        /// <returns>A JSON scheme to be used for validation purposes or null for invalid arguments.</returns>
        /// <seealso cref="GetJsonSchemeFor(Type)"/>
        public static JSchema GetJsonSchemeFor(string businessObjectName)
        {
            Type clazz;
            try
            {
                clazz = GetTypeForBoName(businessObjectName);
            }
            catch (ArgumentException)
            {
                return null;
            }
            return clazz == null ? null : GetJsonSchemeFor(clazz);
        }

        /// <summary>
        /// Get JSON Scheme for given Business Object type
        /// </summary>
        /// <param name="businessObjectType">Business Object type (e.g. typeof(BO4E.BO.Messlokation)</param>
        /// <returns>A JSON scheme to be used for validation purposes.</returns>
        /// <exception cref="ArgumentException">if given type is not derived from BusinessObject</exception>
        /// <seealso cref="GetJsonSchemeFor(string)"/>
        public static JSchema GetJsonSchemeFor(Type businessObjectType)
        {
            if (!businessObjectType.IsSubclassOf(typeof(BusinessObject)))
            {
                throw new ArgumentException($"The given type {businessObjectType} is not derived from BusinessObject.");
            }
            var bo = Activator.CreateInstance(businessObjectType) as BusinessObject;
            return bo.GetJsonScheme();
        }

        /// <summary>
        /// Shortcut for <see cref="GetAnnotatedFields(string, Type)"/> with DataCategoryAttribute as default.
        /// </summary>
        /// <param name="boName">name of the business object in title case<example>Messlokation</example></param>
        /// <returns>Array of FieldInfos</returns>
        [Obsolete("Fields are only private version 1.1", true)]
        public static FieldInfo[] GetAnnotatedFields(string boName)
        {
            return GetAnnotatedFields(boName, typeof(DataCategoryAttribute));
        }

        [Obsolete("Fields are only private version 1.1", true)]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        // no docstrings for deprecated methods
        public static FieldInfo[] GetAnnotatedFields(Type type)

        {
            return GetAnnotatedFields(type, typeof(DataCategoryAttribute));
        }

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

        /// <summary>
        /// Get those fields of a business object that do have attributes/annotations.
        /// The result is ordered by the JsonProperty->Order value (assuming 0 if null).
        /// </summary>
        /// <param name="boType">type of the business object</param>
        /// <param name="attributeType">type of the attribute/annotation you're interested in<example>typeof(DataCategoryAttribute)</example></param>
        /// <returns>Array of FieldInfos</returns>
        [Obsolete("Fields are only private version 1.1", true)]
        public static FieldInfo[] GetAnnotatedFields(Type boType, Type attributeType)
        {
            return boType.GetFields()
                .Where(f => f.GetCustomAttributes(attributeType, false).Length > 0)
                .OrderBy(af => af.GetCustomAttribute<JsonPropertyAttribute>()?.Order)
                .ToArray();
        }

        /// <summary>
        /// Get those fields of a business object that do have attributes/annotations.
        /// The result is ordered by the JsonProperty->Order value (assuming 0 if null).
        /// </summary>
        /// <param name="boName">name of the business object in title case<example>Messlokation</example></param>
        /// <param name="attributeType">type of the attribute/annotation you're interested in<example>typeof(DataCategoryAttribute)</example></param>
        /// <returns>Array of FieldInfos</returns>
        [Obsolete("Fields are only private version 1.1", true)]
        public static FieldInfo[] GetAnnotatedFields(string boName, Type attributeType)
        {
            return Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.Name == boName || String.Equals(t.Name, boName, StringComparison.CurrentCultureIgnoreCase))
                .SelectMany(t => t.GetFields()) // by type name
                .Where(f => f.GetCustomAttributes(attributeType, false).Length > 0)
                .OrderBy(af => af.GetCustomAttribute<JsonPropertyAttribute>()?.Order)
                .ToArray();
        }
    }
}