using System.Collections.Generic;
using System.Text.Json.Serialization;
using BO4E.ENUM;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM;

/// <summary>
/// ordnet beliebigen einer Lokations-ID einen Lokationstyp zu
/// </summary>
[ProtoContract]
public class LokationsTypZuordnung : COM
{
    /// <summary>
    /// Lokationstyp
    /// </summary>
    [JsonProperty(Order = 1, PropertyName = "lokationstyp")]
    [JsonPropertyName("lokationstyp")]
    [JsonPropertyOrder(1)]
    [ProtoMember(1)]
    public Lokationstyp? Lokationstyp { get; set; }

    /// <summary>
    /// Wert, der einem Lokationstyp zugeordnet werden soll #TODO: generischer? (für andere zur Verfügung stellen)
    /// </summary>
    [JsonProperty(Order = 2, PropertyName = "lokationsId")]
    [JsonPropertyName("lokationsId")]
    [JsonPropertyOrder(2)]
    [ProtoMember(2)]
    public string? LokationsId { get; set; }
}
