using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using BO4E.BO;
using Newtonsoft.Json.Schema;

namespace BO4E;

/// <summary>
///     This class maps generic JObjects to BO4E business objects.
/// </summary>
[Obsolete(
    "The BoMapper is obsolete and should be replace with JsonConvert.DeserializeObject<T>(...) in the long run. It's not a good coding style but still thoroughly tested.")]
public abstract class BoMapper
{
    /// <summary>
    ///     namespace.subnamespace for the BO4E package. maybe there's a more elegant way using self reflection.
    /// </summary>
    public const string PackagePrefix = "BO4E.BO";

    private static readonly Regex BoRegex = new Regex(@"BO4E\.(?:Extensions\.)?BO\.\b(?<boName>\w+)\b",
        RegexOptions.Compiled);

    /// <summary>
    ///     Get a list of those strings that are known BO4E types (e.g. "Messlokation", "Energiemenge"...)
    /// </summary>
    /// <returns>a list of valid BO4E names; upper/lower case sensitive</returns>
    public static HashSet<string> GetValidBoNames()
    {
        var result = new HashSet<string>();
        var types = Assembly.GetExecutingAssembly().GetTypes();
        foreach (var t in types)
        {
            var m = BoRegex.Match(t.ToString());
            if (m.Success) result.Add(m.Groups["boName"].Value);
        }

        return result;
    }

    /// <summary>
    ///     Returns a Type for given Business Object name. This method is useful to avoid stringified code.
    /// </summary>
    /// <param name="businessObjectName">name of a business object; is lenient regarding upper/lower case</param>
    /// <returns>a BusinessObjectType or null if no matching type was found</returns>
    /// <exception cref="ArgumentNullException">if argument is null</exception>
    /// <example>
    ///     <code>
    /// BoMapper.GetTypeForBoName("Energiemenge"); // returns typeof(BO4E.BO.Energiemenge)
    /// BoMapper.GetTypeForBoName("eNeRgIeMENgE"); // returns typeof(BO4E.BO.Energiemenge)
    /// BoMapper.GetTypeForBoName("non existent BO"); // returns null
    /// </code>
    /// </example>
    public static Type GetTypeForBoName(string businessObjectName)
    {
        if (businessObjectName == null) throw new ArgumentNullException(nameof(businessObjectName));

        //Type[] types = Assembly.GetExecutingAssembly().GetTypes();
        var clazz = Assembly.GetExecutingAssembly().GetType(PackagePrefix + "." + businessObjectName);
        return clazz != null
            ? clazz
            : (from boName in GetValidBoNames()
                where string.Equals(boName, businessObjectName, StringComparison.CurrentCultureIgnoreCase)
                select Assembly.GetExecutingAssembly().GetType(PackagePrefix + "." + boName)).FirstOrDefault();

        //throw new ArgumentException($"No implemented BusinessObject type matches the name '{businessObjectName}'.");
    }

    /// <summary>
    ///     Get JSON Scheme for given Business Object type
    /// </summary>
    /// <param name="businessObjectType">Business Object type (e.g. typeof(BO4E.BO.Messlokation)</param>
    /// <returns>A JSON scheme to be used for validation purposes.</returns>
    /// <exception cref="ArgumentException">if given type is not derived from BusinessObject</exception>
    public static JSchema GetJsonSchemeFor(Type businessObjectType)
    {
        if (!businessObjectType.IsSubclassOf(typeof(BusinessObject)))
            throw new ArgumentException($"The given type {businessObjectType} is not derived from BusinessObject.");
        var bo = Activator.CreateInstance(businessObjectType) as BusinessObject;
        return bo.GetJsonScheme();
    }
}
