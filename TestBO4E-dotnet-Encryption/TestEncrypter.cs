using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;

using BO4E.BO;
using BO4E.BO.LogObject;
using BO4E.Extensions.Encryption;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.OpenSsl;

using Sodium;

namespace TestBO4EExtensions.Encryption
{
    [TestClass]
    public class TestEncrypter
    {

        [TestMethod]
        public void TestDisposal()
        {
            // this test is still bad.

            // "default" disposal
            var symkey = SecretBox.GenerateKey();
            var abc = new SymmetricEncrypter(symkey);
            abc.Dispose();

            try
            {
                _ = new SymmetricEncrypter("Not a valid base64 code triggering an exception!");
            }
            catch (FormatException)
            {
                // disposal is called although constructor failed.
            }
            var exceptionThrown = false;
            try
            {
            }
            catch (Exception)
            {
                exceptionThrown = true;
            }
            _ = new SymmetricEncrypter(symkey);
            Assert.IsFalse(exceptionThrown);
        }

        [TestMethod]
        public void TestBOEncryption()
        {
            var files = Directory.GetFiles("encrypterTests/bo/", "*.json"); // 

            foreach (var testFile in files)
            {

                JObject json;
                using (var r = new StreamReader(testFile))
                {
                    var jsonString = r.ReadToEnd();
                    json = JsonConvert.DeserializeObject<JObject>(jsonString);
                }
                Assert.IsNotNull(json, $"The content of file {testFile} seems to be no valid JSON.");

                var boType = (string)json["boTyp"];
                Assert.IsNotNull(boType, $"The JSON content of file {testFile} is missing the obligatory 'boTyp' attribute.");

                var bo = BO4E.BoMapper.MapObject(boType, json);
                Assert.IsNotNull(bo, $"The business object in file {testFile} is not a valid BO4E.");

                /******* symmetric test ******/
                var symkey = SecretBox.GenerateKey();
                var symkeyString = Convert.ToBase64String(symkey);
                EncryptedObject eo;
                using (var se0 = new SymmetricEncrypter(symkey))
                {
                    eo = se0.Encrypt(bo, "Associated");
                }

                BusinessObject boDecrypted;
                using (var se1 = new SymmetricEncrypter(symkeyString))
                {
                    boDecrypted = se1.Decrypt(eo);
                }
                var expectedString = JsonConvert.SerializeObject(bo);
                var actualString = JsonConvert.SerializeObject(boDecrypted);
                Assert.AreEqual(expectedString, actualString, "Original and encrypted->decrypted object do not match!");

                /******* asymmetric test ******/
                var asykeyPairSender = PublicKeyBox.GenerateKeyPair();
                var asykeyPairRecipient = PublicKeyBox.GenerateKeyPair();
                using (var asyenc = new AsymmetricEncrypter(asykeyPairSender))
                {
                    eo = asyenc.Encrypt(bo, Convert.ToBase64String(asykeyPairRecipient.PublicKey));
                }

                using (var asydec = new AsymmetricEncrypter(asykeyPairRecipient.PrivateKey))
                {
                    boDecrypted = asydec.Decrypt(eo);
                }
                expectedString = JsonConvert.SerializeObject(bo);
                actualString = JsonConvert.SerializeObject(boDecrypted);
                Assert.AreEqual(expectedString, actualString, "Original and encrypted->decrypted object do not match!");

                /******* X509 + RSA test ******/
                // encrypt (without needing a private key)
                var x509CertPubl = new X509Certificate2(X509Certificate.CreateFromCertFile("encrypterTests/publickey.cer"));
                using (var xasyEnc = new X509AsymmetricEncrypter(x509CertPubl))// encrypter needs no private key!
                {
                    eo = xasyEnc.Encrypt(bo);
                }
                // decrypt (using a private key)
                AsymmetricCipherKeyPair keyPair;
                using (var reader = File.OpenText(@"encrypterTests/privatekey.pem")) // file containing RSA PKCS1 private key
                {
                    keyPair = (AsymmetricCipherKeyPair)new PemReader(reader).ReadObject();
                }

                // openssl genrsa -out privatekey.pem 2048
                // openssl req -new -x509 -key privatekey.pem -out publickey.cer -days 3650

                using (var xasydec = new X509AsymmetricEncrypter(keyPair.Private))
                {
                    boDecrypted = xasydec.Decrypt(eo);
                }
                expectedString = JsonConvert.SerializeObject(bo);
                actualString = JsonConvert.SerializeObject(boDecrypted);
                Assert.IsTrue(expectedString == actualString, "Original and encrypted->decrypted object do not match!");

                /********** X509 + RSA multiple recipients *******/
                var x509CertPubl2 = new X509Certificate2(X509Certificate.CreateFromCertFile("encrypterTests/publickey2.cer"));
                EncryptedObject eoMultiple;
                using (var xasyEncMultiple = new X509AsymmetricEncrypter(new HashSet<X509Certificate2> { x509CertPubl, x509CertPubl2 })) // encrypter needs not private key!
                {
                    eoMultiple = xasyEncMultiple.Encrypt(bo);
                }

                // decrypt (using both private keys)
                AsymmetricCipherKeyPair keyPair2;
                using (var reader = File.OpenText(@"encrypterTests/privatekey2.pem")) // file containing RSA PKCS1 private key
                {
                    keyPair2 = (AsymmetricCipherKeyPair)new PemReader(reader).ReadObject();
                }

                using (var xasydecMultiple = new X509AsymmetricEncrypter(keyPair.Private))
                {
                    using var xasydecMultiple2 = new X509AsymmetricEncrypter(keyPair2.Private);
                    boDecrypted = xasydecMultiple.Decrypt(eoMultiple);
                    var boDecrypted2 = xasydecMultiple2.Decrypt(eoMultiple);
                    var actualString2 = JsonConvert.SerializeObject(boDecrypted2);
                    Assert.AreEqual(expectedString, actualString2, "Original and encrypted->decrypted object do not match!");
                }
                expectedString = JsonConvert.SerializeObject(bo);
                actualString = JsonConvert.SerializeObject(boDecrypted);
                Assert.AreEqual(expectedString, actualString, "Original and encrypted->decrypted object do not match!");
            }
        }

