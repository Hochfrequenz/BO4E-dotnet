using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BO4E;
using BO4E.BO;
using BO4E.COM;
using BO4E.ENUM;
using BO4E.Extensions.BusinessObjects.Energiemenge;
using BO4E.meta.LenientConverters;
using BO4E.Reporting;
using Itenso.TimePeriod;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using StackExchange.Profiling;

namespace TestBO4EExtensions
{
    [TestClass]
    public class TestEnergiemengeExtensionCompleteness
    {

        [TestMethod]
        public void TestCompletenessReportGenerationSomeCustomer()
        {
            var files = Directory.GetFiles("Energiemenge/completeness", "somecustomer*.json");
            Assert.AreEqual(5, files.Count()); // this is just to make sure the files haven't moved 
            foreach (string boFile in files)
            {
                JObject json;
                using (StreamReader r = new StreamReader(boFile))
                {
                    string jsonString = r.ReadToEnd();
                    json = JsonConvert.DeserializeObject<JObject>(jsonString);
                }
                Energiemenge em = (Energiemenge)BoMapper.MapObject((JObject)json["input"], LenientParsing.Strict);
                CompletenessReport cr;
                if (boFile.EndsWith("somecustomer1.json"))
                {
                    cr = em.GetCompletenessReport();
                    Assert.AreEqual((decimal)0.9601, Math.Round(cr.coverage.Value, 4));
                    Assert.AreEqual("4-5-6-7", cr.obiskennzahl);
                    Assert.AreEqual(Wertermittlungsverfahren.MESSUNG, cr.wertermittlungsverfahren);
                    Assert.AreEqual(Mengeneinheit.KWH, cr.einheit);
                    Assert.AreEqual("DEXXX", cr.lokationsId);
                    //Assert.AreEqual(15, cr.values[0].wert);
                    //Assert.AreEqual(TestEnergiemengeExtension.GERMAN_APRIL_2018.Start, cr.values[0].startdatum);
                    string resultString = JsonConvert.SerializeObject(cr, new StringEnumConverter());

                    Assert.IsNotNull(cr.gaps);
                    Assert.AreEqual(1, cr.gaps.Count);
                    Assert.AreEqual(new DateTime(2018, 4, 1, 1, 45, 0, DateTimeKind.Utc), cr.gaps.First().startdatum);
                    Assert.AreEqual(new DateTime(2018, 4, 2, 6, 30, 0, DateTimeKind.Utc), cr.gaps.First().enddatum);
                }
                else if (boFile.EndsWith("somecustomer2.json"))
                {
                    foreach (var combi in em.GetWevObisMeCombinations())
                    {
                        cr = em.GetCompletenessReport(TestEnergiemengeExtension.GERMAN_APRIL_2018, combi.Item1, combi.Item2, combi.Item3);
                        string resultString = JsonConvert.SerializeObject(cr, new StringEnumConverter());
                        CompletenessReport cr2 = em.GetCompletenessReport(new CompletenessReport.CompletenessReportConfiguration
                        {
                            einheit = combi.Item3,
                            obis = combi.Item2,
                            wertermittlungsverfahren = combi.Item1,
                            referenceTimeFrame = new BO4E.COM.Zeitraum
                            {
                                startdatum = TestEnergiemengeExtension.GERMAN_APRIL_2018.Start,
                                enddatum = TestEnergiemengeExtension.GERMAN_APRIL_2018.End
                            }
                        });
                        //Assert.AreEqual(cr, cr2, "calling report with configuration instead of loose parameters doesn't work.");
                    }
                }
                else if (boFile.EndsWith("somecustomer3.json"))
                {

                }
                else if (boFile.EndsWith("somecustomer4.json"))
                {

                }
            }
        }

        [TestMethod]
        public void TestCompletenessReportGenerationSmard()
        {
            MiniProfiler profiler = MiniProfiler.StartNew(nameof(TestCompletenessReportGenerationSmard));
            IList<CompletenessReport> crlist = new List<CompletenessReport>();
            foreach (string boFile in Directory.GetFiles("Energiemenge/completeness", "50hz_prognose*.json"))
            {
                using (MiniProfiler.Current.Step($"Processing file {boFile}"))
                {
                    JObject json;
                    using (StreamReader r = new StreamReader(boFile))
                    {
                        string jsonString = r.ReadToEnd();
                        json = JsonConvert.DeserializeObject<JObject>(jsonString);
                    }
                    Energiemenge em = (Energiemenge)BoMapper.MapObject(json, LenientParsing.Strict);
                    CompletenessReport cr = em.GetCompletenessReport();
                    crlist.Add(cr);
                    if (boFile.Contains("onshore.json"))
                    {
                        Assert.IsNotNull(cr.userProperties);
                        Assert.AreEqual<string>("yippi yippi yeah", cr.userProperties["meineUp0"].Value<string>());
                        Assert.AreEqual<string>("krawall und remmidemmi", cr.userProperties["meineUp1"].Value<string>());
                    }
                }
            }
            string resultString = JsonConvert.SerializeObject(crlist, new StringEnumConverter());
            profiler.Stop();
            System.Diagnostics.Debug.WriteLine($"Profiler results: {profiler.RenderPlainText()}");
        }

