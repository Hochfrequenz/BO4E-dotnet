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
            Assert.IsNotNull(melo.UserProperties);
            Assert.AreEqual("some_value_not_covered_by_bo4e", melo.UserProperties["myCustomInfo"].ToObject<string>());
            Assert.AreEqual(123.456M, melo.UserProperties["myCustomValue"].ToObject<decimal>());
        }

        [TestMethod]
        public void TestTryGetUserProperties()
        {
            string meloJson = @"{'messlokationsId': 'DE0123456789012345678901234567890', 'sparte': 'STROM', 'myCustomInfo': 'some_value_not_covered_by_bo4e', 'myCustomValue': 123.456}";
            var melo = JsonConvert.DeserializeObject<Messlokation>(meloJson);
            Assert.IsTrue(melo.TryGetUserProperty("myCustomInfo", out string myCustomValue));
            Assert.AreEqual("some_value_not_covered_by_bo4e", myCustomValue);
            Assert.IsFalse(melo.TryGetUserProperty("something else", out string _));
            Assert.AreEqual("default value", melo.GetUserProperty("something else", "default value"));
        }
    }
}