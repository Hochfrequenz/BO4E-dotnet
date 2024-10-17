using System.Collections.Generic;
using System.Text.Json.Serialization;
using BO4E.ENUM;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM;

/// <summary>
///     Mit dieser Komponente können Auf- und Abschläge verschiedener Typen im Zusammenhang mit regionalen
///     Gültigkeiten abgebildet werden.
/// </summary>
[ProtoContract]
public class RegionalerAufAbschlag : COM
{
    /// <summary>Bezeichnung des Auf-/Abschlags</summary>
    [JsonProperty(PropertyName = "bezeichnung")]
    [JsonPropertyName("bezeichnung")]
    [ProtoMember(3)]
    public string Bezeichnung { get; set; }

    /// <summary>Beschreibung zum Auf-/Abschlag</summary>
    [JsonProperty(PropertyName = "beschreibung")]
    [JsonPropertyName("beschreibung")]
    [ProtoMember(4)]
    public string? Beschreibung { get; set; }

    /// <summary>Typ des Aufabschlages (z.B. absolut oder prozentual). Details <see cref="ENUM.AufAbschlagstyp" /></summary>
    [JsonProperty(PropertyName = "aufAbschlagstyp")]
    [JsonPropertyName("aufAbschlagstyp")]
    [ProtoMember(5)]
    public AufAbschlagstyp? AufAbschlagstyp { get; set; }

    /// <summary>
    ///     Diesem Preis oder den Kosten ist der Auf/Abschlag zugeordnet. Z.B. Arbeitspreis, Gesamtpreis etc.. Details
    ///     <see cref="ENUM.AufAbschlagsziel" />
    /// </summary>
    [JsonProperty(PropertyName = "aufAbschlagsziel")]
    [JsonPropertyName("aufAbschlagsziel")]
    [ProtoMember(6)]
    public AufAbschlagsziel? AufAbschlagsziel { get; set; }

    /// <summary>
    ///     Gibt an in welcher Währungseinheit der Auf/Abschlag berechnet wird. Euro oder Ct.. (Nur im Falle absoluter
    ///     Aufschlagstypen). Details <see cref="Waehrungseinheit" />
    /// </summary>
    [JsonProperty(PropertyName = "einheit")]
    [JsonPropertyName("einheit")]
    [ProtoMember(7)]
    public Waehrungseinheit? Einheit { get; set; }

    /// <summary>Internetseite, auf der die Informationen zum Auf-/Abschlag veröffentlicht sind.</summary>
    [JsonProperty(PropertyName = "website")]
    [JsonPropertyName("website")]
    [ProtoMember(8)]
    public string? Website { get; set; }

    /// <summary>Zusatzprodukte, die nur in Kombination mit diesem AufAbschlag erhältlich sind.</summary>
    [JsonProperty(PropertyName = "zusatzprodukte")]
    [JsonPropertyName("zusatzprodukte")]
    [ProtoMember(9)]
    public List<string>? Zusatzprodukte { get; set; }

    /// <summary>Voraussetzungen, die erfüllt sein müssen, damit dieser AufAbschlag zur Anwendung kommen kann</summary>
    [JsonProperty(PropertyName = "voraussetzungen")]
    [JsonPropertyName("voraussetzungen")]
    [ProtoMember(10)]
    public List<string>? Voraussetzungen { get; set; }

    /// <summary>Zeitraum, in dem der Abschlag zur Anwendung kommen kann. Details <see cref="Zeitraum" /></summary>
    [JsonProperty(PropertyName = "gueltigkeitszeitraum")]
    [JsonPropertyName("gueltigkeitszeitraum")]
    [ProtoMember(11)]
    public Zeitraum? Gueltigkeitszeitraum { get; set; }

    /// <summary>Durch die Anwendung des Auf/Abschlags kann eine Änderung des Tarifnamens auftreten.</summary>
    [JsonProperty(PropertyName = "tarifnamensaenderungen")]
    [JsonPropertyName("tarifnamensaenderungen")]
    [ProtoMember(12)]
    public string? Tarifnamensaenderungen { get; set; }

    /// <summary>
    ///     Der Energiemix kann sich durch einen AufAbschlag ändern (z.B. zwei Cent Aufschlag für Ökostrom: Sollte dies
    ///     der Fall sein,wird hier die neue Zusammensetzung des Energiemix angegeben. Details <see cref="Energiemix" />
    /// </summary>
    [JsonProperty(PropertyName = "energiemixaenderung")]
    [JsonPropertyName("energiemixaenderung")]
    [ProtoMember(13)]
    public Energiemix? Energiemixaenderung { get; set; }

    /// <summary>
    ///     Änderungen in den Vertragskonditionen. Falls in dieser Komponenten angegeben, werden die Tarifparameter
    ///     hiermit überschrieben. Details <see cref="Vertragskonditionen" />
    /// </summary>
    [JsonProperty(PropertyName = "vertagskonditionsaenderung")]
    [JsonPropertyName("vertagskonditionsaenderung")]
    [ProtoMember(14)]
    public Vertragskonditionen? Vertagskonditionsaenderung { get; set; }

    /// <summary>
    ///     Änderungen in den Garantievereinbarungen. Falls in dieser Komponenten angegeben, werden die Tarifparameter
    ///     hiermit überschrieben. Details <see cref="Preisgarantie" />
    /// </summary>
    [JsonProperty(PropertyName = "garantieaenderung")]
    [JsonPropertyName("garantieaenderung")]
    [ProtoMember(15)]
    public Preisgarantie? Garantieaenderung { get; set; }

    /// <summary>
    ///     Änderungen in den Einschränkungen zum Tarif. Falls in dieser Komponenten angegeben, werden die Tarifparameter
    ///     hiermit überschrieben. Details <see cref="Tarifeinschraenkung" />
    /// </summary>
    [JsonProperty(PropertyName = "einschraenkungsaenderung")]
    [JsonPropertyName("einschraenkungsaenderung")]
    [ProtoMember(16)]
    public Tarifeinschraenkung? Einschraenkungsaenderung { get; set; }

    /// <summary>
    ///     Werte für die gestaffelten Auf/Abschläge mit regionaler Eingrenzung. Details
    ///     <see cref="RegionalePreisstaffel" />
    /// </summary>
    [JsonProperty(PropertyName = "staffeln")]
    [JsonPropertyName("staffeln")]
    [ProtoMember(17)]
    public List<RegionalePreisstaffel> Staffeln { get; set; }
}
