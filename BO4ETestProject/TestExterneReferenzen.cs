using BO4E.BO;
using BO4E.COM;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

namespace TestBO4E
{
    [TestClass]
    public class TestExterneReferenzen
    {
        [TestMethod]
        public void TestDeserialization()
        {
            var marktlokation = new Marktlokation()
            {
                MarktlokationsId = "54321012345",
            };
            Assert.IsFalse(marktlokation.TryGetExterneReferenz("foo", out var _));
            marktlokation.ExterneReferenzen = new List<ExterneReferenz>()
            {
            };
            Assert.IsFalse(marktlokation.TryGetExterneReferenz("foo", out var _));
            marktlokation.ExterneReferenzen.Add(new ExterneReferenz() { ExRefName = "foo", ExRefWert = "bar" });
            Assert.IsTrue(marktlokation.TryGetExterneReferenz("foo", out var actualBar));
            Assert.AreEqual("bar", actualBar);
        }
    }
}