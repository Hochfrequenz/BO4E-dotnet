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
                        Einheit = BO4E.ENUM.Mengeneinheit.ANZAHL,
                        Obiskennzahl = "1-2-3",
                        Enddatum = new DateTime(),
                        Startdatum = new DateTime(),
                        Wert = (decimal)123.456,
                        Wertermittlungsverfahren= BO4E.ENUM.Wertermittlungsverfahren.PROGNOSE
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
                        Einheit = BO4E.ENUM.Mengeneinheit.ANZAHL,
                        Obiskennzahl = "4-5-6",
                        Enddatum = new DateTime(),
                        Startdatum = new DateTime(),
                        Wert = (decimal)123.456,
                        Wertermittlungsverfahren= BO4E.ENUM.Wertermittlungsverfahren.PROGNOSE
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
