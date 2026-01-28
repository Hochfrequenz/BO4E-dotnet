using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BO4E.meta.LenientConverters;

/// <summary>
/// A <see cref="JsonConverterFactory"/> that provides error-tolerant deserialization for properties
/// marked with <see cref="MigratedFromUserPropertiesAttribute"/>.
/// </summary>
/// <remarks>
/// <para>
/// This converter factory handles types that implement <see cref="IUserProperties"/> and have
/// at least one property marked with <see cref="MigratedFromUserPropertiesAttribute"/>.
/// </para>
/// <para>
/// When a marked property fails to deserialize due to a type mismatch (e.g., legacy data
/// stored as an object when an array is expected), the error is caught, the raw JSON value
/// is stored in <see cref="IUserProperties.UserProperties"/> under a key prefixed with
/// <see cref="MigratedFromUserPropertiesAttribute.UserPropertiesKeyPrefix"/>, and deserialization
/// continues with the property set to its default value.
/// </para>
/// <para>
/// Errors on properties NOT marked with the attribute, as well as fundamental JSON syntax errors,
/// are NOT caught and will still throw exceptions.
/// </para>
/// </remarks>
public class MigratedPropertyConverterFactory : JsonConverterFactory
{
    /// <summary>
    /// Cache for type metadata to avoid repeated reflection.
    /// </summary>
    private static readonly ConcurrentDictionary<Type, TypeMetadata?> TypeMetadataCache = new();

    /// <inheritdoc/>
    public override bool CanConvert(Type typeToConvert)
    {
        var metadata = GetOrCreateMetadata(typeToConvert);
        return metadata != null;
    }

    /// <inheritdoc/>
    public override JsonConverter? CreateConverter(
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var metadata = GetOrCreateMetadata(typeToConvert);
        if (metadata == null)
        {
            return null;
        }

        var converterType = typeof(MigratedPropertyConverter<>).MakeGenericType(typeToConvert);
        return (JsonConverter?)Activator.CreateInstance(converterType, metadata);
    }

    private static TypeMetadata? GetOrCreateMetadata(Type type)
    {
        return TypeMetadataCache.GetOrAdd(type, CreateMetadata);
    }

    private static TypeMetadata? CreateMetadata(Type type)
    {
        // Must implement IUserProperties
        if (!typeof(IUserProperties).IsAssignableFrom(type))
        {
            return null;
        }

        // Must not be abstract (we can't instantiate abstract types)
        if (type.IsAbstract || type.IsInterface)
        {
            return null;
        }

        // Find properties marked with MigratedFromUserPropertiesAttribute
        var migratedProperties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(p => p.GetCustomAttribute<MigratedFromUserPropertiesAttribute>() != null)
            .Select(p => new MigratedPropertyInfo(p, GetJsonPropertyName(p)))
            .ToList();

        // Only handle types with at least one migrated property
        if (migratedProperties.Count == 0)
        {
            return null;
        }

        return new TypeMetadata(type, migratedProperties);
    }

    private static string GetJsonPropertyName(PropertyInfo property)
    {
        // Check for JsonPropertyName attribute first
        var jsonPropertyName = property.GetCustomAttribute<JsonPropertyNameAttribute>();
        if (jsonPropertyName != null)
        {
            return jsonPropertyName.Name;
        }

        // Fall back to property name (case-insensitive matching will be used)
        return property.Name;
    }

    /// <summary>
    /// Cached metadata about a type with migrated properties.
    /// </summary>
    internal sealed class TypeMetadata
    {
        public Type Type { get; }
        public IReadOnlyList<MigratedPropertyInfo> MigratedProperties { get; }
        public HashSet<string> MigratedPropertyNamesLower { get; }

        public TypeMetadata(Type type, IReadOnlyList<MigratedPropertyInfo> migratedProperties)
        {
            Type = type;
            MigratedProperties = migratedProperties;
            MigratedPropertyNamesLower = new HashSet<string>(
                migratedProperties.Select(p => p.JsonName.ToLowerInvariant()),
                StringComparer.OrdinalIgnoreCase
            );
        }
    }

    /// <summary>
    /// Information about a property marked with <see cref="MigratedFromUserPropertiesAttribute"/>.
    /// </summary>
    internal sealed class MigratedPropertyInfo
    {
        public PropertyInfo Property { get; }
        public string JsonName { get; }

