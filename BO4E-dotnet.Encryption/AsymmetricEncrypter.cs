using System;
using System.Text;
using BO4E.BO;
using Newtonsoft.Json;
using Sodium;

namespace BO4E.Encryption
{
    public class AsymmetricEncrypter : Encrypter
    {
        private readonly byte[] _ownPublicKey;
        private readonly byte[] _privateKey;

        /// <summary>
        ///     Instantiate with private and public key
        /// </summary>
        /// <param name="privateKey">private key</param>
        /// <param name="publicKey">public key</param>
        public AsymmetricEncrypter(byte[] privateKey, byte[] publicKey)
        {
            _ownPublicKey = new byte[publicKey.Length];
            _privateKey = new byte[privateKey.Length];
            privateKey.CopyTo(_privateKey, 0);
            publicKey.CopyTo(_ownPublicKey, 0);
        }

        /// <summary>
        ///     Instantiate with private and public key
        /// </summary>
        /// <param name="privateKey">base64 encoded private key</param>
        /// <param name="publicKey">base64 encoded public key</param>
        public AsymmetricEncrypter(string privateKey, string publicKey) : this(Convert.FromBase64String(privateKey),
            Convert.FromBase64String(publicKey))
        {
        }

        /// <summary>
        ///     Instantiate with libsodium KeyPair
        /// </summary>
        /// <param name="kp">key pair</param>
        public AsymmetricEncrypter(KeyPair kp) : this(kp.PrivateKey, kp.PublicKey)
        {
        }

        /// <summary>
        ///     instantiate with own private key only
        /// </summary>
        /// <param name="privateKey">private key</param>
        public AsymmetricEncrypter(byte[] privateKey)
        {
            _privateKey = privateKey;
        }

        private string Encrypt(string plainText, string recipientsPublicKey, byte[] nonce)
        {
            var plainBytes = Encoding.UTF8.GetBytes(plainText);
            var rpkBytes = Convert.FromBase64String(recipientsPublicKey);
            var cipherBytes = PublicKeyBox.Create(plainBytes, nonce, _privateKey, rpkBytes);
            var cipherString = Convert.ToBase64String(cipherBytes);
            return cipherString;
        }

        /// <summary>
        ///     Encrypt a plain text with a public key
        /// </summary>
        /// <param name="plainText">UTF-8 encoded string containing the plain text to be encrypted</param>
        /// <param name="recipientsPublicKey">public key of receiver</param>
        /// <returns>Tuple of (cipherText, nonce); both as base64 encoded string</returns>
        public (string, string) Encrypt(string plainText, string recipientsPublicKey)
        {
            var nonce = PublicKeyBox.GenerateNonce();
            return (Encrypt(plainText, recipientsPublicKey, nonce), Convert.ToBase64String(nonce));
        }

        /// <summary>
        ///     Encrypt a Business Object for a given public key
        /// </summary>
        /// <param name="plainObject">unencrypted Business Object</param>
        /// <param name="publicKey">recipients public key</param>
        /// <returns>An encrypted Business Object</returns>
        public EncryptedObjectPublicKeyBox Encrypt(BusinessObject plainObject, string publicKey)
        {
            var plainText = JsonConvert.SerializeObject(plainObject, encryptionSerializerSettings);
            var nonce = PublicKeyBox.GenerateNonce();
            var cipherString = Encrypt(plainText, publicKey, nonce);
            return new EncryptedObjectPublicKeyBox(cipherString, Convert.ToBase64String(_ownPublicKey),
                Convert.ToBase64String(nonce));
        }

        private string Decrypt(string cipherText, string sendersPublicKey, byte[] nonce)
        {
            var cipherBytes = Convert.FromBase64String(cipherText);
            var spkBytes = Convert.FromBase64String(sendersPublicKey);
            var plainBytes = PublicKeyBox.Open(cipherBytes, nonce, _privateKey, spkBytes);
            return Encoding.UTF8.GetString(plainBytes);
        }

        /// <summary>
        ///     decrypt and authenticate a cipher text
        /// </summary>
        /// <param name="cipherText">encrypted message as base64 encoded string</param>
        /// <param name="sendersPublicKey">public key of sender for authentication as base64 encoded string</param>
        /// <param name="nonce">non-secret nonce as base64 encoded string</param>
        /// <returns>decrypted plain text</returns>
        public string Decrypt(string cipherText, string sendersPublicKey, string nonce)
        {
            return Decrypt(cipherText, sendersPublicKey, Convert.FromBase64String(nonce));
        }

        public override BusinessObject Decrypt(EncryptedObject encryptedObject)
        {
            var
                eo = (EncryptedObjectPublicKeyBox)
                    encryptedObject; // (EncryptedObjectPublicKeyBox)BoMapper.MapObject("EncryptedObjectPublicKeyBox", JObject.FromObject(encryptedObject));
            if (eo == null) return null;
            var plainString = Decrypt(eo.CipherText, eo.PublicKey, eo.Nonce);
            return JsonConvert.DeserializeObject<BusinessObject>(plainString, encryptionSerializerSettings);
        }

        public override T Decrypt<T>(EncryptedObject encryptedObject)
        {
            var
                eo = (EncryptedObjectPublicKeyBox)
                    encryptedObject; // (EncryptedObjectPublicKeyBox)BoMapper.MapObject("EncryptedObjectPublicKeyBox", JObject.FromObject(encryptedObject));
            if (eo == null) return null;
            var plainString = Decrypt(eo.CipherText, eo.PublicKey, eo.Nonce);
            return JsonConvert.DeserializeObject<T>(plainString, encryptionSerializerSettings);
        }

        public override void Dispose()
        {
            if (_privateKey != null)
                for (var i = 0; i < _privateKey.Length; i++)
                    _privateKey[i] = 0x0;
        }

        ~AsymmetricEncrypter()
        {
            Dispose();
        }
    }
}