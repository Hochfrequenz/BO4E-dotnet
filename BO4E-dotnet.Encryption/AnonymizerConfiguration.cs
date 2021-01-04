using BO4E.meta;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;

namespace BO4E.Extensions.Encryption
{
    /// <summary>
    /// The Class AnonymizerConfiguration represents a complete configuration for the
    /// <see cref="Anonymizer"/> class. For each possible <see cref="DataCategory"/> an <see cref="AnonymizerApproach"/> is
    /// set to indicate whether the paths related to this option are to be scrambled
    /// or removed from the message.
    /// </summary>
    public class AnonymizerConfiguration
    {

        [JsonProperty(Required = Required.Always, PropertyName = "operations")]
        public Dictionary<DataCategory, AnonymizerApproach> Operations { get; private set; }

        /// <summary>
        /// set of key in <see cref="BO4E.BO.BusinessObject.UserProperties"/> / <see cref="BO4E.COM.COM.UserProperties"/> that should not be affected by the anonymizing operations
        /// </summary>
        [JsonProperty(Required = Required.Default, PropertyName = "unaffectedUserProperties")]
        public HashSet<string> UnaffectedUserProperties;

        [JsonProperty(Required = Required.Default)]
        public string ConfigurationKey { get; private set; }

        /// <summary>
        /// This constructor initialises all options with KEEP by default =&gt; leaves the Business Object unchanged.
        /// </summary>
        public AnonymizerConfiguration()
        {
            ConfigurationKey = null;
            Operations = new Dictionary<DataCategory, AnonymizerApproach>();
            foreach (var ao in Enum.GetValues(typeof(DataCategory)))
            {
                Operations.Add((DataCategory)ao, AnonymizerApproach.KEEP);
            }
            UnaffectedUserProperties = new HashSet<string>();
        }

        /// <summary>
        /// base64 encoded bytes used to salt hashing (<see cref="AnonymizerApproach.HASH"/>
        /// </summary>
        [JsonProperty(Required = Required.Always, PropertyName = "hashingSalt")]
        public string HashingSalt;

        /// <summary>
        /// returns the base64 encoded bytes from <see cref="HashingSalt"/> as byte array
        /// </summary>
        /// <returns>byte array or empty byte array if hashing salt is not set.</returns>
        public byte[] GetSalt()
        {
            return string.IsNullOrWhiteSpace(HashingSalt) ? new byte[0] : Convert.FromBase64String(HashingSalt);
        }

        /// <summary>
        /// Sets the passed <paramref name="anonymizerOption"/> <paramref name="anonymizerApproach"/>
        /// </summary>
        /// <param name="anonymizerOption">the passed DataCategory to</param>
        /// <param name="anonymizerApproach">t</param>
        public void SetOption(DataCategory anonymizerOption, AnonymizerApproach anonymizerApproach)
        {
            try
            {
                Operations.Add(anonymizerOption, anonymizerApproach);
            }
            catch (ArgumentException)
            {
                Operations.Remove(anonymizerOption);
                Operations.Add(anonymizerOption, anonymizerApproach);
            }
        }
        /// <summary>
        /// check if there are any operations in the configuration that actually change the object if an anonymizer with this configuration is applied.
        /// </summary>
        /// <returns>true if configuration potentially changes something</returns>
        public bool ContainsNonKeepingOperations()
        {
            return Operations
                .Any(kvp => kvp.Value != AnonymizerApproach.KEEP);
        }

        /// <summary>
        /// opposite of <see cref="ContainsNonKeepingOperations"/>
        /// </summary>
        /// <returns>opposite of <see cref="ContainsNonKeepingOperations"/></returns>
        public bool IsInitial() => !ContainsNonKeepingOperations();
    }
}
