using BO4E.COM;
using BO4E.ENUM;
using BO4E.meta;
using BO4E.meta.LenientConverters;

using Newtonsoft.Json;

using ProtoBuf;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

using JsonSerializer = System.Text.Json.JsonSerializer;

namespace BO4E.BO;

/// <summary>
///     Modell für die Abbildung von Vertragsbeziehungen. Das Objekt dient dazu, alle Arten von Verträgen, die in der
///     Energiewirtschaft Verwendung finden, abzubilden.
///     https://www.bo4e.de/dokumentation/geschaeftsobjekte/bo-vertrag
/// </summary>
[ProtoContract]
public class Vertrag : BusinessObject
{
    /// <summary>
    ///     static serializer options for Vertragsconverter
    /// </summary>
    public static JsonSerializerOptions? VertragsSerializerOptions;
    /// <summary>
    /// Semaphore to protect access to the serializer
    /// </summary>
    public static readonly System.Threading.SemaphoreSlim SerializerSemaphore = new(1);
    static Vertrag()
    {
    }

    /// <summary>
    ///     Eine im Verwendungskontext eindeutige Nummer für den Vertrag
    /// </summary>
    [BoKey]
    [JsonProperty(Required = Required.Default, Order = 10, PropertyName = "vertragsnummer")]
    [JsonPropertyName("vertragsnummer")]
    [ProtoMember(4)]
    [JsonPropertyOrder(10)]
    public string? Vertragsnummer { get; set; }

    /// <summary>
    ///     Beschreibung zum Vertrag
    /// </summary>
    [JsonProperty(Required = Required.Default, Order = 11, PropertyName = "beschreibung")]
    [JsonPropertyName("beschreibung")]
    [ProtoMember(5)]
    [JsonPropertyOrder(11)]
    public string? Beschreibung { get; set; }

    /// <summary>
    ///     Hier ist festgelegt, um welche Art von Vertrag es sich handelt. Z.B. Netznutzungvertrag. Details siehe ENUM
    ///     Vertragsart
    /// </summary>
    [JsonProperty(Required = Required.Default, Order = 12, PropertyName = "vertragsart")]
    [JsonPropertyName("vertragsart")]
    [ProtoMember(6)]
    [JsonPropertyOrder(12)]
    public Vertragsart? Vertragsart { get; set; }

    /// <summary>
    ///     Gibt den Status des Vertrags an. Siehe ENUM Vertragsstatus
    /// </summary>
    [JsonProperty(Required = Required.Default, Order = 13, PropertyName = "vertragstatus")]
    [JsonPropertyName("vertragstatus")]
    [JsonPropertyOrder(13)]
    [ProtoMember(7)]
    public Vertragstatus? Vertragstatus { get; set; } // ToDo: shouldn't this be vertragsstatus with "ss"?

