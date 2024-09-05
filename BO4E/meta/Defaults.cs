using System.Text.Json;
using System.Text.Json.Serialization;

namespace BO4E.meta;

/// <summary>
///     Static class to store default values (e.g. json serializer options)
/// </summary>
public static class Defaults
{
    /// <summary>
    ///     Basic json serializer options if no separate options (e.g. lenient) are used
    /// </summary>
    public static JsonSerializerOptions JsonSerializerDefaultOptions =>
        new JsonSerializerOptions(JsonSerializerDefaults.Web)
        {
            NumberHandling = JsonNumberHandling.AllowReadingFromString,
        };
}
