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
        [JsonProperty(Required = Required.Always, Order = 4)]
        [ProtoMember(4)]
        public string zaehlernummer;

        /// <summary>Strom oder Gas. <seealso cref="Sparte" /></summary>
        [JsonProperty(Required = Required.Always, Order = 5)]
        [ProtoMember(5)]
        public Sparte sparte;

        /// <summary>Spezifikation die Richtung des Zählers betreffend.
        /// <seealso cref="Zaehlerauspraegung" /></summary>
        [JsonProperty(Required = Required.Always, Order = 6)]
        [ProtoMember(6)]
        public Zaehlerauspraegung zaehlerauspraegung;

        /// <summary>Typisierung des Zählers
        /// <seealso cref="Zaehlertyp" /></summary>
        [JsonProperty(Required = Required.Always, Order = 7)]
        [ProtoMember(7)]
        public Zaehlertyp zaehlertyp;

        /// <summary> Spezifikation bezüglich unterstützter Tarifarten.
        /// <seealso cref="Tarifart" /></summary>
        [JsonProperty(Required = Required.Always, Order = 8)]
        [ProtoMember(8)]
        public Tarifart tarifart;

        /// <summary>Zählerkonstante auf dem Zähler.</summary>
        [JsonProperty(Required = Required.Default, Order = 9)]
        [ProtoMember(9)]
        public Decimal zaehlerkonstante;

        /// <summary>Bis zu diesem Datum ist der Zähler geeicht.</summary>
        [JsonProperty(Required = Required.Default, Order = 10)]
        [ProtoMember(10)]
        public DateTime? eichungBis; // ToDO implement date

        /// <summary>Zu diesem Datum fand die letzte Eichprüfung des Zählers statt.</summary>
        [JsonProperty(Required = Required.Default, Order = 11)]
        [ProtoMember(11)]
        public DateTime? letzteEichung;

        /// <summary> Die Zählwerke des Zählers.
        /// <seealso cref="Zaehlwerk" /></summary>
        [JsonProperty(Required = Required.Always, Order = 12)]
        [MinLength(1)]
        [ProtoMember(12)]
        public List<Zaehlwerk> zaehlwerke;

        /// <summary>Der Hersteller des Zählers. Details <see cref="Geschaeftspartner" /></summary>
        [JsonProperty(Required = Required.Default, Order = 13, NullValueHandling =NullValueHandling.Ignore)]
        [ProtoMember(13)]
        public Geschaeftspartner zaehlerhersteller;

        /// <summary>
        /// Referenz auf das Smartmeter-Gateway
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 14)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1014)]
        public string gateway;

        /// <summary>
        /// Fernschaltung
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 15)]
        [ProtoMember(1015)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        public Fernschaltung? fernschaltung;

        /// <summary>
        /// Messwerterfassung am Zählpunkt
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 16)]
        [ProtoMember(1016)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        public Messwerterfassung? messwerterfassung;
    }
}