        public MigratedPropertyInfo(PropertyInfo property, string jsonName)
        {
            Property = property;
            JsonName = jsonName;
        }
    }
}

/// <summary>
/// Generic converter that handles error-tolerant deserialization for a specific type
/// with properties marked with <see cref="MigratedFromUserPropertiesAttribute"/>.
/// </summary>
/// <typeparam name="T">The type to deserialize. Must implement <see cref="IUserProperties"/>.</typeparam>
/// <remarks>
/// This converter uses a two-phase approach:
/// <list type="number">
///     <item><description>Pre-validate each migrated property by attempting standalone deserialization</description></item>
///     <item><description>Deserialize the object with problematic properties removed</description></item>
///     <item><description>Store failed properties in UserProperties for later cleanup</description></item>
/// </list>
/// </remarks>
internal class MigratedPropertyConverter<T> : JsonConverter<T>
    where T : class, IUserProperties
{
    /// <summary>
    /// Cache for filtered options to avoid creating new options on every deserialization.
    /// Uses ConditionalWeakTable to allow garbage collection of unused options.
    /// </summary>
    private static readonly ConditionalWeakTable<
        JsonSerializerOptions,
        JsonSerializerOptions
    > OptionsCache = new();

    private readonly MigratedPropertyConverterFactory.TypeMetadata _metadata;

    public MigratedPropertyConverter(MigratedPropertyConverterFactory.TypeMetadata metadata)
    {
        _metadata = metadata;
    }

    /// <summary>
    /// Returns false to prevent infinite recursion - we only want to handle reading.
    /// </summary>
    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert == typeof(T);
    }

    public override T? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        if (reader.TokenType == JsonTokenType.Null)
        {
            return null;
        }

        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException($"Expected StartObject but got {reader.TokenType}");
        }

        // Parse the entire JSON into a document so we can manipulate it
        using var document = JsonDocument.ParseValue(ref reader);
        var root = document.RootElement;

        // Check if any migrated property has an error-prone value
        // Store: (originalJsonKey, normalizedPropertyName, value)
        var propertiesToRemove =
            new List<(string OriginalKey, string NormalizedName, JsonElement Value)>();

        foreach (var prop in root.EnumerateObject())
        {
            if (_metadata.MigratedPropertyNamesLower.Contains(prop.Name.ToLowerInvariant()))
            {
                // Find the corresponding migrated property info
                var migratedProp = _metadata.MigratedProperties.FirstOrDefault(mp =>
                    string.Equals(mp.JsonName, prop.Name, StringComparison.OrdinalIgnoreCase)
                );

                if (migratedProp != null)
                {
                    // Try to deserialize just this property to check if it would fail
                    if (
                        !CanDeserializeProperty(
                            prop.Value,
                            migratedProp.Property.PropertyType,
                            options
                        )
                    )
                    {
                        // Store original key (for JSON removal) and normalized name (for consistent UserProperties key)
                        propertiesToRemove.Add((prop.Name, migratedProp.JsonName, prop.Value));
                    }
                }
            }
        }

        T? result;

        if (propertiesToRemove.Count == 0)
        {
            // No problematic properties, deserialize normally
            result = DeserializeWithoutConverter(root, options);
        }
        else
        {
            // Create a modified JSON without the problematic properties
            var modifiedJson = CreateModifiedJson(
                root,
                propertiesToRemove.Select(p => p.OriginalKey)
            );
            result = DeserializeWithoutConverter(modifiedJson, options);

            // Store the failed properties in UserProperties using normalized property names
            // This ensures consistent keys regardless of JSON input casing
            if (result != null)
            {
                result.UserProperties ??= new Dictionary<string, object>();
                foreach (var (_, normalizedName, value) in propertiesToRemove)
                {
                    var key = MigratedFromUserPropertiesAttribute.GetUserPropertiesKey(
                        normalizedName
                    );
                    result.UserProperties[key] = JsonElementToObject(value);
                }
            }
        }

        return result;
    }

    private bool CanDeserializeProperty(
        JsonElement element,
        Type targetType,
        JsonSerializerOptions options
    )
    {
        try
        {
            // Create options without this converter to avoid recursion
            var testOptions = GetOptionsWithoutThisConverter(options);
            var rawJson = element.GetRawText();
            JsonSerializer.Deserialize(rawJson, targetType, testOptions);
            return true;
        }
        catch (Exception ex) when (IsDeserializationError(ex))
        {
            return false;
        }
    }

    /// <summary>
    /// Determines if an exception is a deserialization-related error that should be caught
    /// for migrated properties.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This method intentionally catches a broad set of exceptions beyond just <see cref="JsonException"/>
    /// because legacy data in UserProperties can have various type mismatches that manifest as different
    /// exception types during deserialization:
    /// </para>
    /// <list type="bullet">
    ///     <item><description><see cref="JsonException"/>: JSON structure doesn't match expected type</description></item>
    ///     <item><description><see cref="ArgumentException"/>: Invalid enum values, invalid arguments during conversion</description></item>
    ///     <item><description><see cref="FormatException"/>: Invalid string format for dates, numbers, etc.</description></item>
    ///     <item><description><see cref="InvalidCastException"/>: Type conversion failures</description></item>
    ///     <item><description><see cref="NotSupportedException"/>: Unsupported type conversions</description></item>
    /// </list>
    /// <para>
    /// This broader catching is intentional for data migration scenarios where the goal is to preserve
    /// the application's ability to function while flagging problematic data for manual cleanup.
    /// Errors on properties NOT marked with <see cref="MigratedFromUserPropertiesAttribute"/> will
    /// still propagate normally.
    /// </para>
    /// </remarks>
    private static bool IsDeserializationError(Exception ex)
    {
        return ex is JsonException
            || ex is ArgumentException
            || ex is FormatException
            || ex is InvalidCastException
            || ex is NotSupportedException;
    }

    private T? DeserializeWithoutConverter(JsonElement element, JsonSerializerOptions options)
    {
        var optionsWithoutThis = GetOptionsWithoutThisConverter(options);
        return element.Deserialize<T>(optionsWithoutThis);
    }

    private JsonElement CreateModifiedJson(JsonElement root, IEnumerable<string> propertiesToRemove)
    {
        var removeSet = new HashSet<string>(propertiesToRemove, StringComparer.OrdinalIgnoreCase);

        using var ms = new System.IO.MemoryStream();
        using (var writer = new Utf8JsonWriter(ms))
        {
            writer.WriteStartObject();
            foreach (var prop in root.EnumerateObject())
            {
                if (!removeSet.Contains(prop.Name))
                {
                    prop.WriteTo(writer);
                }
            }
            writer.WriteEndObject();
        }

        ms.Position = 0;
        using var doc = JsonDocument.Parse(ms);
        return doc.RootElement.Clone();
    }

    private JsonSerializerOptions GetOptionsWithoutThisConverter(JsonSerializerOptions options)
    {
        return OptionsCache.GetValue(options, CreateFilteredOptions);
    }

    private static JsonSerializerOptions CreateFilteredOptions(JsonSerializerOptions options)
    {
        var newOptions = new JsonSerializerOptions(options);
        // Remove MigratedPropertyConverterFactory and MigratedPropertyConverter<> to avoid recursion
        var convertersToRemove = newOptions
            .Converters.Where(c =>
                c is MigratedPropertyConverterFactory
                || (
                    c.GetType().IsGenericType
                    && c.GetType().GetGenericTypeDefinition() == typeof(MigratedPropertyConverter<>)
                )
            )
            .ToList();
        foreach (var converter in convertersToRemove)
        {
            newOptions.Converters.Remove(converter);
        }
        return newOptions;
    }

    private static object JsonElementToObject(JsonElement element)
    {
        return element.ValueKind switch
        {
            JsonValueKind.Object => element.Clone(),
            JsonValueKind.Array => element.Clone(),
            JsonValueKind.String => element.GetString()!,
            JsonValueKind.Number when element.TryGetInt64(out var l) => l,
            JsonValueKind.Number => element.GetDouble(),
            JsonValueKind.True => true,
            JsonValueKind.False => false,
            JsonValueKind.Null => null!,
            _ => element.GetRawText(),
        };
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        // Use default serialization for writing
        var optionsWithoutThis = GetOptionsWithoutThisConverter(options);
        JsonSerializer.Serialize(writer, value, optionsWithoutThis);
    }
}
