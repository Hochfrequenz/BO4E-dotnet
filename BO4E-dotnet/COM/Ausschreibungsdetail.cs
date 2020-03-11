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
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(3)]
        public string lokationsId;
        /// <summary>Bezeichnung für die Lokation, z.B. Zentraler Einkauf, Hamburg</summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(4)]
        public string lokationsbezeichung;
        /// <summary>In der angegebenen Netzebene wird die Marktlokation versorgt, z.B. MSP für Mittelspanung. Details <see cref="Netzebene" /></summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(5)]
        public Netzebene netzebeneLieferung;
        /// <summary>In der angegebenen Netzebene wird die Lokation gemessen, z.B. NSP für Niederspanung. Details <see cref="Netzebene" /></summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(6)]
        public Netzebene netzebeneMessung;
        /// <summary>Bezeichnung des zuständigen Netzbetreibers, z.B. Stromnetz Hamburg GmbH.</summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(7)]
        public string netzbetreiber;
        /// <summary>Bezeichnung des Kunden, der die Marktlokation nutzt.</summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(8)]
        public string kunde;
        /// <summary>Die Bezeichnung des Zählers an der Marktlokation</summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(9)]
        public string zaehlernummer;
        /// <summary>Spezifikation, um welche Zählertechnik es sich im vorliegenden Fall handelt, z.B. Leistungsmessung. Details <see cref="Zaehlertyp" /></summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(10)]
        public Zaehlertyp? zaehlertechnik;
        /// <summary>Zeigt an, ob es zu der Marktlokation einen Lastgang gibt. Falls ja, kann dieser abgerufen werden und daraus die Verbrauchswerte ermittelt werden.</summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(11)]
        public bool? lastgangVorhanden;
        /// <summary>Die Adresse an der die Marktlokation sich befindet. Struktur <seealso cref="Adresse" /></summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(12)]
        public Adresse lokationsadresse;
        /// <summary>Die (evtl. abweichende) Rechnungsadresse. Struktur <seealso cref="Adresse" /></summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(13)]
        public Adresse rechnungsadresse;
        /// <summary>Prognosewert für die Jahresarbeit der ausgeschriebenen Lokation. Struktur <seealso cref="Menge" /></summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(14)]
        public Menge prognoseJahresarbeit;
        /// <summary>Ein Prognosewert für die Arbeit innerhalb des angefragten Lieferzeitraums der ausgeschriebenen Lokation. Struktur <seealso cref="Menge" /></summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(15)]
        public Menge prognoseArbeitLieferzeitraum;
        /// <summary>Prognosewert für die abgenommene maximale Leistung der ausgeschriebenen Lokation. Struktur <seealso cref="Menge" /></summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(16)]
        public Menge prognoseLeistung;
        /// <summary>Angefragter Zeitraum für die ausgeschriebene Belieferung. <seealso cref="Zeitraum" /></summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(17)]
        public Zeitraum lieferzeitraum;
    }
}