        [TestMethod]
        public void TestRounding()
        {
            string boFile = Directory.GetFiles("Energiemenge/completeness", "gas_januar_2018.json").First();
            JObject json;
            using (StreamReader r = new StreamReader(boFile))
            {
                string jsonString = r.ReadToEnd();
                json = JsonConvert.DeserializeObject<JObject>(jsonString);
            }
            Energiemenge em = (Energiemenge)BoMapper.MapObject(JObject.FromObject(json["input"]), LenientParsing.Strict);
            CompletenessReport cr = em.GetCompletenessReport(new TimeRange()
            {
                Start = new DateTime(2017, 12, 31, 23, 0, 0, 0, DateTimeKind.Utc),
                End = new DateTime(2018, 1, 31, 23, 0, 0, 0, DateTimeKind.Utc)
            });
            Assert.AreEqual(1.0M, cr.coverage.Value);
            Assert.AreEqual(0, cr.gaps.Count());

            var dailies = em.GetDailyCompletenessReports(new TimeRange()
            {
                Start = new DateTime(2017, 12, 31, 23, 0, 0, 0, DateTimeKind.Utc),
                End = new DateTime(2018, 1, 2, 23, 0, 0, 0, DateTimeKind.Utc)
            });
            foreach (var crDaily in dailies)
            {
                Assert.AreEqual(1.0M, crDaily.Value.coverage.Value, $"error in slice {crDaily.Key}");
            }
            Assert.AreEqual(1.0M, cr.coverage.Value);
        }

        [TestMethod]
        public void TestFirstLastGap()
        {
            Energiemenge em = new Energiemenge()
            {
                lokationsId = "DE123455",
                lokationstyp = Lokationstyp.MeLo,
                energieverbrauch = new List<Verbrauch>()
                {
                    new Verbrauch()
                    {
                        obiskennzahl="1234",
                        wert=123.456M,
                        wertermittlungsverfahren=Wertermittlungsverfahren.MESSUNG,
                        startdatum = new DateTime(2019,1,1,0,0,0,DateTimeKind.Utc),
                        enddatum = new DateTime(2019,1,4,0,0,0,DateTimeKind.Utc),
                    },
                    new Verbrauch()
                    {
                        obiskennzahl="1234",
                        wert=123.456M,
                        wertermittlungsverfahren=Wertermittlungsverfahren.MESSUNG,
                        startdatum = new DateTime(2019,1,4,0,0,0,DateTimeKind.Utc),
                        enddatum = new DateTime(2019,1,7,0,0,0,DateTimeKind.Utc),
                    }
                }
            };

            var cr = em.GetCompletenessReport(new TimeRange(new DateTime(2018, 12, 29, 0, 0, 0, DateTimeKind.Utc), new DateTime(2019, 1, 10, 0, 0, 0, DateTimeKind.Utc)));
            Assert.AreEqual(2, cr.gaps.Count());
            Assert.AreEqual(new DateTime(2018, 12, 29, 0, 0, 0, DateTimeKind.Utc), cr.gaps.First().startdatum);
            Assert.AreEqual(new DateTime(2019, 1, 1, 0, 0, 0, DateTimeKind.Utc), cr.gaps.First().enddatum);
            Assert.AreEqual(new DateTime(2019, 1, 7, 0, 0, 0, DateTimeKind.Utc), cr.gaps.Last().startdatum);
            Assert.AreEqual(new DateTime(2019, 1, 10, 0, 0, 0, DateTimeKind.Utc), cr.gaps.Last().enddatum);
        }

