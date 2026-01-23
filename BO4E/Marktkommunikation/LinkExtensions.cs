#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using BO4E.Marktkommunikation.v1;

namespace BO4E.Marktkommunikation;

#nullable disable warnings
/// <summary>
/// extension methods for <see cref="BOneyComb.Links"/> and <see cref="v2.BOneyComb.ZeitabhaengigeLinks"/>
/// </summary>
public static class LinkExtensions
{
    /// <summary>
    /// converts a <see cref="ZeitabhaengigeBeziehung"/> to a KeyValuePair with the parent id as key and the child id as value
    /// </summary>
    /// <param name="timeDependentLink"></param>
    /// <returns></returns>
    /// <remarks>time-dependent information are lost in this mapping</remarks>
    public static KeyValuePair<string, List<string>> ToTimeIndependentLink(
        this ZeitabhaengigeBeziehung timeDependentLink
    )
    {
        var key = timeDependentLink.ParentId;
        var value = new List<string> { timeDependentLink.ChildId };
        return new KeyValuePair<string, List<string>>(key, value);
    }

    /// <summary>
    /// converts a <see cref="ZeitabhaengigeBeziehung"/> to a KeyValuePair with the parent id as key and the child id as value
    /// </summary>
    /// <param name="timeIndependentLink"></param>
    /// <returns></returns>
    public static List<ZeitabhaengigeBeziehung> ToTimeDependentLink(
        this KeyValuePair<string, List<string>> timeIndependentLink
    )
    {
        var result = timeIndependentLink
            .Value.Select(x => new ZeitabhaengigeBeziehung
            {
                ParentId = timeIndependentLink.Key,
                ChildId = x,
                GueltigVon = DateTimeOffset.MinValue,
                GueltigBis = DateTimeOffset.MaxValue,
            })
            .ToList();
        return result;
    }

    /// <summary>
    /// converts a dictionary of links to<see cref="ZeitabhaengigeBeziehung"/> based on <see cref="ToTimeDependentLink"/>
    /// </summary>
    /// <param name="timeIndependentLinks"></param>
    /// <returns></returns>
    public static List<ZeitabhaengigeBeziehung> ToTimeDependentLinks(
        this IDictionary<string, List<string>> timeIndependentLinks
    )
    {
        var result = timeIndependentLinks.SelectMany(x => x.ToTimeDependentLink()).ToList();
        return result;
    }

    /// <summary>
    /// converts a list of <see cref="ZeitabhaengigeBeziehung"/> to a dictionary of links
    /// </summary>
    /// <param name="timeDependentLinks"></param>
    /// <returns></returns>
    public static Dictionary<string, List<string>> ToTimeIndependentLinks(
        this IList<ZeitabhaengigeBeziehung> timeDependentLinks
    )
    {
        var result = timeDependentLinks
            .GroupBy(x => x.ParentId)
            .ToDictionary(
                grouper => grouper.Key,
                grouper => grouper.Select(x => x.ChildId).ToList()
            );
        return result;
    }
}
