using System;
using System.Collections.Generic;
using System.Linq;
using BO4E.meta;
using Newtonsoft.Json;

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

        [JsonProperty(Required = Required.Always)]
        public Dictionary<DataCategory, AnonymizerApproach> operations { get; private set; }

        /// <summary>
        /// set of key in <see cref="BO4E.BO.BusinessObject.userProperties"/> / <see cref="BO4E.COM.COM.userProperties"/> that should not be affected by the anonymizing operations
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public HashSet<string> unaffectedUserProperties;

        [JsonProperty(Required = Required.Default)]
        public string ConfigurationKey { get; private set; }

        /// <summary>
        /// This constructor initialises all options with KEEP by default =&gt; leaves the Business Object unchanged.
        /// </summary>
        public AnonymizerConfiguration()
        {
            this.ConfigurationKey = null;
            this.operations = new Dictionary<DataCategory, AnonymizerApproach>();
            foreach (object ao in Enum.GetValues(typeof(DataCategory)))
            {
                this.operations.Add((DataCategory)ao, AnonymizerApproach.KEEP);
            }
            this.unaffectedUserProperties = new HashSet<string>();
        }

        /// <summary>
        /// base64 encoded bytes used to salt hashing (<see cref="AnonymizerApproach.HASH"/>
        /// </summary>
        [JsonProperty(Required = Required.Default)]
        public string hashingSalt;

        /// <summary>
        /// returns the base64 encoded bytes from <see cref="AnonymizerConfiguration.hashingSalt"/> as byte array
        /// </summary>
        /// <returns>byte array or empty byte array if hashing salt is not set.</returns>
        public byte[] GetSalt()
        {
            if (string.IsNullOrWhiteSpace(hashingSalt))
            {
                return new byte[0];
            }
            else
            {
                return Convert.FromBase64String(hashingSalt);
            }
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
                this.operations.Add(anonymizerOption, anonymizerApproach);
            }
            catch (ArgumentException)
            {
                this.operations.Remove(anonymizerOption);
                this.operations.Add(anonymizerOption, anonymizerApproach);
            }
        }
        /// <summary>
        /// check if there are any operations in the configuration that actually change the object if an anonymizer with this configuration is applied.
        /// </summary>
        /// <returns>true if configuration potentially changes something</returns>
        public bool ContainsNonKeepingOperations()
        {
            return this.operations
                .Where(kvp => kvp.Value != AnonymizerApproach.KEEP)
                .Count() > 0;
        }

        /// <summary>
        /// opposite of <see cref="ContainsNonKeepingOperations"/>
        /// </summary>
        /// <returns>opposite of <see cref="ContainsNonKeepingOperations"/></returns>
        public bool IsInitial() => !ContainsNonKeepingOperations();
    }
}
