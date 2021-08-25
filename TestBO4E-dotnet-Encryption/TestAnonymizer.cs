﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using BO4E;
using BO4E.BO;
using BO4E.COM;
using BO4E.Encryption;
using BO4E.ENUM;
using BO4E.meta;
using BO4E.Reporting;
using JsonDiffPatchDotNet;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.OpenSsl;

namespace TestBO4E.Encryption
{
    [TestClass]
    public class TestAnonymizer
    {
        [TestMethod]
        public void TestOperations()
        {
            StaticLogger.Logger = NullLogger.Instance;
            var files = Directory.GetFiles("anonymizerTests/masterdata/", "*.json"); // 
            foreach (var testFile in files)
            {
                JObject json;
                using (var r = new StreamReader(testFile))
                {
                    var jsonString = r.ReadToEnd();
                    json = JObject.Parse(jsonString);
                }

                BusinessObject bo;
                using (var a = new Anonymizer(new AnonymizerConfiguration()))
                {
                    bo = JsonConvert.DeserializeObject<BusinessObject>(json["input"].ToString());
                    Assert.IsTrue(bo.Equals(a.ApplyOperations<BusinessObject>(bo)));
                }

                var ac = new AnonymizerConfiguration();
                var allApproaches = new HashSet<AnonymizerApproach>();
                var operations =
                    JsonConvert.DeserializeObject<Dictionary<string, string>>(((JObject)json["operations"])
                        .ToString());
                //Assert.AreEqual(json["input"].ToString(), resultJobject.ToString(), "Anonymizer without configuration should return the original message");
                foreach (var key in operations.Keys)
                {
                    Enum.TryParse(key, out DataCategory option);
                    Enum.TryParse(operations[key], out AnonymizerApproach approach);
                    Assert.IsNotNull(option, "Option invalid. Check test file " + testFile);
                    Assert.IsNotNull(approach, "Approach invalid, Check test file " + testFile);
                    ac.SetOption(option, approach);
                    allApproaches.Add(approach);
                }

                using (var a = new Anonymizer(ac))
                {
                    if (ac.Operations.ContainsValue(AnonymizerApproach.ENCRYPT))
                    {
                        var x509certPubl = new X509Certificate2(
                            X509Certificate.CreateFromCertFile("anonymizerTests/certificates/publicX509Cert.crt"));
                        a.SetPublicKey(x509certPubl);
                    }

                    if (ac.Operations.ContainsValue(AnonymizerApproach.HASH))
                    {
                        var predefinedSalt = new byte[]
                            {0x20, 0x30, 0x40, 0x50, 0x60, 0x70, 0x80, 0x90}; // only predefined for test case
                        a.SetHashingSalt(predefinedSalt);
                    }

                    var resultJobject =
                        a.ApplyOperations<JObject>(
                            JsonConvert.DeserializeObject<BusinessObject>(json["input"].ToString()));

                    if (allApproaches.Count == 1 && allApproaches.Contains(AnonymizerApproach.ENCRYPT))
                    {
                        // iff the file only contains encryption operations, we simple encrypt it once,
                        // decrypt the cipher text and assert they're equal. This complete reversion
                        // round trip is not possible if any other option like DELETE, REPLACE, HASH etc.
                        // is chosen.
                        var acInvert = new AnonymizerConfiguration();
                        foreach (var key in operations.Keys)
                            if (Enum.TryParse(operations[key], out AnonymizerApproach _))
                                if (Enum.TryParse(key, out DataCategory dc))
                                    acInvert.SetOption(dc, AnonymizerApproach.DECRYPT);
                        BusinessObject decryptedBo;
                        using (var d = new Anonymizer(acInvert))
                        {
                            AsymmetricCipherKeyPair keyPair;
                            using (var reader =
                                File.OpenText(
                                    @"anonymizerTests/certificates/privateKey.pem")) // file containing RSA PKCS1 private key
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
                        var additionalMessage = testFile;
                        if (patch != null) additionalMessage = $";\r\n Diff: {patch}";
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
                            var jsonpath = entry.Name;
                            var expectedResult = entry.Value;
                            var testResult = resultJobject.SelectToken(jsonpath);
                            if (expectedResult != null && expectedResult.ToString() == "{}") expectedResult = null;
                            if ((expectedResult == null || !expectedResult.HasValues) && testResult == null) continue;

                            if (expectedResult == null)
                                Assert.AreEqual(expectedResult, testResult.ToString(),
                                    $"Path {jsonpath} in {testFile} returned value {testResult} where null was expected.");
                            else if (testResult == null)
                                Assert.AreEqual(expectedResult.ToString(), testResult,
                                    $"Path {jsonpath} in {testFile} returned null where {expectedResult} was expected.");
                            else
                                Assert.AreEqual(expectedResult.ToString(), testResult.ToString(),
                                    $"Path {jsonpath} in {testFile} didn't return the expected result {expectedResult} but instead {testResult}");
                        }
                    }
                }
            }
        }

