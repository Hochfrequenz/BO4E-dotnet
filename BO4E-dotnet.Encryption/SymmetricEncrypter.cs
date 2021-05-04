using System;
using System.Text;
using BO4E.BO;
using Newtonsoft.Json;
using Sodium;

namespace BO4E.Encryption
{
    /// <summary>
    /// An encrypter using symmetric encryption.
    /// </summary>
    public class SymmetricEncrypter : Encrypter
    {
        private readonly byte[] _secretKey;

        /// <summary>
        ///     pass the secret encryption key to the constructor
        /// </summary>
        /// <param name="secretKey">secret key</param>
        public SymmetricEncrypter(byte[] secretKey)
        {
            _secretKey = new byte[secretKey.Length];
            secretKey.CopyTo(_secretKey, 0);
        }

        /// <summary>
        ///     pass the secret key as base64 encoded string to the constructor
        /// </summary>
        /// <param name="secretKey">secret key as base64 encoded string</param>
        public SymmetricEncrypter(string secretKey) : this(Convert.FromBase64String(secretKey))
        {
        }

        /// <summary>
        ///     Encrypt a given plain text and add associated data.
        /// </summary>
        /// <param name="plainText">UTF-8 encoded string containing the plain text to be encrypted</param>
        /// <param name="associatedDataString">max. 16 character long string (not secret)</param>
        /// <param name="nonce">unique nonce; not secret but must never be used with the same private key before</param>
        /// <returns>the encrypted data as Base64 encoded string</returns>
        private string Encrypt(string plainText, string associatedDataString, byte[] nonce)
        {
            var plainBytes = Encoding.UTF8.GetBytes(plainText);
            var adBytes = Encoding.UTF8.GetBytes(associatedDataString);
            var cipherBytes = SecretAeadChaCha20Poly1305.Encrypt(plainBytes, nonce, _secretKey, adBytes);
            var cipherString = Convert.ToBase64String(cipherBytes);
            return cipherString;
        }

        /// <summary>
        ///     Encrypt a given plain text and add associated data.
        /// </summary>
        /// <param name="plainText">UTF-8 encoded string containing the plain text to be encrypted</param>
        /// <param name="associatedDataString">max. 16 character long string (not secret)</param>
        /// <returns>Tuple of (cipherText, nonce); both as base64 encoded string</returns>
        public (string, string) Encrypt(string plainText, string associatedDataString)
        {
            var nonce = SecretAeadChaCha20Poly1305.GenerateNonce();
            return (Encrypt(plainText, associatedDataString, nonce), Convert.ToBase64String(nonce));
        }

        /// <summary>
        ///     Encrypt a Business Object
        /// </summary>
        /// <param name="plainObject">unencrypted Business Object</param>
        /// <param name="associatedDataString">max. 16 character long string (not secret)</param>
        /// <returns>an encrypted Business Object</returns>
        public EncryptedObjectAEAD Encrypt(BusinessObject plainObject, string associatedDataString)
        {
            var plainText = JsonConvert.SerializeObject(plainObject, encryptionSerializerSettings);
            var nonce = SecretAeadChaCha20Poly1305.GenerateNonce();
            var cipherString = Encrypt(plainText, associatedDataString, nonce);
            return new EncryptedObjectAEAD(cipherString, associatedDataString, Convert.ToBase64String(nonce));
        }

        /// <summary>
        ///     Decrypts a given cipher texts and checks if it corresponds to the associated data.
        /// </summary>
        /// <param name="cipherText">Base64 encoded encrypted bytes</param>
        /// <param name="associatedDataString">max. 16 character long string (not secret)</param>
        /// <param name="nonce">unique nonce used during encryption (not secret)</param>
        /// <returns>decrypted as an UTF-8 encoded string</returns>
        private string Decrypt(string cipherText, string associatedDataString, byte[] nonce)
        {
            var cipherBytes = Convert.FromBase64String(cipherText);
            var adBytes = Encoding.UTF8.GetBytes(associatedDataString);
            var plainBytes = SecretAeadChaCha20Poly1305.Decrypt(cipherBytes, nonce, _secretKey, adBytes);
            return Encoding.UTF8.GetString(plainBytes);
        }

        /// <summary>
        /// <inheritdoc cref="Encrypter.Decrypt"/>
        /// </summary>
        /// <param name="cipherText"></param>
        /// <param name="associatedData"></param>
        /// <param name="nonceString"></param>
        /// <returns></returns>
        public string Decrypt(string cipherText, string associatedData, string nonceString)
        {
            var nonceBytes = Convert.FromBase64String(nonceString);
            return Decrypt(cipherText, associatedData, nonceBytes);
        }

        /// <summary>
        /// <inheritdoc cref="Encrypter.Decrypt"/>
        /// </summary>
        /// <param name="encryptedObject"></param>
        /// <returns></returns>
        public override BusinessObject Decrypt(EncryptedObject encryptedObject)
        {
            var
                eo = (EncryptedObjectAEAD)encryptedObject; //(EncryptedObjectAEAD)BoMapper.MapObject("EncryptedObjectAEAD", JObject.FromObject(encryptedObject));
            if (eo == null) return null;
            var plainString = Decrypt(eo.CipherText, eo.AssociatedData, eo.Nonce);
            return JsonConvert.DeserializeObject<BusinessObject>(plainString, encryptionSerializerSettings);
        }

        /// <summary>
        /// <inheritdoc cref="Encrypter.Decrypt{T}"/>
        /// </summary>
        /// <param name="encryptedObject"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public override T Decrypt<T>(EncryptedObject encryptedObject)
        {
            var eo = (EncryptedObjectAEAD)encryptedObject;
            if (eo == null) return null;
            var plainString = Decrypt(eo.CipherText, eo.AssociatedData, eo.Nonce);
            return JsonConvert.DeserializeObject<T>(plainString, encryptionSerializerSettings);
        }

        /// <summary>
        /// <inheritdoc cref="Encrypter.Dispose"/>
        /// </summary>
        public override void Dispose()
        {
            if (_secretKey != null)
                for (var i = 0; i < _secretKey.Length; i++)
                    _secretKey[i] = 0x0;
        }
    
        /// <summary>
        /// <inheritdoc cref="Encrypter.Dispose"/>
        /// </summary>
        ~SymmetricEncrypter()
        {
            Dispose();
        }
    }
}