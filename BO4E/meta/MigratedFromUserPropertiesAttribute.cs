using System;

namespace BO4E.meta;

/// <summary>
/// Marks a property that was recently added to the model after previously being stored as untyped data
/// in <see cref="IUserProperties.UserProperties"/>.
/// </summary>
/// <remarks>
/// <para>
/// <strong>WHY THIS ATTRIBUTE EXISTS:</strong>
/// </para>
/// <para>
/// When BO4E model classes are persisted (e.g., in databases via EF Core), unknown JSON properties
/// are captured in the <see cref="IUserProperties.UserProperties"/> dictionary via the
/// <c>[JsonExtensionData]</c> attribute. This is useful for forward compatibility - data isn't lost
/// even if the model doesn't have a matching property yet.
/// </para>
/// <para>
/// However, when a new typed property is added to the model (e.g., <c>List&lt;Verbrauchsart&gt; Verbrauchsarten</c>),
/// existing persisted data may have that property stored in an incompatible format. For example:
/// <list type="bullet">
///     <item><description>An object <c>{"Verbrauchsarten": {"key": "value"}}</c> where an array is expected</description></item>
///     <item><description>Nested arrays <c>{"Verbrauchsarten": [[0], [1]]}</c> instead of flat arrays</description></item>
///     <item><description>Wrong value types that cannot be converted to the target enum/class</description></item>
/// </list>
/// </para>
/// <para>
/// Without special handling, deserializing such legacy data causes exceptions like
/// "read too much or not enough" (System.Text.Json) or similar errors (Newtonsoft.Json),
/// resulting in HTTP 500 errors in web applications.
/// </para>
/// <para>
/// <strong>WHAT THIS ATTRIBUTE DOES:</strong>
/// </para>
/// <para>
/// When a property is marked with <c>[MigratedFromUserProperties]</c>, the lenient JSON converters
/// (<see cref="LenientConverters.LenientSystemTextJsonParsingExtensions"/> and
/// <see cref="LenientConverters.LenientParsingExtensionsNewtonsoft"/>) will:
/// <list type="number">
///     <item><description>Attempt normal deserialization of the property</description></item>
///     <item><description>If deserialization fails with a type mismatch error, catch the exception</description></item>
///     <item><description>Store the raw, unparseable value in <c>UserProperties["_migrationError_{PropertyName}"]</c></description></item>
///     <item><description>Set the property to its default value (null for reference types)</description></item>
///     <item><description>Continue deserializing the remaining properties</description></item>
/// </list>
/// </para>
/// <para>
/// This allows applications to:
/// <list type="bullet">
///     <item><description>Continue functioning without HTTP 500 errors</description></item>
///     <item><description>Query for entities with migration errors via <see cref="IUserProperties.UserProperties"/></description></item>
///     <item><description>Implement data cleanup/migration as a separate process</description></item>
/// </list>
/// </para>
/// <para>
/// <strong>IMPORTANT SAFETY GUARANTEES:</strong>
/// </para>
/// <para>
/// This attribute ONLY affects deserialization errors for the specific marked property.
/// The following errors are NOT caught and will still throw exceptions:
/// <list type="bullet">
///     <item><description>Malformed JSON syntax (e.g., <c>{invalid json</c>)</description></item>
///     <item><description>Errors on properties NOT marked with this attribute</description></item>
///     <item><description>Errors unrelated to type mismatches</description></item>
/// </list>
/// </para>
/// <para>
/// <strong>USAGE:</strong>
/// </para>
/// <code>
/// // Property recently added - legacy data may have incompatible format
/// [MigratedFromUserProperties]
/// [JsonPropertyName("verbrauchsarten")]
/// public List&lt;Verbrauchsart&gt;? Verbrauchsarten { get; set; }
/// </code>
/// <para>
/// <strong>WHEN TO REMOVE:</strong>
/// </para>
/// <para>
/// Once all legacy data has been migrated/cleaned up and no entities have
/// <c>_migrationError_{PropertyName}</c> keys in their UserProperties, this attribute
/// can be safely removed from the property.
/// </para>
/// </remarks>
/// <seealso cref="IUserProperties"/>
/// <seealso cref="IUserProperties.UserProperties"/>
/// <seealso cref="LenientConverters.LenientParsing"/>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
public sealed class MigratedFromUserPropertiesAttribute : Attribute
{
    /// <summary>
    /// The prefix used for storing failed property values in UserProperties.
    /// The full key will be <c>_migrationError_{PropertyName}</c>.
    /// </summary>
    public const string UserPropertiesKeyPrefix = "_migrationError_";

    /// <summary>
    /// Gets the UserProperties key for a given property name.
    /// </summary>
    /// <param name="propertyName">The name of the property that failed to deserialize.</param>
    /// <returns>The key to use in UserProperties, e.g., <c>_migrationError_Verbrauchsarten</c>.</returns>
    public static string GetUserPropertiesKey(string propertyName) =>
        $"{UserPropertiesKeyPrefix}{propertyName}";
}
