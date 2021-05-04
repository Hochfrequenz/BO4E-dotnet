using System;
using System.Globalization;
using System.IO;
using System.Linq;
using BO4E;
using BO4E.BO;
using BO4E.ENUM;
using BO4E.meta.LenientConverters;
using BO4E.Extensions.BusinessObjects;
using BO4E.Extensions.BusinessObjects.Energiemenge;
using Itenso.TimePeriod;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TestBO4E.Extensions
{
    [TestClass]
    public class TestEnergiemengeExtension
    {
        internal static readonly TimeRange GERMAN_MARCH_2018 = new TimeRange(new DateTime(2018, 2, 28, 23, 0, 0, DateTimeKind.Utc), new DateTime(2018, 3, 31, 22, 0, 0, DateTimeKind.Utc));
        internal static readonly TimeRange GERMAN_APRIL_2018 = new TimeRange(new DateTime(2018, 3, 31, 22, 0, 0, DateTimeKind.Utc), new DateTime(2018, 4, 30, 22, 0, 0, DateTimeKind.Utc));
        internal static readonly TimeRange march2425 = new TimeRange(new DateTime(2018, 3, 23, 23, 0, 0, DateTimeKind.Utc), new DateTime(2018, 3, 25, 22, 0, 0, DateTimeKind.Utc));

        [TestMethod]
        public void TestTestingRanges()
        {
            Assert.AreEqual(30 * 24, GERMAN_APRIL_2018.Duration.TotalHours); // keine Zeitumstellung im April
            Assert.AreEqual(31 * 24 - 1, GERMAN_MARCH_2018.Duration.TotalHours); // Uhren am 25.03.18 eine Stunde vor
            Assert.AreEqual(47, march2425.Duration.TotalHours);
        }

        [TestMethod]
        public void TestEnergiemengeObjects()
        {
            foreach (var boFile in Directory.GetFiles("Energiemenge/", "*.json"))
            {
                JObject json;
                using (var r = new StreamReader(boFile))
                {
                    var jsonString = r.ReadToEnd();
                    json = JsonConvert.DeserializeObject<JObject>(jsonString);
                }
                var assertions = (JObject)json["assertions"];
                if (assertions == null)
                {
                    continue;
                }
                //    Assert.IsNotNull(assertions, $"Your test file {boFile} is broken. It has no 'assertions' key on root level.");
                var bo = (JObject)json["input"];
                Assert.IsNotNull(bo, $"Your test file {boFile} is broken. It has no 'input' key on root level.");
                Energiemenge em;
                try
                {
                    if (boFile.Contains("wintertime2018.json"))
                    {
#pragma warning disable 618
                        em = BoMapper.MapObject<Energiemenge>(bo, LenientParsing.DATE_TIME);
#pragma warning restore 618
                    }
                    else
                    {
#pragma warning disable 618
                        em = BoMapper.MapObject<Energiemenge>(bo);
#pragma warning restore 618
                    }
                }
                catch (JsonSerializationException e)
                {
                    Assert.IsTrue(false, $"Your test BO is broken: {e.Message}");
                    return;
                }
                if (json.TryGetValue("fixSapCdsBug", out var fixSapCdsRaw))
                {
                    var fixit = fixSapCdsRaw.Value<bool>();
                    if (fixit)
                    {
                        em.FixSapCDSBug();
                    }
                }

                foreach (var assertion in assertions.Properties())
                {
                    switch (assertion.Name)
                    {
                        case "totalConsumption":
                            Assert.AreEqual(assertion.Value, em.GetTotalConsumption().Item1);
                            break;
                        case "totalConsumption-2018":
                            Assert.AreEqual(assertion.Value, em.GetConsumption(new TimeRange(new DateTime(2018, 01, 01), new DateTime(2019, 01, 01))).Item1);
                            break;
                        case "load-kW":
                            foreach (var dateAssertion in ((JObject)assertions["load-kW"]).Properties())
                            {
                                if (DateTime.TryParseExact(dateAssertion.Name, "yyyyMMddHHmmss", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out var dt))
                                {
                                    Assert.AreEqual(dateAssertion.Value, em.GetLoad(Mengeneinheit.KW, dt.ToUniversalTime()));
                                }
                                else
                                {
                                    Assert.IsTrue(false, "Please specify the load dates in the testfiles as yyyyMMddHHmmss");
                                }
                            }
                            break;
                        case "average":
                            try
                            {
                                Assert.AreEqual(Math.Round((decimal)assertion.Value, 12), Math.Round((decimal)em.GetAverage().Item1, 12));
                            }
                            catch (ArgumentException)
                            {
                                Assert.IsTrue(assertion.Value.Type.ToString() == "Null"); // a null value node
                            }
                            break;
                        case "isContinuous":
                            Assert.AreEqual(assertion.Value, em.IsContinuous(), $"{assertion.Name}: {boFile}");
                            break;
                        case "isEvenlySpaced":
                            Assert.AreEqual(assertion.Value, em.IsEvenlySpaced(), $"{assertion.Name}: {boFile}");
                            break;
                        case "isEvenlySpacedWithinDefinition":
                            Assert.AreEqual(assertion.Value, em.IsEvenlySpaced(true), $"{assertion.Name}: {boFile}");
                            break;
                        case "missingTimeRangeCount":
                            Assert.AreEqual(assertion.Value, em.GetMissingTimeRanges().Count, $"{assertion.Name}: {boFile}");
                            break;
                        case "coverage201804":
                            Assert.AreEqual(assertion.Value, Math.Round(em.GetCoverage(GERMAN_APRIL_2018), 4));
                            break;
                        case "coverage201803":
                            Assert.AreEqual(assertion.Value, Math.Round(em.GetCoverage(GERMAN_MARCH_2018), 8));
                            break;
                        case "coverage2018032425":
                            Assert.AreEqual(assertion.Value, Math.Round(em.GetCoverage(march2425), 4));
                            break;
                        case "coverage201804-KWHPROGNOSE1234":
                            Assert.AreEqual(assertion.Value, Math.Round(em.GetCoverage(GERMAN_APRIL_2018, Wertermittlungsverfahren.PROGNOSE, "1-2-3-4", Mengeneinheit.KWH), 4), $"{assertion.Name}: {boFile}");
                            break;
                        case "coverage201804-KWHMESSUNG5678":
                            Assert.AreEqual(assertion.Value, Math.Round(em.GetCoverage(GERMAN_APRIL_2018, Wertermittlungsverfahren.MESSUNG, "5-6-7-8", Mengeneinheit.KWH), 4), $"{assertion.Name}: {boFile}");
                            break;
                        case "jointCoverage":
                            Assert.AreEqual(assertion.Value, Math.Round(em.GetJointCoverage(GERMAN_APRIL_2018), 4), $"{assertion.Name}: {boFile}");
                            break;
                        case "isPure":
                            Assert.AreEqual((bool)assertion.Value, em.IsPure(), boFile);
                            if (!(bool)assertion.Value)
                            {
                                var pureEms = em.SplitInPureGroups();
                                var emptyEm = em.DeepClone();
                                emptyEm.Energieverbrauch = null;
                                Assert.AreEqual(em.Energieverbrauch.Count, pureEms.Select(x => x.Energieverbrauch.Count).Sum());
                                foreach (var pureEm in pureEms)
                                {
                                    Assert.IsTrue(pureEm.IsPure());
                                    var emptyPureEm = pureEm.DeepClone();
                                    emptyPureEm.Energieverbrauch = null;
                                    Assert.AreEqual(emptyEm, emptyPureEm);
                                }
                            }
                            break;
                        case "isPureUserProperties":
                            Assert.AreEqual((bool)assertion.Value, em.IsPure(true), boFile);
                            break;
                        default:
                            Assert.IsTrue(false, $"Unknown assertion type {assertion.Name} in {boFile}");
                            break;
                    }
                }


                // test normalising for all Energiemenge objects
                if (em.IsPure() && em.IsExtensive() && em.GetTotalConsumption().Item1 != 0.0M)
                {
                    const decimal targetValue = 1000.0M;
                    var emNormalised = em.Normalise(targetValue);
                    Assert.AreEqual(Math.Round(targetValue, 12), Math.Round(emNormalised.GetTotalConsumption().Item1, 12));
                }

                if (em.IsIntensive()) // test this once for one object. that's enough
                {
                    Assert.ThrowsException<ArgumentException>(() => em.GetTotalConsumption(), "It must not be allowed to add up intensive units.");
                }
            }
        }

        [TestMethod]
        public void TestDetangling()
        {
            var em = JsonConvert.DeserializeObject<Energiemenge>("{\"versionStruktur\":1,\"boTyp\":\"ENERGIEMENGE\",\"lokationsId\":\"DE0003604780400000000000012345678\",\"lokationstyp\":\"MeLo\",\"energieverbrauch\":[{\"startdatum\":\"2019-03-01T00:00:00Z\",\"enddatum\":\"2019-06-24T00:00:00Z\",\"wertermittlungsverfahren\":\"MESSUNG\",\"obiskennzahl\":\"1-0:1.8.0\",\"wert\":1,\"einheit\":\"KWH\",\"zaehlernummer\":\"10654212\"},{\"startdatum\":\"2019-03-01T00:00:00Z\",\"enddatum\":\"2019-06-24T00:00:00Z\",\"wertermittlungsverfahren\":\"MESSUNG\",\"obiskennzahl\":\"1-0:2.8.0\",\"wert\":1,\"einheit\":\"KWH\",\"zaehlernummer\":\"10654212\"}],\"anlagennummer\":\"50693510\",\"messlokationsId\":\"DE0003604780400000000000012345678\",\"marktlokationsId\":\"\",\"isMelo\":true,\"zaehlernummer\":\"10654212\"}");
            em.Detangle();
            Assert.AreEqual(2, em.Energieverbrauch.Count);
            // todo: add real test. this one is limited.

        }
    }
}