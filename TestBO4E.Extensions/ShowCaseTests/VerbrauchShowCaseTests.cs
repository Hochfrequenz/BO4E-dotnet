using System;
using System.Diagnostics;
using BO4E.COM;
using BO4E.ENUM;
using BO4E.Extensions.COM;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestBO4E.Extensions.ShowCaseTests
{
    [TestClass]
    public class VerbrauchShowCaseTests
    {
        [TestMethod]
        public void ShowCaseTest()
        {
            var verbrauchA = new Verbrauch
            {
                Startdatum = new DateTime(2020, 3, 1, 0, 0, 0, DateTimeKind.Utc),
                Enddatum = new DateTime(2020, 3, 8, 0, 0, 0, DateTimeKind.Utc),
                Wert = 0.456M,
                Einheit = Mengeneinheit.MW,
                Wertermittlungsverfahren = Wertermittlungsverfahren.MESSUNG
            };

            verbrauchA.ConvertToUnit(Mengeneinheit.KW);
            Debug.WriteLine($"{nameof(verbrauchA)} contains {verbrauchA.Wert}{verbrauchA.Einheit}");
            // v contains 456,000KW

            try
            {
                verbrauchA.ConvertToUnit(Mengeneinheit.TAG);
            }
            catch (InvalidOperationException ioe)
            {
                Debug.WriteLine(ioe.Message);
                // KW and TAG are not convertible into each other because they don't share the same dimension.
            }

            var verbrauchB = new Verbrauch
            {
                Startdatum = new DateTime(2020, 3, 7, 0, 0, 0, DateTimeKind.Utc),
                Enddatum = new DateTime(2020, 3, 14, 0, 0, 0, DateTimeKind.Utc),
                Wert = 0.1M,
                Einheit = Mengeneinheit.KW,
                Wertermittlungsverfahren = Wertermittlungsverfahren.MESSUNG
            };

            foreach (var v in verbrauchA.Merge(verbrauchB))
                Debug.WriteLine($"{v.Startdatum:yyyy-MM-dd} to {v.Enddatum:yyyy-MM-dd}: {v.Wert}{v.Einheit}");
            // 2020-03-01 to 2020-03-07: 456,000KW
            // 2020-03-07 to 2020-03-08: 456,100KW
            // 2020-03-08 to 2020-03-14: 0,1KW
        }
    }
}