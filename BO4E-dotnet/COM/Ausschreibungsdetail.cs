using BO4E.ENUM;

using Newtonsoft.Json;

using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>Die Komponente Ausschreibungsdetail wird verwendet um die Informationen zu einer Abnahmestelle innerhalb eines Ausschreibungsloses abzubilden.</summary>
    [ProtoContract]
    public class Ausschreibungsdetail : COM
    {
        /// <summary>Identifikation einer ausgeschriebenen Marktlokation</summary>
        [JsonProperty(PropertyName = "lokationsId", Required = Required.Always)]
        [ProtoMember(3)]
        public string LokationsId { get; set; }
        /// <summary>Bezeichnung für die Lokation, z.B. Zentraler Einkauf, Hamburg</summary>
        [JsonProperty(PropertyName = "lokationsbezeichung", Required = Required.Default)]
        [ProtoMember(4)]
        public string Lokationsbezeichung { get; set; }
        /// <summary>In der angegebenen Netzebene wird die Marktlokation versorgt, z.B. MSP für Mittelspanung. Details <see cref="Netzebene" /></summary>
        [JsonProperty(PropertyName = "netzebeneLieferung", Required = Required.Always)]
        [ProtoMember(5)]
        public Netzebene NetzebeneLieferung { get; set; }
        /// <summary>In der angegebenen Netzebene wird die Lokation gemessen, z.B. NSP für Niederspanung. Details <see cref="Netzebene" /></summary>
        [JsonProperty(PropertyName = "netzebeneMessung", Required = Required.Always)]
        [ProtoMember(6)]
        public Netzebene NetzebeneMessung { get; set; }
        /// <summary>Bezeichnung des zuständigen Netzbetreibers, z.B. Stromnetz Hamburg GmbH.</summary>
        [JsonProperty(PropertyName = "netzbetreiber", Required = Required.Default)]
        [ProtoMember(7)]
        public string Netzbetreiber { get; set; }
        /// <summary>Bezeichnung des Kunden, der die Marktlokation nutzt.</summary>
        [JsonProperty(PropertyName = "kunde", Required = Required.Default)]
        [ProtoMember(8)]
        public string Kunde { get; set; }
        /// <summary>Die Bezeichnung des Zählers an der Marktlokation</summary>
        [JsonProperty(PropertyName = "zaehlernummer", Required = Required.Default)]
        [ProtoMember(9)]
        public string Zaehlernummer { get; set; }
        /// <summary>Spezifikation, um welche Zählertechnik es sich im vorliegenden Fall handelt, z.B. Leistungsmessung. Details <see cref="Zaehlertyp" /></summary>
        [JsonProperty(PropertyName = "zaehlertechnik", Required = Required.Default)]
        [ProtoMember(10)]
        public Zaehlertyp? Zaehlertechnik { get; set; }
        /// <summary>Zeigt an, ob es zu der Marktlokation einen Lastgang gibt. Falls ja, kann dieser abgerufen werden und daraus die Verbrauchswerte ermittelt werden.</summary>
        [JsonProperty(PropertyName = "lastgangVorhanden", Required = Required.Default)]
        [ProtoMember(11)]
        public bool? LastgangVorhanden { get; set; }
        /// <summary>Die Adresse an der die Marktlokation sich befindet. Struktur <seealso cref="Adresse" /></summary>
        [JsonProperty(PropertyName = "lokationsadresse", Required = Required.Always)]
        [ProtoMember(12)]
        public Adresse Lokationsadresse { get; set; }
        /// <summary>Die (evtl. abweichende) Rechnungsadresse. Struktur <seealso cref="Adresse" /></summary>
        [JsonProperty(PropertyName = "rechnungsadresse", Required = Required.Default)]
        [ProtoMember(13)]
        public Adresse Rechnungsadresse { get; set; }
        /// <summary>Prognosewert für die Jahresarbeit der ausgeschriebenen Lokation. Struktur <seealso cref="Menge" /></summary>
        [JsonProperty(PropertyName = "prognoseJahresarbeit", Required = Required.Default)]
        [ProtoMember(14)]
        public Menge PrognoseJahresarbeit { get; set; }
        /// <summary>Ein Prognosewert für die Arbeit innerhalb des angefragten Lieferzeitraums der ausgeschriebenen Lokation. Struktur <seealso cref="Menge" /></summary>
        [JsonProperty(PropertyName = "prognoseArbeitLieferzeitraum", Required = Required.Default)]
        [ProtoMember(15)]
        public Menge PrognoseArbeitLieferzeitraum { get; set; }
        /// <summary>Prognosewert für die abgenommene maximale Leistung der ausgeschriebenen Lokation. Struktur <seealso cref="Menge" /></summary>
        [JsonProperty(PropertyName = "prognoseLeistung", Required = Required.Default)]
        [ProtoMember(16)]
        public Menge PrognoseLeistung { get; set; }
        /// <summary>Angefragter Zeitraum für die ausgeschriebene Belieferung. <seealso cref="Zeitraum" /></summary>
        [JsonProperty(PropertyName = "lieferzeitraum", Required = Required.Default)]
        [ProtoMember(17)]
        public Zeitraum Lieferzeitraum { get; set; }
    }
}