using BO4E.COM;
using BO4E.meta;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;
using Newtonsoft.Json.Serialization;

using ProtoBuf;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

using JsonConverter = Newtonsoft.Json.JsonConverter;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace BO4E.BO
{
    /// <summary>
    ///     General abstract class for Business Objects for Energy (BO4E)
    /// </summary>
    /// This class is not intended to be instantiated. It just provides the boTyp and version
    /// attribute which are obligatory for all BO4E business objects.
    /// <author>Hochfrequenz Unternehmensberatung GmbH</author>
    [Newtonsoft.Json.JsonConverter(typeof(BusinessObjectBaseConverter))]
    [System.Text.Json.Serialization.JsonConverter(typeof(BusinessObjectSystemTextJsonBaseConverter))]
    //[ProtoContract] // If I add this I get an error message: "System.InvalidOperationException: Duplicate field-number detected; 1 on: BO4E.BO.BusinessObject"
    [ProtoInclude(1, typeof(Angebot))]
    [ProtoInclude(2, typeof(Ansprechpartner))]
    [ProtoInclude(3, typeof(Auftrag))]
    [ProtoInclude(4, typeof(Benachrichtigung))]
    [ProtoInclude(5, typeof(Energiemenge))]
    [ProtoInclude(6, typeof(Geschaeftspartner))]
    [ProtoInclude(7, typeof(Kosten))]
    [ProtoInclude(8, typeof(Marktlokation))]
    //[ProtoInclude(8, typeof(Marktteilnehmer))] // https://stackoverflow.com/a/13791539/10009545
    [ProtoInclude(9, typeof(Messlokation))]
    [ProtoInclude(10, typeof(Preisblatt))]
    [ProtoInclude(11, typeof(Rechnung))]
    [ProtoInclude(12, typeof(Region))]
    [ProtoInclude(13, typeof(Vertrag))]
    [ProtoInclude(14, typeof(Zaehler))]
    [ProtoInclude(16, typeof(Bilanzierung))]
    [ProtoInclude(17, typeof(Sperrauftrag))]
    [ProtoInclude(18, typeof(Entsperrauftrag))]
#pragma warning disable CS0618 // Type or member is obsolete
    [ProtoInclude(19, typeof(AuftragsStorno))]
#pragma warning restore CS0618 // Type or member is obsolete
    [ProtoInclude(20, typeof(Statusbericht))]
    [ProtoInclude(21, typeof(Reklamation))]
    [ProtoInclude(22, typeof(Avis))]
    [ProtoInclude(23, typeof(Handelsunstimmigkeit))]
    [ProtoInclude(24, typeof(Berechnungsformel))]
    [ProtoInclude(25, typeof(Anfrage))]
    [ProtoInclude(26, typeof(Zaehlzeitdefinition))]
    [ProtoInclude(27, typeof(Wechsel))]
    [ProtoInclude(28, typeof(Tranche))]
    [ProtoInclude(29, typeof(Netzlokation))]
    [ProtoInclude(29, typeof(SteuerbareRessource))]
    public abstract class BusinessObject : IUserProperties, IOptionalGuid
    {
        /// <summary>
        ///     Fields that are not part of the BO4E-definition are stored in a element, that is
        ///     accessable under the key defined in userPropertiesName.
        /// </summary>
        /// This JObject representing a Messlokation
        /// <example>
        ///     <code>
        /// {
        ///    "boTyp": "MESSLOKATION",
        ///    "versionStruktur": 1,
        ///    "messLokationsId": "DE123...",
        ///    "irgendwas unbekanntes": "xyz"
        /// }
        /// </code>
        ///     is mapped to
        ///     <code>
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
        ///     This keeps the Business Object simple but allows for user specific arguments beyond
        ///     the BO4E standard to be passed along.
        /// </example>
        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        [ProtoIgnore]
        public const string USER_PROPERTIES_NAME = "userProperties";


        /// <summary>
        ///     generates the BO4E boTyp attribute value (class name as upper case)
        /// </summary>
        [System.Text.Json.Serialization.JsonConstructor]
        public BusinessObject()
        {
            //BoTyp = this.GetType().Name.ToUpper();
            VersionStruktur = "1";
        }

        /// <summary>
        ///     obligatory type of the business object in UPPER CASE
        /// </summary>
        /// <example>
        ///     'MESSLOKATION',
        ///     'MARKTLOKATION'
        /// </example>
        [JsonProperty(Required = Required.Default, Order = 1, PropertyName = "boTyp")]
        [JsonPropertyName("boTyp")]
        [JsonPropertyOrder(1)]
        [ProtoMember(1)]
        public string? BoTyp
        {
            get => GetType().Name.ToUpper();
            set { }
        }

        /// <summary>
        ///     obligatory version of the BO4E definition. Currently hard coded to 1
        /// </summary>
        /// <example>
        ///     1
        /// </example>
        [JsonProperty(PropertyName = "versionStruktur", Required = Required.Default, Order = 2)]
        [JsonPropertyName("versionStruktur")]
        [JsonPropertyOrder(2)]
        [ProtoMember(2)]
        public string? VersionStruktur { get; set; }

        /// <summary>
        ///     protobuf serilization requires the <see cref="Guid" /> as string.
        /// </summary>
        // note that this inheritance protobuf thing doesn't work as expected. please see the comments in TestBO4E project->TestProfobufSerialization
        [ProtoMember(3)]
#pragma warning disable IDE1006 // Naming Styles
        protected virtual string guidSerialized
#pragma warning restore IDE1006 // Naming Styles
        {
            get => Guid.HasValue ? Guid.ToString() : string.Empty;
            set { Guid = string.IsNullOrWhiteSpace(value) ? (Guid?)null : System.Guid.Parse(value); }
        }

        /// <summary>
        /// a protobuf serializable TimeStamp
        /// </summary>
        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        [ProtoMember(4, Name = nameof(Timestamp))]
        [CompatibilityLevel(CompatibilityLevel.Level240)]
        protected DateTime _TimeStamp
        {
            get => Timestamp ?? default;
            set => Timestamp = value == default ? null : DateTime.SpecifyKind(value, DateTimeKind.Utc);
        }

        /// <summary>
        ///     Store the latest database update, is Datetime, because postgres doesn't handle datetimeoffset in a generated column
        ///     gracefully
        /// </summary>
        [JsonProperty(PropertyName = "timestamp", NullValueHandling = NullValueHandling.Ignore,
            Required = Required.Default, Order = 3)]
        [JsonPropertyName("timestamp")]
        [JsonPropertyOrder(3)]
        [ProtoIgnore]
        public DateTime? Timestamp { get; set; }


        /// <summary>
        ///     Hier können IDs anderer Systeme hinterlegt werden (z.B. eine SAP-GP-Nummer) (Details siehe
        ///     <see cref="ExterneReferenz" />)
        /// </summary>
        [JsonProperty(PropertyName = "externeReferenzen", Required = Required.Default, Order = 4)]
        [JsonPropertyName("externeReferenzen")]
        [JsonPropertyOrder(4)]
        [ProtoMember(4)]
        public List<ExterneReferenz>? ExterneReferenzen { get; set; }

        /// <summary>
        ///     allows adding a GUID to Business Objects for tracking across systems
        /// </summary>
        [JsonProperty(PropertyName = "guid", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default, Order = 5)]
        [JsonPropertyName("guid")]
        [JsonPropertyOrder(5)]
        public virtual Guid? Guid { get; set; }

        /// <summary>
        ///     User properties (non bo4e standard)
        /// </summary>
        [JsonProperty(PropertyName = USER_PROPERTIES_NAME, Required = Required.Default,
            DefaultValueHandling = DefaultValueHandling.Ignore, Order = 200)]
        [Newtonsoft.Json.JsonExtensionData]
        [ProtoMember(200)]
        [JsonPropertyOrder(200)]
        [DataCategory(DataCategory.USER_PROPERTIES)]
        [System.Text.Json.Serialization.JsonExtensionData]
        public IDictionary<string, object>? UserProperties { get; set; }

        /// <summary>
        ///     return <see cref="BusinessObject.BoTyp" /> (as string, not as type)
        /// </summary>
        /// <returns></returns>
        public string GetBoTyp()
        {
            return BoTyp;
        }

        /// <summary>
        ///     This method is just to make sure the mapping actually makes sense.
        /// </summary>
        /// <param name="_">name of the business object</param>
        protected void SetBoTyp(string _)
        {
            //Debug.Assert(boTyp == s);
        }

        /// <summary>
        ///     <inheritdoc
        ///         cref="ExterneReferenzExtensions.TryGetExterneReferenz(ICollection{ExterneReferenz}, string, out string)" />
        /// </summary>
        public bool TryGetExterneReferenz(string extRefName, out string extRefWert)
        {
            return ExterneReferenzen.TryGetExterneReferenz(extRefName, out extRefWert);
        }

        /// <summary>
        ///     <inheritdoc cref="ExterneReferenzExtensions.SetExterneReferenz" />
        /// </summary>
        public void SetExterneReferenz(ExterneReferenz extRef, bool overwriteExisting = false)
        {
            ExterneReferenzen = ExterneReferenzen.SetExterneReferenz(extRef, overwriteExisting);
        }

        /// <summary>
        ///     returns a JSON scheme for the Business Object
        /// </summary>
        /// <returns>a JSON scheme</returns>
        public JSchema GetJsonScheme()
        {
            return GetJsonSchema(GetType());
        }

        /// <summary>
        ///     returns a JSON scheme for the given type <paramref name="boType" />
        /// </summary>
        /// <param name="boType">a type derived from <see cref="BusinessObject" /></param>
        /// <returns>a JSON scheme</returns>
        /// <exception cref="System.ArgumentException" />
        public static JSchema GetJsonSchema(Type boType)
        {
            if (!boType.IsSubclassOf(typeof(BusinessObject)))
                throw new ArgumentException(
                    $"You must only request JSON schemes for Business Objects. {boType} is not a valid Business Object type.");
            var generator = new JSchemaGenerator();
            generator.GenerationProviders.Add(new StringEnumGenerationProvider());
            var schema = generator.Generate(boType);
            return schema;
        }

        /// <summary>
        ///     Get a BO4E compliant URI for this business object.
        /// </summary>
        /// Use .ToString() on the result to pass it between services.
        /// <returns>a BO4E compliant URI object</returns>
        public Bo4eUri GetURI(bool includeUserProperties = false)
        {
            return Bo4eUri.GetUri(this, includeUserProperties);
        }

        /// <summary>
        ///     (Some) Business Objects do have keys that should identify them in a unique manner across
        ///     multiple systems. This method returns a list of these keys. The list contains the key
        ///     names as they are serialised in JSON. This means that the fields PropertyName is part
        ///     of the list if JsonPropertyAttribute.PropertyName is set in the Business Objects
        ///     definition. Please do not use this method trying to access the actual key values. Use
        ///     the <see cref="GetBoKeys" /> or <see cref="GetBoKeyProps(Type)" /> for this purpose.
        ///     The list is sorted by the JsonPropertyAttribute.Order, assuming 0 if not specified.
        /// </summary>
        /// <returns>
        ///     A list of the names (not the values) of the (composite) Business Object key or an empty list if no key
        ///     attributes are defined.
        /// </returns>
        /// <example>
        ///     <code>
        /// Marktlokation malo = ... some initialisation code ...;
        /// malo.GetBoKeyNames()
        /// </code>
        ///     [ "marktlokationsId" ]
        /// </example>
        /// <seealso cref="GetBoKeyNames(Type)" />
        public List<string> GetBoKeyNames()
        {
            return GetBoKeyNames(GetType());
        }

        /// <summary>
        ///     Same as <see cref="GetBoKeyNames(Type)" /> but allows static calling with a Business Object Type provided.
        /// </summary>
        /// <param name="boType">Business Object Type</param>
        /// <returns>A list just like the result of <see cref="GetBoKeyNames(Type)" /></returns>
        public static List<string> GetBoKeyNames(Type boType)
        {
            var result = new List<string>();
            foreach (var pi in GetBoKeyProps(boType))
            {
                var jpa = pi.GetCustomAttribute<JsonPropertyAttribute>();
                result.Add(jpa?.PropertyName != null ? jpa.PropertyName : pi.Name);
            }

            return result;
        }

        /// <summary>
        ///     This method returns information about the object structure, especially if there are
        ///     nested field, that could be used, e.g. to expand OData queries.
        /// </summary>
        /// <param name="boType">
        ///     valid business object type
        ///     <example>
        ///         <code>typeof(Marktlokation)</code>
        ///     </example>
        /// </param>
        /// <returns>
        ///     A dictionary with field names as keys (or the different JSON property name if set)
        ///     and the type of the property as value. Nesting and different layers are denoted by
        ///     using "."
        /// </returns>
        public static Dictionary<string, Type> GetExpandablePropertyNames(Type boType)
        {
            return GetExpandablePropertyNames(boType, true);
        }

        /// <summary>
        ///     <see cref="GetExpandablePropertyNames(Type)" />
        /// </summary>
        /// <param name="boTypeName">name of the business object as string</param>
        /// <returns>
        ///     <see cref="GetExpandablePropertyNames(Type)" />
        /// </returns>
        public static Dictionary<string, Type> GetExpandableFieldNames(string boTypeName)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            var clazz = Assembly.GetExecutingAssembly().GetType(BoMapper.PackagePrefix + "." + boTypeName);
#pragma warning restore CS0618 // Type or member is obsolete
            if (clazz == null)
            {
#pragma warning disable CS0618 // Type or member is obsolete
                throw new ArgumentException(
                    $"{boTypeName} is not a valid Business Object name. Use one of the following: {string.Join("\n -", BoMapper.GetValidBoNames())}");
#pragma warning restore CS0618 // Type or member is obsolete
            }

            return GetExpandablePropertyNames(clazz);
        }

        /// <summary>
        ///     recursive function to return all expandable fields for a given type <paramref name="type" />.
        ///     Set <paramref name="rootLevel" /> when calling from outside the function itself.
        /// </summary>
        /// <param name="type">Type inherited from Business Object</param>
        /// <param name="rootLevel">true iff calling from outside the function itself / default</param>
        /// <returns>HashSet of strings</returns>
        protected static Dictionary<string, Type> GetExpandablePropertyNames(Type type, bool rootLevel = true)
        {
            if (rootLevel && !type.IsSubclassOf(typeof(BusinessObject)))
                throw new ArgumentException("Only allowed for BusinessObjects");
            var result = new Dictionary<string, Type>();
            foreach (var prop in type.GetProperties())
            {
                string fieldName;
                var jpa = prop.GetCustomAttribute<JsonPropertyAttribute>();
                if (jpa?.PropertyName != null)
                    fieldName = jpa.PropertyName;
                else
                    fieldName = prop.Name;
                if (prop.PropertyType.IsSubclassOf(typeof(BusinessObject)))
                {
                    foreach (var subResult in GetExpandablePropertyNames(prop.PropertyType, false))
                        result.Add(string.Join(".", fieldName, subResult.Key), subResult.Value);
                    result.Add(fieldName, prop.PropertyType);
                }
                else if (prop.PropertyType.IsSubclassOf(typeof(COM.COM)))
                {
                    result.Add(fieldName, prop.PropertyType);
                    // coms do not contain any exandable subfield since they're flat
                }
                else if (prop.PropertyType.IsGenericType &&
                         prop.PropertyType.GetGenericTypeDefinition() == typeof(List<>))
                {
                    var listElementType = prop.PropertyType.GetGenericArguments()[0];
                    foreach (var subResult in GetExpandablePropertyNames(listElementType, false))
                        result.Add(string.Join(".", fieldName, subResult.Key), subResult.Value);
                    result.Add(fieldName, prop.PropertyType);
                }
            }

            return result;
        }

        /// <summary>
        ///     Get a dictionary containing the key values of this Business Object.
        ///     The dictionary has the JsonPropertyAttribute.PropertyName or FieldName
        ///     of the key as key and the actual key value as value.
        /// </summary>
        /// <seealso cref="GetBoKeyProps(Type)" />
        /// <returns>A dictionary with key value pairs.</returns>
        public Dictionary<string, object> GetBoKeys()
        {
            var result = new Dictionary<string, object>();
            foreach (var pi in GetBoKeyProps(GetType()))
            {
                var jpa = pi.GetCustomAttribute<JsonPropertyAttribute>();
                result.Add(jpa?.PropertyName != null ? jpa.PropertyName : pi.Name, pi.GetValue(this));
            }

            return result;
        }

        /// <summary>
        ///     Get a list of FieldInfo objects that contain the key of a Business Object.
        ///     The list is sorted by the JsonPropertyAttribute.Order, assuming 0 if not specified.
        /// </summary>
        /// <param name="boType">Business Object type</param>
        /// <returns>A list of FieldInfos to be used for accessing the key values.</returns>
        public static List<PropertyInfo> GetBoKeyProps(Type boType)
        {
            if (!boType.IsSubclassOf(typeof(BusinessObject)))
                throw new ArgumentException(
                    $"Business Object keys are only defined on Business Object types but {boType} is not a Business Object.");
            return boType.GetProperties()
                .Where(p => p.GetCustomAttributes(typeof(BoKey), false).Length > 0)
                .OrderBy(ap => ap.GetCustomAttribute<JsonPropertyAttribute>()?.Order)
                .ToList();
        }

        /// <summary>
        ///     Tests if the object does contain all mandatory information / fields.
        ///     To do so, the function tries to serialize the object as JSON.
        ///     If the serialization fails due to fields that are <see cref="JsonPropertyAttribute.Required" /> but not filled
        ///     it returns false and true otherwise.
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
                    return null; // pretend TableSortRuleConvert is not specified (thus avoiding a stack overflow)
                return base.ResolveContractConverter(objectType);
            }
        }

        internal class BusinessObjectBaseConverter : JsonConverter
        {
            public override bool CanWrite => false;
            //private static readonly JsonSerializerSettings SpecifiedSubclassConversion = new JsonSerializerSettings() { ContractResolver = new BaseSpecifiedConcreteClassConverter() };

            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(BusinessObject);
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
                JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                if (objectType.IsAbstract)
                {
                    var jo = JObject.Load(reader);
                    Type boType;
                    if (serializer.TypeNameHandling.HasFlag(TypeNameHandling.Objects) &&
                        jo.TryGetValue("$type", out var typeToken))
                    {
                        boType = BusinessObjectSerializationBinder.BusinessObjectAndCOMTypes.SingleOrDefault(t =>
                            typeToken.Value<string>().ToUpper().StartsWith(t.FullName.ToUpper()));
                    }
                    else if (!jo.ContainsKey("boTyp"))
                    {
                        throw new ArgumentException(
                            "If deserializing into an abstract BusinessObject the key \"boTyp\" has to be set. But it wasn't.");
                    }
                    else
                    {
#pragma warning disable CS0618 // Type or member is obsolete
                        boType = BoMapper.GetTypeForBoName(jo["boTyp"]
                            .Value<string>()); // ToDo: catch exception if boTyp is not set and throw exception with descriptive error message
#pragma warning restore CS0618 // Type or member is obsolete
                    }

                    if (boType == null)
                    {
                        foreach (var assembley in AppDomain.CurrentDomain.GetAssemblies())
                        {
                            try
                            {
                                boType = assembley.GetTypes().FirstOrDefault(x => string.Equals(x.Name,
                                    jo["boTyp"].Value<string>(), StringComparison.CurrentCultureIgnoreCase));
                            }
                            catch (ReflectionTypeLoadException)
                            {
                                continue;
                            }

                            if (boType != null) break;
                        }

                        if (boType == null)
                            throw new NotImplementedException(
                                $"The type '{jo["boTyp"].Value<string>()}' does not exist in the BO4E standard.");
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
                        .MakeGenericMethod(boType);
                    try
                    {
                        return deserializationMethod.Invoke(serializer, new object[] { jo.CreateReader() });
                    }
                    catch (TargetInvocationException tie) when (tie.InnerException != null)
                    {
                        throw tie.InnerException; // to hide the reflection to the outside.
                    }
                }

                serializer.ContractResolver.ResolveContract(objectType).Converter = null;
                return serializer.Deserialize(JObject.Load(reader).CreateReader(), objectType);
            }

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                throw new NotImplementedException(
                    "Serializing an abstract BusinessObject is not supported."); // won't be called because CanWrite returns false
            }
        }

        internal class
            BusinessObjectSystemTextJsonBaseConverter : System.Text.Json.Serialization.JsonConverter<BusinessObject>
        {
            //private static readonly JsonSerializerSettings SpecifiedSubclassConversion = new JsonSerializerSettings() { ContractResolver = new BaseSpecifiedConcreteClassConverter() };

            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(BusinessObject);
            }

            public override BusinessObject Read(ref Utf8JsonReader reader, Type typeToConvert,
                JsonSerializerOptions options)
            {
                if (reader.TokenType == JsonTokenType.Null) return null;
                if (typeToConvert.IsAbstract)
                {
                    var jdoc = JsonDocument.ParseValue(ref reader);
                    if (!jdoc.RootElement.TryGetProperty("BoTyp", out var boTypeProp))
                        boTypeProp = jdoc.RootElement.GetProperty("boTyp");
                    var boTypeString = boTypeProp.GetString();
#pragma warning disable CS0618 // Type or member is obsolete
                    var boType = BoMapper.GetTypeForBoName(boTypeString);
#pragma warning restore CS0618 // Type or member is obsolete
                    if (boType == null)
                    {
                        foreach (var assembley in AppDomain.CurrentDomain.GetAssemblies())
                        {
                            try
                            {
                                boType = assembley.GetTypes().FirstOrDefault(x =>
                                    string.Equals(x.Name, boTypeString, StringComparison.CurrentCultureIgnoreCase));
                            }
                            catch (ReflectionTypeLoadException)
                            {
                                continue;
                            }

                            if (boType != null) break;
                        }

                        if (boType == null)
                            throw new NotImplementedException(
                                $"The type '{boTypeString}' does not exist in the BO4E standard.");
                    }

                    return System.Text.Json.JsonSerializer.Deserialize(jdoc.RootElement.GetRawText(), boType, options)
                        as BusinessObject;
                }

                return null;
            }


            public override void Write(Utf8JsonWriter writer, BusinessObject value, JsonSerializerOptions options)
            {
                var boTypeString = value.GetBoTyp();
#pragma warning disable CS0618 // Type or member is obsolete
                var boType = BoMapper.GetTypeForBoName(boTypeString);
#pragma warning restore CS0618 // Type or member is obsolete
                System.Text.Json.JsonSerializer.Serialize(writer, value, boType, options);
            }
        }
    }
}
