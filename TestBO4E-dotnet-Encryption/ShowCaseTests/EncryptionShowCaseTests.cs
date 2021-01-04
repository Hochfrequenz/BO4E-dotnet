using System;
using System.Diagnostics;

using BO4E.BO;
using BO4E.COM;
using BO4E.ENUM;
using BO4E.Extensions.Encryption;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TestBO4E.ShowCaseTests
{
    [TestClass]
    public class EncryptionShowCaseTests
    {
        protected static readonly Marktlokation MaLo = new Marktlokation()
        {
            MarktlokationsId = "54321098765",
            Sparte = Sparte.STROM,
            Energierichtung = Energierichtung.AUSSP,
            Bilanzierungsmethode = Bilanzierungsmethode.SLP,
            Netzebene = Netzebene.NSP,
            Lokationsadresse = new Adresse()
            {
                Postleitzahl = "82031",
                Ort = "Grünwald",
                Strasse = "Nördliche Münchner Straße",
                Hausnummer = "27A",
                Landescode = Landescode.DE,
            }
        };

        [TestMethod]
        public void ShowCaseTestSymmetric()
        {
            Assert.IsTrue(MaLo.IsValid()); // as the encryption relies on serializing the BO invalid BOs cannot be encrypted.

            var sharedSecret = Sodium.SecretBox.GenerateKey();
            EncryptedObject encryptedBo;
            using (var encrypter = new SymmetricEncrypter(sharedSecret))
            {
                encryptedBo = encrypter.Encrypt(MaLo, "test case");
            }
            Debug.Write(JsonConvert.SerializeObject(encryptedBo, new StringEnumConverter()));
            //{
            //  "boTyp": "ENCRYPTEDOBJECTAEAD",
            //  "versionStruktur": 1,
            //  "AssociatedData": "test case",
            //  "encryptionScheme": "SodiumSymmetricAEAD",
            //  "nonce": "hTbQKm/hAwY=",
            //  "cipherText": "iORhQsADEviVhjDP3d ... fnGfLF+AsL1F"
            //}

            Marktlokation decryptedMaLo;
            using (var decrypter = new SymmetricEncrypter(sharedSecret))
            {
                decryptedMaLo = decrypter.Decrypt<Marktlokation>(encryptedBo);
            }
            Assert.AreEqual(MaLo.Lokationsadresse, decryptedMaLo.Lokationsadresse);
        }

        [TestMethod]
        public void ShowCaseTestAsymmetric()
        {
            Assert.IsTrue(MaLo.IsValid()); // as the encryption relies on serializing the BO invalid BOs cannot be encrypted.

            var aliceKeyPair = Sodium.PublicKeyBox.GenerateKeyPair();
            var bobKeyPair = Sodium.PublicKeyBox.GenerateKeyPair();

            Debug.WriteLine($"Bob: Hey @Alice, this is my public key: {Convert.ToBase64String(bobKeyPair.PublicKey).Substring(10)}...");
            // Bob: Hey @Alice, this is my public key: HsGsYigFqgDouUvUW3uMYpy54DqsAxXxQ=...

            EncryptedObject encryptedBo;
            using (var aliceEncrypter = new AsymmetricEncrypter(aliceKeyPair))
            {
                encryptedBo = aliceEncrypter.Encrypt(MaLo, Convert.ToBase64String(bobKeyPair.PublicKey));
            }
            Debug.WriteLine($"Alice: Hey @Bob: This is my signed and encrypted BusinssObject: ");
            Debug.WriteLine(JsonConvert.SerializeObject(encryptedBo, new StringEnumConverter()));
            //{
            //  "boTyp": "ENCRYPTEDOBJECTPUBLICKEYBOX",
            //  "versionStruktur": 1,
            //  "publicKey": "jpo2D3IK9BgPOLyXPfimfSD3u9VErT3kP5IYDMVY0Bo=",
            //  "encryptionScheme": "SodiumAsymmetricPublicKeyBox",
            //  "nonce": "KdNf7rQlQzOyajX+nMKBROce9odVuJqF",
            //  "cipherText": "VIYM7nZU9yTSj2tT...zWUuGbp4HphTlBlzgK"
            //}
            Debug.WriteLine($"Alice: And by the way, I hope you verified my fingerprint or the key itself.");
            Assert.AreEqual(Convert.ToBase64String(aliceKeyPair.PublicKey), ((EncryptedObjectPublicKeyBox)encryptedBo).PublicKey, "Bob: I did, otherwise this would fail");

            Marktlokation decryptedMaLo;
            using (var bobsDecrypter = new AsymmetricEncrypter(bobKeyPair.PrivateKey))
            {
                var decryptedBo = bobsDecrypter.Decrypt(encryptedBo); // In case Bob had no idea what alice sent him...
                Assert.IsInstanceOfType(decryptedBo, typeof(Marktlokation)); // ...now he knows.
                decryptedMaLo = bobsDecrypter.Decrypt<Marktlokation>(encryptedBo); // Bob knows at compile time it's a MaLo.
            }
            Assert.AreEqual(MaLo, decryptedMaLo);

            var eveKeyPair = Sodium.PublicKeyBox.GenerateKeyPair();
            // Eve entered the chat
            EncryptedObjectPublicKeyBox manipulatedBo;
            using (var eveEncrypter = new AsymmetricEncrypter(eveKeyPair))
            {
                manipulatedBo = eveEncrypter.Encrypt(MaLo, Convert.ToBase64String(bobKeyPair.PublicKey));
            }
            manipulatedBo.PublicKey = Convert.ToBase64String(aliceKeyPair.PublicKey); // Eve: Never will Bob know this message is not from Alice!
            Debug.WriteLine("Eve: Hey @Bob, Alice asked me to give you this BO");

            Assert.AreEqual(Convert.ToBase64String(aliceKeyPair.PublicKey), manipulatedBo.PublicKey, "Bob: Hrm, seems like it's from Alice, indeed...");
            using (var bobsDecrypter = new AsymmetricEncrypter(bobKeyPair.PrivateKey))
            {
                try
                {
                    bobsDecrypter.Decrypt(manipulatedBo);
                }
                catch (System.Security.Cryptography.CryptographicException ce)
                {
                    Debug.WriteLine($"Bob: @Eve: You tried to fool me! {ce.Message}");
                    // As long as Bob checks that the public key stored in the Encrypted Business Object matches the public key of the expected sender he'll be fine.
                }
            }
        }

        // This extension package also provides X509 certificate based encryption. Even 1 sender, multiple receivers with just 1 business object!
        // To learn more please check out TestEncrypter.cs --> TestBOEncryption
    }
}
