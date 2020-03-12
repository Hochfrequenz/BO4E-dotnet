using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using BO4E.COM;
using BO4E.ENUM;
using BO4E.meta;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        /// Eindeutige Nummer der Marktlokation bzw. der Messlokation, zu der die Energiemenge gehört
        /// </summary>
        [DefaultValue("|null|")]
        [JsonProperty(Required = Required.Always, Order = 4)]
        [ProtoMember(4)]
        [DataCategory(DataCategory.POD)]
        [BoKey]
        public string lokationsId;

        /// <summary>
        /// Gibt an, ob es sich um eine Markt- oder Messlokation handelt.
        /// </summary>
        /// <see cref="Lokationstyp"/>
        [JsonProperty(Required = Required.Always, Order = 5)]
        [ProtoMember(5)]
        [DataCategory(DataCategory.POD)]
        public Lokationstyp lokationstyp;

        /// <summary>
        /// Gibt den <see cref="Verbrauch"/> in einer Zeiteinheit an.
        /// </summary>
        [JsonProperty(Order = 6)]
        [ProtoMember(6)]
        [DataCategory(DataCategory.METER_READING)]
        [MinLength(1)]
        public List<Verbrauch> energieverbrauch;

        /// <summary>
        /// If energieverbrauch is null or not present, it is initialised with an empty list for easier handling (less null checks) elsewhere.
        /// </summary>
        /// <param name="context"></param>
        [OnDeserialized]
        protected void OnDeserialized(StreamingContext context)
        {
            if (energieverbrauch == null)
            {
                energieverbrauch = new List<Verbrauch>();
            }
            else if (energieverbrauch.Count > 0)
            {
                energieverbrauch = energieverbrauch
                    .Select(v => Verbrauch.FixSapCdsBug(v))
                    .Where(v => !(v.startdatum == DateTime.MinValue || v.enddatum == DateTime.MinValue))
                    .Where(v => !(v.userProperties != null && v.userProperties.ContainsKey("invalid") && (bool)v.userProperties["invalid"] == true))
                    .ToList();
                if (userProperties != null && userProperties.TryGetValue(Verbrauch._SAP_PROFDECIMALS_KEY, out JToken profDecimalsRaw))
                {
                    var profDecimals = profDecimalsRaw.Value<int>();
                    if (profDecimals > 0)
                    {
                        for (int i = 0; i < profDecimals; i++)
                        {
                            // or should I import math.pow() for this purpose?
                            foreach (Verbrauch v in energieverbrauch.Where(v => v.userProperties == null || !v.userProperties.ContainsKey(Verbrauch._SAP_PROFDECIMALS_KEY)))
                            {
                                v.wert /= 10.0M;
                            }
                        }
                    }
                    userProperties.Remove(Verbrauch._SAP_PROFDECIMALS_KEY);
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
            if (em1.lokationsId != em2.lokationsId || em1.lokationstyp != em2.lokationstyp || em1.versionStruktur != em2.versionStruktur)
            {
                throw new InvalidOperationException($"You must not add the Energiemengen with different locations {em1.lokationsId} ({em1.lokationstyp}) (v{em1.versionStruktur}) vs. {em2.lokationsId} ({em2.lokationstyp}) (v{em2.versionStruktur})");
            }
            Energiemenge result = new Energiemenge()
            {
                lokationsId = em1.lokationsId,
                lokationstyp = em1.lokationstyp,
                versionStruktur = em1.versionStruktur,
            };
            if (em1.userProperties == null)
            {
                result.userProperties = em2.userProperties;
            }
            else if (em2.userProperties == null)
            {
                result.userProperties = em1.userProperties;
            }
            else
            {
                // there's no consistency check on user properties!
                result.userProperties = new Dictionary<string, JToken>();
                foreach (var kvp1 in em1.userProperties)
                {
                    result.userProperties.Add(kvp1);
                }
                foreach (var kvp2 in em2.userProperties)
                {
                    if (!result.userProperties.ContainsKey(kvp2.Key))
                    {
                        result.userProperties.Add(kvp2);
                    }
                }
            }
            if (em1.energieverbrauch == null || em1.energieverbrauch.Count == 0)
            {
                result.energieverbrauch = em2.energieverbrauch;
            }
            else if (em2.energieverbrauch == null || em2.energieverbrauch.Count == 0)
            {
                result.energieverbrauch = em1.energieverbrauch;
            }
            else
            {
                result.energieverbrauch = new List<Verbrauch>();
                result.energieverbrauch.AddRange(em1.energieverbrauch);
                result.energieverbrauch.AddRange(em2.energieverbrauch);
            }
            return result;
        }
    }
}
