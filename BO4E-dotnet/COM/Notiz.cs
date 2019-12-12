using System;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace BO4E.COM
{
    /// <summary>
    /// Eine Notiz enthält beliebige, unstrukturierte Zusatzinformationen
    /// </summary>
    /// <author>Hochfrequenz Unternehmensberatung GmbH</author>
    public class Notiz : COM
    {
        /// <summary>
        /// Person oder System, das die Notiz angelegt hat.
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = -1)]
        public string autor;

        /// <summary>
        /// Zeitpunkt zu dem die Notiz angelegt wurde
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 0)]
        public DateTime zeitpunkt;

        /// <summary>
        /// Inhalt der Notiz (Freitext)
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 1)]
        public string inhalt;


        [JsonIgnore]
        private static Regex TrailingMinusRegex = new Regex(@"(?:\\n|\n)?-*$", RegexOptions.Compiled);

        /// <summary>
        /// method remove trailing minuses ('----') from notiz content. Those are artefact from SAPs internal note structure 
        /// </summary>
        /// <param name="context"></param>
        [OnDeserialized]
        public void CleanUpSapNotes(StreamingContext context)
        {
            this.inhalt = TrailingMinusRegex.Replace(inhalt, string.Empty);
        }
    }
}
