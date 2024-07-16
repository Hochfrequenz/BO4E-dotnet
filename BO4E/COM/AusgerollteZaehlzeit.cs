using BO4E.meta;

using Newtonsoft.Json;

using ProtoBuf;

using System;
using System.Text.Json.Serialization;

namespace BO4E.COM;

/// <summary>
///     Ausgerollte Zaehlzeit
/// </summary>
[ProtoContract]
[NonOfficial(NonOfficialCategory.REGULATORY_REQUIREMENTS)]
public class AusgerollteZaehlzeit : COM
{
    [Newtonsoft.Json.JsonIgnore]
    [System.Text.Json.Serialization.JsonIgnore]
    [ProtoMember(4, Name = nameof(Aenderungszeitpunkt))]
    [CompatibilityLevel(CompatibilityLevel.Level240)]
    private DateTime _Aenderungszeitpunkt
    {
        get => Aenderungszeitpunkt.UtcDateTime;
        set => Aenderungszeitpunkt = DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }
    /// <summary>
    /// Angabe eines Zeitpunktes, zu dem der Wechsel auf ein neues aktives Zählzeitregister erfolgt.
    /// </summary>
    /// <remarks>UTILTS SG5 DTM+Z34</remarks>
    [JsonProperty(Required = Required.Always, Order = 4, PropertyName = "aenderungszeitpunkt")]
    [JsonPropertyName("aenderungszeitpunkt")]
    [JsonPropertyOrder(4)]
    [ProtoIgnore]
    public DateTimeOffset Aenderungszeitpunkt { get; set; }

    /// <summary>
    ///     Zählzeitregister
    /// </summary>
    [JsonProperty(PropertyName = "register", Order = 5, Required = Required.Default)]
    [JsonPropertyName("register")]
    [JsonPropertyOrder(5)]
    [ProtoMember(5)]
    public string? Register { get; set; }

}
