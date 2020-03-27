using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using BO4E.BO;
using BO4E.COM;
using BO4E.Extensions.Encryption;
using BO4E.meta;
using BO4E.Reporting;
using JsonDiffPatchDotNet;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.OpenSsl;

namespace TestBO4EExtensions.Encryption
{
    [TestClass]
    public class TestAnonymizer
    {

        [TestMethod]
        public void TestOperations()
        {
            BO4E.StaticLogger.Logger = new Microsoft.Extensions.Logging.Debug.DebugLogger("Testlogger", (log, level) => { return true; });
            string[] files = Directory.GetFiles($"anonymizerTests/masterdata/", "*.json"); // 
            foreach (string testFile in files)
            {
                JObject json;
                using (StreamReader r = new StreamReader(testFile))
                {
                    string jsonString = r.ReadToEnd();
                    json = JObject.Parse(jsonString);
                }

                BusinessObject bo;
                using (Anonymizer a = new Anonymizer(new AnonymizerConfiguration()))
                {
                    bo = JsonConvert.DeserializeObject<BusinessObject>(json["input"].ToString());
                    Assert.IsTrue(bo.Equals(a.ApplyOperations<BusinessObject>(bo)));
                }
                AnonymizerConfiguration ac = new AnonymizerConfiguration();
                HashSet<AnonymizerApproach> allApproaches = new HashSet<AnonymizerApproach>(); ;
                Dictionary<string, string> operations = JsonConvert.DeserializeObject<Dictionary<string, string>>(((JObject)json["operations"]).ToString());
                //Assert.AreEqual(json["input"].ToString(), resultJobject.ToString(), "Anonymizer without configuration should return the original message");
                foreach (string key in operations.Keys)
                {
                    Enum.TryParse(key, out DataCategory option);
                    Enum.TryParse(operations[key], out AnonymizerApproach approach);
                    Assert.IsNotNull(option, "Option invalid. Check test file " + testFile);
                    Assert.IsNotNull(approach, "Approach invalid, Check test file " + testFile);
                    ac.SetOption(option, approach);
                    allApproaches.Add(approach);
                }
                using (Anonymizer a = new Anonymizer(ac))
                {
                    if (ac.operations.ContainsValue(AnonymizerApproach.ENCRYPT))
                    {
                        X509Certificate2 x509certPubl = new X509Certificate2(X509Certificate2.CreateFromCertFile("anonymizerTests/certificates/publicX509Cert.crt"));
                        a.SetPublicKey(x509certPubl);
                    }
                    if (ac.operations.ContainsValue(AnonymizerApproach.HASH))
                    {
                        byte[] predefinedSalt = new byte[] { 0x20, 0x30, 0x40, 0x50, 0x60, 0x70, 0x80, 0x90 }; // only predefined for test case
                        a.SetHashingSalt(predefinedSalt);
                    }
                    JObject resultJobject = a.ApplyOperations<JObject>(JsonConvert.DeserializeObject<BusinessObject>(json["input"].ToString()));

                    if (allApproaches.Count == 1 && allApproaches.Contains(AnonymizerApproach.ENCRYPT))
                    {
                        // iff the file only contains encryption operations, we simple encrypt it once,
                        // decrypt the cipher text and assert they're equal. This complete reversion
                        // round trip is not possible if any other option like DELETE, REPLACE, HASH etc.
                        // is chosen.
                        AnonymizerConfiguration acInvert = new AnonymizerConfiguration();
                        foreach (string key in operations.Keys)
                        {
                            if (Enum.TryParse(operations[key], out AnonymizerApproach option))
                            {
                                if (Enum.TryParse(key, out DataCategory dc))
                                {
                                    acInvert.SetOption(dc, AnonymizerApproach.DECRYPT);
                                }
                            }
                        }
                        BusinessObject decryptedBo;
                        using (Anonymizer d = new Anonymizer(acInvert))
                        {
                            AsymmetricCipherKeyPair keyPair;
                            using (var reader = File.OpenText(@"anonymizerTests/certificates/privateKey.pem")) // file containing RSA PKCS1 private key
                            {
                                //Org.BouncyCastle.Crypto.Parameters.RsaPrivateCrtKeyParameters rpk = (Org.BouncyCastle.Crypto.Parameters.RsaPrivateCrtKeyParameters)new PemReader(reader).ReadObject();
                                keyPair = (AsymmetricCipherKeyPair)new PemReader(reader).ReadObject();
                            }
                            d.SetPrivateKey(keyPair.Private);
                            decryptedBo = d.ApplyOperations<BusinessObject>(resultJobject);
                        }
                        var jdp = new JsonDiffPatch(); // https://github.com/wbish/jsondiffpatch.net
                        JToken left, right;
                        left = JsonHelper.RemoveEmptyChildren(json["input"]);
                        right = JsonHelper.RemoveEmptyChildren(JObject.FromObject(decryptedBo));
                        var patch = jdp.Diff(left, right);
                        string additionalMessage = testFile;
                        if (patch != null)
                        {
                            additionalMessage = $";\r\n Diff: { patch.ToString()}";
                        }
                        // patch == null <--> jobjects match (except for key order)
                        Assert.IsNull(patch, $"Decryption failed: {testFile}{additionalMessage}");
                    }
                    else
                    {
                        //
                        // compare the processed result with a predefined json because the reversion
                        // round trip test is impossible
                        //
                        foreach (JProperty entry in json["assertions"])
                        {
                            string jsonpath = entry.Name;
                            var expectedResult = entry.Value;
                            JToken testResult = resultJobject.SelectToken(jsonpath);
                            if (expectedResult != null && expectedResult.ToString() == "{}")
                            {
                                expectedResult = null;
                            }
                            if ((expectedResult == null || !expectedResult.HasValues) && testResult == null)
                            {
                                continue;
                            }
                            else if (expectedResult == null && testResult != null)
                            {
                                Assert.AreEqual(expectedResult, testResult.ToString(), $"Path {jsonpath} in {testFile} returned value {testResult} where null was expected.");
                            }
                            else if (expectedResult != null && testResult == null)
                            {
                                Assert.AreEqual(expectedResult.ToString(), testResult, $"Path {jsonpath} in {testFile} returned null where {expectedResult} was expected.");
                            }
                            else
                            {
                                Assert.AreEqual(expectedResult.ToString(), testResult.ToString(), $"Path {jsonpath} in {testFile} didn't return the expected result {expectedResult} but instead {testResult}");
                            }
                        }
                    }
                }
            }
        }

