using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using BO4E.COM;
using BO4E.ENUM;
using BO4E.meta;

using Newtonsoft.Json;

using ProtoBuf;

namespace BO4E.BO
{
    /// <summary>
    /// Mit diesem Geschäftsobjekt wird die Information zu einem Zähler abgebildet.
    /// </summary>
    [ProtoContract]
    public class Zaehler : BusinessObject
    {
        /// <summary>Nummerierung des Zählers, vergeben durch den Messstellenbetreiber</summary>
        [BoKey]
        [JsonProperty(Required = Required.Always, Order = 4, PropertyName = "zaehlernummer")]
        [ProtoMember(4)]
        public string Zaehlernummer { get; set; }

        /// <summary>Strom oder Gas. <seealso cref="ENUM.Sparte" /></summary>
        [JsonProperty(Required = Required.Always, Order = 5, PropertyName = "sparte")]
        [ProtoMember(5)]
        public Sparte Sparte { get; set; }

        /// <summary>Spezifikation die Richtung des Zählers betreffend.
        /// <seealso cref="ENUM.Zaehlerauspraegung" /></summary>
        [JsonProperty(Required = Required.Always, Order = 6, PropertyName = "zaehlerauspraegung")]
        [ProtoMember(6)]
        public Zaehlerauspraegung Zaehlerauspraegung { get; set; }

        /// <summary>Typisierung des Zählers
        /// <seealso cref="ENUM.Zaehlertyp" /></summary>
        [JsonProperty(Required = Required.Always, Order = 7, PropertyName = "zaehlertyp")]
        [ProtoMember(7)]
        public Zaehlertyp Zaehlertyp { get; set; }

        /// <summary> Spezifikation bezüglich unterstützter Tarifarten.
        /// <seealso cref="ENUM.Tarifart" /></summary>
        [JsonProperty(Required = Required.Always, Order = 8, PropertyName = "tarifart")]
        [ProtoMember(8)]
        public Tarifart Tarifart { get; set; }

        /// <summary>Zählerkonstante auf dem Zähler.</summary>
        [JsonProperty(Required = Required.Default, Order = 9, PropertyName = "zaehlerkonstante")]
        [ProtoMember(9)]
        public Decimal zaehlerkonstante { get; set; }

        /// <summary>Bis zu diesem Datum ist der Zähler geeicht.</summary>
        [JsonProperty(Required = Required.Default, Order = 10, PropertyName = "eichungBis")]
        [ProtoMember(10)]
        public DateTime? EichungBis { get; set; } // ToDO implement date

        /// <summary>Zu diesem Datum fand die letzte Eichprüfung des Zählers statt.</summary>
        [JsonProperty(Required = Required.Default, Order = 11, PropertyName = "letzteEichung")]
        [ProtoMember(11)]
        public DateTime? LetzteEichung { get; set; }

        /// <summary> Die Zählwerke des Zählers.
        /// <seealso cref="Zaehlwerk" /></summary>
        [JsonProperty(Required = Required.Always, Order = 12, PropertyName = "zaehlwerke")]
        [MinLength(1)]
        [ProtoMember(12)]
        public List<Zaehlwerk> Zaehlwerke { get; set; }

        /// <summary>Der Hersteller des Zählers. Details <see cref="Geschaeftspartner" /></summary>
        [JsonProperty(Required = Required.Default, Order = 13, NullValueHandling = NullValueHandling.Ignore, PropertyName = "zaehlerhersteller")]
        [ProtoMember(13)]
        public Geschaeftspartner Zaehlerhersteller { get; set; }

        /// <summary>
        /// Referenz auf das Smartmeter-Gateway
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 14, PropertyName = "gateway")]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1014)]
        public string Gateway { get; set; }

        /// <summary>
        /// Fernschaltung
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 15, PropertyName = "fernschaltung")]
        [ProtoMember(1015)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        public Fernschaltung? Fernschaltung { get; set; }

        /// <summary>
        /// Messwerterfassung am Zählpunkt
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 16, PropertyName = "messwerterfassung")]
        [ProtoMember(1016)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        public Messwerterfassung? Messwerterfassung { get; set; }
    }
}
