
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using BO4E.BO;
using BO4E.COM;
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
            Energiemenge em = new Energiemenge()
            {
                lokationsId = "54321012345",
                lokationstyp = BO4E.ENUM.Lokationstyp.MaLo,
                energieverbrauch = new System.Collections.Generic.List<Verbrauch>()
                {
                    new Verbrauch()
                    {
                        einheit = BO4E.ENUM.Mengeneinheit.KWH,
                        wert = 10.0M,
                        startdatum = new DateTime(2019, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                        enddatum = new DateTime(2019, 1, 2, 0, 0, 0, DateTimeKind.Utc),
                        obiskennzahl =  "1–0:1.8.1"
                    },
                    new Verbrauch()
                    {
                        einheit = BO4E.ENUM.Mengeneinheit.KWH,
                        wert = 23.0M,
                        startdatum = new DateTime(2019, 1, 2, 0, 0, 0, DateTimeKind.Utc),
                        enddatum = new DateTime(2019, 1, 3, 0, 0, 0, DateTimeKind.Utc),
                        obiskennzahl =  "1–0:1.8.1"
                    }
                },
                guid = Guid.NewGuid().ToString()
            };
            Assert.IsTrue(em.IsValid(), "Must not serialize invalid Business Objects.");
            string emBase64;
            using (var stream = new MemoryStream())
            {
                Serializer.PrepareSerializer<Energiemenge>();
                Serializer.Serialize(stream, em);
                using (var reader = new BinaryReader(stream))
                {
                    var content = reader.ReadBytes((int)stream.Length);
                    emBase64 = Convert.ToBase64String(content);
                }
            }

            // now use base64 string to get back the original energiemenge

            Energiemenge emRoundTrip;
            using (var backStream = new MemoryStream(Convert.FromBase64String(emBase64)))
            {
                emRoundTrip = Serializer.Deserialize<Energiemenge>(backStream);
            }
            Assert.AreEqual(em, emRoundTrip);
        }
    }
}
