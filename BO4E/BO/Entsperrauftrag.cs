using System.Text.Json.Serialization;
using BO4E.ENUM;
using Newtonsoft.Json;

namespace BO4E.BO;

/// <summary>
/// Der Entsperrauftrag ist sehr ähnlich aufgebaut wie der <see cref="Sperrauftrag"/>.
/// </summary>
/// <remarks>Er wird typischerweise mit einer EDIFACT-Nachricht des Typs 17117 kommuniziert.</remarks>
public class Entsperrauftrag : Auftrag
{
    /// <summary>
    /// <inheritdoc cref="Sperrauftrag.Sperrauftragsart"/>
    /// </summary>
    [JsonProperty("sperrauftragsart", Required = Required.Always)]
    [JsonPropertyName("sperrauftragsart")]
    public Sperrauftragsart Sperrauftragsart => Sperrauftragsart.ENTSPERREN;

    /// <summary>
    /// <see cref="ENUM.Auftragsstatus"/>
    /// </summary>
    [JsonProperty("sperrauftragsstatus", Required = Required.Default)]
    [JsonPropertyName("sperrauftragsstatus")]
    public Auftragsstatus? Sperrauftragsstatus { get; set; }

    /// <summary>
    /// Die Nummer des zu sperrenden Zählers
    /// </summary>
    [JsonProperty("zaehlernummer", Required = Required.Default)]
    [JsonPropertyName("zaehlernummer")]
    public string? Zaehlernummer { get; set; }

    /// <summary>
    /// Ist true, falls die Entsperrung innerhalb der Arbeitszeit zu erfolgen hat.
    /// </summary>
    /// <remarks>Falls true ist in EDIFACT Z53 zu verwenden, falls false dann Z54</remarks>
    [JsonProperty("istNurInnerhalbDerArbeitszeitZuEntsperren", Required = Required.Always)]
    [JsonPropertyName("istNurInnerhalbDerArbeitszeitZuEntsperren")]
    public bool IstNurInnerhalbDerArbeitszeitZuEntsperren { get; set; }
}
