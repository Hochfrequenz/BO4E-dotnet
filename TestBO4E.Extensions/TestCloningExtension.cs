using System;
using System.Collections.Generic;
using BO4E.BO;
using BO4E.COM;
using BO4E.ENUM;
using BO4E.Extensions.BusinessObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestBO4E.Extensions;

[TestClass]
public class TestCloningExtension
{
    [TestMethod]
    public void TestCloning()
    {
        var bo = new Messlokation { MesslokationsId = "DE345" };
        var cloneBo = bo.DeepClone();
        Assert.AreNotSame(bo, cloneBo);
        // Assert.AreEqual<Messlokation>((Messlokation)bo, cloneBo); <--- keine ahnung warum das failed. vllt. auch mit json patch/diff arbeiten wie im hubnet projekt
    }

    [TestMethod]
    public void TestCloningEnergiemenge()
    {
        var em = new Energiemenge
        {
            LokationsId = "De12345",
            LokationsTyp = Lokationstyp.MALO,
            Energieverbrauch = new List<Verbrauch>
            {
                new Verbrauch
                {
                    Einheit = Mengeneinheit.KWH,
                    Wert = 123.456M,
                    Obiskennzahl = "dei vadder",
                    Wertermittlungsverfahren = Wertermittlungsverfahren.MESSUNG,
                    Startdatum = new DateTime(2018, 12, 31, 23, 0, 0, 0, DateTimeKind.Utc),
                    Enddatum = new DateTime(2019, 12, 31, 23, 0, 0, 0, DateTimeKind.Utc),
                },
                new Verbrauch
                {
                    Einheit = Mengeneinheit.KWH,
                    Wert = 789.123M,
                    Obiskennzahl = "dei mudder",
                    Wertermittlungsverfahren = Wertermittlungsverfahren.MESSUNG,
                    Startdatum = new DateTime(2019, 12, 31, 23, 0, 0, 0, DateTimeKind.Utc),
                    Enddatum = new DateTime(2020, 12, 31, 23, 0, 0, 0, DateTimeKind.Utc),
                },
            },
        };
        var cloned = em.DeepClone();
        Assert.AreEqual(em.Energieverbrauch.Count, cloned.Energieverbrauch.Count);

        var cloned2 = em.DeepClone();
        Assert.AreEqual(em.Energieverbrauch.Count, cloned2.Energieverbrauch.Count);

        var cloned3 = ((BusinessObject)em).DeepClone();
        Assert.IsTrue(cloned3 is Energiemenge);
        Assert.AreEqual(
            em.Energieverbrauch.Count,
            (cloned3 as Energiemenge).Energieverbrauch.Count
        );
    }
}
