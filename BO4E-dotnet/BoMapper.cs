using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using BO4E.BO;
using BO4E.meta;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Serialization;

namespace BO4E
{
    /// <summary>
    /// This class maps generic JObjects to BO4E business objects. 
    /// </summary>
    [Obsolete("The BoMapper is obsolete and should be replace with JsonConvert.DeserializeObject<T>(...) in the long run. It's not a good coding style but still thoroughly tested.")]
    public abstract class BoMapper
    {

        private static readonly Regex BO_REGEX = new Regex(@"BO4E\.(?:Extensions\.)?BO\.\b(?<boName>\w+)\b", RegexOptions.Compiled);
        /// <summary>
        /// namespace.subnamespace for the BO4E package. maybe there's a more elegant way using self reflection.
        /// </summary>
        public static readonly string packagePrefix = "BO4E.BO";

        /// <summary>
        /// shortcut for <see cref="MapObject(JObject, LenientParsing, HashSet{string})"/> with an empty userProperties white list
        /// </summary>
        /// <param name="jobject">business object json</param>
        /// <param name="lenient">lenient parsing flags</param>
        /// <returns><see cref="MapObject(string, JObject, LenientParsing)"/></returns>
        public static BusinessObject MapObject(JObject jobject, LenientParsing lenient = LenientParsing.Strict)
        {
            return MapObject(jobject, new HashSet<string>(), lenient);
        }

        /// <summary>
        /// shortcut for <see cref="MapObject(string, JObject, LenientParsing)"/> iff <paramref name="jobject"/> has key 'boTyp'
        /// </summary>
        /// <param name="jobject">business object json</param>
        /// <param name="lenient">lenient parsing flags</param>
        /// <param name="userPropertiesWhiteList">white list of non BO4E standard field you'd like to have de-serialised</param>
        /// <returns><see cref="MapObject(string, JObject, LenientParsing)"/></returns>
        public static BusinessObject MapObject(JObject jobject, HashSet<string> userPropertiesWhiteList, LenientParsing lenient = LenientParsing.Strict)
        {
            if (jobject["boTyp"] == null)
            {
                throw new ArgumentNullException("boTyp", "Either call MapObject(JObject) with a Business Object containing the mandatory 'boTyp' key or explicitly name the Object");
            }
            Type businessObjectType = GetTypeForBoName(jobject["boTyp"].ToString());
            return MapObject(businessObjectType, jobject, userPropertiesWhiteList, lenient);
        }

        /// <summary>
        /// <see cref="MapObject(string, JObject, HashSet{string}, LenientParsing)"/> with empty user properties white list
        /// </summary>
        public static BusinessObject MapObject(string businessObjectName, JObject jobject, LenientParsing lenient = LenientParsing.Strict)
        {
            return MapObject(GetTypeForBoName(businessObjectName), jobject, new HashSet<string>(), lenient);
        }

        /// <summary>
        /// <see cref="MapObject(Type, JObject, HashSet{string}, LenientParsing)"/> with empty user properties white list
        /// </summary>
        public static BusinessObject MapObject(Type businessObjectType, JObject jobject, LenientParsing lenient = LenientParsing.Strict)
        {
            return MapObject(businessObjectType, jobject, new HashSet<string>(), lenient);
        }