        [TestMethod]
        public void TestAnonymizeEnergiemengeHashing()
        {
            StaticLogger.Logger = NullLogger.Instance;
            var em = new Energiemenge
            {
                LokationsId = "DE0123456789012345678901234567890",
                LokationsTyp = Lokationstyp.MeLo,
                Energieverbrauch = new List<Verbrauch>
                {
                    new Verbrauch
                    {
                        Wert = 123.456M,
                        Wertermittlungsverfahren = Wertermittlungsverfahren.MESSUNG,
                        Startdatum = new DateTimeOffset(2019, 1, 1, 0, 0, 0, TimeSpan.Zero).UtcDateTime,
                        Enddatum = new DateTimeOffset(2019, 2, 1, 0, 0, 0, TimeSpan.Zero).UtcDateTime,
                        Obiskennzahl = "1-2-3-4",
                        Einheit = Mengeneinheit.KWH
                    }
                }
            };
            var conf = new AnonymizerConfiguration();
            conf.SetOption(DataCategory.POD, AnonymizerApproach.HASH);
            conf.SetOption(DataCategory.USER_PROPERTIES, AnonymizerApproach.HASH);
            var anonymizer = new Anonymizer(conf);
            var verbrauch2 = JsonConvert.DeserializeObject<Verbrauch>(
                "{\"zw\":\"000000000000485549\",\"startdatum\":\"2018-03-24T01:45:00Z\",\"enddatum\":\"2018-03-24T02:00:00Z\",\"wert\":\"59\",\"status\":\"IU012\",\"obiskennzahl\":\"1-1:2.29.0\",\"wertermittlungsverfahren\":\"MESSUNG\",\"einheit\":\"KWH\"}");
            em.Energieverbrauch.Add(verbrauch2);

            // hash everything
            var result = anonymizer.ApplyOperations<Energiemenge>(em);
            Assert.IsNotNull(result);
            Assert.AreNotEqual(em.LokationsId, result.LokationsId);
            Assert.IsTrue(Messlokation.ValidateId(result.LokationsId));
            Assert.AreEqual(em.Energieverbrauch.Count, result.Energieverbrauch.Count);
            Assert.IsTrue(result.Energieverbrauch[1].TryGetUserProperty("zw", out string hashed_zw));
            em.Energieverbrauch[1].TryGetUserProperty("zw", out string hashed_em_zw);
            Assert.AreNotEqual(hashed_zw, hashed_em_zw);
            Assert.IsTrue(Anonymizer.HasHashedKey(result));

            // do not hash zw user property
            conf.UnaffectedUserProperties.Add("zw");
            result = anonymizer.ApplyOperations<Energiemenge>(em);
            Assert.IsNotNull(result);
            Assert.AreNotEqual(em.LokationsId, result.LokationsId);
            Assert.IsTrue(Messlokation.ValidateId(result.LokationsId));
            Assert.AreEqual(em.Energieverbrauch.Count, result.Energieverbrauch.Count);
            Assert.IsTrue(result.Energieverbrauch[1].TryGetUserProperty("zw", out string zw));
            em.Energieverbrauch[1].TryGetUserProperty("zw", out string em_zw);
            Assert.AreEqual(zw, em_zw);
            Assert.IsTrue(Anonymizer.HasHashedKey(result));
        }

