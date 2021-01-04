using Newtonsoft.Json;

namespace BO4E.Extensions.COM
{

    /// <summary>
    /// common extensions for all COM objects
    /// </summary>
    public static class COMExtensions
    {
        /// <summary>
        /// Create a deep copy of a COMponent
        /// </summary>
        /// <typeparam name="T">Type of the COM</typeparam>
        /// <param name="source">the BO that is copied</param>
        /// <returns>the deep copy</returns>
        public static T DeepClone<T>(this T source) where T : BO4E.COM.COM
        {
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(source));
        }
    }
}