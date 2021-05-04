using System;
using System.Collections.Generic;

using BO4E.ENUM;

using Newtonsoft.Json;

using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>Führt die verschiedenen Ausprägungen der Angebotsberechnung auf.</summary>
    [ProtoContract]
    public class Angebotsvariante : COM
    {
        /// <summary>Gibt den Status eines Angebotes an. <seealso cref="ENUM.Angebotsstatus" /></summary>
        [JsonProperty(PropertyName = "angebotsstatus", Required = Required.Always)]

        [System.Text.Json.Serialization.JsonPropertyName("angebotsstatus")]
        [ProtoMember(4)]
        public Angebotsstatus Angebotsstatus { get; set; }
        /// <summary>Umschreibung des Inhalts der Angebotsvariante.</summary>
        [JsonProperty(PropertyName = "beschreibung", Required = Required.Default)]

        [System.Text.Json.Serialization.JsonPropertyName("beschreibung")]
        [ProtoMember(5)]
        public string Beschreibung { get; set; }
        /// <summary>Datum der Erstellung der Angebotsvariante</summary>
        [JsonProperty(PropertyName = "erstelldatum", Required = Required.Default)]

        [System.Text.Json.Serialization.JsonPropertyName("erstelldatum")]
        [ProtoMember(6)]
        public DateTimeOffset Erstelldatum { get; set; }
        /// <summary>Bis zu diesem Zeitpunkt (Tag/Uhrzeit) inklusive gilt die Angebotsvariante, z.B. 31.12.2017, 17:00 Uhr.</summary>
        [JsonProperty(PropertyName = "bindefrist", Required = Required.Always)]

        [System.Text.Json.Serialization.JsonPropertyName("bindefrist")]
        [ProtoMember(7)]
        public DateTimeOffset Bindefrist { get; set; }
        /// <summary>Aufsummierte Wirkarbeitsmenge aller Angebotsteile. <seealso cref="Menge" /></summary>
        [JsonProperty(PropertyName = "gesamtmenge", Required = Required.Default)]

        [System.Text.Json.Serialization.JsonPropertyName("gesamtmenge")]
        [ProtoMember(8)]
        public Menge Gesamtmenge { get; set; }
        /// <summary>Aufsummierte Kosten aller Angebotsteile. <seealso cref="Betrag" /></summary>
        [JsonProperty(PropertyName = "gesamtkosten", Required = Required.Default)]

        [System.Text.Json.Serialization.JsonPropertyName("gesamtkosten")]
        [ProtoMember(9)]
        public Betrag Gesamtkosten { get; set; }
        /// <summary>Angebotsteile werden im einfachsten Fall für eine Marktlokation oder Lieferstellenadresse erzeugt. Hier werden die Mengen und Gesamtkosten aller Angebotspositionen zusammengefasst. Eine Variante besteht mindestens aus einem Angebotsteil. Details <see cref="Angebotsteil" /></summary>
        [JsonProperty(PropertyName = "teile", Required = Required.Always)]

        [System.Text.Json.Serialization.JsonPropertyName("teile")]
        [ProtoMember(10)]
        public List<Angebotsteil> Teile { get; set; }
    }
}