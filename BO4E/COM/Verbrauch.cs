using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;
using BO4E.ENUM;
using BO4E.meta;
using BO4E.meta.LenientConverters;
using Newtonsoft.Json;
using ProtoBuf;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace BO4E.COM
{
    /// <summary>
    ///     Abbildung eines zeitlich abgegrenzten Verbrauchs.
    /// </summary>
    [ProtoContract]
    public class Verbrauch : COM
    {
        [ProtoIgnore] internal const string SapProfdecimalsKey = "sap_profdecimals";

        /// <summary>
        ///     static serializer options for Verbracuhconverter
        /// </summary>
        public static JsonSerializerOptions VerbrauchSerializerOptions;

        static Verbrauch()
        {
            VerbrauchSerializerOptions = LenientParsing.MOST_LENIENT.GetJsonSerializerOptions();
        }

        /// <summary>
        ///     <inheritdoc cref="CentralEuropeStandardTime.CentralEuropeStandardTimezoneInfo" />
        /// </summary>
        [ProtoIgnore]
        [Obsolete(
            "This property moved. Use the property BO4E.meta." + nameof(CentralEuropeStandardTime) + "." +
            nameof(CentralEuropeStandardTime.CentralEuropeStandardTimezoneInfo) + " instead.", true)]
        // ReSharper disable once InconsistentNaming
        public static TimeZoneInfo CENTRAL_EUROPE_STANDARD_TIME
            => CentralEuropeStandardTime.CentralEuropeStandardTimezoneInfo;

        /// <summary>
        ///     Beginn des Zeitraumes, für den der Verbrauch angegeben wird.
        /// </summary>
        /// <remarks>
        /// <c>Required = Required.Default</c>, DateTime aber nicht nullable, laut bo4e doku wäre es optional
        ///</remarks>
        [CompatibilityLevel(CompatibilityLevel.Level240)]
        [JsonProperty(PropertyName = "startdatum", Required = Required.Default, Order = 7)]
        [JsonPropertyName("startdatum")]
        [ProtoMember(3)]
        public DateTime Startdatum { get; set; } // ToDo: use datetimeoffset as well

        /// <summary>
        ///     Ende des Zeitraumes, für den der Verbrauch angegeben wird.
        /// </summary>
        [CompatibilityLevel(CompatibilityLevel.Level240)]
        [JsonProperty(PropertyName = "enddatum", Required = Required.Default, Order = 8)]
        [JsonPropertyName("enddatum")]
        [ProtoMember(4)]
        public DateTime Enddatum { get; set; } // ToDo: use datetimeoffset as well

        /// <summary>
        ///     Gibt an, ob es sich um eine PROGNOSE oder eine MESSUNG handelt.
        /// </summary>
        /// <seealso cref="ENUM.Wertermittlungsverfahren" />
        [JsonProperty(PropertyName = "wertermittlungsverfahren", Required = Required.Default, Order = 5)]
        [JsonPropertyName("wertermittlungsverfahren")]
        [ProtoMember(5)]
        public Wertermittlungsverfahren? Wertermittlungsverfahren { get; set; }

        /// <summary>
        ///     Enthält die Gültigkeit des angegebenen Wertes
        /// </summary>
        /// <seealso cref="ENUM.WertMengeArt" />
        [JsonProperty(PropertyName = "wertmengeart", Required = Required.Default, Order = 5)]
        [JsonPropertyName("wertmengeart")]
        [NonOfficial(NonOfficialCategory.UNSPECIFIED)]
        [ProtoMember(10)]
        public WertMengeArt? WertMengeArt { get; set; }


        /// <summary>
        /// Enthält die Auflistung der STS Segmente Plausibilisierungshinweis, Ersatzwertbildungsverfahren,
        /// Korrekturgrund, Gasqualität, Tarif, Grundlage der Energiemenge
        /// </summary>
        [JsonProperty(PropertyName = "statuszusatzinformationen", Required = Required.Default, Order = 5)]
        [JsonPropertyName("statuszusatzinformationen")]
        [NonOfficial(NonOfficialCategory.UNSPECIFIED)]
        [ProtoMember(11)]
        public List<StatusZusatzInformation>? StatusZusatzInformationen { get; set; }

        /// <summary>
        ///     Die OBIS-Kennzahl für den Wert, die festlegt, welche Größe mit dem Stand gemeldet wird.
        /// </summary>
        /// <example>
        ///     1-0:1.8.1
        /// </example>
        [JsonProperty(PropertyName = "obiskennzahl", Required = Required.Always, Order = 6)]
        [JsonPropertyName("obiskennzahl")]
        [ProtoMember(6)]
        public string Obiskennzahl { get; set; }

        /// <summary>
        ///     Gibt den absoluten Wert der Menge an.
        /// </summary>
        [JsonProperty(PropertyName = "wert", Required = Required.Always, Order = 7)]
        [JsonPropertyName("wert")]
        [ProtoMember(7)]
        public decimal Wert { get; set; }

        /// <summary>
        ///     Gibt die Einheit zum jeweiligen Wert an.
        /// </summary>
        /// <seealso cref="Mengeneinheit" />
        [JsonProperty(PropertyName = "einheit", Required = Required.Always, Order = 8)]
        [JsonPropertyName("einheit")]
        [ProtoMember(8)]
        public Mengeneinheit Einheit { get; set; }

        /// <summary>type</summary>
        /// <example>arbeitleistungtagesparameterabhmalo | veranschlagtejahresmenge | TUMKundenwert</example>
        [NonOfficial(NonOfficialCategory.UNSPECIFIED)]
        [JsonProperty(PropertyName = "type", Required = Required.Default)]
        [JsonPropertyName("type")]
        [ProtoMember(9)]
        public Verbrauchsmengetyp? Type { get; set; }

        /// <summary>Tarifstufe</summary>
        /// <seealso cref="ENUM.Tarifstufe" />
        [NonOfficial(NonOfficialCategory.UNSPECIFIED)]
        [JsonProperty(PropertyName = "tarifstufe", Required = Required.Default)]
        [JsonPropertyName("tarifstufe")]
        [ProtoMember(12)]
        public Tarifstufe? Tarifstufe { get; set; }
    }
}