        [TestMethod]
        public void TestAnonymizeEnergiemengeEncryptionRoundtrip()
        {
            StaticLogger.Logger = NullLogger.Instance;
            var em = new Energiemenge
            {
                LokationsId = "DE0123456789012345678901234567890",
                LokationsTyp = Lokationstyp.MeLo,
                Energieverbrauch = new List<Verbrauch>
                {
                    new Verbrauch
                    {
                        Wert = 123.456M,
                        Wertermittlungsverfahren = Wertermittlungsverfahren.MESSUNG,
                        Obiskennzahl = "1-2-3-4",
                        Einheit = Mengeneinheit.KWH
                    }
                }
            };

            //ENCRYPTION
            var encConf = new AnonymizerConfiguration();
            encConf.SetOption(DataCategory.POD, AnonymizerApproach.ENCRYPT);
            Energiemenge encryptedEm;
            using (var anonymizer = new Anonymizer(encConf))
            {
                var x509certPubl =
                    new X509Certificate2(
                        X509Certificate.CreateFromCertFile("anonymizerTests/certificates/publicX509Cert.crt"));
                anonymizer.SetPublicKey(x509certPubl);
                encryptedEm = anonymizer.ApplyOperations<Energiemenge>(em);
            }

            //DECRYPTION
            var decConf = new AnonymizerConfiguration();
            decConf.SetOption(DataCategory.POD, AnonymizerApproach.DECRYPT);
            Energiemenge decryptedEm;
            using (var decryptingAnonymizer = new Anonymizer(decConf))
            {
                AsymmetricCipherKeyPair keyPair;
                using (var reader =
                    File.OpenText(
                        @"anonymizerTests/certificates/privateKey.pem")) // file containing RSA PKCS1 private key
                {
                    keyPair = (AsymmetricCipherKeyPair)new PemReader(reader).ReadObject();
                }

                decryptingAnonymizer.SetPrivateKey(keyPair.Private);
                decryptedEm = decryptingAnonymizer.ApplyOperations<Energiemenge>(encryptedEm);
            }

            Assert.AreEqual(em.LokationsId, decryptedEm.LokationsId);
            Assert.IsFalse(Anonymizer.HasHashedKey(em));
        }

