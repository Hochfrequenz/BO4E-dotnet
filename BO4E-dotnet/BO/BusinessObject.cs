using BO4E.COM;
using BO4E.meta;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;
using Newtonsoft.Json.Serialization;

using ProtoBuf;

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace BO4E.BO
{
    /// <summary>
    /// General abstract class for Business Objects for Energy (BO4E)
    /// </summary>
    /// This class is not intended to be instantiated. It just provides the boTyp and version
    /// attribute which are obligatory for all BO4E business objects.
    /// <author>Hochfrequenz Unternehmensberatung GmbH</author>
    [JsonConverter(typeof(BusinessObjectBaseConverter))]
    //[ProtoContract] // If I add this I get an error message: "System.InvalidOperationException: Duplicate field-number detected; 1 on: BO4E.BO.BusinessObject"
    [ProtoInclude(1, typeof(Angebot))]
    [ProtoInclude(2, typeof(Ansprechpartner))]
    [ProtoInclude(3, typeof(Benachrichtigung))]
    [ProtoInclude(4, typeof(Energiemenge))]
    [ProtoInclude(5, typeof(Geschaeftspartner))]
    [ProtoInclude(6, typeof(Kosten))]
    [ProtoInclude(7, typeof(Marktlokation))]
    //[ProtoInclude(8, typeof(Marktteilnehmer))] // https://stackoverflow.com/a/13791539/10009545
    [ProtoInclude(9, typeof(Messlokation))]
    [ProtoInclude(10, typeof(Preisblatt))]
    [ProtoInclude(11, typeof(Rechnung))]
    [ProtoInclude(12, typeof(Region))]
    [ProtoInclude(13, typeof(Vertrag))]
    [ProtoInclude(14, typeof(Zaehler))]
    [ProtoInclude(15, typeof(LogObject))]
    public abstract class BusinessObject : IEquatable<BusinessObject>, IUserProperties
    {
        /// <summary>
        /// obligatory type of the business object in UPPER CASE
        /// </summary>
        /// <example>
        /// 'MESSLOKATION',
        /// 'MARKTLOKATION'
        /// </example>
        [JsonProperty(Required = Required.Default, Order = 1, PropertyName = "boTyp")]
        [ProtoMember(1)]
        public string BoTyp
        {
            get { return this.GetType().Name.ToUpper(); }
            set { }
        }

        /// <summary>
        /// Fields that are not part of the BO4E-definition are stored in a element, that is
        /// accessable under the key defined in userPropertiesName.
        /// </summary>
        /// This JObject representing a Messlokation
        /// <example>
        /// <code>
        /// {
        ///    "boTyp": "MESSLOKATION",
        ///    "versionStruktur": 1,
        ///    "messLokationsId": "DE123...",
        ///    "irgendwas unbekanntes": "xyz"
        /// }
        /// </code>
        /// is mapped to
        /// <code>
        /// {
        ///    "boTyp": "MESSLOKATION",
        ///    "versionStruktur": 1,
        ///    "messLokationsId": "DE123...",
        ///    "userProperties":
        ///    {
        ///        "irgendwas unbekanntes": "xyz"
        ///    }
        /// }
        /// </code>
        /// This keeps the Business Object simple but allows for user specific arguments beyond
        /// the BO4E standard to be passed along.
        /// </example>
        [JsonIgnore]
        [ProtoIgnore]
        public const string USER_PROPERTIES_NAME = "userProperties";

        /// <summary>
        /// User properties (non bo4e standard)
        /// </summary>
        [JsonProperty(PropertyName = USER_PROPERTIES_NAME, Required = Required.Default,
            DefaultValueHandling = DefaultValueHandling.Ignore, Order = 200)]
        [JsonExtensionData]
        [ProtoMember(200)]
        [DataCategory(DataCategory.USER_PROPERTIES)]
        public IDictionary<string, JToken> UserProperties { get; set; }

        /// <summary>
        /// generates the BO4E boTyp attribute value (class name as upper case)
        /// </summary>
        protected BusinessObject()
        {
            //BoTyp = this.GetType().Name.ToUpper();
            VersionStruktur = 1;
        }

        /// <summary>
        /// return <see cref="BusinessObject.BoTyp"/> (as string, not as type)
        /// </summary>
        /// <returns></returns>
        public string GetBoTyp() => this.BoTyp;

        /// <summary>
        /// This method is just to make sure the mapping actually makes sense.
        /// </summary>
        /// <param name="_">name of the business object</param>
        protected void SetBoTyp(string _)
        {
            //Debug.Assert(boTyp == s);
        }

        /// <summary>
        /// obligatory version of the BO4E definition. Currently hard coded to 1
        /// </summary>
        /// <example>
        /// 1
        /// </example>
        [JsonProperty(PropertyName = "versionStruktur", Required = Required.Default, Order = 2)]
        [ProtoMember(2)]
        public int VersionStruktur { get; set; }

        /// <summary>
        /// allows adding a GUID to Business Objects for tracking across systems
        /// </summary>
        [JsonProperty(PropertyName = "guid", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public virtual Guid? Guid { get; set; }

        /// <summary>
        /// protobuf serilization requires the <see cref="Guid"/> as string.
        /// </summary>
        // note that this inheritance protobuf thing doesn't work as expected. please see the comments in TestBO4E project->TestProfobufSerialization
        [ProtoMember(3)]
#pragma warning disable IDE1006 // Naming Styles
        protected virtual string guidSerialized
#pragma warning restore IDE1006 // Naming Styles
        {
            get => this.Guid.HasValue ? this.Guid.ToString() : string.Empty;
            set { this.Guid = string.IsNullOrWhiteSpace(value) ? (Guid?)null : System.Guid.Parse(value.ToString()); }
        }
        /// <summary>
        /// Store the latest database update, is Datetime, because postgres doesn't handle datetimeoffset in a generated column gracefully
        /// </summary>
        [JsonProperty(PropertyName = "timestamp", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default, Order = 2)]
        [Timestamp]
        public DateTime? Timestamp { get; set; }



        /// <summary>
        /// Hier können IDs anderer Systeme hinterlegt werden (z.B. eine SAP-GP-Nummer) (Details siehe <see cref="ExterneReferenz"/>)
        /// </summary>
        [JsonProperty(PropertyName = "externeReferenzen", Required = Required.Default)]
        [ProtoMember(4)]
        public List<ExterneReferenz> ExterneReferenzen { get; set; }

        /// <summary>
        /// <inheritdoc cref="ExterneReferenzExtensions.TryGetExterneReferenz(ICollection{ExterneReferenz}, string, out string)"/>
        /// </summary>
        public bool TryGetExterneReferenz(string extRefName, out string extRefWert)
            => this.ExterneReferenzen.TryGetExterneReferenz(extRefName, out extRefWert);

        /// <summary>
        /// <inheritdoc cref="ExterneReferenzExtensions.SetExterneReferenz"/>
        /// </summary>
        public void SetExterneReferenz(ExterneReferenz extRef, bool overwriteExisting = false)
            => this.ExterneReferenzen = this.ExterneReferenzen.SetExterneReferenz(extRef, overwriteExisting);

        /// <summary>
        /// checks if the BusinessObject has a flag set.
        /// </summary>
        /// <remarks>"having a flag set" means that the Business Object has a UserProperty entry that has <paramref name="flagKey"/> as key and the value of the user property is true.</remarks>
        /// <param name="flagKey"></param>
        /// <returns>true iff flag is set and has value true</returns>
        public bool HasFlagSet(string flagKey)
        {
            if (string.IsNullOrWhiteSpace(flagKey))
            {
                throw new ArgumentNullException(nameof(flagKey));
            }
            try
            {
                return this.UserProperties != null && this.UserPropertyEquals(flagKey, other: (bool?)true);
            }
            catch (ArgumentNullException ane) when (ane.ParamName == "value")
            {
                return false;
            }
        }

        /// <summary>
        /// set the value of flag <paramref name="flagKey"/> to <paramref name="flagValue"/>.
        /// If there is no such flag or not user properties yet, they will be created.
        /// </summary>
        /// <remarks>"having a flag set" means that the Business Object has a UserProperty entry that has <paramref name="flagKey"/> as key and the value of the user property is true.</remarks>
        /// <param name="flagKey">key in the userproperties that should hold the value <paramref name="flagValue"/></param>
        /// <param name="flagValue">flag value, use null to remove the flag</param>
        /// <returns>true iff userProperties had been modified, false if not</returns>
        public bool SetFlag<TBusinessObject>(string flagKey, bool? flagValue = true) where TBusinessObject : BO4E.BO.BusinessObject, IUserProperties
        {
            if (string.IsNullOrWhiteSpace(flagKey))
            {
                throw new ArgumentNullException(nameof(flagKey));
            }
            if (this.UserProperties == null)
            {
                this.UserProperties = new Dictionary<string, JToken>();
                if (!flagValue.HasValue)
                {
                    return false;
                }
            }
            else if (flagValue.HasValue && flagValue.Value == this.HasFlagSet(flagKey))
            {
                return false;
            }
            if (!flagValue.HasValue)
            {
                if (!this.UserProperties.ContainsKey(flagKey))
                {
                    return false;
                }
                else
                {
                    this.UserProperties.Remove(flagKey);
                    return true;
                }
            }
            else
            {
                if (((TBusinessObject)this).TryGetUserProperty<bool?, TBusinessObject>(flagKey, out var existingValue) && existingValue == flagValue.Value)
                {
                    return false;
                }
                else
                {
                    this.UserProperties[flagKey] = flagValue.Value;
                }
                return true;
            }
        }

        /// <summary>
        /// returns a JSON scheme for the Business Object
        /// </summary>
        /// <returns>a JSON scheme</returns>
        public JSchema GetJsonScheme()
        {
            return GetJsonSchema(this.GetType());
        }

        /// <summary>
        /// returns a JSON scheme for the given type <paramref name="boType"/>
        /// </summary>
        /// <param name="boType">a type derived from <see cref="BusinessObject"/></param>
        /// <returns>a JSON scheme</returns>
        /// <exception cref="System.ArgumentException" />
        public static JSchema GetJsonSchema(Type boType)
        {
            if (!boType.IsSubclassOf(typeof(BusinessObject)))
            {
                throw new ArgumentException($"You must only request JSON schemes for Business Objects. {boType} is not a valid Business Object type.");
            }
            JSchemaGenerator generator = new JSchemaGenerator();
            generator.GenerationProviders.Add(new StringEnumGenerationProvider());
            JSchema schema = generator.Generate(boType);
            return schema;
        }

        /// <summary>
        /// Get a BO4E compliant URI for this business object.
        /// </summary>
        /// Use .ToString() on the result to pass it between services.
        /// <returns>a BO4E compliant URI object</returns>
        public Bo4eUri GetURI(bool includeUserProperties = false)
        {
            return Bo4eUri.GetUri(this, includeUserProperties);
        }

        /// <summary>
        /// (Some) Business Objects do have keys that should identify them in a unique manner across
        /// multiple systems. This method returns a list of these keys. The list contains the key
        /// names as they are serialised in JSON. This means that the fields PropertyName is part
        /// of the list if JsonPropertyAttribute.PropertyName is set in the Business Objects
        /// definition. Please do not use this method trying to access the actual key values. Use
        /// the <see cref="GetBoKeys"/> or <see cref="GetBoKeyProps(Type)"/> for this purpose.
        /// The list is sorted by the JsonPropertyAttribute.Order, assuming 0 if not specified.
        /// </summary>
        /// <returns>A list of the names (not the values) of the (composite) Business Object key or an empty list if no key attributes are defined.</returns>
        /// <example><code>
        /// Marktlokation malo = ... some initialisation code ...;
        /// malo.GetBoKeyNames()
        /// </code>
        /// [ "marktlokationsId" ]
        /// </example>
        /// <seealso cref="GetBoKeyNames(Type)"/>
        public List<string> GetBoKeyNames()
        {
            return GetBoKeyNames(this.GetType());
        }

        /// <summary>
        /// Same as <see cref="GetBoKeyNames(Type)"/> but allows static calling with a Business Object Type provided.
        /// </summary>
        /// <param name="boType">Business Object Type</param>
        /// <returns>A list just like the result of <see cref="GetBoKeyNames(Type)"/></returns>
        public static List<string> GetBoKeyNames(Type boType)
        {
            List<string> result = new List<string>();
            foreach (var pi in GetBoKeyProps(boType))
            {
                JsonPropertyAttribute jpa = pi.GetCustomAttribute<JsonPropertyAttribute>();
                if (jpa != null && jpa.PropertyName != null)
                {
                    result.Add(jpa.PropertyName);
                }
                else
                {
                    result.Add(pi.Name.ToString());
                }
            }
            return result;
        }

        /// <summary>
        /// This method returns information about the object structure, especially if there are
        /// nested field, that could be used, e.g. to expand OData queries.
        /// </summary>
        /// <param name="boType">valid business object type
        /// <example>
        /// <code>typeof(Marktlokation)</code>
        /// </example></param>
        /// <returns>
        /// A dictionary with field names as keys (or the different JSON property name if set)
        /// and the type of the property as value. Nesting and different layers are denoted by
        /// using "."
        /// </returns>
        public static Dictionary<string, Type> GetExpandablePropertyNames(Type boType)
        {
            return GetExpandablePropertyNames(boType, true);
        }

        /// <summary>
        /// <see cref="GetExpandablePropertyNames(Type)"/>
        /// </summary>
        /// <param name="boTypeName">name of the business object as string</param>
        /// <returns><see cref="GetExpandablePropertyNames(Type)"/></returns>
        public static Dictionary<string, Type> GetExpandableFieldNames(string boTypeName)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            Type clazz = Assembly.GetExecutingAssembly().GetType(BoMapper.packagePrefix + "." + boTypeName);
#pragma warning restore CS0618 // Type or member is obsolete
            if (clazz == null)
            {
#pragma warning disable CS0618 // Type or member is obsolete
                throw new ArgumentException($"{boTypeName} is not a valid Business Object name. Use one of the following: {string.Join("\n -", BoMapper.GetValidBoNames())}");
#pragma warning restore CS0618 // Type or member is obsolete
            }
            return GetExpandablePropertyNames(clazz);
        }

        /// <summary>
        /// recursive function to return all expandable fields for a given type <paramref name="type"/>.
        /// Set <paramref name="rootLevel"/> when calling from outside the function itself.
        /// </summary>
        /// <param name="type">Type inherited from Business Object</param>
        /// <param name="rootLevel">true iff calling from outside the function itself / default</param>
        /// <returns>HashSet of strings</returns>
        protected static Dictionary<string, Type> GetExpandablePropertyNames(Type type, bool rootLevel = true)
        {
            if (rootLevel && !type.IsSubclassOf(typeof(BO.BusinessObject)))
            {
                throw new ArgumentException("Only allowed for BusinessObjects");
            }
            Dictionary<string, Type> result = new Dictionary<string, Type>();
            foreach (var prop in type.GetProperties())
            {
                string fieldName;
                JsonPropertyAttribute jpa = prop.GetCustomAttribute<JsonPropertyAttribute>();
                if (jpa != null && jpa.PropertyName != null)
                {
                    fieldName = jpa.PropertyName;
                }
                else
                {
                    fieldName = prop.Name;
                }
                if (prop.PropertyType.IsSubclassOf(typeof(BO.BusinessObject)))
                {
                    foreach (KeyValuePair<string, Type> subResult in GetExpandablePropertyNames(prop.PropertyType, false))

                    {
                        result.Add(string.Join(".", new string[] { fieldName, subResult.Key }), subResult.Value);
                    }
                    result.Add(fieldName, prop.PropertyType);
                }
                else if (prop.PropertyType.IsSubclassOf(typeof(COM.COM)))
                {
                    result.Add(fieldName, prop.PropertyType);
                    // coms do not contain any exandable subfield since they're flat
                }
                else if (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(List<>))
                {
                    Type listElementType = prop.PropertyType.GetGenericArguments()[0];
                    foreach (KeyValuePair<string, Type> subResult in GetExpandablePropertyNames(listElementType, false))
                    {
                        result.Add(string.Join(".", new string[] { fieldName, subResult.Key }), subResult.Value);
                    }
                    result.Add(fieldName, prop.PropertyType);
                }
                else
                {
                    // nada
                }
            }
            return result;
        }

        /// <summary>
        /// Get a dictionary containing the key values of this Business Object.
        /// The dictionary has the JsonPropertyAttribute.PropertyName or FieldName
        /// of the key as key and the actual key value as value.
        /// </summary>
        /// <seealso cref="GetBoKeyProps(Type)"/>
        /// <returns>A dictionary with key value pairs.</returns>
        public Dictionary<string, object> GetBoKeys()
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            foreach (var pi in GetBoKeyProps(this.GetType()))
            {
                JsonPropertyAttribute jpa = pi.GetCustomAttribute<JsonPropertyAttribute>();
                if (jpa != null && jpa.PropertyName != null)
                {
                    result.Add(jpa.PropertyName, pi.GetValue(this));
                }
                else
                {
                    result.Add(pi.Name, pi.GetValue(this));
                }
            }
            return result;
        }

        /// <summary>
        /// Get a list of FieldInfo objects that contain the key of a Business Object.
        /// The list is sorted by the JsonPropertyAttribute.Order, assuming 0 if not specified.
        /// </summary>
        /// <param name="boType">Business Object type</param>
        /// <returns>A list of FieldInfos to be used for accessing the key values.</returns>
        public static List<PropertyInfo> GetBoKeyProps(Type boType)
        {
            if (!boType.IsSubclassOf(typeof(BusinessObject)))
            {
                throw new ArgumentException($"Business Object keys are only defined on Business Object types but {boType} is not a Business Object.");
            }
            return boType.GetProperties()
                 .Where(p => p.GetCustomAttributes(typeof(BoKey), false).Length > 0)
                 .OrderBy(ap => ap.GetCustomAttribute<JsonPropertyAttribute>()?.Order)
                 .ToList<PropertyInfo>();
        }

        /// <summary>BO4E Business Objects are considered equal iff all of their elements/fields are equal.</summary>
        /// <param name="b">another object</param>
        /// <returns><code>true</code> iff b has the same type as this object and all elements of this and object b are equal; <code>false</code> otherwise</returns>
        public override bool Equals(object b)
        {
            if (b == null || b.GetType() != this.GetType())
            {
                return false;
            }
            return this.Equals(b as BusinessObject);
        }

        /// <summary>
        /// BO4E Business Objects are considered equal iff all of their elements/fields are equal.
        /// </summary>
        /// The method throws an argument exception if you try to test invalid BO4E objects for
        /// equality, e.g. when at least one of the compared objects does lack mandatory fields.
        /// <param name="b">another Business Object</param>
        /// <returns>
        /// <code>true</code> iff b has the same type as this object and all elements
        /// of this and object b are equal; <code>false</code> otherwise
        /// </returns>
        public bool Equals(BusinessObject b)
        {
            if (b == null || b.GetType() != this.GetType())
            {
                return false;
            }
            try
            {
                return JsonConvert.SerializeObject(this) == JsonConvert.SerializeObject(b);
            }
            catch (JsonSerializationException e)
            {
                throw new ArgumentException($"You must not compare/call equals() on invalid Business Objects: {e.Message}");
            }
        }

        /// <summary>
        /// override hash code generation
        /// </summary>
        /// <returns>hash code as int</returns>
        public override int GetHashCode()
        {
            int result = 31;  // I read online that a medium sized prime was a good choice ;)
            unchecked
            {
                result *= this.GetType().GetHashCode();
                foreach (var prop in this.GetType().GetProperties())
                {
                    if (prop.GetValue(this) != null)
                    {
                        if (prop.GetValue(this).GetType().IsGenericType && prop.GetValue(this).GetType().GetGenericTypeDefinition() == typeof(List<>))
                        {
                            IEnumerable enumerable = prop.GetValue(this) as IEnumerable;
                            Type listElementType = prop.GetValue(this).GetType().GetGenericArguments()[0];
                            Type listType = typeof(List<>).MakeGenericType(listElementType);
                            int index = 0;
                            foreach (object listItem in enumerable)
                            {
                                // the index/position inside the list is taken into account, because
                                // if two lists contain the same items but in different order, they must not be considered equal.
                                result *= 19 + (17 * (++index)) * listItem.GetHashCode();
                            }
                        }
                        else
                        {
                            // Using + 19 because the default hash code of uninitialised enums is zero.
                            // This would screw up the calculation such that all objects with at least one null value had the same hash code, namely 0.
                            result *= 19 + prop.GetValue(this).GetHashCode();
                        }
                    }
                }
                return result;
            }
        }

        /// <summary>
        /// Tests if the object does contain all mandatory information / fields.
        /// To do so, the function tries to serialize the object as JSON.
        /// If the serialization fails due to fields that are <see cref="JsonPropertyAttribute.Required"/> but not filled
        /// it returns false and true otherwise.
        /// </summary>
        /// <returns>true if COM object is compatible with BO4E standards</returns>
        public virtual bool IsValid()
        {
            try
            {
                JsonConvert.SerializeObject(this);
            }
            catch (JsonSerializationException)
            {
                return false;
            }
            return true;
        }

        internal class BaseSpecifiedConcreteClassConverter : DefaultContractResolver
        {
            protected override JsonConverter ResolveContractConverter(Type objectType)
            {
                if (typeof(BusinessObject).IsAssignableFrom(objectType) && !objectType.IsAbstract)
                {
                    return null; // pretend TableSortRuleConvert is not specified (thus avoiding a stack overflow)
                }
                return base.ResolveContractConverter(objectType);
            }
        }

        internal class BusinessObjectBaseConverter : JsonConverter
        {
            //private static readonly JsonSerializerSettings SpecifiedSubclassConversion = new JsonSerializerSettings() { ContractResolver = new BaseSpecifiedConcreteClassConverter() };

            public override bool CanConvert(Type objectType)
            {
                return (objectType == typeof(BusinessObject));
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null)
                {
                    return null;
                }
                if (objectType.IsAbstract)
                {
                    JObject jo = JObject.Load(reader);
                    Type boType;
                    if (serializer.TypeNameHandling.HasFlag(TypeNameHandling.Objects) && jo.TryGetValue("$type", out JToken typeToken))
                    {
                        boType = BusinessObjectSerializationBinder.BusinessObjectAndCOMTypes.Where(t => typeToken.Value<string>().ToUpper().StartsWith(t.FullName.ToUpper())).SingleOrDefault();
                    }
                    else if (!jo.ContainsKey("boTyp"))
                    {
                        throw new ArgumentException("If deserializing into an abstract BusinessObject the key \"boTyp\" has to be set. But it wasn't.");
                    }
                    else
                    {
#pragma warning disable CS0618 // Type or member is obsolete
                        boType = BoMapper.GetTypeForBoName(jo["boTyp"].Value<string>()); // ToDo: catch exception if boTyp is not set and throw exception with descriptive error message
#pragma warning restore CS0618 // Type or member is obsolete
                    }
                    if (boType == null)
                    {
                        foreach (var assembley in AppDomain.CurrentDomain.GetAssemblies())
                        {
                            try
                            {
                                boType = assembley.GetTypes().FirstOrDefault(x => x.Name.ToUpper() == jo["boTyp"].Value<string>().ToUpper());
                            }
                            catch (ReflectionTypeLoadException)
                            {
                                continue;
                            }
                            if (boType != null)
                            {
                                break;
                            }
                        }
                        if (boType == null)
                        {
                            throw new NotImplementedException($"The type '{jo["boTyp"].Value<string>()}' does not exist in the BO4E standard.");
                        }
                    }
                    var deserializationMethod = serializer.GetType() // https://stackoverflow.com/a/5218492/10009545
                         .GetMethods()
                         .Where(m => m.Name == nameof(serializer.Deserialize))
                         .Select(m => new
                         {
                             Method = m,
                             Params = m.GetParameters(),
                             Args = m.GetGenericArguments()
                         })
                         .Where(x => x.Params.Length == 1
                                     && x.Args.Length == 1)
                         .Select(x => x.Method)
                         .First()
                         .GetGenericMethodDefinition()
                         .MakeGenericMethod(new Type[] { boType });
                    try
                    {
                        return deserializationMethod.Invoke(serializer, new object[] { jo.CreateReader() });
                    }
                    catch (TargetInvocationException tie) when (tie.InnerException != null)
                    {
                        throw tie.InnerException; // to hide the reflection to the outside.
                    }
                }
                else
                {
                    serializer.ContractResolver.ResolveContract(objectType).Converter = null;
                    return serializer.Deserialize(JObject.Load(reader).CreateReader(), objectType);
                }
            }

            public override bool CanWrite
            {
                get { return false; }
            }

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                throw new NotImplementedException("Serializing an abstract BusinessObject is not supported."); // won't be called because CanWrite returns false
            }
        }
    }
}