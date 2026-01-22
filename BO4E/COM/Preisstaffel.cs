#nullable enable
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM;

/// <summary>Gibt die Staffelgrenzen der jeweiligen Preise an.</summary>
[ProtoContract]
// [ProtoInclude(102, typeof(RegionalePreisstaffel))] // protobuf-net doesn't support multiple levels of inheritance yet
public class Preisstaffel : COM
{
    /// <summary>Preis pro abgerechneter Mengeneinheit</summary>
    [JsonProperty(PropertyName = "einheitspreis")]
    [JsonPropertyName("einheitspreis")]
    [ProtoMember(3)]
    public decimal Einheitspreis { get; set; }

    /// <summary>Unterer Wert, ab dem die Staffel gilt.</summary>
    [JsonProperty(PropertyName = "staffelgrenzeVon")]
    [JsonPropertyName("staffelgrenzeVon")]
    [ProtoMember(4)]
    public decimal StaffelgrenzeVon { get; set; }

    /// <summary>Oberer Wert, bis zu dem die Staffel gilt.</summary>
    [JsonProperty(PropertyName = "staffelgrenzeBis")]
    [JsonPropertyName("staffelgrenzeBis")]
    [ProtoMember(5)]
    public decimal StaffelgrenzeBis { get; set; }

    /// <summary>
    ///     Parameter zur Berechnung des Preises anhand der Jahresmenge und weiterer netzbezogener Parameter.
    ///     <seealso cref="BO4E.COM.Sigmoidparameter" />
    /// </summary>
    [JsonProperty(PropertyName = "sigmoidparameter")]
    [JsonPropertyName("sigmoidparameter")]
    [ProtoMember(6)]
    public Sigmoidparameter? Sigmoidparameter { get; set; }
}
