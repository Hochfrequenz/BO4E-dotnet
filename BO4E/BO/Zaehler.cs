using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using BO4E.COM;
using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.BO
{
    /// <summary>
    ///     Mit diesem Geschäftsobjekt wird die Information zu einem Zähler abgebildet.
    /// </summary>
    [ProtoContract]
    public class Zaehler : BusinessObject
    {
        /// <summary>Nummerierung des Zählers, vergeben durch den Messstellenbetreiber</summary>
        [BoKey]
        [JsonProperty(Required = Required.Always, Order = 4, PropertyName = "zaehlernummer")]
        [JsonPropertyName("zaehlernummer")]
        [ProtoMember(4)]
        public string Zaehlernummer { get; set; }

        /// <summary>Strom oder Gas. <seealso cref="ENUM.Sparte" /></summary>
        [JsonProperty(Required = Required.Always, Order = 5, PropertyName = "sparte")]
        [JsonPropertyName("sparte")]
        [ProtoMember(5)]
        public Sparte Sparte { get; set; }

        /// <summary>
        ///     Spezifikation die Richtung des Zählers betreffend.
        ///     <seealso cref="ENUM.Zaehlerauspraegung" />
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 6, PropertyName = "zaehlerauspraegung")]
        [JsonPropertyName("zaehlerauspraegung")]
        [ProtoMember(6)]
        public Zaehlerauspraegung Zaehlerauspraegung { get; set; }

        /// <summary>
        ///     Typisierung des Zählers
        ///     <seealso cref="ENUM.Zaehlertyp" />
        /// </summary>
        [JsonProperty(
            Required = Required.AllowNull, //Required = Required.Always, 
            Order = 7, PropertyName = "zaehlertyp")]
        [ProtoMember(7)]
        [JsonPropertyName("zaehlertyp")]
        [NonOfficial(NonOfficialCategory
            .REGULATORY_REQUIREMENTS)] // this is ALWAYS required in BO4E standard; Maybe nullable if you as a LIEFERANT don't care about the type of Zähler, othern than in the grid
        public Zaehlertyp? Zaehlertyp { get; set; }

        /// <summary>
        ///     Spezifikation bezüglich unterstützter Tarifarten.
        ///     <seealso cref="ENUM.Tarifart" />
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 8, PropertyName = "tarifart")]
        [JsonPropertyName("tarifart")]
        [ProtoMember(8)]
        public Tarifart Tarifart { get; set; }

        /// <summary>Zählerkonstante auf dem Zähler.</summary>
        [JsonProperty(Required = Required.Default, Order = 9, PropertyName = "zaehlerkonstante")]
        [JsonPropertyName("zaehlerkonstante")]
        [ProtoMember(9)]
        public decimal Zaehlerkonstante { get; set; }



        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ProtoMember(10, Name = nameof(EichungBis))]
        [CompatibilityLevel(CompatibilityLevel.Level240)]
        private DateTime _EichungBis
        {
            get => EichungBis?.UtcDateTime ?? default;
            set => EichungBis = value == default ? null : DateTime.SpecifyKind(value, DateTimeKind.Utc);
        }
        /// <summary>Bis zu diesem Datum ist der Zähler geeicht.</summary>
        [JsonProperty(Required = Required.Default, Order = 10, PropertyName = "eichungBis")]
        [JsonPropertyName("eichungBis")]
        [ProtoIgnore]
        public DateTimeOffset? EichungBis { get; set; } // ToDO implement date



        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ProtoMember(11, Name = nameof(LetzteEichung))]
        [CompatibilityLevel(CompatibilityLevel.Level240)]
        private DateTime _LetzteEichung
        {
            get => LetzteEichung?.UtcDateTime ?? default; 
            set => LetzteEichung = value == default ? null : DateTime.SpecifyKind(value, DateTimeKind.Utc);
        }
        /// <summary>Zu diesem Datum fand die letzte Eichprüfung des Zählers statt.</summary>
        [JsonProperty(Required = Required.Default, Order = 11, PropertyName = "letzteEichung")]
        [JsonPropertyName("letzteEichung")]
        [ProtoIgnore]
        public DateTimeOffset? LetzteEichung { get; set; }

        /// <summary>
        ///     Die Zählwerke des Zählers.
        ///     <seealso cref="Zaehlwerk" />
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 12, PropertyName = "zaehlwerke")]
        [JsonPropertyName("zaehlwerke")]
        [MinLength(1)]
        [ProtoMember(12)]
        public List<Zaehlwerk> Zaehlwerke { get; set; }

        /// <summary>Der Hersteller des Zählers. Details <see cref="Geschaeftspartner" /></summary>
        [JsonProperty(Required = Required.Default, Order = 13, NullValueHandling = NullValueHandling.Ignore,
            PropertyName = "zaehlerhersteller")]
        [JsonPropertyName("zaehlerhersteller")]
        [ProtoMember(13)]
        public Geschaeftspartner Zaehlerhersteller { get; set; }

        /// <summary>
        ///     Referenz auf das Smartmeter-Gateway
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 14, PropertyName = "gateway")]
        [JsonPropertyName("gateway")]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1014)]
        public string Gateway { get; set; }

        /// <summary>
        ///     Fernschaltung
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 15, PropertyName = "fernschaltung")]
        [JsonPropertyName("fernschaltung")]
        [ProtoMember(1015)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        public Fernschaltung? Fernschaltung { get; set; }

        /// <summary>
        ///     Messwerterfassung am Zählpunkt
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 16, PropertyName = "messwerterfassung")]
        [JsonPropertyName("messwerterfassung")]
        [ProtoMember(1016)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        public Messwerterfassung? Messwerterfassung { get; set; }

        /// <summary>
        ///     Typisierung des Zählers (spezifikation für EHZ und MME)
        ///     <seealso cref="ENUM.ZaehlertypSpezifikation" />
        /// </summary>
        [JsonProperty(
            Required = Required.Default,
            PropertyName = "zaehlertypspezifikation", Order = 17)]
        [ProtoMember(1017)]
        [JsonPropertyName("zaehlertypspezifikation")]
        [NonOfficial(NonOfficialCategory.REGULATORY_REQUIREMENTS)]
        public ZaehlertypSpezifikation? Zaehlertypspezifikation { get; set; }


        /// <summary>
        ///     Befestigungsart
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 18, PropertyName = "befestigungsart")]
        [JsonPropertyName("befestigungsart")]
        [ProtoMember(1018)]
        [NonOfficial(NonOfficialCategory.REGULATORY_REQUIREMENTS)]
        public Befestigungsart? Befestigungsart { get; set; }
    }
}