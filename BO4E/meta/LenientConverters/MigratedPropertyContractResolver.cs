using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace BO4E.meta.LenientConverters;

/// <summary>
/// A <see cref="IContractResolver"/> that provides error-tolerant deserialization for properties
/// marked with <see cref="MigratedFromUserPropertiesAttribute"/>.
/// </summary>
/// <remarks>
/// <para>
/// This contract resolver handles types that implement <see cref="IUserProperties"/> and have
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
public class MigratedPropertyContractResolver : DefaultContractResolver
{
    /// <summary>
    /// Cache for property information to avoid repeated reflection.
    /// </summary>
    private static readonly ConcurrentDictionary<Type, HashSet<string>> MigratedPropertiesCache =
        new();

    private readonly HashSet<string>? _userPropertiesWhiteList;

    /// <summary>
    /// Creates a new instance of <see cref="MigratedPropertyContractResolver"/>.
    /// </summary>
    public MigratedPropertyContractResolver() { }

    /// <summary>
    /// Creates a new instance of <see cref="MigratedPropertyContractResolver"/> with a whitelist
    /// of allowed user properties (for compatibility with existing functionality).
    /// </summary>
    /// <param name="userPropertiesWhiteList">Set of property names allowed in UserProperties.</param>
    public MigratedPropertyContractResolver(HashSet<string> userPropertiesWhiteList)
    {
        _userPropertiesWhiteList = userPropertiesWhiteList;
    }

    /// <inheritdoc/>
    protected override JsonObjectContract CreateObjectContract(Type objectType)
    {
        var contract = base.CreateObjectContract(objectType);

        // Only handle IUserProperties types
        if (!typeof(IUserProperties).IsAssignableFrom(objectType))
        {
            return contract;
        }

        // Get the set of migrated property names for this type
        var migratedPropertyNames = GetMigratedPropertyNames(objectType);
        if (migratedPropertyNames.Count == 0)
        {
            return contract;
        }

        // Set up extension data handling if applicable
        if (contract.ExtensionDataSetter != null && _userPropertiesWhiteList != null)
        {
            var oldSetter = contract.ExtensionDataSetter;
            contract.ExtensionDataSetter = (o, key, value) =>
            {
                if (_userPropertiesWhiteList.Contains(key))
                {
                    oldSetter(o, key, value);
                }
            };
        }

        return contract;
    }

    /// <inheritdoc/>
    protected override JsonProperty CreateProperty(
        MemberInfo member,
        MemberSerialization memberSerialization
    )
    {
        var property = base.CreateProperty(member, memberSerialization);

        // Check if this property is marked with MigratedFromUserPropertiesAttribute
        var migratedAttribute = member.GetCustomAttribute<MigratedFromUserPropertiesAttribute>();
        if (migratedAttribute == null)
        {
            return property;
        }

        // Check if the declaring type implements IUserProperties
        var declaringType = member.DeclaringType;
        if (declaringType == null || !typeof(IUserProperties).IsAssignableFrom(declaringType))
        {
            return property;
        }

        // Wrap the property value provider to catch deserialization errors
        var originalValueProvider = property.ValueProvider;
        if (originalValueProvider != null)
        {
            property.ValueProvider = new ErrorTolerantValueProvider(
                originalValueProvider,
                property.PropertyName ?? member.Name,
                property.PropertyType
            );
        }

        return property;
    }

