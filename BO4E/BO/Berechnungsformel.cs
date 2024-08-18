#nullable enable
using System;
using System.Text.Json.Serialization;
using BO4E.COM;
using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;
using Verwendungszweck = BO4E.COM.Verwendungszweck;

namespace BO4E.BO;

/// <summary>
/// Eine Berechnungsformel beschreibt, wie komplexe MaLo-MeLo-Konstrukte rechnerisch behandelt werden.
/// </summary>
/// <remarks>Berechnungsformeln werden in der Marktkommunikation mit Prüfidentifikator 25001 (UTILTS) übermittelt</remarks>
[ProtoContract]
public class Berechnungsformel : BusinessObject
{
    // The UTILTS "Lieferrichtung der Marktlokation" is contained in the marktlokations-bo
    // Also the relation between Berechnungsformel↔ Marktlokation is modelled as "link"

    [System.Text.Json.Serialization.JsonIgnore]
    [Newtonsoft.Json.JsonIgnore]
    [ProtoMember(6, Name = nameof(Beginndatum))]
    [CompatibilityLevel(CompatibilityLevel.Level240)]
    private DateTime _Beginndatum
    {
        get => Beginndatum.UtcDateTime;
        set => Beginndatum = DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }
    /// <summary>
    /// Der inklusive Zeitpunkt ab dem die Berechnungsformel gültig ist
    /// </summary>
    /// <remarks>UTILTS SG5 DTM+157</remarks>
    [JsonProperty(Required = Required.Always, Order = 5, PropertyName = "beginndatum")]
    [JsonPropertyName("beginndatum")]
    [ProtoIgnore]
    public DateTimeOffset Beginndatum { get; set; }

    /// <summary>
    /// Beschreibt ob eine Berechnungsformel notwendig ist
    /// </summary>
    /// <remarks>UTILTS SG5 STS 4405</remarks>
    [JsonProperty(Required = Required.Always, Order = 6, PropertyName = "notwendigkeit")]
    [JsonPropertyName("notwendigkeit")]
    [ProtoMember(6)]
    public BerechnungsformelNotwendigkeit Notwendigkeit { get; set; }

    /// <summary>
    /// ID des Rechenschritts [1 - 99999]
    /// </summary>
    /// <remarks>UTILTS SG8 SEQ Z37</remarks>
    [JsonProperty(Required = Required.Default, Order = 7, PropertyName = "rechenschrittId")]
    [JsonPropertyName("rechenschrittId")]
    [ProtoMember(7)]
    [BoKey]
    public int? RechenschrittId { get; set; }

    /// <summary>
    /// Verwendungszweck der Werte
    /// </summary>
    /// <remarks>UTILTS SG9 CAV 7111</remarks>
    [JsonProperty(Required = Required.Default, Order = 8, PropertyName = "verwendungszweck")]
    [JsonPropertyName("verwendungszweck")]
    public Verwendungszweck? Verwendungszweck { get; set; }

    /// <summary>
    /// Eine Berechnungsformel enthält, falls sie notwendig ist <see cref="BerechnungsformelNotwendigkeit.BERECHNUNGSFORMEL_NOTWENDIG"/>,
    /// einen oder mehrere Berechnungschritte, die hier rekursiv abgebildet werden.
    /// </summary>
    [JsonProperty(Required = Required.Default, Order = 9, PropertyName = "rechenschritt")]
    [JsonPropertyName("rechenschritt")]
    public Rechenschritt? Rechenschritt { get; set; }
}
