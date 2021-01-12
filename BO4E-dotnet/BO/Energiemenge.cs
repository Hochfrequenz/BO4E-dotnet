using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json;

using BO4E.COM;
using BO4E.ENUM;
using BO4E.meta;
using BO4E.meta.LenientConverters;

using Newtonsoft.Json;

using ProtoBuf;

namespace BO4E.BO
{
    /// <summary>
    /// Abbildung von Mengen, die Lokationen zugeordnet sind.
    /// </summary>
    [ProtoContract]
    public class Energiemenge : BusinessObject
    {
        /// <summary>
        /// static serializer options for Energiemengenconverter
        /// </summary>
        public static System.Text.Json.JsonSerializerOptions EnergiemengeSerializerOptions;
        static Energiemenge()
        {
            EnergiemengeSerializerOptions = LenientParsing.MOST_LENIENT.GetJsonSerializerOptions();
            EnergiemengeSerializerOptions.Converters.Remove(EnergiemengeSerializerOptions.Converters.Where(s => s.GetType() == typeof(EnergiemengeConverter)).First());
        }
        /// <summary>
        /// Eindeutige Nummer der Marktlokation bzw. der Messlokation, zu der die Energiemenge gehört
        /// </summary>
        [DefaultValue("|null|")]
        [JsonProperty(PropertyName = "lokationsId", Required = Required.Always, Order = 4)]
        [ProtoMember(4)]
        [DataCategory(DataCategory.POD)]
        [BoKey]
        public string LokationsId { get; set; }

        /// <summary>
        /// Gibt an, ob es sich um eine Markt- oder Messlokation handelt.
        /// </summary>
        /// <see cref="Lokationstyp"/>
        [JsonProperty(PropertyName = "lokationsTyp", Required = Required.Always, Order = 5)]
        [ProtoMember(5)]
        [DataCategory(DataCategory.POD)]
        public Lokationstyp LokationsTyp { get; set; }

        /// <summary>
        /// Gibt den <see cref="Verbrauch"/> in einer Zeiteinheit an.
        /// </summary>
        [JsonProperty(Order = 6, PropertyName = "energieverbrauch")]
        [ProtoMember(6)]
        [DataCategory(DataCategory.METER_READING)]
        [MinLength(1)]
        public List<Verbrauch> Energieverbrauch { get; set; }

        /// <summary>
        /// If energieverbrauch is null or not present, it is initialised with an empty list for easier handling (less null checks) elsewhere.
        /// </summary>
        /// <param name="context"></param>
        [OnDeserialized]
        protected void OnDeserialized(StreamingContext context)
        {
            if (Energieverbrauch == null)
            {
                Energieverbrauch = new List<Verbrauch>();
            }
            else if (Energieverbrauch.Count > 0)
            {
                Energieverbrauch = Energieverbrauch
                    .Select(Verbrauch.FixSapCdsBug)
                    .Where(v => !(v.Startdatum == DateTimeOffset.MinValue || v.Enddatum == DateTimeOffset.MinValue))
                    .Where(v => !v.UserPropertyEquals("invalid", true))
                    .ToList();
                if (UserProperties != null && UserProperties.TryGetValue(Verbrauch.SapProfdecimalsKey, out var profDecimalsRaw))
                {
                    int profDecimals = 0;
                    if (profDecimalsRaw is string)
                        profDecimals = Int32.Parse(profDecimalsRaw as string);
                    else
                        profDecimals = ((System.Text.Json.JsonElement)(profDecimalsRaw)).GetInt32();
                    if (profDecimals > 0)
                    {
                        for (var i = 0; i < profDecimals; i++)
                        {
                            // or should I import math.pow() for this purpose?
                            foreach (var v in Energieverbrauch.Where(v => v.UserProperties == null || !v.UserProperties.ContainsKey(Verbrauch.SapProfdecimalsKey)))
                            {
                                v.Wert /= 10.0M;
                            }
                        }
                    }
                    UserProperties.Remove(Verbrauch.SapProfdecimalsKey);
                }
            }
        }

        /// <summary>
        /// Adding two Energiemenge objects is allowed for Energiemenge with the same location Id and location type.
        /// The operation basically merges both energieverbrauch lists. Non-standard attributes (userProperties) are
        /// not contained in the result.
        /// </summary>
        /// <param name="em1"></param>
        /// <param name="em2"></param>
        /// <returns>new Energiemenge object</returns>
        public static Energiemenge operator +(Energiemenge em1, Energiemenge em2)
        {
            if (em1.LokationsId != em2.LokationsId || em1.LokationsTyp != em2.LokationsTyp || em1.VersionStruktur != em2.VersionStruktur)
            {
                throw new InvalidOperationException($"You must not add the Energiemengen with different locations {em1.LokationsId} ({em1.LokationsTyp}) (v{em1.VersionStruktur}) vs. {em2.LokationsId} ({em2.LokationsTyp}) (v{em2.VersionStruktur})");
            }
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
                foreach (var kvp1 in em1.UserProperties)
                {
                    result.UserProperties.Add(kvp1);
                }
                foreach (var kvp2 in em2.UserProperties)
                {
                    if (!result.UserProperties.ContainsKey(kvp2.Key))
                    {
                        result.UserProperties.Add(kvp2);
                    }
                }
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
    /// 
    /// </summary>
    public class EnergiemengeConverter : System.Text.Json.Serialization.JsonConverter<Energiemenge>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="typeToConvert"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public override Energiemenge Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {

            Energiemenge e = System.Text.Json.JsonSerializer.Deserialize<Energiemenge>(ref reader, Energiemenge.EnergiemengeSerializerOptions);
            if (e.Energieverbrauch == null)
            {
                e.Energieverbrauch = new List<Verbrauch>();
            }
            else if (e.Energieverbrauch.Count > 0)
            {
                e.Energieverbrauch = e.Energieverbrauch
                    .Select(Verbrauch.FixSapCdsBugSystemTextJson)
                    .Where(v => !(v.Startdatum == DateTimeOffset.MinValue || v.Enddatum == DateTimeOffset.MinValue))
                    .Where(v => !v.UserPropertyEquals("invalid", true))
                    .ToList();
                if (e.UserProperties != null && e.UserProperties.TryGetValue(Verbrauch.SapProfdecimalsKey, out var profDecimalsRaw))
                {
                    int profDecimals = 0;
                    if (profDecimalsRaw is string)
                        profDecimals = Int32.Parse(profDecimalsRaw as string);
                    else
                        profDecimals = System.Text.Json.JsonSerializer.Deserialize<int>(((System.Text.Json.JsonElement)(profDecimalsRaw)).GetRawText(), Energiemenge.EnergiemengeSerializerOptions);
                    if (profDecimals > 0)
                    {
                        for (var i = 0; i < profDecimals; i++)
                        {
                            // or should I import math.pow() for this purpose?
                            foreach (var v in e.Energieverbrauch.Where(v => v.UserProperties == null || !v.UserProperties.ContainsKey(Verbrauch.SapProfdecimalsKey)))
                            {
                                v.Wert /= 10.0M;
                            }
                        }
                    }
                    e.UserProperties.Remove(Verbrauch.SapProfdecimalsKey);
                }

            }
            return e;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="options"></param>
        public override void Write(Utf8JsonWriter writer, Energiemenge value, JsonSerializerOptions options)
        {
            System.Text.Json.JsonSerializer.Serialize(writer, value);

        }
    }
}