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
                LokationsId = "DE123456",
                LokationsTyp = BO4E.ENUM.Lokationstyp.MaLo,
                Energieverbrauch = new List<Verbrauch>(),
                Guid = Guid.NewGuid().ToString()
            };

            string emJson = JsonConvert.SerializeObject(em);
            Assert.AreEqual<string>(em.Guid, JsonConvert.DeserializeObject<Energiemenge>(emJson).Guid);

            Geschaeftspartner gp = new Geschaeftspartner()
            {
                Gewerbekennzeichnung = true,
                Guid = Guid.NewGuid().ToString()
            };

            string gpJson = JsonConvert.SerializeObject(gp);
            Assert.AreEqual<string>(gp.Guid, JsonConvert.DeserializeObject<Geschaeftspartner>(gpJson).Guid);
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
