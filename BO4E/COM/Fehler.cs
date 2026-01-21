using System.Text.Json.Serialization;
using Newtonsoft.Json;
using ProtoBuf;

#nullable enable

namespace BO4E.COM;

/// <summary>
///     Die Komponente wird dazu verwendet Fehler innerhalb eines <see cref="BO4E.BO.Statusbericht"/>s abzubilden
/// </summary>
[ProtoContract]
public class Fehler : COM
{
    /// <summary>Gibt den Typ des Fehlers an.</summary>
    [JsonProperty(PropertyName = "typ")]
    [JsonPropertyName("typ")]
    [ProtoMember(1)]
    public BO4E.ENUM.FehlerTyp? Typ { get; set; }

    /// <summary>
    ///     Fehlerdetails
    /// </summary>
    [JsonProperty(PropertyName = "fehlerDetails")]
    [JsonPropertyName("fehlerDetails")]
    [ProtoMember(2)]
    public System.Collections.Generic.List<FehlerDetail>? FehlerDetails { get; set; } =
        new System.Collections.Generic.List<FehlerDetail>();
}
