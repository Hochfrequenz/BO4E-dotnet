using System.Collections.Generic;
using BO4E.COM;
using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;

namespace BO4E.BO
{
    ///<summary>
    /// Mit diesem Objekt können Geschäftspartner übertragen werden. Sowohl
    /// Unternehmen, als auch Privatpersonen können Geschäftspartner sein.
    /// </summary>
    ///
    /// Hinweis: Marktteilnehmer haben ein eigenes BO <see cref="Marktteilnehmer"/>, welches sich von diesem BO
    /// ableitet. Hier sollte daher keine Zuordnung zu Marktrollen erfolgen.
    public class Geschaeftspartner : BusinessObject
    {
        /// <summary>Die Anrede für den GePa, Z.B. Herr. <seealso cref="Anrede" /></summary>
        [JsonProperty(Required = Required.Default, Order = -1)]
        [FieldName("salutation", Language.EN)]
        public Anrede? anrede;

        /// <summary>
        /// Erster Teil des Namens. Hier kann der Firmenname oder bei Privatpersonen
        /// beispielsweise der Nachname dargestellt werden. Beispiele: Yellow Strom GmbH
        /// oder Hagen
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 0)]
        [DataCategory(DataCategory.NAME)]
        [BoKey]
        public string name1;

        /// <summary>
        /// Zweiter Teil des Namens. Hier kann der eine Erweiterung zum Firmennamen oder
        /// bei Privatpersonen beispielsweise der Vorname dargestellt werden. Beispiele:
        /// Bereich Süd oder Nina
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 1)]
        [DataCategory(DataCategory.NAME)]
        public string name2;

        /// <summary>
        /// Dritter Teil des Namens. Hier können weitere Ergänzungen zum Firmennamen oder
        /// bei Privatpersonen Zusätze zum Namen dargestellt werden. Beispiele: und Afrika
        /// oder Sängerin
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 2)]
        [DataCategory(DataCategory.NAME)]
        public string name3;

        /// <summary>
        /// Kennzeichnung ob es sich um einen Gewerbe/Unternehmen (gewerbeKennzeichnung = true)
        /// oder eine Privatperson handelt. (gewerbeKennzeichnung = false)
        /// </summary> 
        [JsonProperty(Required = Required.Always, Order = 3)]
        [FieldName("isCommercial", Language.EN)]
        public bool gewerbekennzeichnung;

        /// <summary>Handelsregisternummer des Geschäftspartners</summary>
        [JsonProperty(Required = Required.Default, Order = 4)]
        [DataCategory(DataCategory.LEGAL)]
        public string hrnummer;


        /// <summary> Amtsgericht bzw Handelsregistergericht, das die Handelsregisternummer herausgegeben hat</summary>
        [JsonProperty(Required = Required.Default, Order = 5)]
        [DataCategory(DataCategory.LEGAL)]
        public string amtsgericht;

        /// <summary>Bevorzugter Kontaktweg des Geschäftspartners.</summary>
        [JsonProperty(Required = Required.Default, Order = 6)]
        public List<Kontaktart> kontaktweg;

        /// <summary>Die Steuer-ID des Geschäftspartners. Beispiel: DE 813281825</summary>
        [JsonProperty(Required = Required.Default, Order = 7)]
        [DataCategory(DataCategory.LEGAL)]
        public string umsatzsteuerId;

        /// <summary>* Die Gläubiger-ID welche im Zahlungsverkehr verwendet wird- Z.B. DE 47116789</summary>
        [JsonProperty(Required = Required.Default, Order = 8)]
        [DataCategory(DataCategory.FINANCE)]
        public string glaeubigerId;

        /// <summary>E-Mail-Adresse des Ansprechpartners. Z.B. info@mp-energie.de</summary>
        [JsonProperty(Required = Required.Default, Order = 9)]
        [DataCategory(DataCategory.ADDRESS)]
        public string eMailAdresse;

        /// <summary>Internetseite des Marktpartners. Beispiel: www.mp-energie.de</summary>
        [JsonProperty(Required = Required.Default, Order = 10)]
        [DataCategory(DataCategory.ADDRESS)]
        public string website;

        /// <summary>Rolle, die der Geschäftspartner hat (z.B. Interessent, Kunde).</summary>
        [JsonProperty(Required = Required.Default, Order = 11)] // ToDo: it's actually required but I need it to work quickly
        [FieldName("role", Language.EN)]
        public List<Geschaeftspartnerrolle> geschaeftspartnerrolle;

        /// <summary>Adresse des Geschäftspartners, an der sich der Hauptsitz befindet. Details <seealso cref="Adresse" /></summary>
        [JsonProperty(Required = Required.Default, Order = 12)]
        [FieldName("partnerAddress", Language.EN)]
        public Adresse partneradresse;
    }
}