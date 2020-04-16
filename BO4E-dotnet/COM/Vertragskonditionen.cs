using System;

using BO4E.ENUM;
using BO4E.meta;
using BO4E.meta.LenientConverters;
using Newtonsoft.Json;

using ProtoBuf;

namespace BO4E.COM

{
    /// <summary>Abbildung für Vertragskonditionen. Die Komponente wird sowohl im Vertrag als auch im Tarif verwendet.</summary>
    [ProtoContract]
    public class Vertragskonditionen : COM
    {
        /// <summary>Freitext zur Beschreibung der Konditionen, z.B. "Standardkonditionen Gas"</summary>
        [JsonProperty(PropertyName = "beschreibung", Required = Required.Default)]
        [ProtoMember(3)]
        public string Beschreibung { get; set; }

        /// <summary>Anzahl der vereinbarten Abschläge pro Jahr, z.B. 12</summary>
        [JsonProperty(PropertyName = "anzahlAbschlaege", Required = Required.Default)]
        [ProtoMember(4)]
        public int? AnzahlAbschlaege { get; set; } //ToDo: bo4e.de models this as decimal which is wrong imho

        /// <summary>Über diesen Zeitraum läuft der Vertrag. Details <see cref="Zeitraum" /></summary>
        [JsonProperty(PropertyName = "vertragslaufzeit", Required = Required.Default)]
        [ProtoMember(5)]
        public Zeitraum Vertragslaufzeit { get; set; }

        /// <summary>Innerhalb dieser Frist kann der Vertrag gekündigt werden. Details <see cref="Zeitraum" /></summary>
        [JsonProperty(PropertyName = "kuendigungsfrist", Required = Required.Default)]
        [ProtoMember(6)]
        public Zeitraum Kuendigungsfrist { get; set; }

        /// <summary>Falls der Vertrag nicht gekündigt wird, verlängert er sich automatisch um die hier angegebene Zeit. Details <see cref="Zeitraum" /></summary>
        [JsonProperty(PropertyName = "vertragsverlaengerung", Required = Required.Default)]
        [ProtoMember(7)]
        public Zeitraum Vertragsverlaengerung { get; set; }

        /// <summary>In diesen Zyklen werden Abschläge gestellt. Details <see cref="Zeitraum" />. Alternativ kann auch die Anzahl in den Konditionen angeben werden."</summary>
        [JsonProperty(PropertyName = "abschlagszyklus", Required = Required.Default)]
        [ProtoMember(8)]
        public Zeitraum Abschlagszyklus { get; set; }

        // ToDo: Docstring!
        [JsonProperty(PropertyName = "startAbrechnungsjahr", Required = Required.Default)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1009)]
        [JsonConverter(typeof(LenientDateTimeConverter))]
        public DateTimeOffset? StartAbrechnungsjahr { get; set; }

        // ToDo: Docstring! why is this a zeitraum and no DateTimeOffset??
        [JsonProperty(PropertyName = "geplanteTurnusablesung", Required = Required.Default)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1010)]
        public Zeitraum GeplanteTurnusablesung { get; set; }

        // ToDo: Docstring! what is the unit? days? why don't you use zeitraum?
        [JsonProperty(PropertyName = "turnusablesungIntervall", Required = Required.Default)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1011)]
        public int? TurnusablesungIntervall { get; set; }

        // ToDo: Docstring!
        [JsonProperty(PropertyName = "netznutzungsabrechnung", Required = Required.Default)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1012)]
        public Zeitraum Netznutzungsabrechnung { get; set; }

        // ToDo: Docstring! what is the unit? days? why dont you use zeitraum?
        [JsonProperty(PropertyName = "netznutzungsabrechnungIntervall", Required = Required.Default)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1013)]
        public int? NetznutzungsabrechnungIntervall { get; set; }

        // ToDo: Docstring!
        [JsonProperty(PropertyName = "haushaltskunde", Required = Required.Default)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1014)]
        public bool? Haushaltskunde { get; set; }

        // ToDo: Docstring!
        [JsonProperty(PropertyName = "netznutzungsvertrag", Required = Required.Default)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1015)]
        public NetznutzungsVertrag? Netznutzungsvertrag { get; set; }

        // ToDo: Docstring!
        [JsonProperty(PropertyName = "netznutzungszahler", Required = Required.Default)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1016)]
        public Netznutzungszahler? Netznutzungszahler { get; set; }

        // ToDo: Docstring!
        [JsonProperty(PropertyName = "netznutzungsabrechnungsvariante", Required = Required.Default)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1017)]
        public Netznutzungsabrechnungsvariante? Netznutzungsabrechnungsvariante { get; set; }

        // ToDo: Docstring!
        [JsonProperty(PropertyName = "netznutzungsabrechnungsgrundlage", Required = Required.Default)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1018)]
        public Netznutzungsabrechnungsgrundlage? Netznutzungsabrechnungsgrundlage { get; set; }
    }
}