using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BO4E.COM;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.BO
{
    /// <summary>
    /// Das allgemeine Modell zur Abbildung von Preisen. Davon abgeleitet können, über die Zuordnung identifizierender Merkmale, spezielle Preisblatt-Varianten modelliert werden.
    /// Die jeweiligen Sätze von Merkmalen sind in der Grafik ergänzt worden und stellen jeweils eine Ausprägung für die verschiedenen Anwendungsfälle der Preisblätter dar.
    /// </summary>
    [ProtoContract]
    // [ProtoInclude(30, typeof(PreisblattDienstleistung))] // protobuf-net doesn't support multiple levels of inheritance yet
    // [ProtoInclude(31, typeof(PreisblattKonzessionsabgabe))] // protobuf-net doesn't support multiple levels of inheritance yet
    // [ProtoInclude(32, typeof(PreisblattMessung))] // protobuf-net doesn't support multiple levels of inheritance yet
    // [ProtoInclude(33, typeof(PreisblattNetznutzung))] // protobuf-net doesn't support multiple levels of inheritance yet
    // [ProtoInclude(34, typeof(PreisblattUmlagen))] // protobuf-net doesn't support multiple levels of inheritance yet
    public class Preisblatt : BusinessObject
    {
        /// <summary>
        /// Eine Bezeichnung für das Preisblatt.
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 4)]
        [ProtoMember(4)]
        [DataCategory(DataCategory.FINANCE)]
        [BoKey]
        public string bezeichnung;

        /// <summary>
        /// Der Zeitraum für den der Preis festgelegt ist. Details siehe <see cref="Zeitraum"/>
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 5)]
        [ProtoMember(5)]
        [DataCategory(DataCategory.FINANCE)]
        public Zeitraum gueltigkeit;

        /// <summary>
        /// Die einzelnen Positionen, die mit dem Preisblatt abgerechnet werden können. Z.B. Arbeitspreis, Grundpreis etc. Details siehe <see cref="Preisposition"/>
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 6)] // at least one entry
        [DataCategory(DataCategory.FINANCE)]
        [ProtoMember(6)]
        public List<Preisposition> preispositionen;

        /*/// <summary>
        /// Staffelgrenzen der jeweiligen Preise. Details siehe <see cref="Preisstaffel"/>
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 6)] // at least 1 entry
        [DataCategory(DataCategory.FINANCE)]
        public List<Preisstaffel> preisstaffeln;*/
        // https://github.com/Hochfrequenz/energy-service-hub/issues/11
    }
}
