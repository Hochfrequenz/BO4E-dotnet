using BO4E.Extensions.Encryption;
using BO4E.meta;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace TestBO4EExtensions.Encryption
{
    [TestClass]
    public class TestAnonymizerConfiguration
    {
        [TestMethod]
        public void TestAcDeserialization()
        {
            var ac = JsonConvert.DeserializeObject<AnonymizerConfiguration>("{\"operations\":{\"POD\":\"HASH\"},\"unaffectedUserProperties\":[\"asd\",\"xyz\"]}");
            Assert.IsTrue(ac.Operations.ContainsKey(DataCategory.POD));
            Assert.AreEqual(AnonymizerApproach.HASH, ac.Operations[DataCategory.POD]);
            Assert.IsTrue(ac.ContainsNonKeepingOperations());
            Assert.IsNotNull(ac.UnaffectedUserProperties);
            Assert.IsTrue(ac.UnaffectedUserProperties.Contains("asd"));
            Assert.IsTrue(ac.UnaffectedUserProperties.Contains("xyz"));
        }

        [TestMethod]
        public void TestAcInitial()
        {
            var ac = new AnonymizerConfiguration();
            Assert.IsTrue(ac.IsInitial());
            Assert.IsFalse(ac.ContainsNonKeepingOperations());
            ac.SetOption(DataCategory.ADDRESS, AnonymizerApproach.ENCRYPT);
            Assert.IsTrue(ac.ContainsNonKeepingOperations());
            Assert.IsFalse(ac.IsInitial());
        }

        [TestMethod]
        public void TestAcSalt()
        {
            var ac = new AnonymizerConfiguration
            {
                HashingSalt = "UG9seWZvbiB6d2l0c2NoZXJuZCBhw59lbiBNw6R4Y2hlbnMgVsO2Z2VsIFLDvGJlbiwgSm9naHVydCB1bmQgUXVhcms="
            };
            Assert.IsTrue(ac.GetSalt().Length > 0);
            ac.HashingSalt = "   ";
            Assert.IsTrue(ac.GetSalt().Length == 0);
            ac.HashingSalt = null;
            Assert.IsTrue(ac.GetSalt().Length == 0);
        }
    }
}