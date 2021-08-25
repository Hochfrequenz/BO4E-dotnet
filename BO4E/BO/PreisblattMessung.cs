﻿using System.Collections.Generic;
using System.Text.Json.Serialization;
using BO4E.COM;
using BO4E.ENUM;
using Newtonsoft.Json;

namespace BO4E.BO
{
    /// <summary>
    ///     Die Variante des Preisblattmodells zur Abbildung der Preise für den Messstellenbetrieb und damit verbundene
    ///     Leistungen.
    /// </summary>
    //[ProtoContract]
    public class PreisblattMessung : Preisblatt
    {
        /// <summary>
        ///     Preisblatt gilt für die angegebene Sparte.
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 7, PropertyName = "sparte")]
        [JsonPropertyName("sparte")]
        //[ProtoMember(7)]
        public Sparte Sparte { get; set; }

        /// <summary>
        ///     Die Preise gelten für Marktlokationen der angegebenen Bilanzierungsmethode.
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 8, PropertyName = "bilanzierungsmethode")]
        [JsonPropertyName("bilanzierungsmethode")]
        //[ProtoMember(8)]
        public Bilanzierungsmethode Bilanzierungsmethode { get; set; }

        /// <summary>
        ///     Die Preise gelten für Messlokationen in der angegebenen Netzebene.
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 9, PropertyName = "messebene")]
        [JsonPropertyName("messebene")]
        //[ProtoMember(9)]
        public Netzebene Messebene { get; set; }

        /// <summary>
        ///     Im Preis sind die hier angegebenen Dienstleistungen enthalten. Z.B. Jährliche Ablesung.
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 10, PropertyName = "inklusiveDienstleistung")]
        [JsonPropertyName("inklusiveDienstleistung")]
        //[ProtoMember(10)]
        public List<Dienstleistungstyp> InklusiveDienstleistung { get; set; }

        /// <summary>
        ///     Der Preis betrifft das hier angegebene Geräte, z.B. einen Drehstromzähler.
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 11, PropertyName = "basisgeraet")]
        [JsonPropertyName("basisgeraet")]
        //[ProtoMember(11)]
        public Geraeteeigenschaften Basisgeraet { get; set; }

        /// <summary>
        ///     Im Preis sind die hier angegebenen Geräte mit enthalten, z.B. ein Wandler.
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 12, PropertyName = "inklusiveGeraete")]
        [JsonPropertyName("inklusiveGeraete")]
        //[ProtoMember(12)]
        public List<Geraeteeigenschaften> InklusiveGeraete { get; set; }

        /// <summary>
        ///     Der Netzbetreiber oder Messstellenbetreiber, der die Preise veröffentlicht hat.
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 13, PropertyName = "herausgeber")]
        [JsonPropertyName("herausgeber")]
        //[ProtoMember(13)]
        public Marktteilnehmer Herausgeber { get; set; }
    }
}