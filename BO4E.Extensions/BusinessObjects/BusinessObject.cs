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
    /// <remarks>
    /// Note: The null-forgiving operator (!) maintains original behavior. If source is null,
    /// DeserializeObject returns null and the ! suppresses the warning. This pre-existing
    /// behavior is preserved for backward compatibility.
    /// TODO: Consider making return type nullable or throwing ArgumentNullException for null source.
    /// </remarks>
    public static T DeepClone<T>(this T source)
        where T : BusinessObject
    {
        return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(source))!;
    }
}
