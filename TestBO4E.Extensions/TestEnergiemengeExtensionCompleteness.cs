using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BO4E;
using BO4E.BO;
using BO4E.COM;
using BO4E.ENUM;
using BO4E.Extensions.BusinessObjects.Energiemenge;
using BO4E.meta;
using BO4E.meta.LenientConverters;
using BO4E.Reporting;
using Itenso.TimePeriod;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using StackExchange.Profiling;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace TestBO4E.Extensions
{
    [TestClass]
    public class TestEnergiemengeExtensionCompleteness
    {
        internal static readonly TimeRange CHRISTMAS_2018 = new TimeRange(
            new DateTimeOffset(2018, 12, 23, 22, 0, 0, TimeSpan.Zero).UtcDateTime,
            new DateTimeOffset(2018, 12, 31, 22, 0, 0, TimeSpan.Zero).UtcDateTime);

        internal static readonly TimeRange GERMAN_YEAR_2018 = new TimeRange(
            new DateTimeOffset(2017, 12, 31, 23, 0, 0, TimeSpan.Zero).UtcDateTime,
            new DateTimeOffset(2018, 12, 31, 23, 0, 0, TimeSpan.Zero).UtcDateTime);

        [TestMethod]
        public void TestCompletenessReportGenerationSomeCustomer()
        {
            var files = Directory.GetFiles("Energiemenge/completeness", "somecustomer*.json");
            Assert.AreEqual(5, files.Length); // this is just to make sure the files haven't moved 
            foreach (var boFile in files)
            {
                JObject json;
                using (var r = new StreamReader(boFile))
                {
                    var jsonString = r.ReadToEnd();
                    json = JsonConvert.DeserializeObject<JObject>(jsonString);
                }

                var em = (Energiemenge)BoMapper.MapObject((JObject)json["input"]);
                CompletenessReport cr;
                if (boFile.EndsWith("somecustomer1.json"))
                {
                    cr = em.GetCompletenessReport();
                    Assert.AreEqual((decimal)0.9601, Math.Round(cr.Coverage.Value, 4));
                    Assert.AreEqual("4-5-6-7", cr.Obiskennzahl);
                    Assert.AreEqual(Wertermittlungsverfahren.MESSUNG, cr.Wertermittlungsverfahren);
                    Assert.AreEqual(Mengeneinheit.KWH, cr.Einheit);
                    Assert.AreEqual("DEXXX", cr.LokationsId);
                    //Assert.AreEqual(15, cr.values[0].wert);
                    //Assert.AreEqual(TestEnergiemengeExtension.GERMAN_APRIL_2018.Start, cr.values[0].startdatum);
                    _ = JsonConvert.SerializeObject(cr, new StringEnumConverter());

                    Assert.IsNotNull(cr.Gaps);
                    Assert.AreEqual(1, cr.Gaps.Count);
                    Assert.AreEqual(new DateTimeOffset(2018, 4, 1, 1, 45, 0, TimeSpan.Zero),
                        cr.Gaps.First().Startdatum);
                    Assert.AreEqual(new DateTimeOffset(2018, 4, 2, 6, 30, 0, TimeSpan.Zero), cr.Gaps.First().Enddatum);
                }
                else if (boFile.EndsWith("somecustomer2.json"))
                {
                    foreach (var combi in em.GetWevObisMeCombinations())
                    {
                        cr = em.GetCompletenessReport(TestEnergiemengeExtension.GERMAN_APRIL_2018, combi.Item1,
                            combi.Item2, combi.Item3);
                        var resultString = JsonConvert.SerializeObject(cr, new StringEnumConverter());
                        var cr2 = em.GetCompletenessReport(new CompletenessReport.CompletenessReportConfiguration
                        {
                            Einheit = combi.Item3,
                            Obis = combi.Item2,
                            Wertermittlungsverfahren = combi.Item1,
                            ReferenceTimeFrame = new Zeitraum
                            {
                                Startdatum = TestEnergiemengeExtension.GERMAN_APRIL_2018.Start,
                                Enddatum = TestEnergiemengeExtension.GERMAN_APRIL_2018.End
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
            var profiler = MiniProfiler.StartNew(nameof(TestCompletenessReportGenerationSmard));
            IList<CompletenessReport> crlist = new List<CompletenessReport>();
            foreach (var boFile in Directory.GetFiles("Energiemenge/completeness", "50hz_prognose*.json"))
                using (MiniProfiler.Current.Step($"Processing file {boFile}"))
                {
                    JObject json;
                    using (var r = new StreamReader(boFile))
                    {
                        var jsonString = r.ReadToEnd();
                        json = JsonConvert.DeserializeObject<JObject>(jsonString);
                    }

                    var em = (Energiemenge)BoMapper.MapObject(json);
                    var cr = em.GetCompletenessReport();
                    crlist.Add(cr);
                    if (boFile.Contains("onshore.json"))
                    {
                        Assert.IsNotNull(cr.UserProperties);
                        Assert.AreEqual("yippi yippi yeah", cr.UserProperties["meineUp0"] as string);
                        Assert.AreEqual("krawall und remmidemmi", cr.UserProperties["meineUp1"] as string);
                    }
                }

            var resultString = JsonConvert.SerializeObject(crlist, new StringEnumConverter());
            profiler.Stop();
            Debug.WriteLine($"Profiler results: {profiler.RenderPlainText()}");
        }

        [TestMethod]
        public void TestRounding()
        {
            var boFile = Directory.GetFiles("Energiemenge/completeness", "gas_januar_2018.json").First();
            JObject json;
            using (var r = new StreamReader(boFile))
            {
                var jsonString = r.ReadToEnd();
                json = JsonConvert.DeserializeObject<JObject>(jsonString);
            }

            var em = (Energiemenge)BoMapper.MapObject(JObject.FromObject(json["input"]));
            var cr = em.GetCompletenessReport(new TimeRange
            {
                Start = new DateTimeOffset(2017, 12, 31, 23, 0, 0, 0, TimeSpan.Zero).UtcDateTime,
                End = new DateTimeOffset(2018, 1, 31, 23, 0, 0, 0, TimeSpan.Zero).UtcDateTime
            });
            Assert.AreEqual(1.0M, cr.Coverage.Value);
            Assert.AreEqual(0, cr.Gaps.Count);

            var dailies = em.GetDailyCompletenessReports(new TimeRange
            {
                Start = new DateTimeOffset(2017, 12, 31, 23, 0, 0, 0, TimeSpan.Zero).UtcDateTime,
                End = new DateTimeOffset(2018, 1, 2, 23, 0, 0, 0, TimeSpan.Zero).UtcDateTime
            });
            foreach (var crDaily in dailies)
                Assert.AreEqual(1.0M, crDaily.Value.Coverage.Value, $"error in slice {crDaily.Key}");
            Assert.AreEqual(1.0M, cr.Coverage.Value);
        }

        [TestMethod]
        public void TestFirstLastGap()
        {
            var em = new Energiemenge
            {
                LokationsId = "DE123455",
                LokationsTyp = Lokationstyp.MeLo,
                Energieverbrauch = new List<Verbrauch>
                {
                    new Verbrauch
                    {
                        Obiskennzahl = "1234",
                        Wert = 123.456M,
                        Wertermittlungsverfahren = Wertermittlungsverfahren.MESSUNG,
                        Startdatum = new DateTimeOffset(2019, 1, 1, 0, 0, 0, TimeSpan.Zero).UtcDateTime,
                        Enddatum = new DateTimeOffset(2019, 1, 4, 0, 0, 0, TimeSpan.Zero).UtcDateTime
                    },
                    new Verbrauch
                    {
                        Obiskennzahl = "1234",
                        Wert = 123.456M,
                        Wertermittlungsverfahren = Wertermittlungsverfahren.MESSUNG,
                        Startdatum = new DateTimeOffset(2019, 1, 4, 0, 0, 0, TimeSpan.Zero).UtcDateTime,
                        Enddatum = new DateTimeOffset(2019, 1, 7, 0, 0, 0, TimeSpan.Zero).UtcDateTime
                    }
                }
            };

            var cr = em.GetCompletenessReport(new TimeRange(new DateTime(2018, 12, 29, 0, 0, 0, DateTimeKind.Utc),
                new DateTime(2019, 1, 10, 0, 0, 0, DateTimeKind.Utc)));
            Assert.AreEqual(2, cr.Gaps.Count);
            Assert.AreEqual(new DateTimeOffset(2018, 12, 29, 0, 0, 0, TimeSpan.Zero), cr.Gaps.First().Startdatum);
            Assert.AreEqual(new DateTimeOffset(2019, 1, 1, 0, 0, 0, TimeSpan.Zero), cr.Gaps.First().Enddatum);
            Assert.AreEqual(new DateTimeOffset(2019, 1, 7, 0, 0, 0, TimeSpan.Zero), cr.Gaps.Last().Startdatum);
            Assert.AreEqual(new DateTimeOffset(2019, 1, 10, 0, 0, 0, TimeSpan.Zero), cr.Gaps.Last().Enddatum);
        }

        [TestMethod]
        public void TestNullableCoverage()
        {
            var em1 = new Energiemenge
            {
                LokationsId = "DE123456789DieseEmhatkeineVerbräuche",
                LokationsTyp = Lokationstyp.MeLo,
                Energieverbrauch = new List<Verbrauch>() //empty list
            };
            var cr1 = em1.GetCompletenessReport();
            Assert.IsNotNull(cr1);
            Assert.IsNull(cr1.Coverage);
            JsonConvert.SerializeObject(cr1); // must _not_ throw exception

            var em2 = new Energiemenge
            {
                LokationsId = "54321012345DieseEmhatkeineVerbräuche",
                LokationsTyp = Lokationstyp.MeLo,
                Energieverbrauch = new List<Verbrauch>() //empty list
            };
            var cr2 = em2.GetCompletenessReport(CHRISTMAS_2018, Wertermittlungsverfahren.MESSUNG, "1-2-3-4",
                Mengeneinheit.KUBIKMETER);
            Assert.IsNotNull(cr2);
            Assert.IsNotNull(cr2.Coverage); // not null because no values but configuration given
            Assert.AreEqual(0.0M, cr2.Coverage);
            JsonConvert.SerializeObject(cr2); // must _not_ throw exception

            var cr3 = em2.GetCompletenessReport(CHRISTMAS_2018);
            Assert.IsNotNull(cr3);
            Assert.IsNotNull(cr3.Coverage);
            Assert.AreEqual(0.0M, cr3.Coverage);
            JsonConvert.SerializeObject(cr3); // must _not_ throw exception
        }

        [TestMethod]
        public void TestDailyCompleteness()
        {
            foreach (var boFile in Directory.GetFiles("Energiemenge/completeness/", "50hz_prognose*.json"))
                using (MiniProfiler.Current.Step($"Processing file {boFile}"))
                {
                    JObject json;
                    using (var r = new StreamReader(boFile))
                    {
                        var jsonString = r.ReadToEnd();
                        json = JsonConvert.DeserializeObject<JObject>(jsonString);
                    }
#pragma warning disable 618
                    var em = BoMapper.MapObject<Energiemenge>(json);
#pragma warning restore 618
                    var result = em.GetDailyCompletenessReports(CHRISTMAS_2018);
                    Assert.AreEqual(8, result.Count);
                    break; // one test is enough. the rest is covered by the individual completeness report tests.
                }
        }

        [TestMethod]
        public void TestMonthlySlices()
        {
            TestMonthlySlices(true);
        }


        internal void TestMonthlySlices(bool testFirstOnly = true, bool useParallelExecution = false)
        {
            foreach (var boFile in Directory.GetFiles("Energiemenge/completeness", "50hz_prognose*.json"))
                using (MiniProfiler.Current.Step($"Processing file {boFile} with parallel={useParallelExecution}"))
                {
                    JObject json;
                    using (var r = new StreamReader(boFile))
                    {
                        var jsonString = r.ReadToEnd();
                        json = JsonConvert.DeserializeObject<JObject>(jsonString);
                    }

                    var em = BoMapper.MapObject<Energiemenge>(json);
                    var result = em.GetMonthlyCompletenessReports(GERMAN_YEAR_2018, useParallelExecution);
                    Assert.AreEqual(12,
                        result.Count); // don't care about values of coverage, just the start/end and count of reports generated.
                    if (testFirstOnly)
                        break; // one test is enough. the rest is covered by the individual completeness report tests
                }
        }

        [DoNotParallelize]
        [TestMethod]
        public void TestParallization()
        {
            for (var i = 0; i < 10; i++)
            {
                Energiemenge em;
                using (var r =
                    new StreamReader(Directory.GetFiles("Energiemenge/completeness", "threeyears.json").First()))
                {
                    var jsonString = r.ReadToEnd();
                    em = JsonConvert.DeserializeObject<Energiemenge>(jsonString);
                }

                var mpFixSapCds = MiniProfiler.StartNew("Fix SAP CDS");
                em.FixSapCDSBug();
                mpFixSapCds.Stop();
                Assert.IsTrue(mpFixSapCds.DurationMilliseconds < 500, mpFixSapCds.RenderPlainText());
                Console.Out.WriteLine(mpFixSapCds.RenderPlainText());

                var mpFixSapCds2 = MiniProfiler.StartNew("Fix SAP CDS");
                em.FixSapCDSBug();
                mpFixSapCds2.Stop();
                Assert.IsTrue(mpFixSapCds2.DurationMilliseconds * 10 < mpFixSapCds.DurationMilliseconds);


                var mpLinear = MiniProfiler.StartNew("Non-Parallel");
                em.GetMonthlyCompletenessReports(new TimeRange(new DateTime(2016, 1, 31, 23, 0, 0, DateTimeKind.Utc),
                    new DateTime(2016, 12, 31, 23, 0, 0, DateTimeKind.Utc)));
                mpLinear.Stop();
                Console.Out.Write(mpLinear.RenderPlainText());
                Assert.IsTrue(mpLinear.DurationMilliseconds < 4000,
                    $"Linear completeness report generation was too slow. Expected less than 4 seconds but was {mpLinear.DurationMilliseconds}ms: {mpLinear.RenderPlainText()}");

                var mpParallel = MiniProfiler.StartNew("Parallel");
                em.GetMonthlyCompletenessReports(
                    new TimeRange(new DateTime(2016, 1, 31, 23, 0, 0, DateTimeKind.Utc),
                        new DateTime(2016, 12, 31, 23, 0, 0, DateTimeKind.Utc)), true);
                mpParallel.Stop();
                Console.Out.Write(mpParallel.RenderPlainText());
                //Assert.IsTrue(mpParallel.DurationMilliseconds < 3000, $"Parallel completeness report generation was too slow. Expected less than 3 seconds but was {mpParallel.DurationMilliseconds}ms: {mpParallel.RenderPlainText()}");
                //Assert.IsTrue(mpParallel.DurationMilliseconds < (int)mpLinear.DurationMilliseconds * 1.25M, $"Parallel: {mpParallel.DurationMilliseconds}, Non-Parallel: {mpLinear.DurationMilliseconds}");
            }
            //int a = 0;
        }

        [DoNotParallelize]
        [TestMethod]
        public async Task TestParallizationSystemTextJson()
        {
            for (var i = 0; i < 10; i++)
            {
                Energiemenge em;
                var r = Directory.GetFiles("Energiemenge/completeness", "threeyears.json").First();
                await using var openStream = File.OpenRead(r);
                em = await JsonSerializer.DeserializeAsync<Energiemenge>(openStream,
                    LenientParsing.MOST_LENIENT.GetJsonSerializerOptions());

                var mpFixSapCds = MiniProfiler.StartNew("Fix SAP CDS");
                em.FixSapCDSBug();
                await mpFixSapCds.StopAsync();
                Assert.IsTrue(mpFixSapCds.DurationMilliseconds < 500, mpFixSapCds.RenderPlainText());
                await Console.Out.WriteLineAsync(mpFixSapCds.RenderPlainText());

                var mpFixSapCds2 = MiniProfiler.StartNew("Fix SAP CDS");
                em.FixSapCDSBug();
                await mpFixSapCds2.StopAsync();
                Assert.IsTrue(mpFixSapCds2.DurationMilliseconds * 10 < mpFixSapCds.DurationMilliseconds);


                var mpLinear = MiniProfiler.StartNew("Non-Parallel");
                em.GetMonthlyCompletenessReports(new TimeRange(new DateTime(2016, 1, 31, 23, 0, 0, DateTimeKind.Utc),
                    new DateTime(2016, 12, 31, 23, 0, 0, DateTimeKind.Utc)));
                await mpLinear.StopAsync();
                await Console.Out.WriteAsync(mpLinear.RenderPlainText());
                Assert.IsTrue(mpLinear.DurationMilliseconds < 4000,
                    $"Linear completeness report generation was too slow. Expected less than 4 seconds but was {mpLinear.DurationMilliseconds}ms: {mpLinear.RenderPlainText()}");

                var mpParallel = MiniProfiler.StartNew("Parallel");
                em.GetMonthlyCompletenessReports(
                    new TimeRange(new DateTime(2016, 1, 31, 23, 0, 0, DateTimeKind.Utc),
                        new DateTime(2016, 12, 31, 23, 0, 0, DateTimeKind.Utc)), true);
                await mpParallel.StopAsync();
                await Console.Out.WriteAsync(mpParallel.RenderPlainText());
                //Assert.IsTrue(mpParallel.DurationMilliseconds < 3000, $"Parallel completeness report generation was too slow. Expected less than 3 seconds but was {mpParallel.DurationMilliseconds}ms: {mpParallel.RenderPlainText()}");
                //Assert.IsTrue(mpParallel.DurationMilliseconds < (int)mpLinear.DurationMilliseconds * 1.25M, $"Parallel: {mpParallel.DurationMilliseconds}, Non-Parallel: {mpLinear.DurationMilliseconds}");
            }
        }
        //int a = 0;


        [TestMethod]
        public void TestDailyParallization()
        {
            //Energiemenge em ;
            //using (StreamReader r = new StreamReader(Directory.GetFiles("BusinessObjectExtensions/Energiemenge/completeness", "threeyears.json").First()))
            //{
            //    string jsonString = r.ReadToEnd();
            //    em = JsonConvert.DeserializeObject<Energiemenge>(jsonString);
            //}
            var em = new Energiemenge();
            var dateTime = DateTime.Parse("2015-01-31 22:45:00");
            var listvb = new List<Verbrauch>();
            for (var u = 0; u < 1500; u++)
            {
                dateTime = dateTime.AddMinutes(15);
                var endDateTime = dateTime.AddMinutes(15);

                listvb.Add(new Verbrauch
                { Startdatum = dateTime, Enddatum = endDateTime, Einheit = Mengeneinheit.JAHR, Wert = 12 });
                dateTime = endDateTime;
            }

            em.Energieverbrauch = listvb;

            var mpLinear = MiniProfiler.StartNew("Non-Parallel");
            em.GetMonthlyCompletenessReports(new TimeRange(new DateTime(2015, 1, 1, 23, 00, 0, DateTimeKind.Utc),
                new DateTime(2019, 12, 31, 23, 0, 0, DateTimeKind.Utc)));
            mpLinear.Stop();
            Console.Out.Write(mpLinear.RenderPlainText());
            //Assert.IsTrue(mpLinear.DurationMilliseconds < 4000, $"Linear completeness report generation was too slow. Expected less than 4 seconds but was {mpLinear.DurationMilliseconds}ms: {mpLinear.RenderPlainText()}");

            var mpParallel = MiniProfiler.StartNew("Parallel");
            em.GetDailyCompletenessReports(
                new TimeRange(new DateTime(2015, 1, 01, 23, 0, 0, DateTimeKind.Utc),
                    new DateTime(2019, 12, 31, 23, 0, 0, DateTimeKind.Utc)), true);
            mpParallel.Stop();
            Console.Out.Write(mpParallel.RenderPlainText());
            //Assert.IsTrue(mpParallel.DurationMilliseconds < 3000, $"Parallel completeness report generation was too slow. Expected less than 3 seconds but was {mpParallel.DurationMilliseconds}ms: {mpParallel.RenderPlainText()}");
            //Assert.IsTrue(mpParallel.DurationMilliseconds < (int)mpLinear.DurationMilliseconds * 1.25M, $"Parallel: {mpParallel.DurationMilliseconds}, Non-Parallel: {mpLinear.DurationMilliseconds}");
        }


        [TestMethod]
        public void TestDailyCompletenessDST()
        {
            var localStart = TimeZoneInfo.ConvertTimeFromUtc(
                new DateTimeOffset(2018, 3, 24, 23, 0, 0, TimeSpan.Zero).UtcDateTime,
                CentralEuropeStandardTime.CentralEuropeStandardTimezoneInfo); //, DateTimeKind.Unspecified);
            var localEnd = TimeZoneInfo.ConvertTimeFromUtc(
                new DateTimeOffset(2018, 3, 26, 22, 0, 0, TimeSpan.Zero).UtcDateTime,
                CentralEuropeStandardTime.CentralEuropeStandardTimezoneInfo); //, DateTimeKind.Unspecified);
            if (TimeZoneInfo.Local != CentralEuropeStandardTime.CentralEuropeStandardTimezoneInfo)
            {
                localStart =
                    DateTime.SpecifyKind(
                        TimeZoneInfo.ConvertTime(localStart, TimeZoneInfo.Local,
                            CentralEuropeStandardTime.CentralEuropeStandardTimezoneInfo), DateTimeKind.Unspecified);
                localEnd = DateTime.SpecifyKind(
                    TimeZoneInfo.ConvertTime(localEnd, TimeZoneInfo.Local,
                        CentralEuropeStandardTime.CentralEuropeStandardTimezoneInfo), DateTimeKind.Unspecified);
            }
            else
            {
                localStart = DateTime.SpecifyKind(localStart, DateTimeKind.Unspecified);
                localEnd = DateTime.SpecifyKind(localEnd, DateTimeKind.Unspecified);
            }

            var utcStart = new DateTimeOffset(2018, 3, 24, 23, 0, 0, TimeSpan.Zero);
            var utcEnd = new DateTimeOffset(2018, 3, 26, 22, 0, 0, TimeSpan.Zero);
            if (TimeZoneInfo.Local.SupportsDaylightSavingTime &&
                CentralEuropeStandardTime.CentralEuropeStandardTimezoneInfo.Equals(TimeZoneInfo.Local))
            {
                Assert.IsFalse(
                    CentralEuropeStandardTime.CentralEuropeStandardTimezoneInfo.IsDaylightSavingTime(localStart));
                Assert.IsTrue(
                    CentralEuropeStandardTime.CentralEuropeStandardTimezoneInfo.IsDaylightSavingTime(localEnd));
            }

            var verbrauchSlices = new List<TimeRange>
            {
                new TimeRange
                {
                    Start = utcStart.UtcDateTime,
                    End = utcStart.AddHours(1).UtcDateTime
                }
            };
            while (verbrauchSlices.Last().End < utcEnd)
                verbrauchSlices.Add(new TimeRange
                {
                    Start = verbrauchSlices.Last().Start.AddHours(1),
                    End = verbrauchSlices.Last().End.AddHours(1)
                });
            Assert.AreEqual(2 * 24 - 1, verbrauchSlices.Count);
            var em = new Energiemenge
            {
                LokationsId = "MeinUnitTest123",
                LokationsTyp = Lokationstyp.MeLo,
                Energieverbrauch = verbrauchSlices.Select(vs => new Verbrauch
                {
                    Startdatum = vs.Start,
                    Enddatum = vs.End,
                    Einheit = Mengeneinheit.KWH,
                    Wert = (decimal)123.456,
                    Wertermittlungsverfahren = Wertermittlungsverfahren.MESSUNG
                }
                ).ToList()
            };
            var result = em.GetDailyCompletenessReports(new TimeRange(utcStart.UtcDateTime, utcEnd.UtcDateTime));
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(new DateTimeOffset(2018, 3, 24, 23, 0, 0, TimeSpan.Zero),
                result.First().Value.ReferenceTimeFrame.Startdatum);
            Assert.AreEqual(new DateTimeOffset(2018, 3, 25, 22, 0, 0, TimeSpan.Zero),
                result.First().Value.ReferenceTimeFrame.Enddatum);
            Assert.AreEqual(new DateTimeOffset(2018, 3, 25, 22, 0, 0, TimeSpan.Zero),
                result.Last().Value.ReferenceTimeFrame.Startdatum);
            Assert.AreEqual(new DateTimeOffset(2018, 3, 26, 22, 0, 0, TimeSpan.Zero),
                result.Last().Value.ReferenceTimeFrame.Enddatum);
        }

        [TestMethod]
        public void TestAddDaysDSTSpring()
        {
            var utcDt = new DateTimeOffset(2018, 3, 24, 23, 0, 0, TimeSpan.Zero).UtcDateTime;
            var localDt =
                DateTime.SpecifyKind(
                    TimeZoneInfo.ConvertTimeFromUtc(
                        new DateTimeOffset(2018, 3, 24, 23, 0, 0, TimeSpan.Zero).UtcDateTime,
                        CentralEuropeStandardTime.CentralEuropeStandardTimezoneInfo), DateTimeKind.Unspecified);

            var resultUtc = utcDt.AddDaysDST(1);
            var resultLocal = localDt.AddDaysDST(1);

            Assert.AreEqual(DateTimeKind.Utc, resultUtc.Kind);
            Assert.AreEqual(DateTimeKind.Unspecified, resultLocal.Kind);

            Assert.AreEqual(23, new TimeRange(utcDt, resultUtc).Duration.TotalHours);
            Assert.AreEqual(23, new TimeRange
            {
                Start = TimeZoneInfo.ConvertTimeToUtc(DateTime.SpecifyKind(localDt, DateTimeKind.Unspecified),
                    CentralEuropeStandardTime.CentralEuropeStandardTimezoneInfo),
                End = TimeZoneInfo.ConvertTimeToUtc(DateTime.SpecifyKind(resultLocal, DateTimeKind.Unspecified),
                    CentralEuropeStandardTime.CentralEuropeStandardTimezoneInfo)
            }.Duration.TotalHours);
        }

        [TestMethod]
        public void TestAddDaysDSTAutumn()
        {
            var utcDt = new DateTimeOffset(2018, 10, 27, 22, 0, 0, TimeSpan.Zero).UtcDateTime;
            var localDt =
                DateTime.SpecifyKind(
                    TimeZoneInfo.ConvertTimeFromUtc(
                        new DateTimeOffset(2018, 10, 27, 22, 0, 0, TimeSpan.Zero).UtcDateTime,
                        CentralEuropeStandardTime.CentralEuropeStandardTimezoneInfo), DateTimeKind.Unspecified);

            var resultUtc = utcDt.AddDaysDST(1);
            var resultLocal = localDt.AddDaysDST(1);

            Assert.AreEqual(DateTimeKind.Utc, resultUtc.Kind);
            Assert.AreEqual(DateTimeKind.Unspecified, resultLocal.Kind);

            Assert.AreEqual(25, new TimeRange(utcDt, resultUtc).Duration.TotalHours);
            Assert.AreEqual(25, new TimeRange
            {
                Start = TimeZoneInfo.ConvertTimeToUtc(DateTime.SpecifyKind(localDt, DateTimeKind.Unspecified),
                    CentralEuropeStandardTime.CentralEuropeStandardTimezoneInfo),
                End = TimeZoneInfo.ConvertTimeToUtc(DateTime.SpecifyKind(resultLocal, DateTimeKind.Unspecified),
                    CentralEuropeStandardTime.CentralEuropeStandardTimezoneInfo)
            }.Duration.TotalHours);
        }

        [TestMethod]
        public void TestAddDaysDSTSummer() // could be winter as well ;)
        {
            var utcDt = new DateTimeOffset(2018, 7, 27, 22, 0, 0, TimeSpan.Zero).UtcDateTime;
            var localDt =
                DateTime.SpecifyKind(
                    TimeZoneInfo.ConvertTimeFromUtc(
                        new DateTimeOffset(2018, 7, 27, 22, 0, 0, TimeSpan.Zero).UtcDateTime,
                        CentralEuropeStandardTime.CentralEuropeStandardTimezoneInfo), DateTimeKind.Unspecified);

            var resultUtc = utcDt.AddDaysDST(1);
            var resultLocal = localDt.AddDaysDST(1);

            Assert.AreEqual(DateTimeKind.Utc, resultUtc.Kind);
            Assert.AreEqual(DateTimeKind.Unspecified, resultLocal.Kind);

            Assert.AreEqual(24, new TimeRange(utcDt, resultUtc).Duration.TotalHours);
            Assert.AreEqual(24, new TimeRange
            {
                Start = TimeZoneInfo.ConvertTimeToUtc(DateTime.SpecifyKind(localDt, DateTimeKind.Unspecified),
                    CentralEuropeStandardTime.CentralEuropeStandardTimezoneInfo),
                End = TimeZoneInfo.ConvertTimeToUtc(DateTime.SpecifyKind(resultLocal, DateTimeKind.Unspecified),
                    CentralEuropeStandardTime.CentralEuropeStandardTimezoneInfo)
            }.Duration.TotalHours);
        }
    }
}