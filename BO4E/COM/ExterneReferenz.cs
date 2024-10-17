#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using BO4E.BO;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM;

/// <summary>
///     Viele Datenobjekte weisen in unterschiedlichen Systemen eine eindeutige ID (Kundennummer, GP-Nummer etc.) auf.
///     Beim Austausch von Datenobjekten zwischen verschiedenen Systemen ist es daher hilfreich, sich die eindeutigen IDs
///     der anzubindenden Systeme zu merken.
///     Diese Komponente ermöglicht es, sich die SAP GP-Nummer zu merken, um diese bei SAP-Aufrufen als Parameter mitgeben
///     zu können.
/// </summary>
[ProtoContract]
public class ExterneReferenz : COM
{
    /// <summary>
    ///     Bezeichnung der externen Referenz (z.B. "hochfrequenz integration services")
    /// </summary>
    [JsonProperty(PropertyName = "exRefName")]
    [JsonPropertyName("exRefName")]
    [ProtoMember(1)]
    public string? ExRefName { get; set; }

    /// <summary>
    ///     Wert der externen Referenz (z.B. "123456"; "4711")
    /// </summary>
    [JsonProperty(PropertyName = "exRefWert")]
    [JsonPropertyName("exRefWert")]
    [ProtoMember(2)]
    public string? ExRefWert { get; set; }

    /// <summary>
    /// Ist das Objekt valide
    /// </summary>
    /// <returns></returns>
    public override bool IsValid()
    {
        return !string.IsNullOrWhiteSpace(ExRefName) && !string.IsNullOrWhiteSpace(ExRefWert);
    }
}

/// <summary>
///     easy access methods for <see cref="List{T}" /> to allow easier setting and getting.
/// </summary>
internal static class ExterneReferenzExtensions
{
    /// <summary>
    ///     try to get a value from <see cref="BusinessObject.ExterneReferenzen" />
    /// </summary>
    /// <param name="extRefName">name of the externe referenz</param>
    /// <param name="extRefWert">non-null if the externe referenz was found</param>
    /// <param name="extReferences">list of external references</param>
    /// <returns>true if externe referenz with name <paramref name="extRefName" /> was found</returns>
    public static bool TryGetExterneReferenz(
        this ICollection<ExterneReferenz>? extReferences,
        string? extRefName,
        out string? extRefWert
    )
    {
        if (extRefName == null)
        {
            throw new ArgumentNullException(nameof(extRefName));
        }

        if (extReferences == null)
        {
            extRefWert = null;
            return false;
        }

        var externeReferenz = extReferences.SingleOrDefault(er => er.ExRefName == extRefName);
        if (externeReferenz == null)
        {
            extRefWert = null;
            return false;
        }

        extRefWert = externeReferenz.ExRefWert;
        return true;
    }

    /// <summary>
    ///     Adds a new value to <paramref name="extReferences" /> and created the list if it's null.
    /// </summary>
    /// <param name="extReferences">list of external references</param>
    /// <param name="extRef">new externe Referenz</param>
    /// <param name="overwriteExisting">set true to overwrite existing values</param>
    /// <exception cref="InvalidOperationException">
    ///     if there is a conflicting value and <paramref name="overwriteExisting" />
    ///     is false
    /// </exception>
    public static List<ExterneReferenz> SetExterneReferenz(
        this List<ExterneReferenz>? extReferences,
        ExterneReferenz extRef,
        bool overwriteExisting = false
    )
    {
        if (extRef == null)
        {
            throw new ArgumentNullException(nameof(extRef));
        }

        if (!extRef.IsValid())
        {
            throw new ArgumentException(
                $"The external reference with {nameof(extRef.ExRefName)}='{extRef.ExRefName}' and {nameof(extRef.ExRefWert)}='{extRef.ExRefWert}' you tried to add is invalid.",
                nameof(extRef)
            );
        }
        if (extReferences == null)
        {
            return new List<ExterneReferenz> { extRef };
        }
        if (
            extReferences.Any()
            && extReferences.TryGetExterneReferenz(extRef.ExRefName, out var existingRefWert)
        )
        {
            if (overwriteExisting)
            {
                extReferences.RemoveAll(er => er.ExRefName == extRef.ExRefName);
            }
            else
            {
                if (existingRefWert != extRef.ExRefWert)
                {
                    throw new InvalidOperationException(
                        $"There is already an with {nameof(extRef.ExRefName)}='{extRef.ExRefName}' having {nameof(extRef.ExRefWert)}='{existingRefWert}'!='{extRef.ExRefWert}'. Use {nameof(overwriteExisting)}=true to overwrite it."
                    );
                }

                return extReferences;
            }
        }

        extReferences.Add(extRef);
        return extReferences;
    }
}
