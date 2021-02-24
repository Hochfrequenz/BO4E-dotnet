using BO4E.ENUM;
using BO4E.meta;

using Newtonsoft.Json;

namespace BO4E.BO
{
    /// <summary>
    /// An EncryptedObject does not contain any plain text but only information necessary to 
    /// decrypt and authenticate the original data. The decrypted cipher text contains the 
    /// original objects JSON serialization. The abstract class EncryptedObject contains
    /// mandatory attributes for all encrypted object types. Please see <see cref="EncryptedObjectAEAD"/>,
    /// <see cref="EncryptedObjectPublicKeyBox"/>, <see cref="EncryptedObjectPKCS7"/>.
    /// </summary>
    /// <author>Hochfrequenz Unternehmensberatung GmbH</author>
    public abstract class EncryptedObject : BusinessObject
    {
        /// <summary>
        /// encryption scheme used
        /// </summary>
        [JsonProperty(PropertyName = "encryptionScheme", Required = Required.Always, Order = 7)]
        [System.Text.Json.Serialization.JsonPropertyName("encryptionScheme")]
        [BoKey]
        public EncryptionScheme EncryptionScheme { get; set; }

        /// <summary>
        /// base64 encoded cipher text of the original objects JSON serialization
        /// </summary>
        [JsonProperty(PropertyName = "cipherText", Required = Required.Always, Order = 8)]
        [System.Text.Json.Serialization.JsonPropertyName("cipherText")]
        [BoKey]
        public string CipherText { get; set; }

        /// <summary>
        /// create a new EncryptedObject instance by providing both
        /// </summary>
        /// <param name="cipherText">the cipher text (bae64 encoded string)</param>
        /// <param name="es">the encryption scheme</param>
        protected EncryptedObject(string cipherText, EncryptionScheme es)
        {
            CipherText = cipherText;
            EncryptionScheme = es;
        }
    }
}