        [TestMethod]
        public void TestAnonymizeEnergiemengeHashing()
        {
            BO4E.StaticLogger.Logger = new Microsoft.Extensions.Logging.Debug.DebugLogger("Testlogger", (log, level) => { return true; });
            Energiemenge em = new Energiemenge()
            {
                lokationsId = "DE0123456789012345678901234567890",
                lokationstyp = BO4E.ENUM.Lokationstyp.MeLo,
                energieverbrauch = new List<Verbrauch>()
               {
                   new Verbrauch()
                   {
                       Wert = 123.456M,
                       Wertermittlungsverfahren=BO4E.ENUM.Wertermittlungsverfahren.MESSUNG,
                       Startdatum=new DateTime(2019,1,1,0,0,0,DateTimeKind.Utc),
                       Enddatum = new DateTime(2019,2,1,0,0,0,DateTimeKind.Utc),
                       Obiskennzahl="1-2-3-4",
                       Einheit =BO4E.ENUM.Mengeneinheit.KWH
                   }
               }
            };
            var conf = new AnonymizerConfiguration();
            conf.SetOption(DataCategory.POD, AnonymizerApproach.HASH);
            conf.SetOption(DataCategory.USER_PROPERTIES, AnonymizerApproach.HASH);
            Anonymizer anonymizer = new Anonymizer(conf);
            var verbrauch2 = JsonConvert.DeserializeObject<Verbrauch>("{\"zw\":\"000000000000485549\",\"startdatum\":\"2018-03-24T01:45:00Z\",\"enddatum\":\"2018-03-24T02:00:00Z\",\"wert\":\"59\",\"status\":\"IU012\",\"obiskennzahl\":\"1-1:2.29.0\",\"wertermittlungsverfahren\":\"MESSUNG\",\"einheit\":\"KWH\"}");
            em.energieverbrauch.Add(verbrauch2);

            // hash everything
            var result = anonymizer.ApplyOperations<Energiemenge>(em);
            Assert.IsNotNull(result);
            Assert.AreNotEqual(em.lokationsId, result.lokationsId);
            Assert.IsTrue(Messlokation.ValidateId(result.lokationsId));
            Assert.AreEqual(em.energieverbrauch.Count, result.energieverbrauch.Count);
            Assert.IsNotNull(result.energieverbrauch[1].UserProperties["zw"]);
            Assert.AreNotEqual(em.energieverbrauch[1].UserProperties["zw"].Value<string>(), result.energieverbrauch[1].UserProperties["zw"].Value<string>());
            Assert.IsTrue(Anonymizer.HasHashedKey(result));

            // do not hash zw user property
            conf.unaffectedUserProperties.Add("zw");
            result = anonymizer.ApplyOperations<Energiemenge>(em);
            Assert.IsNotNull(result);
            Assert.AreNotEqual(em.lokationsId, result.lokationsId);
            Assert.IsTrue(Messlokation.ValidateId(result.lokationsId));
            Assert.AreEqual(em.energieverbrauch.Count, result.energieverbrauch.Count);
            Assert.IsNotNull(result.energieverbrauch[1].UserProperties["zw"]);
            Assert.AreEqual(em.energieverbrauch[1].UserProperties["zw"].Value<string>(), result.energieverbrauch[1].UserProperties["zw"].Value<string>());
            Assert.IsTrue(Anonymizer.HasHashedKey(result));
        }

