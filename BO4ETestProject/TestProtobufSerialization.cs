
using System;
using System.IO;
using System.Linq;
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
                        einheit = BO4E.ENUM.Mengeneinheit.MWH,
                        wert = 23.0M,
                        startdatum = new DateTime(2019, 1, 2, 0, 0, 0, DateTimeKind.Utc),
                        enddatum = new DateTime(2019, 1, 3, 0, 0, 0, DateTimeKind.Utc),
                        obiskennzahl =  "1–0:1.8.1"
                    }
                }
            };
            Assert.IsTrue(em.IsValid(), "Must not serialize invalid Business Objects.");
            string emBase64;
            using (var stream = new MemoryStream())
            {
                Serializer.Serialize<Energiemenge>(stream, em);
                using (var reader = new BinaryReader(stream))
                {
                    emBase64 = Convert.ToBase64String(stream.ToArray());
                }
            }
            Assert.IsFalse(string.IsNullOrWhiteSpace(emBase64));

            // now use base64 string to get back the original energiemenge
            Energiemenge emRoundTrip;
            using (var backStream = new MemoryStream(Convert.FromBase64String(emBase64)))
            {
                backStream.Seek(0, SeekOrigin.Begin);
                emRoundTrip = Serializer.Deserialize<Energiemenge>(backStream);
            }
            Assert.IsNotNull(emRoundTrip.lokationsId);
            Assert.IsTrue(emRoundTrip.IsValid());
            Assert.AreEqual(em, emRoundTrip);
        }
    }
}
