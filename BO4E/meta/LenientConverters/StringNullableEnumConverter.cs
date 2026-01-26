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
        var underlyingType = Nullable.GetUnderlyingType(typeToConvert);
        if (underlyingType == null)
        {
            return typeToConvert.ToString().StartsWith("BO4E.ENUM");
        }

        return underlyingType.ToString().StartsWith("BO4E.ENUM");
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
        var converterType = typeof(StringNullableEnumConverter<>).MakeGenericType(typeToConvert);
        var converter = Activator.CreateInstance(
            converterType,
            BindingFlags.Instance | BindingFlags.Public,
            null,
            null,
            null
        ) as JsonConverter;

        return converter
            ?? throw new InvalidOperationException(
                $"Failed to create converter for type {typeToConvert.FullName}"
            );
    }
}
