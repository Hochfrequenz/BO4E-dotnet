using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using BO4E.COM;
using BO4E.ENUM;
using BO4E.meta.LenientConverters;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.BO;

/// <summary>
///     Mit diesem Geschäftsobjekt wird der Wechsel eines Gerätes oder Zählers modelliert.
/// </summary>
[ProtoContract]
public class Wechsel : BusinessObject
{
    /// <summary>Strom oder Gas. <seealso cref="ENUM.Sparte" /></summary>
    [JsonProperty(Order = 11, PropertyName = "sparte")]
    [JsonPropertyName("sparte")]
    [ProtoMember(11)]
    [JsonPropertyOrder(11)]
    public Sparte Sparte { get; set; }

    /// <summary>Liste an Geräten.</summary>
    [JsonProperty(PropertyName = "geraete", Order = 12)]
    [JsonPropertyName("geraete")]
    [ProtoMember(12)]
    [JsonPropertyOrder(12)]
    public List<Geraet>? Geraete { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    [Newtonsoft.Json.JsonIgnore]
    [ProtoMember(13, Name = nameof(Wechseldatum))]
    [CompatibilityLevel(CompatibilityLevel.Level240)]
    private DateTime _Wechseldatum
    {
        get => Wechseldatum?.UtcDateTime ?? DateTime.MinValue;
        set => Wechseldatum = DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }

    /// <summary>
    ///     Gibt an, wann der Wechsel (voraussichtlich) stattfinden wird.
    /// </summary>
    [JsonProperty(Required = Required.Default, Order = 13, PropertyName = "wechseldatum")]
    [JsonPropertyName("wechseldatum")]
    [JsonPropertyOrder(13)]
    [ProtoIgnore]
    [Newtonsoft.Json.JsonConverter(typeof(LenientDateTimeConverter))]
    public DateTimeOffset? Wechseldatum { get; set; }

    /// <summary>Vollständiger Wechsel (ja/nein), defaults to ja</summary>
    [JsonProperty(Required = Required.Default, Order = 14, PropertyName = "vollstaendig")]
    [JsonPropertyName("vollstaendig")]
    [ProtoMember(14)]
    [JsonPropertyOrder(14)]
    public bool? Vollstaendig { get; set; }
}
