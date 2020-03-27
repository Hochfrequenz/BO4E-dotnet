using System;
using BO4E.COM;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestBO4E
{
    [TestClass]
    public class TestCOMValidity
    {
        [TestMethod]
        public void TestVerbrauch()
        {
            Verbrauch v1 = new Verbrauch();
            Assert.IsFalse(v1.IsValid());
            Verbrauch v2 = new Verbrauch
            {
                Startdatum = new DateTime(),
                Enddatum = new DateTime(),
                Einheit = BO4E.ENUM.Mengeneinheit.ANZAHL,
                Wert = (decimal)123.456,
                Obiskennzahl = "asd"
            };
            Assert.IsTrue(v2.IsValid());
        }
    }
}