#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using BO4E.BO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BO4E.meta;

/// <summary>
///     Bo4eUri class is derived from System.Uri and works the same way. It's just a bit more strict in validation.
/// </summary>
[TypeConverter(typeof(StringUriConverter))]
public class Bo4eUri : Uri
{
    private const string Bo4EScheme = "bo4e://";
    private const string NullKeyPlaceholder = "~"; // an allowed character in URLs that is not escaped

    private static readonly Regex FilterAndPattern = new Regex(
        @"\s*(?<key>\w+)\s*(?:=|eq)\s*(['""]|)(?<value>\w+)\1\s*(?:and)?\s*",
        RegexOptions.IgnoreCase | RegexOptions.Compiled
    ); // \1 backreferences the '" group (in c#, would be \2 in other parsers)

    /// <summary>
    ///     Instantiates a Bo4eUri object. Throws Argument(Null)Exception if URI is null, not well formed (
    ///     <see cref="System.Uri.IsWellFormedOriginalString" /> or doesn't match the bo4e uri regex.
    /// </summary>
    /// <param name="uri">URI string to be processed</param>
    public Bo4eUri(string uri)
        : base(uri)
    {
        if (uri == null)
        {
            throw new ArgumentNullException(nameof(uri), "URI string must not be null.");
        }

        /*if (!base.IsWellFormedOriginalString())
        {
            throw new ArgumentException($"The URI {uri} is not well formed.");
        }*/
        if (Scheme + "://" != Bo4EScheme)
        {
            throw new ArgumentException(
                $"The scheme '{Scheme}' in {uri} is not valid. Expected '{Bo4EScheme}://'"
            );
        }

        if (GetBoName() == null)
        {
            throw new ArgumentException($"There is no Business Object of type '{Host}'.");
        }
    }

    /// <summary>
    ///     implicit casting operator for strings (useful during de serialising
    /// </summary>
    /// <param name="input">string </param>
    public static implicit operator Bo4eUri(string input)
    {
        return new Bo4eUri(input);
    }

    /// <summary>
    ///     Get name of business object with correct upper/lower case (the host value)
    /// </summary>
    /// <returns>business object name or null iff there is no such object</returns>
    public string? GetBoName()
    {
        return BusinessObjectSerializationBinder
            .BusinessObjectAndCOMTypes.Where(t => typeof(BusinessObject).IsAssignableFrom(t))
            .Select(t => t.Name)
            .FirstOrDefault(boName => boName.ToUpper().Equals(Host.ToUpper()));
    }

    /// <summary>
    ///     Get type of business object (e.g. to be used with Activator.CreateInstance)
    /// </summary>
    /// <returns>business object type of null iff there is no such object</returns>
    public Type? GetBoType()
    {
        var boName = GetBoName();
        return boName == null
            ? null
            : Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name.Equals(boName));
    }

    /// <summary>
    ///     Repeatedly calls Uri.UnescapeDataString until the result doesn't change any more.
    /// </summary>
    /// <param name="stringToUnescape">string to unescape</param>
    /// <returns>unescaped input string</returns>
    public static string FullyUnescapeDataString(string stringToUnescape)
    {
        // https://stackoverflow.com/a/3847593/10009545
        // But why?
        string result;
        while ((result = UnescapeDataString(stringToUnescape)) != stringToUnescape)
            stringToUnescape = result;
        return result;
    }

    /// <summary>
    ///     Test if a URI string is valid
    /// </summary>
    /// <param name="uri">URI string</param>
    /// <returns>true iff valid, false otherwise</returns>
    public static bool IsValid(string uri)
    {
        try
        {
            _ = new Bo4eUri(uri);
        }
        catch (Exception)
        {
            return false;
        }

        return true;
    }

    /// <summary>
    ///     Get an URI for a Business Object
    /// </summary>
    /// <see cref="GetQueryObject" />
    /// for the reverse operation.
    /// <param name="bo">Business Object</param>
    /// <param name="includeUserProperties">set true to add userProperties as query parameters</param>
    /// <returns>Bo4eUri</returns>
    /// call e.g.
    /// <see cref="System.Uri.GetComponents" />
    /// or
    /// <see cref="System.Uri.ToString" />
    /// on the returned object.
