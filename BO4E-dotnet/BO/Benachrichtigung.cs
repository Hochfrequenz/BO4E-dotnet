using System;
using System.Collections.Generic;
using System.ComponentModel;
using BO4E.COM;
using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.BO
{
    /// <summary>
    /// Eine Benachrichtigung ist die BO-Entsprechung eines "Klärfall"s im SAP oder eines "Task"s im Salesforce
    /// </summary>
    /// <author>Hochfrequenz Unternehmensberatung GmbH</author>
    public class Benachrichtigung : BusinessObject
    {
        /// <summary>
        /// Eine eindeutige ID der Benachrichtigung.
        /// Entspricht z.B. der Klärfallnummer in einem SAP-System oder der Task-ID im Salesforce
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 4)]
        [ProtoMember(4)]
        [BoKey]
        public string benachrichtigungsId;

        /// <summary>
        /// Priorität der Benachrichtigung
        /// </summary>
        [DefaultValue(Prioritaet.NORMAL)]
        [JsonProperty(Required = Required.Always, Order = 5)]
        [ProtoMember(5)]
        public Prioritaet prioritaet;

        /// <summary>
        /// Status der Benachrichtigung
        /// </summary>
        [DefaultValue(Bearbeitungsstatus.OFFEN)]
        [JsonProperty(Required = Required.Always, Order = 6)]
        [ProtoMember(5)]
        public Bearbeitungsstatus bearbeitungsstatus;

        /// <summary>
        /// Kurzbeschreibung des Fehlers (Klärfall-Überschrift im SAP, Subject im SFDC)
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 7)]
        [ProtoMember(7)]
        public string kurztext;

        //[JsonIgnore]
        //private DateTime _erstellungsZeitpunkt;
        /// <summary>
        /// Zeitpunkt zu dem die Benachrichtigung erstellt wurde (UTC).
        /// </summary>
        // [DefaultValue(DateTime.UtcNow)] <-- doesn't work.
        [JsonProperty(Required = Required.Always, Order = 8)]
        [ProtoMember(8)]
        public DateTime erstellungsZeitpunkt;
        /*{
            get { return _erstellungsZeitpunkt; }
            set
            {
                if (value == null)
                {
                    _erstellungsZeitpunkt = DateTime.UtcNow;
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
        [JsonProperty(Required = Required.Default, Order = 9)]
        [ProtoMember(9)]
        public string kategorie;

        /// <summary>
        /// Eindeutige Kennung des Benutzers, der die Benachrichtigung erhält oder sie bearbeiten
        /// muss; analog dem Klärfallbearbeiter im SAP oder dem Owner im Salesforce.
        /// Kann auch <c>null</c> sein, wenn es keinen festen Bearbeiter gibt.
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 10)]
        [ProtoMember(10)]
        public string bearbeiter;

        /// <summary>
        /// Detaillierte Beschreibung (Klärfall-Notizen im SAP, Description im SFDC)
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 11)]
        [ProtoMember(11)]
        public List<Notiz> notizen;

        /*
        /// <summary>
        /// Referenz auf ein Business Object, das die Benachrichtigung ausgelöst hat.
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 8)]
        [ProtoMember(8)]
        public Bo4eUri betroffenesObjekt;
        */


        /// <summary>
        /// Zeitpunkt bis zu dem die Benachrichtigung bearbeitet worden sein muss.
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 12)]
        [ProtoMember(12)]
        public DateTime? deadline;

        /// <summary>
        /// Liste von Aktivitäten, die der Bearbeiter ausführen kann.
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 13)]
        [ProtoMember(13)]
        public List<Aufgabe> aufgaben;

        /// <summary>
        /// list of additional information built in a customer dependet implementation
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 14)]
        [ProtoMember(14)]
        public List<GenericStringStringInfo> infos;
    }
}
