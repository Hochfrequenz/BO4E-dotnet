﻿using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;
using System.Text.Json.Serialization;

namespace BO4E.COM
{
    /// <summary>
    /// Lastprofil
    /// </summary>
    public class Lastprofil : COM
    {
        /// <summary>
        /// Bezeichnung des Profils, durch DVGW bzw. den Netzbetreiber vergeben (z.B. H0)
        /// </summary>
        [JsonProperty(PropertyName = "bezeichnung", Required = Required.Default)]
        [JsonPropertyName("bezeichnung")]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1001)]
        public string Bezeichnung { get; set; }

        /// <summary>
        /// Verfahren des Profils (analytisch oder synthetisch)
        /// </summary>
        [JsonProperty(PropertyName = "verfahren", Required = Required.Default)]
        [JsonPropertyName("verfahren")]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1002)]
        public Profilverfahren? Verfahren { get; set; }

        /// <summary>
        /// true, falls es sich um ein Einspeiseprofil handelt 
        /// </summary>
        [JsonProperty(PropertyName = "einspeisung", Required = Required.Default)]
        [JsonPropertyName("einspeisung")]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1003)]
        public bool? Einspeisung { get; set; }


        /// <summary>
        /// Klimazone / Temperaturmessstelle
        /// </summary>
        [JsonProperty(PropertyName = "tagesparameter", Required = Required.Default)]
        [JsonPropertyName("tagesparameter")]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1004)]
        public Tagesparameter Tagesparameter { get; set; }
    }
}