        [TestMethod]
        public void TestNullableCoverage()
        {
            Energiemenge em1 = new Energiemenge()
            {
                lokationsId = "DE123456789DieseEmhatkeineVerbräuche",
                lokationstyp = Lokationstyp.MeLo,
                energieverbrauch = new List<Verbrauch>() //empty list
            };
            CompletenessReport cr1 = em1.GetCompletenessReport();
            Assert.IsNotNull(cr1);
            Assert.IsNull(cr1.coverage);
            JsonConvert.SerializeObject(cr1); // must _not_ throw exception

            Energiemenge em2 = new Energiemenge()
            {
                lokationsId = "54321012345DieseEmhatkeineVerbräuche",
                lokationstyp = Lokationstyp.MeLo,
                energieverbrauch = new List<Verbrauch>() //empty list
            };
            CompletenessReport cr2 = em2.GetCompletenessReport(CHRISTMAS_2018, Wertermittlungsverfahren.MESSUNG, "1-2-3-4", Mengeneinheit.KUBIKMETER);
            Assert.IsNotNull(cr2);
            Assert.IsNotNull(cr2.coverage); // not null because no values but configuration given
            Assert.AreEqual(0.0M, cr2.coverage);
            JsonConvert.SerializeObject(cr2); // must _not_ throw exception

            CompletenessReport cr3 = em2.GetCompletenessReport(CHRISTMAS_2018);
            Assert.IsNotNull(cr3);
            Assert.IsNotNull(cr3.coverage);
            Assert.AreEqual(0.0M, cr3.coverage);
            JsonConvert.SerializeObject(cr3); // must _not_ throw exception
        }

        internal static readonly TimeRange CHRISTMAS_2018 = new TimeRange(
            new DateTime(2018, 12, 23, 22, 0, 0, DateTimeKind.Utc),
            new DateTime(2018, 12, 31, 22, 0, 0, DateTimeKind.Utc));
        internal static readonly TimeRange GERMAN_YEAR_2018 = new TimeRange(
            new DateTime(2017, 12, 31, 23, 0, 0, DateTimeKind.Utc),
            new DateTime(2018, 12, 31, 23, 0, 0, DateTimeKind.Utc));

        [TestMethod]
        public void TestDailyCompleteness()
        {
            foreach (string boFile in Directory.GetFiles("Energiemenge/completeness/", "50hz_prognose*.json"))
            {
                using (MiniProfiler.Current.Step($"Processing file {boFile}"))
                {
                    JObject json;
                    using (StreamReader r = new StreamReader(boFile))
                    {
                        string jsonString = r.ReadToEnd();
                        json = JsonConvert.DeserializeObject<JObject>(jsonString);
                    }
                    Energiemenge em = BoMapper.MapObject<Energiemenge>(json, LenientParsing.Strict);
                    var result = em.GetDailyCompletenessReports(CHRISTMAS_2018);
                    Assert.AreEqual(8, result.Count);
                    break; // one test is enough. the rest is covered by the individual completeness report tests.
                }
            }
        }
        [TestMethod]
        public void TestMonthlySlices() => TestMonthlySlices(testFirstOnly: true, useParallelExecution: false);


        internal void TestMonthlySlices(bool testFirstOnly = true, bool useParallelExecution = false)
        {
            foreach (string boFile in Directory.GetFiles("Energiemenge/completeness", "50hz_prognose*.json"))
            {
                using (MiniProfiler.Current.Step($"Processing file {boFile} with parallel={useParallelExecution}"))
                {
                    JObject json;
                    using (StreamReader r = new StreamReader(boFile))
                    {
                        string jsonString = r.ReadToEnd();
                        json = JsonConvert.DeserializeObject<JObject>(jsonString);
                    }
                    Energiemenge em = BoMapper.MapObject<Energiemenge>(json, LenientParsing.Strict);
                    var result = em.GetMonthlyCompletenessReports(GERMAN_YEAR_2018, useParallelExecution: useParallelExecution);
                    Assert.AreEqual(12, result.Count); // don't care about values of coverage, just the start/end and count of reports generated.
                    if (testFirstOnly)
                    {
                        break; // one test is enough. the rest is covered by the individual completeness report tests
                    }
                }
            }
        }

