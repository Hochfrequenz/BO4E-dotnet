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

namespace BO4E.Extensions.Encryption
{
    public class X509AsymmetricEncrypter : Encrypter
    {
        private readonly ISet<X509Certificate2> publicCerts;
        private AsymmetricKeyParameter privateKey;

        /// <summary>
        /// Provide the constructor with an X509 certificate to use as encrypter.
        /// </summary>
        /// <param name="cert">X509 certificate must contain the public key.</param>
        public X509AsymmetricEncrypter(X509Certificate2 cert)
        {
            this.publicCerts = new HashSet<X509Certificate2> { cert };
            this.privateKey = null;
        }

        /// <summary>
        /// Provide the constructor a set of X509 certificates to use for encryption
        /// </summary>
        /// <param name="certs">Collection of certificates</param>
        public X509AsymmetricEncrypter(ISet<X509Certificate2> certs)
        {
            this.publicCerts = new HashSet<X509Certificate2>();
            foreach (X509Certificate2 c in certs)
            {
                this.publicCerts.Add(c);
            }
            this.privateKey = null;
        }

        private List<string> GetPublicKeysBase64()
        {
            List<string> result = new List<string>();
            foreach (X509Certificate2 cert in publicCerts)
            {
                // https://stackoverflow.com/a/4740292
                StringBuilder builder = new StringBuilder();
                builder.AppendLine("-----BEGIN CERTIFICATE-----");
                builder.AppendLine(Convert.ToBase64String(cert.Export(X509ContentType.Cert), Base64FormattingOptions.InsertLineBreaks));
                builder.AppendLine("-----END CERTIFICATE-----");
                result.Add(builder.ToString());
            }
            return result;
        }

        /// <summary>
        /// Provide the constructor with an AsymmetricKeyParameter to use as decrypter.
        /// </summary>
        /// <param name="kp">AsymmetricKeyParamer, must contain the RSA private key.</param>
        public X509AsymmetricEncrypter(AsymmetricKeyParameter kp)
        {
            this.publicCerts = null;
            this.privateKey = kp;
        }

        public string Encrypt(string plainText)
        {
            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
            CmsProcessableByteArray cpba = new CmsProcessableByteArray(plainBytes);

            CmsEnvelopedDataGenerator envelopedGen = new CmsEnvelopedDataGenerator();
            foreach (X509Certificate2 cert in publicCerts)
            {
                Org.BouncyCastle.X509.X509Certificate bouncyCert = DotNetUtilities.FromX509Certificate(cert);
                AsymmetricKeyParameter keyParameter = bouncyCert.GetPublicKey();
                envelopedGen.AddKeyTransRecipient(bouncyCert);
            }

            CmsEnvelopedData envelopedData = envelopedGen.Generate(cpba, CmsEnvelopedDataGenerator.Aes256Cbc);
            string cipherString = Convert.ToBase64String(envelopedData.GetEncoded());
            return cipherString;
        }

        public EncryptedObject Encrypt(BusinessObject plainObject)
        {
            string plainText = JsonConvert.SerializeObject(plainObject);
            string cipherString = Encrypt(plainText);
            return new EncryptedObjectPKCS7(cipherString, GetPublicKeysBase64());
        }

        public string Decrypt(string cipherText)
        {
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            CmsEnvelopedData envelopedData;
            envelopedData = new CmsEnvelopedData(cipherBytes);
            RecipientInformationStore recipientsStore = envelopedData.GetRecipientInfos();
            ICollection recipientsCollection = recipientsStore.GetRecipients();
            IList recipients = recipientsCollection as IList;
            byte[] plainBytes = new byte[] { };
            int index = 0;
            foreach (KeyTransRecipientInformation recipientInfo in recipients)
            {
                // todo: better approach than catching n exceptions.
                RecipientInformation recipient = recipientsStore.GetFirstRecipient(recipientInfo.RecipientID);
                try
                {
                    plainBytes = recipient.GetContent(this.privateKey);
                    break;
                }
                catch (CmsException e)
                {
                    if (index == recipientsStore.Count - 1)
                    {
                        throw e;
                    }
                }
                index++;
            }
            return Encoding.UTF8.GetString(plainBytes);
        }

        public static AsymmetricCipherKeyPair PrivateBase64KeyToACKP(string pemKeyBase64)
        {
            if (!pemKeyBase64.StartsWith("-----"))
            {
                pemKeyBase64 = "-----BEGIN RSA PRIVATE KEY-----\n" + pemKeyBase64 + "\n-----END RSA PRIVATE KEY-----";
            }
            using (var reader = new StringReader(pemKeyBase64))
            {
                return (AsymmetricCipherKeyPair)new PemReader(reader).ReadObject();
            }
        }

        public override BusinessObject Decrypt(EncryptedObject encryptedObject)
        {
            if (!(encryptedObject is EncryptedObjectPKCS7 eo))
            {
                return null;
            }
            string plainString = Decrypt(eo.CipherText);
            return JsonConvert.DeserializeObject<BusinessObject>(plainString);
        }

        public override T Decrypt<T>(EncryptedObject encryptedObject)
        {
            if (!(encryptedObject is EncryptedObjectPKCS7 eo))
            {
                return (T)null;
            }
            string plainString = Decrypt(eo.CipherText);
            return JsonConvert.DeserializeObject<T>(plainString);
        }

        public override void Dispose()
        {
            this.privateKey = null;
        }

        ~X509AsymmetricEncrypter()
        {
            Dispose();
        }
    }
}