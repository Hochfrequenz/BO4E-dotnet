using System;

using BO4E.meta;
using BO4E.meta.LenientConverters;

using Newtonsoft.Json;

using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>
    /// Aufgabe als Teil einer <see cref="BO4E.BO.Benachrichtigung"/>.
    /// Aufgaben entsprechen den Klärfall-Lösungsmethoden im SAP.
    /// </summary>
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    [ProtoContract]
    public class Aufgabe : COM
    {
        /// <summary>
        /// Eindeutige Kennzeichnung der Aufgabe
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(3)]
        public string aufgabenId;

        /// <summary>
        /// Optionale Beschreibung der Aufgabe
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(4)]
        public string beschreibung;

        /// <summary>
        /// Optionale Deadline bis zu der die Aufgabe ausführt werden kann oder ihre Ausführung 
        /// sinnvoll ist.
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(5)]
        public DateTime? deadline;

        /// <summary>
        /// Wurde diese Aufgabe schon ausgeführt (true)? Steht sie noch zur Bearbeitung an (false)?
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(6)]
        public bool ausgefuehrt;

        /// <summary>
        /// Zeitpunkt zu dem die Aufgabe ausgeführt wurde. (Nur sinnvoll, wenn <c>ausgefuehrt==true</c>)
        /// </summary>
        [JsonConverter(typeof(LenientDateTimeConverter))]
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(7)]
        public DateTime? ausfuehrungszeitpunkt;

        /// <summary>
        /// Eindeutige Kennung des Benutzers, der diese Aufgabe ausführt hat.
        /// (Nur sinnvoll, wenn <c>ausgefuehrt==true</c>)
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(8)]
        public string ausfuehrender;
    }
}