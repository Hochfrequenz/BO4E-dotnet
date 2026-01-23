#nullable enable
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BO4E.Marktkommunikation.v2;

/// <summary>
/// the v2 boneycomb contains all the properties of the <see cref="BO4E.Marktkommunikation.v1.BOneyComb"/> + zeitabhängige links
/// </summary>
public class BOneyComb : BO4E.Marktkommunikation.v1.BOneyComb // for now, we model this as inheritance, but we're not restricted to that
{
    /// <summary>
    /// Similar to <see cref="Marktkommunikation.v1.BOneyComb.Links"/> but with time dependencies.
    /// </summary>
    /// <remarks>
    /// We didn't want to encode/serialize any information into the values of <see cref="Marktkommunikation.v1.BOneyComb.Links"/> or loosen its typing by changing the value type to object.
    /// That's why this is a separate property.
    /// With this being a separate property, systems that care only about links, can simply ignore the zeitabhängige Links and those that care have a strong type to work with.
    /// </remarks>
    [JsonPropertyName("zeitabhaengigeLinks")]
    [JsonPropertyOrder(4)]
    [Newtonsoft.Json.JsonProperty(PropertyName = "zeitabhaengigeLinks", Order = 4)]
    public List<ZeitabhaengigeBeziehung>? ZeitabhaengigeLinks { get; set; }
}
