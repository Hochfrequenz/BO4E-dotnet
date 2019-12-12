using System;
using Newtonsoft.Json;
using static BO4E.BoMapper;

namespace BO4E.COM
{
    /// <summary>
    /// Aufgabe als Teil einer <see cref="BO4E.BO.Benachrichtigung"/>.
    /// Aufgaben entsprechen den Klärfall-Lösungsmethoden im SAP.
    /// </summary>
    public class Aufgabe : COM
    {
        /// <summary>
        /// Eindeutige Kennzeichnung der Aufgabe
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public string aufgabenId;

        /// <summary>
        /// Optionale Beschreibung der Aufgabe
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public string beschreibung;

        /// <summary>
        /// Optionale Deadline bis zu der die Aufgabe ausführt werden kann oder ihre Ausführung 
        /// sinnvoll ist.
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public DateTime? deadline;

        /// <summary>
        /// Wurde diese Aufgabe schon ausgeführt (true)? Steht sie noch zur Bearbeitung an (false)?
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public bool ausgefuehrt;

        /// <summary>
        /// Zeitpunkt zu dem die Aufgabe ausgeführt wurde. (Nur sinnvoll, wenn <c>ausgefuehrt==true</c>)
        /// </summary>
        [JsonConverter(typeof(LenientDateTimeConverter))]
        [JsonProperty(Required = Required.Default)]
        public DateTime? ausfuehrungszeitpunkt;

        /// <summary>
        /// Eindeutige Kennung des Benutzers, der diese Aufgabe ausführt hat.
        /// (Nur sinnvoll, wenn <c>ausgefuehrt==true</c>)
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public string ausfuehrender;
    }
}