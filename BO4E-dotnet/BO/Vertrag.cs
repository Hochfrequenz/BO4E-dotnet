using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

using BO4E.COM;
using BO4E.ENUM;
using BO4E.meta;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using ProtoBuf;

namespace BO4E.BO
{
    /// <summary>
    /// Modell für die Abbildung von Vertragsbeziehungen. Das Objekt dient dazu, alle Arten von Verträgen, die in der Energiewirtschaft Verwendung finden, abzubilden.
    /// https://www.bo4e.de/dokumentation/geschaeftsobjekte/bo-vertrag
    /// </summary>
    [ProtoContract]
    public class Vertrag : BusinessObject
    {
        /// <summary>
        /// Eine im Verwendungskontext eindeutige Nummer für den Vertrag
        /// </summary>
        [BoKey]
        [JsonProperty(Required = Required.Always, Order = 4, PropertyName = "vertragsnummer")]
        [ProtoMember(4)]
        public string Vertragsnummer { get; set; }

        /// <summary>
        /// Beschreibung zum Vertrag
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 5, PropertyName = "beschreibung")]
        [ProtoMember(5)]
        public string Beschreibung { get; set; }
        /// <summary>
        /// Hier ist festgelegt, um welche Art von Vertrag es sich handelt. Z.B. Netznutzungvertrag. Details siehe ENUM Vertragsart
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 6, PropertyName = "vertragsart")]
        [ProtoMember(6)]
        public Vertragsart Vertragsart { get; set; }

        /// <summary>
        /// Gibt den Status des Vertrags an. Siehe ENUM Vertragsstatus
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 7, PropertyName = "vertragstatus")]
        [ProtoMember(7)]
        public Vertragstatus Vertragstatus { get; set; } // ToDo: shouldn't this be vertragsstatus with "ss"?

        /// <summary>
        /// Unterscheidungsmöglichkeiten für die Sparte. Siehe ENUM Sparte
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 8, PropertyName = "sparte")]
        [ProtoMember(8)]
        public Sparte Sparte { get; set; }

        /// <summary>
        /// Gibt an, wann der Vertrag beginnt.
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 9, PropertyName = "vertragsbeginn")]
        [ProtoMember(9)]
        public DateTime Vertragsbeginn { get; set; }

        /// <summary>
        /// Gibt an, wann der Vertrag (voraussichtlich) endet oder beendet wurde.
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 10, PropertyName = "vertragsende")]
        [ProtoMember(10)]
        public DateTime Vertragsende { get; set; }

        /// <summary>
        /// Der "erstgenannte" Vertragspartner. In der Regel der Aussteller des Vertrags. Beispiel: "Vertrag zwischen Vertagspartner 1 ..." Siehe BO Geschaeftspartner
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 11, PropertyName = "vertragspartner1")] // TODO: should be required but our CDS is missing the association
        [ProtoMember(11)]
        public Geschaeftspartner Vertragspartner1 { get; set; }

        /// <summary>
        /// Der "zweitgenannte" Vertragspartner. In der Regel der Empfänger des Vertrags. Beispiel "Vertrag zwischen Vertagspartner 1 und Vertragspartner 2". Siehe BO Geschaeftspartner
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 12, PropertyName = "vertragspartner2")] // TODO: should be required but our CDS is missing the association
        [ProtoMember(12)]
        public Geschaeftspartner Vertragspartner2 { get; set; }

        /// <summary>
        /// Unterzeichner des Vertragspartners1. Siehe COM Unterschrift
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 13, PropertyName = "unterzeichnervp1")]
        [ProtoMember(13)]
        public List<Unterschrift> Unterzeichnervp1 { get; set; }

        /// <summary>
        /// Unterzeichner des Vertragspartners2. Siehe COM Unterschrift
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 14, PropertyName = "unterzeichnervp2")]
        [ProtoMember(14)]
        public List<Unterschrift> Unterzeichnervp2 { get; set; }

        /// <summary>
        /// Festlegungen zu Laufzeiten und Kündigungsfristen. Details siehe COM Vertragskonditionen
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 15, PropertyName = "vertragskonditionen")]
        [ProtoMember(15)]
        public Vertragskonditionen Vertragskonditionen { get; set; }

        /// <summary>
        /// Der Vertragsteil wird dazu verwendet, eine vertragliche Leistung in Bezug zu einer Lokation (Markt- oder Messlokation) festzulegen. Details siehe COM Vertragsteil
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 16, PropertyName = "vertragsteile")] // TODO: should be required always but our CDS is missing the association
        [ProtoMember(16)]
        public List<Vertragsteil> Vertragsteile { get; set; }

        /// <summary>
        /// gemeinderabatt für EDIFACT mapping.
        /// </summary>
        // ToDo: What is the unit? is 1.0 = 100% discount?
        [JsonProperty(Required = Required.Default, Order = 17, PropertyName = "gemeinderabatt")]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1017)]
        public decimal? Gemeinderabatt { get; set; }

        /// <summary> 
        /// korrespondenzpartner für EDIFACT mapping
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 18, PropertyName = "korrespondenzpartner")]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1018)]
        // ToDO: isn't an Ansprechpartner the better choice than a Geschaeftspartner?
        public Geschaeftspartner Korrespondenzpartner { get; set; }


        /// <summary>
        /// moves lokationsId from userProperties to vertragsteil if relevant
        /// </summary>
        /// <param name="context"></param>
        [OnDeserialized]
        protected void OnDeserialized(StreamingContext context)
        {
            if ((Vertragsteile == null || Vertragsteile.Count == 0) && (UserProperties != null && UserProperties.ContainsKey("lokationsId")))
            {
                Vertragsteile = new List<Vertragsteil>()
                {
                    new Vertragsteil()
                    {
                        vertragsteilbeginn = this.Vertragsbeginn,
                        vertragsteilende = this.Vertragsende,
                        lokation = UserProperties["lokationsId"].Value<string>()
                    }
                };
            }
        }
        public Vertrag()
        {

        }
    }
}
