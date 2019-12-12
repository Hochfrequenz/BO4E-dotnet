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
            Energiemenge em1 = new Energiemenge()
            {
                lokationsId = "DE123",
                lokationstyp = BO4E.ENUM.Lokationstyp.MaLo,
                energieverbrauch = new List<BO4E.COM.Verbrauch>()
                {
                    new BO4E.COM.Verbrauch()
                    {
                        einheit = BO4E.ENUM.Mengeneinheit.ANZAHL,
                        obiskennzahl = "1-2-3",
                        enddatum = new DateTime(),
                        startdatum = new DateTime(),
                        wert = (decimal)123.456,
                        wertermittlungsverfahren= BO4E.ENUM.Wertermittlungsverfahren.PROGNOSE
                    }
                }
            };
            Energiemenge em2 = new Energiemenge()
            {
                lokationsId = "DE123",
                lokationstyp = BO4E.ENUM.Lokationstyp.MaLo,
                energieverbrauch = new List<BO4E.COM.Verbrauch>()
                {
                    new BO4E.COM.Verbrauch()
                    {
                        einheit = BO4E.ENUM.Mengeneinheit.ANZAHL,
                        obiskennzahl = "4-5-6",
                        enddatum = new DateTime(),
                        startdatum = new DateTime(),
                        wert = (decimal)123.456,
                        wertermittlungsverfahren= BO4E.ENUM.Wertermittlungsverfahren.PROGNOSE
                    }
                }
            };
            Energiemenge result = em1 + em2;
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.energieverbrauch.Count);
        }

        [TestMethod]
        public void TestIllegalAdd()
        {
            Energiemenge em1 = new Energiemenge()
            {
                lokationsId = "DE456",
                lokationstyp = BO4E.ENUM.Lokationstyp.MeLo
            };
            Energiemenge em2 = new Energiemenge()
            {
                lokationsId = "DE789",
                lokationstyp = BO4E.ENUM.Lokationstyp.MeLo
            };
            Assert.ThrowsException<InvalidOperationException>(() => em1 + em2);
        }
    }


}