#nullable disable warnings
    public static Bo4eUri? GetUri(BusinessObject bo, bool includeUserProperties = false)
    {
        if (bo == null)
        {
            throw new ArgumentNullException(nameof(bo), "Business Object must not be null.");
        }

        var baseUriString = Bo4EScheme + bo.GetType().Name + "/";
        var baseUri = new Bo4eUri(baseUriString);
        var relativeUriBuilder = new StringBuilder();

        foreach (var keyProp in GetKeyFields(bo))
            //relativeUriString += keyField.Name; // line is useful for debugging
            if (keyProp.GetValue(bo) != null)
            {
                if (keyProp.GetValue(bo) is string)
                {
                    if (keyProp.GetValue(bo).ToString() == string.Empty)
                    {
                        relativeUriBuilder.Append(NullKeyPlaceholder + "/");
                    }
                    else
                    {
                        relativeUriBuilder.Append(keyProp.GetValue(bo) + "/");
                    }
                }
                else if (keyProp.GetValue(bo) is int)
                {
                    relativeUriBuilder.Append(keyProp.GetValue(bo) + "/");
                }
                else if (keyProp.GetValue(bo) is Enum)
                {
                    relativeUriBuilder.Append(keyProp.GetValue(bo) + "/");
                }
                else if (keyProp.GetValue(bo).GetType().IsSubclassOf(typeof(BusinessObject)))
                {
                    var innerBo = (BusinessObject)keyProp.GetValue(bo);
                    relativeUriBuilder.Append(
                        GetUri(innerBo).GetComponents(UriComponents.Path, UriFormat.UriEscaped)
                    );
                }
                else
                {
                    throw new NotImplementedException(
                        $"Using {keyProp.GetValue(bo).GetType()} as [BoKey] is not supported yet."
                    );
                }
            }
            else
            {
                // there must be some value for null, because if the key is a composite key
                // you could not distinguish which field was null.
                // Think of two Ansprechpartners:
                // - Günther Hermann but Günther is not set/null ==> /~/Hermann
                // - Hermann Maier but Maier is not set/null ==> /Hermann/~/
                relativeUriBuilder.Append(NullKeyPlaceholder + "/");
            }

        if (includeUserProperties && bo.UserProperties != null && bo.UserProperties.Any())
        {
            var n = 0;
            foreach (var up in bo.UserProperties)
            {
                relativeUriBuilder.Append(n == 0 ? "?" : "&");
                relativeUriBuilder.Append($"{up.Key}={up.Value}");
                n += 1;
            }
        }
#pragma warning disable SYSLIB0013
        var relativeUri = new Uri(EscapeUriString(relativeUriBuilder.ToString()), UriKind.Relative);
#pragma warning restore SYSLIB0013
        return TryCreate(baseUri, relativeUri, out var resultUri)
            ? new Bo4eUri(resultUri.AbsoluteUri)
            : null;
    }

#nullable restore warnings

    private static IList<PropertyInfo> GetKeyFields(BusinessObject bo)
    {
        if (bo == null)
        {
            throw new ArgumentNullException(nameof(bo), "Business Object must not be null.");
        }

        return GetKeyProperties(bo.GetType());
    }

    private static IList<PropertyInfo> GetKeyProperties(Type boType)
    {
        var allKeyProperties = boType
            .GetProperties()
            .Where(p => p.GetCustomAttributes(typeof(BoKey), false).Length > 0)
            .OrderBy(af => af.GetCustomAttribute<JsonPropertyAttribute>()?.Order)
            .ToArray();
        if (allKeyProperties.Length == 0)
        {
            throw new NotImplementedException(
                $"Business Object {boType.Name} has no [BoKey] defined => can't create URI."
            );
        }

        IList<PropertyInfo> ownKeyProps = new List<PropertyInfo>();
        var ignoreInheritedFields = false; // default
        foreach (var keyProp in allKeyProperties)
            if (
                keyProp.DeclaringType == boType
                && keyProp.GetCustomAttribute<BoKey>().IgnoreInheritedKeys
            )
            {
                ignoreInheritedFields = true;
                ownKeyProps.Add(keyProp);
            }

        if (ignoreInheritedFields)
        {
            return ownKeyProps;
        }

        return allKeyProperties.ToList();
    }

    /// <summary>
    ///     The query object / dictionary returned by this method allows to search for Business Objects.
    ///     Basically this method reverses what is done in <see cref="GetUri(BusinessObject, bool)" />.
    /// </summary>
    /// The path segments of the URI represent components of the (composite) key of the
    /// Business Object. All key components, annotated with the
    /// <see cref="BoKey" />
    /// attribute
    /// are obligatory fields, yet not all obligatory fields are key components. Hence it is
    /// in general not possible to create a valid Business Object only from its key values.
    /// This is why the return type of this method is just a general JObject but not a valid
    /// Business Object.
    /// <returns>A dictionary with boKey:boKeyValue pairs.</returns>
