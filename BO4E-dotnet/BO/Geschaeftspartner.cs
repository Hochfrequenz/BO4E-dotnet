using System;
using System.Collections.Generic;

using BO4E.COM;
using BO4E.ENUM;
using BO4E.meta;

using Newtonsoft.Json;

using ProtoBuf;

namespace BO4E.BO
{
    ///<summary>
    /// Mit diesem Objekt können Geschäftspartner übertragen werden. Sowohl
    /// Unternehmen, als auch Privatpersonen können Geschäftspartner sein.
    /// </summary>
    ///
    /// Hinweis: Marktteilnehmer haben ein eigenes BO <see cref="Marktteilnehmer"/>, welches sich von diesem BO
    /// ableitet. Hier sollte daher keine Zuordnung zu Marktrollen erfolgen.
    [ProtoContract]
    // [ProtoInclude(41, typeof(Marktteilnehmer))] multiple inheritance is not yet supported by protobuf-net
    public class Geschaeftspartner : BusinessObject
    {
        /// <summary>Die Anrede für den GePa, Z.B. Herr. <seealso cref="Anrede" /></summary>
        [JsonProperty(Required = Required.Default, Order = 4, PropertyName = "anrede")]
        [ProtoMember(4)]
        [FieldName("salutation", Language.EN)]
        public Anrede? anrede { get; set; }

        /// <summary>
        /// title of name
        /// </summary>
        /// <example>Dr.</example>
        [JsonProperty(Required = Required.Default, Order = 5, PropertyName = "title")]
        [ProtoMember(1001)]
        [Obsolete("Please use anrede instead or Ansprechpartner.individuelleAnrede", true)]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        public string Title { get; set; }

        /// <summary>
        /// Erster Teil des Namens. Hier kann der Firmenname oder bei Privatpersonen
        /// beispielsweise der Nachname dargestellt werden. Beispiele: Yellow Strom GmbH
        /// oder Hagen
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 6, PropertyName = "name1")]
        [ProtoMember(6)]
        [DataCategory(DataCategory.NAME)]
        [BoKey]
        public string Name1 { get; set; }

        /// <summary>
        /// Zweiter Teil des Namens. Hier kann der eine Erweiterung zum Firmennamen oder
        /// bei Privatpersonen beispielsweise der Vorname dargestellt werden. Beispiele:
        /// Bereich Süd oder Nina
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 7, PropertyName = "name2")]
        [ProtoMember(7)]
        [DataCategory(DataCategory.NAME)]
        public string Name2 { get; set; }

        /// <summary>
        /// Dritter Teil des Namens. Hier können weitere Ergänzungen zum Firmennamen oder
        /// bei Privatpersonen Zusätze zum Namen dargestellt werden. Beispiele: und Afrika
        /// oder Sängerin
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 8, PropertyName = "name3")]
        [ProtoMember(8)]
        [DataCategory(DataCategory.NAME)]
        public string Name3 { get; set; }

        /// <summary>
        /// Kennzeichnung ob es sich um einen Gewerbe/Unternehmen (gewerbeKennzeichnung = true)
        /// oder eine Privatperson handelt. (gewerbeKennzeichnung = false)
        /// </summary> 
        [JsonProperty(Required = Required.Always, Order = 9, PropertyName = "gewerbekennzeichnung")]
        [ProtoMember(9)]
        [FieldName("isCommercial", Language.EN)]
        public bool Gewerbekennzeichnung { get; set; }

        /// <summary>Handelsregisternummer des Geschäftspartners</summary>
        [JsonProperty(Required = Required.Default, Order = 10, PropertyName = "hrnummer")]
        [ProtoMember(10)]
        [DataCategory(DataCategory.LEGAL)]
        public string Hrnummer { get; set; }


        /// <summary> Amtsgericht bzw Handelsregistergericht, das die Handelsregisternummer herausgegeben hat</summary>
        [JsonProperty(Required = Required.Default, Order = 11, PropertyName = "amtsgericht")]
        [ProtoMember(11)]
        [DataCategory(DataCategory.LEGAL)]
        public string Amtsgericht { get; set; }

        /// <summary>Bevorzugter Kontaktweg des Geschäftspartners.</summary>
        [JsonProperty(Required = Required.Default, Order = 12, PropertyName = "kontaktweg")]
        [ProtoMember(12)]
        public List<Kontaktart> Kontaktweg { get; set; }

        /// <summary>Die Steuer-ID des Geschäftspartners. Beispiel: DE 813281825</summary>
        [JsonProperty(Required = Required.Default, Order = 13, PropertyName = "umsatzsteuerId")]
        [ProtoMember(13)]
        [DataCategory(DataCategory.LEGAL)]
        public string UmsatzsteuerId { get; set; }

        /// <summary>* Die Gläubiger-ID welche im Zahlungsverkehr verwendet wird- Z.B. DE 47116789</summary>
        [JsonProperty(Required = Required.Default, Order = 14, PropertyName = "glaeubigerId")]
        [ProtoMember(14)]
        [DataCategory(DataCategory.FINANCE)]
        public string GlaeubigerId { get; set; }

        /// <summary>E-Mail-Adresse des Ansprechpartners. Z.B. info@mp-energie.de</summary>
        [JsonProperty(Required = Required.Default, Order = 15, PropertyName = "eMailAdresse")]
        [ProtoMember(15)]
        [DataCategory(DataCategory.ADDRESS)]
        public string EMailAdresse { get; set; }

        /// <summary>Internetseite des Marktpartners. Beispiel: www.mp-energie.de</summary>
        [JsonProperty(Required = Required.Default, Order = 16, PropertyName = "website")]
        [ProtoMember(16)]
        [DataCategory(DataCategory.ADDRESS)]
        public string Website { get; set; }

        /// <summary>Rolle, die der Geschäftspartner hat (z.B. Interessent, Kunde).</summary>
        [JsonProperty(Required = Required.Default, Order = 17, PropertyName = "geschaeftspartnerrolle")] // ToDo: it's actually required but I need it to work quickly
        [FieldName("role", Language.EN)]
        [ProtoMember(17)]
        public List<Geschaeftspartnerrolle> Geschaeftspartnerrolle;

        /// <summary>Adresse des Geschäftspartners, an der sich der Hauptsitz befindet. Details <seealso cref="Adresse" /></summary>
        [JsonProperty(Required = Required.Default, Order = 18, PropertyName = "partneradresse")]
        [ProtoMember(18)]
        [FieldName("partnerAddress", Language.EN)]
        public Adresse Partneradresse { get; set; }
    }
}