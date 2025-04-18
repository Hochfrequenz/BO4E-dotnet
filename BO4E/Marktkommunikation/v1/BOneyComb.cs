#nullable enable
using System.Collections.Generic;
using System.Text.Json.Serialization;
using BO4E.BO;
using BO4E.meta;

namespace BO4E.Marktkommunikation.v1;

/// <summary>
/// BOneyComb is a structure that is used when dealing with business objects that are embedded into market communication messages.
/// It combines an array of business objects named <see cref="Stammdaten"/> with a key value dict of process data named <see cred="Transaktionsdaten"/>.
/// A BOneyComb is used to represent the payload of a market communication message and its metadata.
/// BOneyComb is the result structure of the Hochfrequenz edifact-bo4e-converter aka transformer.bee.
/// </summary>
public class BOneyComb
{
    /// <summary>
    /// A list of Business objects.
    /// </summary>
    /// <remarks>
    /// E.g. if you market communication message contained the "Anmeldung",  it'd contain something like a <see cref="BO4E.BO.Zaehler"/>, <see cref="BO4E.BO.Vertrag"/> and a <see cref="BO4E.BO.Marktlokation"/>.
    /// </remarks>
    [JsonPropertyName("stammdaten")]
    [JsonPropertyOrder(1)]
    [Newtonsoft.Json.JsonProperty(PropertyName = "stammdaten", Order = 1)]
    public List<BusinessObject> Stammdaten { get; set; } = [];

    /// <summary>
    /// Transaktionsdaten are data relevant only in the context of this market communication message.
    /// This may include Nachrichtendatum, Prüfidentifikator, etc.
    /// </summary>
    [JsonPropertyName("transaktionsdaten")]
    [JsonPropertyOrder(2)]
    [Newtonsoft.Json.JsonProperty(PropertyName = "transaktionsdaten", Order = 2)]
    public Dictionary<string, string> Transaktionsdaten { get; set; } = new();

    /// <summary>
    /// Links describes relations between different BusinessObjects in Stammdaten.
    /// e.g. if there are two Zaehlers in <see cref="Stammdaten"/>, you could model in the links, to which Messlokation they belong.
    /// Often we use the <see cref="Bo4eUri"/> as key.
    /// </summary>
    [JsonPropertyName("links")]
    [JsonPropertyOrder(3)]
    [Newtonsoft.Json.JsonProperty(PropertyName = "links", Order = 3)]
    public Dictionary<string, List<string>>? Links { get; set; }
}
