using System.Collections.Generic;
using BO4E.ENUM;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TestBO4E
{
    [TestClass]
    public class TestStringEnumConverter
    {
        [TestMethod]
        public void TestMengeneinheit()
        {
            IList<Mengeneinheit> einheiten = new List<Mengeneinheit>
            {
                Mengeneinheit.TAG
            };
            string jsonString = JsonConvert.SerializeObject(einheiten, new StringEnumConverter());
            Assert.IsTrue(jsonString.Contains("TAG"));
        }
    }
}
