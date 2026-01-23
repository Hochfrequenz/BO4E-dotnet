#nullable enable
using System.Collections.Generic;
using System.Text.Json.Serialization;
using BO4E.COM;
using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.BO;

/// <summary>
///     Dieses BO wird zur Übertagung von hierarchischen Kostenstrukturen verwendet. Die Kosten werden dabei in
///     Kostenblöcke und diese wiederum in Kostenpositionen strukturiert.
/// </summary>
[ProtoContract]
public class Kosten : BusinessObject
{
    /// <summary>
    ///     Klasse der Kosten, beispielsweise Fremdkosten. Details siehe <see cref="ENUM.Kostenklasse" />
    /// </summary>
    [JsonProperty(Order = 4, PropertyName = "kostenklasse")]
    [JsonPropertyName("kostenklasse")]
    [ProtoMember(4)]
    [DataCategory(DataCategory.FINANCE)]
    public Kostenklasse Kostenklasse { get; set; }

    /// <summary>
    ///     Für diesen Zeitraum wurden die Kosten ermittelt. Details siehe <see cref="Zeitraum" />
    /// </summary>
    [JsonProperty(Order = 5, PropertyName = "gueltigkeit")]
    [JsonPropertyName("gueltigkeit")]
    [ProtoMember(5)]
    [DataCategory(DataCategory.FINANCE)]
    public Zeitraum? Gueltigkeit { get; set; }

    /// <summary>
    ///     Die Gesamtsumme über alle Kostenblöcke und -positionen. Details siehe <see cref="Betrag" />
    /// </summary>
    [JsonProperty(Order = 6, PropertyName = "summeKosten")]
    [JsonPropertyName("summeKosten")]
    [ProtoMember(6)]
    [DataCategory(DataCategory.FINANCE)]
    public List<Betrag>? SummeKosten { get; set; }

    /// <summary>
    ///     Eine Liste mit Kostenblöcken. In Kostenblöcken werden Kostenpositionen zusammengefasst. Beispiele: Netzkosten,
    ///     Umlagen, Steuern etc. Details siehe <see cref="Kostenblock" />
    /// </summary>
    [JsonProperty(Order = 7, PropertyName = "kostenbloecke")] // at least 1 entry
    [JsonPropertyName("kostenbloecke")]
    [ProtoMember(7)]
    public List<Kostenblock>? Kostenbloecke { get; set; }

    /// <summary>
    ///     Hier sind die Details zu einer Kostenposition aufgeführt. Z.B.:
    ///     Alliander Netz Heinsberg GmbH, 01.02.2018, 31.12.2018, Arbeitspreis HT, 3.660 kWh, 5,8200 ct/kWh, 213,01 €. Details
    ///     siehe COM Kostenposition
    /// </summary>
    [JsonProperty(Order = 8, PropertyName = "kostenpositionen")]
    [JsonPropertyName("kostenpositionen")]
    [ProtoMember(8)]
    [DataCategory(DataCategory.FINANCE)]
    public List<Kostenposition>? Kostenpositionen { get; set; }
}
