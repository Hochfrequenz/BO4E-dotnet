using System.Text.Json.Serialization;
using BO4E.ENUM;
using Newtonsoft.Json;

namespace BO4E.Encryption
{
    /// <summary>
    ///     Encrypted Object using libsodium AEAD algorithm with a shared secret/private key
    /// </summary>
    public class EncryptedObjectAEAD : EncryptedObject
    {
        /// <param name="cipherText">base64 encoded cipher text</param>
        /// <param name="associatedData">associated data (UTF-8), &lt;=16 characters</param>
        /// <param name="nonce">unique nonce / initialisation vector (base 64 encoded, must not be used twice)</param>
        public EncryptedObjectAEAD(string cipherText, string associatedData, string nonce) : base(cipherText,
            EncryptionScheme.SodiumSymmetricAEAD)
        {
            AssociatedData = associatedData;
            Nonce = nonce;
        }

        /// <summary>
        ///     base64 encoded unique nonce / initialisation vector
        /// </summary>
        [JsonProperty(PropertyName = "nonce", Required = Required.Always, Order = 8)]
        [JsonPropertyName("nonce")]
        public string Nonce { get; set; }

        /// <summary>
        ///     associated data string (UTF-8); might be an empty string but not null
        /// </summary>
        [JsonProperty(PropertyName = "AssociatedData", Required = Required.Always, Order = 5)]
        [JsonPropertyName("AssociatedData")]
        public string AssociatedData { get; set; }
    }
}