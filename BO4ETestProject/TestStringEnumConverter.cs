using System.Collections.Generic;
using System.Text.Json;
using BO4E.ENUM;
using BO4E.meta.LenientConverters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TestBO4E
{
    [TestClass]
    public class TestStringEnumConverter
    {
        private readonly IList<Mengeneinheit> einheiten = new List<Mengeneinheit>
        {
            Mengeneinheit.TAG
        };
        [TestMethod]
        public void TestMengeneinheitNewtonsoft()
        {

            var jsonString = JsonConvert.SerializeObject(einheiten, new StringEnumConverter());
            Assert.IsTrue(jsonString.Contains("TAG"));
        }

        [TestMethod]
        public void TestMengeneinheit()
        {
            var options = new JsonSerializerOptions()
            {
                Converters = { new StringNullableEnumConverter() }
            };
            var jsonString = System.Text.Json.JsonSerializer.Serialize(einheiten, options);
            Assert.IsTrue(jsonString.Contains("TAG"));
        }
    }
}
