using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

using BO4E.COM;
using BO4E.ENUM;
using BO4E.meta;
using BO4E.meta.LenientConverters;

using Newtonsoft.Json;

using ProtoBuf;

using JsonSerializer = System.Text.Json.JsonSerializer;

namespace BO4E.BO
{
    /// <summary>
    ///     Abbildung von Mengen, die Lokationen zugeordnet sind.
    /// </summary>
    [ProtoContract]
    public class Energiemenge : BusinessObject
    {
        /// <summary>
        ///     static serializer options for Energiemengenconverter
        /// </summary>
        public static JsonSerializerOptions? EnergiemengeSerializerOptions;
        /// <summary>
        /// Semaphore to protect access to the serializer
        /// </summary>
        public static readonly System.Threading.SemaphoreSlim SerializerSemaphore = new(1);
        static Energiemenge()
        {

        }

        /// <summary>
        ///     Eindeutige Nummer der Marktlokation bzw. der Messlokation, zu der die Energiemenge gehört
        /// </summary>
        [DefaultValue("|null|")]
        [JsonProperty(PropertyName = "lokationsId", Required = Required.Always, Order = 10)]
        [JsonPropertyName("lokationsId")]
        [JsonPropertyOrder(10)]
        [ProtoMember(10)]
        [DataCategory(DataCategory.POD)]
        [BoKey]
        public string LokationsId { get; set; }

        /// <summary>
        ///     Gibt an, ob es sich um eine Markt- oder Messlokation handelt.
        /// </summary>
        /// <see cref="Lokationstyp" />
        [JsonProperty(PropertyName = "lokationsTyp", Order = 11)]
        [JsonPropertyName("lokationsTyp")]
        [JsonPropertyOrder(11)]
        [ProtoMember(11)]
        [DataCategory(DataCategory.POD)]
        public Lokationstyp? LokationsTyp { get; set; }

        /// <summary>
        ///     Gibt den <see cref="Verbrauch" /> in einer Zeiteinheit an.
        /// </summary>
        [JsonProperty(Order = 12, PropertyName = "energieverbrauch")]
        [JsonPropertyName("energieverbrauch")]
        [JsonPropertyOrder(12)]
        [ProtoMember(12)]
        [DataCategory(DataCategory.METER_READING)]
        [MinLength(1)]
        public List<Verbrauch>? Energieverbrauch { get; set; }

        /// <summary>
        ///     Adding two Energiemenge objects is allowed for Energiemenge with the same location Id and location type.
        ///     The operation basically merges both energieverbrauch lists. Non-standard attributes (userProperties) are
        ///     not contained in the result.
        /// </summary>
        /// <param name="em1"></param>
        /// <param name="em2"></param>
        /// <returns>new Energiemenge object</returns>
        public static Energiemenge operator +(Energiemenge em1, Energiemenge em2)
        {
            if (em1.LokationsId != em2.LokationsId || em1.LokationsTyp != em2.LokationsTyp ||
                em1.VersionStruktur != em2.VersionStruktur)
                throw new InvalidOperationException(
                    $"You must not add the Energiemengen with different locations {em1.LokationsId} ({em1.LokationsTyp}) (v{em1.VersionStruktur}) vs. {em2.LokationsId} ({em2.LokationsTyp}) (v{em2.VersionStruktur})");
            var result = new Energiemenge
            {
                LokationsId = em1.LokationsId,
                LokationsTyp = em1.LokationsTyp,
                VersionStruktur = em1.VersionStruktur
            };
            if (em1.UserProperties == null)
            {
                result.UserProperties = em2.UserProperties;
            }
            else if (em2.UserProperties == null)
            {
                result.UserProperties = em1.UserProperties;
            }
            else
            {
                // there's no consistency check on user properties!
                result.UserProperties = new Dictionary<string, object>();
                foreach (var kvp1 in em1.UserProperties) result.UserProperties.Add(kvp1.Key, kvp1.Value);
                foreach (var kvp2 in em2.UserProperties)
                    if (!result.UserProperties.ContainsKey(kvp2.Key))
                        result.UserProperties.Add(kvp2.Key, kvp2.Value);
            }

            if (em1.Energieverbrauch == null || em1.Energieverbrauch.Count == 0)
            {
                result.Energieverbrauch = em2.Energieverbrauch;
            }
            else if (em2.Energieverbrauch == null || em2.Energieverbrauch.Count == 0)
            {
                result.Energieverbrauch = em1.Energieverbrauch;
            }
            else
            {
                result.Energieverbrauch = new List<Verbrauch>();
                result.Energieverbrauch.AddRange(em1.Energieverbrauch);
                result.Energieverbrauch.AddRange(em2.Energieverbrauch);
            }

            return result;
        }
    }

    /// <summary>
    /// </summary>
    public class EnergiemengeConverter : System.Text.Json.Serialization.JsonConverter<Energiemenge>
    {
        /// <summary>
        /// <inheritdoc cref="System.Text.Json.Serialization.JsonConverter{T}.Read"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="typeToConvert"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public override Energiemenge Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            Energiemenge.SerializerSemaphore.Wait();
            if (Energiemenge.EnergiemengeSerializerOptions == null)
            {
                Energiemenge.EnergiemengeSerializerOptions = new JsonSerializerOptions(options);
                while (Energiemenge.EnergiemengeSerializerOptions.Converters.Any(s => s.GetType() == typeof(EnergiemengeConverter)))
                {
                    Energiemenge.EnergiemengeSerializerOptions.Converters.Remove(
                    Energiemenge.EnergiemengeSerializerOptions.Converters.First(s => s.GetType() == typeof(EnergiemengeConverter)));
                }
            }
            Energiemenge.SerializerSemaphore.Release();
            var e = JsonSerializer.Deserialize<Energiemenge>(ref reader, Energiemenge.EnergiemengeSerializerOptions);
            if (e.Energieverbrauch == null)
            {
                e.Energieverbrauch = new List<Verbrauch>();
            }
            return e;
        }

        /// <summary>
        /// <inheritdoc cref="System.Text.Json.Serialization.JsonConverter{T}.Write"/>
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="options"></param>
        public override void Write(Utf8JsonWriter writer, Energiemenge value, JsonSerializerOptions options)
        {
            Energiemenge.SerializerSemaphore.Wait();
            if (Energiemenge.EnergiemengeSerializerOptions == null)
            {
                Energiemenge.EnergiemengeSerializerOptions = new JsonSerializerOptions(options);
                while (Energiemenge.EnergiemengeSerializerOptions.Converters.Any(s => s.GetType() == typeof(EnergiemengeConverter)))
                {
                    Energiemenge.EnergiemengeSerializerOptions.Converters.Remove(
                    Energiemenge.EnergiemengeSerializerOptions.Converters.First(s => s.GetType() == typeof(EnergiemengeConverter)));
                }
            }
            Energiemenge.SerializerSemaphore.Release();
            JsonSerializer.Serialize(writer, value, Energiemenge.EnergiemengeSerializerOptions);
        }
    }
}
