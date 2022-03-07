using System;
using System.Collections.Generic;
using BO4E.BO;
using BO4E.COM;
using BO4E.ENUM;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace TestBO4E
{
    [TestClass]
    public class TestBOCOMGuids
    {
        [TestMethod]
        public void TestBOGuidsNewtonsoft()
        {
            var em = new Energiemenge
            {
                LokationsId = "DE123456",
                LokationsTyp = Lokationstyp.MALO,
                Energieverbrauch = new List<Verbrauch>(),
                Guid = Guid.NewGuid()
            };

            var emJson = JsonConvert.SerializeObject(em);
            Assert.AreEqual(em.Guid.Value, JsonConvert.DeserializeObject<Energiemenge>(emJson).Guid.Value);

            var gp = new Geschaeftspartner
            {
                Gewerbekennzeichnung = true,
                Guid = Guid.NewGuid()
            };

            var gpJson = JsonConvert.SerializeObject(gp);
            Assert.AreEqual(gp.Guid.Value, JsonConvert.DeserializeObject<Geschaeftspartner>(gpJson).Guid.Value);
        }

        [TestMethod]
        public void TestBOGuids()
        {
            var em = new Energiemenge
            {
                LokationsId = "DE123456",
                LokationsTyp = Lokationstyp.MALO,
                Energieverbrauch = new List<Verbrauch>(),
                Guid = Guid.NewGuid()
            };

            var emJson = JsonSerializer.Serialize(em);
            Assert.AreEqual(em.Guid.Value, JsonSerializer.Deserialize<Energiemenge>(emJson).Guid.Value);
            var gp = new Geschaeftspartner
            {
                Gewerbekennzeichnung = true,
                Guid = Guid.NewGuid()
            };

            var gpJson = JsonSerializer.Serialize(gp);
            Assert.AreEqual(gp.Guid.Value, JsonSerializer.Deserialize<Geschaeftspartner>(gpJson).Guid.Value);
        }
    }
}