        [TestMethod]
        public void TestHashingDetectionForNonconformingString()
        {
            StaticLogger.Logger = NullLogger.Instance;
            var em = new Energiemenge
            {
                LokationsId = "asdkasldkmaslkdmas", // not identifyable as lokationsId
                LokationsTyp = Lokationstyp.MeLo,
                Energieverbrauch = new List<Verbrauch>()
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
            StaticLogger.Logger = NullLogger.Instance;
            var cr = new CompletenessReport
            {
                LokationsId = "56789012345",
                Coverage = 0.9M,
                Einheit = Mengeneinheit.MWH,
                Wertermittlungsverfahren = Wertermittlungsverfahren.MESSUNG,
                UserProperties = new Dictionary<string, object>
                {
                    {"anlage", "5012345678"},
                    {"profil", "123456"}
                }
            };
            Assert.IsTrue(cr.IsValid());
            var conf = new AnonymizerConfiguration();
            conf.SetOption(DataCategory.POD, AnonymizerApproach.HASH);
            conf.SetOption(DataCategory.USER_PROPERTIES, AnonymizerApproach.HASH);
            CompletenessReport hashedReport;
            using (var anonymizer = new Anonymizer(conf))
            {
                hashedReport = anonymizer.ApplyOperations<CompletenessReport>(cr);
            }

            Assert.IsNotNull(hashedReport);
            Assert.AreNotEqual(cr.LokationsId, hashedReport.LokationsId);
            Assert.IsTrue(Marktlokation.ValidateId(hashedReport.LokationsId));
            Assert.IsNotNull(cr.UserProperties["anlage"]);
            cr.TryGetUserProperty("anlage", out string cr_anlage);
            hashedReport.TryGetUserProperty("anlage", out string hashed_anlage);
            Assert.AreNotEqual(cr_anlage, hashed_anlage);
            cr.TryGetUserProperty("profil", out string cr_profil);
            hashedReport.TryGetUserProperty("profil", out string hashed_profil);
            Assert.IsNotNull(cr.UserProperties["profil"]);
            Assert.AreNotEqual(cr_profil, hashed_profil);

            conf.HashingSalt =
                "TWFuIGlzIGRpc3Rpbmd1aXNoZWQsIG5vdCBvbmx5IGJ5IGhpcyByZWFzb24sIGJ1dCBieSB0aGlzIHNpbmd1bGFyIHBhc3Npb24gZnJvbSBvdGhlciBhbmltYWxzLCB3aGljaCBpcyBhIGx1c3Qgb2YgdGhlIG1pbmQsIHRoYXQgYnkgYSBwZXJzZXZlcmFuY2Ugb2YgZGVsaWdodCBpbiB0aGUgY29udGludWVkIGFuZCBpbmRlZmF0aWdhYmxlIGdlbmVyYXRpb24gb2Yga25vd2xlZGdlLCBleGNlZWRzIHRoZSBzaG9ydCB2ZWhlbWVuY2Ugb2YgYW55IGNhcm5hbCBwbGVhc3VyZS4=";
            CompletenessReport saltedReport;
            using (var anonymizer = new Anonymizer(conf))
            {
                saltedReport = anonymizer.ApplyOperations<CompletenessReport>(cr);
            }

            Assert.IsNotNull(saltedReport.LokationsId);
            Assert.AreNotEqual(cr.LokationsId, saltedReport.LokationsId);
            Assert.AreNotEqual(hashedReport.LokationsId, saltedReport.LokationsId);

            Assert.IsTrue(Anonymizer.IsHashedKey(hashedReport.LokationsId));
            Assert.IsTrue(Anonymizer.IsHashedKey(saltedReport.LokationsId));
        }

        [TestMethod]
        public void TestSameHashDifferentObjectTypes()
        {
            StaticLogger.Logger = NullLogger.Instance;
            var em = new Energiemenge
            {
                LokationsId = "DE0123456789012345678901234567890",
                LokationsTyp = Lokationstyp.MeLo,
                Energieverbrauch = new List<Verbrauch>
                {
                    new Verbrauch
                    {
                        Wert = 123.456M,
                        Wertermittlungsverfahren = Wertermittlungsverfahren.MESSUNG,
                        Startdatum = new DateTimeOffset(2019, 1, 1, 0, 0, 0, TimeSpan.Zero).UtcDateTime,
                        Enddatum = new DateTimeOffset(2019, 2, 1, 0, 0, 0, TimeSpan.Zero).UtcDateTime,
                        Obiskennzahl = "1-2-3-4",
                        Einheit = Mengeneinheit.KWH
                    }
                }
            };
            Assert.IsTrue(em.IsValid());

            var melo = new Messlokation
            {
                MesslokationsId = "DE0123456789012345678901234567890"
            };
            Assert.IsTrue(melo.IsValid());

            var conf = new AnonymizerConfiguration();
            conf.SetOption(DataCategory.POD, AnonymizerApproach.HASH);

            using var anonymizer = new Anonymizer(conf);
            var hashedEm = anonymizer.ApplyOperations<Energiemenge>(em);
            var hashedMelo = anonymizer.ApplyOperations<Messlokation>(melo);
            Assert.AreEqual(hashedEm.LokationsId, hashedMelo.MesslokationsId);
        }

        [TestMethod]
        public void TestCaginMeLos()
        {
            StaticLogger.Logger = NullLogger.Instance;
            var result = new Dictionary<string, string>
            {
                {"DE0004096816110000000000000022591", null},
                {"DE0004946353300000000000001652988", null},
                {"DE00746663128OF000000000000010156", null},
                {"DE0004946307100000000000001312595", null}
            };
            var conf = new AnonymizerConfiguration();
            conf.SetOption(DataCategory.POD, AnonymizerApproach.HASH);

            using (var anonymizer = new Anonymizer(conf))
            {
                foreach (var plaintextMeLoId in result.Keys.ToList())
                {
                    var melo = new Messlokation
                    {
                        MesslokationsId = plaintextMeLoId
                    };
                    var hashedMelo = anonymizer.ApplyOperations<Messlokation>(melo);
                    result[plaintextMeLoId] = hashedMelo.MesslokationsId;
                }
            }

            JsonConvert.SerializeObject(result);
        }
    }
}