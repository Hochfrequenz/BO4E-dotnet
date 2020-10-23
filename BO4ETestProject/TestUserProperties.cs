using BO4E.BO;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Newtonsoft.Json;

using System;

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
            string meloJson = @"{'messlokationsId': 'DE0123456789012345678901234567890', 'sparte': 'STROM', 'myCustomInfo': 'some_value_not_covered_by_bo4e', 'myCustomValue': 123.456, 'myNullProp': null}";
            var melo = JsonConvert.DeserializeObject<Messlokation>(meloJson);
            Assert.IsTrue(melo.TryGetUserProperty("myCustomInfo", out string myCustomValue));
            Assert.AreEqual("some_value_not_covered_by_bo4e", myCustomValue);
            Assert.IsTrue(melo.UserPropertyEquals("myCustomValue", 123.456M));
            Assert.IsFalse(melo.UserPropertyEquals("myCustomValue", "foo"));

            Assert.IsFalse(melo.TryGetUserProperty("something else", out string _));
            Assert.AreEqual("default value", melo.GetUserProperty("something else", "default value"));
            Assert.IsFalse(melo.UserPropertyEquals("myCustomInfo", 888.999M)); // the cast exception is catched inside.
            Assert.IsFalse(melo.UserPropertyEquals("myCustomValue", "asd")); // the cast exception is catched inside.
            Assert.IsFalse(melo.UserPropertyEquals("some_key_that_was_not_found", "asd"));
            Assert.IsTrue(melo.EvaluateUserProperty<string, bool>("myCustomInfo", up => !string.IsNullOrEmpty(up)));

            melo.UserProperties = null;
            Assert.IsFalse(melo.UserPropertyEquals("there are no user properties", "asd"));
            Assert.IsFalse(melo.TryGetUserProperty("there are no user properties", out string _));
            Assert.ThrowsException<ArgumentNullException>(() => melo.EvaluateUserProperty<string, bool>("there are no user properties", _ => default));
            Assert.IsFalse(melo.UserPropertyEquals("myNullProp", true));
        }
    }
}