        [TestMethod]
        public void TestKeysFromBase64()
        {
            AsymmetricCipherKeyPair expectedPrivate;
            using (var reader = File.OpenText(@"encrypterTests/privatekey2.pem")) // file containing RSA PKCS1 private key
            {
                expectedPrivate = (AsymmetricCipherKeyPair)new PemReader(reader).ReadObject();
            }
            var actualPrivate = X509AsymmetricEncrypter.PrivateBase64KeyToACKP("MIIEpAIBAAKCAQEAydkev6usDL3Bc8nf5olqLlVXCYTRNYoTeUiTD/+CDynW+dU4redtTEkHy4YHJ0CAK82thV7DtAw52dR7/q/5/ZuvZzwtz30L+qhZSHKleTu7xxQrRhY2Tbrldxd1zbUbAjBHL4EUTbASTmojKCXEvG1U+jYRhfoCX8KRW/2AfhmQtvHmEVomRFUFy2tC5i6oS5l7YzM0j4hPQSj6FyWGLDHrLQ61kx8VTEdt6nH9Gr5S5DMUWyuscXwNJe6LK8WJNUwszI/MYwl4AFLVVy1w3DdL2UFuwyaZHLu5Tmn18Sx3yZWB0KUE3jwZ9q1v1zo05qcYJ8NbxdWZwygRE8tsHQIDAQABAoIBABP5JR7ISQUVvc/MWRiB3nzpOuyZNO58VEL7GHpLyT3g4QHlxG8I6HrU+y17fLe4nTY4awQ4hVsKnqrcaMyh8zXSMwAfJ1VRxV6vS+5sUc12SLWBXGraBdOZO92V97U8R4jm6BReTHkHhDg4LnRpkFco5nC/6un7/EIniaS1qAJSLk9NT3O+Nj7l+KTq3IVm9fDHnjEh+tmqTpJDWZZdyhTXZic2kD548Y1MeKDkH5n29/olmbz3n8aaNgf8MwEqjgurluMtkpE+UKB3TLDYZ2Im7kHyrD65vMuEcddkS8PT3l/vddt2dN6MHn4cTRsBOPF5k1CTglzVYd0R8TFZK00CgYEA5a98QQXlz7ZeV2dF1cBsRyYMyHSusK1gHHRUvyletRLe9Z//gnE/4a67B5YJ/UTDZgf7W5pH8v1ifBdY5rK54sWF4uPnupWUcsS0zM6Lxc7NreK08HR//yqiBeFKLZO1aBrSIcemG0T0801Fn2XgeLz+FQvwFEDu/ZKOuJnYsxcCgYEA4PkvMLUsfiTzG2NWM3aMDCBRF3x3LE0C9qf2OYTV1uB/4fyCsAg0jBIopcC8xhRUTPCGXKJcSxwmBBTaIhwO4Phf/DC4lJfGWHTSDl7SsB9wyRNKNL+NUPwJ75f9RlPEvdFZtPNPqqyfGfEFyZn1RXihcOyUb7s6vqx7QTa06usCgYEAxF+k/HLuaQii4FeLfZVm/e2qQDiCosuYwLs1ObtFHctklNyWuA/bbjjV70Z4g/GmnjV00ny1xyqcaTwM5jEofJokPjhch0ocAYPskK6HEjgd4e1ShcMVLDRnEl/r68u97aQAxKDNg8MRKnOGcyHHKXNsSNJMEQTzUBldrLbcb0ECgYEAn4f0L7z5rQX0ooJBmULCMsMj3dy0AWUm6dPXJZiNrs8JwC24Wq2m3YDu9AMFmgzGbrzM+pljixuN1a0XtcJhxqQ6JHJEIZKy4v0MC4awLpZM+zlDkL4YrsnbHdyQjLNQOy5eR5OV9bhtJg8lBH25UKcnDBWneMey840J5geuKTsCgYBg4g2cz7OH+lQMlc/xECl0h4hPDV4V1R7oL1VH/qmMeeHe0rCx7/a8sAWjWVNQal/8R3dT/7/Ct6SPIc2WJ0UG/robSw0Ii/YG9iLYImF0IdHgPGxvjjmRvfxrToeWvTlzaStH4MLNPB6TRi18mlS5WUaNQcOQGDh4jypmhlic+Q==");
            Assert.AreEqual(expectedPrivate.Private, actualPrivate.Private);
        }

