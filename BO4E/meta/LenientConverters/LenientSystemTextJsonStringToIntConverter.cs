using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BO4E.meta.LenientConverters;

/// <summary>
///     The lenient StringToIntConverter allows for int or int? objects have alphabetic characters.
///     If the string is not parseable as integer 0 is used in case of (int) and <c>null</c> in case of (int?).
/// </summary>
/// <example>(string)"12" will be parsed as (int)12 where an integer value is expected.</example>
public class LenientSystemTextJsonStringToIntConverter : JsonConverter<int?>
{
    /// <summary>
    /// </summary>
    public override bool HandleNull => true;

    /// <summary>
    /// </summary>
    /// <param name="reader"></param>
    /// <param name="typeToConvert"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    public override int? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        switch (reader.TokenType)
        {
            case JsonTokenType.Null:
                return null;
            case JsonTokenType.String:
            {
                var numeric = new string(reader.GetString().Where(char.IsDigit).ToArray());
                if (int.TryParse(numeric, out var intValue))
                {
                    return intValue;
                }

                break;
            }
            case JsonTokenType.Number when reader.TryGetInt32(out var int32Value):
                return int32Value;
            case JsonTokenType.Number when reader.TryGetInt64(out var int64Value):
                return (int)int64Value;
        }

        return 0;
    }

    /// <summary>
    /// </summary>
    /// <param name="writer"></param>
    /// <param name="value"></param>
    /// <param name="options"></param>
    public override void Write(Utf8JsonWriter writer, int? value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value);
    }
}