        [TestMethod]
        public void TestAnonymizeEnergiemengeEncryptionRoundtrip()
        {
            BO4E.StaticLogger.Logger = new Microsoft.Extensions.Logging.Debug.DebugLogger("Testlogger", (log, level) => { return true; });
            Energiemenge em = new Energiemenge()
            {
                lokationsId = "DE0123456789012345678901234567890",
                lokationstyp = BO4E.ENUM.Lokationstyp.MeLo,
                energieverbrauch = new List<Verbrauch>()
               {
                   new Verbrauch()
                   {
                       Wert = 123.456M,
                       Wertermittlungsverfahren=BO4E.ENUM.Wertermittlungsverfahren.MESSUNG,
                       Obiskennzahl="1-2-3-4",
                       Einheit =BO4E.ENUM.Mengeneinheit.KWH
                   }
               }
            };

            //ENCRYPTION
            var encConf = new AnonymizerConfiguration();
            encConf.SetOption(DataCategory.POD, AnonymizerApproach.ENCRYPT);
            Energiemenge encryptedEm;
            using (Anonymizer anonymizer = new Anonymizer(encConf))
            {
                X509Certificate2 x509certPubl = new X509Certificate2(X509Certificate2.CreateFromCertFile("anonymizerTests/certificates/publicX509Cert.crt"));
                anonymizer.SetPublicKey(x509certPubl);
                encryptedEm = anonymizer.ApplyOperations<Energiemenge>(em);
            }

            //DECRYPTION
            var decConf = new AnonymizerConfiguration();
            decConf.SetOption(DataCategory.POD, AnonymizerApproach.DECRYPT);
            Energiemenge decryptedEm;
            using (Anonymizer decryptingAnonymizer = new Anonymizer(decConf))
            {
                AsymmetricCipherKeyPair keyPair;
                using (var reader = File.OpenText(@"anonymizerTests/certificates/privateKey.pem")) // file containing RSA PKCS1 private key
                {
                    keyPair = (AsymmetricCipherKeyPair)new PemReader(reader).ReadObject();
                }
                decryptingAnonymizer.SetPrivateKey(keyPair.Private);
                decryptedEm = decryptingAnonymizer.ApplyOperations<Energiemenge>(encryptedEm);
            }
            Assert.AreEqual(em.lokationsId, decryptedEm.lokationsId);
            Assert.IsFalse(Anonymizer.HasHashedKey(em));
        }

