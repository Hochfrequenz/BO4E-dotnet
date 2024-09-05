using System.Text.Json.Serialization;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM;

/// <summary>
///     Die Komponente wird dazu verwendet Fehler innerhalb eines <see cref="BO4E.BO.Statusbericht"/>s abzubilden
/// </summary>
[ProtoContract]
public class Fehler : COM
{
    /// <summary>Gibt den Typ des Fehlers an.</summary>
    [JsonProperty(PropertyName = "typ", Required = Required.Always)]
    [JsonPropertyName("typ")]
    [ProtoMember(1)]
    public BO4E.ENUM.FehlerTyp Typ { get; set; }

    /// <summary>
    ///     Fehlerdetails
    /// </summary>
    [JsonProperty(PropertyName = "fehlerDetails", Required = Required.Default)]
    [JsonPropertyName("fehlerDetails")]
    [ProtoMember(2)]
    public System.Collections.Generic.List<FehlerDetail>? FehlerDetails { get; set; } =
        new System.Collections.Generic.List<FehlerDetail>();
}
