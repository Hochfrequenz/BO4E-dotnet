using System;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

using BO4E.meta;

using Newtonsoft.Json;

using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>
    /// Eine Notiz enthält beliebige, unstrukturierte Zusatzinformationen
    /// </summary>
    /// <author>Hochfrequenz Unternehmensberatung GmbH</author>
    [ProtoContract]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    public class Notiz : COM
    {
        /// <summary>
        /// Person oder System, das die Notiz angelegt hat.
        /// </summary>
        [JsonProperty(PropertyName = "autor", Required = Required.Always, Order = 7)]
        [ProtoMember(3)]
        public string Autor { get; set; }

        /// <summary>
        /// Zeitpunkt zu dem die Notiz angelegt wurde
        /// </summary>
        [JsonProperty(PropertyName = "zeitpunkt", Required = Required.Always, Order = 8)]
        [ProtoMember(4, DataFormat = DataFormat.WellKnown)]
        public DateTimeOffset Zeitpunkt { get; set; }

        /// <summary>
        /// Inhalt der Notiz (Freitext)
        /// </summary>
        [JsonProperty(PropertyName = "inhalt", Required = Required.Always, Order = 5)]
        [ProtoMember(5)]
        public string Inhalt { get; set; }


        [JsonIgnore]
        private static readonly Regex TrailingMinusRegex = new Regex(@"(?:\\n|\n)?-*$", RegexOptions.Compiled);

        /// <summary>
        /// method remove trailing minuses ('----') from notiz content. Those are artefact from SAPs internal note structure 
        /// </summary>
        /// <param name="context"></param>
        [OnDeserialized]
        public void CleanUpSapNotes(StreamingContext context)
        {
            Inhalt = TrailingMinusRegex.Replace(Inhalt, string.Empty);
        }
    }
}