        [TestMethod]
        public void TestParallization()
        {
            for (int i = 0; i < 10; i++)
            {
                Energiemenge em;
                using (StreamReader r = new StreamReader(Directory.GetFiles("Energiemenge/completeness", "threeyears.json").First()))
                {
                    string jsonString = r.ReadToEnd();
                    em = JsonConvert.DeserializeObject<Energiemenge>(jsonString);
                }
                MiniProfiler mpFixSapCds = MiniProfiler.StartNew("Fix SAP CDS");
                em.FixSapCDSBug();
                mpFixSapCds.Stop();
                Assert.IsTrue(mpFixSapCds.DurationMilliseconds < 50, mpFixSapCds.RenderPlainText());
                Console.Out.WriteLine(mpFixSapCds.RenderPlainText());

                MiniProfiler mpFixSapCds2 = MiniProfiler.StartNew("Fix SAP CDS");
                em.FixSapCDSBug();
                mpFixSapCds2.Stop();
                Assert.IsTrue(mpFixSapCds2.DurationMilliseconds * 10 < mpFixSapCds.DurationMilliseconds);


                MiniProfiler mpLinear = MiniProfiler.StartNew("Non-Parallel");
                em.GetMonthlyCompletenessReports(new TimeRange(new DateTime(2016, 1, 31, 23, 0, 0, DateTimeKind.Utc), new DateTime(2016, 12, 31, 23, 0, 0, DateTimeKind.Utc)), useParallelExecution: false);
                mpLinear.Stop();
                Console.Out.Write(mpLinear.RenderPlainText());
                Assert.IsTrue(mpLinear.DurationMilliseconds < 4000, $"Linear completeness report generation was too slow. Expected less than 4 seconds but was {mpLinear.DurationMilliseconds}ms: {mpLinear.RenderPlainText()}");

                MiniProfiler mpParallel = MiniProfiler.StartNew("Parallel");
                em.GetMonthlyCompletenessReports(new TimeRange(new DateTime(2016, 1, 31, 23, 0, 0, DateTimeKind.Utc), new DateTime(2016, 12, 31, 23, 0, 0, DateTimeKind.Utc)), useParallelExecution: true);
                mpParallel.Stop();
                Console.Out.Write(mpParallel.RenderPlainText());
                //Assert.IsTrue(mpParallel.DurationMilliseconds < 3000, $"Parallel completeness report generation was too slow. Expected less than 3 seconds but was {mpParallel.DurationMilliseconds}ms: {mpParallel.RenderPlainText()}");
                //Assert.IsTrue(mpParallel.DurationMilliseconds < (int)mpLinear.DurationMilliseconds * 1.25M, $"Parallel: {mpParallel.DurationMilliseconds}, Non-Parallel: {mpLinear.DurationMilliseconds}");
            }
            //int a = 0;
        }

        [TestMethod]
        public void TestDailyParallization()
        {
            //Energiemenge em ;
            //using (StreamReader r = new StreamReader(Directory.GetFiles("BusinessObjectExtensions/Energiemenge/completeness", "threeyears.json").First()))
            //{
            //    string jsonString = r.ReadToEnd();
            //    em = JsonConvert.DeserializeObject<Energiemenge>(jsonString);
            //}
            Energiemenge em = new Energiemenge();
            DateTime dateTime = DateTime.Parse("2015-01-31 22:45:00");
            List<Verbrauch> listvb = new List<Verbrauch>();
            for (int u = 0; u < 1500; u++)
            {
                dateTime = dateTime.AddMinutes(15);
                DateTime endDateTime = dateTime.AddMinutes(15);

                listvb.Add(new Verbrauch() { startdatum = dateTime, enddatum = endDateTime, einheit = Mengeneinheit.JAHR, wert = 12 });
                dateTime = endDateTime;
            }
            em.energieverbrauch = listvb;

            MiniProfiler mpLinear = MiniProfiler.StartNew("Non-Parallel");
            em.GetMonthlyCompletenessReports(new TimeRange(new DateTime(2015, 1, 1, 23, 00, 0, DateTimeKind.Utc), new DateTime(2019, 12, 31, 23, 0, 0, DateTimeKind.Utc)), useParallelExecution: false);
            mpLinear.Stop();
            Console.Out.Write(mpLinear.RenderPlainText());
            //Assert.IsTrue(mpLinear.DurationMilliseconds < 4000, $"Linear completeness report generation was too slow. Expected less than 4 seconds but was {mpLinear.DurationMilliseconds}ms: {mpLinear.RenderPlainText()}");

            MiniProfiler mpParallel = MiniProfiler.StartNew("Parallel");
            em.GetDailyCompletenessReports(new TimeRange(new DateTime(2015, 1, 01, 23, 0, 0, DateTimeKind.Utc), new DateTime(2019, 12, 31, 23, 0, 0, DateTimeKind.Utc)), useParallelExecution: true);
            mpParallel.Stop();
            Console.Out.Write(mpParallel.RenderPlainText());
            //Assert.IsTrue(mpParallel.DurationMilliseconds < 3000, $"Parallel completeness report generation was too slow. Expected less than 3 seconds but was {mpParallel.DurationMilliseconds}ms: {mpParallel.RenderPlainText()}");
            //Assert.IsTrue(mpParallel.DurationMilliseconds < (int)mpLinear.DurationMilliseconds * 1.25M, $"Parallel: {mpParallel.DurationMilliseconds}, Non-Parallel: {mpLinear.DurationMilliseconds}");
        }