        [TestMethod]
        public void TestLogObjectDecryption()
        {
            //byte[] publicKey = Convert.FromBase64String("C1RpdN5DO86swpkegPxEMB60yVSXYLta6PfSnHuYpxA=");
            var privateKey = Convert.FromBase64String("7BSU9FLrvo8hSk58fs/vHTN4fmRFYbwvI9ZRKmTDt/o=");
            try
            {
                EncryptedObject eo = JsonConvert.DeserializeObject<EncryptedObjectPublicKeyBox>("{\"versionStruktur\":1,\"boTyp\":\"ENCRYPTEDOBJECTPUBLICKEYBOX\",\"encryptionScheme\":1,\"nonce\":\"YRmjJpSb7irazqWbCwWvNWKlApIjGiRh\",\"cipherText\":\"H315B/1ualMyzg882cXXB2I8Ol19bQQ1RlzohUXIGvbY7xCtkVuZZXmTI3Ff1GLf7NoymoQKqW50k2jmBTsoSmFWhPwKxDlW9vdS71fzuJTXSgfEmXWEhez2cMuNo0CRP/jgWDDUDmu5R5jz0bB+/FxZECOfYR4WFuvTz4jM+G8=\",\"publicKey\":\"enRUmVbcBbnneJCnvaU+ldANIDc/wGfqTUVCtSkVwhU=\"}");
                Encrypter dec = new AsymmetricEncrypter(privateKey);
                var bo = dec.Decrypt(eo);
                Assert.IsInstanceOfType(bo, typeof(LogObject));
            }
            catch (JsonSerializationException)
            {
                // ToDo: add required attribute ID to json plain text before encryption.
            }
        }
    }
}
