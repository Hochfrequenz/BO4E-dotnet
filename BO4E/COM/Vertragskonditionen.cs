using BO4E.ENUM;
using BO4E.meta;
using BO4E.meta.LenientConverters;

using Newtonsoft.Json;

using ProtoBuf;

using System;
using System.Text.Json.Serialization;

namespace BO4E.COM;

/// <summary>Abbildung für Vertragskonditionen. Die Komponente wird sowohl im Vertrag als auch im Tarif verwendet.</summary>
[ProtoContract]
public class Vertragskonditionen : COM
{
    /// <summary>Freitext zur Beschreibung der Konditionen, z.B. "Standardkonditionen Gas"</summary>
    [JsonProperty(PropertyName = "beschreibung", Required = Required.Default, Order = 10)]
    [JsonPropertyName("beschreibung")]
    [JsonPropertyOrder(10)]
    [ProtoMember(3)]
    public string? Beschreibung { get; set; }

    /// <summary>Anzahl der vereinbarten Abschläge pro Jahr, z.B. 12</summary>
    [JsonProperty(PropertyName = "anzahlAbschlaege", Required = Required.Default, Order = 11)]
    [JsonPropertyName("anzahlAbschlaege")]
    [JsonPropertyOrder(11)]
    [ProtoMember(4)]
    public int? AnzahlAbschlaege { get; set; } //ToDo: bo4e.de models this as decimal which is wrong imho

    /// <summary>Über diesen Zeitraum läuft der Vertrag. Details <see cref="Zeitraum" /></summary>
    [JsonProperty(PropertyName = "vertragslaufzeit", Required = Required.Default, Order = 12)]
    [JsonPropertyName("vertragslaufzeit")]
    [JsonPropertyOrder(12)]
    [ProtoMember(5)]
    public Zeitraum? Vertragslaufzeit { get; set; }

    /// <summary>Innerhalb dieser Frist kann der Vertrag gekündigt werden. Details <see cref="Zeitraum" /></summary>
    [JsonProperty(PropertyName = "kuendigungsfrist", Required = Required.Default, Order = 13)]
    [JsonPropertyName("kuendigungsfrist")]
    [JsonPropertyOrder(13)]
    [ProtoMember(6)]
    public Zeitraum? Kuendigungsfrist { get; set; }

    /// <summary>
    ///     Falls der Vertrag nicht gekündigt wird, verlängert er sich automatisch um die hier angegebene Zeit. Details
    ///     <see cref="Zeitraum" />
    /// </summary>
    [JsonProperty(PropertyName = "vertragsverlaengerung", Required = Required.Default, Order = 14)]
    [JsonPropertyName("vertragsverlaengerung")]
    [JsonPropertyOrder(14)]
    [ProtoMember(7)]
    public Zeitraum? Vertragsverlaengerung { get; set; }

