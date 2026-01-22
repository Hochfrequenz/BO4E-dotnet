#nullable enable
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using BO4E.ENUM;
using BO4E.meta;
using BO4E.meta.LenientConverters;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM;

/// <summary>
///     Mit dieser Komponente werden die Eigenschaften eines Gerätes in Bezug auf den Typ und weitere Merkmale
///     modelliert.
/// </summary>
[ProtoContract]
public class Geraeteeigenschaften : COM
{
    /// <summary>Der Typ eines Gerätes, beispielsweise Drehstromzähler. Details <see cref="ENUM.Geraetetyp" /></summary>
    [JsonProperty(PropertyName = "geraetetyp", Order = 10)]
    [JsonPropertyName("geraetetyp")]
    [ProtoMember(3)]
    [JsonPropertyOrder(10)]
    public Geraetetyp Geraetetyp { get; set; }

    /// <summary>
    ///     Weitere Merkmale des Geräts, zum Beispiel Mehrtarif, Eintarif etc.. Details <see cref="ENUM.Geraetemerkmal" />
    /// </summary>
    [JsonProperty(PropertyName = "geraetemerkmal", Order = 11)]
    [JsonPropertyName("geraetemerkmal")]
    [ProtoMember(4)]
    [JsonPropertyOrder(11)]
    [Newtonsoft.Json.JsonConverter(typeof(LenientGeraetemerkmalGasConverter))]
    [System.Text.Json.Serialization.JsonConverter(
        typeof(LenientSystemTextNullableGeraetemerkmalGasConverter)
    )]
    public Geraetemerkmal? Geraetemerkmal { get; set; }

    /// <summary>
    ///     Für nicht feste Fields, bsw: 'faktor'
    /// </summary>
    [JsonProperty(Order = 12)]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    [ProtoMember(1005)]
    [JsonPropertyOrder(12)]
    [Obsolete("Use the COM.UserProperties instead", true)]
    private Dictionary<string, string>? Parameter { get; set; } // ToDo: add docstring
}
