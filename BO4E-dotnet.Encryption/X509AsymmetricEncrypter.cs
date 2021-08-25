using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using BO4E.BO;
using Newtonsoft.Json;
using Org.BouncyCastle.Cms;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;

namespace BO4E.Encryption
{
    /// <summary>
    /// Assymmetic Encryption in X509 standard.
    /// </summary>
    public class X509AsymmetricEncrypter : Encrypter
    {
        private readonly ISet<X509Certificate2> _publicCerts;
        private AsymmetricKeyParameter _privateKey;

        /// <summary>
        ///     Provide the constructor with an X509 certificate to use as encrypter.
        /// </summary>
        /// <param name="cert">X509 certificate must contain the public key.</param>
        public X509AsymmetricEncrypter(X509Certificate2 cert)
        {
            _publicCerts = new HashSet<X509Certificate2> { cert };
            _privateKey = null;
        }

        /// <summary>
        ///     Provide the constructor a set of X509 certificates to use for encryption
        /// </summary>
        /// <param name="certs">Collection of certificates</param>
        public X509AsymmetricEncrypter(ISet<X509Certificate2> certs)
        {
            _publicCerts = new HashSet<X509Certificate2>();
            foreach (var c in certs) _publicCerts.Add(c);
            _privateKey = null;
        }

        /// <summary>
        ///     Provide the constructor with an AsymmetricKeyParameter to use as decrypter.
        /// </summary>
        /// <param name="kp">AsymmetricKeyParamer, must contain the RSA private key.</param>
        public X509AsymmetricEncrypter(AsymmetricKeyParameter kp)
        {
            _publicCerts = null;
            _privateKey = kp;
        }

        private List<string> GetPublicKeysBase64()
        {
            var result = new List<string>();
            foreach (var cert in _publicCerts)
            {
                // https://stackoverflow.com/a/4740292
                var builder = new StringBuilder();
                builder.AppendLine("-----BEGIN CERTIFICATE-----");
                builder.AppendLine(Convert.ToBase64String(cert.Export(X509ContentType.Cert),
                    Base64FormattingOptions.InsertLineBreaks));
                builder.AppendLine("-----END CERTIFICATE-----");
                result.Add(builder.ToString());
            }

            return result;
        }

        /// <summary>
        /// encrypts the <paramref name="plainText"/>
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        public string Encrypt(string plainText)
        {
            var plainBytes = Encoding.UTF8.GetBytes(plainText);
            var cpba = new CmsProcessableByteArray(plainBytes);

            var envelopedGen = new CmsEnvelopedDataGenerator();
            foreach (var cert in _publicCerts)
            {
                var bouncyCert = DotNetUtilities.FromX509Certificate(cert);
                bouncyCert.GetPublicKey();
                envelopedGen.AddKeyTransRecipient(bouncyCert);
            }

            var envelopedData = envelopedGen.Generate(cpba, CmsEnvelopedGenerator.Aes256Cbc);
            var cipherString = Convert.ToBase64String(envelopedData.GetEncoded());
            return cipherString;
        }

        /// <summary>
        /// Encrypts the 
        /// </summary>
        /// <param name="plainObject"></param>
        /// <returns></returns>
        public EncryptedObject Encrypt(BusinessObject plainObject)
        {
            var plainText = JsonConvert.SerializeObject(plainObject, encryptionSerializerSettings);
            var cipherString = Encrypt(plainText);
            return new EncryptedObjectPKCS7(cipherString, GetPublicKeysBase64());
        }

        /// <summary>
        /// <inheritdoc cref="Encrypter.Decrypt"/>
        /// </summary>
        /// <param name="cipherText"></param>
        /// <returns></returns>
        public string Decrypt(string cipherText)
        {
            var cipherBytes = Convert.FromBase64String(cipherText);
            var envelopedData = new CmsEnvelopedData(cipherBytes);
            var recipientsStore = envelopedData.GetRecipientInfos();
            var recipientsCollection = recipientsStore.GetRecipients();
            var recipients = recipientsCollection as IList;
            var plainBytes = new byte[] { };
            var index = 0;
            foreach (KeyTransRecipientInformation recipientInfo in recipients)
            {
                // todo: better approach than catching n exceptions.
                var recipient = recipientsStore.GetFirstRecipient(recipientInfo.RecipientID);
                try
                {
                    plainBytes = recipient.GetContent(_privateKey);
                    break;
                }
                catch (CmsException) when (index != recipientsStore.Count - 1)
                {
                }

                index++;
            }

            return Encoding.UTF8.GetString(plainBytes);
        }

        /// <summary>
        /// Converts a base64 string <paramref name="pemKeyBase64"/> in PEM format to a <see cref="AsymmetricCipherKeyPair"/>.
        /// </summary>
        /// <param name="pemKeyBase64"></param>
        /// <returns></returns>
        public static AsymmetricCipherKeyPair PrivateBase64KeyToACKP(string pemKeyBase64)
        {
            if (!pemKeyBase64.StartsWith("-----"))
                pemKeyBase64 = "-----BEGIN RSA PRIVATE KEY-----\n" + pemKeyBase64 + "\n-----END RSA PRIVATE KEY-----";
            using (var reader = new StringReader(pemKeyBase64))
            {
                return (AsymmetricCipherKeyPair)new PemReader(reader).ReadObject();
            }
        }

        /// <summary>
        /// <inheritdoc cref="Encrypter.Decrypt"/>
        /// </summary>
        /// <param name="encryptedObject"></param>
        /// <returns></returns>
        public override BusinessObject Decrypt(EncryptedObject encryptedObject)
        {
            if (!(encryptedObject is EncryptedObjectPKCS7 eo)) return null;
            var plainString = Decrypt(eo.CipherText);
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
            if (!(encryptedObject is EncryptedObjectPKCS7 eo)) return null;
            var plainString = Decrypt(eo.CipherText);
            return JsonConvert.DeserializeObject<T>(plainString, encryptionSerializerSettings);
        }

        /// <summary>
        /// <inheritdoc cref="Encrypter.Dispose"/>
        /// </summary>
        public override void Dispose()
        {
            _privateKey = null;
        }

        /// <summary>
        /// calls the dispose method.
        /// </summary>
        ~X509AsymmetricEncrypter()
        {
            Dispose();
        }
    }
}