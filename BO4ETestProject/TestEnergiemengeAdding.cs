using System;
using System.Collections.Generic;
using BO4E.BO;
using BO4E.COM;
using BO4E.ENUM;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestBO4E;

[TestClass]
public class TestEnergiemengeAdding
{
    [TestMethod]
    public void TestSimpleAdd()
    {
        var em1 = new Energiemenge
        {
            LokationsId = "DE123",
            LokationsTyp = Lokationstyp.MALO,
            Energieverbrauch = new List<Verbrauch>
            {
                new Verbrauch
                {
                    Einheit = Mengeneinheit.ANZAHL,
                    Obiskennzahl = "1-2-3",
                    Enddatum = new DateTimeOffset(),
                    Startdatum = new DateTimeOffset(),
                    Wert = (decimal) 123.456,
                    Wertermittlungsverfahren = Wertermittlungsverfahren.PROGNOSE
                }
            }
        };
        var em2 = new Energiemenge
        {
            LokationsId = "DE123",
            LokationsTyp = Lokationstyp.MALO,
            Energieverbrauch = new List<Verbrauch>
            {
                new Verbrauch
                {
                    Einheit = Mengeneinheit.ANZAHL,
                    Obiskennzahl = "4-5-6",
                    Enddatum = new DateTimeOffset(),
                    Startdatum = new DateTimeOffset(),
                    Wert = (decimal) 123.456,
                    Wertermittlungsverfahren = Wertermittlungsverfahren.PROGNOSE
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
            LokationsTyp = Lokationstyp.MELO
        };
        var em2 = new Energiemenge
        {
            LokationsId = "DE789",
            LokationsTyp = Lokationstyp.MELO
        };
        Assert.ThrowsException<InvalidOperationException>(() => em1 + em2);
    }
}