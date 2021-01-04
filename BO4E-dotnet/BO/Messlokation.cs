using BO4E.COM;
using BO4E.ENUM;
using BO4E.meta;

using Newtonsoft.Json;

using ProtoBuf;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace BO4E.BO
{
    // The key order is actually relevant for the online validation. WTF!
    // https://github.com/Hochfrequenz/energy-service-hub/issues/11
    //@JsonPropertyOrder({ "versionStruktur", "boTyp", "messLokationsId", "sparte", "netzebeneMessung", "messgebietNr",
    //       "grundzustaendigerMSBCodeNr", "grundzustaendigerMSBIMCodeNr", "grundzustaendigerMDLodeNr", "messadresse",
    //        "geoadresse", "katasterinformation", "geraete", "messdienstleistung", "messlokationszaehler" })
    /// <summary>
    /// Objekt zur Aufnahme der Informationen zu einer Messlokation.
    /// </summary>
    [ProtoContract]
    public class Messlokation : BusinessObject
    {
        /// <summary>Die Messlokations-Identifikation. Das ist die frühere Zählpunktbezeichnung,
        /// z.B. DE 47108151234567</summary>
        [DefaultValue("|null|")]
        [JsonProperty(PropertyName = "messlokationsId", Required = Required.Always, Order = 4)]
        [DataCategory(DataCategory.POD)]
        [BoKey]
        [ProtoMember(4)]
        public string MesslokationsId { get; set; }

        /// <summary>* Sparte der Messlokation, z.B. Gas oder Strom.
        /// <seealso cref="ENUM.Sparte" /></summary>
        [JsonProperty(PropertyName = "sparte", Required = Required.Always, Order = 5)]
        [ProtoMember(5)]
        public Sparte Sparte { get; set; }

        ///<summary> Spannungsebene der Messung. <seealso cref="Netzebene" /></summary>
        [JsonProperty(PropertyName = "netzebeneMessung", Required = Required.Default, Order = 6)] //explicitly set NOT required.
        [ProtoMember(6)]
        public Netzebene? NetzebeneMessung { get; set; }

        /// <summary>Die Nummer des Messgebietes in der ene't-Datenbank.</summary>
        [JsonProperty(PropertyName = "messgebietNr", Required = Required.Default, Order = 7)]
        [ProtoMember(7)]
        public string MessgebietNr { get; set; }

        /// <summary>Codenummer des grundzuständigen Messstellenbetreibers, der für diese
        /// Messlokation zuständig ist.( Dieser ist immer dann Messstellenbetreiber, wenn
        /// kein anderer MSB die Einrichtungen an der Messlokation betreibt.)</summary>
        [JsonProperty(PropertyName = "grundzustaendigerMSBCodeNr", Required = Required.Default, Order = 8)]
        [ProtoMember(8)]
        public string GrundzustaendigerMsbCodeNr { get; set; }

        /// <summary>Codenummer des grundzuständigen Messstellenbetreibers für intelligente
        /// Messsysteme der für diese Messlokation zuständig ist.(Dieser ist immer dann
        /// Messstellenbetreiber, wenn kein anderer MSB die Einrichtungen an der
        /// Messlokation betreibt.)</summary>
        [JsonProperty(PropertyName = "grundzustaendigerMSBIMCodeNr", Required = Required.Default, Order = 9)]
        [ProtoMember(9)]
        public string GrundzustaendigerMsbimCodeNr { get; set; }// grundzustaendigerMSB_IMCodenr;  https://github.com/Hochfrequenz/energy-service-hub/issues/11

        /// <summary> Codenummer des Messdienstleisters, der für diese Messlokation zuständig
        /// ist.( Dieser ist immer dann Messdienstleister, wenn kein anderer MDL die
        /// Messlokation abliest.)
        /// </summary>
        [JsonProperty(PropertyName = "grundzustaendigerMDLCodeNr", Order = 10, Required = Required.Default)]
#pragma warning disable CS0618 // Type or member is obsolete
        [NonOfficial(NonOfficialCategory.PROPOSED_DELETION)]
#pragma warning restore CS0618 // Type or member is obsolete
        [ProtoMember(10)]
        [Obsolete("MDL is deprecated.", true)]
        public string GrundzustaendigerMdlCodeNr { get; set; }

        /// <summary>  Die Adresse, an der die Messeinrichtungen zu finden sind.( Nur angeben, wenn
        /// diese von der Adresse der Marktlokation abweicht.)
        /// Achtung: Es darf immer nur eine Art der Ortsangabe vorhanden sein (entweder
        /// eine Adresse oder eine GeoKoordinate oder eine Katasteradresse.
        ///</summary>
        [JsonProperty(PropertyName = "messadresse", Required = Required.Default, Order = 11)]
        [DataCategory(DataCategory.ADDRESS)]
        [ProtoMember(11)]
        public Adresse Messadresse { get; set; }

        /// <summary> Alternativ zu einer postalischen Adresse kann hier ein Ort mittels
        /// Geokoordinaten angegeben werden (z.B. zur Identifikation von Sendemasten).
        /// Achtung: Es darf immer nur eine Art der Ortsangabe vorhanden sein (entweder
        /// eine Adresse oder eine GeoKoordinate oder eine Katasteradresse.</summary>
        [JsonProperty(PropertyName = "geoadresse", Required = Required.Default, Order = 12)]
        [DataCategory(DataCategory.ADDRESS)]
        [ProtoMember(12)]
        public Geokoordinaten Geoadresse { get; set; }

        /// <summary>Alternativ zu einer postalischen Adresse und Geokoordinaten kann hier eine
        /// Ortsangabe mittels Gemarkung und Flurstück erfolgen.
        /// Achtung: Es darf immer nur eine Art der Ortsangabe vorhanden sein (entweder
        /// eine Adresse oder eine GeoKoordinate oder eine Katasteradresse.</summary> */
        [JsonProperty(PropertyName = "katasterinformation", Required = Required.Default, Order = 13)]
        [ProtoMember(13)]
        [DataCategory(DataCategory.ADDRESS)]
        public Katasteradresse Katasterinformation { get; set; }

        /// <summary>Liste der Hardware, die zu dieser Messstelle gehört.</summary>
        [JsonProperty(PropertyName = "geraete", Required = Required.Default, Order = 14)]
        [ProtoMember(14)]
        public List<Hardware> Geraete { get; set; }

        /// <summary>Liste der Messdienstleistungen, die zu dieser Messstelle gehört.</summary>
        [JsonProperty(PropertyName = "messdienstleistung", Required = Required.Default, Order = 15)]
        [ProtoMember(15)]
        public List<Dienstleistung> Messdienstleistung { get; set; }

        /// <summary> Zähler, die zu dieser Messlokation gehören. Details</summary>
        [JsonProperty(PropertyName = "messlokationszaehler", Required = Required.Default, Order = 16)]
        [ProtoMember(16)]
        public List<Zaehler> Messlokationszaehler { get; set; }

        /// <summary>
        /// <see cref="Marktlokation.Bilanzierungsmethode"/>
        /// </summary>
        [JsonProperty(PropertyName = "bilanzierungsmethode", Required = Required.Default, Order = 17)]
        [ProtoMember(17)]
        public Bilanzierungsmethode? Bilanzierungsmethode { get; set; }

        /// <summary>Dieser Wert ist true, falls die Abrechnungs des Messstellenbetriebs die Netznutzungsabrechnung enthält. false andernfalls</summary>
        [JsonProperty(PropertyName = "abrechnungmessstellenbetriebnna", Required = Required.Default, Order = 18)]
        [ProtoMember(1018)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        public bool? Abrechnungmessstellenbetriebnna { get; set; }

        /// <summary>
        /// marktrollen für EDIFACT mapping
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 19, PropertyName = "marktrollen")]
        [ProtoMember(1019)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [Obsolete("This isn't the right place for this information")] // ToDo: check
        public List<MarktpartnerDetails> Marktrollen { get; set; }

        /// <summary>
        /// gasqualitaet für EDIFACT mapping
        /// </summary>
        [JsonProperty(PropertyName = "gasqualitaet", Required = Required.Default, Order = 20, NullValueHandling = NullValueHandling.Ignore)]
        [ProtoMember(1020)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        public Gasqualitaet? Gasqualitaet { get; set; }

        /// <summary>
        /// verlustfaktor für EDIFACT mapping
        /// </summary>
        // ToDo: so does this mean that a factor of 0.0M has no losses?
        [JsonProperty(PropertyName = "verlustfaktor", Required = Required.Default, Order = 21)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1021)]
        public decimal? Verlustfaktor { get; set; }

        [JsonIgnore]
        private static readonly Regex RegexValidate = new Regex(@"[A-Z\d]{33}", RegexOptions.Compiled);

        /// <summary>
        /// Test if a <paramref name="id"/> is a valid messlokations ID.
        /// </summary>
        /// <param name="id">id to test</param>
        /// <returns></returns>
        public static bool ValidateId(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return false;
            }
            return RegexValidate.IsMatch(id);
        }

        /// <summary>
        /// Test if the <see cref="MesslokationsId"/> is valid.
        /// </summary>
        /// <returns>if messlokationsId matches the expected format</returns>
        public bool HasValidId()
        {
            return ValidateId(MesslokationsId);
        }

        /// <summary>
        /// same as <see cref="BusinessObject.IsValid()" /> if <paramref name="checkId"/> is false but by default additionally checks if the <see cref="MesslokationsId"/> is valid using <see cref="HasValidId"/>.
        /// </summary>
        /// <param name="checkId">validate the <see cref="MesslokationsId"/>, too</param>
        /// <returns>true if the marktlokation is valid</returns>
        public bool IsValid(bool checkId = true)
        {
            return base.IsValid() && (!checkId || HasValidId());
        }
    }
}