#nullable enable
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
    [JsonProperty(Order = 3, PropertyName = "lokationstyp")]
    [JsonPropertyName("lokationstyp")]
    [JsonPropertyOrder(3)]
    [ProtoMember(3)]
    public Lokationstyp? Lokationstyp { get; set; }

    /// <summary>
    /// Wert, der einem Lokationstyp zugeordnet werden soll #TODO: generischer? (für andere zur Verfügung stellen)
    /// </summary>
    [JsonProperty(Order = 4, PropertyName = "lokationsId")]
    [JsonPropertyName("lokationsId")]
    [JsonPropertyOrder(4)]
    [ProtoMember(4)]
    public string? LokationsId { get; set; }
}
