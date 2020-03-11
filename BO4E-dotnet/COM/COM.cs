using System;
using System.Collections.Generic;
using System.Reflection;
using BO4E.BO;
using BO4E.meta;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProtoBuf;

namespace BO4E.COM
{
    /// <summary>
    /// The COM class is the abstract class from which all BO4E.COM classes are derived.
    /// </summary>
    [ProtoContract]
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
    [ProtoInclude(24, typeof(Marktrolle))]
    [ProtoInclude(25, typeof(Menge))]
    [ProtoInclude(26, typeof(Messlokationszuordnung))]
    [ProtoInclude(27, typeof(Notiz))]
    [ProtoInclude(28, typeof(PhysikalischerWert))]
    [ProtoInclude(29, typeof(PositionsAufAbschlag))]
    [ProtoInclude(30, typeof(Preis))]
    [ProtoInclude(31, typeof(Preisgarantie))]
    [ProtoInclude(32, typeof(Preisposition))]
    [ProtoInclude(33, typeof(Rechnungsposition))]
    [ProtoInclude(34, typeof(RechnungspositionFlat))]
    [ProtoInclude(35, typeof(RegionaleGueltigkeit))]
    [ProtoInclude(36, typeof(RegionalePreisgarantie))]
    [ProtoInclude(37, typeof(RegionalePreisstaffel))]
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
    public abstract class COM : IEquatable<COM>
    {
        /// <summary>
        /// User properties (non bo4e standard)
        /// </summary>
        [JsonProperty(PropertyName = BusinessObject.userPropertiesName, Required = Required.Default, Order = 2)]
        [ProtoMember(2)]
        [JsonExtensionData]
        [DataCategory(DataCategory.USER_PROPERTIES)]
        public IDictionary<string, JToken> userProperties;

        /// <summary>
        /// BO4E components are considered equal iff all of their elements/fields are equal.
        /// </summary>
        /// <param name="b">another object</param>
        /// <returns><code>true</code> iff all elements of this COM and COM b are equal; <code>false</code> otherwise</returns>
        public override bool Equals(object b)
        {
            if (b == null || b.GetType() != this.GetType())
            {
                return false;
            }
            return this.Equals(b as COM);
        }

        /// <summary>
        /// BO4E components are considered equal iff all of their elements/fields are equal.
        /// </summary>
        /// <param name="b">another BO4E component</param>
        /// <returns><code>true</code> iff all elements of this COM and COM b are equal; <code>false</code> otherwise</returns>
        public bool Equals(COM b)
        {
            if (b == null || b.GetType() != this.GetType())
            {
                return false;
            }
            return JsonConvert.SerializeObject(this) == JsonConvert.SerializeObject(b);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int result = 31; // I read online that a medium sized prime was a good choice ;)
            unchecked
            {
                result *= this.GetType().GetHashCode();
                foreach (FieldInfo field in this.GetType().GetFields())
                {
                    if (field.GetValue(this) != null)
                    {
                        // Using +19 because the default hash code of uninitialised enums is zero.
                        // This would screw up the calculation such that all objects with at least one null value had the same hash code, namely 0.
                        result *= 19 + field.GetValue(this).GetHashCode();
                    }
                }
                return result;
            }
        }

        /// <inheritdoc cref="BO4E.BO.BusinessObject.IsValid"/>
        public bool IsValid()
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

        /// <summary>
        /// allows adding a GUID to COM objects for tracking across systems
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, Required = Required.Default, Order = 1)]
        [ProtoMember(1)]
        public string guid;
    }
}