    /// <summary>
    ///     Unterscheidungsmöglichkeiten für die Sparte. Siehe ENUM Sparte
    /// </summary>
    [JsonProperty(Required = Required.Always, Order = 14, PropertyName = "sparte")]
    [JsonPropertyName("sparte")]
    [JsonPropertyOrder(14)]
    [ProtoMember(8)]
    public Sparte Sparte { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    [Newtonsoft.Json.JsonIgnore]
    [ProtoMember(9, Name = nameof(Vertragsbeginn))]
    [CompatibilityLevel(CompatibilityLevel.Level240)]
    private DateTime _Vertragsbeginn
    {
        get => Vertragsbeginn.UtcDateTime;
        set => Vertragsbeginn = DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }
    /// <summary>
    ///     Gibt an, wann der Vertrag beginnt.
    /// </summary>
    [JsonProperty(Required = Required.Always, Order = 15, PropertyName = "vertragsbeginn")]
    [JsonPropertyName("vertragsbeginn")]
    [ProtoIgnore]
    [JsonPropertyOrder(15)]
    [Newtonsoft.Json.JsonConverter(typeof(LenientDateTimeConverter))]
    public DateTimeOffset Vertragsbeginn { get; set; }


    [System.Text.Json.Serialization.JsonIgnore]
    [Newtonsoft.Json.JsonIgnore]
    [ProtoMember(10, Name = nameof(Vertragsende))]
    [CompatibilityLevel(CompatibilityLevel.Level240)]
    private DateTime _Vertragsende
    {
        get => Vertragsende?.UtcDateTime ?? DateTime.MinValue;
        set => Vertragsende = DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }
    /// <summary>
    ///     Gibt an, wann der Vertrag (voraussichtlich) endet oder beendet wurde.
    /// </summary>
    [JsonProperty(Required = Required.Default, Order = 16, PropertyName = "vertragsende")]
    [JsonPropertyName("vertragsende")]
    [JsonPropertyOrder(16)]
    [ProtoIgnore]
    [Newtonsoft.Json.JsonConverter(typeof(LenientDateTimeConverter))]
    public DateTimeOffset? Vertragsende { get; set; }

    /// <summary>
    ///     Der "erstgenannte" Vertragspartner. In der Regel der Aussteller des Vertrags. Beispiel: "Vertrag zwischen
    ///     Vertagspartner 1 ..." Siehe BO Geschaeftspartner
    /// </summary>
    [JsonProperty(Required = Required.Default, Order = 17,
        PropertyName = "vertragspartner1")] // TODO: should be required but our CDS is missing the association
    [JsonPropertyName("vertragspartner1")]
    [JsonPropertyOrder(17)]
    [ProtoMember(11)]
    public Geschaeftspartner? Vertragspartner1 { get; set; }

    /// <summary>
    ///     Der "zweitgenannte" Vertragspartner. In der Regel der Empfänger des Vertrags. Beispiel "Vertrag zwischen
    ///     Vertagspartner 1 und Vertragspartner 2". Siehe BO Geschaeftspartner
    /// </summary>
    [JsonProperty(Required = Required.Default, Order = 18,
        PropertyName = "vertragspartner2")] // TODO: should be required but our CDS is missing the association
    [JsonPropertyName("vertragspartner2")]
    [JsonPropertyOrder(18)]
    [ProtoMember(12)]
    public Geschaeftspartner? Vertragspartner2 { get; set; }

    /// <summary>
    ///     Unterzeichner des Vertragspartners1. Siehe COM Unterschrift
    /// </summary>
    [JsonProperty(Required = Required.Default, Order = 19, PropertyName = "unterzeichnervp1")]
    [JsonPropertyName("unterzeichnervp1")]
    [ProtoMember(13)]
    [JsonPropertyOrder(19)]
    public List<Unterschrift>? Unterzeichnervp1 { get; set; }

    /// <summary>
    ///     Unterzeichner des Vertragspartners2. Siehe COM Unterschrift
    /// </summary>
    [JsonProperty(Required = Required.Default, Order = 20, PropertyName = "unterzeichnervp2")]
    [JsonPropertyName("unterzeichnervp2")]
    [ProtoMember(14)]
    [JsonPropertyOrder(20)]
    public List<Unterschrift>? Unterzeichnervp2 { get; set; }

    /// <summary>
    ///     Festlegungen zu Laufzeiten und Kündigungsfristen. Details siehe COM Vertragskonditionen
    /// </summary>
    [JsonProperty(Required = Required.Default, Order = 21, PropertyName = "vertragskonditionen")]
    [JsonPropertyName("vertragskonditionen")]
    [ProtoMember(15)]
    [JsonPropertyOrder(21)]
    public Vertragskonditionen? Vertragskonditionen { get; set; }

    /// <summary>
    ///     Der Vertragsteil wird dazu verwendet, eine vertragliche Leistung in Bezug zu einer Lokation (Markt- oder
    ///     Messlokation) festzulegen. Details siehe COM Vertragsteil
    /// </summary>
    [JsonProperty(Required = Required.Default, Order = 22,
        PropertyName = "vertragsteile")] // TODO: should be required always but our CDS is missing the association
    [JsonPropertyName("vertragsteile")]
    [ProtoMember(16)]
    [JsonPropertyOrder(22)]
    public List<Vertragsteil>? Vertragsteile { get; set; }

    /// <summary>
    ///     gemeinderabatt für EDIFACT mapping.
    /// </summary>
    // ToDo: What is the unit? is 1.0 = 100% discount?
    [JsonProperty(Required = Required.Default, Order = 23, PropertyName = "gemeinderabatt")]
    [JsonPropertyName("gemeinderabatt")]
    [JsonPropertyOrder(23)]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    [ProtoMember(1017)]
    public decimal? Gemeinderabatt { get; set; }

    /// <summary>
    ///     korrespondenzpartner für EDIFACT mapping
    /// </summary>
    [JsonProperty(Required = Required.Default, Order = 24, PropertyName = "korrespondenzpartner")]
    [JsonPropertyName("korrespondenzpartner")]
    [NonOfficial(NonOfficialCategory.CUSTOMER_REQUIREMENTS)]
    [ProtoMember(1018)]
    [JsonPropertyOrder(24)]
    // ToDO: isn't an Ansprechpartner the better choice than a Geschaeftspartner?
    public Geschaeftspartner? Korrespondenzpartner { get; set; }

    /// <summary>
    ///     moves lokationsId from userProperties to vertragsteil if relevant
    /// </summary>
    /// <param name="context"></param>
    [OnDeserialized]
    protected void OnDeserialized(StreamingContext context)
    {
        if ((Vertragsteile == null || Vertragsteile.Count == 0) && UserProperties != null &&
            UserProperties.ContainsKey("lokationsId"))
            Vertragsteile = new List<Vertragsteil>
            {
                new Vertragsteil
                {
                    Vertragsteilbeginn = Vertragsbeginn,
                    Vertragsteilende = Vertragsende,
                    Lokation = UserProperties["lokationsId"] as string
                }
            };
    }
}

/// <summary>
/// </summary>
public class VertragsConverter : System.Text.Json.Serialization.JsonConverter<Vertrag>
{
    /// <summary>
    /// <inheritdoc cref="System.Text.Json.Serialization.JsonConverter{T}.Read"/>
    /// </summary>
    /// <param name="reader"></param>
    /// <param name="typeToConvert"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    public override Vertrag Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        Vertrag.SerializerSemaphore.Wait();
        try
        {
            RemoveDuplicateVertragsConverter(options);
        }
        finally
        {
            Vertrag.SerializerSemaphore.Release();
        }

