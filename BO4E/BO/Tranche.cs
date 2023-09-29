using BO4E.COM;
using BO4E.EnergyIdentificationCodes;
using BO4E.ENUM;
using BO4E.meta;

using Newtonsoft.Json;

using ProtoBuf;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.ConstrainedExecution;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace BO4E.BO
{
    /// <summary>
    ///     Objekt zur Aufnahme der Informationen zu einer Tranche
    /// </summary>
    [ProtoContract]
    public class Tranche : BusinessObject
    {
        /// <summary>
        ///     Regular Expression used to validate 11 digit TrancheId like MarktlokationsId
        /// </summary>
        //[Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        protected static readonly Regex RegexValidate = new(@"^[1-9][\d]{10}$", RegexOptions.Compiled);

        /// <summary>
        ///     Regular Expression to check if a string consists only of numbers (is numeric)
        /// </summary>
        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        protected static readonly Regex RegexNumericString = new(@"^\d+$", RegexOptions.Compiled);

        /// <summary>
        ///     Identifikationsnummer einer Tranche, an der Energie entweder
        ///     verbraucht, oder erzeugt wird
        /// </summary>
        [DefaultValue("|null|")]
        [JsonProperty(Required = Required.Always, Order = 10, PropertyName = "trancheId")]
        [JsonPropertyName("trancheId")]
        [JsonPropertyOrder(10)]
        [DataCategory(DataCategory.POD)]
        [BoKey]
        [ProtoMember(4)]
        public string TrancheId { get; set; }

        /// <summary>Sparte der Messlokation, z.B. Gas oder Strom.</summary>
        [JsonProperty(Required = Required.Always, Order = 11, PropertyName = "sparte")]
        [JsonPropertyOrder(11)]
        [JsonPropertyName("sparte")]
        [ProtoMember(5)]
        public Sparte Sparte { get; set; }

        /// <summary>
        /// Prozentualer Anteil der Tranche an der erzeugenden Marktlokation in Prozent mit 2 Nachkommastellen
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 12, PropertyName = "aufteilungsmenge")]
        [JsonPropertyOrder(12)]
        [JsonPropertyName("aufteilungsmenge")]
        [ProtoMember(6)]
        public decimal? Aufteilungsmenge { get; set; }

        /// <summary>
        ///     Die OBIS-Kennzahl für die Tranche, die festlegt, welche auf die gemessene Größe mit dem Stand gemeldet wird.
        /// </summary>
        [JsonProperty(Required = Required.Default, Order = 13, PropertyName = "obisKennzahl")]
        [JsonPropertyOrder(13)]
        [JsonPropertyName("obisKennzahl")]
        [ProtoMember(7)]
        public string? ObisKennzahl { get; set; }

        /// <summary>
        ///     Test if a <paramref name="id" /> is a valid Tranche ID.
        /// </summary>
        /// <param name="id">id to test</param>
        /// <returns></returns>
        public static bool ValidateId(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return false;
            if (!RegexValidate.IsMatch(id)) return false;
            var expectedChecksum = GetChecksum(id);
            var actualChecksum = id.Substring(10, 1);
            return actualChecksum == expectedChecksum;
        }

        /// <summary>
        ///     Get the checksum of a marklokationsId:
        ///     a) Quersumme aller Ziffern in ungerader Position
        ///     b) Quersumme aller Ziffern
        ///     auf gerader Position multipliziert mit 2 c) Summe von a) und b) d) Differenz
        ///     von c) zum nächsten Vielfachen von 10 (ergibt sich hier 10, wird die
        ///     Prüfziffer 0 genommen)
        ///     https://bdew-codes.de/Content/Files/MaLo/2017-04-28-BDEW-Anwendungshilfe-MaLo-ID_Version1.0_FINAL.PDF
        /// </summary>
        /// <returns>expected checksum</returns>
        public static string GetChecksum(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException($"Input '{nameof(input)}' must not be empty but was '{input}'");
            if (input.Length is < 10 or > 11)
                throw new ArgumentException(
                    $"Input '{nameof(input)}' must be a string with length 10 (to generate the checksum) or 11 (to validate the checksum).");
            if (!RegexNumericString.IsMatch(input))
                throw new ArgumentException($"Input '{nameof(input)}' must be numeric was '{input}'");
            var oddChecksum = 0;
            var evenChecksum = 0;

            // start counting at 1 to be consistent with the above description of "even" and  "odd" but stop at tenth digit.
            for (var i = 1; i < 11; i++)
            {
                var s = input.Substring(i - 1, 1);
                if (i % 2 == 0)
                    evenChecksum += 2 * int.Parse(s);
                else
                    oddChecksum += int.Parse(s);
            }

            var result = (10 - (evenChecksum + oddChecksum) % 10) % 10;
            return result.ToString();
        }

        /// <summary>
        ///     Test if the <see cref="TrancheId" /> is valid.
        /// </summary>
        /// <returns>if <see cref="TrancheId"/> matches the expected format</returns>
        public bool HasValidId()
        {
            return ValidateId(TrancheId);
        }
    }
}
