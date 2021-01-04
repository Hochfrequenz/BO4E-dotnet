using BO4E.BO;
using BO4E.COM;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;

namespace TestBO4E
{
    [TestClass]
    public class TestBOCOMGuids
    {
        [TestMethod]
        public void TestBOGuids()
        {
            var em = new Energiemenge()
            {
                LokationsId = "DE123456",
                LokationsTyp = BO4E.ENUM.Lokationstyp.MaLo,
                Energieverbrauch = new List<Verbrauch>(),
                Guid = Guid.NewGuid()
            };

            var emJson = JsonConvert.SerializeObject(em);
            Assert.AreEqual<Guid>(em.Guid.Value, JsonConvert.DeserializeObject<Energiemenge>(emJson).Guid.Value);

            var gp = new Geschaeftspartner()
            {
                Gewerbekennzeichnung = true,
                Guid = Guid.NewGuid()
            };

            var gpJson = JsonConvert.SerializeObject(gp);
            Assert.AreEqual<Guid>(gp.Guid.Value, JsonConvert.DeserializeObject<Geschaeftspartner>(gpJson).Guid.Value);
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