        [TestMethod]
        public void TestHashingDetectionForNonconformingString()
        {
            BO4E.StaticLogger.Logger = new Microsoft.Extensions.Logging.Debug.DebugLogger("Testlogger", (log, level) => { return true; });
            Energiemenge em = new Energiemenge()
            {
                lokationsId = "asdkasldkmaslkdmas", // not identifyable as lokationsId
                lokationstyp = BO4E.ENUM.Lokationstyp.MeLo,
                energieverbrauch = new List<Verbrauch>()
            };
            Assert.IsFalse(Anonymizer.HasHashedKey(em));

            var hashConf = new AnonymizerConfiguration();
            hashConf.SetOption(DataCategory.POD, AnonymizerApproach.HASH);
            Energiemenge hashedEm;
            using (var a = new Anonymizer(hashConf))
            {
                hashedEm = a.ApplyOperations<Energiemenge>(em);
            }
            Assert.IsTrue(Anonymizer.HasHashedKey(hashedEm));
        }

        [TestMethod]
        public void TestCompletenessReportHashing()
        {
            BO4E.StaticLogger.Logger = new Microsoft.Extensions.Logging.Debug.DebugLogger("Testlogger", (log, level) => { return true; });
            CompletenessReport cr = new CompletenessReport()
            {
                lokationsId = "56789012345",
                coverage = 0.9M,
                einheit = BO4E.ENUM.Mengeneinheit.MWH,
                wertermittlungsverfahren = BO4E.ENUM.Wertermittlungsverfahren.MESSUNG,
                UserProperties = new Dictionary<string, JToken>()
                {
                    { "anlage", "5012345678" },
                    { "profil", "123456" }
                }
            };
            Assert.IsTrue(cr.IsValid());
            var conf = new AnonymizerConfiguration();
            conf.SetOption(DataCategory.POD, AnonymizerApproach.HASH);
            conf.SetOption(DataCategory.USER_PROPERTIES, AnonymizerApproach.HASH);
            CompletenessReport hashedReport;
            using (Anonymizer anonymizer = new Anonymizer(conf))
            {
                hashedReport = anonymizer.ApplyOperations<CompletenessReport>(cr);
            }
            Assert.IsNotNull(hashedReport);
            Assert.AreNotEqual(cr.lokationsId, hashedReport.lokationsId);
            Assert.IsTrue(Marktlokation.ValidateId(hashedReport.lokationsId));
            Assert.IsNotNull(cr.UserProperties["anlage"]);
            Assert.AreNotEqual(cr.UserProperties["anlage"].Value<string>(), hashedReport.UserProperties["anlage"].Value<string>());
            Assert.IsNotNull(cr.UserProperties["profil"]);
            Assert.AreNotEqual(cr.UserProperties["profil"].Value<string>(), hashedReport.UserProperties["profil"].Value<string>());

            conf.hashingSalt = "TWFuIGlzIGRpc3Rpbmd1aXNoZWQsIG5vdCBvbmx5IGJ5IGhpcyByZWFzb24sIGJ1dCBieSB0aGlzIHNpbmd1bGFyIHBhc3Npb24gZnJvbSBvdGhlciBhbmltYWxzLCB3aGljaCBpcyBhIGx1c3Qgb2YgdGhlIG1pbmQsIHRoYXQgYnkgYSBwZXJzZXZlcmFuY2Ugb2YgZGVsaWdodCBpbiB0aGUgY29udGludWVkIGFuZCBpbmRlZmF0aWdhYmxlIGdlbmVyYXRpb24gb2Yga25vd2xlZGdlLCBleGNlZWRzIHRoZSBzaG9ydCB2ZWhlbWVuY2Ugb2YgYW55IGNhcm5hbCBwbGVhc3VyZS4=";
            CompletenessReport saltedReport;
            using (Anonymizer anonymizer = new Anonymizer(conf))
            {
                saltedReport = anonymizer.ApplyOperations<CompletenessReport>(cr);
            }
            Assert.IsNotNull(saltedReport.lokationsId);
            Assert.AreNotEqual(cr.lokationsId, saltedReport.lokationsId);
            Assert.AreNotEqual(hashedReport.lokationsId, saltedReport.lokationsId);

            Assert.IsTrue(Anonymizer.IsHashedKey(hashedReport.lokationsId));
            Assert.IsTrue(Anonymizer.IsHashedKey(saltedReport.lokationsId));
        }

