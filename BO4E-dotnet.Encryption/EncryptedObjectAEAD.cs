using BO4E.ENUM;
using Newtonsoft.Json;

namespace BO4E.BO
{
    /// <summary>
    /// Encrypted Object using libsodium AEAD algorithm with a shared secret/private key
    /// </summary>
    public class EncryptedObjectAEAD : EncryptedObject
    {
        /// <param name="cipherText">base64 encoded cipher text</param>
        /// <param name="associatedData">associated data (UTF-8), &lt;=16 characters</param>
        /// <param name="nonce">unique nonce / initialisation vector (base 64 encoded, must not be used twice)</param>
        public EncryptedObjectAEAD(string cipherText, string associatedData, string nonce) : base(cipherText, EncryptionScheme.SodiumSymmetricAEAD)
        {
            this.associatedData = associatedData;
            this.nonce = nonce;
        }

        /// <summary>
        /// base64 encoded unique nonce / initialisation vector
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 0)]
        public string nonce;

        /// <summary>
        /// associated data string (UTF-8); might be an empty string but not null
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 1)]
        public string associatedData;
    }
}
