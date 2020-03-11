using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using BO4E.COM;
using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

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
        [JsonProperty(PropertyName = "messLokationsId", Required = Required.Always, Order = 4)]
        [DataCategory(DataCategory.POD)]
        [BoKey]
        [ProtoMember(4)]
        public string messlokationsId;

        /// <summary>* Sparte der Messlokation, z.B. Gas oder Strom.
        /// <seealso cref="Sparte" /></summary>
        [JsonProperty(Required = Required.Always, Order = 5)]
        [ProtoMember(5)]
        public Sparte sparte;
        ///<summary> Spannungsebene der Messung. <seealso cref="Netzebene" /></summary>
        [JsonProperty(Required = Required.Default, Order = 6)] //explicitly set NOT required.
        [ProtoMember(6)]
        public Netzebene? netzebeneMessung;

        /// <summary>Die Nummer des Messgebietes in der ene't-Datenbank.</summary>
        [JsonProperty(Required = Required.Default, Order = 7)]
        [ProtoMember(7)]
        public string messgebietNr;

        /// <summary>Codenummer des grundzuständigen Messstellenbetreibers, der für diese
        /// Messlokation zuständig ist.( Dieser ist immer dann Messstellenbetreiber, wenn
        /// kein anderer MSB die Einrichtungen an der Messlokation betreibt.)</summary>
        [JsonProperty(Required = Required.Default, Order = 8)]
        [ProtoMember(8)]
        public string grundzustaendigerMSBCodeNr;

        /// <summary>Codenummer des grundzuständigen Messstellenbetreibers für intelligente
        /// Messsysteme der für diese Messlokation zuständig ist.(Dieser ist immer dann
        /// Messstellenbetreiber, wenn kein anderer MSB die Einrichtungen an der
        /// Messlokation betreibt.)</summary>
        [JsonProperty(Required = Required.Default, Order = 9)]
        [ProtoMember(9)]
        public string grundzustaendigerMSBIMCodeNr;// grundzustaendigerMSB_IMCodenr;  https://github.com/Hochfrequenz/energy-service-hub/issues/11

        /// <summary> Codenummer des Messdienstleisters, der für diese Messlokation zuständig
        /// ist.( Dieser ist immer dann Messdienstleister, wenn kein anderer MDL die
        /// Messlokation abliest.)
        /// </summary>
        [JsonProperty(PropertyName = "grundzustaendigerMDLodeNr", Order = 10, Required = Required.Default)]
        [NonOfficial(NonOfficialCategory.PROPOSED_DELETION)]
        [ProtoMember(10)]
        [Obsolete("MDL is deprecated.", true)]
        public string grundzustaendigerMDLCodeNr;

        /// <summary>  Die Adresse, an der die Messeinrichtungen zu finden sind.( Nur angeben, wenn
        /// diese von der Adresse der Marktlokation abweicht.)
        /// Achtung: Es darf immer nur eine Art der Ortsangabe vorhanden sein (entweder
        /// eine Adresse oder eine GeoKoordinate oder eine Katasteradresse.
        ///</summary> 
        [JsonProperty(Required = Required.Default, Order = 11)]
        [DataCategory(DataCategory.ADDRESS)]
        [ProtoMember(11)]
        public Adresse messadresse;

        /// <summary> Alternativ zu einer postalischen Adresse kann hier ein Ort mittels
        /// Geokoordinaten angegeben werden (z.B. zur Identifikation von Sendemasten).
        /// Achtung: Es darf immer nur eine Art der Ortsangabe vorhanden sein (entweder
        /// eine Adresse oder eine GeoKoordinate oder eine Katasteradresse.</summary> 
        [JsonProperty(Required = Required.Default, Order = 12)]
        [DataCategory(DataCategory.ADDRESS)]
        [ProtoMember(12)]
        public Geokoordinaten geoadresse;

        /// <summary>Alternativ zu einer postalischen Adresse und Geokoordinaten kann hier eine
        /// Ortsangabe mittels Gemarkung und Flurstück erfolgen.
        /// Achtung: Es darf immer nur eine Art der Ortsangabe vorhanden sein (entweder
        /// eine Adresse oder eine GeoKoordinate oder eine Katasteradresse.</summary> */
        [JsonProperty(Required = Required.Default, Order = 13)]
        [ProtoMember(13)]
        [DataCategory(DataCategory.ADDRESS)]
        public Katasteradresse katasterinformation;

        /// <summary>Liste der Hardware, die zu dieser Messstelle gehört.</summary>
        [JsonProperty(Required = Required.Default, Order = 14)]
        [ProtoMember(14)]
        public List<Hardware> geraete;

        /// <summary>Liste der Messdienstleistungen, die zu dieser Messstelle gehört.</summary>
        [JsonProperty(Required = Required.Default, Order = 15)]
        [ProtoMember(15)]
        public List<Dienstleistung> messdienstleistung;

        /// <summary> Zähler, die zu dieser Messlokation gehören. Details</summary>
        [JsonProperty(Required = Required.Default, Order = 16)]
        [ProtoMember(16)]
        public List<Zaehler> messlokationszaehler;

        /// <summary>
        /// <see cref="Marktlokation.bilanzierungsmethode"/>
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 17)]
        [ProtoMember(17)]
        public Bilanzierungsmethode? bilanzierungsmethode;

        /// <summary>Dieser Wert ist true, falls die Abrechnungs des Messstellenbetriebs die Netznutzungsabrechnung enthält. false andernfalls</summary>
        [JsonProperty(Required = Required.Default, Order = 18)]
        [ProtoMember(18)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        public bool? abrechnungmessstellenbetriebnna;

        /// <summary>
        /// marktrollen für EDIFACT mapping
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 19)]
        [ProtoMember(19)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        public List<COM.Marktrolle> marktrollen;

        /// <summary>
        /// gasqualitaet für EDIFACT mapping
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 20, NullValueHandling = NullValueHandling.Ignore)]
        [ProtoMember(20)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        public Gasqualitaet? gasqualitaet;

        /// <summary>
        /// verlustfaktor für EDIFACT mapping
        /// </summary>
        // ToDo: so does this mean that a factor of 0.0M has no losses?
        [JsonProperty(Required = Required.Default, Order = 21)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(21)]
        public decimal? verlustfaktor;

        [JsonIgnore]
        private static readonly Regex REGEX_VALIDATE = new Regex(@"[A-Z\d]{33}", RegexOptions.Compiled);

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
            return REGEX_VALIDATE.IsMatch(id);
        }

        /// <summary>
        /// Test if the <see cref="messlokationsId"/> is valid.
        /// </summary>
        /// <returns>if messlokationsId matches the expected format</returns>
        public bool HasValidId()
        {
            return ValidateId(this.messlokationsId);
        }

        /// <summary>
        /// same as <see cref="BusinessObject.IsValid()" /> if <paramref name="checkId"/> is false but by default additionally checks if the <see cref="messlokationsId"/> is valid using <see cref="HasValidId"/>.
        /// </summary>
        /// <param name="checkId">validate the <see cref="messlokationsId"/>, too</param>
        /// <returns>true if the marktlokation is valid</returns>
        public bool IsValid(bool checkId = true)
        {
            return base.IsValid() && (!checkId || HasValidId());
        }
    }
}