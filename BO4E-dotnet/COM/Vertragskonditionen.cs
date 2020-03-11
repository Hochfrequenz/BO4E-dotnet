using BO4E.ENUM;
using BO4E.meta;
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
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(3)]
        public string beschreibung;

        /// <summary>Anzahl der vereinbarten Abschläge pro Jahr, z.B. 12</summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(4)]
        public int? anzahlAbschlaege; //ToDo: bo4e.de models this as decimal which is wrong imho

        /// <summary>Über diesen Zeitraum läuft der Vertrag. Details <see cref="Zeitraum" /></summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(5)]
        public Zeitraum vertragslaufzeit;

        /// <summary>Innerhalb dieser Frist kann der Vertrag gekündigt werden. Details <see cref="Zeitraum" /></summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(6)]
        public Zeitraum kuendigungsfrist;

        /// <summary>Falls der Vertrag nicht gekündigt wird, verlängert er sich automatisch um die hier angegebene Zeit. Details <see cref="Zeitraum" /></summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(7)]
        public Zeitraum vertragsverlaengerung;

        /// <summary>In diesen Zyklen werden Abschläge gestellt. Details <see cref="Zeitraum" />. Alternativ kann auch die Anzahl in den Konditionen angeben werden."</summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(8)]
        public Zeitraum abschlagszyklus;

        // ToDo: Docstring!
        [JsonProperty(Required = Required.Default)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(9)]
        public DateTime? startAbrechnungsjahr;

        // ToDo: Docstring! why is this a zeitraum and no DateTime??
        [JsonProperty(Required = Required.Default)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(10)]
        public Zeitraum geplanteTurnusablesung;

        // ToDo: Docstring! what is the unit? days? why don't you use zeitraum?
        [JsonProperty(Required = Required.Default)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(11)]
        public int? turnusablesungIntervall;

        // ToDo: Docstring!
        [JsonProperty(Required = Required.Default)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(12)]
        public Zeitraum netznutzungsabrechnung;

        // ToDo: Docstring! what is the unit? days? why dont you use zeitraum?
        [JsonProperty(Required = Required.Default)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(13)]
        public int? netznutzungsabrechnungIntervall;

        // ToDo: Docstring!
        [JsonProperty(Required = Required.Default)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(14)]
        public bool? haushaltskunde;

        // ToDo: Docstring!
        [JsonProperty(Required = Required.Default)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(15)]
        public NetznutzungsVertrag? netznutzungsvertrag;

        // ToDo: Docstring!
        [JsonProperty(Required = Required.Default)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(16)]
        public Netznutzungszahler? netznutzungszahler;

        // ToDo: Docstring!
        [JsonProperty(Required = Required.Default)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(17)]
        public Netznutzungsabrechnungsvariante? netznutzungsabrechnungsvariante;

        // ToDo: Docstring!
        [JsonProperty(Required = Required.Default)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(18)]
        public Netznutzungsabrechnungsgrundlage? netznutzungsabrechnungsgrundlage;
    }
}