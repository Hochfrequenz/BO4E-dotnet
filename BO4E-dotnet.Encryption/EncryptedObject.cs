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
        [JsonProperty(Required = Required.Always, Order = 7)]
        [BoKey]
        public EncryptionScheme encryptionScheme;

        /// <summary>
        /// base64 encoded cipher text of the original objects JSON serialisation
        /// </summary>
        [JsonProperty(Required = Required.Always, Order = 8)]
        [BoKey]
        public string cipherText;

        /// <summary>
        /// create a new EncryptedObject instance by providing both
        /// </summary>
        /// <param name="_cipherText">the cipher text (bae64 encoded string)</param>
        /// <param name="es">the encryption scheme</param>
        public EncryptedObject(string _cipherText, EncryptionScheme es) : base()
        {
            this.cipherText = _cipherText;
            this.encryptionScheme = es;
        }
    }
}
