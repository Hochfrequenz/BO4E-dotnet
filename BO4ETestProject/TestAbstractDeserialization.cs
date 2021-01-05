using BO4E.BO;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System.IO;

namespace TestBO4E
{
    [TestClass]
    public class TestAbstractDeserialization
    {
        [TestMethod]
        public void TestMaLoDeserialization()
        {
            JObject json;
            using (var r = new StreamReader("BoMapperTests/marktlokation_simple.json"))
            {
                var jsonString = r.ReadToEnd();
                json = JObject.Parse(jsonString);
            }
            var maloString = json["input"].ToString();
            var malo = JsonConvert.DeserializeObject<Marktlokation>(maloString);
            Assert.IsNotNull(malo);
            var bo = JsonConvert.DeserializeObject<BusinessObject>(maloString);
            Assert.IsNotNull(bo);
            Assert.IsInstanceOfType(bo, typeof(Marktlokation));
        }

        [TestMethod]
        public void TestMaLoTypeNameHandlingDeserialization()
        {
            JObject json;
            using (var r = new StreamReader("BoMapperTests/marktlokation_with_typenamehandling.json"))
            {
                var jsonString = r.ReadToEnd();
                json = JObject.Parse(jsonString);
            }
            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Objects
            };
            var maloString = json["input"].ToString();
            var malo = JsonConvert.DeserializeObject<Marktlokation>(maloString, settings);
            Assert.IsNotNull(malo);
            var bo = JsonConvert.DeserializeObject<BusinessObject>(maloString, settings);
            Assert.IsNotNull(bo);
            Assert.IsInstanceOfType(bo, typeof(Marktlokation));
        }
    }
}