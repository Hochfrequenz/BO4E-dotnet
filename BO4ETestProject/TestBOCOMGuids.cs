using System;
using System.Collections.Generic;
using BO4E.BO;
using BO4E.COM;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace TestBO4E
{
    [TestClass]
    public class TestBOCOMGuids
    {
        [TestMethod]
        public void TestBOGuids()
        {
            Energiemenge em = new Energiemenge()
            {
                lokationsId = "DE123456",
                lokationstyp = BO4E.ENUM.Lokationstyp.MaLo,
                energieverbrauch = new List<Verbrauch>(),
                guid = Guid.NewGuid().ToString()
            };

            string jsonString = JsonConvert.SerializeObject(em);
            Assert.AreEqual<string>(em.guid, JsonConvert.DeserializeObject<Energiemenge>(jsonString).guid);
        }
        /*
        [TestMethod]
        public void TestCOMGuids()
        {
            Rechnungsposition rp = new Rechnungsposition()
            {
                lokationsId = "De123456",
                positionsnummer = 1,
                guid = Guid.NewGuid().ToString()
            };

            string jsonString = JsonConvert.SerializeObject(rp);
        }*/

    }
}
