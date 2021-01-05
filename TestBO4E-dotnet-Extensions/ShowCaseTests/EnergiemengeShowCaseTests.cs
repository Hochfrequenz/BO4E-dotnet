using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using BO4E.BO;
using BO4E.COM;
using BO4E.ENUM;
using BO4E.Extensions.BusinessObjects.Energiemenge;

using Itenso.TimePeriod;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestBO4E.ShowCaseTests
{
    [TestClass]
    public class EnergiemengeShowCaseTests
    {
        [TestMethod]
        public void ShowCaseTest()
        {
            var em = new Energiemenge
            {
                LokationsId = "DE0123456789012345678901234567890",
                LokationsTyp = Lokationstyp.MeLo,
                Energieverbrauch = new List<Verbrauch>
                {
                   new Verbrauch
                   {
                       Einheit = Mengeneinheit.KWH,
                       Startdatum = new DateTime(2020,3,1,0,0,0,DateTimeKind.Utc),
                       Enddatum = new DateTime(2020,3,8,0,0,0,DateTimeKind.Utc),
                       Wert = 456.0M,
                       Wertermittlungsverfahren = Wertermittlungsverfahren.MESSUNG
                   },
                   new Verbrauch
                   {
                       Einheit = Mengeneinheit.KWH,
                       Startdatum = new DateTime(2020,3,25,0,0,0,DateTimeKind.Utc),
                       Enddatum = new DateTime(2020,4,1,0,0,0,DateTimeKind.Utc),
                       Wert = 123.0M,
                       Wertermittlungsverfahren = Wertermittlungsverfahren.MESSUNG
                   }
                }
            };
            Debug.WriteLine($"You got Verbrauch data for {Decimal.Round(em.GetCoverage() * 100.0M)}% of the time in between {em.Energieverbrauch.Select(v => v.Startdatum).Min().ToString("yyyy-MM-dd")} and {em.Energieverbrauch.Select(v => v.Enddatum).Max().ToString("yyyy-MM-dd")}");
            // You got Verbrauch data for 45% of the time in between 2020-03-01 and 2020-04-01

            var consumption = em.GetTotalConsumption();
            Debug.WriteLine($"The total consumption is {consumption.Item1}{consumption.Item2}");
            // The total consumption is 579,0KWH

            var consumptionMarch7 = em.GetConsumption(new TimeRange(start: new DateTimeOffset(2020, 3, 7, 0, 0, 0, TimeSpan.Zero).UtcDateTime, end: new DateTimeOffset(2020, 3, 8, 0, 0, 0, TimeSpan.Zero).UtcDateTime));
            Debug.WriteLine($"The total consumption on March 7 is {Decimal.Round(consumptionMarch7.Item1)}{consumptionMarch7.Item2}");
            // The total consumption on March 7 is 65KWH

            // ToDo: show other methods.
        }
    }
}