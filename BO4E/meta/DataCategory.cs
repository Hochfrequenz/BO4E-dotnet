#nullable enable
using System.Runtime.Serialization;

namespace BO4E.meta;

/// <summary>
///     The DataCategory is supposed to be used as an attribute on Business Object fields to specify what type of data they
///     contain.
/// </summary>
/// <seealso cref="DataCategoryAttribute" />
public enum DataCategory
{
    /// <summary>
    ///     address data (city, street, house number, postbox)
    /// </summary>
    [EnumMember(Value = "ADDRESS")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("ADDRESS")]
    ADDRESS,

    /// <summary>
    ///     device master data like device number or lokale Kennzeichnung
    /// </summary>
    [EnumMember(Value = "DEVICE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("DEVICE")]
    DEVICE,

    /// <summary>
    ///     financial information like bank account numbers
    /// </summary>
    [EnumMember(Value = "FINANCE")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("FINANCE")]
    FINANCE,

    /// <summary>
    ///     legal and tax relevant information like handelsregisternummer
    /// </summary>
    [EnumMember(Value = "LEGAL")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("LEGAL")]
    LEGAL,

    /// <summary>
    ///     names of persons
    /// </summary>
    [EnumMember(Value = "NAME")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("NAME")]
    NAME,

    /// <summary>
    ///     metering values.
    /// </summary>
    [EnumMember(Value = "METER_READING")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("METER_READING")]
    METER_READING,

    /// <summary>
    ///     points of delivery (market Location, measuring location, tranche)
    /// </summary>
    [EnumMember(Value = "POD")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("POD")]
    POD,

    /// <summary>
    ///     the <see cref="BO.BusinessObject.UserProperties" /> might be handled separately with this DataCategory
    /// </summary>
    [EnumMember(Value = "USER_PROPERTIES")]
    [System.Text.Json.Serialization.JsonStringEnumMemberName("USER_PROPERTIES")]
    USER_PROPERTIES,
}