        var v = JsonSerializer.Deserialize<Vertrag>(ref reader, Vertrag.VertragsSerializerOptions);
        if ((v.Vertragsteile == null || v.Vertragsteile.Count == 0) && v.UserProperties != null &&
            v.UserProperties.ContainsKey("lokationsId"))
            v.Vertragsteile = new List<Vertragsteil>
            {
                new()
                {
                    Vertragsteilbeginn = v.Vertragsbeginn,
                    Vertragsteilende = v.Vertragsende,
                    Lokation = ((JsonElement) v.UserProperties["lokationsId"]).GetString()
                }
            };
        return v;
    }

    private static void RemoveDuplicateVertragsConverter(JsonSerializerOptions options)
    {
        if (Vertrag.VertragsSerializerOptions == null)
        {
            Vertrag.VertragsSerializerOptions = new JsonSerializerOptions(options);
            while (Vertrag.VertragsSerializerOptions.Converters.Any(s => s.GetType() == typeof(VertragsConverter)))
            {
                Vertrag.VertragsSerializerOptions.Converters.Remove(
                    Vertrag.VertragsSerializerOptions.Converters.First(s => s.GetType() == typeof(VertragsConverter)));
            }
        }
    }

    /// <summary>
    /// <inheritdoc cref="System.Text.Json.Serialization.JsonConverter{T}.Write"/>
    /// </summary>
    /// <param name="writer"></param>
    /// <param name="value"></param>
    /// <param name="options"></param>
    public override void Write(Utf8JsonWriter writer, Vertrag value, JsonSerializerOptions options)
    {
        Vertrag.SerializerSemaphore.Wait();
        try
        {
            RemoveDuplicateVertragsConverter(options);
        }
        finally
        {
            Vertrag.SerializerSemaphore.Release();
        }
        JsonSerializer.Serialize(writer, value, Vertrag.VertragsSerializerOptions);
    }
}
