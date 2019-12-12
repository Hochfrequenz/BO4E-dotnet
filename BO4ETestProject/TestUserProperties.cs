using BO4E.BO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace TestBO4E
{
    [TestClass]
    public class TestUserProperties
    {
        [TestMethod]
        public void TestDeserialization()
        {
            string meloJson = @"{'messlokationsId': 'DE0123456789012345678901234567890', 'sparte': 'STROM', 'myCustomInfo': 'some_value_not_covered_by_bo4e', 'myCustomValue': 123.456}";
            var melo = JsonConvert.DeserializeObject<Messlokation>(meloJson);
            Assert.IsTrue(melo.IsValid());
            Assert.IsNotNull(melo.userProperties);
            Assert.AreEqual("some_value_not_covered_by_bo4e", melo.userProperties["myCustomInfo"].ToObject<string>());
            Assert.AreEqual(123.456M, melo.userProperties["myCustomValue"].ToObject<decimal>());
        }
    }

}
