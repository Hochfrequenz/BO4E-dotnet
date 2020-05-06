using System;
using BO4E.ENUM;
using BO4E.Extensions.ENUM;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestBO4EExtensions
{
    [TestClass]
    public class TestMengeneinheitExtension
    {

        [TestMethod]
        public void TestConvertibility()
        {
            Assert.IsTrue(Mengeneinheit.KW.IsConvertibleTo(Mengeneinheit.MW));
            Assert.IsTrue(Mengeneinheit.MW.IsConvertibleTo(Mengeneinheit.KW));
            Assert.IsTrue(Mengeneinheit.KWH.IsConvertibleTo(Mengeneinheit.MWH));
            Assert.IsFalse(Mengeneinheit.JAHR.IsConvertibleTo(Mengeneinheit.KUBIKMETER));
        }

        [TestMethod]
        public void TestConversionFactor()
        {
            foreach (Mengeneinheit me in Enum.GetValues(typeof(Mengeneinheit)))
            {
                if ((int)me == 0)
                {
                    continue;
                }
                Assert.AreEqual(1.0M, me.GetConversionFactor(me));
                Assert.IsTrue(me.IsConvertibleTo(me));
            }
            Assert.AreEqual(1000.0M, Mengeneinheit.KWH.GetConversionFactor(Mengeneinheit.WH));
            Assert.AreEqual(1000.0M, Mengeneinheit.MWH.GetConversionFactor(Mengeneinheit.KWH));
            Assert.AreEqual(12.0M, Mengeneinheit.JAHR.GetConversionFactor(Mengeneinheit.MONAT));
            Assert.AreEqual(0.000001M, Mengeneinheit.WH.GetConversionFactor(Mengeneinheit.MWH));
            Assert.AreEqual(0.001M, Mengeneinheit.KW.GetConversionFactor(Mengeneinheit.MW));

            foreach (Mengeneinheit me1 in Enum.GetValues(typeof(Mengeneinheit)))
            {
                foreach (Mengeneinheit me2 in Enum.GetValues(typeof(Mengeneinheit)))
                {
                    if (!me1.IsConvertibleTo(me2))
                    {
                        Assert.ThrowsException<InvalidOperationException>(() => me1.GetConversionFactor(me2), $"Conversion {me1}-->{me2} should throw an exception!");
                    }
                }
            }
        }
    }
}