        /// <summary>
        /// <see cref="MapObject(Type, JObject, HashSet{string}, LenientParsing)"/>
        /// </summary>
        public static BusinessObjectType MapObject<BusinessObjectType>(JObject jobject, LenientParsing lenient = LenientParsing.Strict)
        {
            return (BusinessObjectType)Convert.ChangeType(MapObject(typeof(BusinessObjectType), jobject, lenient), typeof(BusinessObjectType));
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
        public static BusinessObject MapObject(string businessObjectName, JObject jobject, HashSet<string> userPropertiesWhiteList, LenientParsing lenient = LenientParsing.Strict)
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
        public static BusinessObject MapObject(Type businessObjectType, JObject jobject, HashSet<string> userPropertiesWhiteList, LenientParsing lenient = LenientParsing.Strict)
        {
            if (!businessObjectType.IsSubclassOf(typeof(BusinessObject)))
            {
                throw new ArgumentException("Mapping is only allowed for types derived from BO4E.BO.BusinessObject");
            }
            else if (businessObjectType != null)
            {
                if (lenient == LenientParsing.Strict && userPropertiesWhiteList.Count == 0)
                {
                    return (BusinessObject)jobject.ToObject(businessObjectType);
                }
                else
                {
                    List<JsonConverter> converters = new List<JsonConverter>();
                    foreach (LenientParsing lp in Enum.GetValues(typeof(LenientParsing)))
                    {
                        if (lenient.HasFlag(lp))
                        {
                            switch (lp)
                            {
                                case LenientParsing.DateTime:
                                    if (!lenient.HasFlag(LenientParsing.SetInitialDateIfNull))
                                    {
                                        converters.Add(new LenientDateTimeConverter());
                                    }
                                    else
                                    {
                                        converters.Add(new LenientDateTimeConverter(new DateTime()));
                                    }
                                    break;
                                case LenientParsing.EnumList:
                                    converters.Add(new LenientEnumListConverter());
                                    break;
                                case LenientParsing.Bo4eUri:
                                    converters.Add(new LenientBo4eUriConverter());
                                    break;
                                    // case LenientParsing.EmptyLists:
                                    // converters.Add(new LenientRequiredListConverter());
                                    // break;

                                    // no default case because NONE and MOST_LENIENT do not come up with more converters
                            }
                        }
                    }
                    IContractResolver contractResolver;
                    if (userPropertiesWhiteList.Count > 0)
                    {
                        contractResolver = new UserPropertiesDataContractResolver(userPropertiesWhiteList);
                    }
                    else
                    {
                        contractResolver = new DefaultContractResolver();
                    }
                    JsonSerializerSettings settings = new JsonSerializerSettings
                    {
                        Converters = converters,
                        DateParseHandling = DateParseHandling.None,
                        ContractResolver = contractResolver
                    };
                    return (BusinessObject)JsonConvert.DeserializeObject(jobject.ToString(), businessObjectType, settings);
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// <see cref="MapObject(Type, JObject, HashSet{string}, LenientParsing)"/>
        /// </summary>
        /// <typeparam name="BusinessObjectType">type of return value</typeparam>
        /// <param name="jobject"><see cref="MapObject(Type, JObject, HashSet{string}, LenientParsing)"/></param>
        /// <param name="userPropertiesWhiteList"><see cref="MapObject(Type, JObject, HashSet{string}, LenientParsing)"/></param>
        /// <param name="lenient"><see cref="MapObject(Type, JObject, HashSet{string}, LenientParsing)"/></param>
        /// <returns><see cref="MapObject(Type, JObject, HashSet{string}, LenientParsing)"/></returns>
        public static BusinessObjectType MapObject<BusinessObjectType>(JObject jobject, HashSet<string> userPropertiesWhiteList, LenientParsing lenient = LenientParsing.Strict)
        {
            Type businessObjectType = typeof(BusinessObjectType);
            return (BusinessObjectType)Convert.ChangeType(MapObject(businessObjectType, jobject, userPropertiesWhiteList, lenient), typeof(BusinessObjectType));
        }

        /// <summary>
        /// Get a list of those strings that are known BO4E types (e.g. "Messlokation", "Energiemenge"...)
        /// </summary>
        /// <returns>a list of valid BO4E names; upper/lower case sensitive</returns>
        public static HashSet<string> GetValidBoNames()
        {
            HashSet<string> result = new HashSet<string>();
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            foreach (Type t in types)
            {
                Match m = BO_REGEX.Match(t.ToString());
                if (m.Success)
                {
                    result.Add((m.Groups)["boName"].Value);
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
                throw new ArgumentNullException("Business Object Name must not be null.");
            }

            Type clazz;
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            clazz = Assembly.GetExecutingAssembly().GetType(packagePrefix + "." + businessObjectName);
            if (clazz != null)
            {
                return clazz;
            }
            else
            {
                foreach (string boName in GetValidBoNames())
                {
                    // fallback.
                    if (boName.ToUpper() == businessObjectName.ToUpper())
                    {
                        return Assembly.GetExecutingAssembly().GetType(packagePrefix + "." + boName);
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
            if (clazz == null)
            {
                return null;
            }
            return GetJsonSchemeFor(clazz);
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
                throw new ArgumentException($"The given type {businessObjectType.ToString()} is not derived from BusinessObject.");
            }
            BusinessObject bo = Activator.CreateInstance(businessObjectType) as BusinessObject;
            return bo.GetJsonScheme();
        }

        /// <summary>
        /// Shortcut for <see cref="GetAnnotatedFields(string, Type)"/> with DataCategoryAttribute as default.
        /// </summary>
        /// <param name="boName">name of the business object in title case<example>Messlokation</example></param>
        /// <returns>Array of FieldInfos</returns>
        public static FieldInfo[] GetAnnotatedFields(string boName)
        {
            return GetAnnotatedFields(boName, typeof(DataCategoryAttribute));
        }

        /// <summary>
        /// Get those fields of a business object that do have attributes/annotations.
        /// The result is ordered by the JsonProperty->Order value (assuming 0 if null).
        /// </summary>
        /// <param name="boType">type of the business object</param>
        /// <param name="attributeType">type of the attribute/annotation you're interested in<example>typeof(DataCategoryAttribute)</example></param>
        /// <returns>Array of FieldInfos</returns>
        public static FieldInfo[] GetAnnotatedFields(Type boType, Type attributeType)
        {
            return Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t == boType) // by type
                .SelectMany(t => t.GetFields())
                .Where(f => f.GetCustomAttributes(attributeType, false).Length > 0)
                .OrderBy(af => af.GetCustomAttribute<JsonPropertyAttribute>()?.Order)
                .ToArray<FieldInfo>();
        }

        /// <summary>
        /// Get those fields of a business object that do have attributes/annotations.
        /// The result is ordered by the JsonProperty->Order value (assuming 0 if null).
        /// </summary>
        /// <param name="boName">name of the business object in title case<example>Messlokation</example></param>
        /// <param name="attributeType">type of the attribute/annotation you're interested in<example>typeof(DataCategoryAttribute)</example></param>
        /// <returns>Array of FieldInfos</returns>
        public static FieldInfo[] GetAnnotatedFields(string boName, Type attributeType)
        {
            return Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.Name == boName || t.Name.ToUpper()==boName.ToUpper())
                .SelectMany(t => t.GetFields()) // by type name
                .Where(f => f.GetCustomAttributes(attributeType, false).Length > 0)
                .OrderBy(af => af.GetCustomAttribute<JsonPropertyAttribute>()?.Order)
                .ToArray<FieldInfo>();
        }

        private class LenientEnumListConverter : JsonConverter
        {

            public override bool CanConvert(Type objectType)
            {
                if (!objectType.IsGenericType)
                {
                    return false;
                }
                if (objectType.GetGenericTypeDefinition() != typeof(List<>))
                {
                    return false;
                }
                Type expectedListElementType = objectType.GetGenericArguments()[0];
                return expectedListElementType.ToString().StartsWith("BO4E.ENUM");
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                JToken token = JToken.Load(reader); // https://stackoverflow.com/a/47864946/10009545
                List<object> rawList = token.ToObject<List<object>>();
                Type expectedListElementType = objectType.GetGenericArguments()[0];
                Type expectedListType = typeof(List<>).MakeGenericType(expectedListElementType);
                object result = Activator.CreateInstance(expectedListType);
                if (rawList == null || rawList.Count == 0)
                {
                    return result;
                }
                // First try to parse the List normally, in case it's formatted as expected
                foreach (var rawItem in rawList)
                {
                    if (rawItem.GetType() == typeof(string) && Enum.IsDefined(expectedListElementType, rawItem.ToString()))
                    {
                        // default. everything is as it should be :-)
                        object enumValue = Enum.Parse(expectedListElementType, rawItem.ToString());
                        ((IList)result).Add(enumValue);
                    }
                    else if (rawItem.GetType() == typeof(JObject))
                    {
                        Dictionary<string, object> rawDict = ((JObject)rawItem).ToObject<Dictionary<string, object>>();
                        object rawObject = rawDict.Values.FirstOrDefault<object>();
                        object enumValue = Enum.Parse(expectedListElementType, rawObject.ToString());
                        ((IList)result).Add(enumValue);
                    }
                    else
                    {
                        ((IList)result).Add(rawItem);
                    }
                }
                return result;
            }

            public override bool CanWrite
            {
                get { return false; }
            }

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// The lenient DateTimeConverter allows for transforming strings into (nullable) DateTime(?) objects,
        /// even if their formatting is somehow weird.
        /// </summary>
        public class LenientDateTimeConverter : JsonConverter
        {
            // basic structure copied from https://stackoverflow.com/a/33172735/10009545

            private readonly DateTime? _defaultDateTime;

            public LenientDateTimeConverter(DateTime? defaultDateTime = null)
            {
                this._defaultDateTime = defaultDateTime;
            }

            public LenientDateTimeConverter() : this(null)
            {

            }

            private readonly List<string> ALLOWED_DATETIME_FORMATS = new List<string>()
            {
                "yyyyMMddHHmm",
                "yyyyMMddHHmmss",
                @"yyyyMMddHHmmss'--T::zzzz'", // ToDo: remove again. this is just a buggy, nasty workaround
            };

            public override bool CanConvert(Type objectType)
            {
                return (objectType == typeof(DateTime) || objectType == typeof(DateTime?));
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                string rawDate;
                if(reader.Value == null)
                {
                    return null;
                }
                else if (reader.Value as string != null)
                {
                    rawDate = (string)reader.Value;
                }
                else if (reader.Value.GetType() == typeof(DateTime))
                {
                    return (DateTime)reader.Value;
                }
                else
                {
                    rawDate = reader.Value.ToString();
                }
                // First try to parse the date string as is (in case it is correctly formatted)
                if (DateTime.TryParse(rawDate, out DateTime date))
                {
                    return date;
                }

                foreach (string dtf in ALLOWED_DATETIME_FORMATS)
                {
                    if (DateTime.TryParseExact(rawDate, dtf, CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                    {
                        return date;
                    }
                }

                // It's not a date after all, so just return the default value
                if (objectType == typeof(DateTime?))
                {
                    return null;
                }
                if (this._defaultDateTime.HasValue)
                {
                    return _defaultDateTime;
                }
                else
                {
                    throw new JsonReaderException($"Couldn't convert {rawDate} to any of the allowed date time formats: {String.Join(";", ALLOWED_DATETIME_FORMATS)})");
                }
            }

            public override bool CanWrite
            {
                get { return false; }
            }

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
        }

        private class LenientBo4eUriConverter : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return (objectType == typeof(Bo4eUri));
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                if (reader.Value == null)
                {
                    return null;
                }
                string rawString = (string)reader.Value;
                if (rawString.Trim() == String.Empty)
                {
                    return null;
                }
                return new Bo4eUri(rawString);
            }

            public override bool CanWrite
            {
                get { return false; }
            }

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// The UserPropertiesContractResolver allows to put non-BO4E-standard/custom fields/properties into a "userProperties" object.
        /// </summary>
        public class UserPropertiesDataContractResolver : DefaultContractResolver
        {
            public static readonly UserPropertiesDataContractResolver Instance = new UserPropertiesDataContractResolver(new HashSet<string>());

            private readonly HashSet<string> whitelist;

            /// <summary>
            /// The UserPropertiesDataContractResolver is initialised with a white list of allowed properties. Everything else is discarded.
            /// </summary>
            /// <param name="userPropertiesWhiteList">white list of properties (actually a white"set")</param>
            public UserPropertiesDataContractResolver(HashSet<string> userPropertiesWhiteList)
            {
                whitelist = userPropertiesWhiteList;
            }

            public override JsonContract ResolveContract(Type type)
            {
                JsonContract contract = base.ResolveContract(type);
                if (contract is JsonObjectContract objContract)
                {
                    if (objContract.ExtensionDataSetter != null)
                    {
                        ExtensionDataSetter oldSetter = objContract.ExtensionDataSetter;
                        objContract.ExtensionDataSetter = (o, key, value) =>
                        {
                            if (whitelist.Contains(key))
                            {
                                oldSetter(o, key, value);
                            }
                            else
                            {
                                int a = 0;
                                a++;
                            }
                        };
                    }
                }
                return contract;
            }
        }
    }
}