    /// <summary>
    ///     In diesen Zyklen werden Abschläge gestellt. Details <see cref="Zeitraum" />. Alternativ kann auch die Anzahl
    ///     in den Konditionen angeben werden."
    /// </summary>
    [JsonProperty(PropertyName = "abschlagszyklus", Required = Required.Default, Order = 15)]
    [JsonPropertyName("abschlagszyklus")]
    [JsonPropertyOrder(15)]
    [ProtoMember(8)]
    public Zeitraum? Abschlagszyklus { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    [Newtonsoft.Json.JsonIgnore]
    [ProtoMember(1009, Name = nameof(StartAbrechnungsjahr))]
    [CompatibilityLevel(CompatibilityLevel.Level240)]
    private DateTime _StartAbrechnungsjahr
    {
        get => StartAbrechnungsjahr?.UtcDateTime ?? default;
        set => StartAbrechnungsjahr = value == default ? null : DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }
    // ToDo: Docstring!
    [JsonProperty(PropertyName = "startAbrechnungsjahr", Required = Required.Default, Order = 16)]
    [JsonPropertyName("startAbrechnungsjahr")]
    [JsonPropertyOrder(16)]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    [ProtoIgnore]
    [Newtonsoft.Json.JsonConverter(typeof(LenientDateTimeConverter))]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    // todo @hamid: add a docstring
    public DateTimeOffset? StartAbrechnungsjahr { get; set; }

    // ToDo: Docstring! why is this a zeitraum and no DateTimeOffset??
    [JsonProperty(PropertyName = "geplanteTurnusablesung", Required = Required.Default, Order = 17)]
    [JsonPropertyName("geplanteTurnusablesung")]
    [JsonPropertyOrder(17)]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    [ProtoMember(1010)]
    // todo @hamid: add a docstring
    public Zeitraum? GeplanteTurnusablesung { get; set; }

    // ToDo: Docstring! what is the unit? days? why don't you use zeitraum?
    // todo @hamid: add a docstring
    [JsonProperty(PropertyName = "turnusablesungIntervall", Required = Required.Default, Order = 18)]
    [JsonPropertyName("turnusablesungIntervall")]
    [JsonPropertyOrder(18)]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    [ProtoMember(1011)]
    public int? TurnusablesungIntervall { get; set; }

    // ToDo: Docstring!
    // todo @hamid: add a docstring
    [JsonProperty(PropertyName = "netznutzungsabrechnung", Required = Required.Default, Order = 19)]
    [JsonPropertyName("netznutzungsabrechnung")]
    [JsonPropertyOrder(19)]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    [ProtoMember(1012)]
    public Zeitraum? Netznutzungsabrechnung { get; set; }

    // ToDo: Docstring! what is the unit? days? why dont you use zeitraum?
    // todo @hamid: add a docstring
    [JsonProperty(PropertyName = "netznutzungsabrechnungIntervall", Required = Required.Default, Order = 20)]
    [JsonPropertyName("netznutzungsabrechnungIntervall")]
    [JsonPropertyOrder(20)]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    [ProtoMember(1013)]
    public int? NetznutzungsabrechnungIntervall { get; set; }

    // ToDo: Docstring!
    // todo @hamid: add a docstring
    [JsonProperty(PropertyName = "haushaltskunde", Required = Required.Default, Order = 21)]
    [JsonPropertyName("haushaltskunde")]
    [JsonPropertyOrder(21)]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    [ProtoMember(1014)]
    public bool? Haushaltskunde { get; set; }

    // ToDo: Docstring!
    // todo @hamid: add a docstring
    [JsonProperty(PropertyName = "netznutzungsvertrag", Required = Required.Default, Order = 22)]
    [JsonPropertyName("netznutzungsvertrag")]
    [JsonPropertyOrder(22)]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    [ProtoMember(1015)]
    public Netznutzungsvertragsart? Netznutzungsvertragsart { get; set; }


    // ToDo: Docstring!
    // todo @hamid: add a docstring
    [JsonProperty(PropertyName = "netznutzungszahler", Required = Required.Default, Order = 23)]
    [JsonPropertyName("netznutzungszahler")]
    [JsonPropertyOrder(23)]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    [ProtoMember(1016)]
    public Netznutzungszahler? Netznutzungszahler { get; set; }

    // ToDo: Docstring!
    // todo @hamid: add a docstring
    [JsonProperty(PropertyName = "netznutzungsabrechnungsvariante", Required = Required.Default, Order = 24)]
    [JsonPropertyName("netznutzungsabrechnungsvariante")]
    [JsonPropertyOrder(24)]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    [ProtoMember(1017)]
    public Netznutzungsabrechnungsvariante? Netznutzungsabrechnungsvariante { get; set; }

    // ToDo: Docstring!
    // todo @hamid: add a docstring
    [JsonProperty(PropertyName = "netznutzungsabrechnungsgrundlage", Required = Required.Default, Order = 25)]
    [JsonPropertyName("netznutzungsabrechnungsgrundlage")]
    [JsonPropertyOrder(25)]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    [ProtoMember(1018)]
    public Netznutzungsabrechnungsgrundlage? Netznutzungsabrechnungsgrundlage { get; set; }

    /// <summary>
    ///     Singulär genutzte Betriebsmittel in der Netznutzungsabrechnung
    ///     Hier wird angegeben, ob in der Netznutzungsabrechnung der verbrauchenden Marktlokation singulär 
    ///     genutzte Betriebsmittel abgerechnet werden.
    /// </summary>
    /// <remarks>für EDIFACT mapping</remarks>
    [JsonProperty(PropertyName = "beinhaltetSingulaerGenutzteBetriebsmittel", Required = Required.Default, Order = 26)]
    [JsonPropertyName("beinhaltetSingulaerGenutzteBetriebsmittel")]
    [JsonPropertyOrder(26)]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    [ProtoMember(1019)]
    public bool? BeinhaltetSingulaerGenutzteBetriebsmittel { get; set; }

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}