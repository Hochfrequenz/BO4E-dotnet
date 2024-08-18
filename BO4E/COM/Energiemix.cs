#nullable enable
using System.Collections.Generic;
using System.Text.Json.Serialization;
using BO4E.ENUM;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM;

/// <summary>Zusammensetzung der gelieferten Energie aus den verschiedenen Primärenergieformen.</summary>
[ProtoContract]
public class Energiemix : COM
{
    /// <summary>Eindeutige Nummer zur Identifizierung des Energiemixes.</summary>
    [JsonProperty(PropertyName = "energiemixnummer", Required = Required.Default)]
    [JsonPropertyName("energiemixnummer")]
    [ProtoMember(3)]
    public int? Energiemixnummer { get; set; } // todo: probably should be a string

    /// <summary>Strom oder Gas etc.. Details <see cref="Sparte" /></summary>
    [JsonProperty(PropertyName = "energieart", Required = Required.Default)]
    [JsonPropertyName("energieart")]
    [ProtoMember(4)]
    public Sparte? Energieart { get; set; }

    /// <summary>Bezeichnung des Energiemix.</summary>
    [JsonProperty(PropertyName = "bezeichnung", Required = Required.Default)]
    [JsonPropertyName("bezeichnung")]
    [ProtoMember(5)]
    public string? Bezeichnung { get; set; }

    /// <summary>Bemerkung zum Energiemix.</summary>
    [JsonProperty(PropertyName = "bemerkung", Required = Required.Default)]
    [JsonPropertyName("bemerkung")]
    [ProtoMember(6)]
    public string? Bemerkung { get; set; }

    /// <summary>Jahr, für das der Energiemix gilt.</summary>
    [JsonProperty(PropertyName = "gueltigkeitsjahr", Required = Required.Default)]
    [JsonPropertyName("gueltigkeitsjahr")]
    [ProtoMember(7)]
    public int? Gueltigkeitsjahr { get; set; }

    /// <summary>Höhe des erzeugten CO2-Ausstosses in g/kWh.</summary>
    [JsonProperty(PropertyName = "cO2Emission", Required = Required.Default)]
    [JsonPropertyName("cO2Emission")]
    [ProtoMember(8)]
    public decimal? CO2Emission { get; set; }

    /// <summary>Höhe des erzeugten Atommülls in g/kWh.</summary>
    [JsonProperty(PropertyName = "atommuell", Required = Required.Default)]
    [JsonPropertyName("atommuell")]
    [ProtoMember(9)]
    public decimal? Atommuell { get; set; }

    /// <summary>Zertifikat für den Energiemix. Details <see cref="ENUM.Oekozertifikat" /></summary>
    [JsonProperty(PropertyName = "oekozertifikat", Required = Required.Default)]
    [JsonPropertyName("oekozertifikat")]
    [ProtoMember(10)]
    public List<Oekozertifikat>? Oekozertifikat { get; set; }

    /// <summary>Ökolabel für den Energiemix. Details <see cref="ENUM.Oekolabel" /></summary>
    [JsonProperty(PropertyName = "oekolabel", Required = Required.Default)]
    [JsonPropertyName("oekolabel")]
    [ProtoMember(11)]
    public List<Oekolabel>? Oekolabel { get; set; }

    /// <summary>Kennzeichen, ob der Versorger zu den Öko Top Ten gehört.</summary>
    [JsonProperty(PropertyName = "oekoTopTen", Required = Required.Default)]
    [JsonPropertyName("oekoTopTen")]
    [ProtoMember(12)]
    public bool? OekoTopTen { get; set; }

    /// <summary>Internetseite, auf der die Strommixdaten veröffentlicht sind.</summary>
    [JsonProperty(PropertyName = "website", Required = Required.Default)]
    [JsonPropertyName("website")]
    [ProtoMember(13)]
    public string? Website { get; set; }

    /// <summary>Anteile der jeweiligen Erzeugungsart. Details <see cref="Energieherkunft" /></summary>
    [JsonProperty(PropertyName = "anteil", Required = Required.Default)]
    [JsonPropertyName("anteil")]
    [ProtoMember(14)]
    public List<Energieherkunft>? Anteil { get; set; }
}
