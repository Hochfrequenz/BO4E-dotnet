using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.ConstrainedExecution;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using BO4E.COM;
using BO4E.EnergyIdentificationCodes;
using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.BO
{
    /// <summary>
    ///     Objekt zur Aufnahme der Informationen zu einer Tranche
    /// </summary>
    [ProtoContract]
    public class Tranche : BusinessObject
    {
        /// <summary>
        ///     Identifikationsnummer einer Tranche, an der Energie entweder
        ///     verbraucht, oder erzeugt wird (Like MarktlokationsId <see cref="Marktlokation"/>)
        /// </summary>
        [DefaultValue("|null|")]
        [JsonProperty(Required = Required.Always, Order = 10, PropertyName = "trancheId")]
        [JsonPropertyName("trancheId")]
        [JsonPropertyOrder(10)]
        [DataCategory(DataCategory.POD)]
        [BoKey]
        [ProtoMember(4)]
        public string TrancheId { get; set; }

        /// <summary>Sparte der Tranche, z.B. Gas oder Strom.</summary>
        [JsonProperty(Required = Required.Always, Order = 11, PropertyName = "sparte")]
        [JsonPropertyOrder(11)]
        [JsonPropertyName("sparte")]
        [ProtoMember(5)]
        public Sparte Sparte { get; set; }

        /// <summary>
        /// Prozentualer Anteil der Tranche an der erzeugenden Marktlokation in Prozent mit 2 Nachkommastellen
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 12, PropertyName = "aufteilungsmenge")]
        [JsonPropertyOrder(12)]
        [JsonPropertyName("aufteilungsmenge")]
        [ProtoMember(6)]
        public decimal? Aufteilungsmenge { get; set; }

        /// <summary>
        ///     Die OBIS-Kennzahl für die Tranche, die festlegt, welche auf die gemessene Größe mit dem Stand gemeldet wird.
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 13, PropertyName = "obisKennzahl")]
        [JsonPropertyOrder(13)]
        [JsonPropertyName("obisKennzahl")]
        [ProtoMember(7)]
        public string? ObisKennzahl { get; set; }

        /// <summary>
        ///     Zugeordnete Marktpartner
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 14, PropertyName = "marktrollen")]
        [JsonPropertyName("marktrollen")]
        [JsonPropertyOrder(14)]
        [ProtoMember(8)]
        public List<MarktpartnerDetails>? Marktrollen { get; set; }
    }
}
