using System;
using System.Collections.Generic;
using System.Linq;

namespace BO4E.meta;

/// <summary>
///     This class provides a custom attribute used to annotate fields of Business Objects, COMponents and enums that are
///     NOT part of the official BO4E standard.
///     Using this attribute allows us to keep track of our changes (and those we'll suggest to the BO4E consortium to
///     adapt).
/// </summary>
/// <seealso cref="NonOfficialCategory" />
/// <example>
///     <code>
///  public class SomeBusinessObject : BusinessObject
///  {
///     ...
///  [NonOfficial(NonOfficial.REGULATORY_REQUIREMENT)]
///  public string foo; // this string is needed to express information that are required by law.
///     ...
///  }
/// </code>
/// </example>
public class NonOfficialAttribute : Attribute
{
    /// <summary>
    ///     instantiate by providing a reason
    /// </summary>
    /// <param name="enums"></param>
    public NonOfficialAttribute(params object[] enums)
    {
        if (
            enums.Any(r =>
                r.GetType().BaseType != typeof(Enum) || r.GetType() != typeof(NonOfficialCategory)
            )
        )
        {
            throw new ArgumentException(
                $"You must only pass enums of type {nameof(NonOfficialCategory)}",
                nameof(enums)
            );
        }

        Mapping = new HashSet<Enum>();
        foreach (Enum e in enums)
            Mapping.Add(e);
    }

    /// <summary>
    ///     contains those NonOfficialCategories (<see cref="NonOfficialCategory" />) annotated to the field.
    /// </summary>
    protected HashSet<Enum> Mapping { get; set; }

    /// <summary>
    ///     test if a category is part of the attribute data
    /// </summary>
    /// <param name="noc">a category</param>
    /// <returns>true if the attribute contains the category</returns>
    public bool HasCategory(NonOfficialCategory noc)
    {
        return Mapping.Contains(noc);
    }
}
