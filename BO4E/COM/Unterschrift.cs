﻿using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>
    ///     Modellierung einer Unterschrift, z.B. für Verträge, Angebote etc.
    ///     https://www.bo4e.de/dokumentation/komponenten/com-unterschrift
    /// </summary>
    [ProtoContract]
    public class Unterschrift : COM
    {
        /// <summary>
        ///     Ort, an dem die Unterschrift geleistet wird
        /// </summary>
        [JsonProperty(PropertyName = "ort", Required = Required.Default)]
        [JsonPropertyName("ort")]
        [ProtoMember(3)]
        public string Ort { get; set; }

        /// <summary>
        ///     Datum der Unterschrift
        /// </summary>
        [JsonProperty(PropertyName = "datum", Required = Required.Default)]
        [JsonPropertyName("datum")]
        [ProtoMember(4)]
        public DateTimeOffset? Datum { get; set; }

        /// <summary>
        ///     Name des Unterschreibers
        /// </summary>
        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        [JsonPropertyName("name")]
        [ProtoMember(5)]
        public string Name { get; set; }
    }
}