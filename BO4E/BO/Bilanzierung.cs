using BO4E.COM;
using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using BO4E.EnergyIdentificationCodes;

namespace BO4E.BO
{
    /// <summary>
    /// Bilanzierungs BO
    /// </summary>
    [ProtoContract]
    public class Bilanzierung : BusinessObject
    {
        /// <summary>
        /// Eine Liste der verwendeten Lastprofile (SLP, SLP/TLP, ALP etc.)
        /// </summary>
        [JsonProperty(PropertyName = "lastprofile", Required = Required.Default)]
        [JsonPropertyName("lastprofile")]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1001)]
        public List<Lastprofil> Lastprofile { get; set; }

        /// <summary>
        /// Inklusiver Start der Bilanzierung
        /// </summary>
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ProtoMember(1002, Name = nameof(Bilanzierungsbeginn))]
        [CompatibilityLevel(CompatibilityLevel.Level240)]
        private DateTime _Bilanzierungsbeginn
        {
            get => Bilanzierungsbeginn?.UtcDateTime ?? DateTime.MinValue;
            set => Bilanzierungsbeginn = DateTime.SpecifyKind(value, DateTimeKind.Utc);
        }
        /// <summary>
        /// Inklusiver Start der Bilanzierung
        /// </summary>
        [JsonProperty(PropertyName = "bilanzierungsbeginn", Required = Required.Default)]
        [JsonPropertyName("bilanzierungsbeginn")]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoIgnore]
        public DateTimeOffset? Bilanzierungsbeginn { get; set; }


        /// <summary>
        /// Exklusives Ende der Bilanzierung
        /// </summary>
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ProtoMember(1003, Name = nameof(Bilanzierungsende))]
        [CompatibilityLevel(CompatibilityLevel.Level240)]
        private DateTime _Bilanzierungsende
        {
            get => Bilanzierungsende?.UtcDateTime ?? DateTime.MinValue;
            set => Bilanzierungsende = DateTime.SpecifyKind(value, DateTimeKind.Utc);
        }
        /// <summary>
        /// Exklusives Ende der Bilanzierung
        /// </summary>
        [JsonProperty(PropertyName = "bilanzierungsende", Required = Required.Default)]
        [JsonPropertyName("bilanzierungsende")]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoIgnore]
        public DateTimeOffset? Bilanzierungsende { get; set; }

        /// <summary>
        /// Bilanzkreis, should obey <see cref="EnergyIdentificationCodeExtensions.IsValidEIC"/>
        /// </summary>
        [JsonProperty(PropertyName = "bilanzkreis", Required = Required.Default)]
        [JsonPropertyName("bilanzkreis")]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1004)]
        [BoKey]
        public string Bilanzkreis { get; set; }

        /// <summary>
        /// Jahresverbrauchsprognose
        /// </summary>
        [JsonProperty(PropertyName = "jahresverbrauchsprognose", Required = Required.Default)]
        [JsonPropertyName("jahresverbrauchsprognose")]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1005)]
        public Menge Jahresverbrauchsprognose { get; set; }

        /// <summary>
        /// Kundenwert
        /// </summary>
        [JsonProperty(PropertyName = "kundenwert", Required = Required.Default)]
        [JsonPropertyName("kundenwert")]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1006)]
        public Menge Kundenwert { get; set; }

        /// <summary>
        ///  Verbrauchsaufteilung in % zwischen SLP und TLP-Profil
        ///  1. [Gemessene Energiemenge der OBIS "nicht Schwachlast"] * [Verbrauchsaufteilung in % / 100%] = [zu verlagernde Energiemenge] 
        ///  2. [Gemessene Energiemenge der OBIS "Schwachlast"] - [zu verlagernde Energiemenge] = [Ermittelte Energiemenge für
        ///     Schwachlast]
        ///  3. [Gemessene Energiemenge der OBIS "nicht Schwachlast"] + [zu verlagernde Energiemenge] = [Ermittelte Energiemenge für nicht
        ///     Schwachlast]
        /// </summary>
        [JsonProperty(PropertyName = "verbrauchsaufteilung", Required = Required.Default)]
        [JsonPropertyName("verbrauchsaufteilung")]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1011)]
        public double? Verbrauchsaufteilung { get; set; }

        /// <summary>
        ///     Zeitreihentyp (SLS, TLS, etc.)
        /// </summary>
        [JsonProperty(PropertyName = "zeitreihentyp", Required = Required.Default)]
        [JsonPropertyName("zeitreihentyp")]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1012)]
        public Zeitreihentyp? Zeitreihentyp { get; set; }

        /// <summary>
        ///     Aggregationsverantwortung
        /// </summary>
        [JsonProperty(PropertyName = "aggregationsverantwortung", Required = Required.Default)]
        [JsonPropertyName("aggregationsverantwortung")]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1013)]
        public Aggregationsverantwortung? Aggregationsverantwortung { get; set; }

        /// <summary>
        ///     Prognosegrundlage
        /// </summary>
        [JsonProperty(PropertyName = "prognosegrundlage", Required = Required.Default)]
        [JsonPropertyName("prognosegrundlage")]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1013)]
        public Prognosegrundlage? Prognosegrundlage { get; set; }

        /// <summary>
        ///     Prognosegrundlage
        /// </summary>
        [JsonProperty(PropertyName = "detailsprognosegrundlage", Required = Required.Default)]
        [JsonPropertyName("detailsprognosegrundlage")]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1014)]
        public List<Profiltyp> DetailsPrognosegrundlage { get; set; }

        /// <summary>
        ///     Wahlrecht der Prognosegrundlage (true = Wahlrecht beim Lieferanten vorhanden)
        /// </summary>
        [JsonProperty(PropertyName = "wahlrechtprognosegrundlage", Required = Required.Default)]
        [JsonPropertyName("wahlrechtprognosegrundlage")]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1015)]
        public bool? WahlrechtPrognosegrundlage { get; set; }

        /// <summary>
        ///     Fallgruppenzuordnung (für gas RLM)
        /// </summary>
        [JsonProperty(PropertyName = "fallgruppenzuordnung", Required = Required.Default)]
        [JsonPropertyName("fallgruppenzuordnung")]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1016)]
        public Fallgruppenzuordnung? Fallgruppenzuordnung { get; set; }

        /// <summary>
        ///   Priorität des Bilanzkreises (für Gas)
        /// </summary>
        [JsonProperty(PropertyName = "prioritaet", Required = Required.Default)]
        [JsonPropertyName("prioritaet")]
        [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
        [ProtoMember(1017)]
        public int? Prioritaet { get; set; }
    }
}