        [TestMethod]
        public void TestDailyCompletenessDST()
        {
            var localStart = TimeZoneInfo.ConvertTimeFromUtc(new DateTime(2018, 3, 24, 23, 0, 0, DateTimeKind.Utc), Verbrauch.CENTRAL_EUROPE_STANDARD_TIME);//, DateTimeKind.Unspecified);
            var localEnd = TimeZoneInfo.ConvertTimeFromUtc(new DateTime(2018, 3, 26, 22, 0, 0, DateTimeKind.Utc), Verbrauch.CENTRAL_EUROPE_STANDARD_TIME);//, DateTimeKind.Unspecified);
            if (TimeZoneInfo.Local != Verbrauch.CENTRAL_EUROPE_STANDARD_TIME)
            {
                localStart = DateTime.SpecifyKind(TimeZoneInfo.ConvertTime(localStart, TimeZoneInfo.Local, Verbrauch.CENTRAL_EUROPE_STANDARD_TIME), DateTimeKind.Unspecified);
                localEnd = DateTime.SpecifyKind(TimeZoneInfo.ConvertTime(localEnd, TimeZoneInfo.Local, Verbrauch.CENTRAL_EUROPE_STANDARD_TIME), DateTimeKind.Unspecified);
            }
            else
            {
                localStart = DateTime.SpecifyKind(localStart, DateTimeKind.Unspecified);
                localEnd = DateTime.SpecifyKind(localEnd, DateTimeKind.Unspecified);
            }
            var utcStart = new DateTime(2018, 3, 24, 23, 0, 0, DateTimeKind.Utc);
            var utcEnd = new DateTime(2018, 3, 26, 22, 0, 0, DateTimeKind.Utc);
            if (TimeZoneInfo.Local.SupportsDaylightSavingTime && Verbrauch.CENTRAL_EUROPE_STANDARD_TIME == TimeZoneInfo.Local)
            {
                Assert.IsFalse(Verbrauch.CENTRAL_EUROPE_STANDARD_TIME.IsDaylightSavingTime(localStart));
                Assert.IsTrue(Verbrauch.CENTRAL_EUROPE_STANDARD_TIME.IsDaylightSavingTime(localEnd));
            }

            var verbrauchSlices = new List<TimeRange>()
            {
                new TimeRange()
                {
                    Start = utcStart,
                    End = utcStart.AddHours(1)
                }
            };
            while (verbrauchSlices.Last().End < utcEnd)
            {
                verbrauchSlices.Add(new TimeRange()
                {
                    Start = verbrauchSlices.Last().Start.AddHours(1),
                    End = verbrauchSlices.Last().End.AddHours(1),
                });
            }
            Assert.AreEqual(2 * 24 - 1, verbrauchSlices.Count);
            Energiemenge em = new Energiemenge()
            {
                lokationsId = "MeinUnitTest123",
                lokationstyp = Lokationstyp.MeLo,
                energieverbrauch = verbrauchSlices.Select(vs => new BO4E.COM.Verbrauch()
                {
                    startdatum = vs.Start,
                    enddatum = vs.End,
                    einheit = Mengeneinheit.KWH,
                    wert = (decimal)123.456,
                    wertermittlungsverfahren = Wertermittlungsverfahren.MESSUNG
                }
                ).ToList()
            };
            var result = em.GetDailyCompletenessReports(new TimeRange(utcStart, utcEnd));
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(new DateTime(2018, 3, 24, 23, 0, 0, DateTimeKind.Utc), result.First().Value.referenceTimeFrame.startdatum);
            Assert.AreEqual(new DateTime(2018, 3, 25, 22, 0, 0, DateTimeKind.Utc), result.First().Value.referenceTimeFrame.enddatum);
            Assert.AreEqual(new DateTime(2018, 3, 25, 22, 0, 0, DateTimeKind.Utc), result.Last().Value.referenceTimeFrame.startdatum);
            Assert.AreEqual(new DateTime(2018, 3, 26, 22, 0, 0, DateTimeKind.Utc), result.Last().Value.referenceTimeFrame.enddatum);
        }

