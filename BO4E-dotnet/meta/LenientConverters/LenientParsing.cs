using System;

namespace BO4E.meta.LenientParsing
{
    /// <summary>
    /// Passing LenientParsing flags to <see cref="BoMapper"/> allows you to map such JSONs that
    /// are "slightly invalid". Slightly means, e.g. the date string format is wrong.
    /// </summary>
    [Flags]
    public enum LenientParsing
    {
        /// <summary>
        /// strict parsing, no lenient behaviour
        /// </summary>
        Strict = 0,
        /// <summary>
        /// allows automatic conversion of other date formats
        /// </summary>
        DateTime = 1,
        /// <summary>
        /// allows list of objects with enum as value where a list of enums was expected
        /// (e.g. when mapping from a SAP CDS view)
        /// </summary>
        EnumList = 2,
        /// <summary>
        /// allow partly malformed BO4E URIs
        /// </summary>
        Bo4eUri = 4,
        // /// <summary>
        // /// allow null or missing values where a list is mandatory => map on empty list
        // /// </summary>
        // EmptyLists = 8,
        /// <summary>
        /// Set initial DateTime if date could not be parsed (only applies if <see cref="LenientParsing.DateTime"/> is set)
        /// </summary>
        SetInitialDateIfNull = 8,
        /// <summary>
        /// Try to parse Strings as Integer if type doesn't fit
        /// </summary>
        StringToInt = 16,
        /// <summary>
        /// most lenient (all others)
        /// </summary>
        MOST_LENIENT = ~0
    }
}
