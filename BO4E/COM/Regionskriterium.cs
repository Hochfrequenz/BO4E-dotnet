#nullable enable
using System.Text.Json.Serialization;
using BO4E.ENUM;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM;

/// <summary>
///     Komponente zur Abbildung eines Regionskriteriums.
/// </summary>
[ProtoContract]
public class Regionskriterium : COM
{
    /// <summary>
    ///     Hier wird festgelegt, ob es sich um ein einschließendes oder ausschließendes Kriterium handelt.Details siehe
    ///     <see cref="ENUM.Gueltigkeitstyp" />
    /// </summary>
    [JsonProperty(PropertyName = "gueltigkeitstyp")]
    [JsonPropertyName("gueltigkeitstyp")]
    [ProtoMember(3)]
    public Gueltigkeitstyp Gueltigkeitstyp { get; set; }

    /// <summary>
    ///     Das Kriterium gilt in der angegebenen Sparte.Details siehe <see cref="ENUM.Sparte" />
    /// </summary>
    [JsonProperty(PropertyName = "sparte")]
    [JsonPropertyName("sparte")]
    [ProtoMember(4)]
    public Sparte? Sparte { get; set; }

    /// <summary>
    ///     Unterscheidung, wie der Wert angewendet werden soll, z.B.kleiner, größer, gleich.Details siehe
    ///     <see cref="ENUM.Mengenoperator" />
    /// </summary>
    [JsonProperty(PropertyName = "mengenoperator")]
    [JsonPropertyName("mengenoperator")]
    [ProtoMember(5)]
    public Mengenoperator Mengenoperator { get; set; }

    /// <summary>
    ///     Hier wird das Kriterium selbst angegeben, z.B.Bundesland. Details siehe <see cref="ENUM.Regionskriteriumtyp" />
    /// </summary>
    [JsonProperty(PropertyName = "regionskriteriumtyp")]
    [JsonPropertyName("regionskriteriumtyp")]
    [ProtoMember(6)]
    public Regionskriteriumtyp Regionskriteriumtyp { get; set; }

    /// <summary>
    ///     Der Wert, den das Kriterium annehmen kann, z.B.NRW.Im Falle des Regionskriteriumstyp BUNDESWEIT spielt dieser Wert
    ///     keine Rolle.
    /// </summary>
    [JsonProperty(PropertyName = "wert")]
    [JsonPropertyName("wert")]
    [ProtoMember(7)]
    public string? Wert { get; set; }
}
