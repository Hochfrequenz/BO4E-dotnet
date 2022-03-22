using BO4E.COM;
using BO4E.ENUM;
using BO4E.meta;

using Newtonsoft.Json;

using ProtoBuf;
using System.Text.Json.Serialization;

namespace BO4E.BO
{
    /// <summary>
    /// Handelsunstimmigkeit BO
    /// </summary>
    [ProtoContract]
    [NonOfficial(NonOfficialCategory.MISSING)]
    public class Handelsunstimmigkeit : BusinessObject
    {

        /// <summary>
        /// Handelsunstimmigkeitsnummer
        /// </summary>
        [JsonProperty(PropertyName = "nummer", Required = Required.Always)]
        [JsonPropertyName("nummer")]
        [NonOfficial(NonOfficialCategory.MISSING)]
        [ProtoMember(1000)]
        [BoKey]
        public string Nummer { get; set; }

        /// <summary>
        /// Gibt den Typ der Handelsunstimmigkeit an.
        /// </summary>
        /// <see cref="Handelsunstimmigkeitstyp" />
        [JsonProperty(PropertyName = "typ", Required = Required.Always)]
        [JsonPropertyName("typ")]
        [ProtoMember(1001)]
        public Handelsunstimmigkeitstyp Typ { get; set; }

        /// <summary>
        /// Handelsunstimmigskeitsbegründung
        /// </summary>
        /// <see cref="Handelsunstimmigkeitsbegruendung" />
        [JsonProperty(PropertyName = "begruendung", Required = Required.Always)]
        [JsonPropertyName("begruendung")]
        [NonOfficial(NonOfficialCategory.MISSING)]
        [ProtoMember(1002)]
        public Handelsunstimmigkeitsbegruendung Begruendung { get; set; }

        /// <summary>
        /// angeforderter Betrag
        /// </summary>
        [JsonProperty(PropertyName = "zuZahlen", Required = Required.Default)]
        [JsonPropertyName("zuZahlen")]
        [NonOfficial(NonOfficialCategory.MISSING)]
        [ProtoMember(1003)]
        public Betrag? ZuZahlen { get; set; }

    }
}