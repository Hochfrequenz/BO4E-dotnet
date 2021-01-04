using System.Collections.Generic;

using BO4E.ENUM;

using Newtonsoft.Json;


namespace BO4E.BO
{
    /// <summary>
    /// Bouncy Castle CMS encrypted object
    /// </summary>
    public class EncryptedObjectPkcs7 : EncryptedObject
    {
        /// <param name="cipherText">base64 encoded cipher text</param>
        /// <param name="publicKeys">list of public keys for which the object is decrypt-able </param>
        public EncryptedObjectPkcs7(string cipherText, List<string> publicKeys) : base(cipherText, EncryptionScheme.BOUNCY_CASTLE_CMS)
        {
            PublicKeys = publicKeys;
        }

        /// <summary>
        /// list of public keys for which the object is decrypt-able 
        /// </summary>
        [JsonProperty(PropertyName = "publicKeys", Required = Required.Default)]
        public List<string> PublicKeys { get; set; }
    }
}
