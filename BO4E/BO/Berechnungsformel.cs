using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using BO4E.COM;
using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.BO
{
    /// <summary>
    /// Eine Berechnungsformel beschreibt, wie komplexe MaLo-MeLo-Konstrukte rechnerisch behandelt werden.
    /// </summary>
    /// <remarks>Berechnungsformeln werden in der Marktkommunikation mit Prüfidentifikator 25001 (UTILTS) übermittelt</remarks>
    public class Berechnungsformel : BusinessObject
    {
        // beziehung zur marktlokation wird über die links abgebildet
        // lieferrichtung is part of the marktlokations-bo
        // beziehung zur messlokation wird über die links abgebildet

        /// <summary>
        /// Der inklusive Zeitpunkt ab dem die Berechnungsformel gültig ist
        /// </summary>
        /// <returns></returns>
        [JsonProperty(Required = Required.Always, Order = 5, PropertyName = "beginndatum")]
        [JsonPropertyName("beginndatum")]
        [ProtoMember(5)]
        public DateTimeOffset Beginndatum { get; set; }

        /// <summary>
        /// beschreibt ob eine Berechnungsformel notwendig ist
        /// </summary>
        /// <remarks>UTILTS SG5 STS 4405</remarks>
        [JsonProperty(Required = Required.Always, Order = 6, PropertyName = "notwendigkeit")]
        [JsonPropertyName("notwendigkeit")]
        [ProtoMember(6)]
        public BerechnungsformelNotwendigkeit Notwendigkeit { get; set; }
        
        /// <summary>
        /// Eine Berechnungsformel enthält, falls sie notwendig ist <see cref="BerechnungsformelNotwendigkeit.BERECHNUNGSFORMEL_NOTWENDIG"/>,
        /// einen oder mehrere Berechnungschritte
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 4, PropertyName = "rechenschritte")]
        [JsonPropertyName("rechenschritte")]
        public List<Rechenschritt> Rechenschritte { get; set; }
    }
}
