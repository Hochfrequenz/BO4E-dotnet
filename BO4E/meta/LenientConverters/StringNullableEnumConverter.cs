#nullable enable
using System;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BO4E.meta.LenientConverters;

/// <summary>
///     A custom enum converter that uses an array for containing bit flags.
/// </summary>
public class StringNullableEnumConverter : JsonConverterFactory
{
    /// <summary>
    /// </summary>
    /// <param name="typeToConvert"></param>
    /// <returns></returns>
    public override bool CanConvert(Type typeToConvert)
    {
        if (Nullable.GetUnderlyingType(typeToConvert) == null)
        {
            return typeToConvert.ToString().StartsWith("BO4E.ENUM");
        }

        return Nullable.GetUnderlyingType(typeToConvert).ToString().StartsWith("BO4E.ENUM");
    }

    /// <summary>
    /// </summary>
    /// <param name="typeToConvert"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    public override JsonConverter? CreateConverter(
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var converter = (JsonConverter)
            Activator.CreateInstance(
                typeof(StringNullableEnumConverter<>).MakeGenericType(typeToConvert),
                BindingFlags.Instance | BindingFlags.Public,
                null,
                null,
                null
            );

        return converter;
    }
}
