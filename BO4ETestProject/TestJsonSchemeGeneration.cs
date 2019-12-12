using System;
using BO4E.BO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestBO4E
{
    [TestClass]
    public class TestJsonSchemeGeneration
    {
        [TestMethod]
        public void BasicTest()
        {
            Messlokation melo = new Messlokation();
            string result;
            result = melo.GetJsonScheme().ToString();

            Energiemenge em = new Energiemenge();
            result = em.GetJsonScheme().ToString();

            string result2 = BusinessObject.GetJsonScheme(typeof(Energiemenge)).ToString();
            Assert.AreEqual(result, result2);
        }

        [TestMethod]
        public void NegativeTest()
        {
            bool expectionThrown = false;
            try
            {
                BusinessObject.GetJsonScheme(typeof(string));
            }
            catch (ArgumentException)
            {
                expectionThrown = true;
            }
            Assert.IsTrue(expectionThrown, "Illegal types must result in a ArgumentException.");
        }
    }
}
