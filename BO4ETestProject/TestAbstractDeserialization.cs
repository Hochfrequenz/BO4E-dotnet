using System.IO;
using BO4E.BO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TestBO4E
{
    [TestClass]
    public class TestAbstractDeserialization
    {
        [TestMethod]
        public void TestMaLoDeserialization()
        {
            JObject json;
            using (StreamReader r = new StreamReader("BoMapperTests/marktlokation_simple.json"))
            {
                string jsonString = r.ReadToEnd();
                json = JObject.Parse(jsonString);
            }
            string maloString = json["input"].ToString();
            Marktlokation malo = JsonConvert.DeserializeObject<Marktlokation>(maloString);
            Assert.IsNotNull(malo);
            BusinessObject bo = JsonConvert.DeserializeObject<BusinessObject>(maloString);
            Assert.IsNotNull(bo);
            Assert.IsInstanceOfType(bo, typeof(Marktlokation));
        }
    }
}
