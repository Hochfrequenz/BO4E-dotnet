#nullable enable
using System.Collections.Generic;
using System.Text.Json.Serialization;
using BO4E.COM;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.BO;

/// <summary>
/// Modell für die Abbildung der Referenz auf die Lokationsbündelstruktur. Diese gibt an welche Marktlokationen,
/// Messlokationen, Netzlokationen, technische/steuerbaren Ressourcen an einer Lokation vorhanden sind;
/// </summary>
[ProtoContract]
public class Lokationszuordnung : BusinessObject
{
    /// <summary>
    /// Liste mit IDs der referenzierten Marktlokationen
    /// </summary>
    [JsonProperty(Order = 11, PropertyName = "marktlokationen")]
    [JsonPropertyName("marktlokationen")]
    [JsonPropertyOrder(11)]
    [ProtoMember(11)]
    public List<Marktlokation>? Marktlokationen { get; set; }

    /// <summary>
    /// Liste mit IDs der referenzierten Messlokationen
    /// </summary>
    [JsonProperty(Order = 12, PropertyName = "messlokationen")]
    [JsonPropertyName("messlokationen")]
    [JsonPropertyOrder(12)]
    [ProtoMember(12)]
    public List<Messlokation>? Messlokationen { get; set; }

    /// <summary>
    /// Liste mit IDs der referenzierten Netzlokationen
    /// </summary>
    [JsonProperty(Order = 13, PropertyName = "netzlokationen")]
    [JsonPropertyName("netzlokationen")]
    [JsonPropertyOrder(13)]
    [ProtoMember(13)]
    public List<Netzlokation>? Netzlokationen { get; set; }

    /// <summary>
    /// Liste mit IDs der referenzierten technischen Ressourcen
    /// </summary>
    [JsonProperty(Order = 14, PropertyName = "technischeRessourcen")]
    [JsonPropertyName("technischeRessourcen")]
    [JsonPropertyOrder(14)]
    [ProtoMember(14)]
    public List<TechnischeRessource>? TechnischeRessourcen { get; set; }

    /// <summary>
    /// Liste mit IDs der referenzierten steuerbaren Ressourcen
    /// </summary>
    [JsonProperty(Order = 15, PropertyName = "steuerbareRessourcen")]
    [JsonPropertyName("steuerbareRessourcen")]
    [JsonPropertyOrder(15)]
    [ProtoMember(15)]
    public List<SteuerbareRessource>? SteuerebareRessourcen { get; set; }

    /// <summary>
    /// Zeitspanne der Gültigkeit
    /// </summary>
    [JsonProperty(Order = 16, PropertyName = "gueltigkeit")]
    [JsonPropertyName("gueltigkeit")]
    [JsonPropertyOrder(16)]
    [ProtoMember(16)]
    // Instead of COM.Zeitspanne (bo4e-python)
    public List<Zeitraum>? Gueltigkeit { get; set; }

    /// <summary>
    /// Verknüpfungsrichtung z.B. Malo-Melo
    /// </summary>
    [JsonProperty(Order = 17, PropertyName = "zuordnungstyp")]
    [JsonPropertyName("zuordnungstyp")]
    [JsonPropertyOrder(17)]
    [ProtoMember(17)]
    public string? Zuordnungstyp { get; set; }

    /// <summary>
    /// Code, der angibt wie die Lokationsbündelstruktur zusammengesetzt ist (zu finden unter "Codeliste der Lokationsbündelstrukturen" auf https://www.edi-energy.de/index.php?id=38)
    /// </summary>
    [JsonProperty(Order = 18, PropertyName = "lokationsbuendelcode")]
    [JsonPropertyName("lokationsbuendelcode")]
    [JsonPropertyOrder(18)]
    [ProtoMember(18)]
    [BoKey]
    public string? LokationsbuendelCode { get; set; }
}
