using BO4E.BO;
using Newtonsoft.Json;

namespace BO4E.Extensions.BusinessObjects;

/// <summary>
///     common extensions for all BusinessObjects
/// </summary>
public static class BusinessObjectExtensions
{
    /// <summary>
    ///     Create a deep copy of a Business Object
    /// </summary>
    /// <typeparam name="T">Type of the BusinessObject</typeparam>
    /// <param name="source">the BO that is copied</param>
    /// <returns>the deep copy</returns>
    public static T DeepClone<T>(this T source)
        where T : BusinessObject
    {
        return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(source));
    }
}
