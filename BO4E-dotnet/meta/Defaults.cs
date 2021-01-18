namespace BO4E.meta
{
    /// <summary>
    /// Static class to store default values (e.g. json serializer options)
    /// </summary>
    public static class Defaults
    {
        /// <summary>
        /// Basic json serializer options if no separate options (e.g. lenient) are used
        /// </summary>
        public static System.Text.Json.JsonSerializerOptions JsonSerializerDefaultOptions => new System.Text.Json.JsonSerializerOptions(System.Text.Json.JsonSerializerDefaults.Web)
        {
            NumberHandling = System.Text.Json.Serialization.JsonNumberHandling.AllowReadingFromString
        };
    }
}
