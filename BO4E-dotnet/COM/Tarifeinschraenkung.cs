using System.Collections.Generic;
using BO4E.ENUM;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>Mit dieser Komponente werden Einschränkungen für die Anwendung von Tarifen modelliert.</summary>
    [ProtoContract]
    public class Tarifeinschraenkung : COM
    {
        /// <summary>Weitere Produkte, die gemeinsam mit diesem Tarif bestellt werden können.</summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(3)]
        public List<string> zusatzprodukte;

        /// <summary>Voraussetzungen, die erfüllt sein müssen, damit dieser Tarif zur Anwendung kommen kann. Details <see cref="Voraussetzungen" /></summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(4)]
        public List<Voraussetzungen> voraussetzungen;

        /// <summary>Liste der Zähler/Geräte, die erforderlich sind, damit dieser Tarif zur Anwendung gelangen kann.(Falls keine Zähler angegeben sind, ist der Tarif nicht an das Vorhandensein bestimmter Zähler gebunden.)Details <see cref="Geraet" /></summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(5)]
        public Geraet einschraenkungzaehler;

        /// <summary>Die vereinbarte Leistung, die (näherungsweise) abgenommen wird. Insbesondere Gastarife können daran gebunden sein, dass die Leistung einer vereinbarten Höhe entspricht.Details <see cref="Menge" /></summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(6)]
        public Menge einschraenkungleistung;
    }
}