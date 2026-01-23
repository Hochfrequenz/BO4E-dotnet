#nullable enable
using System;
using System.Runtime.Serialization;

namespace BO4E.meta.LenientConverters;

/// <summary>
///     Passing LenientParsing flags to <see cref="BoMapper" /> allows you to map such JSONs that
///     are "slightly invalid". Slightly means, e.g. the date string format is wrong.
/// </summary>
[Flags]
public enum LenientParsing
{
    /// <summary>
    ///     strict parsing, no lenient behaviour
    /// </summary>
    [EnumMember(Value = "STRICT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("STRICT")]
    STRICT = 0,

    /// <summary>
    ///     allows automatic conversion of other date formats
    /// </summary>
    [EnumMember(Value = "DATE_TIME")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("DATE_TIME")]
    DATE_TIME = 1,

    /// <summary>
    ///     allows list of objects with enum as value where a list of enums was expected
    ///     (e.g. when mapping from a SAP CDS view)
    /// </summary>
    [EnumMember(Value = "ENUM_LIST")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ENUM_LIST")]
    ENUM_LIST = 2,

    /// <summary>
    ///     allow partly malformed BO4E URIs
    /// </summary>
    [EnumMember(Value = "BO4_E_URI")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("BO4_E_URI")]
    BO4_E_URI = 4,

    // /// <summary>
    // /// allow null or missing values where a list is mandatory => map on empty list
    // /// </summary>
    // EmptyLists = 8,
    /// <summary>
    ///     Set initial DateTimeOffset if date could not be parsed (only applies if <see cref="DATE_TIME" /> is set)
    /// </summary>
    [EnumMember(Value = "SET_INITIAL_DATE_IF_NULL")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("SET_INITIAL_DATE_IF_NULL")]
    SET_INITIAL_DATE_IF_NULL = 8,

    /// <summary>
    ///     Try to parse Strings as Integer if type doesn't fit
    /// </summary>
    [EnumMember(Value = "STRING_TO_INT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("STRING_TO_INT")]
    STRING_TO_INT = 16,

    /// <summary>
    ///     most lenient (all others)
    /// </summary>
    [EnumMember(Value = "MOST_LENIENT")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("MOST_LENIENT")]
    MOST_LENIENT = ~0,
}
