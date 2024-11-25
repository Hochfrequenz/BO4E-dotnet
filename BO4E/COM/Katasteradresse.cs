using System.Text.Json.Serialization;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM;

/// <summary>Dient der Adressierung über die Liegenschaftsinformation.</summary>
[ProtoContract]
public class Katasteradresse : COM
{
    /// <summary>Die Gemarkung oder die Flur in der die Liegenschaft liegt</summary>
    [DataCategory(DataCategory.ADDRESS)]
    [JsonProperty(PropertyName = "gemarkung_flur")]
    [JsonPropertyName("gemarkung_flur")]
    [ProtoMember(3)]
    public string? GemarkungFlur { get; set; }

    /// <summary>Das Flurstück mit dem die Liegenschaft (Grundstück) bezeichnet ist.</summary>
    [DataCategory(DataCategory.ADDRESS)]
    [JsonProperty(PropertyName = "flurstueck")]
    [JsonPropertyName("flurstueck")]
    [ProtoMember(4)]
    public string? Flurstueck { get; set; }
}
