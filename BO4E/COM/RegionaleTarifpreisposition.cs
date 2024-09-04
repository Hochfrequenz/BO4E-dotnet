using System.Collections.Generic;
using System.Text.Json.Serialization;
using BO4E.ENUM;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM;

/// <summary>
///     Mit dieser Komponente können Tarifpreise verschiedener Typen im Zusammenhang mit regionalen Gültigkeiten
///     abgebildet werden.
/// </summary>
[ProtoContract]
public class RegionaleTarifpreisposition : COM
{
    /// <summary>Angabe des Preistyps (z.B. Grundpreis) Details <see cref="ENUM.Preistyp" /></summary>
    [JsonProperty(PropertyName = "preistyp", Required = Required.Always)]
    [JsonPropertyName("preistyp")]
    [ProtoMember(3)]
    public Preistyp Preistyp { get; set; }

    /// <summary>Einheit des Preises (z.B. EURO) Details <see cref="Waehrungseinheit" /></summary>
    [JsonProperty(PropertyName = "einheit", Required = Required.Always)]
    [JsonPropertyName("einheit")]
    [ProtoMember(4)]
    public string Einheit { get; set; }

    /// <summary>
    ///     Größe, auf die sich die Einheit bezieht, beispielsweise kWh, Jahr. Details <see cref="Mengeneinheit" />
    /// </summary>
    [JsonProperty(PropertyName = "bezugseinheit", Required = Required.Always)]
    [JsonPropertyName("bezugseinheit")]
    [ProtoMember(5)]
    public Mengeneinheit Bezugseinheit { get; set; }

    /// <summary>
    ///     Gibt an, nach welcher Menge die vorgenannte Einschränkung erfolgt (z.B. Jahresstromverbrauch in kWh).Details
    ///     <see cref="Mengeneinheit" />
    /// </summary>
    [JsonProperty(PropertyName = "mengeneinheitstaffel", Required = Required.Default)]
    [JsonPropertyName("mengeneinheitstaffel")]
    [ProtoMember(6)]
    public Mengeneinheit? Mengeneinheitstaffel { get; set; }

    /// <summary>
    ///     Hier sind die Staffeln mit ihren Preisangaben und regionalen Gültigkeiten definiert. Struktur
    ///     <seealso cref="RegionalePreisstaffel" />
    /// </summary>
    [JsonProperty(PropertyName = "preisstaffeln", Required = Required.Default)]
    [JsonPropertyName("preisstaffeln")]
    [ProtoMember(7)]
    public List<RegionalePreisstaffel>? Preisstaffeln { get; set; }
}