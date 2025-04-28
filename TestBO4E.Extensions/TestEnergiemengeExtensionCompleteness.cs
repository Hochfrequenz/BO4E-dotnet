using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BO4E.BO;
using BO4E.COM;
using BO4E.ENUM;
using BO4E.Extensions.BusinessObjects.Energiemenge;
using BO4E.meta;
using BO4E.meta.LenientConverters;
using Itenso.TimePeriod;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace TestBO4E.Extensions;

[TestClass]
public class TestEnergiemengeExtensionCompleteness
{
    internal static readonly TimeRange CHRISTMAS_2018 = new TimeRange(
        new DateTimeOffset(2018, 12, 23, 22, 0, 0, TimeSpan.Zero).UtcDateTime,
        new DateTimeOffset(2018, 12, 31, 22, 0, 0, TimeSpan.Zero).UtcDateTime
    );

    internal static readonly TimeRange GERMAN_YEAR_2018 = new TimeRange(
        new DateTimeOffset(2017, 12, 31, 23, 0, 0, TimeSpan.Zero).UtcDateTime,
        new DateTimeOffset(2018, 12, 31, 23, 0, 0, TimeSpan.Zero).UtcDateTime
    );

    [TestMethod]
    public void TestFirstLastGap()
    {
        var em = new Energiemenge
        {
            LokationsId = "DE123455",
            LokationsTyp = Lokationstyp.MELO,
            Energieverbrauch = new List<Verbrauch>
            {
                new Verbrauch
                {
                    Obiskennzahl = "1234",
                    Wert = 123.456M,
                    Wertermittlungsverfahren = Wertermittlungsverfahren.MESSUNG,
                    Startdatum = new DateTimeOffset(2019, 1, 1, 0, 0, 0, TimeSpan.Zero).UtcDateTime,
                    Enddatum = new DateTimeOffset(2019, 1, 4, 0, 0, 0, TimeSpan.Zero).UtcDateTime,
                },
                new Verbrauch
                {
                    Obiskennzahl = "1234",
                    Wert = 123.456M,
                    Wertermittlungsverfahren = Wertermittlungsverfahren.MESSUNG,
                    Startdatum = new DateTimeOffset(2019, 1, 4, 0, 0, 0, TimeSpan.Zero).UtcDateTime,
                    Enddatum = new DateTimeOffset(2019, 1, 7, 0, 0, 0, TimeSpan.Zero).UtcDateTime,
                },
            },
        };

        var cr = em.GetCompletenessReport(
            new TimeRange(
                new DateTime(2018, 12, 29, 0, 0, 0, DateTimeKind.Utc),
                new DateTime(2019, 1, 10, 0, 0, 0, DateTimeKind.Utc)
            )
        );
        Assert.AreEqual(2, cr.Gaps.Count);
        Assert.AreEqual(
            new DateTimeOffset(2018, 12, 29, 0, 0, 0, TimeSpan.Zero),
            cr.Gaps.First().Startdatum
        );
        Assert.AreEqual(
            new DateTimeOffset(2019, 1, 1, 0, 0, 0, TimeSpan.Zero),
            cr.Gaps.First().Enddatum
        );
        Assert.AreEqual(
            new DateTimeOffset(2019, 1, 7, 0, 0, 0, TimeSpan.Zero),
            cr.Gaps.Last().Startdatum
        );
        Assert.AreEqual(
            new DateTimeOffset(2019, 1, 10, 0, 0, 0, TimeSpan.Zero),
            cr.Gaps.Last().Enddatum
        );
    }

    [TestMethod]
    public void TestNullableCoverage()
    {
        var em1 = new Energiemenge
        {
            LokationsId = "DE123456789DieseEmhatkeineVerbräuche",
            LokationsTyp = Lokationstyp.MELO,
            Energieverbrauch =
                new List<Verbrauch>() //empty list
            ,
        };
        var cr1 = em1.GetCompletenessReport();
        Assert.IsNotNull(cr1);
        Assert.IsNull(cr1.Coverage);
        JsonConvert.SerializeObject(cr1); // must _not_ throw exception

        var em2 = new Energiemenge
        {
            LokationsId = "54321012345DieseEmhatkeineVerbräuche",
            LokationsTyp = Lokationstyp.MELO,
            Energieverbrauch =
                new List<Verbrauch>() //empty list
            ,
        };
        var cr2 = em2.GetCompletenessReport(
            CHRISTMAS_2018,
            Wertermittlungsverfahren.MESSUNG,
            "1-2-3-4",
            Mengeneinheit.KUBIKMETER
        );
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
        foreach (
            var boFile in Directory.GetFiles("Energiemenge/completeness/", "50hz_prognose*.json")
        )
        {
            string jsonString;
            using (var r = new StreamReader(boFile))
            {
                jsonString = r.ReadToEnd();
            }
            var em = JsonConvert.DeserializeObject<Energiemenge>(jsonString);
            var result = em.GetDailyCompletenessReports(CHRISTMAS_2018);
            Assert.AreEqual(8, result.Count);
            break; // one test is enough. the rest is covered by the individual completeness report tests.
        }
    }

