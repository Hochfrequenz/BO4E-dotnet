using System;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>
    /// Modellierung einer Unterschrift, z.B. für Verträge, Angebote etc.
    /// https://www.bo4e.de/dokumentation/komponenten/com-unterschrift
    /// </summary>
    [ProtoContract]
    public class Unterschrift : COM
    {
        /// <summary>
        /// Ort, an dem die Unterschrift geleistet wird
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(3)]
        public string ort;

        /// <summary>
        /// Datum der Unterschrift
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(4)]
        public DateTime? datum;

        /// <summary>
        /// Name des Unterschreibers
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(5)]
        public string name;
    }
}
