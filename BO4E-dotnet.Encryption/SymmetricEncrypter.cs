using System;
using System.Text;
using BO4E.BO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sodium;

namespace BO4E.Extensions.Encryption
{
    public class SymmetricEncrypter : Encrypter
    {
        private readonly byte[] secretKey;

        /// <summary>
        /// pass the secret encryption key to the constructor
        /// </summary>
        /// <param name="secretKey">secret key</param>
        public SymmetricEncrypter(byte[] secretKey)
        {
            this.secretKey = secretKey;
        }
        /// <summary>
        /// pass the secret key as base64 encoded string to the constructor
        /// </summary>
        /// <param name="secretKey">secret key as base64 encoded string</param>
        public SymmetricEncrypter(string secretKey) : this(Convert.FromBase64String(secretKey)) { }

        /// <summary>
        /// Encrypt a given plain text and add associated data.
        /// </summary>
        /// <param name="plainText">UTF-8 encoded string containing the plain text to be encrypted</param>
        /// <param name="associatedDataString">max. 16 character long string (not secret)</param>
        /// <param name="nonce">unique nonce; not secret but must never be used with the same private key before</param>
        /// <returns>the encrypted data as Base64 encoded string</returns>
        private string Encrypt(string plainText, string associatedDataString, byte[] nonce)
        {
            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
            byte[] adBytes = Encoding.UTF8.GetBytes(associatedDataString);
            byte[] cipherBytes = SecretAead.Encrypt(plainBytes, nonce, secretKey, adBytes);
            string cipherString = Convert.ToBase64String(cipherBytes);
            return cipherString;
        }

        /// <summary>
        /// Encrypt a given plain text and add associated data.
        /// </summary>
        /// <param name="plainText">UTF-8 encoded string containing the plain text to be encrypted</param>
        /// <param name="associatedDataString">max. 16 character long string (not secret)</param>
        /// <returns>Tuple of (cipherText, nonce); both as base64 encoded string</returns>
        public (string, string) Encrypt(string plainText, string associatedDataString)
        {
            byte[] nonce = SecretAead.GenerateNonce();
            return (Encrypt(plainText, associatedDataString, nonce), Convert.ToBase64String(nonce));
        }

        /// <summary>
        /// Encrypt a Business Object
        /// </summary>
        /// <param name="plainObject">unencrypted Business Object</param>
        /// <param name="associatedData">max. 16 character long string (not secret)</param>
        /// <returns>an encrypted Business Object</returns>
        public EncryptedObjectAEAD Encrypt(BusinessObject plainObject, string associatedDataString)
        {
            string plainText = JsonConvert.SerializeObject(plainObject);
            byte[] nonce = SecretAead.GenerateNonce();
            string cipherString = Encrypt(plainText, associatedDataString, nonce);
            return new EncryptedObjectAEAD(cipherString, associatedDataString, Convert.ToBase64String(nonce));
        }
        /// <summary>
        /// Decrypts a given cipher texts and checks if it corresponds to the associated data.
        /// </summary>
        /// <param name="cipherText">Base64 encoded encrypted bytes</param>
        /// <param name="associatedDataString">max. 16 character long string (not secret)</param>
        /// <param name="nonce">unique nonce used during encryption (not secret)</param>
        /// <returns>decrypted as an UTF-8 encoded string</returns>
        private string Decrypt(string cipherText, string associatedDataString, byte[] nonce)
        {
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            byte[] adBytes = Encoding.UTF8.GetBytes(associatedDataString);
            byte[] plainBytes = SecretAead.Decrypt(cipherBytes, nonce, secretKey, adBytes);
            return Encoding.UTF8.GetString(plainBytes);
        }


        public string Decrypt(string cipherText, string associatedData, string nonceString)
        {
            byte[] nonceBytes = Convert.FromBase64String(nonceString);
            return Decrypt(cipherText, associatedData, nonceBytes);
        }

        public override BusinessObject Decrypt(EncryptedObject encryptedObject)
        {
            EncryptedObjectAEAD eo = (EncryptedObjectAEAD)encryptedObject;//(EncryptedObjectAEAD)BoMapper.MapObject("EncryptedObjectAEAD", JObject.FromObject(encryptedObject));
            if (eo == null)
            {
                return null;
            }
            string plainString = Decrypt(eo.CipherText, eo.AssociatedData, eo.Nonce);
            return JsonConvert.DeserializeObject<BusinessObject>(plainString);
        }

        public override void Dispose()
        {
            if (secretKey != null)
            {
                for (int i = 0; i < secretKey.Length; i++)
                {
                    secretKey[i] = 0x0;
                }
            }
        }

        ~SymmetricEncrypter()
        {
            Dispose();
        }
    }
}