using System;
using System.Collections.Generic;
using BO4E.BO;
using BO4E.COM;
using BO4E.ENUM;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace TestBO4E
{
    [TestClass]
    public class TestEqualities
    {
        [TestMethod]
        public void TestEqualsCOM()
        {
            var v1 = new Verbrauch();
            var v2 = new Verbrauch();
            Assert.ThrowsException<JsonSerializationException>(() => v1.Equals(v2),
                "You must not compare invalid/incomplete COMs");
            Assert.AreEqual(v1.GetHashCode(), v2.GetHashCode());


            v1 = new Verbrauch
            {
                Einheit = Mengeneinheit.KWH,
                Obiskennzahl = "1-1:1.8.0",
                Startdatum = new DateTime(2019, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                Enddatum = new DateTime(2020, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            };
            v2 = new Verbrauch
            {
                Einheit = Mengeneinheit.KWH,
                Obiskennzahl = "1-1:1.8.0",
                Startdatum = new DateTime(2019, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                Enddatum = new DateTime(2020, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            };

            Assert.AreEqual(v1, v2);
            Assert.IsTrue(v1.Equals(v2));
            Assert.AreEqual(v1.GetHashCode(), v2.GetHashCode());
            Assert.IsFalse(v1 == v2);

            v2.Obiskennzahl = "1-1:1.8.1";
            Assert.AreNotEqual(v1, v2);
            Assert.AreNotEqual(v1.GetHashCode(), v2.GetHashCode());
            Assert.AreNotEqual(new Preis(), new Menge());
        }

        [TestMethod]
        public void TestEqualsBO()
        {
            var em1 = new Energiemenge();
            var em2 = new Energiemenge();
            Assert.ThrowsException<ArgumentException>(() => em1.Equals(em2));
            Assert.AreEqual(em1.GetHashCode(), em2.GetHashCode());

            em1.LokationsId = "DE1234";
            em2.LokationsId = "DE1234";

            em1.LokationsTyp = Lokationstyp.MeLo;
            em2.LokationsTyp = Lokationstyp.MeLo;

            em1.Energieverbrauch = new List<Verbrauch>();
            var v1 = new Verbrauch
            {
                Obiskennzahl = "1-2-3-4-5"
            };
            em1.Energieverbrauch.Add(v1);
            em2.Energieverbrauch = new List<Verbrauch>();
            var v2 = new Verbrauch
            {
                Obiskennzahl = "1-2-3-4-5"
            };
            em2.Energieverbrauch.Add(v2);

            Assert.AreEqual(em1, em2);
            //Assert.AreEqual(em1.GetHashCode(), em2.GetHashCode());
            Assert.IsFalse(em1 == em2);

            var v3 = new Verbrauch
            {
                Einheit = Mengeneinheit.KWH,
                Obiskennzahl = "ABC",
                Startdatum = new DateTime(2018, 1, 1),
                Enddatum = new DateTime(2018, 12, 31),
                Wert = 123.456M
            };
            em1.Energieverbrauch = new List<Verbrauch> { v3 };
            em2.Energieverbrauch = new List<Verbrauch> { v3 };
            Assert.AreEqual(em1, em2);
            //Assert.AreEqual(em1.GetHashCode(), em2.GetHashCode());
            Assert.IsFalse(em1 == em2);

            var v4 = JsonConvert.DeserializeObject<Verbrauch>(JsonConvert.SerializeObject(v1));
            v4.Wert = 789.012M;
            em1.Energieverbrauch.Add(v4);
            Assert.AreNotEqual(em1, em2);

            em2.Energieverbrauch.Add(v4);
            Assert.AreEqual(em1, em2);

            em1.Energieverbrauch = new List<Verbrauch> { v3, v4 };
            em2.Energieverbrauch = new List<Verbrauch> { v4, v3 };

            Assert.AreNotEqual(em1, em2);
            //Assert.AreNotEqual(em1.GetHashCode(), em2.GetHashCode());
        }
    }
}