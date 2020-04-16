using System;

using BO4E.meta;
using BO4E.meta.LenientConverters;
using Newtonsoft.Json;

using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>
    /// Abbildung für einen Vertragsteil. Der Vertragsteil wird dazu verwendet, eine vertragliche Leistung in Bezug zu einer Lokation (Markt- oder Messlokation) festzulegen.
    /// https://www.bo4e.de/dokumentation/komponenten/com-vertragsteil
    /// </summary>
    [ProtoContract]
    public class Vertragsteil : COM
    {
        /// <summary>
        /// Start der Gültigkeit des Vertragsteils.
        /// </summary>
        [JsonProperty(PropertyName = "vertragsteilbeginn", Required = Required.Always)]
        [ProtoMember(3)]
        [JsonConverter(typeof(LenientDateTimeConverter))]
        public DateTimeOffset Vertragsteilbeginn { get; set; }

        /// <summary>
        /// Ende der Gültigkeit des Vertragsteils.
        /// </summary>
        [JsonProperty(PropertyName = "vertragsteilende", Required = Required.Always)]
        [ProtoMember(4)]
        [JsonConverter(typeof(LenientDateTimeConverter))]
        public DateTimeOffset Vertragsteilende { get; set; }

        /// <summary>
        /// Der Identifier für diejenigen Markt- oder Messlokation, die zu diesem Vertragsteil gehören.
        /// Verträge für mehrere Lokationen werden mit mehreren Vertragsteilen abgebildet.
        /// </summary>
        [ProtoMember(5)]
        [JsonProperty(PropertyName = "lokation", Required = Required.Default)]
        public string Lokation { get; set; }

        /// <summary>
        /// Für die Lokation festgeschriebene Abnahmemenge. Siehe COM Menge
        /// </summary>
        [JsonProperty(PropertyName = "vertraglichFixierteMenge", Required = Required.Default)]
        [ProtoMember(6)]
        public Menge VertraglichFixierteMenge { get; set; }

        /// <summary>
        /// Für die Lokation festgelegte Mindestabnahmemenge. Siehe COM Menge
        /// </summary>
        [JsonProperty(PropertyName = "minimaleAbnahmemenge", Required = Required.Default)]
        [ProtoMember(7)]
        public Menge MinimaleAbnahmemenge { get; set; }

        /// <summary>
        /// Für die Lokation festgelegte maximale Abnahmemenge. Siehe COM Menge
        /// </summary>
        [JsonProperty(PropertyName = "maximaleAbnahmemenge", Required = Required.Default)]
        [ProtoMember(8)]
        public Menge MaximaleAbnahmemenge { get; set; }

        /// <summary>
        /// jahresverbrauchsprognose für EDIFACT mapping
        /// </summary>
        [JsonProperty(PropertyName = "jahresverbrauchsprognose", Required = Required.Default)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1009)]
        public Menge Jahresverbrauchsprognose { get; set; }

        /// <summary>
        /// kundenwert für EDIFACT mapping
        /// </summary>
        [JsonProperty(PropertyName = "kundenwert", Required = Required.Default)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1010)]
        public Menge Kundenwert { get; set; }

        /// <summary>
        /// verbrauchsaufteilung für EDIFACT mapping
        /// </summary>
        [JsonProperty(PropertyName = "verbrauchsaufteilung", Required = Required.Default)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1011)]
        public string Verbrauchsaufteilung { get; set; } // ToDo: evaluate if this actually should be an enum
    }
}
