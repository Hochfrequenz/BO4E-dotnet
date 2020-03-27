using System;
using System.Text;
using BO4E.BO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sodium;

namespace BO4E.Extensions.Encryption
{
    public class AsymmetricEncrypter : Encrypter
    {
        private readonly byte[] ownPublicKey;
        private readonly byte[] privateKey;

        /// <summary>
        /// Instantiate with private and public key
        /// </summary>
        /// <param name="privateKey">private key</param>
        /// <param name="publicKey">public key</param>
        public AsymmetricEncrypter(byte[] privateKey, byte[] publicKey)
        {
            this.privateKey = privateKey;
            this.ownPublicKey = publicKey;
        }
        /// <summary>
        /// Instantiate with private and public key
        /// </summary>
        /// <param name="privateKey">base64 encoded private key</param>
        /// <param name="publicKey">base64 encoded public key</param>
        public AsymmetricEncrypter(string privateKey, string publicKey) : this(Convert.FromBase64String(privateKey), Convert.FromBase64String(publicKey)) { }
        /// <summary>
        /// Instantiate with libsodium KeyPair
        /// </summary>
        /// <param name="kp">key pair</param>
        public AsymmetricEncrypter(KeyPair kp) : this(kp.PrivateKey, kp.PublicKey) { }

        /// <summary>
        /// instantiate with own private key only
        /// </summary>
        /// <param name="privateKey">private key</param>
        public AsymmetricEncrypter(byte[] privateKey)
        {
            this.privateKey = privateKey;
        }

        private string Encrypt(string plainText, string recipientsPublicKey, byte[] nonce)
        {
            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
            byte[] rpkBytes = Convert.FromBase64String(recipientsPublicKey);
            byte[] cipherBytes = PublicKeyBox.Create(plainBytes, nonce, privateKey, rpkBytes);
            string cipherString = Convert.ToBase64String(cipherBytes);
            return cipherString;
        }

        /// <summary>
        /// Encrypt a plain text with a public key
        /// </summary>
        /// <param name="plainText">UTF-8 encoded string containing the plain text to be encrypted</param>
        /// <param name="recipientsPublicKey">public key of receiver</param>
        /// <returns>Tuple of (cipherText, nonce); both as base64 encoded string</returns>
        public (string, string) Encrypt(string plainText, string recipientsPublicKey)
        {
            byte[] nonce = PublicKeyBox.GenerateNonce();
            return (Encrypt(plainText, recipientsPublicKey, nonce), Convert.ToBase64String(nonce));
        }

        /// <summary>
        /// Encrypt a Business Object for a given public key
        /// </summary>
        /// <param name="plainObject">unencrypted Business Object</param>
        /// <param name="publicKey">recipients public key</param>
        /// <returns>An encrypted Business Object</returns>
        public EncryptedObjectPublicKeyBox Encrypt(BusinessObject plainObject, string publicKey)
        {
            string plainText = JsonConvert.SerializeObject(plainObject);
            byte[] nonce = PublicKeyBox.GenerateNonce();
            string cipherString = Encrypt(plainText, publicKey, nonce);
            return new EncryptedObjectPublicKeyBox(cipherString, Convert.ToBase64String(ownPublicKey), Convert.ToBase64String(nonce));
        }

        private string Decrypt(string cipherText, string sendersPublicKey, byte[] nonce)
        {
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            byte[] spkBytes = Convert.FromBase64String(sendersPublicKey);
            byte[] plainBytes = PublicKeyBox.Open(cipherBytes, nonce, privateKey, spkBytes);
            return Encoding.UTF8.GetString(plainBytes);
        }

        /// <summary>
        /// decrypt and authenticate a cipher text
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
            EncryptedObjectPublicKeyBox eo = (EncryptedObjectPublicKeyBox)(encryptedObject);// (EncryptedObjectPublicKeyBox)BoMapper.MapObject("EncryptedObjectPublicKeyBox", JObject.FromObject(encryptedObject));
            if (eo == null)
            {
                return null;
            }
            string plainString = Decrypt(eo.CipherText, eo.PublicKey, eo.Nonce);
            return JsonConvert.DeserializeObject<BusinessObject>(plainString);
        }

        public override void Dispose()
        {
            if (privateKey != null)
            {
                for (int i = 0; i < privateKey.Length; i++)
                {
                    privateKey[i] = 0x0;
                }
            }
        }

        ~AsymmetricEncrypter()
        {
            Dispose();
        }
    }
}