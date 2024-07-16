using System;
using BO4E.BO;
using BO4E.Extensions.BusinessObjects.Energiemenge;
using Itenso.TimePeriod;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace TestBO4E.Extensions;

[TestClass]
public class TestEnergiemengeExtension
{
    internal static readonly TimeRange GERMAN_MARCH_2018 =
        new TimeRange(new DateTime(2018, 2, 28, 23, 0, 0, DateTimeKind.Utc),
            new DateTime(2018, 3, 31, 22, 0, 0, DateTimeKind.Utc));

    internal static readonly TimeRange GERMAN_APRIL_2018 =
        new TimeRange(new DateTime(2018, 3, 31, 22, 0, 0, DateTimeKind.Utc),
            new DateTime(2018, 4, 30, 22, 0, 0, DateTimeKind.Utc));

    internal static readonly TimeRange march2425 =
        new TimeRange(new DateTime(2018, 3, 23, 23, 0, 0, DateTimeKind.Utc),
            new DateTime(2018, 3, 25, 22, 0, 0, DateTimeKind.Utc));

    [TestMethod]
    public void TestTestingRanges()
    {
        Assert.AreEqual(30 * 24, GERMAN_APRIL_2018.Duration.TotalHours); // keine Zeitumstellung im April
        Assert.AreEqual(31 * 24 - 1, GERMAN_MARCH_2018.Duration.TotalHours); // Uhren am 25.03.18 eine Stunde vor
        Assert.AreEqual(47, march2425.Duration.TotalHours);
    }


    [TestMethod]
    public void TestDetangling()
    {
        var em = JsonConvert.DeserializeObject<Energiemenge>(
            "{\"versionStruktur\":1,\"boTyp\":\"ENERGIEMENGE\",\"lokationsId\":\"DE0003604780400000000000012345678\",\"lokationstyp\":\"MeLo\",\"energieverbrauch\":[{\"startdatum\":\"2019-03-01T00:00:00Z\",\"enddatum\":\"2019-06-24T00:00:00Z\",\"wertermittlungsverfahren\":\"MESSUNG\",\"obiskennzahl\":\"1-0:1.8.0\",\"wert\":1,\"einheit\":\"KWH\",\"zaehlernummer\":\"10654212\"},{\"startdatum\":\"2019-03-01T00:00:00Z\",\"enddatum\":\"2019-06-24T00:00:00Z\",\"wertermittlungsverfahren\":\"MESSUNG\",\"obiskennzahl\":\"1-0:2.8.0\",\"wert\":1,\"einheit\":\"KWH\",\"zaehlernummer\":\"10654212\"}],\"anlagennummer\":\"50693510\",\"messlokationsId\":\"DE0003604780400000000000012345678\",\"marktlokationsId\":\"\",\"isMelo\":true,\"zaehlernummer\":\"10654212\"}");
        em.Detangle();
        Assert.AreEqual(2, em.Energieverbrauch.Count);
        // todo: add real test. this one is limited.
    }
}
