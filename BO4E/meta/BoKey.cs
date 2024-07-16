using System;

namespace BO4E.meta;

/// <summary>
///     Those fields of a BusinessObject annotated with the [BoKey] Attribute are considered part of the (composite) key of
///     the Business Object.
///     The BusinessObject Type together with the key identifies a BusinessObject.
/// </summary>
public class BoKey : Attribute
{
    /// <param name="ignoreInheritedKeys">set to true to ignore inherited keys</param>
    /// <example>
    ///     <code>
    /// Marktteilnehmer : Geschaeftspartner
    /// {
    ///     [BoKey(true)]
    ///     public string rollencodenummer;
    /// }
    /// </code>
    ///     We don't want the Marktteilnehmer BO to inherit the keys like name1 etc.
    ///     from the Geschaeftspartner object because the rollencodenummer is a better ID.
    /// </example>
    public BoKey(bool ignoreInheritedKeys = false)
    {
        IgnoreInheritedKeys = ignoreInheritedKeys;
    }

    /// <summary>
    ///     <see cref="BoKey" />
    /// </summary>
    public bool IgnoreInheritedKeys { get; }
}