using System;
using System.Collections.Concurrent;
using System.Collections.Frozen;
using System.Linq;
using System.Reflection;
using BO4E.BO;

namespace BO4E.meta;

/// <summary>
/// Provides centralized type resolution for BusinessObject types.
/// Used by both Newtonsoft.Json and System.Text.Json converters for polymorphic deserialization.
/// </summary>
/// <remarks>
/// This class provides:
/// <list type="bullet">
///   <item>O(1) lookups for known BO4E types via <see cref="FrozenDictionary{TKey,TValue}"/></item>
///   <item>Cached fallback lookups for custom types in external assemblies</item>
///   <item>Thread-safe operations for concurrent deserialization scenarios</item>
/// </list>
/// </remarks>
internal static class BusinessObjectTypeResolver
{
    /// <summary>
    /// Cached dictionary for O(1) BusinessObject type lookups by name (case-insensitive).
    /// Uses FrozenDictionary for optimal read performance on this immutable collection.
    /// </summary>
    private static readonly FrozenDictionary<string, Type> BoTypesByName =
        BusinessObjectSerializationBinder
            .BusinessObjectAndCOMTypes.Where(t => typeof(BusinessObject).IsAssignableFrom(t))
            .ToFrozenDictionary(t => t.Name, t => t, StringComparer.OrdinalIgnoreCase);

    /// <summary>
    /// Cache for external type lookups (types not in BO4E assembly).
    /// Thread-safe for concurrent access during deserialization.
    /// </summary>
    private static readonly ConcurrentDictionary<string, Type?> ExternalTypeCache = new(
        StringComparer.OrdinalIgnoreCase
    );

    /// <summary>
    /// Resolves a BusinessObject type by name with fallback to assembly scanning.
    /// </summary>
    /// <param name="typeName">The type name to resolve (case-insensitive)</param>
    /// <returns>The resolved type, or null if not found</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="typeName"/> is null</exception>
    public static Type? ResolveType(string typeName)
    {
        ArgumentNullException.ThrowIfNull(typeName);

        // Primary lookup in known BO4E types (O(1))
        if (BoTypesByName.TryGetValue(typeName, out var type))
        {
            return type;
        }

        // Fallback: search external assemblies (cached)
        return ScanAssembliesForType(typeName);
    }

    /// <summary>
    /// Returns a Type for given Business Object name from the known BO4E types only.
    /// Does not search external assemblies.
    /// </summary>
    /// <param name="businessObjectName">Name of a business object (case-insensitive)</param>
    /// <returns>A BusinessObject Type or null if no matching type was found in BO4E</returns>
    /// <exception cref="ArgumentNullException">If argument is null</exception>
    public static Type? GetKnownType(string businessObjectName)
    {
        ArgumentNullException.ThrowIfNull(businessObjectName);
        return BoTypesByName.TryGetValue(businessObjectName, out var type) ? type : null;
    }

    /// <summary>
    /// Scans all loaded assemblies for a type with the given name.
    /// Results are cached to avoid repeated assembly scanning.
    /// </summary>
    private static Type? ScanAssembliesForType(string typeName)
    {
        return ExternalTypeCache.GetOrAdd(
            typeName,
            static name =>
            {
                foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
                {
                    try
                    {
                        var type = assembly
                            .GetTypes()
                            .FirstOrDefault(x =>
                                string.Equals(x.Name, name, StringComparison.OrdinalIgnoreCase)
                            );
                        if (type != null)
                        {
                            return type;
                        }
                    }
                    catch (ReflectionTypeLoadException)
                    {
                        // Assembly failed to load some types, skip it
                        continue;
                    }
                }

                return null;
            }
        );
    }
}
