using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using BO4E.COM;
using BO4E.EnergyIdentificationCodes;
using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;
using ProtoBuf;

namespace BO4E.BO;

/// <summary>
/// Bilanzierungs BO
/// </summary>
[ProtoContract]
[NonOfficial(NonOfficialCategory.MISSING)]
public class Bilanzierung : BusinessObject
{
    /// <summary>
    /// Für welche Marktlokation gelten diese Bilanzierungsdaten
    /// </summary>
    [JsonProperty(PropertyName = "marktlokationsId", Order = 10)]
    [JsonPropertyName("marktlokationsId")]
    [JsonPropertyOrder(10)]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(1000)]
    [BoKey]
    public string? MarktlokationsId { get; set; }

    /// <summary>
    /// Eine Liste der verwendeten Lastprofile (SLP, SLP/TLP, ALP etc.)
    /// </summary>
    [JsonProperty(PropertyName = "lastprofile", Order = 11)]
    [JsonPropertyName("lastprofile")]
    [JsonPropertyOrder(11)]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(1001)]
    public List<Lastprofil>? Lastprofile { get; set; }

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
    [JsonProperty(PropertyName = "bilanzierungsbeginn", Order = 12)]
    [JsonPropertyName("bilanzierungsbeginn")]
    [JsonPropertyOrder(12)]
    [NonOfficial(NonOfficialCategory.MISSING)]
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
    [JsonProperty(PropertyName = "bilanzierungsende", Order = 13)]
    [JsonPropertyName("bilanzierungsende")]
    [JsonPropertyOrder(13)]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoIgnore]
    public DateTimeOffset? Bilanzierungsende { get; set; }

    /// <summary>
    /// Bilanzkreis, should obey <see cref="EnergyIdentificationCodeExtensions.IsValidEIC"/>
    /// </summary>
    [JsonProperty(PropertyName = "bilanzkreis", Order = 14)]
    [JsonPropertyName("bilanzkreis")]
    [JsonPropertyOrder(14)]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(1004)]
    [BoKey]
    public string? Bilanzkreis { get; set; }

    /// <summary>
    /// Jahresverbrauchsprognose
    /// </summary>
    [JsonProperty(PropertyName = "jahresverbrauchsprognose", Order = 15)]
    [JsonPropertyName("jahresverbrauchsprognose")]
    [JsonPropertyOrder(15)]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(1005)]
    public Menge? Jahresverbrauchsprognose { get; set; }

    /// <summary>
    /// Kundenwert
    /// </summary>
    [JsonProperty(PropertyName = "temperaturarbeit", Order = 16)]
    [JsonPropertyName("temperaturarbeit")]
    [JsonPropertyOrder(16)]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(1018)]
    public Menge? TemperaturArbeit { get; set; }

    /// <summary>
    /// Kundenwert
    /// </summary>
    [JsonProperty(PropertyName = "kundenwert", Order = 17)]
    [JsonPropertyName("kundenwert")]
    [JsonPropertyOrder(17)]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(1006)]
    public Menge? Kundenwert { get; set; }

    /// <summary>
    ///  Verbrauchsaufteilung in % zwischen SLP und TLP-Profil
    ///  1. [Gemessene Energiemenge der OBIS "nicht Schwachlast"] * [Verbrauchsaufteilung in % / 100%] = [zu verlagernde Energiemenge]
    ///  2. [Gemessene Energiemenge der OBIS "Schwachlast"] - [zu verlagernde Energiemenge] = [Ermittelte Energiemenge für
    ///     Schwachlast]
    ///  3. [Gemessene Energiemenge der OBIS "nicht Schwachlast"] + [zu verlagernde Energiemenge] = [Ermittelte Energiemenge für nicht
    ///     Schwachlast]
    /// </summary>
    [JsonProperty(PropertyName = "verbrauchsaufteilung", Order = 18)]
    [JsonPropertyName("verbrauchsaufteilung")]
    [JsonPropertyOrder(18)]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(1011)]
    public double? Verbrauchsaufteilung { get; set; }

    /// <summary>
    ///     Zeitreihentyp (SLS, TLS, etc.)
    /// </summary>
    [JsonProperty(PropertyName = "zeitreihentyp", Order = 19)]
    [JsonPropertyName("zeitreihentyp")]
    [JsonPropertyOrder(19)]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(1012)]
    public Zeitreihentyp? Zeitreihentyp { get; set; }

    /// <summary>
    ///     Aggregationsverantwortung
    /// </summary>
    [JsonProperty(PropertyName = "aggregationsverantwortung", Order = 20)]
    [JsonPropertyName("aggregationsverantwortung")]
    [JsonPropertyOrder(20)]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(1013)]
    public Aggregationsverantwortung? Aggregationsverantwortung { get; set; }

    /// <summary>
    ///     Prognosegrundlage
    /// </summary>
    [JsonProperty(PropertyName = "prognosegrundlage", Order = 21)]
    [JsonPropertyName("prognosegrundlage")]
    [JsonPropertyOrder(21)]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(1013)]
    public Prognosegrundlage? Prognosegrundlage { get; set; }

    /// <summary>
    ///     Prognosegrundlage
    ///     Besteht der Bedarf ein tagesparameteräbhängiges Lastprofil mit gemeinsamer Messung anzugeben, so ist dies über die 2 -malige
    ///     Wiederholung des CAV Segments mit der Angabe der Codes E02 und E14 möglich.
    /// </summary>
    [JsonProperty(PropertyName = "detailsPrognosegrundlage", Order = 22)]
    [JsonPropertyName("detailsPrognosegrundlage")]
    [JsonPropertyOrder(22)]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(1014)]
    public List<Profiltyp>? DetailsPrognosegrundlage { get; set; }

    /// <summary>
    ///     Wahlrecht der Prognosegrundlage (true = Wahlrecht beim Lieferanten vorhanden)
    /// </summary>
    [JsonProperty(PropertyName = "wahlrechtPrognosegrundlage", Order = 23)]
    [JsonPropertyName("wahlrechtPrognosegrundlage")]
    [JsonPropertyOrder(23)]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(1015)]
    public WahlrechtPrognosegrundlage? WahlrechtPrognosegrundlage { get; set; }

    /// <summary>
    ///     Fallgruppenzuordnung (für gas RLM)
    /// </summary>
    [JsonProperty(PropertyName = "fallgruppenzuordnung", Order = 24)]
    [JsonPropertyName("fallgruppenzuordnung")]
    [JsonPropertyOrder(24)]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(1016)]
    public Fallgruppenzuordnung? Fallgruppenzuordnung { get; set; }

    /// <summary>
    ///   Priorität des Bilanzkreises (für Gas)
    /// </summary>
    [JsonProperty(PropertyName = "prioritaet", Order = 25)]
    [JsonPropertyName("prioritaet")]
    [JsonPropertyOrder(25)]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(1017)]
    public int? Prioritaet { get; set; }

    /// <summary>
    ///     Grund Wahlrecht der Prognosegrundlage (true = Wahlrecht beim Lieferanten vorhanden)
    /// </summary>
    [JsonProperty(PropertyName = "grundWahlrechtPrognosegrundlage", Order = 26)]
    [JsonPropertyName("grundWahlrechtPrognosegrundlage")]
    [JsonPropertyOrder(26)]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(1018)]
    public WahlrechtPrognosegrundlage? GrundWahlrechtPrognosegrundlage { get; set; }

    /// <summary>
    ///     Abwicklungsmodell
    /// </summary>
    [JsonProperty(PropertyName = "abwicklungsmodell", Order = 27)]
    [JsonPropertyName("abwicklungsmodell")]
    [JsonPropertyOrder(27)]
    [NonOfficial(NonOfficialCategory.MISSING)]
    [ProtoMember(1019)]
    public Abwicklungsmodell? Abwicklungsmodell { get; set; }

    /// <summary>
    /// Aus der ORDERS gemappte Positionsnummer der Anfrage
    /// </summary>
    /// <remarks>LIN+?</remarks>
    [JsonProperty(PropertyName = "positionsnummer", Order = 28)]
    [JsonPropertyName("positionsnummer")]
    [ProtoMember(1020)]
    [JsonPropertyOrder(28)]
    public string? Positionsnummer { get; set; }
}
