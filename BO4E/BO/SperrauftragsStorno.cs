#nullable enable
using System;
using System.Text.Json.Serialization;
using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;

namespace BO4E.BO;

/// <summary>
/// Das Storno eines <see cref="Sperrauftrag"/>s oder <see cref="Entsperrauftrag"/>
/// </summary>
[NonOfficial(NonOfficialCategory.REGULATORY_REQUIREMENTS)]
[Obsolete(
    "This is not used in the implementation of the blocking process - we use the enum Auftragsstornogrund instead"
)]
public class SperrauftragsStorno : AuftragsStorno
{
    /// <summary>
    /// Handelt es sich beim zu stornierenden Auftrag um einen Auftrag zum <see cref="ENUM.Sperrauftragsart.SPERREN"/> oder <see cref="ENUM.Sperrauftragsart.ENTSPERREN"/>?
    /// </summary>
    [JsonProperty("originalSperrauftragsart")]
    [JsonPropertyName("originalSperrauftragsart")]
    public Sperrauftragsart OriginalSperrauftragsart => Sperrauftragsart.SPERREN;
}
