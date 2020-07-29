using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

using BO4E.BO;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BO4E.meta
{
    /// <summary>
    /// Bo4eUri class is derived from System.Uri and works the same way. It's just a bit more strict in validation.
    /// </summary>
    [TypeConverter(typeof(StringUriConverter))]
    public class Bo4eUri : Uri
    {
        private const string BO4E_SCHEME = "bo4e://";
        private const string NULL_KEY_PLACEHOLDER = "~"; // an allowed character in URLs that is not escaped
        private static readonly Regex FILTER_AND_PATTERN = new Regex(@"\s*(?<key>\w+)\s*(?:=|eq)\s*(['""]|)(?<value>\w+)\1\s*(?:and)?\s*", RegexOptions.IgnoreCase | RegexOptions.Compiled); // \1 backreferences the '" group (in c#, would be \2 in other parsers)

        /// <summary>
        /// Instantiates a Bo4eUri object. Throws Argument(Null)Exception if URI is null, not well formed (<see cref="System.Uri.IsWellFormedOriginalString"/> or doesn't match the bo4e uri regex.
        /// </summary>
        /// <param name="uri">URI string to be processed</param>
        public Bo4eUri(string uri) : base(uri)
        {
            if (uri == null)
            {
                throw new ArgumentNullException("URI string must not be null.");
            }
            /*if (!base.IsWellFormedOriginalString())
            {
                throw new ArgumentException($"The URI {uri} is not well formed.");
            }*/
            if (base.Scheme + "://" != BO4E_SCHEME)
            {
                throw new ArgumentException($"The scheme '{base.Scheme}' in {uri} is not valid. Expected '{BO4E_SCHEME}://'");
            }
            if (GetBoName() == null)
            {
                throw new ArgumentException($"There is no Business Object of type '{base.Host}'.");
            }
        }

        /// <summary>
        /// implicit casting operator for strings (useful during de serialising
        /// </summary>
        /// <param name="input">string </param>
        public static implicit operator Bo4eUri(string input)
        {
            return new Bo4eUri(input);
        }

        /// <summary>
        /// Get name of business object with correct upper/lower case (the host value)
        /// </summary>
        /// <returns>business object name or null iff there is no such object</returns>
        public string GetBoName()
        {
            foreach (string boName in BoMapper.GetValidBoNames())
            {
                if (boName.ToUpper().Equals(this.Host.ToUpper()))
                {
                    return boName;
                }
            }
            return null;
        }

        /// <summary>
        /// Get type of business object (e.g. to be used with Activator.CreateInstance) 
        /// </summary>
        /// <returns>business object type of null iff there is no such object</returns>
        public Type GetBoType()
        {
            string boName = GetBoName();
            if (boName == null)
            {
                return null;
            }
            else
            {
                return Assembly.GetExecutingAssembly().GetTypes().Where(t => t.Name.Equals(boName)).FirstOrDefault();
            }
        }

        /// <summary>
        /// Repeatedly calls Uri.UnescapeDataString until the result doesn't change any more.
        /// </summary>
        /// <param name="stringToUnescape">string to unescape</param>
        /// <returns>unescaped input string</returns>
        public static string FullyUnescapeDataString(string stringToUnescape)
        {
            // https://stackoverflow.com/a/3847593/10009545
            // But why?
            string result;
            while ((result = Uri.UnescapeDataString(stringToUnescape)) != stringToUnescape)
            {
                stringToUnescape = result;
            }
            return result;
        }

        /// <summary>
        /// Test if a URI string is valid
        /// </summary>
        /// <param name="uri">URI string</param>
        /// <returns>true iff valid, false otherwise</returns>
        public static bool IsValid(string uri)
        {
            try
            {
                new Bo4eUri(uri);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Get an URI for a Business Object
        /// </summary>
        /// <see cref="GetQueryObject"/> for the reverse operation.
        /// <param name="bo">Business Object</param>
        /// <param name="includeUserProperties">set true to add userProperties as query parameters</param>
        /// <returns>Bo4eUri</returns>
        /// call e.g. <see cref="System.Uri.GetComponents"/> or <see cref="System.Uri.ToString"/> on the returned object.
        public static Bo4eUri GetUri(BusinessObject bo, bool includeUserProperties = false)
        {
            if (bo == null)
            {
                throw new ArgumentNullException("Business Object must not be null.");
            }
            string baseUriString = BO4E_SCHEME + bo.GetType().Name + "/";
            Bo4eUri baseUri = new Bo4eUri(baseUriString);
            var relativeUriBuilder= new StringBuilder();

            foreach (PropertyInfo keyProp in GetKeyFields(bo))
            {
                //relativeUriString += keyField.Name; // line is useful for debugging
                if (keyProp.GetValue(bo) != null)
                {
                    if (keyProp.GetValue(bo).GetType() == typeof(string))
                    {
                        if (keyProp.GetValue(bo).ToString() == string.Empty)
                        {
                            relativeUriBuilder.Append(NULL_KEY_PLACEHOLDER + "/");
                        }
                        else
                        {
                            relativeUriBuilder.Append(keyProp.GetValue(bo) + "/");
                        }
                    }
                    else if (keyProp.GetValue(bo).GetType() == typeof(int))
                    {
                        relativeUriBuilder.Append(keyProp.GetValue(bo).ToString() + "/");
                    }
                    else if (keyProp.GetValue(bo) is Enum)
                    {
                        relativeUriBuilder.Append(keyProp.GetValue(bo).ToString() + "/");
                    }
                    else if (keyProp.GetValue(bo).GetType().IsSubclassOf(typeof(BusinessObject)))
                    {
                        BusinessObject innerBo = (BusinessObject)keyProp.GetValue(bo);
                        relativeUriBuilder.Append(GetUri(innerBo).GetComponents(UriComponents.Path, UriFormat.UriEscaped).ToString());
                    }
                    else
                    {
                        throw new NotImplementedException($"Using {keyProp.GetValue(bo).GetType()} as [BoKey] is not supported yet.");
                    }
                }
                else
                {
                    // there must be some value for null, because if the key is a composite key
                    // you could not distinguish which field was null.
                    // Think of two Ansprechpartners:
                    // - Günther Hermann but Günther is not set/null ==> /~/Hermann
                    // - Hermann Maier but Maier is not set/null ==> /Hermann/~/
                    relativeUriBuilder.Append(NULL_KEY_PLACEHOLDER + "/");
                }
            }
            if (includeUserProperties && bo.UserProperties != null && bo.UserProperties.Count > 0)
            {
                int n = 0;
                foreach (var up in bo.UserProperties)
                {
                    if (n == 0)
                    {
                        relativeUriBuilder.Append("?");
                    }
                    else
                    {
                        relativeUriBuilder.Append("&");
                    }
                    relativeUriBuilder.Append($"{up.Key}={up.Value}");
                    n += 1;
                }
            }

            Uri relativeUri = new Uri(Uri.EscapeUriString(relativeUriBuilder.ToString()), UriKind.Relative);
            if (TryCreate(baseUri, relativeUri, out Uri resultUri))
            {
                return new Bo4eUri(resultUri.AbsoluteUri);
            }
            else
            {
                return null;
            }
        }

        private static IList<PropertyInfo> GetKeyFields(BusinessObject bo)
        {
            if (bo == null)
            {
                throw new ArgumentNullException("Business Object must not be null.");
            }
            return GetKeyProperties(bo.GetType());
        }

        private static IList<PropertyInfo> GetKeyProperties(Type boType)
        {
            var allKeyProperties = boType.GetProperties()
                .Where(p => p.GetCustomAttributes(typeof(BoKey), false).Length > 0)
                .OrderBy(af => af.GetCustomAttribute<JsonPropertyAttribute>()?.Order)
                .ToArray<PropertyInfo>();
            if (allKeyProperties.Length == 0)
            {
                throw new NotImplementedException($"Business Object {boType.Name} has no [BoKey] defined => can't create URI.");
            }
            IList<PropertyInfo> ownKeyProps = new List<PropertyInfo>();
            bool ignoreInheritedFields = false; // default
            foreach (var keyProp in allKeyProperties)
            {
                if (keyProp.DeclaringType == boType
                    && keyProp.GetCustomAttribute<BoKey>().IgnoreInheritedKeys)
                {
                    ignoreInheritedFields = true;
                    ownKeyProps.Add(keyProp);
                }
            }
            if (ignoreInheritedFields)
            {
                return ownKeyProps;
            }
            else
            {
                return allKeyProperties.ToList<PropertyInfo>();
            }
        }


        /// <summary>
        /// The query object / dictionary returned by this method allows to search for Business Objects.
        /// Basically this method reverses what is done in <see cref="GetUri(BusinessObject, bool)"/>.
        /// </summary>
        /// The path segments of the URI represent components of the (composite) key of the
        /// Business Object. All key components, annotated with the <see cref="BoKey"/> attribute
        /// are obligatory fields, yet not all obligatory fields are key components. Hence it is
        /// in general not possible to create a valid Business Object only from its key values.
        /// This is why the return type of this method is just a general JObject but not a valid
        /// Business Object.
        /// <returns>A dictionary with boKey:boKeyValue pairs.</returns>
        public JObject GetQueryObject(Type boType = null, int i = 0)
        {
            JObject result = new JObject();

            // Method is called recursively if sub-BOs are part of the key. To distinguish between
            // top level and recursive calls, check the value of boType and i.
            if (boType == null) // top level call
            {
                boType = this.GetBoType();
            }
            result.Add("boTyp", boType.Name.ToUpper());

            // The order of the FieldInfos is the same as the JsonProperty.Order attribute of the
            // business objects is the same as the order of the BO key values encoded in the URI
            // path segments.

            foreach (PropertyInfo keyProp in GetKeyProperties(boType))
            {
                string keyPropName = keyProp.Name;
                JsonPropertyAttribute jpa = keyProp.GetCustomAttribute<JsonPropertyAttribute>();
                if (jpa != null && jpa.PropertyName != null)
                {
                    keyPropName = jpa.PropertyName;
                }
                string keyValue;
                try
                {
                    keyValue = FullyUnescapeDataString(this.Segments[++i]);
                }
                catch (IndexOutOfRangeException)
                {
                    break; // no arguments at all.
                }
                if (keyValue.EndsWith("/"))
                {
                    keyValue = keyValue.Substring(0, keyValue.Length - 1);
                }
                if (keyProp.PropertyType == typeof(string))
                {
                    if (keyValue == NULL_KEY_PLACEHOLDER)
                    {
                        result.Add(keyPropName, null);
                    }
                    else
                    {
                        result.Add(keyPropName, keyValue);
                    }
                }
                else if (keyProp.PropertyType == typeof(int))
                {
                    /*if (keyField.FieldType.IsEnum)
                    {
                        Enum.TryParse<>
                        if( Enum.TryParse(keyValue, out var resultEnum);
                    }
                    else*/
                    if (Int32.TryParse(keyValue, out int keyValueInt))
                    {
                        result.Add(keyPropName, keyValueInt);
                    }
                    else
                    {
                        throw new ArgumentException($"Key segment {keyPropName} could not be parsed as int although an integer type was expected!");
                    }
                }
                else if (keyProp.PropertyType.IsSubclassOf(typeof(BusinessObject)))
                {
                    JObject subresult = GetQueryObject(keyProp.PropertyType, i - 1);
                    result.Add(keyPropName, subresult);
                }
                else
                {
                    throw new NotImplementedException($"Using {keyProp.PropertyType} as [BoKey] is not supported yet.");
                }
            }

            var query = System.Web.HttpUtility.ParseQueryString(this.Query);
            var boProps = this.GetBoType().GetProperties().Select(p => p.Name);
            if (query.AllKeys.Contains("filter")) // currently this pattern only supports AND concatenation, not OR. result should contain multiple JObjects
            {
                string filter = query.Get("filter");
                foreach (Match match in FILTER_AND_PATTERN.Matches(filter))
                {
                    if (boProps.Contains(match.Groups["key"].Value, StringComparer.OrdinalIgnoreCase))
                    {
                        result[match.Groups["key"].Value] = match.Groups["value"].Value;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// returns a new Bo4eUri instance with an additional filter in the query
        /// </summary>
        /// <param name="filterObject"></param>
        public Bo4eUri AddFilter(IDictionary<string, object> filterObject)
        {
            NameValueCollection query = System.Web.HttpUtility.ParseQueryString(this.Query);
            string filterString = string.Empty;
            var boFields = this.GetBoType().GetProperties().Select(p => p.Name);
            string andString = " and ";
            foreach (var kvp in filterObject.Where(kvp => kvp.Value != null && boFields.Contains(kvp.Key, StringComparer.OrdinalIgnoreCase)))
            {
                filterString += $"{andString}{kvp.Key} eq '{kvp.Value}'";
            }
            if (filterString.StartsWith(andString))
            {
                filterString = filterString.Substring(andString.Length);
            }
            query.Add("filter", filterString);
            UriBuilder ub = new UriBuilder(this)
            {
                Query = query.ToString()
            };
            return new Bo4eUri(ub.Uri.ToString());
        }
    }

    // https://stackoverflow.com/a/39386674/10009545
    /// <summary>
    /// tries to implicitly convert a string to a BO4E URI if a URI is expected.
    /// </summary>
    public class StringUriConverter : TypeConverter
    {
        /// <inheritdoc/>
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string) ? true : base.CanConvertFrom(context, sourceType);
        }

        /// <inheritdoc/>
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string)
            {
                return new Bo4eUri((string)value);
            }
            return base.ConvertFrom(context, culture, value);
        }
    }

}