    private static HashSet<string> GetMigratedPropertyNames(Type type)
    {
        return MigratedPropertiesCache.GetOrAdd(
            type,
            t => new HashSet<string>(
                t.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.GetCustomAttribute<MigratedFromUserPropertiesAttribute>() != null)
                    .Select(p => p.Name),
                StringComparer.OrdinalIgnoreCase
            )
        );
    }

    /// <summary>
    /// A value provider that catches deserialization errors and stores failed values in UserProperties.
    /// </summary>
    private sealed class ErrorTolerantValueProvider : IValueProvider
    {
        private readonly IValueProvider _innerProvider;
        private readonly string _propertyName;
        private readonly Type? _propertyType;

        public ErrorTolerantValueProvider(
            IValueProvider innerProvider,
            string propertyName,
            Type? propertyType
        )
        {
            _innerProvider = innerProvider;
            _propertyName = propertyName;
            _propertyType = propertyType;
        }

        public object? GetValue(object target)
        {
            return _innerProvider.GetValue(target);
        }

        public void SetValue(object target, object? value)
        {
            try
            {
                // If the value is a JToken that needs conversion, try to convert it
                if (
                    value is JToken jToken
                    && _propertyType != null
                    && _propertyType != typeof(JToken)
                )
                {
                    try
                    {
                        var convertedValue = jToken.ToObject(_propertyType);
                        _innerProvider.SetValue(target, convertedValue);
                        return;
                    }
                    catch (Exception ex) when (IsDeserializationError(ex))
                    {
                        // Store the failed value in UserProperties
                        StoreInUserProperties(target, jToken);
                        return;
                    }
                }

                _innerProvider.SetValue(target, value);
            }
            catch (Exception ex) when (IsDeserializationError(ex))
            {
                // Store the failed value in UserProperties
                StoreInUserProperties(target, value);
            }
        }

        private static bool IsDeserializationError(Exception ex)
        {
            // Only catch type conversion/deserialization errors
            return ex is JsonSerializationException
                || ex is JsonReaderException
                || ex is FormatException
                || ex is InvalidCastException
                || ex is ArgumentException
                || ex is NotSupportedException;
        }

        private void StoreInUserProperties(object target, object? value)
        {
            if (target is IUserProperties userPropertiesTarget)
            {
                userPropertiesTarget.UserProperties ??= new Dictionary<string, object>();
                var key = MigratedFromUserPropertiesAttribute.GetUserPropertiesKey(_propertyName);

                // Convert JToken to a more storage-friendly format if needed
                var storedValue = value switch
                {
                    JToken jt => jt.DeepClone(),
                    _ => value,
                };

                userPropertiesTarget.UserProperties[key] = storedValue!;
            }
        }
    }
}

/// <summary>
/// Extension methods for configuring Newtonsoft.Json serialization with migrated property support.
/// </summary>
public static class MigratedPropertyNewtonsoftExtensions
{
    /// <summary>
    /// Creates an error handler that catches deserialization errors for properties marked with
    /// <see cref="MigratedFromUserPropertiesAttribute"/> and stores failed values in UserProperties.
    /// </summary>
    /// <param name="settings">The JSON serializer settings to configure.</param>
    /// <returns>The configured settings for method chaining.</returns>
    public static JsonSerializerSettings WithMigratedPropertyErrorHandling(
        this JsonSerializerSettings settings
    )
    {
        var originalHandler = settings.Error;

        settings.Error = (sender, args) =>
        {
            // Check if this is an error on a migrated property
            if (ShouldHandleMigratedPropertyError(args))
            {
                StoreMigrationErrorInUserProperties(args);
                args.ErrorContext.Handled = true;
                return;
            }

            // Call original handler if exists
            originalHandler?.Invoke(sender, args);
        };

        return settings;
    }

    private static bool ShouldHandleMigratedPropertyError(ErrorEventArgs args)
    {
        // Get the current object being deserialized
        var currentObject = args.CurrentObject;
        if (currentObject == null || currentObject is not IUserProperties)
        {
            return false;
        }

        // Get the member (property) that caused the error
        var member = args.ErrorContext.Member;
        if (member == null)
        {
            return false;
        }

        var memberName = member.ToString();
        if (string.IsNullOrEmpty(memberName))
        {
            return false;
        }

        // Check if the property is marked with MigratedFromUserPropertiesAttribute
        var objectType = currentObject.GetType();
        var property = objectType.GetProperty(
            memberName,
            BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase
        );

        return property?.GetCustomAttribute<MigratedFromUserPropertiesAttribute>() != null;
    }

    private static void StoreMigrationErrorInUserProperties(ErrorEventArgs args)
    {
        if (args.CurrentObject is IUserProperties userPropertiesTarget)
        {
            var memberName = args.ErrorContext.Member?.ToString();
            if (!string.IsNullOrEmpty(memberName))
            {
                userPropertiesTarget.UserProperties ??= new Dictionary<string, object>();
                var key = MigratedFromUserPropertiesAttribute.GetUserPropertiesKey(memberName);

                // Store error information
                userPropertiesTarget.UserProperties[key] = new Dictionary<string, object>
                {
                    ["error"] = args.ErrorContext.Error.Message,
                    ["path"] = args.ErrorContext.Path,
                };
            }
        }
    }
}