        [TestMethod]
        public void TestSameHashDifferentObjectTypes()
        {
            BO4E.StaticLogger.Logger = new Microsoft.Extensions.Logging.Debug.DebugLogger("Testlogger", (log, level) => { return true; });
            Energiemenge em = new Energiemenge()
            {
                lokationsId = "DE0123456789012345678901234567890",
                lokationstyp = BO4E.ENUM.Lokationstyp.MeLo,
                energieverbrauch = new List<Verbrauch>()
               {
                   new Verbrauch()
                   {
                       Wert = 123.456M,
                       Wertermittlungsverfahren=BO4E.ENUM.Wertermittlungsverfahren.MESSUNG,
                       Startdatum=new DateTime(2019,1,1,0,0,0,DateTimeKind.Utc),
                       Enddatum = new DateTime(2019,2,1,0,0,0,DateTimeKind.Utc),
                       Obiskennzahl="1-2-3-4",
                       Einheit =BO4E.ENUM.Mengeneinheit.KWH
                   }
               }
            };
            Assert.IsTrue(em.IsValid());

            Messlokation melo = new Messlokation()
            {
                messlokationsId = "DE0123456789012345678901234567890"
            };
            Assert.IsTrue(melo.IsValid());

            var conf = new AnonymizerConfiguration();
            conf.SetOption(DataCategory.POD, AnonymizerApproach.HASH);

            using Anonymizer anonymizer = new Anonymizer(conf);
            var hashedEm = anonymizer.ApplyOperations<Energiemenge>(em);
            var hashedMelo = anonymizer.ApplyOperations<Messlokation>(melo);
            Assert.AreEqual(hashedEm.lokationsId, hashedMelo.messlokationsId);
        }

        [TestMethod]
        public void TestCaginMeLos()
        {
            BO4E.StaticLogger.Logger = new Microsoft.Extensions.Logging.Debug.DebugLogger("Testlogger", (log, level) => { return true; });
            var result = new Dictionary<string, string>() {
                {"DE0004096816110000000000000022591", null },
                {"DE0004946353300000000000001652988", null },
                {"DE00746663128OF000000000000010156", null },
                {"DE0004946307100000000000001312595", null },
            };
            var conf = new AnonymizerConfiguration();
            conf.SetOption(DataCategory.POD, AnonymizerApproach.HASH);

            using (Anonymizer anonymizer = new Anonymizer(conf))
            {
                foreach (var plaintextMeLoId in result.Keys.ToList())
                {
                    Messlokation melo = new Messlokation()
                    {
                        messlokationsId = plaintextMeLoId
                    };
                    var hashedMelo = anonymizer.ApplyOperations<Messlokation>(melo);
                    result[plaintextMeLoId] = hashedMelo.messlokationsId;
                }
            }
            var resultJson = JsonConvert.SerializeObject(result);
        }
    }
}