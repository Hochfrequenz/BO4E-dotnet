using System;
using System.Collections.Generic;
using System.IO;
using BO4E.BO;
using BO4E.COM;
using BO4E.ENUM;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProtoBuf;

namespace TestBO4E
{
    [TestClass]
    public class TestProtobufSerialization
    {
        [TestMethod]
        public void TestProtobufRoundTrip()
        {
            //Guid emGuid = Guid.NewGuid();
            //Guid v1Guid = Guid.NewGuid();
            var em = new Energiemenge
            {
                LokationsId = "54321012345",
                LokationsTyp = Lokationstyp.MaLo,
                //Guid = emGuid,
                Energieverbrauch = new List<Verbrauch>
                {
                    new()
                    {
                        Einheit = Mengeneinheit.KWH,
                        Wert = 10.0M,
                        Startdatum = new DateTime(2019, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                        Enddatum = new DateTime(2019, 1, 2, 0, 0, 0, DateTimeKind.Utc),
                        Obiskennzahl = "1-0:1.8.1"
                        //Guid = v1Guid
                    },
                    new()
                    {
                        Einheit = Mengeneinheit.MWH,
                        Wert = 23.0M,
                        Startdatum = new DateTime(2019, 1, 2, 0, 0, 0, DateTimeKind.Utc),
                        Enddatum = new DateTime(2019, 1, 3, 0, 0, 0, DateTimeKind.Utc),
                        Obiskennzahl = "1-0:1.8.1"
                        //Guid = null
                    }
                }
            };
            Assert.IsTrue(em.IsValid(), "Must not serialize invalid Business Objects.");
            string emBase64;
            using (var stream = new MemoryStream())
            {
                Serializer.Serialize(stream, em);
                using var reader = new BinaryReader(stream);
                emBase64 = Convert.ToBase64String(stream.ToArray());
            }

            Assert.IsFalse(string.IsNullOrWhiteSpace(emBase64));

            // now use base64 string to get back the original energiemenge
            Energiemenge emRoundTrip;
            using (var backStream = new MemoryStream(Convert.FromBase64String(emBase64)))
            {
                backStream.Seek(0, SeekOrigin.Begin);
                emRoundTrip = Serializer.Deserialize<Energiemenge>(backStream);
            }

            Assert.IsNotNull(emRoundTrip.LokationsId);
            Assert.IsTrue(emRoundTrip.IsValid());
            /*
            Assert.IsTrue(emRoundTrip.Guid.HasValue);
            Assert.AreEqual(emGuid, em.Guid.Value);
            Assert.IsTrue(emRoundTrip.Energieverbrauch.First().Guid.HasValue);
            Assert.AreEqual(v1Guid, emRoundTrip.Energieverbrauch.First().Guid.Value);
            Assert.IsFalse(emRoundTrip.Energieverbrauch.Last().Guid.HasValue);
            */

            Assert.AreEqual(em, emRoundTrip);
        }
    }
}