    [TestMethod]
    [Obsolete]
    public void TestMonthlySlices()
    {
        TestMonthlySlices(true);
    }

    [Obsolete]
    internal void TestMonthlySlices(bool testFirstOnly = true, bool useParallelExecution = false)
    {
        foreach (
            var boFile in Directory.GetFiles("Energiemenge/completeness", "50hz_prognose*.json")
        )
        {
            string jsonString;
            using (var r = new StreamReader(boFile))
            {
                jsonString = r.ReadToEnd();
            }
            var em = JsonConvert.DeserializeObject<Energiemenge>(jsonString);
            var result = em.GetMonthlyCompletenessReports(GERMAN_YEAR_2018, useParallelExecution);
            Assert.AreEqual(12, result.Count); // don't care about values of coverage, just the start/end and count of reports generated.
            if (testFirstOnly)
            {
                break; // one test is enough. the rest is covered by the individual completeness report tests
            }
        }
    }

    [DoNotParallelize]
    [TestMethod]
    public void TestParallization()
    {
        for (var i = 0; i < 10; i++)
        {
            Energiemenge em;
            using (
                var r = new StreamReader(
                    Directory.GetFiles("Energiemenge/completeness", "threeyears.json").First()
                )
            )
            {
                var jsonString = r.ReadToEnd();
                em = JsonConvert.DeserializeObject<Energiemenge>(jsonString);
            }

            em.GetMonthlyCompletenessReports(
                new TimeRange(
                    new DateTime(2016, 1, 31, 23, 0, 0, DateTimeKind.Utc),
                    new DateTime(2016, 12, 31, 23, 0, 0, DateTimeKind.Utc)
                )
            );

            em.GetMonthlyCompletenessReports(
                new TimeRange(
                    new DateTime(2016, 1, 31, 23, 0, 0, DateTimeKind.Utc),
                    new DateTime(2016, 12, 31, 23, 0, 0, DateTimeKind.Utc)
                ),
                true
            );

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
            em = await JsonSerializer.DeserializeAsync<Energiemenge>(
                openStream,
                LenientParsing.MOST_LENIENT.GetJsonSerializerOptions()
            );

            em.GetMonthlyCompletenessReports(
                new TimeRange(
                    new DateTime(2016, 1, 31, 23, 0, 0, DateTimeKind.Utc),
                    new DateTime(2016, 12, 31, 23, 0, 0, DateTimeKind.Utc)
                )
            );

            em.GetMonthlyCompletenessReports(
                new TimeRange(
                    new DateTime(2016, 1, 31, 23, 0, 0, DateTimeKind.Utc),
                    new DateTime(2016, 12, 31, 23, 0, 0, DateTimeKind.Utc)
                ),
                true
            );

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

            listvb.Add(
                new Verbrauch
                {
                    Startdatum = dateTime,
                    Enddatum = endDateTime,
                    Einheit = Mengeneinheit.JAHR,
                    Wert = 12,
                }
            );
            dateTime = endDateTime;
        }

        em.Energieverbrauch = listvb;

        em.GetMonthlyCompletenessReports(
            new TimeRange(
                new DateTime(2015, 1, 1, 23, 00, 0, DateTimeKind.Utc),
                new DateTime(2019, 12, 31, 23, 0, 0, DateTimeKind.Utc)
            )
        );

        //Assert.IsTrue(mpLinear.DurationMilliseconds < 4000, $"Linear completeness report generation was too slow. Expected less than 4 seconds but was {mpLinear.DurationMilliseconds}ms: {mpLinear.RenderPlainText()}");

        em.GetDailyCompletenessReports(
            new TimeRange(
                new DateTime(2015, 1, 01, 23, 0, 0, DateTimeKind.Utc),
                new DateTime(2019, 12, 31, 23, 0, 0, DateTimeKind.Utc)
            ),
            true
        );

        //Assert.IsTrue(mpParallel.DurationMilliseconds < 3000, $"Parallel completeness report generation was too slow. Expected less than 3 seconds but was {mpParallel.DurationMilliseconds}ms: {mpParallel.RenderPlainText()}");
        //Assert.IsTrue(mpParallel.DurationMilliseconds < (int)mpLinear.DurationMilliseconds * 1.25M, $"Parallel: {mpParallel.DurationMilliseconds}, Non-Parallel: {mpLinear.DurationMilliseconds}");
    }

