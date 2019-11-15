using System;
using System.Collections.Generic;
using BO4E.BO;
using BO4E.COM;
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
            Verbrauch v1 = new Verbrauch();
            Verbrauch v2 = new Verbrauch();
            Assert.ThrowsException<JsonSerializationException>(() => v1.Equals(v2), "You must not compare invalid/incomplete COMs");
            Assert.AreEqual(v1.GetHashCode(), v2.GetHashCode());

            v1.einheit = BO4E.ENUM.Mengeneinheit.KUBIKMETER;
            v2.einheit = BO4E.ENUM.Mengeneinheit.KUBIKMETER;

            v1.startdatum = new DateTime(2018, 1, 1);
            v2.startdatum = new DateTime(2018, 1, 1);

            v1.enddatum = new DateTime(2019, 12, 31);
            v2.enddatum = new DateTime(2019, 12, 31);

            v1.obiskennzahl = "abc";
            v2.obiskennzahl = "abc";

            Assert.AreEqual(v1, v2);
            Assert.AreEqual(v1.GetHashCode(), v2.GetHashCode());
            Assert.IsFalse(v1 == v2);

            v2.obiskennzahl = "def";
            Assert.AreNotEqual(v1, v2);
            Assert.AreNotEqual(v1.GetHashCode(), v2.GetHashCode());
            Assert.AreNotEqual(new Preis(), new Menge());
        }

        [TestMethod]
        public void TestEqualsBO()
        {
            Energiemenge em1 = new Energiemenge();
            Energiemenge em2 = new Energiemenge();
            Assert.ThrowsException<ArgumentException>(() => em1.Equals(em2));
            Assert.AreEqual(em1.GetHashCode(), em2.GetHashCode());

            em1.lokationsId = "DE1234";
            em2.lokationsId = "DE1234";

            em1.lokationstyp = BO4E.ENUM.Lokationstyp.MeLo;
            em2.lokationstyp = BO4E.ENUM.Lokationstyp.MeLo;

            em1.energieverbrauch = new List<Verbrauch>();
            Verbrauch v1 = new Verbrauch();
            v1.obiskennzahl = "1-2-3-4-5";
            em1.energieverbrauch.Add(v1);
            em2.energieverbrauch = new List<Verbrauch>();
            Verbrauch v2 = new Verbrauch();
            v2.obiskennzahl = "1-2-3-4-5";
            em2.energieverbrauch.Add(v2);

            Assert.AreEqual(em1, em2);
            Assert.AreEqual(em1.GetHashCode(), em2.GetHashCode());
            Assert.IsFalse(em1 == em2);

            Verbrauch v3 = new Verbrauch();
            v3.einheit = BO4E.ENUM.Mengeneinheit.KWH;
            v3.obiskennzahl = "ABC";
            v3.startdatum = new DateTime(2018, 1, 1);
            v3.enddatum = new DateTime(2018, 12, 31);
            v3.wert = 123.456M;
            em1.energieverbrauch = new List<Verbrauch> { v3 };
            em2.energieverbrauch = new List<Verbrauch> { v3 };
            Assert.AreEqual(em1, em2);
            Assert.AreEqual(em1.GetHashCode(), em2.GetHashCode());
            Assert.IsFalse(em1 == em2);

            Verbrauch v4 = JsonConvert.DeserializeObject<Verbrauch>(JsonConvert.SerializeObject(v1));
            v4.wert = 789.012M;
            em1.energieverbrauch.Add(v4);
            Assert.AreNotEqual(em1, em2);

            em2.energieverbrauch.Add(v4);
            Assert.AreEqual(em1, em2);

            em1.energieverbrauch = new List<Verbrauch> { v3, v4 };
            em2.energieverbrauch = new List<Verbrauch> { v4, v3 };

            Assert.AreNotEqual(em1, em2);
            Assert.AreNotEqual(em1.GetHashCode(), em2.GetHashCode());
        }

    }
}