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
            Assert.IsTrue(ac.operations.ContainsKey(DataCategory.POD));
            Assert.AreEqual(AnonymizerApproach.HASH, ac.operations[DataCategory.POD]);
            Assert.IsTrue(ac.ContainsNonKeepingOperations());
            Assert.IsNotNull(ac.unaffectedUserProperties);
            Assert.IsTrue(ac.unaffectedUserProperties.Contains("asd"));
            Assert.IsTrue(ac.unaffectedUserProperties.Contains("xyz"));
        }

        [TestMethod]
        public void TestAcInitial()
        {
            AnonymizerConfiguration ac = new AnonymizerConfiguration();
            Assert.IsTrue(ac.IsInitial());
            Assert.IsFalse(ac.ContainsNonKeepingOperations());
            ac.SetOption(DataCategory.ADDRESS, AnonymizerApproach.ENCRYPT);
            Assert.IsTrue(ac.ContainsNonKeepingOperations());
            Assert.IsFalse(ac.IsInitial());
        }

        [TestMethod]
        public void TestAcSalt()
        {
            AnonymizerConfiguration ac = new AnonymizerConfiguration
            {
                hashingSalt = "UG9seWZvbiB6d2l0c2NoZXJuZCBhw59lbiBNw6R4Y2hlbnMgVsO2Z2VsIFLDvGJlbiwgSm9naHVydCB1bmQgUXVhcms="
            };
            Assert.IsTrue(ac.GetSalt().Length>0);
            ac.hashingSalt = "   ";
            Assert.IsTrue(ac.GetSalt().Length == 0);
            ac.hashingSalt = null;
            Assert.IsTrue(ac.GetSalt().Length == 0);
        }
    }
}