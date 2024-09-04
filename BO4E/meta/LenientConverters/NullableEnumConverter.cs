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
    public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        var converter = (JsonConverter)Activator.CreateInstance(
            typeof(StringNullableEnumConverter<>).MakeGenericType(typeToConvert),
            BindingFlags.Instance | BindingFlags.Public,
            null,
            null,
            null);

        return converter;
    }
}

/// <summary>
///     A converter to also allow parsing of nullable enums (not included in system.text.json yet)
/// </summary>
/// <typeparam name="T"></typeparam>
public class StringNullableEnumConverter<T> : JsonConverter<T>
{
    private readonly JsonConverter<T> _converter;
    private readonly Type _underlyingType;

    /// <summary>
    ///     constructor
    /// </summary>
    public StringNullableEnumConverter() : this(null)
    {
    }

    /// <summary>
    ///     Construct a converter (reuse if possible)
    /// </summary>
    /// <param name="options"></param>
    public StringNullableEnumConverter(JsonSerializerOptions options)
    {
        // for performance, use the existing converter if available
        if (options != null)
        {
            _converter = (JsonConverter<T>)options.GetConverter(typeof(T));
        }

        // cache the underlying type
        _underlyingType = Nullable.GetUnderlyingType(typeof(T));
        if (_underlyingType == null)
        {
            _underlyingType = typeof(T);
        }
    }

    /// <summary>
    ///     Also handles null values
    /// </summary>
    public override bool HandleNull => true;

    /// <summary>
    ///     Check if we can convert this type
    /// </summary>
    /// <param name="typeToConvert"></param>
    /// <returns></returns>
    public override bool CanConvert(Type typeToConvert)
    {
        return true;
    }

    /// <summary>
    ///     Read from the json reader.
    ///     <see cref="System.Text.Json.Serialization.JsonConverter{T}.Read(ref Utf8JsonReader, Type, JsonSerializerOptions)" />
    /// </summary>
    /// <param name="reader"></param>
    /// <param name="typeToConvert"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    public override T Read(ref Utf8JsonReader reader,
        Type typeToConvert, JsonSerializerOptions options)
    {
        if (_converter != null)
        {
            return _converter.Read(ref reader, _underlyingType, options);
        }

        if (reader.TokenType == JsonTokenType.Null)
        {
            return default;
        }

        if (reader.TokenType == JsonTokenType.String)
        {
            var value = reader.GetString();
            if (string.IsNullOrEmpty(value))
            {
                return default;
            }

            // for performance, parse with ignoreCase:false first.
            try
            {
                var result = Enum.Parse(_underlyingType, value, true);
                return (T)result;
            }
            catch (Exception)
            {
                return default;
            }
        }

        if (reader.TokenType == JsonTokenType.Number)
        {
            return (T)Enum.ToObject(_underlyingType, reader.GetInt32());
        }

        return default;
    }

    /// <summary>
    ///     Write to the json writer
    ///     <see cref="System.Text.Json.Serialization.JsonConverter{T}.Write(Utf8JsonWriter, T, JsonSerializerOptions)" />
    /// </summary>
    /// <param name="writer"></param>
    /// <param name="value"></param>
    /// <param name="options"></param>
    public override void Write(Utf8JsonWriter writer,
        T value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value?.ToString());
    }
}