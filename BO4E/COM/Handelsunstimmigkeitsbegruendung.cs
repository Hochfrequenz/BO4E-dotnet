using System.Text.Json.Serialization;
using System.Collections.Generic;
using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM;

/// <summary>
/// Begründung der Korrektheit der Rechnung oder des Lieferscheins (COMDIS SG3 AJT)
/// </summary>
[ProtoContract]
[NonOfficial(NonOfficialCategory.MISSING)]
public class Handelsunstimmigkeitsbegruendung : COM
{
    /// <summary>
    /// Referenzen auf vorherige Nachrichten
    /// </summary>
    [JsonProperty(PropertyName = "referenzen", Required = Required.Default, Order = 1)]
    [JsonPropertyName("referenzen")]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(1)]

    public List<string>? Referenzen { get; set; }


    /// <summary>
    /// Angabe des Handelsunstimmigkeitsgrunds
    /// </summary>
    [JsonProperty(PropertyName = "grund", Required = Required.Always, Order = 2)]
    [JsonPropertyName("grund")]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(2)]
    public Handelsunstimmigkeitsgrund Grund { get; set; }

}
