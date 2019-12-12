using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using BO4E.COM;
using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BO4E.BO
{
    /// <summary>
    /// Modell für die Abbildung von Vertragsbeziehungen. Das Objekt dient dazu, alle Arten von Verträgen, die in der Energiewirtschaft Verwendung finden, abzubilden.
    /// https://www.bo4e.de/dokumentation/geschaeftsobjekte/bo-vertrag
    /// </summary>
    public class Vertrag : BusinessObject
    {
        /// <summary>
        /// Eine im Verwendungskontext eindeutige Nummer für den Vertrag
        /// </summary>
        [BoKey]
        [JsonProperty(Required = Required.Always)]
        public string vertragsnummer;

        /// <summary>
        /// Beschreibung zum Vertrag
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public string beschreibung;
        /// <summary>
        /// Hier ist festgelegt, um welche Art von Vertrag es sich handelt. Z.B. Netznutzungvertrag. Details siehe ENUM Vertragsart
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public Vertragsart vertragsart;

        /// <summary>
        /// Gibt den Status des Vertrags an. Siehe ENUM Vertragsstatus
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public Vertragstatus vertragstatus;

        /// <summary>
        /// Unterscheidungsmöglichkeiten für die Sparte. Siehe ENUM Sparte
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public Sparte sparte;

        /// <summary>
        /// Gibt an, wann der Vertrag beginnt.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public DateTime vertragsbeginn;

        /// <summary>
        /// Gibt an, wann der Vertrag (voraussichtlich) endet oder beendet wurde.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public DateTime vertragsende;

        /// <summary>
        /// Der "erstgenannte" Vertragspartner. In der Regel der Aussteller des Vertrags. Beispiel: "Vertrag zwischen Vertagspartner 1 ..." Siehe BO Geschaeftspartner
        /// </summary>
        [JsonProperty(Required = Required.Default)] // TODO: should be required but our CDS is missing the association
        public Geschaeftspartner vertragspartner1;

        /// <summary>
        /// Der "zweitgenannte" Vertragspartner. In der Regel der Empfänger des Vertrags. Beispiel "Vertrag zwischen Vertagspartner 1 und Vertragspartner 2". Siehe BO Geschaeftspartner
        /// </summary>
        [JsonProperty(Required = Required.Default)] // TODO: should be required but our CDS is missing the association
        public Geschaeftspartner vertragspartner2;

        /// <summary>
        /// Unterzeichner des Vertragspartners1. Siehe COM Unterschrift
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public List<Unterschrift> unterzeichnervp1;

        /// <summary>
        /// Unterzeichner des Vertragspartners2. Siehe COM Unterschrift
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public List<Unterschrift> unterzeichnervp2;

        /// <summary>
        /// Festlegungen zu Laufzeiten und Kündigungsfristen. Details siehe COM Vertragskonditionen
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public Vertragskonditionen vertragskonditionen;

        /// <summary>
        /// Der Vertragsteil wird dazu verwendet, eine vertragliche Leistung in Bezug zu einer Lokation (Markt- oder Messlokation) festzulegen. Details siehe COM Vertragsteil
        /// </summary>
        [JsonProperty(Required = Required.Default)] // TODO: should be required but our CDS is missing the association
        public List<Vertragsteil> vertragsteile;

        /// <summary>
        /// moves lokationsId from userProperties to vertragsteil if relevant
        /// </summary>
        /// <param name="context"></param>
        [OnDeserialized]
        protected void OnDeserialized(StreamingContext context)
        {
            if ((vertragsteile == null || vertragsteile.Count == 0) && userProperties.ContainsKey("lokationsId"))
            {
                vertragsteile = new List<Vertragsteil>()
                {
                    new Vertragsteil()
                    {
                        vertragsteilbeginn = this.vertragsbeginn,
                        vertragsteilende = this.vertragsende,
                        lokation = userProperties["lokationsId"].Value<string>()
                    }
                };
            }
        }
        public Vertrag()
        {

        }
    }
}
