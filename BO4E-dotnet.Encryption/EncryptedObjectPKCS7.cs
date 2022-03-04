using System.Collections.Generic;
using System.Text.Json.Serialization;
using BO4E.ENUM;
using Newtonsoft.Json;

namespace BO4E.Encryption
{
    /// <summary>
    ///     Bouncy Castle CMS encrypted object
    /// </summary>
    public class EncryptedObjectPKCS7 : EncryptedObject
    {
        /// <param name="cipherText">base64 encoded cipher text</param>
        /// <param name="publicKeys">list of public keys for which the object is decrypt-able </param>
        public EncryptedObjectPKCS7(string cipherText, List<string> publicKeys) : base(cipherText,
            EncryptionScheme.BouncyCastleCMS)
        {
            PublicKeys = publicKeys;
        }

        /// <summary>
        ///     list of public keys for which the object is decrypt-able
        /// </summary>
        [JsonProperty(PropertyName = "publicKeys", Required = Required.Default)]
        [JsonPropertyName("publicKeys")]
        public List<string> PublicKeys { get; set; }
    }
}