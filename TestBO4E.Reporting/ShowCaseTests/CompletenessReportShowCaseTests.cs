using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using BO4E.BO;
using BO4E.COM;
using BO4E.ENUM;
using BO4E.Extensions.BusinessObjects.Energiemenge;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestBO4E.Reporting.ShowCaseTests
{
    [TestClass]
    public class CompletenessReportShowCaseTests
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
                        Startdatum = new DateTimeOffset(2020, 3, 1, 0, 0, 0, TimeSpan.Zero).UtcDateTime,
                        Enddatum = new DateTimeOffset(2020, 3, 8, 0, 0, 0, TimeSpan.Zero).UtcDateTime,
                        Wert = 456.0M,
                        Wertermittlungsverfahren = Wertermittlungsverfahren.MESSUNG
                    },
                    new Verbrauch
                    {
                        Einheit = Mengeneinheit.KWH,
                        Startdatum = new DateTimeOffset(2020, 3, 25, 0, 0, 0, TimeSpan.Zero).UtcDateTime,
                        Enddatum = new DateTimeOffset(2020, 4, 1, 0, 0, 0, TimeSpan.Zero).UtcDateTime,
                        Wert = 123.0M,
                        Wertermittlungsverfahren = Wertermittlungsverfahren.MESSUNG
                    }
                }
            };

            var cr = em.GetCompletenessReport();
            Debug.WriteLine($"{nameof(em)} has a coverage of {decimal.Round(cr.Coverage.Value * 100.0M)}%.");
            // em has a coverage of 45%.

            Debug.WriteLine(
                $"{nameof(em)} has no values for the following intervals: {string.Join(", ", cr.Gaps.Select(g => g.Startdatum.ToString("yyyy-MM-dd") + " to " + g.Enddatum.ToString("yyyy-MM-dd")))}");
            // em has no values for the following intervals: 2020-03-08 to 2020-03-25
        }
    }
}