using System;
using BO4E.COM;
using BO4E.ENUM;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestBO4E;

[TestClass]
public class TestComValidity
{
    [TestMethod]
    public void TestVerbrauch()
    {
        var v1 = new Verbrauch();
        Assert.IsFalse(v1.IsValid());
        var v2 = new Verbrauch
        {
            Startdatum = new DateTimeOffset(),
            Enddatum = new DateTimeOffset(),
            Einheit = Mengeneinheit.ANZAHL,
            Wert = (decimal)123.456,
            Obiskennzahl = "asd"
        };
        Assert.IsTrue(v2.IsValid());
    }
}
