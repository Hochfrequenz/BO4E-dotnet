using System;
using System.Collections.Generic;
using System.ComponentModel;
using BO4E.COM;
using BO4E.ENUM;
using BO4E.meta;
using BO4E.meta.LenientConverters;
using Newtonsoft.Json;

using ProtoBuf;

namespace BO4E.BO
{
    /// <summary>
    /// Eine Benachrichtigung ist die BO-Entsprechung eines "Klärfall"s im SAP oder eines "Task"s im Salesforce
    /// </summary>
    /// <author>Hochfrequenz Unternehmensberatung GmbH</author>
    [ProtoContract]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    public class Benachrichtigung : BusinessObject
    {
        /// <summary>
        /// Eine eindeutige ID der Benachrichtigung.
        /// Entspricht z.B. der Klärfallnummer in einem SAP-System oder der Task-ID im Salesforce
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 4, PropertyName = "benachrichtigungsId")]
        [ProtoMember(4)]
        [BoKey]
        public string BenachrichtigungsId { get; set; }

        /// <summary>
        /// Priorität der Benachrichtigung
        /// </summary>
        [DefaultValue(Prioritaet.NORMAL)]
        [JsonProperty(Required = Required.Always, Order = 5, PropertyName = "prioritaet")]
        [ProtoMember(5)]
        public Prioritaet Prioritaet { get; set; }

        /// <summary>
        /// Status der Benachrichtigung
        /// </summary>
        [DefaultValue(Bearbeitungsstatus.OFFEN)]
        [JsonProperty(Required = Required.Always, Order = 6, PropertyName = "bearbeitungsstatus")]
        [ProtoMember(6)]
        public Bearbeitungsstatus Bearbeitungsstatus { get; set; }

        /// <summary>
        /// Kurzbeschreibung des Fehlers (Klärfall-Überschrift im SAP, Subject im SFDC)
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 7, PropertyName = "kurztext")]
        [ProtoMember(7)]
        public string Kurztext { get; set; }

        //[JsonIgnore]
        //private DateTimeOffset _erstellungsZeitpunkt;
        /// <summary>
        /// Zeitpunkt zu dem die Benachrichtigung erstellt wurde (UTC).
        /// </summary>
        // [DefaultValue(DateTimeOffset.UtcNow)] <-- doesn't work.
        [JsonProperty(Required = Required.Always, Order = 8, PropertyName = "erstellungsZeitpunkt")]
        [ProtoMember(8, DataFormat = DataFormat.WellKnown)]
        [JsonConverter(typeof(LenientDateTimeConverter))]
        public DateTimeOffset ErstellungsZeitpunkt { get; set; }
        /*{
            get { return _erstellungsZeitpunkt; }
            set
            {
                if (value == null)
                {
                    _erstellungsZeitpunkt = DateTimeOffset.UtcNow;
                }
                else
                {
                    _erstellungsZeitpunkt = value;
                }
            }
        }*/

        /// <summary>
        /// Optionale Kategorisierung der Benachrichtigung. 
        /// (Entspricht z.B. der Klärfallkategorie in SAP)
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 9, PropertyName = "kategorie")]
        [ProtoMember(9)]
        public string Kategorie { get; set; }

        /// <summary>
        /// Eindeutige Kennung des Benutzers, der die Benachrichtigung erhält oder sie bearbeiten
        /// muss; analog dem Klärfallbearbeiter im SAP oder dem Owner im Salesforce.
        /// Kann auch <c>null</c> sein, wenn es keinen festen Bearbeiter gibt.
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 10, PropertyName = "bearbeiter")]
        [ProtoMember(10)]
        public string Bearbeiter { get; set; }

        /// <summary>
        /// Detaillierte Beschreibung (Klärfall-Notizen im SAP, Description im SFDC)
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 11, PropertyName = "notizen")]
        [ProtoMember(11)]
        public List<Notiz> Notizen { get; set; }

        /*
        /// <summary>
        /// Referenz auf ein Business Object, das die Benachrichtigung ausgelöst hat.
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 8)]
        [ProtoMember(8)]
        public Bo4eUri betroffenesObjekt { get;set; }
        */


        /// <summary>
        /// Zeitpunkt bis zu dem die Benachrichtigung bearbeitet worden sein muss.
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 12, PropertyName = "deadline")]
        [ProtoMember(12, DataFormat = DataFormat.WellKnown)]
        [JsonConverter(typeof(LenientDateTimeConverter))]
        public DateTimeOffset? Deadline { get; set; }

        /// <summary>
        /// Liste von Aktivitäten, die der Bearbeiter ausführen kann.
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 13, PropertyName = "aufgaben")]
        [ProtoMember(13)]
        public List<Aufgabe> Aufgaben { get; set; }

        /// <summary>
        /// list of additional information built in a customer dependet implementation
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 14, PropertyName = "infos")]
        [ProtoMember(14)]
        public List<GenericStringStringInfo> Infos { get; set; }
    }
}