#nullable disable warnings
    public JObject GetQueryObject(Type boType = null, int i = 0)
    {
        var result = new JObject();

        // Method is called recursively if sub-BOs are part of the key. To distinguish between
        // top level and recursive calls, check the value of boType and i.
        if (boType == null) // top level call
        {
            boType = GetBoType();
        }

        result.Add("boTyp", boType.Name.ToUpper());

        // The order of the FieldInfos is the same as the JsonProperty.Order attribute of the
        // business objects is the same as the order of the BO key values encoded in the URI
        // path segments.

        foreach (var keyProp in GetKeyProperties(boType))
        {
            var keyPropName = keyProp.Name;
            var jpa = keyProp.GetCustomAttribute<JsonPropertyAttribute>();
            if (jpa?.PropertyName != null)
            {
                keyPropName = jpa.PropertyName;
            }

            string keyValue;
            try
            {
                keyValue = FullyUnescapeDataString(Segments[++i]);
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
                result.Add(keyPropName, keyValue == NullKeyPlaceholder ? null : keyValue);
            }
            else if (keyProp.PropertyType == typeof(int))
            {
                /*if (keyField.FieldType.IsEnum)
                {
                    Enum.TryParse<>
                    if( Enum.TryParse(keyValue, out var resultEnum);
                }
                else*/
                if (int.TryParse(keyValue, out var keyValueInt))
                {
                    result.Add(keyPropName, keyValueInt);
                }
                else
                {
                    throw new ArgumentException(
                        $"Key segment {keyPropName} could not be parsed as int although an integer type was expected!"
                    );
                }
            }
            else if (keyProp.PropertyType.IsSubclassOf(typeof(BusinessObject)))
            {
                var subresult = GetQueryObject(keyProp.PropertyType, i - 1);
                result.Add(keyPropName, subresult);
            }
            else
            {
                throw new NotImplementedException(
                    $"Using {keyProp.PropertyType} as [BoKey] is not supported yet."
                );
            }
        }

        var query = HttpUtility.ParseQueryString(Query);
        var boProps = GetBoType().GetProperties().Select(p => p.Name);
        if (query.AllKeys.Contains("filter")) // currently this pattern only supports AND concatenation, not OR. result should contain multiple JObjects
        {
            var filter = query.Get("filter");
            foreach (Match match in FilterAndPattern.Matches(filter))
                if (boProps.Contains(match.Groups["key"].Value, StringComparer.OrdinalIgnoreCase))
                {
                    result[match.Groups["key"].Value] = match.Groups["value"].Value;
                }
        }

        return result;
    }

#nullable restore warnings

    /// <summary>
    ///     returns a new Bo4eUri instance with an additional filter in the query
    /// </summary>
    /// <param name="filterObject"></param>
#nullable disable warnings
    public Bo4eUri AddFilter(IDictionary<string, object> filterObject)
    {
        var query = HttpUtility.ParseQueryString(Query);
        var filterString = string.Empty;
        var boFields = GetBoType().GetProperties().Select(p => p.Name);
        const string andString = " and ";
        filterString = filterObject
            .Where(kvp =>
                kvp.Value != null && boFields.Contains(kvp.Key, StringComparer.OrdinalIgnoreCase)
            )
            .Aggregate(
                filterString,
                (current, kvp) => current + $"{andString}{kvp.Key} eq '{kvp.Value}'"
            );
        if (filterString.StartsWith(andString))
        {
            filterString = filterString.Substring(andString.Length);
        }

        query.Add("filter", filterString);
        var ub = new UriBuilder(this) { Query = query.ToString() };
        return new Bo4eUri(ub.Uri.ToString());
    }
#nullable restore warnings
}

// https://stackoverflow.com/a/39386674/10009545
/// <summary>
///     tries to implicitly convert a string to a BO4E URI if a URI is expected.
/// </summary>
#nullable disable warnings
public class StringUriConverter : TypeConverter
{
    /// <inheritdoc />
    public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
    {
        return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
    }

    /// <inheritdoc />
    public override object ConvertFrom(
        ITypeDescriptorContext context,
        CultureInfo culture,
        object value
    )
    {
        if (value is string @string)
        {
            return new Bo4eUri(@string);
        }

        return base.ConvertFrom(context, culture, value);
    }
}
#nullable restore warnings
