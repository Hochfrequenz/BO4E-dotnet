using BO4E.BO;
using BO4E.meta;

using Newtonsoft.Json;

using ProtoBuf;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;

namespace BO4E.COM
{
    /// <summary>
    ///     The COM class is the abstract class from which all BO4E.COM classes are derived.
    /// </summary>
    //[ProtoContract] // If I add this line I get the following message: System.InvalidOperationException: Duplicate field-number detected; 1 on: BO4E.COM.COM
    [ProtoInclude(1, typeof(Adresse))]
    [ProtoInclude(2, typeof(Angebotsposition))]
    [ProtoInclude(3, typeof(Angebotsteil))]
    [ProtoInclude(4, typeof(Angebotsvariante))]
    [ProtoInclude(5, typeof(AufAbschlag))]
    [ProtoInclude(6, typeof(Aufgabe))]
    [ProtoInclude(7, typeof(Ausschreibungsdetail))]
    [ProtoInclude(8, typeof(Ausschreibungslos))]
    [ProtoInclude(9, typeof(Betrag))]
    [ProtoInclude(10, typeof(Dienstleistung))]
    [ProtoInclude(11, typeof(Energieherkunft))]
    [ProtoInclude(12, typeof(Energiemix))]
    [ProtoInclude(13, typeof(GenericStringStringInfo))]
    [ProtoInclude(14, typeof(Geokoordinaten))]
    [ProtoInclude(15, typeof(Geraet))]
    [ProtoInclude(16, typeof(Geraeteeigenschaften))]
    [ProtoInclude(17, typeof(Hardware))]
    [ProtoInclude(18, typeof(Katasteradresse))]
    [ProtoInclude(19, typeof(Konzessionsabgabe))]
    [ProtoInclude(20, typeof(Kostenblock))]
    [ProtoInclude(21, typeof(Kostenposition))]
    [ProtoInclude(22, typeof(KriteriumsWert))]
    [ProtoInclude(23, typeof(Kostenposition))]
#pragma warning disable CS0618 // Type or member is obsolete
    [ProtoInclude(24, typeof(MarktpartnerDetails))]
#pragma warning restore CS0618 // Type or member is obsolete
    [ProtoInclude(25, typeof(Menge))]
    [ProtoInclude(26, typeof(Messlokationszuordnung))]
    [ProtoInclude(27, typeof(Notiz))]
    [ProtoInclude(28, typeof(PhysikalischerWert))]
    [ProtoInclude(29, typeof(PositionsAufAbschlag))]
    [ProtoInclude(30, typeof(Preis))]
    //[ProtoInclude(31, typeof(Preisstaffel))]
    //[ProtoInclude(31, typeof(Preisgarantie))]
    [ProtoInclude(32, typeof(Preisposition))]
    [ProtoInclude(33, typeof(Rechnungsposition))]
    [ProtoInclude(34, typeof(RechnungspositionFlat))]
    [ProtoInclude(35, typeof(RegionaleGueltigkeit))]
    //[ProtoInclude(36, typeof(RegionalePreisgarantie))]
    //[ProtoInclude(37, typeof(RegionalePreisstaffel))]
    [ProtoInclude(38, typeof(RegionalerAufAbschlag))]
    [ProtoInclude(39, typeof(RegionaleTarifpreisposition))]
    [ProtoInclude(40, typeof(Regionskriterium))]
    [ProtoInclude(41, typeof(Rufnummer))]
    [ProtoInclude(42, typeof(Sigmoidparameter))]
    [ProtoInclude(43, typeof(Steuerbetrag))]
    [ProtoInclude(44, typeof(Tarifberechnungsparameter))]
    [ProtoInclude(45, typeof(Tarifeinschraenkung))]
    [ProtoInclude(46, typeof(Tarifpreisposition))]
    [ProtoInclude(47, typeof(Unterschrift))]
    [ProtoInclude(48, typeof(Verbrauch))]
    [ProtoInclude(49, typeof(Vertragskonditionen))]
    [ProtoInclude(50, typeof(Vertragsteil))]
    [ProtoInclude(51, typeof(Zaehlwerk))]
    [ProtoInclude(52, typeof(Zeitraum))]
    [ProtoInclude(53, typeof(Zustaendigkeit))]
    public abstract class COM : IUserProperties, IOptionalGuid
    {
        /// <inheritdoc cref="BO.BusinessObject.guidSerialized" />

        // note that this inheritance protobuf thing doesn't work as expected. please see the comments in TestBO4E project->TestProfobufSerialization
        [ProtoMember(1)]
#pragma warning disable IDE1006 // Naming Styles
        // ReSharper disable once InconsistentNaming
        protected string guidSerialized
#pragma warning restore IDE1006 // Naming Styles
        {
            get => Guid.HasValue ? Guid.ToString() : string.Empty;
            set { Guid = string.IsNullOrWhiteSpace(value) ? (Guid?)null : System.Guid.Parse(value); }
        }

        /// <summary>
        /// a protobuf serializable TimeStamp
        /// </summary>
        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        [ProtoMember(2, Name = nameof(Timestamp))]
        [CompatibilityLevel(CompatibilityLevel.Level240)]
        protected DateTime _TimeStamp
        {
            get => Timestamp?.DateTime ?? default;
            set => Timestamp = value == default ? null : new DateTimeOffset(value);
        }

        /// <summary>
        ///     Store the latest timestamp (update from the database)
        /// </summary>
        [JsonProperty(PropertyName = "timestamp", NullValueHandling = NullValueHandling.Ignore,
            Required = Required.Default, Order = 2)]
        [JsonPropertyName("timestamp")]
        [ProtoIgnore]
        public DateTimeOffset? Timestamp { get; set; }

        /// <summary>
        ///     BO4E components are considered equal iff all of their elements/fields are equal.
        /// </summary>
        /// <param name="b">another BO4E component</param>
        /// <returns><code>true</code> iff all elements of this COM and COM b are equal; <code>false</code> otherwise</returns>
        public bool Equals(COM b)
        {
            if (b == null || b.GetType() != GetType()) return false;
            return JsonConvert.SerializeObject(this) == JsonConvert.SerializeObject(b);
        }

        /// <summary>
        ///     allows adding a GUID to COM objects for tracking across systems
        /// </summary>
        [JsonProperty(PropertyName = "guid", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default,
            Order = 1)]
        [JsonPropertyName("guid")]
        public Guid? Guid { get; set; }

        /// <summary>
        ///     User properties (non bo4e standard)
        /// </summary>
        [JsonProperty(PropertyName = BusinessObject.USER_PROPERTIES_NAME, Required = Required.Default, Order = 2,
            DefaultValueHandling = DefaultValueHandling.Ignore)]
        [ProtoMember(2)]
        [Newtonsoft.Json.JsonExtensionData]
        [System.Text.Json.Serialization.JsonExtensionData]
        [DataCategory(DataCategory.USER_PROPERTIES)]
        public IDictionary<string, object> UserProperties { get; set; }

        /// <inheritdoc cref="BO4E.BO.BusinessObject.IsValid" />
        public virtual bool IsValid()
        {
            try
            {
                JsonConvert.SerializeObject(this);
            }
            catch (JsonSerializationException)
            {
                return false;
            }

            return true;
        }
    }
}
