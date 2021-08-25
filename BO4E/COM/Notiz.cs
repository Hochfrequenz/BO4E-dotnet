using System;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>
    ///     Eine Notiz enthält beliebige, unstrukturierte Zusatzinformationen
    /// </summary>
    /// <author>Hochfrequenz Unternehmensberatung GmbH</author>
    [ProtoContract]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    public class Notiz : COM
    {
        /// <summary>
        ///     method remove trailing minuses ('----') from notiz content. Those are artefact from SAPs internal note structure
        /// </summary>
        [Newtonsoft.Json.JsonIgnore]
        private static readonly Regex TrailingMinusRegex = new Regex(@"\r?(?:\\n|\n)?-*$", RegexOptions.Compiled);


        private string _inhalt;

        /// <summary>
        ///     Person oder System, das die Notiz angelegt hat.
        /// </summary>
        [JsonProperty(PropertyName = "autor", Required = Required.Always, Order = 7)]
        [JsonPropertyName("autor")]
        [ProtoMember(3)]
        public string Autor { get; set; }

        /// <summary>
        ///     Zeitpunkt zu dem die Notiz angelegt wurde
        /// </summary>
        [JsonProperty(PropertyName = "zeitpunkt", Required = Required.Always, Order = 8)]
        [JsonPropertyName("zeitpunkt")]
        [ProtoMember(4)]
        public DateTimeOffset Zeitpunkt { get; set; }

        /// <summary>
        ///     Inhalt der Notiz (Freitext)
        /// </summary>
        [JsonProperty(PropertyName = "inhalt", Required = Required.Always, Order = 5)]
        [JsonPropertyName("inhalt")]
        [ProtoMember(5)]
        public string Inhalt
        {
            get => _inhalt;
            set => _inhalt = TrailingMinusRegex.Replace(value, string.Empty);
        }
    }
}