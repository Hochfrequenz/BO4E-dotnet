using BO4E.ENUM;
using Newtonsoft.Json;

namespace BO4E.BO
{
    /// <summary>
    /// Encrypted Object using the Public Key Box Algorithm of libsodium
    /// </summary>
    public class EncryptedObjectPublicKeyBox : EncryptedObject
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cipherText">base64 encoded cipher text</param>
        /// <param name="publicKey">public key of the sender (base64 encoded)</param>
        /// <param name="nonce">unique nonce / initialisation vector (base 64 encoded, must not be used twice)</param>
        public EncryptedObjectPublicKeyBox(string cipherText, string publicKey, string nonce) : base(cipherText, EncryptionScheme.SodiumAsymmetricPublicKeyBox)
        {
            this.publicKey = publicKey;
            this.nonce = nonce;
        }

        /// <summary>
        /// Base64 encoded unique nonce / initialisation vector (IV)
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 8)]
        public string nonce;

        /// <summary>
        /// base64 encoded public key of the message sender
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 5)]
        public string publicKey;
    }
}
