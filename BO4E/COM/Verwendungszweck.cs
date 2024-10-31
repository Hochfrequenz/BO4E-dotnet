using System.Collections.Generic;
using System.Text.Json.Serialization;
using BO4E.meta;
using BO4E.meta.LenientConverters;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM;

/// <summary>
///     Marktrolle
/// </summary>
[ProtoContract]
[NonOfficial(NonOfficialCategory.REGULATORY_REQUIREMENTS)]
[System.Text.Json.Serialization.JsonConverter(typeof(SystemTextVerwendungszweckEnumToComConverter))]
[Newtonsoft.Json.JsonConverter(typeof(NewtonsoftVerwendungszweckEnumToComConverter))]
public class Verwendungszweck : COM
{
    /// <summary>
    ///     rollencodenummer von Marktrolle
    /// </summary>
    [JsonProperty(PropertyName = "marktrolle")]
    [JsonPropertyName("marktrolle")]
    [ProtoMember(3)]
    public ENUM.Marktrolle Marktrolle { get; set; }

    /// <summary>
    ///     code von Marktrolle
    /// </summary>
    [JsonProperty(PropertyName = "zweck")]
    [JsonPropertyName("zweck")]
    [ProtoMember(4)]
    public List<ENUM.Verwendungszweck>? Zweck { get; set; }
}