    [TestMethod]
    public void TestDailyCompletenessDST()
    {
        var localStart = TimeZoneInfo.ConvertTimeFromUtc(
            new DateTimeOffset(2018, 3, 24, 23, 0, 0, TimeSpan.Zero).UtcDateTime,
            CentralEuropeStandardTime.CentralEuropeStandardTimezoneInfo
        ); //, DateTimeKind.Unspecified);
        var localEnd = TimeZoneInfo.ConvertTimeFromUtc(
            new DateTimeOffset(2018, 3, 26, 22, 0, 0, TimeSpan.Zero).UtcDateTime,
            CentralEuropeStandardTime.CentralEuropeStandardTimezoneInfo
        ); //, DateTimeKind.Unspecified);
        if (TimeZoneInfo.Local != CentralEuropeStandardTime.CentralEuropeStandardTimezoneInfo)
        {
            localStart = DateTime.SpecifyKind(
                TimeZoneInfo.ConvertTime(
                    localStart,
                    TimeZoneInfo.Local,
                    CentralEuropeStandardTime.CentralEuropeStandardTimezoneInfo
                ),
                DateTimeKind.Unspecified
            );
            localEnd = DateTime.SpecifyKind(
                TimeZoneInfo.ConvertTime(
                    localEnd,
                    TimeZoneInfo.Local,
                    CentralEuropeStandardTime.CentralEuropeStandardTimezoneInfo
                ),
                DateTimeKind.Unspecified
            );
        }
        else
        {
            localStart = DateTime.SpecifyKind(localStart, DateTimeKind.Unspecified);
            localEnd = DateTime.SpecifyKind(localEnd, DateTimeKind.Unspecified);
        }

        var utcStart = new DateTimeOffset(2018, 3, 24, 23, 0, 0, TimeSpan.Zero);
        var utcEnd = new DateTimeOffset(2018, 3, 26, 22, 0, 0, TimeSpan.Zero);
        if (
            TimeZoneInfo.Local.SupportsDaylightSavingTime
            && CentralEuropeStandardTime.CentralEuropeStandardTimezoneInfo.Equals(
                TimeZoneInfo.Local
            )
        )
        {
            Assert.IsFalse(
                CentralEuropeStandardTime.CentralEuropeStandardTimezoneInfo.IsDaylightSavingTime(
                    localStart
                )
            );
            Assert.IsTrue(
                CentralEuropeStandardTime.CentralEuropeStandardTimezoneInfo.IsDaylightSavingTime(
                    localEnd
                )
            );
        }

        var verbrauchSlices = new List<TimeRange>
        {
            new TimeRange { Start = utcStart.UtcDateTime, End = utcStart.AddHours(1).UtcDateTime },
        };
        while (verbrauchSlices.Last().End < utcEnd)
            verbrauchSlices.Add(
                new TimeRange
                {
                    Start = verbrauchSlices.Last().Start.AddHours(1),
                    End = verbrauchSlices.Last().End.AddHours(1),
                }
            );
        Assert.AreEqual(2 * 24 - 1, verbrauchSlices.Count);
        var em = new Energiemenge
        {
            LokationsId = "MeinUnitTest123",
            LokationsTyp = Lokationstyp.MELO,
            Energieverbrauch = verbrauchSlices
                .Select(vs => new Verbrauch
                {
                    Startdatum = vs.Start,
                    Enddatum = vs.End,
                    Einheit = Mengeneinheit.KWH,
                    Wert = (decimal)123.456,
                    Wertermittlungsverfahren = Wertermittlungsverfahren.MESSUNG,
                })
                .ToList(),
        };
        var result = em.GetDailyCompletenessReports(
            new TimeRange(utcStart.UtcDateTime, utcEnd.UtcDateTime)
        );
        Assert.AreEqual(2, result.Count);
        Assert.AreEqual(
            new DateTimeOffset(2018, 3, 24, 23, 0, 0, TimeSpan.Zero),
            result.First().Value.ReferenceTimeFrame.Startdatum
        );
        Assert.AreEqual(
            new DateTimeOffset(2018, 3, 25, 22, 0, 0, TimeSpan.Zero),
            result.First().Value.ReferenceTimeFrame.Enddatum
        );
        Assert.AreEqual(
            new DateTimeOffset(2018, 3, 25, 22, 0, 0, TimeSpan.Zero),
            result.Last().Value.ReferenceTimeFrame.Startdatum
        );
        Assert.AreEqual(
            new DateTimeOffset(2018, 3, 26, 22, 0, 0, TimeSpan.Zero),
            result.Last().Value.ReferenceTimeFrame.Enddatum
        );
    }

