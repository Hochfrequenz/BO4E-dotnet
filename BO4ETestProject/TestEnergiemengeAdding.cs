using System;
using System.Collections.Generic;
using BO4E.BO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestBO4E
{
    [TestClass]
    public class TestEnergiemengeAdding
    {
        [TestMethod]
        public void TestSimpleAdd()
        {
            var em1 = new Energiemenge
            {
                LokationsId = "DE123",
                LokationsTyp = BO4E.ENUM.Lokationstyp.MaLo,
                Energieverbrauch = new List<BO4E.COM.Verbrauch>
                {
                    new BO4E.COM.Verbrauch
                    {
                        Einheit = BO4E.ENUM.Mengeneinheit.ANZAHL,
                        Obiskennzahl = "1-2-3",
                        Enddatum = new DateTime(),
                        Startdatum = new DateTime(),
                        Wert = (decimal) 123.456,
                        Wertermittlungsverfahren = BO4E.ENUM.Wertermittlungsverfahren.PROGNOSE
                    }
                }
            };
            var em2 = new Energiemenge
            {
                LokationsId = "DE123",
                LokationsTyp = BO4E.ENUM.Lokationstyp.MaLo,
                Energieverbrauch = new List<BO4E.COM.Verbrauch>
                {
                    new BO4E.COM.Verbrauch
                    {
                        Einheit = BO4E.ENUM.Mengeneinheit.ANZAHL,
                        Obiskennzahl = "4-5-6",
                        Enddatum = new DateTime(),
                        Startdatum = new DateTime(),
                        Wert = (decimal) 123.456,
                        Wertermittlungsverfahren = BO4E.ENUM.Wertermittlungsverfahren.PROGNOSE
                    }
                }
            };
            var result = em1 + em2;
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Energieverbrauch.Count);
        }

        [TestMethod]
        public void TestIllegalAdd()
        {
            var em1 = new Energiemenge
            {
                LokationsId = "DE456",
                LokationsTyp = BO4E.ENUM.Lokationstyp.MeLo
            };
            var em2 = new Energiemenge
            {
                LokationsId = "DE789",
                LokationsTyp = BO4E.ENUM.Lokationstyp.MeLo
            };
            Assert.ThrowsException<InvalidOperationException>(() => em1 + em2);
        }
    }
}