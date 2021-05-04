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
        [JsonProperty(PropertyName = "aufgabenId", Required = Required.Always)]

        [System.Text.Json.Serialization.JsonPropertyName("aufgabenId")]
        [ProtoMember(3)]
        public string AufgabenId { get; set; }

        /// <summary>
        /// Optionale Beschreibung der Aufgabe
        /// </summary>
        [JsonProperty(PropertyName = "beschreibung", Required = Required.Default)]

        [System.Text.Json.Serialization.JsonPropertyName("beschreibung")]
        [ProtoMember(4)]
        public string Beschreibung { get; set; }

        /// <summary>
        /// Optionale Deadline bis zu der die Aufgabe ausführt werden kann oder ihre Ausführung 
        /// sinnvoll ist.
        /// </summary>
        [JsonProperty(PropertyName = "deadline", Required = Required.Default)]

        [System.Text.Json.Serialization.JsonPropertyName("deadline")]
        [ProtoMember(5)]
        public DateTimeOffset? Deadline { get; set; }

        /// <summary>
        /// Wurde diese Aufgabe schon ausgeführt (true)? Steht sie noch zur Bearbeitung an (false)?
        /// </summary>
        [JsonProperty(PropertyName = "ausgefuehrt", Required = Required.Always)]

        [System.Text.Json.Serialization.JsonPropertyName("ausgefuehrt")]
        [ProtoMember(6)]
        public bool Ausgefuehrt { get; set; }

        /// <summary>
        /// Zeitpunkt zu dem die Aufgabe ausgeführt wurde. (Nur sinnvoll, wenn <c>ausgefuehrt==true</c>)
        /// </summary>
        [JsonConverter(typeof(LenientDateTimeConverter))]
        [System.Text.Json.Serialization.JsonConverter(typeof(LenientSystemTextJsonNullableDateTimeOffsetConverter))]
        [JsonProperty(PropertyName = "ausfuehrungszeitpunkt", Required = Required.Default)]

        [System.Text.Json.Serialization.JsonPropertyName("ausfuehrungszeitpunkt")]
        [ProtoMember(7)]
        public DateTimeOffset? Ausfuehrungszeitpunkt { get; set; }

        /// <summary>
        /// Eindeutige Kennung des Benutzers, der diese Aufgabe ausführt hat.
        /// (Nur sinnvoll, wenn <c>ausgefuehrt==true</c>)
        /// </summary>
        [JsonProperty(PropertyName = "ausfuehrender", Required = Required.Default)]

        [System.Text.Json.Serialization.JsonPropertyName("ausfuehrender")]
        [ProtoMember(8)]
        public string Ausfuehrender { get; set; }
    }
}