    [TestMethod]
    public void TestAddDaysDSTSpring()
    {
        var utcDt = new DateTimeOffset(2018, 3, 24, 23, 0, 0, TimeSpan.Zero).UtcDateTime;
        var localDt = DateTime.SpecifyKind(
            TimeZoneInfo.ConvertTimeFromUtc(
                new DateTimeOffset(2018, 3, 24, 23, 0, 0, TimeSpan.Zero).UtcDateTime,
                CentralEuropeStandardTime.CentralEuropeStandardTimezoneInfo
            ),
            DateTimeKind.Unspecified
        );

        var resultUtc = utcDt.AddDaysDST(1);
        var resultLocal = localDt.AddDaysDST(1);

        Assert.AreEqual(DateTimeKind.Utc, resultUtc.Kind);
        Assert.AreEqual(DateTimeKind.Unspecified, resultLocal.Kind);

        Assert.AreEqual(23, new TimeRange(utcDt, resultUtc).Duration.TotalHours);
        Assert.AreEqual(
            23,
            new TimeRange
            {
                Start = TimeZoneInfo.ConvertTimeToUtc(
                    DateTime.SpecifyKind(localDt, DateTimeKind.Unspecified),
                    CentralEuropeStandardTime.CentralEuropeStandardTimezoneInfo
                ),
                End = TimeZoneInfo.ConvertTimeToUtc(
                    DateTime.SpecifyKind(resultLocal, DateTimeKind.Unspecified),
                    CentralEuropeStandardTime.CentralEuropeStandardTimezoneInfo
                ),
            }
                .Duration
                .TotalHours
        );
    }

    [TestMethod]
    public void TestAddDaysDSTAutumn()
    {
        var utcDt = new DateTimeOffset(2018, 10, 27, 22, 0, 0, TimeSpan.Zero).UtcDateTime;
        var localDt = DateTime.SpecifyKind(
            TimeZoneInfo.ConvertTimeFromUtc(
                new DateTimeOffset(2018, 10, 27, 22, 0, 0, TimeSpan.Zero).UtcDateTime,
                CentralEuropeStandardTime.CentralEuropeStandardTimezoneInfo
            ),
            DateTimeKind.Unspecified
        );

        var resultUtc = utcDt.AddDaysDST(1);
        var resultLocal = localDt.AddDaysDST(1);

        Assert.AreEqual(DateTimeKind.Utc, resultUtc.Kind);
        Assert.AreEqual(DateTimeKind.Unspecified, resultLocal.Kind);

        Assert.AreEqual(25, new TimeRange(utcDt, resultUtc).Duration.TotalHours);
        Assert.AreEqual(
            25,
            new TimeRange
            {
                Start = TimeZoneInfo.ConvertTimeToUtc(
                    DateTime.SpecifyKind(localDt, DateTimeKind.Unspecified),
                    CentralEuropeStandardTime.CentralEuropeStandardTimezoneInfo
                ),
                End = TimeZoneInfo.ConvertTimeToUtc(
                    DateTime.SpecifyKind(resultLocal, DateTimeKind.Unspecified),
                    CentralEuropeStandardTime.CentralEuropeStandardTimezoneInfo
                ),
            }
                .Duration
                .TotalHours
        );
    }

    [TestMethod]
    public void TestAddDaysDSTSummer() // could be winter as well ;)
    {
        var utcDt = new DateTimeOffset(2018, 7, 27, 22, 0, 0, TimeSpan.Zero).UtcDateTime;
        var localDt = DateTime.SpecifyKind(
            TimeZoneInfo.ConvertTimeFromUtc(
                new DateTimeOffset(2018, 7, 27, 22, 0, 0, TimeSpan.Zero).UtcDateTime,
                CentralEuropeStandardTime.CentralEuropeStandardTimezoneInfo
            ),
            DateTimeKind.Unspecified
        );

        var resultUtc = utcDt.AddDaysDST(1);
        var resultLocal = localDt.AddDaysDST(1);

        Assert.AreEqual(DateTimeKind.Utc, resultUtc.Kind);
        Assert.AreEqual(DateTimeKind.Unspecified, resultLocal.Kind);

        Assert.AreEqual(24, new TimeRange(utcDt, resultUtc).Duration.TotalHours);
        Assert.AreEqual(
            24,
            new TimeRange
            {
                Start = TimeZoneInfo.ConvertTimeToUtc(
                    DateTime.SpecifyKind(localDt, DateTimeKind.Unspecified),
                    CentralEuropeStandardTime.CentralEuropeStandardTimezoneInfo
                ),
                End = TimeZoneInfo.ConvertTimeToUtc(
                    DateTime.SpecifyKind(resultLocal, DateTimeKind.Unspecified),
                    CentralEuropeStandardTime.CentralEuropeStandardTimezoneInfo
                ),
            }
                .Duration
                .TotalHours
        );
    }
}
