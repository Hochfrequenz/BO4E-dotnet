using System;
using System.Collections.Generic;
using BO4E.BO;
using BO4E.COM;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace TestBO4E
{
    [TestClass]
    public class TestNotizDeserialization
    {
        [TestMethod]
        public void TestMinusRemoval()
        {
            Notiz n = JsonConvert.DeserializeObject<Notiz>("{\"klaerfallnummer\":\"468982\",\"autor\":\"Konstantin Klein\",\"zeitpunkt\":\"2019-05-24T14:05:00Z\",\"inhalt\":\"hallo. das ist eine notiz mit einem lustigen emoji 🥝\n------------------------------------------------------------------------\",\"tdid\":\"0002\",\"tdname\":\"0000468982\",\"tdobject\":\"EMMA_CASE\"}");
            Assert.AreEqual("hallo. das ist eine notiz mit einem lustigen emoji 🥝", n.inhalt);
        }
    }
}