        [TestMethod]
        public void TestAddDaysDSTSpring()
        {
            DateTime utcDt = new DateTime(2018, 3, 24, 23, 0, 0, DateTimeKind.Utc);
            DateTime localDt = DateTime.SpecifyKind(TimeZoneInfo.ConvertTimeFromUtc(new DateTime(2018, 3, 24, 23, 0, 0, DateTimeKind.Utc), Verbrauch.CENTRAL_EUROPE_STANDARD_TIME), DateTimeKind.Unspecified);

            DateTime resultUtc = utcDt.AddDaysDST(1);
            DateTime resultLocal = localDt.AddDaysDST(1);

            Assert.AreEqual(DateTimeKind.Utc, resultUtc.Kind);
            Assert.AreEqual(DateTimeKind.Unspecified, resultLocal.Kind);

            Assert.AreEqual(23, (new TimeRange(utcDt, resultUtc)).Duration.TotalHours);
            Assert.AreEqual(23, (new TimeRange()
            {
                Start = TimeZoneInfo.ConvertTimeToUtc(DateTime.SpecifyKind(localDt, DateTimeKind.Unspecified), Verbrauch.CENTRAL_EUROPE_STANDARD_TIME),
                End = TimeZoneInfo.ConvertTimeToUtc(DateTime.SpecifyKind(resultLocal, DateTimeKind.Unspecified), Verbrauch.CENTRAL_EUROPE_STANDARD_TIME)
            }).Duration.TotalHours);
        }

        [TestMethod]
        public void TestAddDaysDSTAutumn()
        {
            DateTime utcDt = new DateTime(2018, 10, 27, 22, 0, 0, DateTimeKind.Utc);
            DateTime localDt = DateTime.SpecifyKind(TimeZoneInfo.ConvertTimeFromUtc(new DateTime(2018, 10, 27, 22, 0, 0, DateTimeKind.Utc), Verbrauch.CENTRAL_EUROPE_STANDARD_TIME), DateTimeKind.Unspecified);

            DateTime resultUtc = utcDt.AddDaysDST(1);
            DateTime resultLocal = localDt.AddDaysDST(1);

            Assert.AreEqual(DateTimeKind.Utc, resultUtc.Kind);
            Assert.AreEqual(DateTimeKind.Unspecified, resultLocal.Kind);

            Assert.AreEqual(25, (new TimeRange(utcDt, resultUtc)).Duration.TotalHours);
            Assert.AreEqual(25, (new TimeRange()
            {
                Start = TimeZoneInfo.ConvertTimeToUtc(DateTime.SpecifyKind(localDt, DateTimeKind.Unspecified), Verbrauch.CENTRAL_EUROPE_STANDARD_TIME),
                End = TimeZoneInfo.ConvertTimeToUtc(DateTime.SpecifyKind(resultLocal, DateTimeKind.Unspecified), Verbrauch.CENTRAL_EUROPE_STANDARD_TIME)
            }).Duration.TotalHours);
        }

        [TestMethod]
        public void TestAddDaysDSTSummer() // could be winter as well ;)
        {
            DateTime utcDt = new DateTime(2018, 7, 27, 22, 0, 0, DateTimeKind.Utc);
            DateTime localDt = DateTime.SpecifyKind(TimeZoneInfo.ConvertTimeFromUtc(new DateTime(2018, 7, 27, 22, 0, 0, DateTimeKind.Utc), Verbrauch.CENTRAL_EUROPE_STANDARD_TIME), DateTimeKind.Unspecified);

            DateTime resultUtc = utcDt.AddDaysDST(1);
            DateTime resultLocal = localDt.AddDaysDST(1);

            Assert.AreEqual(DateTimeKind.Utc, resultUtc.Kind);
            Assert.AreEqual(DateTimeKind.Unspecified, resultLocal.Kind);

            Assert.AreEqual(24, (new TimeRange(utcDt, resultUtc)).Duration.TotalHours);
            Assert.AreEqual(24, (new TimeRange()
            {
                Start = TimeZoneInfo.ConvertTimeToUtc(DateTime.SpecifyKind(localDt, DateTimeKind.Unspecified), Verbrauch.CENTRAL_EUROPE_STANDARD_TIME),
                End = TimeZoneInfo.ConvertTimeToUtc(DateTime.SpecifyKind(resultLocal, DateTimeKind.Unspecified), Verbrauch.CENTRAL_EUROPE_STANDARD_TIME)
            }).Duration.TotalHours);
        }
    }
}