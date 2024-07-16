using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM;

/// <summary>
/// Die Positionen eines Avis.
/// </summary>
[ProtoContract]
[NonOfficial(NonOfficialCategory.MISSING)]
public class Avisposition : COM
{
    /// <summary>
    /// Die Rechnungsnummer der Rechnung, auf die sich das Avis bezieht.
    /// </summary>
    [JsonProperty(PropertyName = "rechnungsNummer", Required = Required.Always, Order = 1)]
    [JsonPropertyName("rechnungsNummer")]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(1)]
    public string RechnungsNummer { get; set; }

    /// <summary>
    /// workaround
    /// </summary>
    [System.Text.Json.Serialization.JsonIgnore]
    [Newtonsoft.Json.JsonIgnore]
    [ProtoMember(2, Name = nameof(RechnungsDatum))]
    [CompatibilityLevel(CompatibilityLevel.Level240)]
    protected DateTime _RechnungsDatum
    {
        get => RechnungsDatum.UtcDateTime;
        set => RechnungsDatum = DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }
    /// <summary>
    /// Das Rechnungsdatum der Rechnung, auf die sich das Avis bezieht.
    /// </summary>
    [JsonProperty(PropertyName = "rechnungsDatum", Required = Required.Always, Order = 2)]
    [JsonPropertyName("rechnungsDatum")]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoIgnore]
    public DateTimeOffset RechnungsDatum { get; set; }

    /// <summary>
    /// Kennzeichnung, ob es sich bei der Rechnung auf die sich das Avis bezieht, um eine Stornorechnung handelt.
    /// </summary>
    [JsonProperty(PropertyName = "istStorno", Required = Required.Always, Order = 3)]
    [JsonPropertyName("istStorno")]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(3)]
    public bool IstStorno { get; set; }

    /// <summary>
    /// Kennzeichnung, ob es sich bei der Rechnung auf die sich das Avis bezieht, um eine Stornorechnung handelt.
    /// </summary>
    [JsonProperty(PropertyName = "istSelbstausgestellt", Required = Required.Default, Order = 4)]
    [JsonPropertyName("istSelbstausgestellt")]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(4)]
    public bool? IstSelbstausgestellt { get; set; }

    /// <summary>
    /// Überweisungsbetrag
    /// </summary>
    [JsonProperty(PropertyName = "gesamtBrutto", Required = Required.Always, Order = 5)]
    [JsonPropertyName("gesamtBrutto")]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(5)]
    public Betrag GesamtBrutto { get; set; }

    /// <summary>
    /// Geforderter Rechnungsbetrag
    /// </summary>
    [JsonProperty(PropertyName = "zuZahlen", Required = Required.Always, Order = 6)]
    [JsonPropertyName("zuZahlen")]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(6)]
    public Betrag ZuZahlen { get; set; }

    /// <summary>
    /// Referenzierung auf eine vorherige COMDIS-Nachricht
    /// </summary>
    [JsonProperty(PropertyName = "referenz", Required = Required.Default, Order = 7)]
    [JsonPropertyName("referenz")]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(1)]
    public string? Referenz { get; set; }

    /// <summary>
    /// Abweichungen bei Ablehnung einer COMDIS
    /// </summary>
    /// <see cref="Abweichungen" />
    [JsonProperty(PropertyName = "abweichungen", Required = Required.Default, Order = 8)]
    [JsonPropertyName("abweichungen")]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(7)]
    public List<Abweichung>? Abweichungen { get; set; }

    /// <summary>
    /// Rückmeldungspositionen
    /// </summary>
    [JsonProperty(PropertyName = "positionen", Required = Required.Default, Order = 9)]
    [JsonPropertyName("positionen")]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(8)]
    public List<Rueckmeldungsposition>? Positionen { get; set; }
}