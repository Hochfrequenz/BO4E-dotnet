using System;
using BO4E.meta;
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
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(3)]
        public DateTime vertragsteilbeginn;

        /// <summary>
        /// Ende der Gültigkeit des Vertragsteils.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        [ProtoMember(4)]
        public DateTime vertragsteilende;

        /// <summary>
        /// Der Identifier für diejenigen Markt- oder Messlokation, die zu diesem Vertragsteil gehören.
        /// Verträge für mehrere Lokationen werden mit mehreren Vertragsteilen abgebildet.
        /// </summary>
        [ProtoMember(5)]
        [JsonProperty(Required = Required.Default)]
        public string lokation;

        /// <summary>
        /// Für die Lokation festgeschriebene Abnahmemenge. Siehe COM Menge
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(6)]
        public Menge vertraglichFixierteMenge;

        /// <summary>
        /// Für die Lokation festgelegte Mindestabnahmemenge. Siehe COM Menge
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(7)]
        public Menge minimaleAbnahmemenge;

        /// <summary>
        /// Für die Lokation festgelegte maximale Abnahmemenge. Siehe COM Menge
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        [ProtoMember(8)]
        public Menge maximaleAbnahmemenge;

        /// <summary>
        /// jahresverbrauchsprognose für EDIFACT mapping
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(9)]
        public Menge jahresverbrauchsprognose;

        /// <summary>
        /// kundenwert für EDIFACT mapping
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(10)]
        public Menge kundenwert;

        /// <summary>
        /// verbrauchsaufteilung für EDIFACT mapping
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(11)]
        public string verbrauchsaufteilung; // ToDo: evaluate if this actually should be an enum
    }
}
