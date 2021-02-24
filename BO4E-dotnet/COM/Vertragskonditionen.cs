using BO4E.ENUM;
using BO4E.meta;
using BO4E.meta.LenientConverters;

using Newtonsoft.Json;

using ProtoBuf;

using System;

namespace BO4E.COM

{
    /// <summary>Abbildung für Vertragskonditionen. Die Komponente wird sowohl im Vertrag als auch im Tarif verwendet.</summary>
    [ProtoContract]
    public class Vertragskonditionen : COM
    {
        /// <summary>Freitext zur Beschreibung der Konditionen, z.B. "Standardkonditionen Gas"</summary>
        [JsonProperty(PropertyName = "beschreibung", Required = Required.Default)]

        [System.Text.Json.Serialization.JsonPropertyName("beschreibung")]
        [ProtoMember(3)]
        public string Beschreibung { get; set; }

        /// <summary>Anzahl der vereinbarten Abschläge pro Jahr, z.B. 12</summary>
        [JsonProperty(PropertyName = "anzahlAbschlaege", Required = Required.Default)]

        [System.Text.Json.Serialization.JsonPropertyName("anzahlAbschlaege")]
        [ProtoMember(4)]
        public int? AnzahlAbschlaege { get; set; } //ToDo: bo4e.de models this as decimal which is wrong imho

        /// <summary>Über diesen Zeitraum läuft der Vertrag. Details <see cref="Zeitraum" /></summary>
        [JsonProperty(PropertyName = "vertragslaufzeit", Required = Required.Default)]

        [System.Text.Json.Serialization.JsonPropertyName("vertragslaufzeit")]
        [ProtoMember(5)]
        public Zeitraum Vertragslaufzeit { get; set; }

        /// <summary>Innerhalb dieser Frist kann der Vertrag gekündigt werden. Details <see cref="Zeitraum" /></summary>
        [JsonProperty(PropertyName = "kuendigungsfrist", Required = Required.Default)]

        [System.Text.Json.Serialization.JsonPropertyName("kuendigungsfrist")]
        [ProtoMember(6)]
        public Zeitraum Kuendigungsfrist { get; set; }

        /// <summary>Falls der Vertrag nicht gekündigt wird, verlängert er sich automatisch um die hier angegebene Zeit. Details <see cref="Zeitraum" /></summary>
        [JsonProperty(PropertyName = "vertragsverlaengerung", Required = Required.Default)]

        [System.Text.Json.Serialization.JsonPropertyName("vertragsverlaengerung")]
        [ProtoMember(7)]
        public Zeitraum Vertragsverlaengerung { get; set; }

        /// <summary>In diesen Zyklen werden Abschläge gestellt. Details <see cref="Zeitraum" />. Alternativ kann auch die Anzahl in den Konditionen angeben werden."</summary>
        [JsonProperty(PropertyName = "abschlagszyklus", Required = Required.Default)]

        [System.Text.Json.Serialization.JsonPropertyName("abschlagszyklus")]
        [ProtoMember(8)]
        public Zeitraum Abschlagszyklus { get; set; }

        // ToDo: Docstring!
        [JsonProperty(PropertyName = "startAbrechnungsjahr", Required = Required.Default)]

        [System.Text.Json.Serialization.JsonPropertyName("startAbrechnungsjahr")]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1009)]
        [JsonConverter(typeof(LenientDateTimeConverter))]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        // todo @hamid: add a docstring
        public DateTimeOffset? StartAbrechnungsjahr { get; set; }

        // ToDo: Docstring! why is this a zeitraum and no DateTimeOffset??
        [JsonProperty(PropertyName = "geplanteTurnusablesung", Required = Required.Default)]

        [System.Text.Json.Serialization.JsonPropertyName("geplanteTurnusablesung")]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1010)]
        // todo @hamid: add a docstring
        public Zeitraum GeplanteTurnusablesung { get; set; }

        // ToDo: Docstring! what is the unit? days? why don't you use zeitraum?
        // todo @hamid: add a docstring
        [JsonProperty(PropertyName = "turnusablesungIntervall", Required = Required.Default)]

        [System.Text.Json.Serialization.JsonPropertyName("turnusablesungIntervall")]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1011)]
        public int? TurnusablesungIntervall { get; set; }

        // ToDo: Docstring!
        // todo @hamid: add a docstring
        [JsonProperty(PropertyName = "netznutzungsabrechnung", Required = Required.Default)]

        [System.Text.Json.Serialization.JsonPropertyName("netznutzungsabrechnung")]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1012)]
        public Zeitraum Netznutzungsabrechnung { get; set; }

        // ToDo: Docstring! what is the unit? days? why dont you use zeitraum?
        // todo @hamid: add a docstring
        [JsonProperty(PropertyName = "netznutzungsabrechnungIntervall", Required = Required.Default)]

        [System.Text.Json.Serialization.JsonPropertyName("netznutzungsabrechnungIntervall")]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1013)]
        public int? NetznutzungsabrechnungIntervall { get; set; }

        // ToDo: Docstring!
        // todo @hamid: add a docstring
        [JsonProperty(PropertyName = "haushaltskunde", Required = Required.Default)]

        [System.Text.Json.Serialization.JsonPropertyName("haushaltskunde")]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1014)]
        public bool? Haushaltskunde { get; set; }

        // ToDo: Docstring!
        // todo @hamid: add a docstring
        [JsonProperty(PropertyName = "netznutzungsvertrag", Required = Required.Default)]

        [System.Text.Json.Serialization.JsonPropertyName("netznutzungsvertrag")]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1015)]
        public NetznutzungsVertrag? Netznutzungsvertrag { get; set; }

        // ToDo: Docstring!
        // todo @hamid: add a docstring
        [JsonProperty(PropertyName = "netznutzungszahler", Required = Required.Default)]

        [System.Text.Json.Serialization.JsonPropertyName("netznutzungszahler")]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1016)]
        public Netznutzungszahler? Netznutzungszahler { get; set; }

        // ToDo: Docstring!
        // todo @hamid: add a docstring
        [JsonProperty(PropertyName = "netznutzungsabrechnungsvariante", Required = Required.Default)]

        [System.Text.Json.Serialization.JsonPropertyName("netznutzungsabrechnungsvariante")]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1017)]
        public Netznutzungsabrechnungsvariante? Netznutzungsabrechnungsvariante { get; set; }

        // ToDo: Docstring!
        // todo @hamid: add a docstring
        [JsonProperty(PropertyName = "netznutzungsabrechnungsgrundlage", Required = Required.Default)]

        [System.Text.Json.Serialization.JsonPropertyName("netznutzungsabrechnungsgrundlage")]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1018)]
        public Netznutzungsabrechnungsgrundlage? Netznutzungsabrechnungsgrundlage { get; set; }

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    }
}